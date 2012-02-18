using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ST = cacheCopy.Properties.Settings;
using System.Drawing;

namespace cacheCopy
{
    public partial class MainGUI : Form
    {
        Core core;
        List<ProfilePath> Profiles = new List<ProfilePath>();

        public MainGUI(ref Core core)
        {
            this.core = core;
            InitializeComponent();

        }

        public void addProfile(ProfilePath profile)
        {
            Profiles.Add(profile);
        }

        public void addProfile(List<ProfilePath> profile)
        {
            Profiles.AddRange(profile);
        }


#region Events

        /// <summary>
        /// Handles the Load event of the MainGUI control.
        /// Executed when the form is loaded
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainGUI_Load(object sender, EventArgs e)
        {
            //load data from settings file
            LoadSettings();

            // check that all the relevant controls for checkboxes are switched on/off
            // depending on the original checkbox state
            hoursCheckbox_CheckedChanged(null, null);
            kilobytesCheckbox_CheckedChanged(null, null);
            resolutionCheckbox_CheckedChanged(null, null);

            BrowserDropDown.DataSource = Profiles;
            BrowserDropDown.DisplayMember = "Name";
            BrowserDropDown.ValueMember = "FullPath";

            ResetControls();

            DisplaySamplePattern();

            SetTooltips();
        }

        /// <summary>
        /// Handles the Click event of the CopyButton control.
        /// Executes the whole copy process
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CopyButton_Click(object sender, EventArgs e)
        {
            // validate the form
            List<string> messages = new List<string>();
            if (!isValid(ref messages))
            {
                // if form is not valid, show error messages and do nothing
                showMessageBox(messages);
                return;
            }

            backgroundWorker1.RunWorkerAsync();//this invokes the DoWork event
            CancelButton.Visible = true;
            CopyButton.Enabled = false;
            progressBar.Value = 0;
            progressBar.Visible = true;
        }

        /// <summary>
        /// Open a file selection dialog for target folder
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void targetFolderButton_Click(object sender, EventArgs e)
        {
            if (TargetFolderDialog.ShowDialog() == DialogResult.OK)
            {
                this.targetFolderName.Text = TargetFolderDialog.SelectedPath;
                targetFolderName.Focus();
            }

        }

        /// <summary>
        /// Open folder selection dialog for manual selection of source folder
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SourceFolderButton_Click(object sender, EventArgs e)
        {
            if (SourceFolderDialog.ShowDialog() == DialogResult.OK)
            {
                this.SourceFolderName.Text = SourceFolderDialog.SelectedPath;
                SourceFolderName.Focus();
            }

        }

        /// <summary>
        /// Handles the DoWork event of the backgroundWorker1 control.
        /// Executed by pressing "Copy" button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            core.executeMainRoutine(sender as BackgroundWorker, e);
        }

        /// <summary>
        /// Runs when background worker has finished the work: resetting the controls
        /// to the initial state
        /// And should show a message with results.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetControls();
            if (!e.Cancelled && null == e.Error )
            {
                int totalFilesCopied = (int)e.Result;
                showMessageBox(totalFilesCopied.ToString() + " files copied");
            }

        }

        /// <summary>
        /// Tells background worker to terminate
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        /// <summary>
        /// Every time background worker is reporting progress change, this
        /// function is executed. Used to update the progress bar with current percentage
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// When user changes selection on radio buttons, update all the related controls
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ManualSelectionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SourceSelectionChanged();
        }

        /// <summary>
        /// Enable or disable Text field for file-naming pattern, depending if the option is 
        /// turned on or not.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chbxFileNamingPattern_CheckChanged(object sender, EventArgs e)
        {
            DisplaySamplePattern();
            SourceSelectionChanged();
        }

        /// <summary>
        /// Handles the FormClosing event of the MainGUI control:
        /// here we need to disable any kind of validation, so we can close the form.
        /// Otherwise the validation would not let us close the program if one of the fields
        /// is not validated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save the current data on the form into property file
            SaveSettings();

            // read details here: http://msdn.microsoft.com/en-us/library/ms229603.aspx
            e.Cancel = false;

        }

        /// <summary>
        /// Change label with selection path to the profile path value
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BrowserDropDown_SelectionChanged(object sender, EventArgs e)
        {
            ProfilePath path = getSelectedProfile();
            lblSourceFolderDisplay.Text = path.FullPath;
        }


        /// <summary>
        /// Every time the pattern changes, we want to update label, for user to see the result
        /// of translation of the pattern to the name
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtFileNamingPattern_TextChanged(object sender, EventArgs e)
        {
            DisplaySamplePattern();
        }

        private void btnPatternHelp_Click(object sender, EventArgs e)
        {
            // create help dialog
            PatternHelpDialog help = new PatternHelpDialog();

            // set manual positioning
            help.StartPosition = FormStartPosition.Manual;

            // place the dialog to the right from the main window
            int x = this.Location.X + this.Width;
            int y = this.Location.Y;
            help.Location = new Point(x, y); 

            // actually show the dialog
            help.Show();
        }


