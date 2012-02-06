using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYS = System.Environment;


namespace cacheCopy
{
    /// <summary>
    /// Helper class to help detect cache paths for Chromium
    /// </summary>
    class ChromiumHelper : DefaultBrowser, IBrowserHelper
    {

        protected override List<string>  GetListOfPossiblePaths()
        {
            List<String> list = new List<String> {
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\Local Settings\Application Data\Chromium\User Data\Default\Cache",
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Chromium\User Data\Default",
            };

            return list;
        }

        protected override string  GetBrowserName()
        {
            return "Chromium";
        }


        protected override bool UseOnlyFirstExisting()
        {
            return true;
        }
    }
}
