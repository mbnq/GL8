
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.ComponentModel;
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

        // ------------------- MaterialSkin setup ---------

        public static ColorScheme mbColorSchemeGrey = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        public static ColorScheme mbColorSchemeRed = new ColorScheme(Primary.Red800, Primary.Red900, Primary.Red500, Accent.Red200, TextShade.WHITE);
        public static ColorScheme mbColorSchemeGreen = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.LightGreen200, TextShade.WHITE);
        public static ColorScheme mbColorSchemeBlue = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
        public void InitializeMaterialSkin(ColorScheme _colorSchemeInput = null, string brightness = "LIGHT")
        {
            if (_colorSchemeInput == null) { _colorSchemeInput = mbColorSchemeGrey; }
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (brightness.ToUpper() == "DARK") { materialSkinManager.Theme = MaterialSkinManager.Themes.DARK; } 
               else{materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; }
            materialSkinManager.ColorScheme = _colorSchemeInput;
        }

        public ColorScheme mbActiveColorScheme = mbColorSchemeBlue;     // default color scheme
        public static int mbColorSchemeIndex;                           // default color scheme index

        // ------------------- Main -----------------------
        public mbMainMenu(SecureString userPassword)
        {
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

            mbDataView.CellValueChanged     += mbDataView_CellValueChanged;
            mbDataView.RowValidated         += mbDataView_RowValidated;
            mbDataView.CellFormatting       += mbDataView_CellFormatting;
            mbDataView.KeyDown              += mbDataView_KeyDown;
            mbDataView.CellMouseDown        += mbDataView_CellMouseDown;
            mbDataView.RowPostPaint         += mbDataView_RowPostPaint;
            mbDataView.DoubleClick          += (sender, e) => mbButtonEdit_Click(sender, e);
            this.FormClosing                += mbMainMenu_FormClosing;

            _mbRMBMenu = new mbRMBMenu(mbDataView);

            _DialogSettings = new mbDialogSettings(this);
            _DialogSettings.LoadPublicSettings(this);

            switch (mbColorSchemeIndex)
            {
                case 0:
                    mbActiveColorScheme = mbColorSchemeGrey;
                    break;
                case 1:
                    mbActiveColorScheme = mbColorSchemeRed;
                    break;
                case 2:
                    mbActiveColorScheme = mbColorSchemeGreen;
                    break;
                case 3:
                    mbActiveColorScheme = mbColorSchemeBlue;
                    break;
                default:
                    mbActiveColorScheme = mbColorSchemeBlue;
                    break;
            }

            InitializeMaterialSkin(mbActiveColorScheme);
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

        // ------------------- DataView -------------------
        private void mbDataView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _unsavedChanges = true;
        }
        private void mbDataView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (_unsavedChanges)
            {
                var result = MaterialMessageBox.Show(
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
        private void mbDataView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((mbHidePasswords) && (mbDataView.Columns[e.ColumnIndex].Name == "pswdPass" && e.Value != null))
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
        private void mbDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mbButtonEdit_Click(sender, e);
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
        private void mbDataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(mbDataView.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowNumber = (e.RowIndex + 1).ToString();

                float x = e.RowBounds.Location.X + 20;
                float y = e.RowBounds.Location.Y + 4;

                e.Graphics.DrawString(rowNumber, e.InheritedRowStyle.Font, brush, x, y);
            }
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
