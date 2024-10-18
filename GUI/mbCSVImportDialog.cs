/* 
    
    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbCSVImportDialog : Form
    {
        public Dictionary<string, string> ColumnMappings { get; private set; }

        private List<string> _csvColumns;

        public mbCSVImportDialog(List<string> csvColumns)
        {
            InitializeComponent();
            _csvColumns = csvColumns;
            ColumnMappings = new Dictionary<string, string>();

            InitializeMappingControls();
        }

        private void InitializeMappingControls()
        {
            // Define mbPSWD properties to map
            var pswdProperties = new List<string>
            {
                "pswdName",
                "pswdAddress",
                "pswdCategory",
                "pswdLogin",
                "pswdPass",
                "pswdEmail",
                "pswdAdditionalInfo"
                // Add more properties if needed
            };

            int startY = 20;
            int labelX = 20;
            int comboBoxX = 150;
            int controlHeight = 25;
            int spacingY = 35;

            foreach (var property in pswdProperties)
            {
                // Create Label
                Label lbl = new Label
                {
                    Text = property,
                    Left = labelX,
                    Top = startY,
                    Width = 120
                };
                this.Controls.Add(lbl);

                // Create ComboBox
                ComboBox cmb = new ComboBox
                {
                    Left = comboBoxX,
                    Top = startY - 3,
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmb.Items.AddRange(_csvColumns.ToArray());

                // Optional: Set default selection if possible
                foreach (var column in _csvColumns)
                {
                    if (string.Equals(column, property.Replace("pswd", ""), StringComparison.OrdinalIgnoreCase))
                    {
                        cmb.SelectedItem = column;
                        break;
                    }
                }

                this.Controls.Add(cmb);

                // Store the ComboBox with Tag as the property name
                cmb.Tag = property;

                startY += spacingY;
            }

            // Add Buttons
            Button btnOK = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Left = 150,
                Width = 80,
                Top = startY + 10
            };
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            Button btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Left = 240,
                Width = 80,
                Top = startY + 10
            };
            this.Controls.Add(btnCancel);

            // Set dialog properties
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Height = startY + 70;
            this.Width = 400;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Map CSV Columns";
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Collect mappings
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox cmb && cmb.Tag is string property)
                {
                    if (cmb.SelectedItem != null)
                    {
                        ColumnMappings[property] = cmb.SelectedItem.ToString();
                    }
                }
            }

            // Validate that all required properties have a mapping
            var requiredProperties = new List<string>
            {
                "pswdName",
                "pswdLogin",
                "pswdPass"
                // Add other required properties as needed
            };

            foreach (var prop in requiredProperties)
            {
                if (!ColumnMappings.ContainsKey(prop) || string.IsNullOrWhiteSpace(ColumnMappings[prop]))
                {
                    MessageBox.Show($"Please map the '{prop}' property to a CSV column.", "Mapping Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None; // Prevent dialog from closing
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
