using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace cacheCopy.filters
{
    class JpegFilter : IFilter
    {

        public bool checkFile(FileInfo file)
        {
            // JPG files always start with the following characters
            //FF D8 FF
            byte[] jpgHeader = new byte[3] { 255, 216, 255 };
            byte[] header = new byte[3];

            try
            {
                using (FileStream fsSource = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    // read first three symbols from file into array of bytes.
                    fsSource.Read(header, 0, header.Length);
                }

                // check the header first, if it does not match, we are sure it is not jpg
                if (!jpgHeader.SequenceEqual(header)) return false;


                try
                {
                    Image image = Image.FromFile(file.FullName);
                }
                catch (Exception)
                {
                    return false;
                }

                return true;

            }
            catch (Exception) 
            {
                // if we get IOException, most likely that the file we are 
                // trying to read is locked and it is a Firefox system file, we are not interested in
                throw new ApplicationException("Could not read file:" + file.Name);
            } 
            

        }
    }
}
