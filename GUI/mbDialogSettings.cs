﻿/* 

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

namespace GL8.CORE
{
    public partial class mbDialogSettings : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;
        public mbDialogSettings(mbMainMenu mainMenuInstance)
        {
            // right order is crucial

            InitializeComponent();

            _mainMenuInstance = mainMenuInstance;

            if (mainMenuInstance == null) throw new ArgumentNullException(nameof(mainMenuInstance), "Critical: Main menu instance cannot be null.");

            LoadPublicSettings(mainMenuInstance);

#if DEBUG
            mbButtonSettingsDebug.Visible = true;
#endif
            this.mbButtonSettingsLabel1.Text = $"GL8 v.{Program.mbVersion}";

            this.mbDropDownSettingsColorScheme.Items.Add("Grey");
            this.mbDropDownSettingsColorScheme.Items.Add("Red");
            this.mbDropDownSettingsColorScheme.Items.Add("Green");
            this.mbDropDownSettingsColorScheme.Items.Add("Blue");
            this.mbDropDownSettingsColorScheme.Items.Add("Mono");

            this.mbDropDownSettingsColorScheme.SelectedIndex = mbMainMenu.mbColorSchemeIndex;

            this.CenterToParent();
            this.ShowIcon = false;
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

        private mbWaitDialog _mbWaitDialog;
        private void mbButtonSettingsDebug_Click(object sender, EventArgs e)
        {
            _mbWaitDialog = new mbWaitDialog();
            _mbWaitDialog.ShowDialog();
        }
        private void mbButtonSettingsChangeMasterPassword_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Current password is incorrect or settings could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            mbCSVImporter importer = new mbCSVImporter(_mainMenuInstance);
            importer.ImportCsv();
        }
        private void mbButtonSettingsExportCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Export to CSV";
                saveFileDialog.FileName = "Export.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string delimiter = ";";

                    try
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            Delimiter = delimiter,
                        }))
                        {
                            // write header
                            csv.WriteHeader<mbPSWD>();
                            csv.NextRecord();

                            // write records
                            foreach (var record in _mainMenuInstance.mbPSWDList)
                            {
                                csv.WriteRecord(record);
                                csv.NextRecord();
                            }
                        }

                        MaterialMessageBox.Show("Data exported successfully!", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show($"Error exporting data: {ex.Message}", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void mbButtonSettingsLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.mbnq.pl",
                UseShellExecute = true
            });
        }
        private void mbButtonSettingsLabel1_Click(object sender, EventArgs e)
        {

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
            this.Refresh();
        }
    }
}
