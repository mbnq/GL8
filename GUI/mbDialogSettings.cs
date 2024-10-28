
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using CsvHelper.Configuration;
using CsvHelper;
using MaterialSkin.Controls;
using System;
using System.Globalization;
using System.IO;
using System.Security;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin;
using System.Data;

namespace GL8.CORE
{
    public partial class mbDialogSettings : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;

        private mbAbout mbAboutDialog;
        public mbDialogSettings(mbMainMenu mainMenuInstance)
        {
            // right order is crucial

            InitializeComponent();

            _mainMenuInstance = mainMenuInstance;

            if (mainMenuInstance == null) throw new ArgumentNullException(nameof(mainMenuInstance), "Critical: Main menu instance cannot be null.");

            // LoadPublicSettings(mainMenuInstance);

#if DEBUG
            mbButtonSettingsDebug.Visible = true;
#endif
            this.mbDropDownSettingsColorScheme.Items.Add("Grey");
            this.mbDropDownSettingsColorScheme.Items.Add("Red");
            this.mbDropDownSettingsColorScheme.Items.Add("Green");
            this.mbDropDownSettingsColorScheme.Items.Add("Blue");
            this.mbDropDownSettingsColorScheme.Items.Add("Mono");

            this.mbDropDownSettingsClipboardDelay.Items.Add("15");
            this.mbDropDownSettingsClipboardDelay.Items.Add("30");
            this.mbDropDownSettingsClipboardDelay.Items.Add("45");
            this.mbDropDownSettingsClipboardDelay.Items.Add("60");

            this.mbDropDownSettingsImportExportBackup.Items.Add("Backup");
            this.mbDropDownSettingsImportExportBackup.Items.Add("JSON Import");
            this.mbDropDownSettingsImportExportBackup.Items.Add("JSON Export");
            this.mbDropDownSettingsImportExportBackup.Items.Add("CSV Import");
            this.mbDropDownSettingsImportExportBackup.Items.Add("CSV Export");

            this.mbDropDownSettingsImportBackupFrequency.Items.Add("Disabled");
            this.mbDropDownSettingsImportBackupFrequency.Items.Add("20");
            this.mbDropDownSettingsImportBackupFrequency.Items.Add("50");
            this.mbDropDownSettingsImportBackupFrequency.Items.Add("100");

            this.mbDropDownSettingsColorScheme.SelectedIndex    = mbMainMenu.mbColorSchemeIndex;
            this.mbDropDownSettingsClipboardDelay.SelectedIndex = mbMainMenu.mbClipboardClearIndex;
            this.mbDropDownSettingsImportBackupFrequency.SelectedIndex = mbMainMenu.mbAutoBackupIndex;


            // this.mbDropDownSettingsImportExportBackup.SelectedIndex = 0;

            this.CenterToParent();
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.Shown += (sender, e) => { _mainMenuInstance.mbSwitchEnableMainMenuControls(false); };
            this.FormClosed += (sender, e) => { _mainMenuInstance.mbSwitchEnableMainMenuControls(true); };
            this.FormClosing += (sender, e) => { SavePublicSettings(mainMenuInstance); };
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
            // MaterialMessageBox.Show($"Debugging is enabled. {mbMainMenu.mbClipboardClearDelay}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            mbAboutDialog = new mbAbout();
            mbAboutDialog.ShowDialog();
        }
        private void mbButtonSettingsChangeMasterPassword_Click(object sender, EventArgs e)
        {
            DialogResult mbRUSure = MaterialMessageBox.Show(
                "\nAre you sure you want to continue?\n\nDo not lose your new password, the old one will no longer work.",
                "Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (mbRUSure != DialogResult.OK) return;

            if ((mbButtonSettingsChangeMasterPass_current.Text == string.Empty) ||
                (mbButtonSettingsChangeMasterPass_new.Text == string.Empty) ||
                (mbButtonSettingsChangeMasterPass_newConfirm.Text == string.Empty))
            {
                MaterialMessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mbButtonSettingsChangeMasterPass_new.Text.Length < 8)
            {
                MaterialMessageBox.Show("Password must be at least 8 characters long for security reasons.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mbButtonSettingsChangeMasterPass_new.Text = "";
                mbButtonSettingsChangeMasterPass_newConfirm.Text = "";
                return;
            }

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

            if (!mbSecureString.SSEqual(newPassword, newPasswordConfirm))
            {
                MaterialMessageBox.Show("Entered passwords are not the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceed to verify the current password and update
            mbUserSettings settings = mbUserSettings.LoadSettings(currentPassword);

            if (settings == null)
            {
                MaterialMessageBox.Show("Current password is incorrect or settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] saltBytes = Convert.FromBase64String(settings.Salt);

            if (!mbMasterPasswordManager.VerifyPassword(currentPassword, settings.HashedPassword, saltBytes))
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate new salt and hash the new password
            byte[] newSalt = mbMasterPasswordManager.GenerateSalt();
            settings.HashedPassword = mbMasterPasswordManager.HashPassword(newPassword, newSalt);
            settings.Salt = Convert.ToBase64String(newSalt);

            // Save settings with new password
            settings.SaveSettings(newPassword);

            // Update the data file's encryption
            string errorMessage;
            bool success = mbMasterPasswordManager.UpdatePassword(mbMainMenu.mbFilePath, currentPassword, newPassword, out errorMessage);

            if (success)
            {
                // Update the stored password in mbMainMenu
                _mainMenuInstance.UpdateUserPassword(newPassword);

                MaterialMessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MaterialMessageBox.Show("Error updating data encryption: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mbButtonSettingsImportCSV_Click(object sender, EventArgs e)
        {
            mbCSVImport importer = new mbCSVImport(_mainMenuInstance);
            importer.ImportCsv();
        }
        private void mbButtonSettingsExportCSV_Click(object sender, EventArgs e)
        {
            mbCSVExport(_mainMenuInstance);
        }
        private void mbButtonSettingsLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.mbnq.pl",
                UseShellExecute = true
            });
        }
        private void mbDropDownSettingsColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorScheme selectedScheme;

            // Determine which scheme was selected
            switch (mbDropDownSettingsColorScheme.SelectedIndex)
            {
                case 0:
                    selectedScheme = mbMainMenu.mbColorSchemeGrey;
                    break;
                case 1:
                    selectedScheme = mbMainMenu.mbColorSchemeRed;
                    break;
                case 2:
                    selectedScheme = mbMainMenu.mbColorSchemeGreen;
                    break;                
                case 3:
                    selectedScheme = mbMainMenu.mbColorSchemeBlue; 
                    break;                
                case 4:
                    selectedScheme = mbMainMenu.mbColorSchemeMono; 
                    break;
                default:
                    selectedScheme = mbMainMenu.mbColorSchemeBlue;
                    break;
            }

            mbMainMenu.mbColorSchemeIndex = mbDropDownSettingsColorScheme.SelectedIndex;
            _mainMenuInstance.InitializeMaterialSkin(selectedScheme);
            _mainMenuInstance.Refresh();
            _mainMenuInstance.mbSwitchColorScheme();
            this.Refresh();
        }
        private void mbDropDownSettingsImportExportBackup_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mbDropDownSettingsImportExportBackup.SelectedIndex)
            {
                case 0:
                    mbButtonSettingsBackup_Click(this, EventArgs.Empty);
                    break;
                case 1:
                    mbJSONImport(_mainMenuInstance);
                    break;
                case 2:
                    mbJSONExport(_mainMenuInstance);
                    break;
                case 3:
                    mbButtonSettingsImportCSV_Click(this, EventArgs.Empty);
                    break;
                case 4:
                    mbButtonSettingsExportCSV_Click(this, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }
        private void mbDropDownSettingsImportBackupFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mbDropDownSettingsImportBackupFrequency.SelectedIndex)
            {
                case 0:
                    mbMainMenu.mbAutoBackupFrequency = -1;
                    break;
                default:
                case 1:
                    mbMainMenu.mbAutoBackupFrequency = 20;
                    break;
                case 2:
                    mbMainMenu.mbAutoBackupFrequency = 50;
                    break;
                case 3:
                    mbMainMenu.mbAutoBackupFrequency = 100;
                    break;
            }

            // Correct variable being assigned
            mbMainMenu.mbAutoBackupIndex = mbDropDownSettingsImportBackupFrequency.SelectedIndex;
            _mainMenuInstance.Refresh();
            this.Refresh();
        }
        private void mbDropDownSettingsClipboardDelay_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (mbDropDownSettingsClipboardDelay.SelectedIndex)
            {
                case 0:
                    mbMainMenu.mbClipboardClearDelay = 15;
                    break;
                case 1:
                    mbMainMenu.mbClipboardClearDelay = 30;
                    break;
                case 2:
                    mbMainMenu.mbClipboardClearDelay = 45;
                    break;
                case 3:
                default:
                    mbMainMenu.mbClipboardClearDelay = 60;
                    break;
            }

            mbMainMenu.mbClipboardClearIndex = mbDropDownSettingsClipboardDelay.SelectedIndex;
            _mainMenuInstance.Refresh();
            this.Refresh();
        }
        private void mbTextBoxEditPassword_GetRandom_Click(object sender, EventArgs e)
        {
            var passwordGenerator = new mbRNG();
            string password = passwordGenerator.mbGenerateRandomPassword((int)mbTextBoxEditPassword_GetRandomNum.Value, true, true, true, true);
            mbButtonSettingsChangeMasterPass_new.Text = password;
            mbButtonSettingsChangeMasterPass_newConfirm.Text = password;
        }
        private void mbButtonSettingsBackup_Click(object sender, EventArgs e)
        {
            DialogResult mbRUSure = MaterialMessageBox.Show(
                "\nAn encrypted backup of your data will be created in \\AppData\\Roaming\\ directory to ensure your information is safely stored.\nDo you want to continue?",
                "Backup",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (mbRUSure != DialogResult.OK) return;

            try
            {
                mbBackup _backupManager;
                _backupManager = new mbBackup(_mainMenuInstance, true);
                _backupManager.CheckAndGo();
            }
            catch (Exception exception)
            {
                MaterialMessageBox.Show("Error creating backup: " + exception.Message, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void mbButtonSettingsExportJSON_Click(object sender, EventArgs e)
        {
            mbJSONExport(_mainMenuInstance);
        }
        private void mbButtonSettingsImportJSON_Click(object sender, EventArgs e)
        {
            mbJSONImport(_mainMenuInstance);
        }
        private void mbDropDownSettings_Click(object sender, EventArgs e)
        {
            mbAboutDialog = new mbAbout();
            mbAboutDialog.ShowDialog();
        }
    }
}
