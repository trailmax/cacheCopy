using System;
using System.IO;

namespace cacheCopy.filters
{
    /// <summary>
    /// Filter file size
    /// </summary>
    class SizeFilter : IFilter
    {
        private Int32 minSize { get; set; }
        private Int32 maxSize { get; set; }

        public SizeFilter(Int32 minSize)
        {
            this.minSize = minSize;
        }


        public bool checkFile(FileInfo file)
        {
            if (minSize >= 0 && maxSize >= 0 &&
                minSize >= file.Length && file.Length <= maxSize)
            {
                return true;
            }

            if (minSize >= 0 && maxSize == 0 &&
                file.Length >= minSize )
            {
                return true;
            }

            if (minSize == 0 && maxSize >= 0 &&
                 file.Length <= maxSize  )
            {
                return true;
            }


            return false;

            
        }
    }
}
