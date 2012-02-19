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
            this.dataRepeater1 = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.txtExplanation = new System.Windows.Forms.TextBox();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnCopyPattern = new System.Windows.Forms.Button();
            this.dataRepeater1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(293, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataRepeater1
            // 
            // 
            // dataRepeater1.ItemTemplate
            // 
            this.dataRepeater1.ItemTemplate.Size = new System.Drawing.Size(348, 33);
            this.dataRepeater1.Location = new System.Drawing.Point(12, 184);
            this.dataRepeater1.Name = "dataRepeater1";
            this.dataRepeater1.Size = new System.Drawing.Size(356, 220);
            this.dataRepeater1.TabIndex = 2;
            this.dataRepeater1.Text = "dataRepeater1";
            // 
            // txtExplanation
            // 
            this.txtExplanation.Location = new System.Drawing.Point(145, 114);
            this.txtExplanation.Name = "txtExplanation";
            this.txtExplanation.ReadOnly = true;
            this.txtExplanation.Size = new System.Drawing.Size(209, 20);
            this.txtExplanation.TabIndex = 2;
            // 
            // txtPattern
            // 
            this.txtPattern.Location = new System.Drawing.Point(72, 116);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.ReadOnly = true;
            this.txtPattern.Size = new System.Drawing.Size(67, 20);
            this.txtPattern.TabIndex = 1;
            // 
            // btnCopyPattern
            // 
            this.btnCopyPattern.Location = new System.Drawing.Point(12, 114);
            this.btnCopyPattern.Name = "btnCopyPattern";
            this.btnCopyPattern.Size = new System.Drawing.Size(54, 23);
            this.btnCopyPattern.TabIndex = 0;
            this.btnCopyPattern.Text = "Copy";
            this.btnCopyPattern.UseVisualStyleBackColor = true;
            // 
            // PatternHelpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(380, 445);
            this.Controls.Add(this.txtExplanation);
            this.Controls.Add(this.dataRepeater1);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopyPattern);
            this.Controls.Add(this.txtHelpDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatternHelpDialog";
            this.Text = "File Naming Pattern Help";
            this.Load += new System.EventHandler(this.PatternHelpDialog_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PatternHelpDialog_KeyUp);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PatternHelpDialog_KeyUp);
            this.dataRepeater1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHelpDescription;
        private System.Windows.Forms.Button btnClose;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater dataRepeater1;
        private System.Windows.Forms.TextBox txtExplanation;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnCopyPattern;
    }
}