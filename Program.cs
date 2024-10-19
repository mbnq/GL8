
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using GL8.CORE;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

namespace GL8
{
    internal static class Program
    {
        public const string mbVersion = "0.0.0.4";

        #region DPI
        [DllImport("user32.dll")]
        static extern bool SetProcessDPIAware();

        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiFlag);
        private static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new IntPtr(-4);
        private static readonly IntPtr DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = new IntPtr(-2);
        #endregion

        public static bool mbPassOK = false;
        public static SecureString UserPassword { get; private set; }
        public static void SetUserPassword(SecureString password)
        {
            UserPassword = password;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mbDialogIntro introDialog = new mbDialogIntro();
            Application.Run(introDialog);

            if (mbPassOK)
            {
                Application.Run(new mbMainMenu(UserPassword));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
