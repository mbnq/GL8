using System;
using System.IO;
using Newtonsoft.Json;

public class mbUserSettings
{
    public string HashedPassword { get; set; }
    public string Salt { get; set; }

    // Path to the user data file in the current program directory
    private static string userSettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user.json");

    // Method to load settings from user.json
    public static mbUserSettings LoadSettings()
    {
        if (File.Exists(userSettingsFilePath))
        {
            string json = File.ReadAllText(userSettingsFilePath);
            mbUserSettings settings = JsonConvert.DeserializeObject<mbUserSettings>(json);
            return settings;
        }
        else
        {
            return null;  // Return null if the file does not exist
        }
    }

    // Method to save settings to user.json
    public void SaveSettings()
    {
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText(userSettingsFilePath, json);
    }
}
