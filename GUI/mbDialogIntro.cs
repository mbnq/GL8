
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

    mbDialogIntro.cs

*/

using MaterialSkin.Controls;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbDialogIntro : MaterialForm
    {
        private bool isNewUser = false;
        private mbMainMenu _mainMenuInstance;
        public mbDialogIntro()
        {
            InitializeComponent();
            this.CenterToScreen();
            mbKeySoundHandler.RegisterKeySoundHandler(this.Controls, _mainMenuInstance);

            this.Icon = Properties.Resources.gl8;
            this.AcceptButton = mbIntroButtonLogin;

            if (File.Exists(mbMainMenu.mbFilePathSettings))
            {
                isNewUser = false;

                mbIntroButtonLogin.Text = "Login";
                mbIntroButtonLogin.Focus();
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
                mbIntroButtonLogin.Focus();
                this.Height = 380;

                mbIntroTextBoxMasterPswdConfirm.Visible = true;
                mbIntroTextBoxMasterPswdWarning.Visible = true;
                mbIntroTextBoxMasterPswdConfirm.Enabled = true;
                mbIntroTextBoxMasterPswdWarning.Enabled = true;
                mbIntroTextBoxMasterPswdConfirm.PasswordChar = '\0';
                mbIntroTextBoxMasterPswd.PasswordChar = '\0';
            }
        }

        private async void mbIntroButtonLogin_Click(object sender, EventArgs e)
        {
            SecureString enteredPassword = new SecureString();
            foreach (char c in mbIntroTextBoxMasterPswd.Text)
            {
                enteredPassword.AppendChar(c);
            }
            enteredPassword.MakeReadOnly();

            if (enteredPassword == null || enteredPassword.Length == 0)
            {
                this.Hide();
                MaterialMessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
                return;
            }

            if (isNewUser) // User is setting up a new master password
            {

                if (mbIntroTextBoxMasterPswd.Text.Length < 8)
                {
                    this.Hide();
                    MaterialMessageBox.Show("Password must be at least 8 characters long for security reasons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                    mbIntroTextBoxMasterPswd.Text = "";
                    mbIntroTextBoxMasterPswdConfirm.Text = "";
                    return;
                }

                SecureString enteredPasswordConfirmation = new SecureString();
                foreach (char c in mbIntroTextBoxMasterPswdConfirm.Text)
                {
                    enteredPasswordConfirmation.AppendChar(c);
                }
                enteredPasswordConfirmation.MakeReadOnly();

                if (!SecureStringsEqual(enteredPassword, enteredPasswordConfirmation))
                {
                    this.Hide();
                    MaterialMessageBox.Show("Entered passwords are not the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
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

                this.Hide();
                MaterialMessageBox.Show("Master password set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
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
                    this.Hide();
                    MaterialMessageBox.Show("Incorrect password or user settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();

                    // wait couple of seconds to prevent brute force attacks
                    await AntiBruteForceWaiter();

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
                        this.Hide();
                        MaterialMessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        await AntiBruteForceWaiter();
                    }
                }
                catch (FormatException)
                {
                    this.Hide();
                    MaterialMessageBox.Show("The stored salt value is not in a valid Base64 format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show();
                }
            }
        }

        private async Task AntiBruteForceWaiter()
        {
            byte _timeInSeconds = 6;

            this.Enabled = false;
            mbIntroTextBoxMasterPswd.Enabled = false;
            mbIntroButtonLogin.Enabled = false;

            for (int i = 0; i < _timeInSeconds; i++)
            {
                mbIntroButtonLogin.Text = $"Please wait... {_timeInSeconds - i}s";
                await Task.Delay(1000);
            }

            mbIntroButtonLogin.Text = "Login";
            this.Enabled = true;
            mbIntroButtonLogin.Enabled = true;
            mbIntroTextBoxMasterPswd.Enabled = true;
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
