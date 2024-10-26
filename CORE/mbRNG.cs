
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.Collections.Generic;

namespace GL8.CORE
{
    internal class mbRNG
    {
        private const string UppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Numbers = "0123456789";
        private const string SpecialCharacters = "!@#$%^&*()_+[]{}|;:,.<>?";

        public string mbGenerateRandomPassword
        (
            int length              = 8,
            bool includeUppercase   = true,
            bool includeLowercase   = true,
            bool includeNumbers     = true,
            bool includeSpecialCharacters = true
        )
        {
            if (length <= 0)
            {
                throw new ArgumentException("Password length must be greater than zero!");
            }

            Random random = new Random();
            string characterSet = "";

            // character set
            if (includeUppercase) characterSet          += UppercaseLetters;
            if (includeLowercase) characterSet          += LowercaseLetters;
            if (includeNumbers) characterSet            += Numbers;
            if (includeSpecialCharacters) characterSet  += SpecialCharacters;

            if (string.IsNullOrEmpty(characterSet)) throw new ArgumentException("At least one character set must be included!");

            List<char> passwordChars = new List<char>();

            // ensure at least one character from each selected character set
            if (includeUppercase) passwordChars.Add(UppercaseLetters[random.Next(UppercaseLetters.Length)]);
            if (includeLowercase) passwordChars.Add(LowercaseLetters[random.Next(LowercaseLetters.Length)]);
            if (includeNumbers) passwordChars.Add(Numbers[random.Next(Numbers.Length)]);
            if (includeSpecialCharacters) passwordChars.Add(SpecialCharacters[random.Next(SpecialCharacters.Length)]);

            int remainingLength = length - passwordChars.Count;

            for (int i = 0; i < remainingLength; i++) passwordChars.Add(characterSet[random.Next(characterSet.Length)]);

            // shuffle
            for (int i = passwordChars.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = passwordChars[i];
                passwordChars[i] = passwordChars[j];
                passwordChars[j] = temp;
            }

            return new string(passwordChars.ToArray());
        }
    }
}
