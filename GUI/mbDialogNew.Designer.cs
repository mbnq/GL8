﻿using System.Windows.Forms;

namespace GL8.CORE
{
    partial class mbDialogNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mbTextBoxAddName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbTextBoxAddAddress = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbTextBoxAddCategory = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbTextBoxAddLogin = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbTextBoxAddPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbTextBoxAddEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbTextBoxAddAdditionalInfo = new System.Windows.Forms.TextBox();
            this.mbButtonAddAddItem = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonAddCancel = new MaterialSkin.Controls.MaterialButton();
            this.mbTextBoxAddPassword_GenRandom = new MaterialSkin.Controls.MaterialButton();
            this.mbTextBoxAddPassword_GetRandomNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mbTextBoxAddPassword_GetRandomNum)).BeginInit();
            this.SuspendLayout();
            // 
            // mbTextBoxAddName
            // 
            this.mbTextBoxAddName.AnimateReadOnly = false;
            this.mbTextBoxAddName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbTextBoxAddName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbTextBoxAddName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbTextBoxAddName.Depth = 0;
            this.mbTextBoxAddName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddName.HideSelection = true;
            this.mbTextBoxAddName.Hint = "Name";
            this.mbTextBoxAddName.LeadingIcon = null;
            this.mbTextBoxAddName.Location = new System.Drawing.Point(8, 82);
            this.mbTextBoxAddName.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddName.MaxLength = 32767;
            this.mbTextBoxAddName.MouseState = MaterialSkin.MouseState.OUT;
            this.mbTextBoxAddName.Name = "mbTextBoxAddName";
            this.mbTextBoxAddName.PasswordChar = '\0';
            this.mbTextBoxAddName.PrefixSuffixText = null;
            this.mbTextBoxAddName.ReadOnly = false;
            this.mbTextBoxAddName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddName.SelectedText = "";
            this.mbTextBoxAddName.SelectionLength = 0;
            this.mbTextBoxAddName.SelectionStart = 0;
            this.mbTextBoxAddName.ShortcutsEnabled = true;
            this.mbTextBoxAddName.Size = new System.Drawing.Size(500, 48);
            this.mbTextBoxAddName.TabIndex = 0;
            this.mbTextBoxAddName.TabStop = false;
            this.mbTextBoxAddName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbTextBoxAddName.TrailingIcon = null;
            this.mbTextBoxAddName.UseSystemPasswordChar = false;
            // 
            // mbTextBoxAddAddress
            // 
            this.mbTextBoxAddAddress.AnimateReadOnly = false;
            this.mbTextBoxAddAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbTextBoxAddAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbTextBoxAddAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbTextBoxAddAddress.Depth = 0;
            this.mbTextBoxAddAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddAddress.HideSelection = true;
            this.mbTextBoxAddAddress.Hint = "Site";
            this.mbTextBoxAddAddress.LeadingIcon = null;
            this.mbTextBoxAddAddress.Location = new System.Drawing.Point(7, 149);
            this.mbTextBoxAddAddress.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddAddress.MaxLength = 32767;
            this.mbTextBoxAddAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.mbTextBoxAddAddress.Name = "mbTextBoxAddAddress";
            this.mbTextBoxAddAddress.PasswordChar = '\0';
            this.mbTextBoxAddAddress.PrefixSuffixText = null;
            this.mbTextBoxAddAddress.ReadOnly = false;
            this.mbTextBoxAddAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddAddress.SelectedText = "";
            this.mbTextBoxAddAddress.SelectionLength = 0;
            this.mbTextBoxAddAddress.SelectionStart = 0;
            this.mbTextBoxAddAddress.ShortcutsEnabled = true;
            this.mbTextBoxAddAddress.Size = new System.Drawing.Size(500, 48);
            this.mbTextBoxAddAddress.TabIndex = 0;
            this.mbTextBoxAddAddress.TabStop = false;
            this.mbTextBoxAddAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbTextBoxAddAddress.TrailingIcon = null;
            this.mbTextBoxAddAddress.UseSystemPasswordChar = false;
            // 
            // mbTextBoxAddCategory
            // 
            this.mbTextBoxAddCategory.AnimateReadOnly = false;
            this.mbTextBoxAddCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.mbTextBoxAddCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.mbTextBoxAddCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbTextBoxAddCategory.Depth = 0;
            this.mbTextBoxAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddCategory.HideSelection = true;
            this.mbTextBoxAddCategory.Hint = "Category";
            this.mbTextBoxAddCategory.LeadingIcon = null;
            this.mbTextBoxAddCategory.Location = new System.Drawing.Point(8, 215);
            this.mbTextBoxAddCategory.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddCategory.MaxLength = 32767;
            this.mbTextBoxAddCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.mbTextBoxAddCategory.Name = "mbTextBoxAddCategory";
            this.mbTextBoxAddCategory.PasswordChar = '\0';
            this.mbTextBoxAddCategory.PrefixSuffixText = null;
            this.mbTextBoxAddCategory.ReadOnly = false;
            this.mbTextBoxAddCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddCategory.SelectedText = "";
            this.mbTextBoxAddCategory.SelectionLength = 0;
            this.mbTextBoxAddCategory.SelectionStart = 0;
            this.mbTextBoxAddCategory.ShortcutsEnabled = true;
            this.mbTextBoxAddCategory.Size = new System.Drawing.Size(500, 48);
            this.mbTextBoxAddCategory.TabIndex = 0;
            this.mbTextBoxAddCategory.TabStop = false;
            this.mbTextBoxAddCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbTextBoxAddCategory.TrailingIcon = null;
            this.mbTextBoxAddCategory.UseSystemPasswordChar = false;
            // 
            // mbTextBoxAddLogin
            // 
            this.mbTextBoxAddLogin.AnimateReadOnly = false;
            this.mbTextBoxAddLogin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbTextBoxAddLogin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbTextBoxAddLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbTextBoxAddLogin.Depth = 0;
            this.mbTextBoxAddLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddLogin.HideSelection = true;
            this.mbTextBoxAddLogin.Hint = "Login";
            this.mbTextBoxAddLogin.LeadingIcon = null;
            this.mbTextBoxAddLogin.Location = new System.Drawing.Point(589, 82);
            this.mbTextBoxAddLogin.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddLogin.MaxLength = 32767;
            this.mbTextBoxAddLogin.MouseState = MaterialSkin.MouseState.OUT;
            this.mbTextBoxAddLogin.Name = "mbTextBoxAddLogin";
            this.mbTextBoxAddLogin.PasswordChar = '\0';
            this.mbTextBoxAddLogin.PrefixSuffixText = null;
            this.mbTextBoxAddLogin.ReadOnly = false;
            this.mbTextBoxAddLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddLogin.SelectedText = "";
            this.mbTextBoxAddLogin.SelectionLength = 0;
            this.mbTextBoxAddLogin.SelectionStart = 0;
            this.mbTextBoxAddLogin.ShortcutsEnabled = true;
            this.mbTextBoxAddLogin.Size = new System.Drawing.Size(300, 48);
            this.mbTextBoxAddLogin.TabIndex = 0;
            this.mbTextBoxAddLogin.TabStop = false;
            this.mbTextBoxAddLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbTextBoxAddLogin.TrailingIcon = null;
            this.mbTextBoxAddLogin.UseSystemPasswordChar = false;
            // 
            // mbTextBoxAddPassword
            // 
            this.mbTextBoxAddPassword.AnimateReadOnly = false;
            this.mbTextBoxAddPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbTextBoxAddPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbTextBoxAddPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbTextBoxAddPassword.Depth = 0;
            this.mbTextBoxAddPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddPassword.HideSelection = true;
            this.mbTextBoxAddPassword.Hint = "Password";
            this.mbTextBoxAddPassword.LeadingIcon = null;
            this.mbTextBoxAddPassword.Location = new System.Drawing.Point(589, 149);
            this.mbTextBoxAddPassword.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddPassword.MaxLength = 32767;
            this.mbTextBoxAddPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.mbTextBoxAddPassword.Name = "mbTextBoxAddPassword";
            this.mbTextBoxAddPassword.PasswordChar = '\0';
            this.mbTextBoxAddPassword.PrefixSuffixText = null;
            this.mbTextBoxAddPassword.ReadOnly = false;
            this.mbTextBoxAddPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddPassword.SelectedText = "";
            this.mbTextBoxAddPassword.SelectionLength = 0;
            this.mbTextBoxAddPassword.SelectionStart = 0;
            this.mbTextBoxAddPassword.ShortcutsEnabled = true;
            this.mbTextBoxAddPassword.Size = new System.Drawing.Size(300, 48);
            this.mbTextBoxAddPassword.TabIndex = 0;
            this.mbTextBoxAddPassword.TabStop = false;
            this.mbTextBoxAddPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbTextBoxAddPassword.TrailingIcon = null;
            this.mbTextBoxAddPassword.UseSystemPasswordChar = false;
            // 
            // mbTextBoxAddEmail
            // 
            this.mbTextBoxAddEmail.AnimateReadOnly = false;
            this.mbTextBoxAddEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbTextBoxAddEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbTextBoxAddEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbTextBoxAddEmail.Depth = 0;
            this.mbTextBoxAddEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddEmail.HideSelection = true;
            this.mbTextBoxAddEmail.Hint = "eMail";
            this.mbTextBoxAddEmail.LeadingIcon = null;
            this.mbTextBoxAddEmail.Location = new System.Drawing.Point(589, 215);
            this.mbTextBoxAddEmail.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddEmail.MaxLength = 32767;
            this.mbTextBoxAddEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.mbTextBoxAddEmail.Name = "mbTextBoxAddEmail";
            this.mbTextBoxAddEmail.PasswordChar = '\0';
            this.mbTextBoxAddEmail.PrefixSuffixText = null;
            this.mbTextBoxAddEmail.ReadOnly = false;
            this.mbTextBoxAddEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddEmail.SelectedText = "";
            this.mbTextBoxAddEmail.SelectionLength = 0;
            this.mbTextBoxAddEmail.SelectionStart = 0;
            this.mbTextBoxAddEmail.ShortcutsEnabled = true;
            this.mbTextBoxAddEmail.Size = new System.Drawing.Size(300, 48);
            this.mbTextBoxAddEmail.TabIndex = 0;
            this.mbTextBoxAddEmail.TabStop = false;
            this.mbTextBoxAddEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbTextBoxAddEmail.TrailingIcon = null;
            this.mbTextBoxAddEmail.UseSystemPasswordChar = false;
            // 
            // mbTextBoxAddAdditionalInfo
            // 
            this.mbTextBoxAddAdditionalInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.mbTextBoxAddAdditionalInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbTextBoxAddAdditionalInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mbTextBoxAddAdditionalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbTextBoxAddAdditionalInfo.Location = new System.Drawing.Point(7, 284);
            this.mbTextBoxAddAdditionalInfo.Margin = new System.Windows.Forms.Padding(4);
            this.mbTextBoxAddAdditionalInfo.Multiline = true;
            this.mbTextBoxAddAdditionalInfo.Name = "mbTextBoxAddAdditionalInfo";
            this.mbTextBoxAddAdditionalInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbTextBoxAddAdditionalInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mbTextBoxAddAdditionalInfo.Size = new System.Drawing.Size(881, 100);
            this.mbTextBoxAddAdditionalInfo.TabIndex = 0;
            this.mbTextBoxAddAdditionalInfo.TabStop = false;
            // 
            // mbButtonAddAddItem
            // 
            this.mbButtonAddAddItem.AutoSize = false;
            this.mbButtonAddAddItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonAddAddItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonAddAddItem.Depth = 0;
            this.mbButtonAddAddItem.HighEmphasis = true;
            this.mbButtonAddAddItem.Icon = null;
            this.mbButtonAddAddItem.Location = new System.Drawing.Point(679, 395);
            this.mbButtonAddAddItem.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonAddAddItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonAddAddItem.Name = "mbButtonAddAddItem";
            this.mbButtonAddAddItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonAddAddItem.Size = new System.Drawing.Size(211, 44);
            this.mbButtonAddAddItem.TabIndex = 1;
            this.mbButtonAddAddItem.Text = "Add and Save";
            this.mbButtonAddAddItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonAddAddItem.UseAccentColor = false;
            this.mbButtonAddAddItem.UseVisualStyleBackColor = true;
            this.mbButtonAddAddItem.Click += new System.EventHandler(this.mbButtonAddAddItem_Click);
            // 
            // mbButtonAddCancel
            // 
            this.mbButtonAddCancel.AutoSize = false;
            this.mbButtonAddCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonAddCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonAddCancel.Depth = 0;
            this.mbButtonAddCancel.HighEmphasis = true;
            this.mbButtonAddCancel.Icon = null;
            this.mbButtonAddCancel.Location = new System.Drawing.Point(459, 395);
            this.mbButtonAddCancel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonAddCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonAddCancel.Name = "mbButtonAddCancel";
            this.mbButtonAddCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonAddCancel.Size = new System.Drawing.Size(211, 44);
            this.mbButtonAddCancel.TabIndex = 8;
            this.mbButtonAddCancel.Text = "Cancel";
            this.mbButtonAddCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonAddCancel.UseAccentColor = false;
            this.mbButtonAddCancel.UseVisualStyleBackColor = true;
            this.mbButtonAddCancel.Click += new System.EventHandler(this.mbButtonAddCancel_Click);
            // 
            // mbTextBoxAddPassword_GenRandom
            // 
            this.mbTextBoxAddPassword_GenRandom.AutoSize = false;
            this.mbTextBoxAddPassword_GenRandom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbTextBoxAddPassword_GenRandom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbTextBoxAddPassword_GenRandom.Depth = 0;
            this.mbTextBoxAddPassword_GenRandom.HighEmphasis = true;
            this.mbTextBoxAddPassword_GenRandom.Icon = null;
            this.mbTextBoxAddPassword_GenRandom.Location = new System.Drawing.Point(535, 149);
            this.mbTextBoxAddPassword_GenRandom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbTextBoxAddPassword_GenRandom.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbTextBoxAddPassword_GenRandom.Name = "mbTextBoxAddPassword_GenRandom";
            this.mbTextBoxAddPassword_GenRandom.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbTextBoxAddPassword_GenRandom.Size = new System.Drawing.Size(47, 26);
            this.mbTextBoxAddPassword_GenRandom.TabIndex = 9;
            this.mbTextBoxAddPassword_GenRandom.Text = "R";
            this.mbTextBoxAddPassword_GenRandom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbTextBoxAddPassword_GenRandom.UseAccentColor = false;
            this.mbTextBoxAddPassword_GenRandom.UseVisualStyleBackColor = true;
            this.mbTextBoxAddPassword_GenRandom.Click += new System.EventHandler(this.mbTextBoxAddPassword_GenRandom_Click);
            // 
            // mbTextBoxAddPassword_GetRandomNum
            // 
            this.mbTextBoxAddPassword_GetRandomNum.Location = new System.Drawing.Point(533, 183);
            this.mbTextBoxAddPassword_GetRandomNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mbTextBoxAddPassword_GetRandomNum.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.mbTextBoxAddPassword_GetRandomNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mbTextBoxAddPassword_GetRandomNum.Name = "mbTextBoxAddPassword_GetRandomNum";
            this.mbTextBoxAddPassword_GetRandomNum.Size = new System.Drawing.Size(48, 22);
            this.mbTextBoxAddPassword_GetRandomNum.TabIndex = 12;
            this.mbTextBoxAddPassword_GetRandomNum.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // mbDialogNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 450);
            this.Controls.Add(this.mbTextBoxAddPassword_GetRandomNum);
            this.Controls.Add(this.mbTextBoxAddPassword_GenRandom);
            this.Controls.Add(this.mbButtonAddCancel);
            this.Controls.Add(this.mbButtonAddAddItem);
            this.Controls.Add(this.mbTextBoxAddAdditionalInfo);
            this.Controls.Add(this.mbTextBoxAddEmail);
            this.Controls.Add(this.mbTextBoxAddPassword);
            this.Controls.Add(this.mbTextBoxAddLogin);
            this.Controls.Add(this.mbTextBoxAddCategory);
            this.Controls.Add(this.mbTextBoxAddAddress);
            this.Controls.Add(this.mbTextBoxAddName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mbDialogNew";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.Text = "New Item";
            ((System.ComponentModel.ISupportInitialize)(this.mbTextBoxAddPassword_GetRandomNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mbTextBoxAddName;
        private MaterialSkin.Controls.MaterialTextBox2 mbTextBoxAddAddress;
        private MaterialSkin.Controls.MaterialTextBox2 mbTextBoxAddCategory;
        private MaterialSkin.Controls.MaterialTextBox2 mbTextBoxAddLogin;
        private MaterialSkin.Controls.MaterialTextBox2 mbTextBoxAddPassword;
        private MaterialSkin.Controls.MaterialTextBox2 mbTextBoxAddEmail;
        private TextBox mbTextBoxAddAdditionalInfo;
        private MaterialSkin.Controls.MaterialButton mbButtonAddAddItem;
        private MaterialSkin.Controls.MaterialButton mbButtonAddCancel;
        private MaterialSkin.Controls.MaterialButton mbTextBoxAddPassword_GenRandom;
        private System.Windows.Forms.NumericUpDown mbTextBoxAddPassword_GetRandomNum;
    }
}