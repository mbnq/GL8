using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace GL8.CORE
{
    public partial class mbCSVImportDialog : Form
    {
        public Dictionary<string, string> ColumnMappings { get; private set; }
        public string SelectedDelimiter { get; private set; }

        private string _filePath;

        public mbCSVImportDialog(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;
            ColumnMappings = new Dictionary<string, string>();
            SelectedDelimiter = ","; // Default delimiter

            cmbDelimiter.SelectedIndex = 0; // Set default selection to Comma

            InitializeMappingControls();
        }

        private void InitializeMappingControls()
        {
            // Read headers with the current delimiter
            List<string> csvColumns = GetCsvHeaders(SelectedDelimiter);

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

            // Remove existing mapping controls to prevent duplicates
            RemoveExistingMappingControls(pswdProperties);

            int startY = 70; // Start below the delimiter controls
            int labelX = 20;
            int comboBoxX = 150;
            int spacingY = 35;

            foreach (var property in pswdProperties)
            {
                // Create Label
                Label lbl = new Label
                {
                    Text = property,
                    Left = labelX,
                    Top = startY,
                    Width = 120,
                    Tag = property
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
                cmb.Items.AddRange(csvColumns.ToArray());

                // Optional: Set default selection if possible
                foreach (var column in csvColumns)
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

            // Adjust dialog size based on the number of controls
            this.Height = startY + 70;
            this.Width = 400;
        }

        private void RemoveExistingMappingControls(List<string> pswdProperties)
        {
            // Identify and remove existing Labels and ComboBoxes for mapping
            var controlsToRemove = this.Controls.OfType<Control>()
                .Where(c => (c is Label || c is ComboBox) && c.Tag is string tag && pswdProperties.Contains(tag))
                .ToList();

            foreach (var ctrl in controlsToRemove)
            {
                this.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }

        private List<string> GetCsvHeaders(string delimiter)
        {
            try
            {
                using (var reader = new StreamReader(_filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = delimiter,
                    HeaderValidated = null,
                    MissingFieldFound = null,
                    IgnoreBlankLines = true,
                    TrimOptions = TrimOptions.Trim
                }))
                {
                    csv.Read();
                    csv.ReadHeader();
                    return csv.HeaderRecord.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV headers: {ex.Message}", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

        private void RebuildMappingControls(string delimiter)
        {
            // Update the SelectedDelimiter
            SelectedDelimiter = delimiter;

            // Re-initialize mapping controls with the new delimiter
            InitializeMappingControls();
        }

        private void cmbDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbDelimiter.SelectedItem.ToString();

            switch (selected)
            {
                case "Comma (,)":
                    SelectedDelimiter = ",";
                    lblCustomDelimiter.Visible = false;
                    txtCustomDelimiter.Visible = false;
                    btnApplyCustomDelimiter.Visible = false;
                    RebuildMappingControls(SelectedDelimiter);
                    break;
                case "Semicolon (;)":
                    SelectedDelimiter = ";";
                    lblCustomDelimiter.Visible = false;
                    txtCustomDelimiter.Visible = false;
                    btnApplyCustomDelimiter.Visible = false;
                    RebuildMappingControls(SelectedDelimiter);
                    break;
                case "Tab (\\t)":
                    SelectedDelimiter = "\t";
                    lblCustomDelimiter.Visible = false;
                    txtCustomDelimiter.Visible = false;
                    btnApplyCustomDelimiter.Visible = false;
                    RebuildMappingControls(SelectedDelimiter);
                    break;
                case "Pipe (|)":
                    SelectedDelimiter = "|";
                    lblCustomDelimiter.Visible = false;
                    txtCustomDelimiter.Visible = false;
                    btnApplyCustomDelimiter.Visible = false;
                    RebuildMappingControls(SelectedDelimiter);
                    break;
                case "Space ( )":
                    SelectedDelimiter = " ";
                    lblCustomDelimiter.Visible = false;
                    txtCustomDelimiter.Visible = false;
                    btnApplyCustomDelimiter.Visible = false;
                    RebuildMappingControls(SelectedDelimiter);
                    break;
                case "Custom":
                    lblCustomDelimiter.Visible = true;
                    txtCustomDelimiter.Visible = true;
                    btnApplyCustomDelimiter.Visible = true;
                    break;
                default:
                    SelectedDelimiter = ",";
                    lblCustomDelimiter.Visible = false;
                    txtCustomDelimiter.Visible = false;
                    btnApplyCustomDelimiter.Visible = false;
                    RebuildMappingControls(SelectedDelimiter);
                    break;
            }
        }

        private void btnApplyCustomDelimiter_Click(object sender, EventArgs e)
        {
            if (cmbDelimiter.SelectedItem.ToString() == "Custom")
            {
                SelectedDelimiter = txtCustomDelimiter.Text;
                if (string.IsNullOrEmpty(SelectedDelimiter))
                {
                    MessageBox.Show("Please enter a custom delimiter or select a predefined one.", "Delimiter Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (SelectedDelimiter.Length != 1)
                {
                    DialogResult dlgResult = MessageBox.Show("Delimiters longer than one character may lead to unexpected results. Do you want to proceed?", "Delimiter Length Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlgResult == DialogResult.No)
                    {
                        return;
                    }
                }

                // Rebuild mapping controls with the custom delimiter
                RebuildMappingControls(SelectedDelimiter);
            }
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

            // Validate and capture the delimiter
            if (string.IsNullOrEmpty(SelectedDelimiter))
            {
                MessageBox.Show("Please specify a delimiter.", "Delimiter Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
