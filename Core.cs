﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using cacheCopy.filters;

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
        /// Executes the main routine: reads information from form
        /// and accordingly to the settings copies the files from one place to another
        /// </summary>
        public void executeMainRoutine(BackgroundWorker worker, DoWorkEventArgs e)
        {
            try
            {
                mainGUI.setProgressLabel("Reading files");

                List<String> errors = new List<string>();

                string source = mainGUI.GetSourceFolder();
                readFiles(source);

                // read data about filters from GUI and set the filters in Core
                setFilters();

                mainGUI.setProgressLabel("Filtering files");
                // apply filters to files and save error messages from there
                applyFilters(worker, e);

                int totalFilesCopied = 0;
                // finally copy the files
                string targetFolder = mainGUI.GetTargetFolder();
                for (int i = 0; i < files.Count; i++)
                {
                    FileInfo file = files[i];
                    mainGUI.setProgressLabel("Copying files: " + i.ToString() + "/" + files.Count.ToString());
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        errors.Add("Cancelled by user");
                        break;
                    }

                    // now make a new filename, according to the parameters provided by user
                    string paddedNumber = Util.PadNumberToMaximum(i, files.Count);
                    string newPath = FileNaming.GenerateFileName(file, mainGUI.GetFileNamingPattern(), mainGUI.IsAllowOverwriteFiles(), targetFolder, paddedNumber);

                    try
                    {
                        file.CopyTo(newPath);
                        totalFilesCopied++;

                        // if user checked the box for file deletion, try to remove the file.
                        if (mainGUI.IsRemoveImagesFromCache())
                        {
                            file.Delete();
                        }

                    }
                    catch (IOException)
                    {
                        errors.Add("Could not copy or delete file: " + file.Name);
                    }

                    // update progress bar
                    reportProgress(files.Count, i, worker);

                }
                mainGUI.setProgressLabel("");
                //return errors;
                e.Result = totalFilesCopied;

            }
            catch (Exception ex)
            {
                Util.WriteToLogFile(ex);
                throw;
            }
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
            if ( mainGUI.GetHours() != null )
            {
                // if checkbox is set on hours, set the filter
                IFilter dateFilter = new DateFilter(
                    DateTime.Now.AddHours(-1* (int)mainGUI.GetHours()));
                addFilter(dateFilter);
            }

            if (mainGUI.GetKilobytes() != null)
            {
                IFilter FileSizeFilter = new FileSizeFilter((int)mainGUI.GetKilobytes() * 1000);
                addFilter(FileSizeFilter);
            }


             // always add jpeg filter before filter with image size.
            IFilter imageFilter = new ImageTypeFilter(mainGUI.IsJPG(), mainGUI.IsPNG(), mainGUI.IsGIF());
            addFilter(imageFilter);


            // we only need to check if one of the dimensions is set,
            // as both of them are required on the form.
            if (mainGUI.GetMinHeight() != null)
            {
                int minWidth = (int)mainGUI.GetMinWidth();
                int minHeight = (int)mainGUI.GetMinHeight();
                IFilter imageSizeFilter = new ImageSizeFilter(minWidth, minHeight);
                addFilter(imageSizeFilter);
            }

        }



    }
}
