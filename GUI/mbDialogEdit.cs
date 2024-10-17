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
using static GL8.CORE.mbMainMenu;

namespace GL8.CORE
{
    public partial class mbDialogEdit : MaterialForm
    {
        private mbPSWD _pswdItem;
        private mbMainMenu _mainMenuInstance;
        public mbDialogEdit(mbMainMenu mainMenuInstance, mbPSWD pswdItem, string selectedColumnName)
        {
            InitializeComponent();
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));
            _pswdItem = pswdItem ?? throw new ArgumentNullException(nameof(pswdItem));

            // Pre-fill the textboxes with the existing data
            mbTextBoxEditName.Text = _pswdItem.pswdName;
            mbTextBoxEditAddress.Text = _pswdItem.pswdAddress;
            mbTextBoxEditCategory.Text = _pswdItem.pswdCategory;
            mbTextBoxEditLogin.Text = _pswdItem.pswdLogin;
            mbTextBoxEditPassword.Text = _pswdItem.pswdPass;
            mbTextBoxEditEmail.Text = _pswdItem.pswdEmail;
            mbTextBoxEditAdditionalInfo.Text = _pswdItem.pswdAdditionalInfo;

            // Optionally set hint text for better UX
            mbTextBoxEditName.Hint = "Name";
            mbTextBoxEditAddress.Hint = "Address";
            mbTextBoxEditCategory.Hint = "Category";
            mbTextBoxEditLogin.Hint = "Login";
            mbTextBoxEditPassword.Hint = "Password";
            mbTextBoxEditEmail.Hint = "eMail";
            mbTextBoxEditAdditionalInfo.Hint = "Notes";

            this.Shown += (sender, e) => FocusCorrespondingTextBox(selectedColumnName);
        }
        private void FocusCorrespondingTextBox(string columnName)
        {
            this.BeginInvoke ( (MethodInvoker) delegate {
                // MessageBox.Show($"{columnName}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                switch (columnName)
                {
                    case "pswdName":
                        mbTextBoxEditName.Select();
                        break;
                    case "pswdAddress":
                        mbTextBoxEditAddress.Select();
                        break;
                    case "pswdCategory":
                        mbTextBoxEditCategory.Select();
                        break;
                    case "pswdLogin":
                        mbTextBoxEditLogin.Select();
                        break;
                    case "pswdPass":
                        mbTextBoxEditPassword.Select();
                        break;
                    case "pswdEmail":
                        mbTextBoxEditEmail.Select();
                        break;
                    case "pswdAdditionalInfo":
                        mbTextBoxEditAdditionalInfo.Select();
                        break;
                    default:
                        mbTextBoxEditName.Select();
                        break;
                }
            });
        }

        private void mbButtonEditSave_Click(object sender, EventArgs e)
        {
            _pswdItem.pswdName = mbTextBoxEditName.Text;
            _pswdItem.pswdAddress = mbTextBoxEditAddress.Text;
            _pswdItem.pswdCategory = mbTextBoxEditCategory.Text;
            _pswdItem.pswdLogin = mbTextBoxEditLogin.Text;
            _pswdItem.pswdPass = mbTextBoxEditPassword.Text;
            _pswdItem.pswdEmail = mbTextBoxEditEmail.Text;
            _pswdItem.pswdAdditionalInfo = mbTextBoxEditAdditionalInfo.Text;
            _pswdItem.pswdLastEditTime = DateTime.Now;

            _mainMenuInstance.mbDataView.Refresh();
            _mainMenuInstance.SavePSWDData();

            this.Close();
        }
        private void mbButtonEditCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
