
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
using System.Net;
using MaterialSkin.Controls;

public class mbUserSettings
{
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
    public static mbUserSettings LoadSettings(SecureString password)
    {
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
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    public void SaveSettings(SecureString password)
    {
        string json = JsonConvert.SerializeObject(this);
        byte[] encryptedData = mbEncryption.EncryptStringToBytes(json, password);
        File.WriteAllBytes(mbMainMenu.mbFilePathSettings, encryptedData);
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