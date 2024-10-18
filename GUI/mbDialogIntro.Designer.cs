namespace GL8.GUI
{
    partial class mbDialogIntro
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
            this.mbIntroTextBoxMasterPswd = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbIntroButtonLogin = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mbIntroTextBoxMasterPswd
            // 
            this.mbIntroTextBoxMasterPswd.AnimateReadOnly = false;
            this.mbIntroTextBoxMasterPswd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbIntroTextBoxMasterPswd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbIntroTextBoxMasterPswd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbIntroTextBoxMasterPswd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbIntroTextBoxMasterPswd.Depth = 0;
            this.mbIntroTextBoxMasterPswd.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbIntroTextBoxMasterPswd.HideSelection = true;
            this.mbIntroTextBoxMasterPswd.Hint = "Enter Password";
            this.mbIntroTextBoxMasterPswd.LeadingIcon = null;
            this.mbIntroTextBoxMasterPswd.Location = new System.Drawing.Point(63, 98);
            this.mbIntroTextBoxMasterPswd.MaxLength = 32767;
            this.mbIntroTextBoxMasterPswd.MouseState = MaterialSkin.MouseState.OUT;
            this.mbIntroTextBoxMasterPswd.Name = "mbIntroTextBoxMasterPswd";
            this.mbIntroTextBoxMasterPswd.PasswordChar = '*';
            this.mbIntroTextBoxMasterPswd.PrefixSuffixText = null;
            this.mbIntroTextBoxMasterPswd.ReadOnly = false;
            this.mbIntroTextBoxMasterPswd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbIntroTextBoxMasterPswd.SelectedText = "";
            this.mbIntroTextBoxMasterPswd.SelectionLength = 0;
            this.mbIntroTextBoxMasterPswd.SelectionStart = 0;
            this.mbIntroTextBoxMasterPswd.ShortcutsEnabled = true;
            this.mbIntroTextBoxMasterPswd.Size = new System.Drawing.Size(250, 48);
            this.mbIntroTextBoxMasterPswd.TabIndex = 0;
            this.mbIntroTextBoxMasterPswd.TabStop = false;
            this.mbIntroTextBoxMasterPswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbIntroTextBoxMasterPswd.TrailingIcon = null;
            this.mbIntroTextBoxMasterPswd.UseSystemPasswordChar = false;
            // 
            // mbIntroButtonLogin
            // 
            this.mbIntroButtonLogin.AutoSize = false;
            this.mbIntroButtonLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbIntroButtonLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbIntroButtonLogin.Depth = 0;
            this.mbIntroButtonLogin.HighEmphasis = true;
            this.mbIntroButtonLogin.Icon = null;
            this.mbIntroButtonLogin.Location = new System.Drawing.Point(63, 173);
            this.mbIntroButtonLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbIntroButtonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbIntroButtonLogin.Name = "mbIntroButtonLogin";
            this.mbIntroButtonLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbIntroButtonLogin.Size = new System.Drawing.Size(250, 36);
            this.mbIntroButtonLogin.TabIndex = 1;
            this.mbIntroButtonLogin.Text = "materialButton1";
            this.mbIntroButtonLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbIntroButtonLogin.UseAccentColor = false;
            this.mbIntroButtonLogin.UseVisualStyleBackColor = true;
            // 
            // mbDialogIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 251);
            this.Controls.Add(this.mbIntroButtonLogin);
            this.Controls.Add(this.mbIntroTextBoxMasterPswd);
            this.Name = "mbDialogIntro";
            this.Text = "Welcome";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mbIntroTextBoxMasterPswd;
        private MaterialSkin.Controls.MaterialButton mbIntroButtonLogin;
    }
}