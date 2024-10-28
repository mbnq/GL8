
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail 

*/

using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using Newtonsoft.Json;
using GL8.CORE;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Data;
using System.ComponentModel;

public class mbUserSettings
{
    private static mbWaitPrompter _mbWaitDialogManager = new mbWaitPrompter();
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
    public static mbUserSettings LoadSettings(SecureString password)
    {
        _mbWaitDialogManager.Start(null);
        if (File.Exists(mbMainMenu.mbFilePathSettings))
        {
            byte[] encryptedData = File.ReadAllBytes(mbMainMenu.mbFilePathSettings);
            try
            {
                string json = mbEncryption.DecryptStringFromBytes(encryptedData, password);
                return JsonConvert.DeserializeObject<mbUserSettings>(json);
            }
            catch (CryptographicException)
            {
                // Handle incorrect password
                _mbWaitDialogManager.Stop();
                return null;
            }
        }
        else
        {
            _mbWaitDialogManager.Stop();
            return null;
        }
    }
    public void SaveSettings(SecureString password)
    {
        _mbWaitDialogManager.Start(null);
        string json = JsonConvert.SerializeObject(this);
        byte[] encryptedData = mbEncryption.EncryptStringToBytes(json, password);
        File.WriteAllBytes(mbMainMenu.mbFilePathSettings, encryptedData);
        _mbWaitDialogManager.Stop();
    }
}

namespace GL8.CORE
{    
    public partial class mbDialogSettings : MaterialForm
    {
        public void SavePublicSettings(mbMainMenu _mainMenuInstance)
        {
            try
            {
                // run but rather saveload count
                Properties.Settings.Default.mbRunCount = mbMainMenu.mbRunCount;

                // main menu width
                Properties.Settings.Default.mbMainMenuWidth = _mainMenuInstance.Width;

                // show passwords
                Properties.Settings.Default.mbSettingsSwitchHidePswd = mbSettingsSwitchHidePswd.Checked;

                // Color Scheme Index
                Properties.Settings.Default.mbColorSchemeIndex = mbMainMenu.mbColorSchemeIndex;

                // Clipboard Clear Index
                Properties.Settings.Default.mbClipboardClearIndex = mbMainMenu.mbClipboardClearIndex;

                // AutoBackup Frequency Index
                Properties.Settings.Default.mbAutoBackupIndex = mbMainMenu.mbAutoBackupIndex;

                // Column order
                var columnOrder = new System.Collections.Specialized.StringCollection();
                foreach (DataGridViewColumn column in _mainMenuInstance.mbDataView.Columns)
                {
                    columnOrder.Add($"{column.Name}:{column.DisplayIndex}");
                }
                Properties.Settings.Default.mbDataViewColumnOrder = columnOrder;

                // ---

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving public settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadPublicSettings(mbMainMenu _mainMenuInstance)
        {
            try
            {
                // run but rather saveload count
                mbMainMenu.mbRunCount = Properties.Settings.Default.mbRunCount;

                // main menu width
                _mainMenuInstance.Width = Properties.Settings.Default.mbMainMenuWidth;

                // show passwords
                mbSettingsSwitchHidePswd.Checked = Properties.Settings.Default.mbSettingsSwitchHidePswd;

                // Color Scheme Index
                mbMainMenu.mbColorSchemeIndex = Properties.Settings.Default.mbColorSchemeIndex;

                // Clipboard Clear Index
                mbMainMenu.mbClipboardClearIndex = Properties.Settings.Default.mbClipboardClearIndex;

                // AutoBackup Frequency Index
                mbMainMenu.mbAutoBackupIndex = Properties.Settings.Default.mbAutoBackupIndex;

                // columnorder
                var columnOrder = Properties.Settings.Default.mbDataViewColumnOrder;
                if (columnOrder != null)
                {
                    foreach (var columnInfo in columnOrder)
                    {
                        var parts = columnInfo.Split(':');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int displayIndex))
                        {
                            var column = _mainMenuInstance.mbDataView.Columns[parts[0]];
                            if (column != null)
                            {
                                column.DisplayIndex = displayIndex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading public settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public partial class mbMainMenu : MaterialForm
    {
        // ------------------- Data Handling ----------------------
        public void LoadPSWDData()
        {
            _mbWaitDialogManager.Start(null);
            if (File.Exists(mbFilePath))
            {
                try
                {
                    byte[] encryptedData = File.ReadAllBytes(mbFilePath);
                    string jsonData = mbEncryption.DecryptStringFromBytes(encryptedData, _userPassword);
                    mbPSWDList = JsonConvert.DeserializeObject<BindingList<mbPSWD>>(jsonData);
                }
                catch (Exception ex)
                {
                    _mbWaitDialogManager.Start(null);
                    MaterialMessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mbPSWDList = new BindingList<mbPSWD>();
                }
            }
            else
            {
                mbPSWDList = new BindingList<mbPSWD>();
            }

            mbDataView.DataSource = mbPSWDList;

            if (mbDataView.Columns.Contains("pswdCreateTime"))
                mbDataView.Columns["pswdCreateTime"].HeaderText = "Creation Date";

            if (mbDataView.Columns.Contains("pswdLastEditTime"))
                mbDataView.Columns["pswdLastEditTime"].HeaderText = "Modify Date";

            _mbWaitDialogManager.Stop();
            this.Refresh();
        }
        public void CreateDataFileIfMissing()
        {
            if (!File.Exists(mbFilePath))
            {
                var result = MaterialMessageBox.Show(
                    "Database not found. Do you want to create a new Database?",
                    "GL8 - Create Database",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SavePSWDData();
                }
                else
                {
                    // Application.Exit();
                    this.BeginInvoke(new MethodInvoker(delegate { this.Close(); }));
                }
            }
        }
        public void SavePSWDData()
        {
            _mbWaitDialogManager.Start(null);
            try
            {
                string jsonData = JsonConvert.SerializeObject(mbPSWDList);
                byte[] encryptedData = mbEncryption.EncryptStringToBytes(jsonData, _userPassword);
                File.WriteAllBytes(mbFilePath, encryptedData);
                _mbWaitDialogManager.Stop();
            }
            catch (Exception ex)
            {
                _mbWaitDialogManager.Stop();
                MaterialMessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}