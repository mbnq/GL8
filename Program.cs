
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using GL8.CORE;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using System.Security.Principal;
using MaterialSkin.Controls;
using System.Diagnostics;

namespace GL8
{
    internal static class Program
    {
        public const string mbVersion = "0.0.2.3";

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
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        [STAThread]
        static void Main()
        {
            if (!gl8Mutex.WaitOne(TimeSpan.Zero, true))
            {
                MaterialMessageBox.Show("Another instance of the application is already running.", "GL8", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return;
            }

#if !DEBUG
            if (!IsAdministrator())
            {
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
                    MaterialMessageBox.Show("This application requires administrator privileges to run.", "GL8");
                }
                Application.Exit();
                return;
            }
#endif

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
