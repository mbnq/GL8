using System;

public class UserSettings
{
    public string HashedPassword { get; set; }
    public string Salt { get; set; }

    // Method to load settings (e.g., from a file)
    public static UserSettings LoadSettings()
    {
        // Example: Load from JSON or database
        // For example, deserializing a JSON file into the UserSettings object
        // return JsonConvert.DeserializeObject<UserSettings>(File.ReadAllText("userSettings.json"));
        // Example data for testing:
        byte[] salt = PasswordManager.GenerateSalt();
        string base64Salt = Convert.ToBase64String(salt);

        // Hash the password using Argon2 and the generated salt
        string hashedPassword = PasswordManager.HashPassword("test", salt);

        return new UserSettings
        {
            HashedPassword = hashedPassword,  // Store the hashed version of "test"
            Salt = base64Salt  // Store the Base64-encoded salt
        };
    }

    // Method to save settings (e.g., to a file)
    public void SaveSettings()
    {
        // Example: Serialize to JSON and save to a file
        // File.WriteAllText("userSettings.json", JsonConvert.SerializeObject(this));
    }
}
