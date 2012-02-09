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
        



        public static string GenerateFileName(FileInfo file, String pattern, FileType fileType, bool allowOverwrite )
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
                CorrectNameIfFileExits(file, name);
            }

            return name;
        }




        private static void CorrectNameIfFileExits(FileInfo file, string name)
        {
            throw new NotImplementedException();
        }



        private static bool NameIncludesCorrectExtension(string name)
        {
            //check that file name ends with .jpg or .jpeg or .gif or .png
            throw new NotImplementedException();
        }




        private static string ProcessPatternName(FileInfo file, string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
