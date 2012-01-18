using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cacheCopy
{
    class IEHelper : IBrowserHelper
    {

        /// <summary>
        /// Gets the browser version.
        /// </summary>
        /// <returns>string with version number</returns>
        public String getBrowserVersion()
        {
            string currentVersion = Util.ReadRegistryKey(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Internet Explorer\", "Version");

            if (null == currentVersion)
            {
                return "";
            }

            return currentVersion;

        }


        /// <summary>
        /// Gets the only profile
        /// </summary>
        /// <returns></returns>
        public List<ProfilePath> getProfiles()
        {
            string userProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string localAppData = System.Environment.GetEnvironmentVariable("LOCALAPPDATA");

            // list of possible paths with the temp.
            // added in the order of possibility
            String[] paths = new String[]
            {
                Util.ReadRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders\", "Cache"),
                Util.ReadRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders\", "Cache"),
                Path.Combine(localAppData, @"Microsoft\Windows\Temporary Internet Files\Low\Content.IE5"),
                Path.Combine(userProfile, @"Local Settings\Temp\Temporary Internet Files\Content.IE5"),
                Path.Combine(userProfile, @"Local Settings\Temporary Internet Files"),
                Path.Combine(userProfile, @"Local Settings\Temp\Temporary Internet Files"),
                Path.Combine(userProfile, @"Local Settings\Temporary Internet Files"),
            };

            foreach (string path in paths)
            {
                // if the directory exists, use it as a default single profile
                if (Directory.Exists(path))
                {
                    return new List<ProfilePath> { new ProfilePath("Internet Explorer", path) };
                }
            }

            return new List<ProfilePath>();
        }


        /// <summary>
        /// Determines whether the browser is installed.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if browser is installed; otherwise, <c>false</c>.
        /// </returns>
        public bool isBrowserInstalled()
        {
            if (getBrowserVersion() == "")
                return false;
            return true;
        }
    }
}
