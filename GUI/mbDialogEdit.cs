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

namespace GL8.GUI
{
    public partial class mbDialogEdit : MaterialForm
    {
        private mbPSWD _pswdItem;
        private GL8.CORE.mbMainMenu _mainMenuInstance;
        private string _fieldToFocus;
        public mbDialogEdit(GL8.CORE.mbMainMenu mainMenuInstance, mbPSWD pswdItem, string fieldToFocus)
        {
            InitializeComponent();
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));
            _pswdItem = pswdItem ?? throw new ArgumentNullException(nameof(pswdItem));
            _fieldToFocus = fieldToFocus;

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

            // Set focus to the appropriate field
            SetFocusToField(_fieldToFocus);
        }
        private void mbButtonEditSave_Click(object sender, EventArgs e)
        {
            // Update the _pswdItem with new values
            _pswdItem.pswdName = mbTextBoxEditName.Text;
            _pswdItem.pswdAddress = mbTextBoxEditAddress.Text;
            _pswdItem.pswdCategory = mbTextBoxEditCategory.Text;
            _pswdItem.pswdLogin = mbTextBoxEditLogin.Text;
            _pswdItem.pswdPass = mbTextBoxEditPassword.Text;
            _pswdItem.pswdEmail = mbTextBoxEditEmail.Text;
            _pswdItem.pswdAdditionalInfo = mbTextBoxEditAdditionalInfo.Text;
            _pswdItem.pswdLastEditTime = DateTime.Now;

            // Refresh the DataGridView
            _mainMenuInstance.mbDataView.Refresh();

            // Save the updated data
            _mainMenuInstance.SavePSWDData();

            // Close the edit form
            this.Close();
        }
        private void mbButtonEditCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetFocusToField(string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                // If no field specified, set focus to the first field or any default field
                mbTextBoxEditName.Focus();
                return;
            }

            // Map the field name to the corresponding textbox
            switch (fieldName)
            {
                case "pswdName":
                    mbTextBoxEditName.Focus();
                    break;
                case "pswdAddress":
                    mbTextBoxEditAddress.Focus();
                    break;
                case "pswdCategory":
                    mbTextBoxEditCategory.Focus();
                    break;
                case "pswdLogin":
                    mbTextBoxEditLogin.Focus();
                    break;
                case "pswdPass":
                    mbTextBoxEditPassword.Focus();
                    break;
                case "pswdEmail":
                    mbTextBoxEditEmail.Focus();
                    break;
                case "pswdAdditionalInfo":
                    mbTextBoxEditAdditionalInfo.Focus();
                    break;
                default:
                    mbTextBoxEditName.Focus();
                    break;
            }
        }
    }
}
