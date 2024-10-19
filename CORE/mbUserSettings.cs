
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

public class mbUserSettings
{
    private static mbWaitDialogManager _mbWaitDialogManager = new mbWaitDialogManager();
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
                _mbWaitDialogManager.Stop();
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
        public void SavePublicSettings()
        {
            try
            {
                Properties.Settings.Default.mbSettingsSwitchHidePswd = mbSettingsSwitchHidePswd.Checked;

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving public settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadPublicSettings()
        {
            try
            {
                mbSettingsSwitchHidePswd.Checked = Properties.Settings.Default.mbSettingsSwitchHidePswd;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading public settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}