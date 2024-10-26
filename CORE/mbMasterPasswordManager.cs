
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
    public static byte[] GenerateSalt(int size = 64)
    {
        var salt = new byte[size];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }
    public static string HashPassword(SecureString password, byte[] salt)
    {
        byte[] passwordBytes = mbSecureString.SecureStringToByteArray(password);
        byte[] hash = null;

        try
        {
            var argon2 = new Argon2id(passwordBytes)
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 24
            };

            hash = argon2.GetBytes(32);
            return Convert.ToBase64String(hash);
        }
        finally
        {
            ClearByteArray(passwordBytes);
            ClearByteArray(hash);
        }
    }
    public static bool VerifyPassword(SecureString enteredPassword, string storedHash, byte[] salt)
    {
        string hashOfEntered = HashPassword(enteredPassword, salt);
        byte[] enteredHashBytes = Convert.FromBase64String(hashOfEntered);
        byte[] storedHashBytes = Convert.FromBase64String(storedHash);

        return SlowEquals(enteredHashBytes, storedHashBytes);
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
            string jsonData = mbEncryption.DecryptStringFromBytes(encryptedData, oldPassword);

            // Re-encrypt data with new password
            byte[] newEncryptedData = mbEncryption.EncryptStringToBytes(jsonData, newPassword);
            File.WriteAllBytes(dataFilePath, newEncryptedData);

            return true;
        }
        catch (CryptographicException)
        {
            errorMessage = "The old password is incorrect.";
            return false;
        }
        catch (Exception ex)
        {
            #if DEBUG
            errorMessage = $"An unexpected error occurred while updating the password. {ex}";
            #else
            errorMessage = "An unexpected error occurred while updating the password.";
            #endif
            return false;
        }
    }
}