#endregion


#region Methods

        /// <summary>
        /// Loads the settings into the form from the xml-properties file
        /// </summary>
        private void LoadSettings()
        {
            BrowserRadioButton.Checked = ST.Default.BrowserRadioButtonChecked;
            ManualSelectionRadioButton.Checked = ST.Default.ManualSelectionRadioButtonChecked;
            SourceFolderName.Text = ST.Default.ManualSelectionPath;
            targetFolderName.Text = ST.Default.TargetFolderPath;
            hoursCheckbox.Checked = ST.Default.HoursCheckboxChecked;
            hours.Value = ST.Default.HoursSetting;
            kilobytesCheckbox.Checked = ST.Default.KilobytesCheckboxChecked;
            kilobytes.Value = ST.Default.KilobytesSetting;
            resolutionCheckbox.Checked = ST.Default.ResolutionCheckboxChecked;
            minWidth.Value = ST.Default.Xresolution;
            minHeight.Value = ST.Default.YResolution;
            chbxDeleteFilesFromCache.Checked = ST.Default.RemoveImagesFromCache;
            chbxFileNamingPattern.Checked = ST.Default.UseFileNamingPattern;
            txtFileNamingPattern.Text = ST.Default.NamingPattern;
            chbxAllowOverwriteFiles.Checked = ST.Default.AllowOverwriteFiles;
        }

        /// <summary>
        /// Saves the current state of the form into properties file
        /// </summary>
        private void SaveSettings()
        {
            ST.Default.BrowserRadioButtonChecked = BrowserRadioButton.Checked;
            ST.Default.ManualSelectionRadioButtonChecked = ManualSelectionRadioButton.Checked;
            ST.Default.ManualSelectionPath = SourceFolderName.Text;
            ST.Default.TargetFolderPath = targetFolderName.Text;
            ST.Default.HoursCheckboxChecked = hoursCheckbox.Checked;
            ST.Default.HoursSetting = (int)hours.Value;
            ST.Default.KilobytesCheckboxChecked = kilobytesCheckbox.Checked;
            ST.Default.KilobytesSetting = (int)kilobytes.Value;
            ST.Default.ResolutionCheckboxChecked = resolutionCheckbox.Checked;
            ST.Default.Xresolution = (int)minWidth.Value;
            ST.Default.YResolution = (int)minHeight.Value;
            ST.Default.RemoveImagesFromCache = chbxDeleteFilesFromCache.Checked;
            ST.Default.UseFileNamingPattern = chbxFileNamingPattern.Checked;
            ST.Default.NamingPattern = txtFileNamingPattern.Text;
            ST.Default.AllowOverwriteFiles = chbxAllowOverwriteFiles.Checked;

            ST.Default.Save();
        }

        /// <summary>
        /// Resets the controls to the original state.
        /// When the form start this should be called.
        /// </summary>
        private void ResetControls()
        {
            this.progressLabel.Text = "";
            CancelButton.Visible = false;
            CopyButton.Enabled = true;
            progressBar.Visible = false;

            SourceSelectionChanged();

        }

        /// <summary>
        /// Shows the message box.
        /// </summary>
        /// <param name="message">The message.</param>
        public void showMessageBox(String message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Shows all the messages in the list of string as a message box.
        /// </summary>
        /// <param name="messages">The messages.</param>
        private void showMessageBox(List<string> messages)
        {
            StringBuilder msg = new StringBuilder();
            foreach (string m in messages)
            {
                msg.Append("* " + m + "\n");
            }
            showMessageBox(msg.ToString());
        }

        /// <summary>
        /// Sets the progress label in the status bar
        /// </summary>
        /// <param name="message">The message.</param>
        public void setProgressLabel(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { progressLabel.Text = message; }));
                return;
            }

            this.progressLabel.Text = message;
        }

        /// <summary>
        /// When user changes selection in radio-buttons, this should
        /// update the state of controls: activate the control related 
        /// to the current selection and disable all the rest
        /// </summary>
        private void SourceSelectionChanged()
        {
            BrowserDropDown.Enabled = BrowserRadioButton.Checked;
            lblSourceFolderDisplay.Visible = BrowserRadioButton.Checked;
            SourceFolderName.Enabled = ManualSelectionRadioButton.Checked;
            SourceFolderButton.Enabled = ManualSelectionRadioButton.Checked;
            txtFileNamingPattern.Enabled = chbxFileNamingPattern.Checked;
        }

        private void SetTooltips()
        {
            toolTip1.SetToolTip(this.lblBrowserHelpTooltip, "Automatic browser detection tries to find all the installed browsers in your system. ");

            this.toolTip1.SetToolTip(this.label2, String.Format("This is a full path in your system where the automatic{0}"+
                "browser detection is pointing to for browser cache.", Environment.NewLine));
            
            this.toolTip1.SetToolTip(this.label4, String.Format("Application will copy images from browser cache to this folder.{0}"+
                "Best advised to use some temporary empty folder i.e. C:/tmp/images. {0}"+
                "This will make it easier to process your results.", Environment.NewLine));

            this.toolTip1.SetToolTip(this.label3, String.Format("If automated browser detection fails to find your browser, you can point to the browser cache manually.{0}"+
                "Auto-detection usually fails when your browsers are not installed in the standard location,{0}"+
                "or your browser is not supported yet. Also if you would like to use cacheCopy{0}"+
                "to sort out your image collection (e.g. remove all small images), use this option{0}"+
                "and point it to your folder with images. Subfolders are scanned as well, as the folder.", Environment.NewLine));

            this.toolTip1.SetToolTip(this.label5, 
                String.Format("This option will not copy files that are older than particular number of hours.{0}"+
                "Useful if you would like to have only recent images and don\'t want {0}"+
                "to copy the whole previous history of browsing.", Environment.NewLine));

            this.toolTip1.SetToolTip(this.label6, "Turn this option on to include only images with file-size larger than desired");
            
            this.toolTip1.SetToolTip(this.label7, "Filter out images with small resolution.");

            this.toolTip1.SetToolTip(this.label8, String.Format("This option will remove files with images from the browser cache.{0}"+ 
                "This will not allow to copy the same images twice. Only copied images will be removed from cache.", Environment.NewLine));

            this.toolTip1.SetToolTip(this.label10, String.Format("If in target folder file with the same name exists, overwrite this file.{0}" +
                "If this option is turned off, to the name of the new file \"(1)\" will be added", Environment.NewLine));

        }

        /// <summary>
        /// Replaces placeholders in file naming pattern and displays the sample below the pattern field
        /// </summary>
        private void DisplaySamplePattern()
        {
            string pattern = getFileNamingPattern();
            
            if ( pattern == String.Empty)
            {
                lblPatternTranslationSample.Text = "";
                return;
            }



            if (FileNaming.isPatternValid(pattern))
            {
                lblPatternTranslationSample.Text = FileNaming.GenerateSampleFileName(pattern);
            }
            else
            {
                lblPatternTranslationSample.Text = "Pattern is not valid";
            }
        }
