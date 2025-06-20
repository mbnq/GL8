
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        // ------------------- Variables ------------------

        public BindingList<mbPSWD> mbPSWDList       = new BindingList<mbPSWD>();
        public static string mbFilePath             = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mbData.dat");
        public static string mbFilePathSettings     = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mbUser.dat");

        public MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private static mbWaitPrompter _mbWaitDialogManager = new mbWaitPrompter();

        private mbDialogNew         _DialogAddNew;
        private mbDialogSettings    _DialogSettings;
        private mbRMBMenu           _mbRMBMenu;

        public static System.Windows.Forms.ToolTip toolTipGeneral = new System.Windows.Forms.ToolTip()
        {
            AutoPopDelay    = 5000,
            InitialDelay    = 1000,
            ReshowDelay     = 500,
            ShowAlways      = true
        };

        private SecureString            _userPassword;
        private readonly mbBackup       _backupManager;

        public bool                     mbHidePasswords       = true;
        public bool                     mbEnableSoundEffects = true;
        public static int               mbRunCount            = 0;
        public static int               mbClipboardClearIndex = 2;
        public static int               mbClipboardClearDelay = 30;
        public static int               mbAutoBackupIndex     = 1;
        public static int               mbAutoBackupFrequency = 20;

        // ------------------- Main -----------------------
        public mbMainMenu(SecureString userPassword)
        {
            Debug.WriteLine("Initializing...");

            InitializeComponent();
            InitializeTooltipsForControls();

            this.CenterToScreen();

            _userPassword = userPassword;

            this.Icon = Properties.Resources.gl8;

            if (mbPSWDList == null)
            {
                MaterialMessageBox.Show("Was unable to find existing database. Creating new one.");
                mbPSWDList = new BindingList<mbPSWD>();
            }

            CreateDataFileIfMissing();

            LoadPSWDData();

            AddEventHandlers();

            _mbRMBMenu = new mbRMBMenu(mbDataView);

            _DialogSettings = new mbDialogSettings(this);
            _DialogSettings.LoadPublicSettings(this);

            UpdateClipboardClearDelay();
            UpdateAutoBackupFrequency();
            mbSwitchColorScheme();

            this.FormClosing += mbMainMenu_FormClosing;

            mbRunCount++;

            _backupManager = new mbBackup(this);
            _backupManager.CheckAndGo();

            this.HelpButtonClicked += (sender, e) =>
            {
                var mbAboutDialog = new mbAbout();
                mbAboutDialog.ShowDialog();
            };

            mbKeySoundHandler.RegisterKeySoundHandler(this.Controls);
            Debug.WriteLine($"Init ok. SaveLoad number: {mbRunCount}");
        }

        // ------------------- Search ---------------------
        private void mbSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = mbSearchTextBox.Text;
            string filter = mbSearchFilter.SelectedItem?.ToString();  // Get selected filter from MaterialComboBox

            if (string.IsNullOrWhiteSpace(searchText))
            {
                mbDataView.DataSource = mbPSWDList;
            }
            else
            {
                string lowerSearchText = searchText.ToLower();

                var filteredList = new BindingList<mbPSWD>(
                    mbPSWDList.Where(pswd =>
                        (filter == "ALL" && (
                            (!string.IsNullOrEmpty(pswd.pswdName) && pswd.pswdName.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (!string.IsNullOrEmpty(pswd.pswdAddress) && pswd.pswdAddress.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (!string.IsNullOrEmpty(pswd.pswdCategory) && pswd.pswdCategory.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (!string.IsNullOrEmpty(pswd.pswdLogin) && pswd.pswdLogin.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (!string.IsNullOrEmpty(pswd.pswdEmail) && pswd.pswdEmail.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                            (!string.IsNullOrEmpty(pswd.pswdAdditionalInfo) && pswd.pswdAdditionalInfo.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0))) ||
                        (filter == "Name" && !string.IsNullOrEmpty(pswd.pswdName) && pswd.pswdName.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (filter == "Address" && !string.IsNullOrEmpty(pswd.pswdAddress) && pswd.pswdAddress.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (filter == "Category" && !string.IsNullOrEmpty(pswd.pswdCategory) && pswd.pswdCategory.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (filter == "Login" && !string.IsNullOrEmpty(pswd.pswdLogin) && pswd.pswdLogin.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (filter == "Email" && !string.IsNullOrEmpty(pswd.pswdEmail) && pswd.pswdEmail.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (filter == "Additional Info" && !string.IsNullOrEmpty(pswd.pswdAdditionalInfo) && pswd.pswdAdditionalInfo.IndexOf(lowerSearchText, StringComparison.OrdinalIgnoreCase) >= 0))
                    .ToList()
                );

                mbDataView.DataSource = filteredList;
            }
            mbDataView.Refresh();
        }
        private void mbSearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbSearchTextBox_TextChanged(this, EventArgs.Empty);
            mbDataView.Refresh();
        }

        // ------------------- GUI Controls ---------------
        private void InitializeTooltipsForControls()
        {
            toolTipGeneral.SetToolTip(this.mbButtonNewItem, "Add a new item to the list");
            toolTipGeneral.SetToolTip(this.mbButtonEdit, "Edit the selected item");
            toolTipGeneral.SetToolTip(this.mbButtonRemoveItem, "Remove the selected item");
            toolTipGeneral.SetToolTip(this.mbButtonOptions, "Open the options menu");
            toolTipGeneral.SetToolTip(this.mbButtonExit, "Close the application");
            toolTipGeneral.SetToolTip(this.mbSearchTextBox, "Search in items");
            toolTipGeneral.SetToolTip(this.mbSearchFilter, "Search filter");
        }
        public void mbSwitchEnableMainMenuControls(bool enable)
        {
            this.Enabled = enable;
        }
        public void mbButtonNewItem_Click(object sender, EventArgs e)
        {
            _DialogAddNew = new mbDialogNew(this);
            _DialogAddNew.ShowDialog();
        }
        public void mbButtonEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;

            if (mbDataView.SelectedRows.Count > 0)
            {
                selectedRow = mbDataView.SelectedRows[0];
            }
            else if (mbDataView.SelectedCells.Count > 0)
            {
                int rowIndex = mbDataView.SelectedCells[0].RowIndex;
                selectedRow = mbDataView.Rows[rowIndex];
            }

            if (selectedRow != null && (mbDataView.CurrentCell.ColumnIndex >= 0 && mbDataView.CurrentCell.RowIndex >= 0))   // not really needed
            {
                mbPSWD selectedPSWD = (mbPSWD)selectedRow.DataBoundItem;

                // Get the name of the currently selected column
                string selectedColumnName = mbDataView.Columns[mbDataView.CurrentCell.ColumnIndex].Name;

                // Pass the selected column name to the dialog
                mbDialogEdit editDialog = new mbDialogEdit(this, selectedPSWD, true);

                editDialog.ShowDialog();

                this.Refresh();
                // SavePSWDData(); // not needed here, as the dialog will save the data
            }
            else
            {
                MaterialMessageBox.Show(
                    "Please select a row or cell to edit.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void mbButtonRemoveItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = null;

            // Get the selected row either by selected row or selected cell
            if (mbDataView.SelectedRows.Count > 0)
            {
                selectedRow = mbDataView.SelectedRows[0];
            }
            else if (mbDataView.SelectedCells.Count > 0)
            {
                int rowIndex = mbDataView.SelectedCells[0].RowIndex;
                selectedRow = mbDataView.Rows[rowIndex];
            }

            if (selectedRow != null)
            {
                // Check the first cell's value in the selected row
                var firstCellValue = selectedRow.Cells[0].Value?.ToString();
                string displayValue = !string.IsNullOrWhiteSpace(firstCellValue) ? firstCellValue : "[Empty]";

                var result = MaterialMessageBox.Show(
                    $"Are you sure you want to delete the selected entry {displayValue}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Get the bound data item
                    mbPSWD selectedPSWD = (mbPSWD)selectedRow.DataBoundItem;

                    // Remove it from the BindingList
                    mbPSWDList.Remove(selectedPSWD);

                    // Save the updated data to the file

                    SavePSWDData();

                    if (!string.IsNullOrEmpty(mbSearchTextBox.Text)) mbSearchTextBox.Text = null;
                    mbDataView.Refresh();
                    this.Refresh();
                }
            }
            else
            {
                MaterialMessageBox.Show(
                    "Please select an item to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void mbButtonOptions_Click(object sender, EventArgs e)
        {
            _DialogSettings = new mbDialogSettings(this);
            _DialogSettings.ShowDialog();
        }
        private void mbButtonExit_Click(object sender, EventArgs e)
        {
            SavePSWDData();
            // Application.Exit();
            this.Close();
        }

        // ------------------- Other ----------------------
        public void mbRefreshMainMenu()
        {
            this.Refresh();
            mbDataView.Refresh();
        }
        private void mbMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePSWDData();
            _DialogSettings.SavePublicSettings(this);
        }
        public void UpdateUserPassword(SecureString newPassword)
        {
            _userPassword = newPassword;
        }
        public void UpdateClipboardClearDelay()
        {
            switch (mbMainMenu.mbClipboardClearIndex)
            {
                case 0:
                    mbMainMenu.mbClipboardClearDelay = 15;
                    break;
                case 1:
                    mbMainMenu.mbClipboardClearDelay = 30;
                    break;
                case 2:
                    mbMainMenu.mbClipboardClearDelay = 45;
                    break;
                case 3:
                default:
                    mbMainMenu.mbClipboardClearDelay = 60;
                    break;
            }
        }
        public void UpdateAutoBackupFrequency()
        {
            switch (mbMainMenu.mbAutoBackupIndex)
            {
                case 0:
                    mbMainMenu.mbAutoBackupFrequency = -1;
                    break;
                default:
                case 1:
                    mbMainMenu.mbAutoBackupFrequency = 20;
                    break;
                case 2:
                    mbMainMenu.mbAutoBackupFrequency = 50;
                    break;
                case 3:
                    mbMainMenu.mbAutoBackupFrequency = 100;
                    break;
            }
        }
    }
}
