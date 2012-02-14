using System.IO;

namespace cacheCopy
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFilter
    {

        /// <summary>
        /// Checks the file if it falls through the filter.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>If filter stops the file, return false</returns>
        bool checkFile(FileInfo file);
    }
}
