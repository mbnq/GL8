using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

public class mbUserSettings
{
    public string HashedPassword { get; set; }
    public string Salt { get; set; }

    private static string userSettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user.json");

    // Load settings from user.json using the user's password
    public static mbUserSettings LoadSettings(string password)
    {
        if (File.Exists(userSettingsFilePath))
        {
            byte[] encryptedData = File.ReadAllBytes(userSettingsFilePath);

            try
            {
                string json = EncryptionUtility.DecryptStringFromBytes(encryptedData, password);
                mbUserSettings settings = JsonConvert.DeserializeObject<mbUserSettings>(json);
                return settings;
            }
            catch (CryptographicException)
            {
                // Handle incorrect password or decryption failure
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    // Save settings to user.json using the user's password
    public void SaveSettings(string password)
    {
        string json = JsonConvert.SerializeObject(this);
        byte[] encryptedData = EncryptionUtility.EncryptStringToBytes(json, password);
        File.WriteAllBytes(userSettingsFilePath, encryptedData);
    }
}
