
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.ComponentModel;

namespace GL8.CORE
{
    public partial class mbDialogNew : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;

        public static BindingList<mbPSWD> mbPSWDList = mbPSWDList ?? new BindingList<mbPSWD>();
        public mbDialogNew(mbMainMenu mainMenuInstance)
        {
            InitializeComponent();
            this.CenterToParent();
            this.ShowIcon = false;
            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));
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

        private void mbTextBoxAddPassword_GenRandom_Click(object sender, EventArgs e)
        {
            var passwordGenerator = new mbRNG();
            string password = passwordGenerator.GeneratePassword(((int)mbTextBoxAddPassword_GetRandomNum.Value), true, true, true, true);
            mbTextBoxAddPassword.Text = password;
        }
    }
}
