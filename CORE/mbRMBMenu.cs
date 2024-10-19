
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace GL8.CORE
{
    public class mbRMBMenu
    {
        public ContextMenuStrip mbContextMenu;

        public mbRMBMenu(DataGridView mbDataView)
        {
            mbContextMenu = new MaterialContextMenuStrip();

            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copy to Clipboard");
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("New");
            ToolStripSeparator separator = new ToolStripSeparator();

            mbContextMenu.Items.Add(copyMenuItem);
            mbContextMenu.Items.Add(separator);
            mbContextMenu.Items.Add(newMenuItem);
            mbContextMenu.Items.Add(editMenuItem);

            copyMenuItem.Click += (sender, e)   => CopyMenuItem_Click(mbDataView);
            editMenuItem.Click += (sender, e)   => EditMenuItem_Click(mbDataView);
            newMenuItem.Click += (sender, e)    => NewMenuItem_Click(mbDataView);

            // assign the ContextMenuStrip to the DataGridView
            mbDataView.ContextMenuStrip = mbContextMenu;
        }
        private void CopyMenuItem_Click(DataGridView mbDataView)
        {
            if (mbDataView.CurrentCell != null)
            {
                string cellValue = mbDataView.CurrentCell.Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue))
                {
                    Clipboard.SetText(cellValue);
                }
            }
        }
        private void EditMenuItem_Click(DataGridView mbDataView)
        {
            mbMainMenu mainMenu = (mbMainMenu)mbDataView.FindForm(); // Get reference to the main form
            mainMenu.mbButtonEdit_Click(mbDataView, EventArgs.Empty); // Call existing edit method
        }
        private void NewMenuItem_Click(DataGridView mbDataView)
        {
            mbMainMenu mainMenu = (mbMainMenu)mbDataView.FindForm();
            mainMenu.mbButtonNewItem_Click(mbDataView, EventArgs.Empty);
        }
    }
}
