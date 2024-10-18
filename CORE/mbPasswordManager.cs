using Konscious.Security.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;
public class PasswordManager
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
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8;  // Number of threads to use (parallelism)
        argon2.MemorySize = 65536;       // Memory usage in KB (64MB)
        argon2.Iterations = 4;           // Number of iterations

        byte[] hash = argon2.GetBytes(16);  // Hash length (e.g., 16 bytes)
        return Convert.ToBase64String(hash);
    }

    // Method to verify a password against a stored hash and salt
    public static bool VerifyPassword(string enteredPassword, string storedHash, byte[] salt)
    {
        string hashOfEntered = HashPassword(enteredPassword, salt);
        return hashOfEntered == storedHash;
    }
}
