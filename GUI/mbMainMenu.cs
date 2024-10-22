
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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

        private mbDialogAddNew      _DialogAddNew;
        private mbDialogEdit        _DialogEdit;
        private mbDialogSettings    _DialogSettings;
        private mbDialogSettings    _DialogSettingsDummy;
        private mbRMBMenu           _mbRMBMenu;

        private SecureString _userPassword;
        public bool mbHidePasswords     = true;
        private bool _unsavedChanges    = false;

        // ------------------- Main -----------------------
        public mbMainMenu(SecureString userPassword)
        {
            Debug.WriteLine("Initializing...");

            InitializeComponent();

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

            mbSwitchColorScheme();

            this.FormClosing += mbMainMenu_FormClosing;

            Debug.WriteLine("Init ok");
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
        public void mbButtonNewItem_Click(object sender, EventArgs e)
        {
            _DialogAddNew = new mbDialogAddNew(this);
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

            if (selectedRow != null)
            {
                mbPSWD selectedPSWD = (mbPSWD)selectedRow.DataBoundItem;

                // Get the name of the currently selected column
                string selectedColumnName = mbDataView.Columns[mbDataView.CurrentCell.ColumnIndex].Name;

                // Pass the selected column name to the dialog
                mbDialogEdit editDialog = new mbDialogEdit(this, selectedPSWD);

                editDialog.ShowDialog();

                this.Refresh();
                SavePSWDData();
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
            Application.Exit();
        }

        // ------------------- Other ----------------------
        public void mbRefreshMainMenu()
        {
            this.Refresh();
            mbDataView.Refresh();
        }
        private void mbMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_unsavedChanges)
            {
                var result = MaterialMessageBox.Show(
                    "You have unsaved changes. Do you want to save them before exiting?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SavePSWDData();
                    _unsavedChanges = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            _DialogSettings.SavePublicSettings(this);
        }
        public void UpdateUserPassword(SecureString newPassword)
        {
            _userPassword = newPassword;
        }
    }
}
