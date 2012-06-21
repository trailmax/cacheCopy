using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Homegrown.Updater;
using ST = cacheCopy.Properties.Settings;

namespace cacheCopy
{
    /// <summary>
    /// Class that works as de-coupling measure between the application and the
    /// Updater class. This class is to be changed on every application, 
    /// but Updater class to stay as it is.
    /// </summary>
    public class cacheCopyUpdaterBridge : IApplicationUpdaterBridge
    {
        public Version GetApplicationVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version; 
        }

        public DateTime GetLastCheckedForUpdateDate()
        {
            return ST.Default.LastCheckedForUpdateDate;
        }

        public void SetLastCheckedForUpdateDate(DateTime date)
        {
            ST.Default.LastCheckedForUpdateDate = date;
        }

        public void LogException(Exception e)
        {
            Util.WriteToLogFile(e);
        }

        public void Exit()
        {
            Application.Exit();
        }
    }
}
