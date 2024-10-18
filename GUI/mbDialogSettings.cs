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
    public partial class mbDialogSettings : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;
        private mbDialogIntro _DialogIntro;
        public mbDialogSettings(mbMainMenu mainMenuInstance)
        {
            InitializeComponent();
            _mainMenuInstance = mainMenuInstance;

#if DEBUG   
            mbButtonSettingsDebug.Visible = true;
#endif
        }

        private void mbButtonSettingsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbSettingsSwtichHidePswd_CheckedChanged(object sender, EventArgs e)
        {
            if (mbSettingsSwitchHidePswd.Checked)
            {
                _mainMenuInstance.mbHidePasswords = true;
            }
            else
            {
                _mainMenuInstance.mbHidePasswords = false;
            }

            _mainMenuInstance.mbRefreshMainMenu();
        }

        private void mbButtonSettingsDebug_Click(object sender, EventArgs e)
        {
            _DialogIntro = new mbDialogIntro();
            _DialogIntro.ShowDialog();
        }

        private void mbButtonSettingsChangeMasterPassword_Click(object sender, EventArgs e)
        {
            SecureString currentPassword = new SecureString();
            foreach (char c in mbButtonSettingsChangeMasterPass_current.Text)
            {
                currentPassword.AppendChar(c);
            }
            currentPassword.MakeReadOnly();

            SecureString newPassword = new SecureString();
            foreach (char c in mbButtonSettingsChangeMasterPass_new.Text)
            {
                newPassword.AppendChar(c);
            }
            newPassword.MakeReadOnly();

            SecureString newPasswordConfirm = new SecureString();
            foreach (char c in mbButtonSettingsChangeMasterPass_newConfirm.Text)
            {
                newPasswordConfirm.AppendChar(c);
            }
            newPasswordConfirm.MakeReadOnly();

            // Compare new passwords (requires conversion)
            string newPasswordString = ConvertToUnsecureString(newPassword);
            string newPasswordConfirmString = ConvertToUnsecureString(newPasswordConfirm);

            if (newPasswordString != newPasswordConfirmString)
            {
                MessageBox.Show("The new passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceed to verify the current password and update
            mbUserSettings settings = mbUserSettings.LoadSettings(currentPassword);

            if (settings == null)
            {
                MessageBox.Show("Current password is incorrect or settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] saltBytes = Convert.FromBase64String(settings.Salt);

            if (!mbPasswordManager.VerifyPassword(currentPassword, settings.HashedPassword, saltBytes))
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate new salt and hash the new password
            byte[] newSalt = mbPasswordManager.GenerateSalt();
            settings.HashedPassword = mbPasswordManager.HashPassword(newPassword, newSalt);
            settings.Salt = Convert.ToBase64String(newSalt);

            // Save settings with new password
            settings.SaveSettings(newPassword);

            // Update mbMainMenu password
            _mainMenuInstance.UpdatePassword(currentPassword, newPassword);

            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear unsecure strings
            newPasswordString = null;
            newPasswordConfirmString = null;
        }

        private string ConvertToUnsecureString(SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = SecureStringMarshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
