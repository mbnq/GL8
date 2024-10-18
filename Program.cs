using GL8.CORE;
using System;
using System.Windows.Forms;

namespace GL8
{
    internal static class Program
    {
        public static bool mbPassOK = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new mbDialogIntro());

            if (mbPassOK)
            {
                Application.Run(new mbMainMenu());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
