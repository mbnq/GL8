﻿
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
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
        private void mbDataView_RowPostPaint_old(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(mbDataView.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowNumber = (e.RowIndex + 1).ToString();

                float x = e.RowBounds.Location.X + 20;
                float y = e.RowBounds.Location.Y + 4;

                e.Graphics.DrawString(rowNumber, e.InheritedRowStyle.Font, brush, x, y);
            }
        }
        private void mbDataView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowNumber = (e.RowIndex + 1).ToString();

            // create a rectangle for the row header bounds
            Rectangle headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                mbDataView.RowHeadersWidth,
                e.RowBounds.Height);

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            e.Graphics.DrawString(
                rowNumber,
                e.InheritedRowStyle.Font,
                SystemBrushes.ControlText,
                headerBounds,
                centerFormat);
        }

    }
}