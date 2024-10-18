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

        private void mbIntroButtonLogin_Click0(object sender, EventArgs e)
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

        private void mbIntroButtonLogin_Click(object sender, EventArgs e)
        {
            // Load user settings (hashed password and salt)
            mbUserSettings settings = mbUserSettings.LoadSettings();

            if (string.IsNullOrEmpty(settings.Salt))
            {
                MessageBox.Show("Salt value is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string enteredPassword = mbIntroTextBoxMasterPswd.Text;
                byte[] saltBytes = Convert.FromBase64String(settings.Salt);  // Check if salt conversion works

                // Verify password using Argon2
                if (mbPasswordManager.VerifyPassword(enteredPassword, settings.HashedPassword, saltBytes))
                {
                    Program.mbPassOK = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The stored salt value is not in a valid Base64 format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
