using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Homegrown.Updater
{
    /// <summary>
    /// Object to deal with updates: checking for a new versions available, 
    /// downloading installation files, installing new versions.
    /// </summary>
    public class Updater : IUpdater
    {
        private bool isNewVersionAvailable = false;
        private Version onlineVersion;
        private string onlineDownloadUrl;
        private IMessagingGui gui;
        private IApplicationUpdaterBridge application;
        private BackgroundWorker bgdWorker;
        private const string xmlURL = "http://trailmax.info/cachecopy/version.xml"; // url where to go for XML file with update info
        private String fullTempPath;

        /// <summary>
        /// Create Updater object and send the GUI reference
        /// </summary>
        /// <param name="gui"></param>
        public Updater(IMessagingGui gui, IApplicationUpdaterBridge app)
        {
            this.gui = gui;
            this.application = app;
        }


        /// <summary>
        /// Public method to work out if we need to update or not.
        /// Check if it is time to check for an update. If it is time
        /// to update, do check if new release is available. 
        /// </summary>
        public void CheckUpdates()
        {
            // if no application, or no gui, don't bother checking for update
            if (null == gui || null == application)
            {
                return;
            }

            // check every 30 days
            int checkingFrequency = 30;

            // get the stored date of the last check.
            DateTime lastChecked = application.GetLastCheckedForUpdateDate();

            // do check if it is time to check
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
                if (ex is ApplicationException)
                    gui.setProgressLabel(ex.Message);
                else
                    gui.setProgressLabel("Can not reach update server");
                
                application.LogException(ex);
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            // get the running version  
            Version curVersion = application.GetApplicationVersion();

            // compare the versions  
            if (curVersion.CompareTo(onlineVersion) < 0)
            {
                isNewVersionAvailable = true;
            }
        }





        /// <summary>
        /// What happens when the update is finished: 
        /// update status bar. show user a message if there is a new version. 
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
                application.SetLastCheckedForUpdateDate(DateTime.Now);
                return;
            }

            gui.setProgressLabel("New version is available");

            // but if something is available do offer user a dialog.
            string title = "Download new version?";
            string question = "New version of cacheCopy is available. Download?";
            if (gui.showConfirmationDialog(question, title))
            {
                DownloadFile(onlineDownloadUrl);
            }
        }



        /// <summary>
        /// Download a file from url, store it in temp dir and store the path to the file
        /// </summary>
        /// <param name="url"></param>
        private void DownloadFile(String url)
        {
            gui.setProgressLabel("Downloading update");
            try
            {
                String tempPath = Path.GetTempPath();

                // get the file extension from the URL
                string extension = url.Substring(url.Length - 3, 3);

                // make up a new name for the download
                String filename = "cacheCopy_update_" + Guid.NewGuid()+"."+extension;
                fullTempPath = Path.Combine(tempPath, filename);

                // download the file in separate thread, save into the temp location
                WebClient client = new WebClient();
                Uri uri = new Uri(url);
                // when download complete execute DownloadFileComplete function
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(uri, fullTempPath);
            }
            catch (Exception e)
            {
                gui.setProgressLabel("Can't download update");
                application.LogException(e);
            }
        }


        /// <summary>
        /// This gets executed when the download is finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)    
        {
            try
            {
                if (gui.showConfirmationDialog("Download of update is complete. Install?", "Install Update?"))
                {
                    // start the installer
                    Process.Start(fullTempPath);

                    // exit the application, so we remove file locks.
                    application.Exit();
                }
            }
            catch (Exception ex)
            {
                gui.setProgressLabel("Can not start update installer");
                application.LogException(ex);
            }
        }

    }
}
