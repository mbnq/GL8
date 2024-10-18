/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.IO;
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
            string currentPassword = mbButtonSettingsChangeMasterPass_current.Text;
            string newPassword = mbButtonSettingsChangeMasterPass_new.Text;
            string newPasswordConfirm = mbButtonSettingsChangeMasterPass_newConfirm.Text;

            // Attempt to load settings using the current password
            mbUserSettings settings = mbUserSettings.LoadSettings(currentPassword);

            if (settings == null)
            {
                MessageBox.Show("Current password is incorrect or settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify the current password
            if (!mbPasswordManager.VerifyPassword(currentPassword, settings.HashedPassword, Convert.FromBase64String(settings.Salt)))
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the new passwords match
            if (newPassword != newPasswordConfirm)
            {
                MessageBox.Show("The new passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the new password is not empty
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("New password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a new salt and hash the new password
            byte[] newSalt = mbPasswordManager.GenerateSalt();
            settings.HashedPassword = mbPasswordManager.HashPassword(newPassword, newSalt);
            settings.Salt = Convert.ToBase64String(newSalt); // Store the salt as a Base64 string

            // Save settings encrypted with the new password
            settings.SaveSettings(newPassword);

            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally, clear the password fields
            mbButtonSettingsChangeMasterPass_current.Text = string.Empty;
            mbButtonSettingsChangeMasterPass_new.Text = string.Empty;
            mbButtonSettingsChangeMasterPass_newConfirm.Text = string.Empty;
        }
    }
}
