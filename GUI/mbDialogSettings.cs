using GL8.CORE;
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

namespace GL8.CORE
{
    public partial class mbDialogSettings : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;
        public mbDialogSettings(mbMainMenu mainMenuInstance)
        {
            InitializeComponent();
            _mainMenuInstance = mainMenuInstance;
        }

        private void mbButtonSettingsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbSettingsCheckboxHidePswd_CheckedChanged(object sender, EventArgs e)
        {
            if (mbSettingsCheckboxHidePswd.Checked)
            {
                _mainMenuInstance.mbHidePasswords = true;
            }
            else
            {
                _mainMenuInstance.mbHidePasswords = false;
            }

            _mainMenuInstance.mbRefreshMainMenu();
        }
    }
}
