
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using GL8.CORE;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;

namespace GL8
{
    internal static class Program
    {
        public const string mbVersion = "0.0.0.8";

        static Mutex gl8Mutex = new Mutex(true, "{GL8}");

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
            if (!gl8Mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Another instance of the application is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return;
            }

            /*
            if (!IsAdministrator())
            {
                // Restart the application with admin rights
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Verb = "runas"
                    };
                    Process.Start(proc);
                }
                catch
                {
                    // The user refused the elevation
                    MessageBox.Show("This application requires administrator privileges to run.");
                }
                Application.Exit();
                return;
            }

            private static bool IsAdministrator()
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mbDialogIntro introDialog = new mbDialogIntro();
            Application.Run(introDialog);

            if (mbPassOK)
            {
                Application.Run(new mbMainMenu(UserPassword));
                gl8Mutex.ReleaseMutex();
            }
            else
            {
                gl8Mutex.ReleaseMutex();
                Application.Exit();
            }
        }
    }
}
