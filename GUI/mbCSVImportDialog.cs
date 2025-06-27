
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

    mbCSVImportDialog.cs

*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public partial class mbCSVImportDialog : MaterialForm
    {
        public Dictionary<string, string> ColumnMappings { get; private set; }
        public string SelectedDelimiter { get; private set; }

        private string _filePath;

        public mbCSVImportDialog(string filePath)
        {
            InitializeComponent();

            this.CenterToParent();
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            _filePath = filePath;
            ColumnMappings = new Dictionary<string, string>();

            SelectedDelimiter = ",";        // def
            cmbDelimiter.SelectedIndex = 0; // def

            InitializeMappingControls();
        }
        private void InitializeMappingControls()
        {
            List<string> csvColumns = GetCsvHeaders(SelectedDelimiter);

            var pswdProperties = new List<string>
            {
                "pswdName",
                "pswdAddress",
                "pswdCategory",
                "pswdLogin",
                "pswdPass",
                "pswdEmail",
                "pswdAdditionalInfo"
            };

            // remove existing to prevent duplicates
            RemoveExistingMappingControls(pswdProperties);

            int defSpacing = 50;
            int startY = defSpacing * 2 ;
            int labelX = defSpacing / 3;
            int comboBoxX = defSpacing * 3;

            foreach (var property in pswdProperties)
            {
                string labelText = property.StartsWith("pswd") ? property.Substring(4) : property;

                MaterialLabel lbl = new MaterialLabel
                {
                    Text = labelText,
                    Left = labelX,
                    Top = startY,
                    Width = 120,
                    Tag = property
                };
                this.Controls.Add(lbl);

                MaterialComboBox cmb = new MaterialComboBox
                {
                    Left = comboBoxX,
                    Top = startY - 12,
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmb.Items.AddRange(csvColumns.ToArray());

                // ---

                // set default selection if possible
                foreach (var column in csvColumns)
                {
                    if (string.Equals(column, property.Replace("pswd", ""), StringComparison.OrdinalIgnoreCase))
                    {
                        cmb.SelectedItem = column;
                        break;
                    }
                }

                this.Controls.Add(cmb);

                cmb.Tag = property;
                startY += defSpacing;
            }

            this.Height = startY + (4 * defSpacing);
            this.Width = (8 * defSpacing) + (defSpacing / 2);
        }
        private void RemoveExistingMappingControls(List<string> pswdProperties)
        {
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
                    BadDataFound = null,            // ignore bad data
                    Quote = '▪',
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
                MaterialMessageBox.Show($"Error reading CSV headers: {ex.Message}", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }
        private void RebuildMappingControls(string delimiter)
        {
            SelectedDelimiter = delimiter;              // Update the SelectedDelimiter
            InitializeMappingControls();                // Re-initialize mapping controls with the new delimiter
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
                    MaterialMessageBox.Show("Please enter a custom delimiter or select a predefined one.", "Delimiter Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (SelectedDelimiter.Length != 1)
                {
                    DialogResult dlgResult = MaterialMessageBox.Show("Delimiters longer than one character may lead to unexpected results. Do you want to proceed?", "Delimiter Length Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                if (control is MaterialComboBox cmb && cmb.Tag is string property)
                {
                    if (cmb.SelectedItem != null)
                    {
                        ColumnMappings[property] = cmb.SelectedItem.ToString();
                    }
                }
            }

            // Vrequired properties should have mappings
            var requiredProperties = new List<string>
            {
                "pswdName",
                "pswdLogin",
                "pswdPass"
            };

            foreach (var prop in requiredProperties)
            {
                if (!ColumnMappings.ContainsKey(prop) || string.IsNullOrWhiteSpace(ColumnMappings[prop]))
                {
                    MaterialMessageBox.Show($"Please map the '{prop}' property to a CSV column.", "Mapping Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None; // Prevent dialog from closing
                    return;
                }
            }

            // Validate and capture the delimiter
            if (string.IsNullOrEmpty(SelectedDelimiter))
            {
                MaterialMessageBox.Show("Please specify a delimiter.", "Delimiter Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
