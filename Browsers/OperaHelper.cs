using System;
using System.Collections.Generic;
using SYS = System.Environment;


namespace cacheCopy
{
    class OperaHelper : DefaultBrowser, IBrowserHelper
    {
        protected override List<string> GetListOfPossiblePaths()
        {
            List<String> paths = new List<String> 
            {	
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\AppData\Local\Opera\Opera\cache\",
                SYS.GetEnvironmentVariable("USERPROFILE") + @"\Local Settings\Application Data\Opera\Opera\cache\",

            };
            return paths;
        }

        protected override string GetBrowserName()
        {
            return "Opera";
        }

        protected override bool UseOnlyFirstExisting()
        {
            return true;
        }
    }
}
