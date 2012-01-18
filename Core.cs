using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using cacheCopy.filters;
using System.ComponentModel;

namespace cacheCopy
{
    /// <summary>
    /// The main operational class.
    /// Here we take information from GUI, read files, apply filters and 
    /// actually do copy files.
    /// </summary>
    public class Core
    {

        private List<IFilter> filters;
        private List<FileInfo> files;
        private MainGUI mainGUI;
        private List<String> errors;


        public Core()
        {
            files = new List<FileInfo>();
            filters = new List<IFilter>();
            errors = new List<string>();
        }



        /// <summary>
        /// Setter for GUI object
        /// </summary>
        /// <param name="gui">The GUI object</param>
        public void setMainGUI(ref MainGUI gui) 
        {
            mainGUI = gui;
        }


        /// <summary>
        /// Adds the filter to the list of filters.
        /// Filters are processed int he same way they are added
        /// So please add them in the most efficient way.
        /// </summary>
        /// <param name="filter">The filter object</param>
        public void addFilter(IFilter filter)
        {
            filters.Add(filter);
        }


        /// <summary>
        /// Reads the files from the source directory and 
        /// puts them in files list.
        /// </summary>
        /// <param name="path">The path of source directory to read files from</param>
        public void readFiles(String path)
        {
            files.Clear();
            files = Util.WalkDirectory(path);
        }



        /// <summary>
        /// Getter for list of files.
        /// </summary>
        /// <returns></returns>
        public List<FileInfo> getFiles()
        {
            return files;
        }





        /// <summary>
        /// Calculate the current progress of the execution
        /// by total number of files and current file processed.
        /// And update the worker with count from 0 to 100
        /// </summary>
        /// <param name="totalFiles">The total number of files involved.</param>
        /// <param name="currentCount">The current number of file processed.</param>
        /// <param name="worker">The background worker to update.</param>
        public void reportProgress(int totalFiles, int currentCount, BackgroundWorker worker)
        {
            // calculate total progress for all the files
            // +0.01 to avoid division by zero
            double totalProgress = currentCount * 100.0 / (totalFiles+0.01);

            // update the worker with current progress
            worker.ReportProgress((int)totalProgress);

        }


        /// <summary>
        /// Applies the filters to the files.
        /// Given list of files, and list of filters, apply 
        /// every filter to every file. If file does not get through 
        /// the filter, remove it from the list.
        /// </summary>
        /// <param name="files">The list of files</param>
        /// <param name="filters">The list of filters to apply</param>
        private void applyFilters(BackgroundWorker worker, DoWorkEventArgs e)
        {

            //List<String> errors = new List<string>();
            if (files.Count < 1)
            {
                errors.Add("There are no files to work with");
                return;
            }

            for (int i = files.Count-1; i >= 0; i--)
            {
                // check if the routine was not cancelled by the user
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    errors.Add("Cancelled by user");
                    break;
                }


                FileInfo file = files[i];
                foreach (IFilter filter in filters)
                {
                    bool checkFilter = true;
                    // some of the filters can cause Exceptions
                    try
                    {
                        checkFilter = filter.checkFile(file);
                    }
                    catch (Exception ex)
                    {
                        // catch all the errors that might come up 
                        // we don't want to throw errors on them 
                        // instead save the error messages for every file in an array.
                        errors.Add(ex.Message);
                        checkFilter = false;
                    }

                    // If file does not fall through the filter,
                    if (!checkFilter)
                    {
                        // remove the file from the array
                        files.RemoveAt(i);
                        // and move on to the next file, ignore the rest of the filters
                        break;
                    }

                }
                // update the progress bar
                reportProgress(files.Count, files.Count-i, worker);
            }

        }



        /// <summary>
        /// Generates the name of the file, checks if the file
        /// already exists and appends (%number%) at the end of the name.
        /// </summary>
        /// <param name="dirName">Name of the directory</param>
        /// <param name="fileName">Name of the file</param>
        /// <param name="extension">The extension</param>
        /// <returns>String with full path of the file</returns>
        public static string generateFileName(string dirName, string fileName, string extension)
        {
            // if the filename already has the extension, we just remove it.
            if (fileName.ToLower().EndsWith(extension.ToLower()))
            {
                fileName = fileName.Remove(fileName.Length - extension.Length);
            }
            // create file name, as if there no file with that name
            string newName = Path.Combine(dirName, fileName + extension);
            int i = 0;
            while (File.Exists(newName))    // check if file exists
            {
                i++;    // if file exists, add counter
                // and add the number to the file name
                newName = Path.Combine(dirName, fileName + "(" + i.ToString() + ")" + extension);
            }

            return newName;
        }





        /// <summary>
        /// Executes the main routine: reads information from form
        /// and accordingly to the settings copies the files from one place to another
        /// </summary>
        public void executeMainRoutine(BackgroundWorker worker, DoWorkEventArgs e)
        {
            mainGUI.setProgressLabel("Reading files");

            List<String> errors = new List<string>();

            readFiles(mainGUI.getSourceFolder());

            // read data about filters from GUI and set the filters in Core
            setFilters();

            mainGUI.setProgressLabel("Filtering files");
            // apply filters to files and save error messages from there
            applyFilters(worker, e);

            int totalFilesCopied = 0;
            // finally copy the files
            string targetFolder = mainGUI.getTargetFolder();
            for (int i = 0; i < files.Count; i++ )
            {
                FileInfo file = files[i];
                mainGUI.setProgressLabel("Copying files: "+i.ToString()+"/"+files.Count.ToString());
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    errors.Add("Cancelled by user");
                    break;
                }

                string newPath = Core.generateFileName(targetFolder, file.Name, ".jpg");

                try
                {
                    file.CopyTo(newPath);
                    totalFilesCopied++;
                }
                catch (IOException)
                {
                    errors.Add("Could not copy file: " + file.Name);
                }

                // update progress bar
                reportProgress(files.Count, i, worker);

            }
            mainGUI.setProgressLabel("");
            //return errors;
            e.Result = totalFilesCopied;
        }






        /// <summary>
        /// Read required filters from the GUI and then put them in the queue
        /// for processing of the images
        /// </summary>
        private void setFilters()
        {
            // remove filters from the previous execution. In case the settings has changed
            filters.Clear();

            // check if the checkbox is set
            if ( mainGUI.getHours() != null )
            {
                // if checkbox is set on hours, set the filter
                IFilter dateFilter = new DateFilter(
                    DateTime.Now.AddHours(-1* (int)mainGUI.getHours()));
                addFilter(dateFilter);
                    
            }

            if (mainGUI.getKilobytes() != null)
            {
                IFilter sizeFilter = new SizeFilter((int)mainGUI.getKilobytes() * 1000);
                addFilter(sizeFilter);
                
            }


             // always add jpeg filter before filter with image size.
            IFilter jpegFilter = new JpegFilter();
            addFilter(jpegFilter);


            // we only need to check if one of the dimensions is set,
            // as both of them are required on the form.
            if (mainGUI.getMinHeight() != null)
            {
                int minWidth = (int)mainGUI.getMinWidth();
                int minHeight = (int)mainGUI.getMinHeight();
                IFilter imageSizeFilter = new ImageSizeFilter(minWidth, minHeight);
                addFilter(imageSizeFilter);
            }

        }



    }
}
