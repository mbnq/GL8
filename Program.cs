using GL8.CORE;
using System;
using System.Windows.Forms;

namespace GL8
{
    internal static class Program
    {
        public static bool mbPassOK = false;
        public static string UserPassword { get; private set; }

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

        // Method to set the user's password (called from mbDialogIntro)
        public static void SetUserPassword(string password)
        {
            UserPassword = password;
        }
    }
}
