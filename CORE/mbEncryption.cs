
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.IO;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using System.Security;
using GL8.CORE;

public static class mbEncryption
{
    // Size of the salt (in bytes)
    private const int SaltSize = 16;

    // Size of the key and IV (in bytes)
    private const int KeySize = 32; // 256 bits for AES-256
    private const int IvSize = 16;  // 128 bits for AES block size

    public static byte[] EncryptStringToBytes(string plainText, SecureString password)
    {
        // Convert SecureString to byte array
        byte[] passwordBytes = mbSecureString.SecureStringToByteArray(password);

        try
        {
            // Generate a random salt
            byte[] salt = GenerateRandomBytes(SaltSize);

            // Derive key and IV from the password and salt using Argon2
            byte[] key, iv;
            DeriveKeyAndIV(passwordBytes, salt, out key, out iv);

            // Proceed with encryption as before
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                MemoryStream msEncrypt = new MemoryStream();
                msEncrypt.Write(salt, 0, salt.Length);

                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }

                return msEncrypt.ToArray();
            }
        }
        finally
        {
            // Zero out the passwordBytes array
            ClearByteArray(passwordBytes);
        }
    }
    public static string DecryptStringFromBytes(byte[] cipherText, SecureString password)
    {
        // Convert SecureString to byte array
        byte[] passwordBytes = mbSecureString.SecureStringToByteArray(password);

        try
        {
            MemoryStream msDecrypt = new MemoryStream(cipherText);
            byte[] salt = new byte[SaltSize];
            msDecrypt.Read(salt, 0, salt.Length);

            // Derive key and IV from the password and salt using Argon2
            byte[] key, iv;
            DeriveKeyAndIV(passwordBytes, salt, out key, out iv);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
        finally
        {
            // Zero out the passwordBytes array
            ClearByteArray(passwordBytes);
        }
    }
    private static void DeriveKeyAndIV(byte[] passwordBytes, byte[] salt, out byte[] key, out byte[] iv)
    {
        var argon2 = new Argon2id(passwordBytes)
        {
            Salt = salt,
            DegreeOfParallelism = 8,
            MemorySize = 65536,
            Iterations = 4
        };

        byte[] hash = argon2.GetBytes(KeySize + IvSize);

        key = new byte[KeySize];
        iv = new byte[IvSize];
        Array.Copy(hash, 0, key, 0, KeySize);
        Array.Copy(hash, KeySize, iv, 0, IvSize);
    }
    private static byte[] GenerateRandomBytes(int size)
    {
        byte[] bytes = new byte[size];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        return bytes;
    }
    private static void ClearByteArray(byte[] bytes)
    {
        if (bytes != null)
        {
            Array.Clear(bytes, 0, bytes.Length);
        }
    }
}
