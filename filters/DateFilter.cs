using System;
using System.IO;

namespace cacheCopy.filters
{

    /// <summary>
    /// Check if file is within some date interval
    /// </summary>
    public class DateFilter: IFilter
    {
        private DateTime? sdt { get; set; }
        private DateTime? edt { get; set; }


        public DateFilter(DateTime sdt, DateTime edt)
        {
            this.sdt = sdt;
            this.edt = edt;
        }



        public DateFilter(DateTime sdt)
        {
            this.sdt = sdt;
            this.edt = null;
        }




        /// <summary>
        /// Checks the file if it was created between 
        /// set start time and end-time
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        /// If file within date-range, return true
        /// </returns>
        public bool checkFile(FileInfo file)
        {
            if (edt != null)
            {
                if (sdt <= file.CreationTime && file.CreationTime < edt)
                    return true;
            }
            else
            {
                if (sdt <= file.CreationTime)
                    return true;
            }

            return false;

            
        }
    }
}
