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

        public static BindingList<mbPSWD> mbPSWDList = new BindingList<mbPSWD>();
        private mbDialogAddNew _DialogAddNew;
        private string mbFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "mbData.json";

        public mbMainMenu()
        {
            InitializeComponent();

            if (File.Exists(mbFilePath) == false) File.Create(mbFilePath).Dispose();

            var json = File.ReadAllText(mbFilePath);
            mbPSWDList = JsonConvert.DeserializeObject<BindingList<mbPSWD>>(json);
            mbDataView.DataSource = mbPSWDList;
        }

        private void mbButtonNewItem_Click(object sender, EventArgs e)
        {
            _DialogAddNew = new mbDialogAddNew();
            _DialogAddNew.ShowDialog();
        }

        private void mbButtonDebug_Click(object sender, EventArgs e)
        {
            var json = JsonConvert.SerializeObject(mbPSWDList);
            File.WriteAllText(mbFilePath, JsonConvert.SerializeObject(mbPSWDList));
        }
    }
}
