using System.Drawing;
using System.IO;

namespace cacheCopy.filters
{
    class ImageSizeFilter : IFilter
    {
        private int minHres { get; set; }
        private int minVres { get; set; }

        public ImageSizeFilter(int hres, int vres)
        {
            this.minHres = hres;
            this.minVres = vres;
        }


        public bool checkFile(FileInfo file)
        {
            Image image = Image.FromFile(file.FullName);
            float hres = image.Width;
            float vres = image.Height;

            if (hres < minHres || vres < minVres)
                return false;


            return true;
        }


    }
}
