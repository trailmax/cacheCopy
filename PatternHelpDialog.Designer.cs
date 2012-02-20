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
            this.TemplateTxtExplanation = new System.Windows.Forms.TextBox();
            this.TemplateTxtPattern = new System.Windows.Forms.TextBox();
            this.TemplateBtnCopyPattern = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHelpDescription
            // 
            this.txtHelpDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtHelpDescription.Location = new System.Drawing.Point(1, 3);
            this.txtHelpDescription.Name = "txtHelpDescription";
            this.txtHelpDescription.ReadOnly = true;
            this.txtHelpDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtHelpDescription.Size = new System.Drawing.Size(378, 105);
            this.txtHelpDescription.TabIndex = 0;
            this.txtHelpDescription.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(301, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TemplateTxtExplanation
            // 
            this.TemplateTxtExplanation.Location = new System.Drawing.Point(110, 6);
            this.TemplateTxtExplanation.Name = "TemplateTxtExplanation";
            this.TemplateTxtExplanation.ReadOnly = true;
            this.TemplateTxtExplanation.Size = new System.Drawing.Size(245, 20);
            this.TemplateTxtExplanation.TabIndex = 2;
            // 
            // TemplateTxtPattern
            // 
            this.TemplateTxtPattern.Location = new System.Drawing.Point(51, 6);
            this.TemplateTxtPattern.Name = "TemplateTxtPattern";
            this.TemplateTxtPattern.ReadOnly = true;
            this.TemplateTxtPattern.Size = new System.Drawing.Size(53, 20);
            this.TemplateTxtPattern.TabIndex = 1;
            // 
            // TemplateBtnCopyPattern
            // 
            this.TemplateBtnCopyPattern.Location = new System.Drawing.Point(3, 3);
            this.TemplateBtnCopyPattern.Name = "TemplateBtnCopyPattern";
            this.TemplateBtnCopyPattern.Size = new System.Drawing.Size(42, 23);
            this.TemplateBtnCopyPattern.TabIndex = 0;
            this.TemplateBtnCopyPattern.Text = "Insert";
            this.TemplateBtnCopyPattern.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.TemplateBtnCopyPattern);
            this.panel1.Controls.Add(this.TemplateTxtExplanation);
            this.panel1.Controls.Add(this.TemplateTxtPattern);
            this.panel1.Location = new System.Drawing.Point(1, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 299);
            this.panel1.TabIndex = 3;
            // 
            // PatternHelpDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(380, 445);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtHelpDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PatternHelpDialog";
            this.Text = "File Naming Pattern Help";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtHelpDescription;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox TemplateTxtExplanation;
        private System.Windows.Forms.TextBox TemplateTxtPattern;
        private System.Windows.Forms.Button TemplateBtnCopyPattern;
        private System.Windows.Forms.Panel panel1;
    }
}