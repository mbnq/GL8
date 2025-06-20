
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using CsvHelper.Configuration;
using CsvHelper;
using MaterialSkin.Controls;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System;

namespace GL8.CORE
{
    public partial class mbDialogSettings : MaterialForm
    {
        public void mbCSVExport(mbMainMenu _mainMenuInstance) 
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Export to CSV";
                saveFileDialog.FileName = "Export.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string delimiter = ";";

                    try
                    {
                        using (var writer = new StreamWriter(saveFileDialog.FileName))
                        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            Delimiter = delimiter,
                            Mode = CsvMode.NoEscape,
                            IgnoreBlankLines = true,
                            TrimOptions = TrimOptions.Trim
                        }))
                        {
                            // write header
                            csv.WriteHeader<mbPSWD>();
                            csv.NextRecord();

                            // write records
                            foreach (var record in _mainMenuInstance.mbPSWDList)
                            {
                                csv.WriteRecord(record);
                                csv.NextRecord();
                            }
                        }

                        MaterialMessageBox.Show("Data exported successfully!", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show($"Error exporting data: {ex.Message}", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}