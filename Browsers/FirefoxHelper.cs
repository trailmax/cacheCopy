using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SYS = System.Environment;

namespace cacheCopy
{
    public class FirefoxHelper : IBrowserHelper
    {

        /// <summary>
        /// Get the list of all the profiles 
        /// </summary>
        /// <returns>List with ProfilePath objects</returns>
        public List<ProfilePath> getProfiles()
        {
            List<String> paths = new List<String> 
            {	
                SYS.GetEnvironmentVariable("LOCALAPPDATA") + @"\Mozilla\Firefox\Profiles",
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\Local Settings\Application Data\Mozilla\Firefox\Profiles",
                SYS.GetEnvironmentVariable("APPDATA") + @"\Mozilla\Firefox\Profiles",
                SYS.GetEnvironmentVariable("WINDIR") + @"\Mozilla", 
                SYS.GetEnvironmentVariable("WINDIR") + @"\Application Data\Mozilla\" 
            };

            // remove all invalid paths
            paths.RemoveAll( path => !Directory.Exists(path) );


            // get all the subdirs for the profile paths
            List<DirectoryInfo> subdirs = new List<DirectoryInfo>();
            foreach (String dir in paths)
            {
                List<DirectoryInfo> ss = (new DirectoryInfo(dir)).GetDirectories().ToList<DirectoryInfo>();
                subdirs.AddRange(ss);
            }

            // filter out subdirs with existing Cache sub-folder and eding with ".Default"
            var dirs = from sd in subdirs
                       where Directory.Exists(sd.FullName + @"\Cache") && sd.FullName.EndsWith(".default")
                       select new ProfilePath("Firefox - " + sd.Name, sd.FullName + @"\Cache");

            return dirs.Distinct().ToList<ProfilePath>();

        }


    }
}
