using Konscious.Security.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

public class mbPasswordManager
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
    public static string HashPassword(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            DegreeOfParallelism = 8,  // Number of threads to use
            MemorySize = 65536,       // Memory usage in KB (64MB)
            Iterations = 4            // Number of iterations
        };

        byte[] hash = argon2.GetBytes(32);  // Hash length (e.g., 32 bytes)
        return Convert.ToBase64String(hash);
    }

    // Method to verify a password against a stored hash and salt
    public static bool VerifyPassword(string enteredPassword, string storedHash, byte[] salt)
    {
        string hashOfEntered = HashPassword(enteredPassword, salt);
        // Use constant-time comparison to prevent timing attacks
        return SlowEquals(Convert.FromBase64String(hashOfEntered), Convert.FromBase64String(storedHash));
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
            diff |= (uint)(a[i] ^ b[i]);
        return diff == 0;
    }
}
