
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace GL8.CORE
{
    public static class mbSecureString
    {
        public static bool SSEqual(SecureString ss1, SecureString ss2)
        {
            if (ss1 == null || ss2 == null)
                return false;

            if (ss1.Length != ss2.Length)
                return false;

            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;
            try
            {
                // Convert the SecureStrings to BSTR pointers
                bstr1 = Marshal.SecureStringToBSTR(ss1);
                bstr2 = Marshal.SecureStringToBSTR(ss2);

                // Get the length of the strings in bytes (Unicode characters are 2 bytes)
                int length = ss1.Length * 2;

                // Compare byte by byte
                for (int i = 0; i < length; i++)
                {
                    byte byte1 = Marshal.ReadByte(bstr1, i);
                    byte byte2 = Marshal.ReadByte(bstr2, i);

                    if (byte1 != byte2)
                    {
                        return false;
                    }
                }
                return true;
            }
            finally
            {
                // Zero and free the unmanaged memory
                if (bstr1 != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr1);

                if (bstr2 != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr2);
            }
        }
        public static string ToUnsecureString(SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException(nameof(secureString));

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }


    }
}
