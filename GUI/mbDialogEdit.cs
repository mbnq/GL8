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

        public mbDialogEdit(GL8.CORE.mbMainMenu mainMenuInstance, mbPSWD pswdItem)
        {
            InitializeComponent();
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));
            _pswdItem = pswdItem ?? throw new ArgumentNullException(nameof(pswdItem));

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
            mbTextBoxEditEmail.Hint = "Email";
            mbTextBoxEditAdditionalInfo.Hint = "Additional Info";
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
    }
}
