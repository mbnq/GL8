
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.IO;
using System.Diagnostics;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public class mbBackup
    {
        private readonly mbMainMenu _mainMenu;
        private const string BackupFolderName = "backup";

        // not really using instance of mbMainMenu atm, but let's leave it for future use
        public mbBackup(mbMainMenu mainMenu)    
        {
            _mainMenu = mainMenu ?? throw new ArgumentNullException(nameof(mainMenu));
        }

        public void CheckAndGo()
        {
            if (mbMainMenu.mbRunCount > 0 && mbMainMenu.mbRunCount % 20 == 0)
            {
                DoBackup();
            }
        }

        private void DoBackup()
        {
            try
            {
                string filePath = mbMainMenu.mbFilePath;
                string filePathSettings = mbMainMenu.mbFilePathSettings;

                if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(filePathSettings))
                {
                    Debug.WriteLine("One or both file paths are invalid.");
                    return;
                }

                bool fileExists = File.Exists(filePath);
                bool fileSettingsExists = File.Exists(filePathSettings);

                if (!fileExists || !fileSettingsExists)
                {
                    Debug.WriteLine("One or both files do not exist. Backup will not proceed.");
                    return;
                }

                string directory = Path.GetDirectoryName(filePath);
                if (string.IsNullOrEmpty(directory))
                {
                    Debug.WriteLine("Unable to determine the directory of the files.");
                    return;
                }

                string backupDirectory = Path.Combine(directory, BackupFolderName);
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                    Debug.WriteLine($"Backup directory created at: {backupDirectory}");
                }
                else
                {
                    Debug.WriteLine($"Backup directory already exists at: {backupDirectory}");
                }

                string backupFilePath = Path.Combine(backupDirectory, Path.GetFileName(filePath));
                string backupFilePathSettings = Path.Combine(backupDirectory, Path.GetFileName(filePathSettings));

                File.Copy(filePath, backupFilePath, overwrite: true);
                File.Copy(filePathSettings, backupFilePathSettings, overwrite: true);

                Debug.WriteLine($"Backup completed successfully at run count {mbMainMenu.mbRunCount}.");
                MaterialMessageBox.Show("Automated Backup completed successfully.\nCheck backup folder in program location.", "Backup", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred during backup: {ex.Message}");
            }
        }
    }
}

