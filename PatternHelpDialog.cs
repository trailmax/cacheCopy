using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacheCopy
{
    public partial class PatternHelpDialog : Form
    {
        private String[,] result = new String[,]
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

        
        public PatternHelpDialog()
        {
            InitializeComponent();
            txtHelpDescription.Text = String.Format("* File Naming Pattern option provides you a way to control the way copied files are named. {0}{0}"+
                "* In the pattern you can use any of the symbols allowed in a filename and a set of the wildcard replacements listed below. {0}{0}" +
                "* The file extension can be amended - if it is not set in the pattern string, then it will be added automatically, based on the type " +
                "of file copied.", Environment.NewLine);

        }



        // close dialog on ESC button
        private void PatternHelpDialog_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void PatternHelpDialog_KeyUp(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void PopulateDataGrid()
        {
        //dataGrid

        }



    }
}
