using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbDialogIntro : MaterialForm
    {
        private bool isNewUser = false;

        public mbDialogIntro()
        {
            InitializeComponent();

            // Check if user.json exists
            mbUserSettings settings = mbUserSettings.LoadSettings();

            if (settings == null)
            {
                // User data file does not exist, prompt for new password
                isNewUser = true;
                MessageBox.Show("Welcome! Please set up your master password.", "New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbIntroButtonLogin.Text = "Set Password";
            }
            else
            {
                isNewUser = false;
                mbIntroButtonLogin.Text = "Login";
            }
        }

        private void mbIntroButtonLogin_Click(object sender, EventArgs e)
        {
            if (isNewUser)
            {
                // User is setting up a new master password
                string newPassword = mbIntroTextBoxMasterPswd.Text;

                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate salt and hash the password
                byte[] salt = mbPasswordManager.GenerateSalt();
                string base64Salt = Convert.ToBase64String(salt);
                string hashedPassword = mbPasswordManager.HashPassword(newPassword, salt);

                // Save settings
                mbUserSettings settings = new mbUserSettings
                {
                    HashedPassword = hashedPassword,
                    Salt = base64Salt
                };
                settings.SaveSettings();

                MessageBox.Show("Master password set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Program.mbPassOK = true;
                this.Close();
            }
            else
            {
                // Existing user login
                mbUserSettings settings = mbUserSettings.LoadSettings();

                if (settings == null)
                {
                    MessageBox.Show("User settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(settings.Salt))
                {
                    MessageBox.Show("Salt value is missing or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string enteredPassword = mbIntroTextBoxMasterPswd.Text;
                    byte[] saltBytes = Convert.FromBase64String(settings.Salt);

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
}
