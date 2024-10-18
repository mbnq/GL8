/* 
    
    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace GL8.CORE
{
    public class mbCSVImporter
    {
        private mbMainMenu _mainMenuInstance;

        public mbCSVImporter(mbMainMenu mainMenuInstance)
        {
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));
        }

        public void ImportCsv()
        {
            // Step 3: Prompt user to select CSV file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select CSV File",
                Filter = "CSV files (*.csv)|*.csv",
                Multiselect = false
            };

            DialogResult result = openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                MessageBox.Show("No file selected. Import operation canceled.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filePath = openFileDialog.FileName;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Selected file does not exist. Import operation canceled.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 5: Ask user to map CSV columns to mbPSWD fields
            List<string> csvHeaders = GetCsvHeaders(filePath);

            if (csvHeaders == null || csvHeaders.Count == 0)
            {
                MessageBox.Show("Unable to read CSV headers. Please ensure the file is correctly formatted.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mbCSVImportDialog mappingDialog = new mbCSVImportDialog(csvHeaders);
            DialogResult mappingResult = mappingDialog.ShowDialog();

            if (mappingResult != DialogResult.OK)
            {
                MessageBox.Show("Column mapping was canceled. Import operation canceled.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> columnMappings = mappingDialog.ColumnMappings;

            // Step 6: Import and validate data
            List<mbPSWD> importedPswdList = ImportData(filePath, columnMappings);

            if (importedPswdList == null || importedPswdList.Count == 0)
            {
                MessageBox.Show("No valid data found to import.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add imported entries to the BindingList
            foreach (var pswd in importedPswdList)
            {
                _mainMenuInstance.mbPSWDList.Add(pswd);
            }

            // Step 7: Refresh and ask to save
            _mainMenuInstance.mbDataView.Refresh();

            DialogResult saveResult = MessageBox.Show("CSV data imported successfully. Do you want to save changes?", "Import CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (saveResult == DialogResult.Yes)
            {
                _mainMenuInstance.SavePSWDData();
                MessageBox.Show("Changes saved successfully.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Step 8: Finish
            MessageBox.Show("CSV import operation completed.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<string> GetCsvHeaders(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    return csv.HeaderRecord.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV headers: {ex.Message}", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private List<mbPSWD> ImportData(string filePath, Dictionary<string, string> columnMappings)
        {
            List<mbPSWD> pswdList = new List<mbPSWD>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        MissingFieldFound = null, // Ignore missing fields
                        HeaderValidated = null,
                        IgnoreBlankLines = true,
                        TrimOptions = TrimOptions.Trim
                    };

                    using (var csvReader = new CsvReader(reader, config))
                    {
                        // Read the header
                        csvReader.Read();
                        csvReader.ReadHeader();

                        while (csvReader.Read())
                        {
                            mbPSWD pswd = new mbPSWD();

                            foreach (var mapping in columnMappings)
                            {
                                string pswdProperty = mapping.Key;
                                string csvColumn = mapping.Value;

                                string value = csvReader.GetField(csvColumn);

                                switch (pswdProperty)
                                {
                                    case "pswdName":
                                        pswd.pswdName = value;
                                        break;
                                    case "pswdAddress":
                                        pswd.pswdAddress = value;
                                        break;
                                    case "pswdCategory":
                                        pswd.pswdCategory = value;
                                        break;
                                    case "pswdLogin":
                                        pswd.pswdLogin = value;
                                        break;
                                    case "pswdPass":
                                        pswd.pswdPass = value;
                                        break;
                                    case "pswdEmail":
                                        pswd.pswdEmail = value;
                                        break;
                                    case "pswdAdditionalInfo":
                                        pswd.pswdAdditionalInfo = value;
                                        break;
                                    // Add more cases if mbPSWD has more properties
                                    default:
                                        // Optionally handle unexpected mappings
                                        break;
                                }
                            }

                            // Assign timestamps
                            pswd.pswdCreateTime = DateTime.Now;
                            pswd.pswdLastEditTime = DateTime.Now;

                            // Optional: Validate the pswd object before adding
                            if (ValidatePswd(pswd))
                            {
                                pswdList.Add(pswd);
                            }
                        }
                    }
                }

                return pswdList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing CSV data: {ex.Message}", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool ValidatePswd(mbPSWD pswd)
        {
            // Implement validation logic as needed
            // For example, ensure required fields are not empty
            if (string.IsNullOrWhiteSpace(pswd.pswdName) ||
                string.IsNullOrWhiteSpace(pswd.pswdLogin) ||
                string.IsNullOrWhiteSpace(pswd.pswdPass))
            {
                // Invalid entry
                return false;
            }

            // Additional validation rules can be added here

            return true;
        }
    }
}
