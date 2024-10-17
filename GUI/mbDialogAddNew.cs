using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GL8.GUI
{
    public partial class mbDialogAddNew : MaterialForm
    {
        public mbDialogAddNew()
        {
            InitializeComponent();
        }

        private void mbButtonAddCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
