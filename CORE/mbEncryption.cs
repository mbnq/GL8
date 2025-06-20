
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

    https://github.com/kmaragon/Konscious.Security.Cryptography
*/

using GL8.CORE;
using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;

public static class mbEncryption
{
    // Size of the salt (in bytes)
    private const int SaltSize = 32;

    // Size of the key and IV (in bytes)
    private const int KeySize = 32;  // 256 bits for AES-256
    private const int IvSize = 16;   // 128 bits for AES block size

    public static byte[] EncryptStringToBytes(string plainText, SecureString password)
    {
        byte[] passwordBytes = mbSecureString.SecureStringToByteArray(password);
        byte[] key = null;
        byte[] nonce = null;
        byte[] cipherBytes = null;

        try
        {
            byte[] salt = GenerateRandomBytes(SaltSize);
            key = DeriveKey(passwordBytes, salt);
            nonce = GenerateRandomBytes(12);

            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            GcmBlockCipher gcm = new GcmBlockCipher(new AesEngine());
            AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, nonce, null);
            gcm.Init(true, parameters);

            cipherBytes = new byte[gcm.GetOutputSize(plainBytes.Length)];
            int len = gcm.ProcessBytes(plainBytes, 0, plainBytes.Length, cipherBytes, 0);
            gcm.DoFinal(cipherBytes, len);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                msEncrypt.Write(salt, 0, salt.Length);
                msEncrypt.Write(nonce, 0, nonce.Length);
                msEncrypt.Write(cipherBytes, 0, cipherBytes.Length);
                return msEncrypt.ToArray();
            }
        }
        finally
        {
            ClearByteArray(passwordBytes);
            ClearByteArray(key);
            ClearByteArray(nonce);
            ClearByteArray(cipherBytes);
        }
    }
    public static string DecryptStringFromBytes(byte[] cipherText, SecureString password)
    {
        byte[] passwordBytes = mbSecureString.SecureStringToByteArray(password);
        byte[] key = null;
        byte[] nonce = new byte[12];

        try
        {
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                byte[] salt = new byte[SaltSize];
                msDecrypt.Read(salt, 0, salt.Length);
                msDecrypt.Read(nonce, 0, nonce.Length);

                key = DeriveKey(passwordBytes, salt);

                byte[] cipherBytes = new byte[msDecrypt.Length - msDecrypt.Position];
                msDecrypt.Read(cipherBytes, 0, cipherBytes.Length);

                GcmBlockCipher gcm = new GcmBlockCipher(new AesEngine());
                AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, nonce, null);
                gcm.Init(false, parameters);

                byte[] plainBytes = new byte[gcm.GetOutputSize(cipherBytes.Length)];
                int len = gcm.ProcessBytes(cipherBytes, 0, cipherBytes.Length, plainBytes, 0);
                gcm.DoFinal(plainBytes, len);

                return System.Text.Encoding.UTF8.GetString(plainBytes).TrimEnd('\0');
            }
        }
        catch (InvalidCipherTextException)
        {
            // Handle authentication failure
            throw new CryptographicException("Decryption failed due to invalid ciphertext or authentication failure.");
        }
        finally
        {
            ClearByteArray(passwordBytes);
            ClearByteArray(key);
            ClearByteArray(nonce);
        }
    }
    private static byte[] DeriveKey(byte[] passwordBytes, byte[] salt)
    {
        var argon2 = new Argon2id(passwordBytes)
        {
            Salt = salt,
            DegreeOfParallelism = 4,
            MemorySize = 131072,
            Iterations = 24
        };

        return argon2.GetBytes(KeySize);
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
