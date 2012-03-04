using System;
using System.Xml;
using ST = cacheCopy.Properties.Settings;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace cacheCopy
{
    /// <summary>
    /// Object to deal with updates: checking for a new versions available, 
    /// downloading installation files, installing new versions.
    /// </summary>
    public class Updater
    {
        public bool isNewVersionAvailable = false;
        public Version onlineVersion;
        public string onlineDownloadUrl;
        public MainGUI gui;
        public BackgroundWorker bgdWorker;
        public const string xmlURL = "http://trailmax.info/cachecopy/version.xml"; // url where to go for XML file with update info


        /// <summary>
        /// Create Updater object and send the GUI reference
        /// </summary>
        /// <param name="gui"></param>
        public Updater(ref MainGUI gui)
        {
            this.gui = gui;
        }

        /// <summary>
        /// Public method to work out if we need to update or not.
        /// Check if it is time to check for an update. If it is time
        /// to update, do check if new release is available. 
        /// </summary>
        public void CheckUpdates()
        {
            // get todays date, compare with lastCheckedForUpdateDate
            // if have not checked for the update for long enough - go online
            // and check for the update
            // when checked for update - either update the software,
            // or write to settings file, set the lastCheckedForUpdateDate for today.

            int checkingFrequency = 30;
            DateTime lastChecked = ST.Default.LastCheckedForUpdateDate;
            if (lastChecked.AddDays(checkingFrequency) <= DateTime.Now)
            {
                gui.setProgressLabel("Checking for updates...");

                // create a threaded task to check for the update.
                bgdWorker = new BackgroundWorker();
                bgdWorker.DoWork += new DoWorkEventHandler(DoOnlineCheck);
                bgdWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CheckingFinished);

                //execute the checker for the update
                bgdWorker.RunWorkerAsync();
            }

        }



        /// <summary>
        /// What happens when the update is finished: 
        /// updaet status bar. show user a message if there is a new version. 
        /// Show a confirmation dialog if user would like to download.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckingFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            // if nothing is available, just quit the process
            if (isNewVersionAvailable == false)
            {
                gui.setProgressLabel("No updates available");
                return;
            }

            // but if something is available do offer user a dialog.
            string title = "Download new version?";
            string question = "New version of cacheCopy is available. Download?";
            if (MessageBox.Show(question, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //TODO download and install new file.
            }
        }


        /// <summary>
        /// Check If new version is available in a new version.
        /// </summary>
        private void DoOnlineCheck(object sender, DoWorkEventArgs e)
        {
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(xmlURL);

                // simply (and easily) skip the junk at the beginning  
                reader.MoveToContent();

                // internal - as the XmlTextReader moves only forward, we save current xml element name  
                // in elementName variable. When we parse a text node, we refer to elementName to check  
                // what was the node name  
                string elementName = "";

                // we check if the xml starts with a proper "cachecopy" element node  
                if (!(reader.NodeType == XmlNodeType.Element) || !(reader.Name == "cachecopy"))
                {
                    throw new ApplicationException("Badly formatted XML. Please inform trailmax1@gmail.com");
                }

                
                while (reader.Read())
                {
                    // when we find an element node, we remember its name  
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        elementName = reader.Name;
                        continue;
                    }

                    // for text nodes...  
                    if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                    {
                        // we check what the name of the node was  
                        switch (elementName)
                        {
                            case "version":
                                // that is why we keep the version info in xxx.xxx.xxx.xxx format  
                                // the Version class does the parsing for us  
                                onlineVersion = new Version(reader.Value);
                                break;
                            case "url":
                                onlineDownloadUrl = reader.Value;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                isNewVersionAvailable = false;
                gui.setProgressLabel(ex.Message);
                Util.WriteToLogFile(ex);
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            // get the running version  
            Version curVersion = Assembly.GetExecutingAssembly().GetName().Version;

            // compare the versions  
            if (curVersion.CompareTo(onlineVersion) < 0)
            {
                isNewVersionAvailable = true;
            }
        }

    }
}
