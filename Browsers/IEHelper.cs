using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SYS = System.Environment;

namespace cacheCopy
{
    class IEHelper : IBrowserHelper
    {

        /// <summary>
        /// Gets the only profile
        /// </summary>
        /// <returns></returns>
        public List<ProfilePath> getProfiles()
        {
            string userProfile = SYS.GetEnvironmentVariable("USERPROFILE");
            string localAppData = SYS.GetEnvironmentVariable("LOCALAPPDATA");

            // list of possible paths with the temp.
            // added in the order of possibility
            List<String> paths = new List<String>()
            {
                Util.ReadRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders\", "Cache"),
                Util.ReadRegistryKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders\", "Cache"),
                localAppData + @"\Microsoft\Windows\Temporary Internet Files\Low\Content.IE5",
                userProfile + @"\Local Settings\Temp\Temporary Internet Files\Content.IE5",
                userProfile + @"\Local Settings\Temporary Internet Files",
                userProfile + @"\Local Settings\Temp\Temporary Internet Files",
                userProfile + @"\Local Settings\Temporary Internet Files",
            };

            paths.RemoveAll(d => !Directory.Exists(d));

            String profile = "";
            if (paths.Any())
            {
		        profile = paths.First();
            }
	        else
            {
                return new List<ProfilePath>();
            }


            return new List<ProfilePath>(){ 
                new ProfilePath("Internet Explorer", profile)
            };

        }

    }
}
