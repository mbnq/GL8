using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

public static class EncryptionUtility
{
    // Size of the salt (in bytes)
    private const int SaltSize = 16;

    // Size of the key and IV (in bytes)
    private const int KeySize = 32; // 256 bits for AES-256
    private const int IvSize = 16;  // 128 bits for AES block size

    public static byte[] EncryptStringToBytes(string plainText, string password)
    {
        // Generate a random salt
        byte[] salt = GenerateRandomBytes(SaltSize);

        // Derive key and IV from the password and salt using Argon2
        byte[] key, iv;
        DeriveKeyAndIV(password, salt, out key, out iv);

        // Create an AES cipher
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Create an encryptor
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            MemoryStream msEncrypt = new MemoryStream();
            // Write the salt to the beginning of the stream
            msEncrypt.Write(salt, 0, salt.Length);

            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                // Write the plaintext to the stream
                swEncrypt.Write(plainText);
            }

            return msEncrypt.ToArray();
        }
    }

    public static string DecryptStringFromBytes(byte[] cipherText, string password)
    {
        MemoryStream msDecrypt = new MemoryStream(cipherText);
        // Read the salt from the beginning of the stream
        byte[] salt = new byte[SaltSize];
        msDecrypt.Read(salt, 0, salt.Length);

        // Derive key and IV from the password and salt using Argon2
        byte[] key, iv;
        DeriveKeyAndIV(password, salt, out key, out iv);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Create a decryptor
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                // Read the decrypted bytes from the decrypting stream
                return srDecrypt.ReadToEnd();
            }
        }
    }

    private static void DeriveKeyAndIV(string password, byte[] salt, out byte[] key, out byte[] iv)
    {
        // Convert the password to bytes
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        // Configure Argon2 parameters
        var argon2 = new Argon2id(passwordBytes)
        {
            Salt = salt,
            DegreeOfParallelism = 8, // Number of threads to use
            MemorySize = 65536,      // Memory size in KB (64 MB)
            Iterations = 4           // Number of iterations
        };

        // Get bytes for key and IV
        byte[] hash = argon2.GetBytes(KeySize + IvSize);

        // Split the hash into key and IV
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
}
