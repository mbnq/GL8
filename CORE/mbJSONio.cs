
/* 

    www.mbnq.pl 2025 
    https://mbnq.pl/
    mbnq00 on gmail

    mbJSONio.cs

*/

using MaterialSkin.Controls;
using System.IO;
using System.Windows.Forms;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GL8.CORE
{
    public partial class mbDialogSettings : MaterialForm
    {
        public void mbJSONExport(mbMainMenu _mainMenuInstance)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Export to JSON";
                saveFileDialog.FileName = "Export.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DialogResult result = MaterialMessageBox.Show(
                            "The data includes sensitive information. Do you wish to proceed?",
                            "Export Warning",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            return;
                        }

                        string jsonString = JsonConvert.SerializeObject(
                            _mainMenuInstance.mbPSWDList,
                            Formatting.Indented);

                        File.WriteAllText(saveFileDialog.FileName, jsonString);

                        MaterialMessageBox.Show(
                            "Data exported successfully!",
                            "Export JSON",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show(
                            $"Error exporting data: {ex.Message}",
                            "Export JSON",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void mbJSONImport(mbMainMenu _mainMenuInstance)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Import from JSON";
                // openFileDialog.FileName = "Export.json";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonString = File.ReadAllText(openFileDialog.FileName);

                        List<mbPSWD> importedPswdList = JsonConvert.DeserializeObject<List<mbPSWD>>(jsonString);

                        if (importedPswdList != null && importedPswdList.Count > 0)
                        {
                            DialogResult result = MaterialMessageBox.Show(
                                "The data will be merged with your current database. Do you wish to proceed?",
                                "Import Warning",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                            {
                                return;
                            }

                            int duplicates = 0;

                            foreach (var pswd in importedPswdList)
                            {
                                // Check for duplicates
                                if (!_mainMenuInstance.mbPSWDList.Any(p => p.pswdName == pswd.pswdName && p.pswdLogin == pswd.pswdLogin))
                                {
                                    _mainMenuInstance.mbPSWDList.Add(pswd);
                                }
                                else
                                {
                                    duplicates++;
                                }
                            }

                            _mainMenuInstance.mbDataView.Refresh();

                            string message = "Data imported successfully!";
                            if (duplicates > 0)
                            {
                                message += $" {duplicates} duplicate(s) were skipped.";
                            }

                            MaterialMessageBox.Show(
                                message,
                                "Import JSON",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MaterialMessageBox.Show(
                                "No data found in the JSON file.",
                                "Import JSON",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {

                        MaterialMessageBox.Show(
                            $"Error importing data: {ex.Message}",
                            "Import JSON",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}