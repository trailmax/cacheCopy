using System;
using System.Drawing;
using System.Windows.Forms;

namespace cacheCopy
{
    public partial class PatternHelpDialog : Form
    {
        private String[,] information = new String[,]
            {
                {"*yyyy*", "Current year: 2012"},  // 1999
                {"*yy*", "Current year: 12"},      // 99
                {"*MM*", "Current month: 02"},      // 02 (for February)
                {"*MMM*", "Current month in short word: Feb"},    // Feb (for February)
                {"*dd*", "Current date: 09"},      // 05 for fifth
                {"*HH*", "Current hour: 04"},      // 07 - hours
                {"*mm*", "Current minute: 07"},      // minutes
                {"*ss*", "Current second: 06"},      // seconds
                {"*ffff*", "Current ten-thousands of a second"},  //	The hundredths of a second
                {"*fffffff*", "Current ten-millionth of a second"}, //The ten millionths of a second
                {"*CFyyyy*", "Year from file creation date: 2012"},
                {"*CFyy*", "Year from file creation date: 12"},
                {"*CFMM*", "Month from file creation date: 02"},
                {"*CFMMM*", "Month from file creation date: Feb"},
                {"*CFdd*", "Day from file creation date: 02"},
                {"*CFHH*", "Hour from file creation time: 23"},
                {"*CFmm*", "Minute from file creation time: 59"},
                {"*CFss*", "Second from file creation time: 01"},
                {"*CFff*", "Hundredth from file creation time: 99"},
                {"*RAND3*", "Random string with 3 symbols"},
                {"*RAND4*", "Random string with 4 symbols"},
                {"*RAND5*", "Random string with 6 symbols"},
                {"*RAND6*", "Random string with 6 symbols"},
                {"*NUM*", "Current number of file during copying: 079"}
            };

        // reference to the main screen
        MainGUI mainGui;
        

        public PatternHelpDialog(MainGUI main)
        {
            InitializeComponent();
            txtHelpDescription.Text = String.Format("* File Naming Pattern option provides you a way to control the way copied files are named. {0}{0}"+
                "* In the pattern you can use any of the symbols allowed in a filename and a set of the wildcard replacements listed below. {0}{0}" +
                "* The file extension can be amended - if it is not set in the pattern string, then it will be added automatically, based on the type " +
                "of file copied.", Environment.NewLine);
            
            // save the reference to the main screen
            mainGui = main;

            HideTemplateControls();

            CreateControlsTable();

        }

        #region Closing dialog events


        /// <summary>
        /// Hide the dialog on ESC key
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
                this.Hide();
        }

        
        /// <summary>
        /// Close dialog when close button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion


        /// <summary>
        /// Create DataTable structure and fill the information from the array
        /// 
        /// Not the best solution to create a grid with a button and 2 textboxes. 
        /// But DataGrid proven to be a pain in the neck, so is DataRepeater.
        /// So this is a quick and dirty way of doing what I need. 
        /// this is only a freaking help screen after all, no over-engineering here please!
        /// </summary>
        private void CreateControlsTable()
        {
            int Y_padding = 3;
            for (int i = 0; i < information.GetUpperBound(0); i++)
            {
                // tabs are special here!
                int tabCount = 10*i;

                // say what location we want. 
                // Y-location is computed based on the number of buttons already on the screen and by vertical padding
                int Y = TemplateBtnCopyPattern.Location.Y + i * (TemplateBtnCopyPattern.Height + Y_padding);
                // X location is copied from the template controls
                int X = TemplateTxtPattern.Location.X;
                
                // First Text Box
                TextBox pattern = CreateTextBox(X, Y, information[i, 0], TemplateTxtPattern, tabCount + 1);
                panel1.Controls.Add(pattern);

                // Copy button
                X = TemplateBtnCopyPattern.Location.X;
                Button copy = new Button();
                copy.Location = new Point(X, Y);
                copy.Text = TemplateBtnCopyPattern.Text;
                copy.Size = new Size(TemplateBtnCopyPattern.Width, TemplateBtnCopyPattern.Height);
                copy.Click += new System.EventHandler(this.CopyButton_Click);
                copy.Tag = pattern;     // we need to associate a button with pattern textbox, so we can reference it later
                copy.TabIndex = tabCount;
                panel1.Controls.Add(copy);

                //Second text Box
                X = TemplateTxtExplanation.Location.X;
                TextBox expl = CreateTextBox(X, Y, information[i,1], TemplateTxtExplanation, tabCount+2);
                panel1.Controls.Add(expl);
            }

        }


        /// <summary>
        /// Creates the text box with the size and shape of the pattern-TextBox
        /// Give it new location and text
        /// </summary>
        /// <param name="X">The X.</param>
        /// <param name="Y">The Y.</param>
        /// <param name="text">The text.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        private TextBox CreateTextBox(int X, int Y, string text, TextBox pattern, int tabIndex)
        {
            TextBox box = new TextBox();
            box.Location = new Point(X, Y);
            box.Text = text;
            box.Size = new Size(pattern.Width, pattern.Height);
            box.ReadOnly = true;
            box.TabIndex = tabIndex;
            return box;
        }

        
        /// <summary>
        /// There are template controls on the panel. We want to remove them,
        /// but still available to take their properties.
        /// So just hide them.
        /// </summary>
        private void HideTemplateControls()
        {
            TemplateBtnCopyPattern.Visible = false;
            TemplateTxtPattern.Visible = false;
            TemplateTxtExplanation.Visible = false;
        }


        /// <summary>
        /// Pass on a text value from pattern text-box into the main form, so this can be inserted into the
        /// File Naming Pattern Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyButton_Click(object sender, EventArgs e)
        {
            // get the button that sent the event
            Button btn = (Button)sender;

            // every button is associated via tag with TextBox containing a pattern
            TextBox pattern = (TextBox)btn.Tag;

            // and now get the text from the TextBox and pass it on to the main screen
            mainGui.AddToNamingPattern(pattern.Text);

        }
    }
}
