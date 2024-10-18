
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

public class mbUserSettings
{
    public string HashedPassword { get; set; }
    public string Salt { get; set; }

    private static string userSettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user.dat");

    // Load settings from user.json using the user's password
    public static mbUserSettings LoadSettings(SecureString password)
    {
        if (File.Exists(userSettingsFilePath))
        {
            byte[] encryptedData = File.ReadAllBytes(userSettingsFilePath);
            try
            {
                string json = mbEncryptionUtility.DecryptStringFromBytes(encryptedData, password);
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

    // Save settings to user.json using the user's password
    public void SaveSettings(SecureString password)
    {
        string json = JsonConvert.SerializeObject(this);
        byte[] encryptedData = mbEncryptionUtility.EncryptStringToBytes(json, password);
        File.WriteAllBytes(userSettingsFilePath, encryptedData);
    }
}
