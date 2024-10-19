
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbDialogIntro : MaterialForm
    {
        private bool isNewUser = false;

        public mbDialogIntro()
        {
            InitializeComponent();
            this.CenterToScreen();

            this.Icon = Properties.Resources.gl8;

            if (File.Exists(mbMainMenu.mbFilePathSettings))
            {
                isNewUser = false;

                mbIntroButtonLogin.Text = "Login";
                this.Height = 180;

                mbIntroTextBoxMasterPswdConfirm.Visible = false;
                mbIntroTextBoxMasterPswdWarning.Visible = false;
                mbIntroTextBoxMasterPswdConfirm.Enabled = false;
                mbIntroTextBoxMasterPswdWarning.Enabled = false;
                mbIntroTextBoxMasterPswdConfirm.PasswordChar = '*';
                mbIntroTextBoxMasterPswd.PasswordChar = '*';
            }
            else
            {
                isNewUser = true;

                MaterialMessageBox.Show("Welcome! Please set up your master password.", "GL8", MessageBoxButtons.OK, MessageBoxIcon.None);

                mbIntroButtonLogin.Text = "Set Password";
                this.Height = 380;

                mbIntroTextBoxMasterPswdConfirm.Visible = true;
                mbIntroTextBoxMasterPswdWarning.Visible = true;
                mbIntroTextBoxMasterPswdConfirm.Enabled = true;
                mbIntroTextBoxMasterPswdWarning.Enabled = true;
                mbIntroTextBoxMasterPswdConfirm.PasswordChar = '\0';
                mbIntroTextBoxMasterPswd.PasswordChar = '\0';
            }
        }

        private void mbIntroButtonLogin_Click(object sender, EventArgs e)
        {
            SecureString enteredPassword = new SecureString();
            foreach (char c in mbIntroTextBoxMasterPswd.Text)
            {
                enteredPassword.AppendChar(c);
            }
            enteredPassword.MakeReadOnly();

            if (enteredPassword == null || enteredPassword.Length == 0)
            {
                MaterialMessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isNewUser)
            {
                // User is setting up a new master password

                SecureString enteredPasswordConfirmation = new SecureString();
                foreach (char c in mbIntroTextBoxMasterPswdConfirm.Text)
                {
                    enteredPasswordConfirmation.AppendChar(c);
                }
                enteredPasswordConfirmation.MakeReadOnly();

                if (!SecureStringsEqual(enteredPassword, enteredPasswordConfirmation))
                {
                    MaterialMessageBox.Show("Entered passwords are not the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate salt for password hashing
                byte[] salt = mbMasterPasswordManager.GenerateSalt();
                string base64Salt = Convert.ToBase64String(salt);

                // Hash the password using Argon2 and the generated salt
                string hashedPassword = mbMasterPasswordManager.HashPassword(enteredPassword, salt);

                // Save settings
                mbUserSettings settings = new mbUserSettings
                {
                    HashedPassword = hashedPassword,
                    Salt = base64Salt
                };
                settings.SaveSettings(enteredPassword); // Use the password to encrypt the file

                MaterialMessageBox.Show("Master password set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Program.mbPassOK = true;
                Program.SetUserPassword(enteredPassword);
                this.Close();
            }
            else
            {
                // Existing user login

                // Attempt to load settings using the entered password
                mbUserSettings settings = mbUserSettings.LoadSettings(enteredPassword);

                if (settings == null)
                {
                    mbIntroTextBoxMasterPswd.Text = "";
                    MaterialMessageBox.Show("Incorrect password or user settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    byte[] saltBytes = Convert.FromBase64String(settings.Salt);

                    // Verify password using Argon2
                    if (mbMasterPasswordManager.VerifyPassword(enteredPassword, settings.HashedPassword, saltBytes))
                    {
                        Program.mbPassOK = true;
                        Program.SetUserPassword(enteredPassword);
                        this.Close();
                    }
                    else
                    {
                        mbIntroTextBoxMasterPswd.Text = "";
                        MaterialMessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MaterialMessageBox.Show("The stored salt value is not in a valid Base64 format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool SecureStringsEqual(SecureString ss1, SecureString ss2)
        {
            if (ss1 == null || ss2 == null)
                return false;

            if (ss1.Length != ss2.Length)
                return false;

            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;
            try
            {
                // Convert the SecureStrings to BSTR pointers
                bstr1 = Marshal.SecureStringToBSTR(ss1);
                bstr2 = Marshal.SecureStringToBSTR(ss2);

                // Get the length of the strings in bytes (Unicode characters are 2 bytes)
                int length1 = ss1.Length * 2;
                int length2 = ss2.Length * 2;

                // Compare byte by byte
                for (int i = 0; i < length1; i++)
                {
                    byte byte1 = Marshal.ReadByte(bstr1, i);
                    byte byte2 = Marshal.ReadByte(bstr2, i);

                    if (byte1 != byte2)
                    {
                        return false;
                    }
                }
                return true;
            }
            finally
            {
                // Zero and free the unmanaged memory
                if (bstr1 != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr1);

                if (bstr2 != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr2);
            }
        }

    }
}