#endregion


#region Checkboxes 

        /// <summary>
        /// Handles the CheckedChanged event of the hoursCheckbox control.
        /// When checkbox is ticked enable further input. Disable otherwise
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void hoursCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            hours.Enabled = hoursCheckbox.Checked;
            lblHours.Enabled = hoursCheckbox.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the kilobytesCheckbox control.
        /// When kilobytes checkbox is checked, enable the kilobyte control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void kilobytesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            kilobytes.Enabled = kilobytesCheckbox.Checked;
            lblKilobytes.Enabled = kilobytesCheckbox.Checked;
        }
        
        /// <summary>
        /// Handles the CheckedChanged event of the resolutionCheckbox control.
        /// When checked, enable other resolution controls
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void resolutionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            minHeight.Enabled = resolutionCheckbox.Checked;
            minWidth.Enabled = resolutionCheckbox.Checked;
            lblX.Enabled = resolutionCheckbox.Checked;
            lblPixels.Enabled = resolutionCheckbox.Checked;
        }

#endregion


#region Getters

        /// <summary>
        /// Gets the hours value from the form.
        /// If hours filter is disabled on the form, NULL is returned
        /// </summary>
        /// <returns>null if hours filter is disabled or int value</returns>
        public int? getHours()
        {
            if (!hoursCheckbox.Checked)
            {
                return null;
            }

            return (int)hours.Value;
        }

        /// <summary>
        /// Gets the kilobytes value from the form.
        /// If file size filter is disabled, NULL is returned
        /// </summary>
        /// <returns>Null or int value</returns>
        public int? getKilobytes()
        {
            if (! kilobytesCheckbox.Checked)
            {
                return null;
            }

            return (int)kilobytes.Value;
        }

        /// <summary>
        /// Gets the minimum width of the image.
        /// If this filter is disabled, returns NULL
        /// </summary>
        /// <returns>Null or int value</returns>
        public int? getMinWidth()
        {
            if (! resolutionCheckbox.Checked)
            {
                return null;
            }

            return (int)minWidth.Value;
        }

        /// <summary>
        /// Gets the minimum height of the image.
        /// If this filter is disabled, returns NULL
        /// </summary>
        /// <returns>Null or int value</returns>
        public int? getMinHeight()
        {
            if (!resolutionCheckbox.Checked)
            {
                return null;
            }

            return (int)minHeight.Value;
        }

        /// <summary>
        /// Gets the selected profile for Firefox in a thread-safe manner
        /// </summary>
        /// <returns>Selected ProfilePath object</returns>
        public ProfilePath getSelectedProfile()
        {
            ProfilePath selectedPath = null;

            BrowserDropDown.InvokeEx(f => selectedPath = (ProfilePath)BrowserDropDown.SelectedItem);

            return selectedPath;
        }

        /// <summary>
        /// Returns the selected source folder
        /// </summary>
        /// <returns></returns>
        public string getSourceFolder()
        {
            // if the browser dropdown is selected, return the full path
            if (BrowserRadioButton.Checked == true)
            {
                ProfilePath profile = getSelectedProfile();
                return profile.FullPath;
            }
            // otherwise select manual profile
            return SourceFolderName.Text;
        }

        /// <summary>
        /// Gets the target folder - selected by user
        /// </summary>
        /// <returns></returns>
        public string getTargetFolder()
        {
            return targetFolderName.Text;
        }

        /// <summary>
        /// Determines whether we should remove copied images from cache. 
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is remove images from cache]; otherwise, <c>false</c>.
        /// </returns>
        public bool isRemoveImagesFromCache()
        {
            return chbxDeleteFilesFromCache.Checked;
        }

        /// <summary>
        /// Gets the file naming pattern.
        /// </summary>
        /// <returns>If the option is switched off, this returns empty string, otherwise naming pattern entered by user</returns>
        public string getFileNamingPattern()
        {
            if (chbxFileNamingPattern.Checked)
                return txtFileNamingPattern.Text;
            else
                return "";
                
        }

        /// <summary>
        /// Determines whether it is allowed to overwrite existing files in target
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is allow overwrite files]; otherwise, <c>false</c>.
        /// </returns>
        public bool isAllowOverwriteFiles(){
            return chbxAllowOverwriteFiles.Checked;
        }

