using GL8.CORE;
using System;
using System.Security;
using System.Windows.Forms;

namespace GL8
{
    internal static class Program
    {
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
