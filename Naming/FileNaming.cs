using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cacheCopy
{
    class FileNaming
    {



        // overwrite file ? 
        // pattern
        // extension - detect if there is an extension there already (1 to 4 symbols after the dot at the end)
        // If no extension provided - get the extension by the file type.


        // possible patterns available:
        //  For current time/date: YYYY, MM, DD, MMM, HH,MIN,SS,TS = timestamp
        //  same for the file modification date/time
        //  image resolution X, Y, total square of the image resolution: X*Y
        //  current number and number with padding
        //  random number
        //  random string of letters/digits
        //  add correct extension if not present already
        // * (asterisk for pattern)
        



        public static string GenerateFileName(FileInfo file, String pattern, FileType fileType, bool allowOverwrite, string targetPath )
        {
            String name = file.Name;

            // if pattern is set, process the pattern
            if (pattern != null && pattern != String.Empty)
            {
                name = ProcessPatternName(file, pattern);
            }

            // check for file extension in the pattern
            // if the extension exists in pattern, do nothing
            if (!NameIncludesCorrectExtension(name))
            {
                // if there is no extension, take it from fileType
                // add extension to the end of the fileName
                name += '.' + fileType.extension;
            }

            // then check if the filename with this name already exists
            if (!allowOverwrite)
            {
                //create new name - add (1) at the name end
                name = CorrectNameIfFileExits(file, name, targetPath);
            }

            return Path.Combine(targetPath, name);
        }



        /// <summary>
        /// Replace placeholders in pattern for the information 
        /// from file and other data
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        private static string ProcessPatternName(FileInfo file, string pattern)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Check if given file names already includes the correct extension.
        /// Basically we need to check if the filename ends with one of the known extension
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>true if filename already has allowed extension at the end</returns>
        private static bool NameIncludesCorrectExtension(string name)
        {
            List<string> allowedExtension = new List<string> {
                ".jpg",
                ".jpeg",
                ".gif",
                ".png"
            };

            foreach (string ext in allowedExtension)
            {
                if (name.EndsWith(ext))
                    return true;
            }

            return false;
        }



        /// <summary>
        /// Check if the file with this name and path already exists and 
        /// add (1) or (2), etc. at the end of the name, before the extension
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="name">The name.</param>
        private static string CorrectNameIfFileExits(FileInfo file, string name, string targetPath)
        {
            string newFullName = Path.Combine(targetPath, name);

            int i = 0;
            while (File.Exists(newFullName))    // check if file exists
            {
                i++;    // if file exists, add counter
                string nameNoExtension = Path.GetFileNameWithoutExtension(newFullName);
                string extension = Path.GetExtension(newFullName);
                // and add the number to the file name
                newFullName = Path.Combine(targetPath, nameNoExtension + "(" + i.ToString() + ")" + extension);
            }

            return newFullName;
        }







    }
}
