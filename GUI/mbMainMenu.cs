using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GL8.GUI;
using MaterialSkin;
using MaterialSkin.Controls;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        internal class mbPSWD
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

        private BindingList<mbPSWD> _mbPSWD = new BindingList<mbPSWD>();
        private mbDialogAddNew _DialogAddNew;

        public mbMainMenu()
        {
            InitializeComponent();
            mbDataView.DataSource = _mbPSWD;
        }

        private void mbButtonNewItem_Click(object sender, EventArgs e)
        {
            _DialogAddNew = new mbDialogAddNew();
            _DialogAddNew.ShowDialog();
        }
    }
}
