using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cacheCopy
{
    public class FirefoxHelper : IBrowserHelper
    {


        /// <summary>
        /// Determines whether Firefox is installed by accessing the registry
        /// </summary>
        /// <returns>
        ///   <c>true</c> if Firefox is installed; otherwise, <c>false</c>.
        /// </returns>
        public bool isBrowserInstalled()
        {
            if (getBrowserVersion() == "")
                return false;
            return true;
        }




        /// <summary>
        /// Gets the Firefox version from the registry
        /// </summary>
        /// <returns></returns>
        public string getBrowserVersion()
        {
            // in windows 32bit, current version is stored here
            string currentVersion = Util.ReadRegistryKey(@"HKEY_CURRENT_USER\Software\Mozilla\Firefox\", "CurrentVersion");

            if ( null == currentVersion || ""== currentVersion)
            {
                // Win7 64bit is storing current version here
                currentVersion = Util.ReadRegistryKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Mozilla\Mozilla Firefox",
                "CurrentVersion");
            }

            if (null == currentVersion )
            {
                return "";
            }

            return currentVersion;
        }



        /// <summary>
        /// Try to guess the path of Firefox profiles
        /// </summary>
        /// <returns>String with path. If path not found, return empty string</returns>
        private string getProfilesPath()
        {
            string path = "";

            if (!isBrowserInstalled()) return path;

            String localAppData = System.Environment.GetEnvironmentVariable("LOCALAPPDATA");

            //%LOCALAPPDATA%\Mozilla\Firefox\Profiles\alpha-numeric.default\Cache

            path = Path.Combine(localAppData, @"Mozilla\Firefox\Profiles");

            if (!Directory.Exists(path)) return "" ;

            return path;
        }


        /// <summary>
        /// Get the list of all the profiles 
        /// </summary>
        /// <returns>List with ProfilePath objects</returns>
        public List<ProfilePath> getProfiles()
        {

            String profilesPath = getProfilesPath();

            // find all the folder there
            DirectoryInfo dir = new DirectoryInfo(profilesPath);

            DirectoryInfo[] subDirectories = dir.GetDirectories();

            var dirs = from sd in subDirectories
                       where sd.Name.EndsWith(".default")
                       select new ProfilePath("Firefox - " + sd.Name, sd.FullName);

            return dirs.ToList<ProfilePath>();

        }


    }
}
