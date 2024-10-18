using System;
using System.Text;

namespace GL8.CORE
{
    internal class mbRND
    {
        // Characters to use in password generation
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()_+[]{}|;:,.<>?";

        // Method to generate random password
        public string GeneratePassword(int length = 8, bool includeUppercase = true, bool includeLowercase = true, bool includeNumbers = true, bool includeSpecialCharacters = true)
        {
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            string characterSet = "";

            if (includeUppercase)
                characterSet += UppercaseLetters;

            if (includeLowercase)
                characterSet += LowercaseLetters;

            if (includeNumbers)
                characterSet += Numbers;

            if (includeSpecialCharacters)
                characterSet += SpecialCharacters;

            if (string.IsNullOrEmpty(characterSet))
                throw new ArgumentException("At least one character set must be included.");

            for (int i = 0; i < length; i++)
            {
                password.Append(characterSet[random.Next(characterSet.Length)]);
            }

            return password.ToString();
        }
    }
}
