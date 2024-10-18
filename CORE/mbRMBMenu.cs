using System;
using System.Windows.Forms;

namespace GL8.CORE
{
    public class mbRMBMenu
    {
        public ContextMenuStrip mbContextMenu;

        public mbRMBMenu(DataGridView mbDataView)
        {
            // Create ContextMenuStrip
            mbContextMenu = new ContextMenuStrip();

            // Create menu items
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copy to Clipboard");
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Edit");

            // Add menu items to the context menu
            mbContextMenu.Items.Add(copyMenuItem);
            mbContextMenu.Items.Add(editMenuItem);

            // Assign event handlers
            copyMenuItem.Click += (sender, e) => CopyMenuItem_Click(mbDataView);
            editMenuItem.Click += (sender, e) => EditMenuItem_Click(mbDataView);

            // Assign the ContextMenuStrip to the DataGridView
            mbDataView.ContextMenuStrip = mbContextMenu;
        }

        // Event handler for "Copy to Clipboard"
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

        // Event handler for "Edit"
        private void EditMenuItem_Click(DataGridView mbDataView)
        {
            mbMainMenu mainMenu = (mbMainMenu)mbDataView.FindForm(); // Get reference to the main form
            mainMenu.mbButtonEdit_Click(mbDataView, EventArgs.Empty); // Call existing edit method
        }
    }
}
