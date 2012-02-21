namespace cacheCopy
{
    partial class MainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.CopyButton = new System.Windows.Forms.Button();
            this.TargetFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.targetFolderName = new System.Windows.Forms.TextBox();
            this.targetFolderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceFolderName = new System.Windows.Forms.TextBox();
            this.SourceFolderButton = new System.Windows.Forms.Button();
            this.SourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.hoursCheckbox = new System.Windows.Forms.CheckBox();
            this.hours = new System.Windows.Forms.NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.kilobytesCheckbox = new System.Windows.Forms.CheckBox();
            this.kilobytes = new System.Windows.Forms.NumericUpDown();
            this.lblKilobytes = new System.Windows.Forms.Label();
            this.resolutionCheckbox = new System.Windows.Forms.CheckBox();
            this.minWidth = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.minHeight = new System.Windows.Forms.NumericUpDown();
            this.lblPixels = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CancelButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ManualSelectionRadioButton = new System.Windows.Forms.RadioButton();
            this.BrowserRadioButton = new System.Windows.Forms.RadioButton();
            this.BrowserDropDown = new System.Windows.Forms.ComboBox();
            this.ManualSelectionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TargetFolderErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSourceFolderDisplay = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblBrowserHelpTooltip = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chbxDeleteFilesFromCache = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chbxFileNamingPattern = new System.Windows.Forms.CheckBox();
            this.txtFileNamingPattern = new System.Windows.Forms.TextBox();
            this.chbxAllowOverwriteFiles = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FilePatternErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPatternHelp = new System.Windows.Forms.Button();
            this.lblPatternTranslationSample = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kilobytes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHeight)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualSelectionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetFolderErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePatternErrorProvider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(605, 294);
            this.CopyButton.Margin = new System.Windows.Forms.Padding(4);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(100, 28);
            this.CopyButton.TabIndex = 120;
            this.CopyButton.Text = "Copy!";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // TargetFolderDialog
            // 
            this.TargetFolderDialog.Description = "Folder where to save images";
            this.TargetFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // targetFolderName
            // 
            this.targetFolderName.Location = new System.Drawing.Point(148, 110);
            this.targetFolderName.Margin = new System.Windows.Forms.Padding(4);
            this.targetFolderName.Name = "targetFolderName";
            this.targetFolderName.Size = new System.Drawing.Size(500, 22);
            this.targetFolderName.TabIndex = 35;
            // 
            // targetFolderButton
            // 
            this.targetFolderButton.Location = new System.Drawing.Point(646, 109);
            this.targetFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.targetFolderButton.Name = "targetFolderButton";
            this.targetFolderButton.Size = new System.Drawing.Size(37, 22);
            this.targetFolderButton.TabIndex = 40;
            this.targetFolderButton.Text = "...";
            this.targetFolderButton.UseVisualStyleBackColor = true;
            this.targetFolderButton.Click += new System.EventHandler(this.targetFolderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Target Folder";
            // 
            // SourceFolderName
            // 
            this.SourceFolderName.Location = new System.Drawing.Point(148, 68);
            this.SourceFolderName.Margin = new System.Windows.Forms.Padding(4);
            this.SourceFolderName.Name = "SourceFolderName";
            this.SourceFolderName.Size = new System.Drawing.Size(500, 22);
            this.SourceFolderName.TabIndex = 25;
            // 
            // SourceFolderButton
            // 
            this.SourceFolderButton.Location = new System.Drawing.Point(646, 68);
            this.SourceFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.SourceFolderButton.Name = "SourceFolderButton";
            this.SourceFolderButton.Size = new System.Drawing.Size(37, 22);
            this.SourceFolderButton.TabIndex = 30;
            this.SourceFolderButton.Text = "...";
            this.SourceFolderButton.UseVisualStyleBackColor = true;
            this.SourceFolderButton.Click += new System.EventHandler(this.SourceFolderButton_Click);
            // 
            // SourceFolderDialog
            // 
            this.SourceFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.SourceFolderDialog.ShowNewFolderButton = false;
            // 
            // hoursCheckbox
            // 
            this.hoursCheckbox.AutoSize = true;
            this.hoursCheckbox.Checked = true;
            this.hoursCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hoursCheckbox.Location = new System.Drawing.Point(7, 7);
            this.hoursCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.hoursCheckbox.Name = "hoursCheckbox";
            this.hoursCheckbox.Size = new System.Drawing.Size(150, 20);
            this.hoursCheckbox.TabIndex = 45;
            this.hoursCheckbox.Text = "Include images up to";
            this.hoursCheckbox.UseVisualStyleBackColor = true;
            this.hoursCheckbox.CheckedChanged += new System.EventHandler(this.hoursCheckbox_CheckedChanged);
            // 
            // hours
            // 
            this.hours.Location = new System.Drawing.Point(165, 6);
            this.hours.Margin = new System.Windows.Forms.Padding(4);
            this.hours.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.hours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(55, 22);
            this.hours.TabIndex = 50;
            this.hours.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(220, 8);
            this.lblHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(63, 16);
            this.lblHours.TabIndex = 12;
            this.lblHours.Text = "hours old";
            // 
            // kilobytesCheckbox
            // 
            this.kilobytesCheckbox.AutoSize = true;
            this.kilobytesCheckbox.Checked = true;
            this.kilobytesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kilobytesCheckbox.Location = new System.Drawing.Point(7, 37);
            this.kilobytesCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.kilobytesCheckbox.Name = "kilobytesCheckbox";
            this.kilobytesCheckbox.Size = new System.Drawing.Size(184, 20);
            this.kilobytesCheckbox.TabIndex = 55;
            this.kilobytesCheckbox.Text = "include images larger than";
            this.kilobytesCheckbox.UseVisualStyleBackColor = true;
            this.kilobytesCheckbox.CheckedChanged += new System.EventHandler(this.kilobytesCheckbox_CheckedChanged);
            // 
            // kilobytes
            // 
            this.kilobytes.Location = new System.Drawing.Point(199, 37);
            this.kilobytes.Margin = new System.Windows.Forms.Padding(4);
            this.kilobytes.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.kilobytes.Name = "kilobytes";
            this.kilobytes.Size = new System.Drawing.Size(72, 22);
            this.kilobytes.TabIndex = 60;
            this.kilobytes.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lblKilobytes
            // 
            this.lblKilobytes.AutoSize = true;
            this.lblKilobytes.Location = new System.Drawing.Point(272, 39);
            this.lblKilobytes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKilobytes.Name = "lblKilobytes";
            this.lblKilobytes.Size = new System.Drawing.Size(24, 16);
            this.lblKilobytes.TabIndex = 15;
            this.lblKilobytes.Text = "Kb";
            // 
            // resolutionCheckbox
            // 
            this.resolutionCheckbox.AutoSize = true;
            this.resolutionCheckbox.Checked = true;
            this.resolutionCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.resolutionCheckbox.Location = new System.Drawing.Point(7, 66);
            this.resolutionCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.resolutionCheckbox.Name = "resolutionCheckbox";
            this.resolutionCheckbox.Size = new System.Drawing.Size(187, 20);
            this.resolutionCheckbox.TabIndex = 80;
            this.resolutionCheckbox.Text = "include images larger than ";
            this.resolutionCheckbox.UseVisualStyleBackColor = true;
            this.resolutionCheckbox.CheckedChanged += new System.EventHandler(this.resolutionCheckbox_CheckedChanged);
            // 
            // minWidth
            // 
            this.minWidth.Location = new System.Drawing.Point(199, 65);
            this.minWidth.Margin = new System.Windows.Forms.Padding(4);
            this.minWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.minWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minWidth.Name = "minWidth";
            this.minWidth.Size = new System.Drawing.Size(72, 22);
            this.minWidth.TabIndex = 85;
            this.minWidth.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(275, 68);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(16, 16);
            this.lblX.TabIndex = 18;
            this.lblX.Text = "X";
            // 
            // minHeight
            // 
            this.minHeight.Location = new System.Drawing.Point(293, 65);
            this.minHeight.Margin = new System.Windows.Forms.Padding(4);
            this.minHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.minHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minHeight.Name = "minHeight";
            this.minHeight.Size = new System.Drawing.Size(69, 22);
            this.minHeight.TabIndex = 90;
            this.minHeight.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblPixels
            // 
            this.lblPixels.AutoSize = true;
            this.lblPixels.Location = new System.Drawing.Point(362, 67);
            this.lblPixels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPixels.Name = "lblPixels";
            this.lblPixels.Size = new System.Drawing.Size(43, 16);
            this.lblPixels.TabIndex = 20;
            this.lblPixels.Text = "pixels";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // CancelButton
            // 
            this.CancelButton.CausesValidation = false;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(506, 294);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 28);
            this.CancelButton.TabIndex = 125;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressLabel,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 334);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(717, 22);
            this.statusStrip.TabIndex = 27;
            // 
            // progressLabel
            // 
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Visible = false;
            // 
            // ManualSelectionRadioButton
            // 
            this.ManualSelectionRadioButton.AutoSize = true;
            this.ManualSelectionRadioButton.Location = new System.Drawing.Point(16, 70);
            this.ManualSelectionRadioButton.Name = "ManualSelectionRadioButton";
            this.ManualSelectionRadioButton.Size = new System.Drawing.Size(132, 20);
            this.ManualSelectionRadioButton.TabIndex = 20;
            this.ManualSelectionRadioButton.Text = "Manual Selection ";
            this.ManualSelectionRadioButton.UseVisualStyleBackColor = true;
            this.ManualSelectionRadioButton.CheckedChanged += new System.EventHandler(this.ManualSelectionRadioButton_CheckedChanged);
            // 
            // BrowserRadioButton
            // 
            this.BrowserRadioButton.AutoSize = true;
            this.BrowserRadioButton.Checked = true;
            this.BrowserRadioButton.Location = new System.Drawing.Point(16, 12);
            this.BrowserRadioButton.Name = "BrowserRadioButton";
            this.BrowserRadioButton.Size = new System.Drawing.Size(135, 20);
            this.BrowserRadioButton.TabIndex = 10;
            this.BrowserRadioButton.TabStop = true;
            this.BrowserRadioButton.Text = "Browser Detection";
            this.BrowserRadioButton.UseVisualStyleBackColor = true;
            // 
            // BrowserDropDown
            // 
            this.BrowserDropDown.FormattingEnabled = true;
            this.BrowserDropDown.Location = new System.Drawing.Point(148, 8);
            this.BrowserDropDown.Name = "BrowserDropDown";
            this.BrowserDropDown.Size = new System.Drawing.Size(535, 24);
            this.BrowserDropDown.TabIndex = 15;
            this.BrowserDropDown.SelectedIndexChanged += new System.EventHandler(this.BrowserDropDown_SelectionChanged);
            // 
            // ManualSelectionErrorProvider
            // 
            this.ManualSelectionErrorProvider.ContainerControl = this;
            // 
            // TargetFolderErrorProvider
            // 
            this.TargetFolderErrorProvider.ContainerControl = this;
            // 
            // lblSourceFolderDisplay
            // 
            this.lblSourceFolderDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceFolderDisplay.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblSourceFolderDisplay.Location = new System.Drawing.Point(16, 39);
            this.lblSourceFolderDisplay.Name = "lblSourceFolderDisplay";
            this.lblSourceFolderDisplay.ReadOnly = true;
            this.lblSourceFolderDisplay.Size = new System.Drawing.Size(667, 20);
            this.lblSourceFolderDisplay.TabIndex = 17;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 700;
            this.toolTip1.AutoPopDelay = 7000;
            this.toolTip1.InitialDelay = 700;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1000;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(689, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "?";
            // 
            // lblBrowserHelpTooltip
            // 
            this.lblBrowserHelpTooltip.AutoSize = true;
            this.lblBrowserHelpTooltip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrowserHelpTooltip.Location = new System.Drawing.Point(689, 13);
            this.lblBrowserHelpTooltip.Name = "lblBrowserHelpTooltip";
            this.lblBrowserHelpTooltip.Size = new System.Drawing.Size(13, 13);
            this.lblBrowserHelpTooltip.TabIndex = 38;
            this.lblBrowserHelpTooltip.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(689, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(689, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(281, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(293, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(404, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "?";
            // 
            // chbxDeleteFilesFromCache
            // 
            this.chbxDeleteFilesFromCache.AutoSize = true;
            this.chbxDeleteFilesFromCache.Location = new System.Drawing.Point(6, 31);
            this.chbxDeleteFilesFromCache.Name = "chbxDeleteFilesFromCache";
            this.chbxDeleteFilesFromCache.Size = new System.Drawing.Size(189, 17);
            this.chbxDeleteFilesFromCache.TabIndex = 100;
            this.chbxDeleteFilesFromCache.Text = "Delete images from browser cache";
            this.chbxDeleteFilesFromCache.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(238, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "?";
            // 
            // chbxFileNamingPattern
            // 
            this.chbxFileNamingPattern.AutoSize = true;
            this.chbxFileNamingPattern.Location = new System.Drawing.Point(6, 58);
            this.chbxFileNamingPattern.Name = "chbxFileNamingPattern";
            this.chbxFileNamingPattern.Size = new System.Drawing.Size(143, 17);
            this.chbxFileNamingPattern.TabIndex = 110;
            this.chbxFileNamingPattern.Text = "Use pattern to name files";
            this.chbxFileNamingPattern.UseVisualStyleBackColor = true;
            this.chbxFileNamingPattern.CheckedChanged += new System.EventHandler(this.chbxFileNamingPattern_CheckChanged);
            // 
            // txtFileNamingPattern
            // 
            this.txtFileNamingPattern.Location = new System.Drawing.Point(185, 58);
            this.txtFileNamingPattern.Name = "txtFileNamingPattern";
            this.txtFileNamingPattern.Size = new System.Drawing.Size(447, 22);
            this.txtFileNamingPattern.TabIndex = 115;
            this.txtFileNamingPattern.TextChanged += new System.EventHandler(this.txtFileNamingPattern_TextChanged);
            // 
            // chbxAllowOverwriteFiles
            // 
            this.chbxAllowOverwriteFiles.AutoSize = true;
            this.chbxAllowOverwriteFiles.Location = new System.Drawing.Point(6, 6);
            this.chbxAllowOverwriteFiles.Name = "chbxAllowOverwriteFiles";
            this.chbxAllowOverwriteFiles.Size = new System.Drawing.Size(188, 17);
            this.chbxAllowOverwriteFiles.TabIndex = 95;
            this.chbxAllowOverwriteFiles.Text = "Allow overwrite files in target folder";
            this.chbxAllowOverwriteFiles.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(237, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "?";
            // 
            // FilePatternErrorProvider
            // 
            this.FilePatternErrorProvider.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 139);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 148);
            this.tabControl1.TabIndex = 52;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hoursCheckbox);
            this.tabPage1.Controls.Add(this.hours);
            this.tabPage1.Controls.Add(this.lblHours);
            this.tabPage1.Controls.Add(this.kilobytesCheckbox);
            this.tabPage1.Controls.Add(this.kilobytes);
            this.tabPage1.Controls.Add(this.lblKilobytes);
            this.tabPage1.Controls.Add(this.resolutionCheckbox);
            this.tabPage1.Controls.Add(this.minWidth);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lblX);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.minHeight);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblPixels);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(689, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPatternHelp);
            this.tabPage2.Controls.Add(this.lblPatternTranslationSample);
            this.tabPage2.Controls.Add(this.chbxAllowOverwriteFiles);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.chbxDeleteFilesFromCache);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.chbxFileNamingPattern);
            this.tabPage2.Controls.Add(this.txtFileNamingPattern);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(689, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPatternHelp
            // 
            this.btnPatternHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatternHelp.Location = new System.Drawing.Point(636, 54);
            this.btnPatternHelp.Name = "btnPatternHelp";
            this.btnPatternHelp.Size = new System.Drawing.Size(31, 28);
            this.btnPatternHelp.TabIndex = 117;
            this.btnPatternHelp.Text = "?";
            this.btnPatternHelp.UseVisualStyleBackColor = true;
            this.btnPatternHelp.Click += new System.EventHandler(this.btnPatternHelp_Click);
            // 
            // lblPatternTranslationSample
            // 
            this.lblPatternTranslationSample.AutoSize = true;
            this.lblPatternTranslationSample.Location = new System.Drawing.Point(185, 87);
            this.lblPatternTranslationSample.Name = "lblPatternTranslationSample";
            this.lblPatternTranslationSample.Size = new System.Drawing.Size(0, 16);
            this.lblPatternTranslationSample.TabIndex = 116;
            // 
            // MainGUI
            // 
            this.AcceptButton = this.CopyButton;
            this.AccessibleName = "cacheCopy";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(717, 356);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBrowserHelpTooltip);
            this.Controls.Add(this.lblSourceFolderDisplay);
            this.Controls.Add(this.BrowserDropDown);
            this.Controls.Add(this.BrowserRadioButton);
            this.Controls.Add(this.ManualSelectionRadioButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SourceFolderButton);
            this.Controls.Add(this.SourceFolderName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetFolderButton);
            this.Controls.Add(this.targetFolderName);
            this.Controls.Add(this.CopyButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainGUI";
            this.Text = "cacheCopy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUI_FormClosing);
            this.Load += new System.EventHandler(this.MainGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kilobytes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHeight)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManualSelectionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetFolderErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePatternErrorProvider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.FolderBrowserDialog TargetFolderDialog;
        private System.Windows.Forms.TextBox targetFolderName;
        private System.Windows.Forms.Button targetFolderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SourceFolderName;
        private System.Windows.Forms.Button SourceFolderButton;
        private System.Windows.Forms.FolderBrowserDialog SourceFolderDialog;
        private System.Windows.Forms.CheckBox hoursCheckbox;
        private System.Windows.Forms.NumericUpDown hours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.CheckBox kilobytesCheckbox;
        private System.Windows.Forms.NumericUpDown kilobytes;
        private System.Windows.Forms.Label lblKilobytes;
        private System.Windows.Forms.CheckBox resolutionCheckbox;
        private System.Windows.Forms.NumericUpDown minWidth;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown minHeight;
        private System.Windows.Forms.Label lblPixels;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        protected System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel progressLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.RadioButton ManualSelectionRadioButton;
        private System.Windows.Forms.RadioButton BrowserRadioButton;
        private System.Windows.Forms.ComboBox BrowserDropDown;
        private System.Windows.Forms.ErrorProvider ManualSelectionErrorProvider;
        private System.Windows.Forms.ErrorProvider TargetFolderErrorProvider;
        private System.Windows.Forms.TextBox lblSourceFolderDisplay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBrowserHelpTooltip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbxDeleteFilesFromCache;
        private System.Windows.Forms.CheckBox chbxFileNamingPattern;
        private System.Windows.Forms.TextBox txtFileNamingPattern;
        private System.Windows.Forms.CheckBox chbxAllowOverwriteFiles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider FilePatternErrorProvider;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblPatternTranslationSample;
        private System.Windows.Forms.Button btnPatternHelp;
    }
}

