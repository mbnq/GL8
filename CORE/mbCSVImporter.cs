/* 
        
    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

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
    public class mbCSVImporter
    {
        private mbMainMenu _mainMenuInstance;

        public mbCSVImporter(mbMainMenu mainMenuInstance)
        {
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance), "Critical: Main menu instance cannot be null.");
        }

        public void ImportCsv()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select CSV File",
                Filter = "CSV files (*.csv)|*.csv",
                Multiselect = false
            };

            DialogResult result = openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                MaterialMessageBox.Show("No file selected. Import operation canceled.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filePath = openFileDialog.FileName;

            if (!File.Exists(filePath))
            {
                MaterialMessageBox.Show("Selected file does not exist. Import operation canceled.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mbCSVImportDialog mappingDialog = new mbCSVImportDialog(filePath);
            DialogResult mappingResult = mappingDialog.ShowDialog();

            if (mappingResult != DialogResult.OK)
            {
                MaterialMessageBox.Show("Import operation canceled.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> columnMappings = mappingDialog.ColumnMappings;
            string delimiter = mappingDialog.SelectedDelimiter;

            // import and validate data
            List<mbPSWD> importedPswdList = ImportData(filePath, columnMappings, delimiter);

            if (importedPswdList == null || importedPswdList.Count == 0)
            {
                MaterialMessageBox.Show("No valid data found to import.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // add entries to mbPSWDList
            foreach (var pswd in importedPswdList)
            {
                _mainMenuInstance.mbPSWDList.Add(pswd);
            }

            // refresh and ask to save
            _mainMenuInstance.mbDataView.Refresh();

            DialogResult saveResult = MaterialMessageBox.Show("CSV data imported successfully. Do you want to save changes now?", "Import CSV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (saveResult == DialogResult.Yes)
            {
                _mainMenuInstance.SavePSWDData();
                MaterialMessageBox.Show("Changes saved successfully. Please don't forget to check your passwords after import.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // MaterialMessageBox.Show("CSV import operation completed.", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MaterialMessageBox.Show($"Error reading CSV headers: {ex.Message}", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private List<mbPSWD> ImportData(string filePath, Dictionary<string, string> columnMappings, string delimiter)
        {
            List<mbPSWD> pswdList = new List<mbPSWD>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = delimiter,
                        MissingFieldFound = null,
                        HeaderValidated = null,
                        BadDataFound = null,  // Ignore bad data
                        Quote = '▪',          // Set the Quote character to '▪'
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
                                string pswdProperty = mapping.Key;   // Property name
                                string csvColumn = mapping.Value;    // CSV column name

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
                                    default:
                                        break;
                                }
                            }

                            pswd.pswdCreateTime = DateTime.Now;
                            pswd.pswdLastEditTime = DateTime.Now;

                            // Validate the pswd object before adding
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
                MaterialMessageBox.Show($"Error importing CSV data: {ex.Message}", "Import CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool ValidatePswd(mbPSWD pswd)
        {
            if (string.IsNullOrWhiteSpace(pswd.pswdName) ||
                string.IsNullOrWhiteSpace(pswd.pswdLogin) ||
                string.IsNullOrWhiteSpace(pswd.pswdPass))
            {
                // invalid entry
                return false;
            }

            return true;
        }
    }
}
