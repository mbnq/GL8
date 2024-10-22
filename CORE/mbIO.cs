
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        // ------------------- Data Handling ----------------------
        public void LoadPSWDData()
        {
            if (File.Exists(mbFilePath))
            {
                try
                {
                    byte[] encryptedData = File.ReadAllBytes(mbFilePath);
                    string jsonData = mbEncryption.DecryptStringFromBytes(encryptedData, _userPassword);
                    mbPSWDList = JsonConvert.DeserializeObject<BindingList<mbPSWD>>(jsonData);
                }
                catch (Exception ex)
                {
                    MaterialMessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mbPSWDList = new BindingList<mbPSWD>();
                }
            }
            else
            {
                mbPSWDList = new BindingList<mbPSWD>();
            }

            mbDataView.DataSource = mbPSWDList;

            if (mbDataView.Columns.Contains("pswdCreateTime"))
                mbDataView.Columns["pswdCreateTime"].HeaderText = "Creation Date";

            if (mbDataView.Columns.Contains("pswdLastEditTime"))
                mbDataView.Columns["pswdLastEditTime"].HeaderText = "Modify Date";

            this.Refresh();
        }
        public void CreateDataFileIfMissing()
        {
            if (!File.Exists(mbFilePath))
            {
                var result = MaterialMessageBox.Show(
                    "Database not found. Do you want to create a new Database?",
                    "GL8 - Create Database",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SavePSWDData();
                }
                else
                {
                    // Application.Exit();
                    this.BeginInvoke(new MethodInvoker(delegate { this.Close(); }));
                }
            }
        }
        public void SavePSWDData()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(mbPSWDList);
                byte[] encryptedData = mbEncryption.EncryptStringToBytes(jsonData, _userPassword);
                File.WriteAllBytes(mbFilePath, encryptedData);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}