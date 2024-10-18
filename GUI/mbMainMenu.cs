
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        public bool mbHidePasswords = true;

        public BindingList<mbPSWD> mbPSWDList = new BindingList<mbPSWD>();
        public static string mbFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "mbData.dat");

        private mbDialogAddNew _DialogAddNew;
        private mbDialogEdit _DialogEdit;
        private mbDialogSettings _DialogSettings;
        private mbRMBMenu _mbRMBMenu;

        private SecureString _userPassword;
        private bool _unsavedChanges = false;

        // ------------------- Main ----------------------
        public mbMainMenu(SecureString userPassword)
        {
            InitializeComponent();
            _userPassword = userPassword;

            if (mbPSWDList == null)
            {
                MessageBox.Show("Was unable to find existing database. Creating new one.");
                mbPSWDList = new BindingList<mbPSWD>();
            }

            CreateDataFileIfMissing();

            LoadPSWDData();

            mbDataView.CellValueChanged     += mbDataView_CellValueChanged;
            mbDataView.RowValidated         += mbDataView_RowValidated;
            mbDataView.CellFormatting       += mbDataView_CellFormatting;
            mbDataView.KeyDown              += mbDataView_KeyDown;
            mbDataView.CellMouseDown        += mbDataView_CellMouseDown;
            this.FormClosing                += mbMainMenu_FormClosing;

            _mbRMBMenu = new mbRMBMenu(mbDataView);
        }
        // ------------------- Main ----------------------

        public void mbRefreshMainMenu()
        {
            this.Refresh();
            mbDataView.Refresh();
        }

        private void mbDataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((mbHidePasswords) && (mbDataView.Columns[e.ColumnIndex].Name == "pswdPass" && e.Value != null))
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        private void mbDataView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (mbDataView.CurrentCell != null && mbDataView.CurrentCell.ColumnIndex == mbDataView.Columns["pswdPass"].Index)
                {
                    var selectedRow = mbDataView.CurrentRow;
                    if (selectedRow != null)
                    {
                        mbPSWD selectedPSWD = (mbPSWD)selectedRow.DataBoundItem;
                        if (selectedPSWD != null)
                        {
                            Clipboard.SetText(selectedPSWD.pswdPass);
                        }

                        e.Handled = true;
                    }
                }
            }
        }

        // ------------------- Search ----------------------

        private void mbSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = mbSearchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // When the search box is empty, show all items
                mbDataView.DataSource = mbPSWDList;
            }
            else
            {
                // Filter the list based on the search text
                var filteredList = new BindingList<mbPSWD>(
                    mbPSWDList.Where(pswd =>
                        pswd.pswdName.ToLower().Contains(searchText) ||
                        pswd.pswdAddress.ToLower().Contains(searchText) ||
                        pswd.pswdCategory.ToLower().Contains(searchText) ||
                        pswd.pswdLogin.ToLower().Contains(searchText) ||
                        pswd.pswdEmail.ToLower().Contains(searchText) ||
                        pswd.pswdAdditionalInfo.ToLower().Contains(searchText))
                    .ToList()
                );

                mbDataView.DataSource = filteredList;
            }
            mbDataView.Refresh();
        }


        // ------------------- GUI Controls ----------------------
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
                MessageBox.Show(
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

                var result = MessageBox.Show(
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
                    mbDataView.Refresh();
                }
            }
            else
            {
                MessageBox.Show(
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
        private void mbMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_unsavedChanges)
            {
                var result = MessageBox.Show(
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
        }

        // ------------------- DataView ----------------------

        private void mbDataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _unsavedChanges = true;
        }
        private void mbDataView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_unsavedChanges)
            {
                var result = MessageBox.Show(
                    "You have made changes to this row. Do you want to save them now?",
                    "Save Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SavePSWDData();
                    _unsavedChanges = false;
                }
            }
        }

        private void mbDataView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // check if the click was inside a valid cell
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    mbDataView.CurrentCell = mbDataView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // select the entire row if preferred
                    mbDataView.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        public void UpdatePassword(SecureString oldPassword, SecureString newPassword)
        {
            try
            {
                // Load data with old password
                byte[] encryptedData = File.ReadAllBytes(mbFilePath);
                string jsonData = EncryptionUtility.DecryptStringFromBytes(encryptedData, oldPassword);

                // Re-encrypt data with new password
                byte[] newEncryptedData = EncryptionUtility.EncryptStringToBytes(jsonData, newPassword);
                File.WriteAllBytes(mbFilePath, newEncryptedData);

                // Update the stored password
                _userPassword = newPassword;

                MessageBox.Show("Data re-encrypted with new password successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data encryption: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
