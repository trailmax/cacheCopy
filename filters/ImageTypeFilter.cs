using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace cacheCopy.filters
{
    class ImageTypeFilter : IFilter
    {
        private bool isJpg = true;
        private bool isGif = false;
        private bool isPng = false;

        public ImageTypeFilter(bool isJpg, bool isPng, bool isGif)
        {
            this.isJpg = isJpg;
            this.isPng = isPng;
            this.isGif = isGif;
        }



        /// <summary>
        /// Checks the file if it either JPG, GIF or PNG and compares with required types.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        /// If filter stops the file, return false
        /// </returns>
        public bool checkFile(FileInfo file)
        {
            FileType type = file.GetFileType();

            if ((isJpg && type == Detective.JPEG)
                || (isPng && type == Detective.PNG)
                || (isGif && type == Detective.GIF ))
            {
                return true;
            } 
            else
            {
                return false;
            }

        }
    }
}
