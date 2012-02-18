namespace cacheCopy
{
    partial class PatternHelpDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatternHelpDialog));
            this.txtHelpDescription = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHelpDescription
            // 
            this.txtHelpDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtHelpDescription.Location = new System.Drawing.Point(12, 12);
            this.txtHelpDescription.Name = "txtHelpDescription";
            this.txtHelpDescription.ReadOnly = true;
            this.txtHelpDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtHelpDescription.Size = new System.Drawing.Size(356, 96);
            this.txtHelpDescription.TabIndex = 0;
            this.txtHelpDescription.Text = "";
            this.txtHelpDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PatternHelpDialog_KeyUp);
            this.txtHelpDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatternHelpDialog_KeyUp);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(270, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 114);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(356, 265);
            this.dataGrid.TabIndex = 2;
            // 
            // PatternHelpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(380, 445);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtHelpDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatternHelpDialog";
            this.Text = "File Naming Pattern Help";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatternHelpDialog_KeyUp);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PatternHelpDialog_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHelpDescription;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}