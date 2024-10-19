
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
