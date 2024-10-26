﻿
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbDialogEdit : MaterialForm
    {
        private mbPSWD _pswdItem;
        private mbMainMenu _mainMenuInstance;
        private int _mbChangesCount;
        public mbDialogEdit(mbMainMenu mainMenuInstance, mbPSWD pswdItem)
        {
            InitializeComponent();
            _mbChangesCount = 0;

            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));
            _pswdItem = pswdItem ?? throw new ArgumentNullException(nameof(pswdItem));

            // Pre-fill the textboxes with the existing data
            mbTextBoxEditName.Text      = _pswdItem.pswdName;
            mbTextBoxEditAddress.Text   = _pswdItem.pswdAddress;
            mbTextBoxEditCategory.Text  = _pswdItem.pswdCategory;
            mbTextBoxEditLogin.Text     = _pswdItem.pswdLogin;
            mbTextBoxEditPassword.Text  = _pswdItem.pswdPass;
            mbTextBoxEditEmail.Text     = _pswdItem.pswdEmail;
            mbTextBoxEditAdditionalInfo.Text = _pswdItem.pswdAdditionalInfo;

            this.CenterToParent();
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            mbTextBoxEditName.TextChanged       += (sender, e) => { _mbChangesCount++; };
            mbTextBoxEditAddress.TextChanged    += (sender, e) => { _mbChangesCount++; };
            mbTextBoxEditCategory.TextChanged   += (sender, e) => { _mbChangesCount++; };
            mbTextBoxEditLogin.TextChanged      += (sender, e) => { _mbChangesCount++; };
            mbTextBoxEditPassword.TextChanged   += (sender, e) => { _mbChangesCount++; };
            mbTextBoxEditEmail.TextChanged      += (sender, e) => { _mbChangesCount++; };
            mbTextBoxEditAdditionalInfo.TextChanged += (sender, e) => { _mbChangesCount++; };

            this.Shown += (sender, e)        => { _mainMenuInstance.mbSwitchEnableMainMenuControls(false); };
            this.FormClosed += (sender, e)   => { _mainMenuInstance.mbSwitchEnableMainMenuControls(true); };

            mbAddSuggestionsToCategory();
        }
        private void mbAddSuggestionsToCategory()
        {
            var suggestionsCollectionCategory = mbSuggestions.mbBuildSuggestionsForCategory();

            mbTextBoxEditCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            mbTextBoxEditCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            mbTextBoxEditCategory.AutoCompleteCustomSource = suggestionsCollectionCategory;
        }
        private void mbButtonEditSave_Click(object sender, EventArgs e)
        {
            if (_mbChangesCount > 0)
            {
                DialogResult mbRUSure = MaterialMessageBox.Show(
                "Are you sure you want to save changes?",
                "Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (mbRUSure != DialogResult.OK) return;
            }

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
            if (_mbChangesCount > 0)
            {
                DialogResult mbRUSure = MaterialMessageBox.Show(
                    "Are you sure you want to cancel?\nChanges will not be saved.",
                    "Confirmation",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (mbRUSure != DialogResult.OK) return;
            }

            this.Close();
        }
        private void mbCheckBoxEditHidePswd_CheckedChanged(object sender, EventArgs e)
        {
            if (mbCheckBoxEditHidePswd.Checked) 
            {
                mbTextBoxEditPassword.PasswordChar = '\0';
            }
            else 
            {
                mbTextBoxEditPassword.PasswordChar = '*';
            }
        }
        private void mbTextBoxEditPassword_GenRandom_Click(object sender, EventArgs e)
        {
            var passwordGenerator = new mbRNG();
            string password = passwordGenerator.mbGenerateRandomPassword((int)mbTextBoxEditPassword_GetRandomNum.Value, true, true, true, true);
            mbTextBoxEditPassword.Text = password;
        }
    }
}
