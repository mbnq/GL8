
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
using System.Security;

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
                    string jsonData = mbEncryptionUtility.DecryptStringFromBytes(encryptedData, _userPassword);
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
                SavePSWDData();
            }
        }
        public void SavePSWDData()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(mbPSWDList);
                byte[] encryptedData = mbEncryptionUtility.EncryptStringToBytes(jsonData, _userPassword);
                File.WriteAllBytes(mbFilePath, encryptedData);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}