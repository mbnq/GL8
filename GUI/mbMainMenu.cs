using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        public class mbPSWD
        {
            public string pswdName { get; set; }
            public string pswdAddress { get; set; }
            public string pswdCategory { get; set; }
            public string pswdLogin { get; set; }
            public string pswdPass { get; set; }
            public string pswdEmail { get; set; }
            public string pswdAdditionalInfo { get; set; }
            public DateTime pswdCreateTime { get; set; }
            public DateTime pswdLastEditTime { get; set; }
        }

        public BindingList<mbPSWD> mbPSWDList = new BindingList<mbPSWD>();
        private mbDialogAddNew _DialogAddNew;
        public static string mbFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "mbData.json");

        public mbMainMenu()
        {
            InitializeComponent();

            if (mbPSWDList == null)
            {
                mbPSWDList = new BindingList<mbPSWD>();
            }

            CreateDataFileIfMissing();

            LoadPSWDData();
        }

        public void LoadPSWDData()
        {
            var json = File.ReadAllText(mbFilePath);
            mbPSWDList = JsonConvert.DeserializeObject<BindingList<mbPSWD>>(json);

            if (mbPSWDList == null)
            {
                mbPSWDList = new BindingList<mbPSWD>();
            }

            mbDataView.DataSource = mbPSWDList;
            this.Refresh();
        }

        private void CreateDataFileIfMissing()
        {
            if (!File.Exists(mbFilePath))
            {
                File.WriteAllText(mbFilePath, JsonConvert.SerializeObject(new BindingList<mbPSWD>()));
            }
        }

        private void mbButtonNewItem_Click(object sender, EventArgs e)
        {
            _DialogAddNew = new mbDialogAddNew(this);
            _DialogAddNew.ShowDialog();
        }
        private void mbButtonDebug_Click(object sender, EventArgs e)
        {
            SavePSWDData();
            LoadPSWDData();
        }
        public void SavePSWDData()
        {
            var json = JsonConvert.SerializeObject(mbPSWDList);
            File.WriteAllText(mbFilePath, JsonConvert.SerializeObject(mbPSWDList));
        }

        private void mbButtonExit_Click(object sender, EventArgs e)
        {
            SavePSWDData();
            Application.Exit();
        }

        private void mbButtonRemoveItem_Click(object sender, EventArgs e)
        {
            // 0.) Check if any row from mbDataView.DataSource is selected
            if (mbDataView.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show(
                    "Are you sure you want to delete the selected entry?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 2.) Delete selected row
                    // Get the selected row
                    DataGridViewRow selectedRow = mbDataView.SelectedRows[0];

                    // Get the bound data item
                    mbPSWD selectedPSWD = (mbPSWD)selectedRow.DataBoundItem;

                    // Remove it from the BindingList
                    mbPSWDList.Remove(selectedPSWD);

                    // Save the updated data to the file
                    SavePSWDData();

                    // Optionally refresh the DataGridView
                    mbDataView.Refresh();
                }
            }
            else
            {
                MessageBox.Show(
                    "Please select an item to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
