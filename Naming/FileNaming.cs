using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cacheCopy
{
    public class FileNaming
    {

        /// <summary>
        /// Generates the name of the file taking into account all the settings provided by user in GUI:
        ///  * pattern
        ///  * Overwrite existing files or not
        ///  * adds extension to the file if not already there
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="allowOverwrite">if set to <c>true</c> [allow overwrite].</param>
        /// <param name="targetPath">The target path.</param>
        /// <param name="Number">The number.</param>
        /// <returns></returns>
        public static string GenerateFileName(FileInfo file, String pattern, bool allowOverwrite, string targetPath, string Number = "" )
        {
            String name = file.Name;

            // if pattern is set, process the pattern
            if (pattern != null && pattern != String.Empty)
            {
                name = ProcessPatternName(file, pattern, Number);
            }

            // check for file extension in the pattern
            // if the extension exists in pattern, do nothing
            if (!NameIncludesCorrectExtension(name))
            {
                // if there is no extension, take it from fileType
                // add extension to the end of the fileName
                name += '.' + file.GetFileType().extension;
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
        private static string ProcessPatternName(FileInfo file, string pattern, string Number)
        {
            DateTime FileCreatedTime = file.CreationTime;

            // possible patterns available:
            Dictionary<string, string> replacements = new Dictionary<string, string>()
            {
                //current computer time
                {"*yyyy*", DateTime.Now.ToString("yyyy")},
                {"*yy*", DateTime.Now.ToString("yy")},
                {"*MM*", DateTime.Now.ToString("MM")},
                {"*MMM*", DateTime.Now.ToString("MMM")},
                {"*HH*", DateTime.Now.ToString("HH")},
                {"*mm*", DateTime.Now.ToString("mm")},
                {"*ss*", DateTime.Now.ToString("ss")},
                {"*ffff*", DateTime.Now.ToString("ffff")},
                {"*fffffff*", DateTime.Now.ToString("fffffff")},

                //Timestamp for file creation time
                {"*CFyyyy*", FileCreatedTime.ToString("yyyy")},
                {"*CFyy*", FileCreatedTime.ToString("yyyy")},
                {"*CFMM*", FileCreatedTime.ToString("MM")},
                {"*CFMMM*", FileCreatedTime.ToString("MMM")},
                {"*CFHH*", FileCreatedTime.ToString("HH")},
                {"*CFmm*", FileCreatedTime.ToString("mm")},
                {"*CFss*", FileCreatedTime.ToString("ss")},
                {"*CFff*", FileCreatedTime.ToString("ff")},
            
                // random string of letters/digits
                {"*RAND3*", Util.GenerateRandomString(3)},
                {"*RAND4*", Util.GenerateRandomString(4)},
                {"*RAND5*", Util.GenerateRandomString(5)},
                {"*RAND6*", Util.GenerateRandomString(6)},

                // number of the file in the queue with padding
                {"*NUM*", Number}

            };

            foreach (var pair in replacements)
            {
                pattern = pattern.Replace(pair.Key, pair.Value);
            }

            return pattern;

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