#endregion


#region Validators


        /// <summary>
        /// Determines whether the form has valid user input.
        /// Returns true if all the validations are fine.
        /// False if some controls fail to validate. 
        /// List of messages passed in will be filled in with the error messages from 
        /// the faulty validation
        /// </summary>
        /// <param name="messages">The list of error messages - will be populated on faulty validation</param>
        /// <returns>
        ///   <c>true</c> if the form is valid; otherwise, <c>false</c>.
        /// </returns>
        private Boolean isValid(ref List<string> messages)
        {
            bool isValid = true;

            // validate for TargetFolder
            if (!Directory.Exists(targetFolderName.Text))
            {
                TargetFolderErrorProvider.SetError(targetFolderName, "Folder does not exist");
                isValid = false;
                messages.Add("Target folder does not exist");
            }
            else
            {
                TargetFolderErrorProvider.SetError(targetFolderName, "");
            }
            
            // validate for source folder if manual selection
            if (ManualSelectionRadioButton.Checked && !Directory.Exists(SourceFolderName.Text))
            {
                ManualSelectionErrorProvider.SetError(SourceFolderName, "Directory does not exist");
                isValid = false;
                messages.Add("Source folder does not exists");
            }
            else
            {
                ManualSelectionErrorProvider.SetError(SourceFolderName, "");
            }

            if (chbxFileNamingPattern.Checked && !FileNaming.isPatternValid(getFileNamingPattern()))
            {
                FilePatternErrorProvider.SetError(txtFileNamingPattern, "Pattern contains invalid characters or not valid");
                messages.Add("File naming pattern contains invalid characters or not valid");
                isValid = false;
                //switch to second tab and focus on text field for file pattern
                tabControl1.SelectTab(1);
                txtFileNamingPattern.Focus();
            }
            else
            {
                FilePatternErrorProvider.SetError(txtFileNamingPattern, "");
            }


            return isValid;
        }
#endregion

    }
}
