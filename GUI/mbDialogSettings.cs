
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
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
            mbUserSettings settings = mbUserSettings.LoadSettings();

            // Verify the current password
            if (!mbPasswordManager.VerifyPassword(mbButtonSettingsChangeMasterPass_current.Text, settings.HashedPassword, Convert.FromBase64String(settings.Salt)))
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the new passwords match
            if (mbButtonSettingsChangeMasterPass_new.Text != mbButtonSettingsChangeMasterPass_newConfirm.Text)
            {
                MessageBox.Show("The new passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a new salt and hash the new password
            byte[] newSalt = mbPasswordManager.GenerateSalt();
            settings.HashedPassword = mbPasswordManager.HashPassword(mbButtonSettingsChangeMasterPass_new.Text, newSalt);
            settings.Salt = Convert.ToBase64String(newSalt); // Store the salt as a Base64 string
            settings.SaveSettings();

            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
