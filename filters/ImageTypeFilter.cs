using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace cacheCopy.filters
{
    class ImageTypeFilter : IFilter
    {

        public bool checkFile(FileInfo file)
        {
            return file.isJpeg();
        }
    }
}
