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
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user.json")))
            {
                isNewUser = false;
                mbIntroButtonLogin.Text = "Login";
            }
            else
            {
                // User data file does not exist, prompt for new password
                isNewUser = true;
                MessageBox.Show("Welcome! Please set up your master password.", "New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mbIntroButtonLogin.Text = "Set Password";
            }
        }

        private void mbIntroButtonLogin_Click(object sender, EventArgs e)
        {
            string enteredPassword = mbIntroTextBoxMasterPswd.Text;

            if (string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isNewUser)
            {
                // User is setting up a new master password

                // Generate salt for password hashing
                byte[] salt = mbPasswordManager.GenerateSalt();
                string base64Salt = Convert.ToBase64String(salt);

                // Hash the password using Argon2 and the generated salt
                string hashedPassword = mbPasswordManager.HashPassword(enteredPassword, salt);

                // Save settings
                mbUserSettings settings = new mbUserSettings
                {
                    HashedPassword = hashedPassword,
                    Salt = base64Salt
                };
                settings.SaveSettings(enteredPassword); // Use the password to encrypt the file

                MessageBox.Show("Master password set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Program.mbPassOK = true;
                this.Close();
            }
            else
            {
                // Existing user login

                // Attempt to load settings using the entered password
                mbUserSettings settings = mbUserSettings.LoadSettings(enteredPassword);

                if (settings == null)
                {
                    MessageBox.Show("Incorrect password or user settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
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
