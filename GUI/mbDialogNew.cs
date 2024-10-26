
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbDialogNew : MaterialForm
    {
        private mbMainMenu _mainMenuInstance;
        private int _mbChangesCount;

        public static BindingList<mbPSWD> mbPSWDList = mbPSWDList ?? new BindingList<mbPSWD>();
        public mbDialogNew(mbMainMenu mainMenuInstance)
        {
            InitializeComponent();
            _mbChangesCount = 0;

            this.CenterToParent();
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            _mainMenuInstance = mainMenuInstance ?? throw new ArgumentNullException(nameof(mainMenuInstance));

            mbTextBoxAddName.TextChanged += (sender, e) => { _mbChangesCount++; };
            mbTextBoxAddAddress.TextChanged += (sender, e) => { _mbChangesCount++; };
            mbTextBoxAddCategory.TextChanged += (sender, e) => { _mbChangesCount++; };
            mbTextBoxAddLogin.TextChanged += (sender, e) => { _mbChangesCount++; };
            mbTextBoxAddPassword.TextChanged += (sender, e) => { _mbChangesCount++; };
            mbTextBoxAddEmail.TextChanged += (sender, e) => { _mbChangesCount++; };
            mbTextBoxAddAdditionalInfo.TextChanged += (sender, e) => { _mbChangesCount++; };

            this.Shown += (sender, e) => { _mainMenuInstance.mbSwitchEnableMainMenuControls(false); };
            this.FormClosed += (sender, e) => { _mainMenuInstance.mbSwitchEnableMainMenuControls(true); };

            mbAddSuggestionsToCategory();
        }

        private void mbAddSuggestionsToCategory()
        {
            mbSuggestions.mbBuildSuggestionsForCategory(mbSuggestions.suggestionsCollectionCategory);

            mbTextBoxAddCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
            mbTextBoxAddCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
            mbTextBoxAddCategory.AutoCompleteCustomSource = mbSuggestions.suggestionsCollectionCategory;
        }

        private void mbButtonAddCancel_Click(object sender, EventArgs e)
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
        private void mbButtonAddAddItem_Click(object sender, EventArgs e)
        {
            if (_mbChangesCount == 0)
            {
                MaterialMessageBox.Show(
                    "Fill atleast one field before saving.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (_mbChangesCount > 0)
            {
                DialogResult mbRUSure = MaterialMessageBox.Show(
                "Are you sure you want to save changes?",
                "Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

                if (mbRUSure != DialogResult.OK) return;
            }

            AddPSWD();
            _mainMenuInstance.SavePSWDData();
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
            string password = passwordGenerator.mbGenerateRandomPassword(((int)mbTextBoxAddPassword_GetRandomNum.Value), true, true, true, true);
            mbTextBoxAddPassword.Text = password;
        }
    }
}
