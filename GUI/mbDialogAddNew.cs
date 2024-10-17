
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using static GL8.CORE.mbMainMenu;

namespace GL8.CORE
{
    public partial class mbDialogAddNew : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;

        public static BindingList<mbPSWD> mbPSWDList = mbPSWDList ?? new BindingList<mbPSWD>();
        public mbDialogAddNew(mbMainMenu mainMenuInstance)
        {
            InitializeComponent();
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));

            mbTextBoxAddName.Hint = "Name";
            mbTextBoxAddAddress.Hint = "Site Address";
            mbTextBoxAddCategory.Hint = "Category";
            mbTextBoxAddLogin.Hint = "Login";
            mbTextBoxAddPassword.Hint = "Password";
            mbTextBoxAddEmail.Hint = "eMail";
            mbTextBoxAddAdditionalInfo.Hint = "Notes";
        }
        private void mbButtonAddCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbButtonAddAddItem_Click(object sender, EventArgs e)
        {
            AddPSWD();
            this.Close();
        }

        private void AddPSWD()
        {
            var mbPSWDData = new mbPSWD
            {
                pswdName = mbTextBoxAddName.Text,
                pswdAddress = mbTextBoxAddAddress.Text,
                pswdCategory = mbTextBoxAddCategory.Text,
                pswdLogin = mbTextBoxAddLogin.Text,
                pswdPass = mbTextBoxAddPassword.Text,
                pswdEmail = mbTextBoxAddEmail.Text,
                pswdAdditionalInfo = mbTextBoxAddAdditionalInfo.Text,
                pswdCreateTime = DateTime.Now,
                pswdLastEditTime = DateTime.Now
            };

            _mainMenuInstance.mbPSWDList.Add(mbPSWDData);
        }
    }
}
