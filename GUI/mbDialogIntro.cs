using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbDialogIntro : MaterialForm
    {
        public mbDialogIntro()
        {
            InitializeComponent();
        }

        private void mbIntroButtonLogin_Click(object sender, EventArgs e)
        {
            if (mbIntroTextBoxMasterPswd.Text == "test")
            {
                Program.mbPassOK = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
