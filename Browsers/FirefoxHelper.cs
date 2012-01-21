﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;

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
            // check if there is a record in software for local user
            if (Registry.CurrentUser.OpenSubKey(@"Software\Mozilla\Firefox")!= null)
                return true;

            // try to get a version 
            if (getBrowserVersion() != String.Empty)
                return true;    //if we can find a version, Firefox is installed

            // probably there is no Firefox
            return false;
        }






        /// <summary>
        /// Gets the Firefox version from the registry
        /// </summary>
        /// <returns>Return version number as a string. If not found, returns empty string.</returns>
        public string getBrowserVersion()
        {

            String[] possibleVersions = new String[]
            {
                Util.ReadRegistryKey(@"HKEY_CURRENT_USER\Software\Mozilla\Firefox\", "CurrentVersion"),
                Util.ReadRegistryKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\mozilla.org\Mozilla", "CurrentVersion"),
                Util.ReadRegistryKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Mozilla\Mozilla Firefox", "CurrentVersion"),
                Util.ReadRegistryKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Mozilla\Mozilla Firefox", "CurrentVersion")
            };

            foreach (var path in possibleVersions)
            {
                if (null != path && path!= String.Empty)
                {
                    return path;
                }
            }

            return "";
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

            if (null == profilesPath || profilesPath == "")
            {
                return new List<ProfilePath>();
            }

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
