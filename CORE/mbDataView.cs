
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        private void AddEventHandlers()
        {
            mbDataView.CellFormatting += mbDataView_CellFormatting;
            mbDataView.KeyDown += mbDataView_KeyDown;
            mbDataView.CellMouseDown += mbDataView_CellMouseDown;
            mbDataView.RowPostPaint += mbDataView_RowPostPaint;
            mbDataView.CellDoubleClick += mbDataView_CellDoubleClick;
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
                    _ = mbClipboardCleaner.AutoClearAsync(10);
                }
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
        private void mbDataView_Sorted(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i < mbDataView.Rows.Count; i++)
            {
                mbDataView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        private void mbDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                mbButtonEdit_Click(sender, e);
            }
        }
    }
}