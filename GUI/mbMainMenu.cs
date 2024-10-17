
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        public class mbPSWD
        {
            public string pswdName { get; set; }
            public string pswdAddress { get; set; }
            public string pswdCategory { get; set; }
            public string pswdLogin { get; set; }
            public string pswdPass { get; set; }
            public string pswdEmail { get; set; }
            public string pswdAdditionalInfo { get; set; }
            public DateTime pswdCreateTime { get; set; }
            public DateTime pswdLastEditTime { get; set; }
        }

        public BindingList<mbPSWD> mbPSWDList = new BindingList<mbPSWD>();
        private mbDialogAddNew _DialogAddNew;
        private mbDialogEdit _DialogEdit;
        public static string mbFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "mbData.json");
        private bool unsavedChanges = false;

        // ------------------- Main ----------------------
        public mbMainMenu()
        {
            InitializeComponent();

            if (mbPSWDList == null)
            {
                mbPSWDList = new BindingList<mbPSWD>();
            }

            CreateDataFileIfMissing();

            LoadPSWDData();

            mbDataView.CellValueChanged += mbDataView_CellValueChanged;
            mbDataView.RowValidated += mbDataView_RowValidated;
            this.FormClosing += mbMainMenu_FormClosing;
        }
        // ------------------- Main ----------------------



        // ------------------- GUI Controls ----------------------
        private void mbButtonNewItem_Click(object sender, EventArgs e)
        {
            _DialogAddNew = new mbDialogAddNew(this);
            _DialogAddNew.ShowDialog();
        }

        private void mbButtonEdit_Click(object sender, EventArgs e)
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

        private void mbButtonExit_Click(object sender, EventArgs e)
        {
            SavePSWDData();
            Application.Exit();
        }
        private void mbMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show(
                    "You have unsaved changes. Do you want to save them before exiting?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SavePSWDData();
                    unsavedChanges = false;
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
            unsavedChanges = true;
        }
        private void mbDataView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show(
                    "You have made changes to this row. Do you want to save them now?",
                    "Save Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SavePSWDData();
                    unsavedChanges = false;
                }
            }
        }
    }
}
