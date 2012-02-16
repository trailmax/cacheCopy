using System;
using System.Collections.Generic;
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
                name = HandlePatternName(file, pattern, Number);
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
        private static string HandlePatternName(FileInfo file, string pattern, string Number)
        {
            DateTime FileCreatedTime = file.CreationTime;

            return ReplacePlaceholders(pattern, FileCreatedTime, Number);

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



        /// <summary>
        /// Build a dictionary of replacement strings
        /// </summary>
        /// <param name="FileCreatedTime">The file created time.</param>
        /// <param name="Number">The string with current file number - with zeros as padding.</param>
        /// <returns>dictionary with strings</returns>
        private static Dictionary<string, string> GetReplacementPattern(DateTime FileCreatedTime, string Number)
        {
            // for more date string formats go here:
            //http://msdn.microsoft.com/en-us/library/8kb3ddd4.aspx

            Dictionary<string, string> replacements = new Dictionary<string, string>()
            {
                //current computer time
                {"*yyyy*", DateTime.Now.ToString("yyyy")},  // 1999
                {"*yy*", DateTime.Now.ToString("yy")},      // 99
                {"*MM*", DateTime.Now.ToString("MM")},      // 02 (for February)
                {"*MMM*", DateTime.Now.ToString("MMM")},    // Feb (for February)
                {"*dd*", DateTime.Now.ToString("dd")},      // 05 for fifth
                {"*HH*", DateTime.Now.ToString("HH")},      // 07 - hours
                {"*mm*", DateTime.Now.ToString("mm")},      // minutes
                {"*ss*", DateTime.Now.ToString("ss")},      // seconds
                {"*ffff*", DateTime.Now.ToString("ffff")},  //	The hundredths of a second
                {"*fffffff*", DateTime.Now.ToString("fffffff")}, //The ten millionths of a second

                //Timestamp for file creation time
                {"*CFyyyy*", FileCreatedTime.ToString("yyyy")},
                {"*CFyy*", FileCreatedTime.ToString("yy")},
                {"*CFMM*", FileCreatedTime.ToString("MM")},
                {"*CFMMM*", FileCreatedTime.ToString("MMM")},
                {"*CFdd*", FileCreatedTime.ToString("dd")},
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
            return replacements;
        }



        /// <summary>
        /// Determines whether the provided pattern is valid in terms of the file naming conventions,
        /// allowed symbols and all the possible replacements.
        /// </summary>
        /// <param name="pattern">The string with pattern.</param>
        /// <returns>
        ///   <c>true</c> if pattern is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool isPatternValid(string pattern)
        {
            // avoid assigning to the parameter
            String name = ReplacePlaceholders(pattern, DateTime.Now, "");
            
            return Util.IsValidFileName(name);

        }



        /// <summary>
        /// Replaces the placeholders in pattern to a values
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="FileCreatedTime">File creation time.</param>
        /// <param name="Number">String with number of the file in the process line.</param>
        /// <returns>string with replaced placeholders</returns>
        private static string ReplacePlaceholders(String pattern, DateTime FileCreatedTime, string Number)
        {
            // avoid assigning to the parameter
            String name = pattern;

            // get all the possible replacements
            Dictionary<string, string> replacements = GetReplacementPattern(FileCreatedTime, Number);

            // replace every wildcard with value
            foreach (var pair in replacements)
            {
                name = name.Replace(pair.Key, pair.Value);
            }

            return name;
        }



        /// <summary>
        /// Produces sample file name based on the pattern provided 
        /// by user - just for an example, to see the resulting file name.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <returns>Pattern with replaced placeholders</returns>
        public static string GenerateSampleFileName(string pattern)
        {
            String result = "";

            // if pattern is set, process the pattern
            if (pattern != null && pattern != String.Empty)
            {
                result = ReplacePlaceholders(pattern, DateTime.Now, "001");
            }
            else
            {
                return "";
            }

            // check for file extension in the pattern
            // if the extension exists in pattern, do nothing
            if (!NameIncludesCorrectExtension(result))
            {
                // if there is no extension, take it from fileType
                // add extension to the end of the fileName
                result += ".jpg";
            }

            return result;
            
        }



    }
}
