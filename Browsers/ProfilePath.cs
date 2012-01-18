using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cacheCopy
{
    /// <summary>
    /// Mini class to provide information from Firefox Helper to GUI
    /// </summary>
    public class ProfilePath
    {
        public string Name { get; set; }
        public string FullPath { get; set; }


        public ProfilePath(String Name, String FullPath)
        {
            this.Name = Name;
            this.FullPath = FullPath;
        }
    }
}
