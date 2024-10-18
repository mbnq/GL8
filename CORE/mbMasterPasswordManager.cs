
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using Konscious.Security.Cryptography;
using System;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using GL8.CORE;

public class mbMasterPasswordManager
{
    // Method to generate a random salt
    public static byte[] GenerateSalt(int size = 16)
    {
        var salt = new byte[size];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    // Method to hash a password using Argon2 with a provided salt
    public static string HashPassword(SecureString password, byte[] salt)
    {
        byte[] passwordBytes = mbSecureString.SecureStringToByteArray(password);

        try
        {
            var argon2 = new Argon2id(passwordBytes)
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            byte[] hash = argon2.GetBytes(32);
            return Convert.ToBase64String(hash);
        }
        finally
        {
            ClearByteArray(passwordBytes);
        }
    }

    // Method to verify a password against a stored hash and salt
    public static bool VerifyPassword(SecureString enteredPassword, string storedHash, byte[] salt)
    {
        string hashOfEntered = HashPassword(enteredPassword, salt);
        return SlowEquals(Convert.FromBase64String(hashOfEntered), Convert.FromBase64String(storedHash));
    }
    private static bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
            diff |= (uint)(a[i] ^ b[i]);
        return diff == 0;
    }
    private static void ClearByteArray(byte[] bytes)
    {
        if (bytes != null)
            Array.Clear(bytes, 0, bytes.Length);
    }
    public static bool UpdatePassword(string dataFilePath, SecureString oldPassword, SecureString newPassword, out string errorMessage)
    {
        errorMessage = null;
        try
        {
            // Load data with old password
            byte[] encryptedData = File.ReadAllBytes(dataFilePath);
            string jsonData = mbEncryptionUtility.DecryptStringFromBytes(encryptedData, oldPassword);

            // Re-encrypt data with new password
            byte[] newEncryptedData = mbEncryptionUtility.EncryptStringToBytes(jsonData, newPassword);
            File.WriteAllBytes(dataFilePath, newEncryptedData);

            return true;
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return false;
        }
    }
}
