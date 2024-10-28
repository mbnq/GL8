namespace GL8.CORE
{
    partial class mbDialogSettings
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
            this.mbButtonSettingsClose = new MaterialSkin.Controls.MaterialButton();
            this.mbSettingsSwitchHidePswd = new MaterialSkin.Controls.MaterialSwitch();
            this.mbButtonSettingsDebug = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonSettingsChangeMasterPass_current = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbButtonSettingsChangeMasterPass_new = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbButtonSettingsChangeMasterPass_newConfirm = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbButtonSettingsChangeMasterPassword = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonSettingsImportCSV = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonSettingsExportCSV = new MaterialSkin.Controls.MaterialButton();
            this.mbDropDownSettingsColorScheme = new MaterialSkin.Controls.MaterialComboBox();
            this.mbTextBoxEditPassword_GetRandomNum = new System.Windows.Forms.NumericUpDown();
            this.mbTextBoxEditPassword_GetRandom = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonSettingsBackup = new MaterialSkin.Controls.MaterialButton();
            this.mbDropDownSettingsClipboardDelay = new MaterialSkin.Controls.MaterialComboBox();
            this.mbButtonSettingsExportJSON = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonSettingsImportJSON = new MaterialSkin.Controls.MaterialButton();
            this.mbDropDownSettingsImportExportBackup = new MaterialSkin.Controls.MaterialComboBox();
            this.mbDropDownSettings = new System.Windows.Forms.PictureBox();
            this.mbDropDownSettingsImportBackupFrequency = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mbTextBoxEditPassword_GetRandomNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbDropDownSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // mbButtonSettingsClose
            // 
            this.mbButtonSettingsClose.AutoSize = false;
            this.mbButtonSettingsClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsClose.Depth = 0;
            this.mbButtonSettingsClose.HighEmphasis = true;
            this.mbButtonSettingsClose.Icon = null;
            this.mbButtonSettingsClose.Location = new System.Drawing.Point(635, 405);
            this.mbButtonSettingsClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsClose.Name = "mbButtonSettingsClose";
            this.mbButtonSettingsClose.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsClose.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsClose.TabIndex = 0;
            this.mbButtonSettingsClose.Text = "Close";
            this.mbButtonSettingsClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsClose.UseAccentColor = false;
            this.mbButtonSettingsClose.UseVisualStyleBackColor = true;
            this.mbButtonSettingsClose.Click += new System.EventHandler(this.mbButtonSettingsClose_Click);
            // 
            // mbSettingsSwitchHidePswd
            // 
            this.mbSettingsSwitchHidePswd.AutoSize = true;
            this.mbSettingsSwitchHidePswd.Checked = true;
            this.mbSettingsSwitchHidePswd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mbSettingsSwitchHidePswd.Depth = 0;
            this.mbSettingsSwitchHidePswd.Location = new System.Drawing.Point(7, 91);
            this.mbSettingsSwitchHidePswd.Margin = new System.Windows.Forms.Padding(0);
            this.mbSettingsSwitchHidePswd.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mbSettingsSwitchHidePswd.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbSettingsSwitchHidePswd.Name = "mbSettingsSwitchHidePswd";
            this.mbSettingsSwitchHidePswd.Ripple = true;
            this.mbSettingsSwitchHidePswd.Size = new System.Drawing.Size(172, 37);
            this.mbSettingsSwitchHidePswd.TabIndex = 1;
            this.mbSettingsSwitchHidePswd.Text = "Hide Passwords";
            this.mbSettingsSwitchHidePswd.UseVisualStyleBackColor = true;
            this.mbSettingsSwitchHidePswd.CheckedChanged += new System.EventHandler(this.mbSettingsSwtichHidePswd_CheckedChanged);
            // 
            // mbButtonSettingsDebug
            // 
            this.mbButtonSettingsDebug.AutoSize = false;
            this.mbButtonSettingsDebug.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsDebug.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsDebug.Depth = 0;
            this.mbButtonSettingsDebug.HighEmphasis = true;
            this.mbButtonSettingsDebug.Icon = null;
            this.mbButtonSettingsDebug.Location = new System.Drawing.Point(635, 357);
            this.mbButtonSettingsDebug.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsDebug.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsDebug.Name = "mbButtonSettingsDebug";
            this.mbButtonSettingsDebug.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsDebug.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsDebug.TabIndex = 2;
            this.mbButtonSettingsDebug.Text = "Debug Button";
            this.mbButtonSettingsDebug.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsDebug.UseAccentColor = false;
            this.mbButtonSettingsDebug.UseVisualStyleBackColor = true;
            this.mbButtonSettingsDebug.Visible = false;
            this.mbButtonSettingsDebug.Click += new System.EventHandler(this.mbButtonSettingsDebug_Click);
            // 
            // mbButtonSettingsChangeMasterPass_current
            // 
            this.mbButtonSettingsChangeMasterPass_current.AnimateReadOnly = false;
            this.mbButtonSettingsChangeMasterPass_current.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbButtonSettingsChangeMasterPass_current.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbButtonSettingsChangeMasterPass_current.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbButtonSettingsChangeMasterPass_current.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbButtonSettingsChangeMasterPass_current.Depth = 0;
            this.mbButtonSettingsChangeMasterPass_current.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbButtonSettingsChangeMasterPass_current.HideSelection = true;
            this.mbButtonSettingsChangeMasterPass_current.Hint = "Current Password";
            this.mbButtonSettingsChangeMasterPass_current.LeadingIcon = null;
            this.mbButtonSettingsChangeMasterPass_current.Location = new System.Drawing.Point(461, 84);
            this.mbButtonSettingsChangeMasterPass_current.MaxLength = 32767;
            this.mbButtonSettingsChangeMasterPass_current.MouseState = MaterialSkin.MouseState.OUT;
            this.mbButtonSettingsChangeMasterPass_current.Name = "mbButtonSettingsChangeMasterPass_current";
            this.mbButtonSettingsChangeMasterPass_current.PasswordChar = '*';
            this.mbButtonSettingsChangeMasterPass_current.PrefixSuffixText = null;
            this.mbButtonSettingsChangeMasterPass_current.ReadOnly = false;
            this.mbButtonSettingsChangeMasterPass_current.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbButtonSettingsChangeMasterPass_current.SelectedText = "";
            this.mbButtonSettingsChangeMasterPass_current.SelectionLength = 0;
            this.mbButtonSettingsChangeMasterPass_current.SelectionStart = 0;
            this.mbButtonSettingsChangeMasterPass_current.ShortcutsEnabled = true;
            this.mbButtonSettingsChangeMasterPass_current.Size = new System.Drawing.Size(320, 48);
            this.mbButtonSettingsChangeMasterPass_current.TabIndex = 3;
            this.mbButtonSettingsChangeMasterPass_current.TabStop = false;
            this.mbButtonSettingsChangeMasterPass_current.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbButtonSettingsChangeMasterPass_current.TrailingIcon = null;
            this.mbButtonSettingsChangeMasterPass_current.UseSystemPasswordChar = false;
            // 
            // mbButtonSettingsChangeMasterPass_new
            // 
            this.mbButtonSettingsChangeMasterPass_new.AnimateReadOnly = false;
            this.mbButtonSettingsChangeMasterPass_new.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbButtonSettingsChangeMasterPass_new.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbButtonSettingsChangeMasterPass_new.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbButtonSettingsChangeMasterPass_new.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbButtonSettingsChangeMasterPass_new.Depth = 0;
            this.mbButtonSettingsChangeMasterPass_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbButtonSettingsChangeMasterPass_new.HideSelection = true;
            this.mbButtonSettingsChangeMasterPass_new.Hint = "New Password";
            this.mbButtonSettingsChangeMasterPass_new.LeadingIcon = null;
            this.mbButtonSettingsChangeMasterPass_new.Location = new System.Drawing.Point(461, 149);
            this.mbButtonSettingsChangeMasterPass_new.MaxLength = 32767;
            this.mbButtonSettingsChangeMasterPass_new.MouseState = MaterialSkin.MouseState.OUT;
            this.mbButtonSettingsChangeMasterPass_new.Name = "mbButtonSettingsChangeMasterPass_new";
            this.mbButtonSettingsChangeMasterPass_new.PasswordChar = '\0';
            this.mbButtonSettingsChangeMasterPass_new.PrefixSuffixText = null;
            this.mbButtonSettingsChangeMasterPass_new.ReadOnly = false;
            this.mbButtonSettingsChangeMasterPass_new.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbButtonSettingsChangeMasterPass_new.SelectedText = "";
            this.mbButtonSettingsChangeMasterPass_new.SelectionLength = 0;
            this.mbButtonSettingsChangeMasterPass_new.SelectionStart = 0;
            this.mbButtonSettingsChangeMasterPass_new.ShortcutsEnabled = true;
            this.mbButtonSettingsChangeMasterPass_new.Size = new System.Drawing.Size(320, 48);
            this.mbButtonSettingsChangeMasterPass_new.TabIndex = 3;
            this.mbButtonSettingsChangeMasterPass_new.TabStop = false;
            this.mbButtonSettingsChangeMasterPass_new.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbButtonSettingsChangeMasterPass_new.TrailingIcon = null;
            this.mbButtonSettingsChangeMasterPass_new.UseSystemPasswordChar = false;
            // 
            // mbButtonSettingsChangeMasterPass_newConfirm
            // 
            this.mbButtonSettingsChangeMasterPass_newConfirm.AnimateReadOnly = false;
            this.mbButtonSettingsChangeMasterPass_newConfirm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbButtonSettingsChangeMasterPass_newConfirm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbButtonSettingsChangeMasterPass_newConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbButtonSettingsChangeMasterPass_newConfirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbButtonSettingsChangeMasterPass_newConfirm.Depth = 0;
            this.mbButtonSettingsChangeMasterPass_newConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbButtonSettingsChangeMasterPass_newConfirm.HideSelection = true;
            this.mbButtonSettingsChangeMasterPass_newConfirm.Hint = "Confirm New Password";
            this.mbButtonSettingsChangeMasterPass_newConfirm.LeadingIcon = null;
            this.mbButtonSettingsChangeMasterPass_newConfirm.Location = new System.Drawing.Point(461, 213);
            this.mbButtonSettingsChangeMasterPass_newConfirm.MaxLength = 32767;
            this.mbButtonSettingsChangeMasterPass_newConfirm.MouseState = MaterialSkin.MouseState.OUT;
            this.mbButtonSettingsChangeMasterPass_newConfirm.Name = "mbButtonSettingsChangeMasterPass_newConfirm";
            this.mbButtonSettingsChangeMasterPass_newConfirm.PasswordChar = '\0';
            this.mbButtonSettingsChangeMasterPass_newConfirm.PrefixSuffixText = null;
            this.mbButtonSettingsChangeMasterPass_newConfirm.ReadOnly = false;
            this.mbButtonSettingsChangeMasterPass_newConfirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbButtonSettingsChangeMasterPass_newConfirm.SelectedText = "";
            this.mbButtonSettingsChangeMasterPass_newConfirm.SelectionLength = 0;
            this.mbButtonSettingsChangeMasterPass_newConfirm.SelectionStart = 0;
            this.mbButtonSettingsChangeMasterPass_newConfirm.ShortcutsEnabled = true;
            this.mbButtonSettingsChangeMasterPass_newConfirm.Size = new System.Drawing.Size(320, 48);
            this.mbButtonSettingsChangeMasterPass_newConfirm.TabIndex = 3;
            this.mbButtonSettingsChangeMasterPass_newConfirm.TabStop = false;
            this.mbButtonSettingsChangeMasterPass_newConfirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbButtonSettingsChangeMasterPass_newConfirm.TrailingIcon = null;
            this.mbButtonSettingsChangeMasterPass_newConfirm.UseSystemPasswordChar = false;
            // 
            // mbButtonSettingsChangeMasterPassword
            // 
            this.mbButtonSettingsChangeMasterPassword.AutoSize = false;
            this.mbButtonSettingsChangeMasterPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsChangeMasterPassword.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsChangeMasterPassword.Depth = 0;
            this.mbButtonSettingsChangeMasterPassword.HighEmphasis = true;
            this.mbButtonSettingsChangeMasterPassword.Icon = null;
            this.mbButtonSettingsChangeMasterPassword.Location = new System.Drawing.Point(461, 280);
            this.mbButtonSettingsChangeMasterPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsChangeMasterPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsChangeMasterPassword.Name = "mbButtonSettingsChangeMasterPassword";
            this.mbButtonSettingsChangeMasterPassword.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsChangeMasterPassword.Size = new System.Drawing.Size(320, 51);
            this.mbButtonSettingsChangeMasterPassword.TabIndex = 0;
            this.mbButtonSettingsChangeMasterPassword.Text = "Change Master Password";
            this.mbButtonSettingsChangeMasterPassword.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsChangeMasterPassword.UseAccentColor = false;
            this.mbButtonSettingsChangeMasterPassword.UseVisualStyleBackColor = true;
            this.mbButtonSettingsChangeMasterPassword.Click += new System.EventHandler(this.mbButtonSettingsChangeMasterPassword_Click);
            // 
            // mbButtonSettingsImportCSV
            // 
            this.mbButtonSettingsImportCSV.AutoSize = false;
            this.mbButtonSettingsImportCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsImportCSV.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsImportCSV.Depth = 0;
            this.mbButtonSettingsImportCSV.HighEmphasis = true;
            this.mbButtonSettingsImportCSV.Icon = null;
            this.mbButtonSettingsImportCSV.Location = new System.Drawing.Point(7, 405);
            this.mbButtonSettingsImportCSV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsImportCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsImportCSV.Name = "mbButtonSettingsImportCSV";
            this.mbButtonSettingsImportCSV.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsImportCSV.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsImportCSV.TabIndex = 4;
            this.mbButtonSettingsImportCSV.Text = "Import CSV";
            this.mbButtonSettingsImportCSV.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsImportCSV.UseAccentColor = false;
            this.mbButtonSettingsImportCSV.UseVisualStyleBackColor = true;
            this.mbButtonSettingsImportCSV.Click += new System.EventHandler(this.mbButtonSettingsImportCSV_Click);
            // 
            // mbButtonSettingsExportCSV
            // 
            this.mbButtonSettingsExportCSV.AutoSize = false;
            this.mbButtonSettingsExportCSV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsExportCSV.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsExportCSV.Depth = 0;
            this.mbButtonSettingsExportCSV.HighEmphasis = true;
            this.mbButtonSettingsExportCSV.Icon = null;
            this.mbButtonSettingsExportCSV.Location = new System.Drawing.Point(173, 405);
            this.mbButtonSettingsExportCSV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsExportCSV.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsExportCSV.Name = "mbButtonSettingsExportCSV";
            this.mbButtonSettingsExportCSV.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsExportCSV.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsExportCSV.TabIndex = 4;
            this.mbButtonSettingsExportCSV.Text = "Export CSV";
            this.mbButtonSettingsExportCSV.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsExportCSV.UseAccentColor = false;
            this.mbButtonSettingsExportCSV.UseVisualStyleBackColor = true;
            this.mbButtonSettingsExportCSV.Click += new System.EventHandler(this.mbButtonSettingsExportCSV_Click);
            // 
            // mbDropDownSettingsColorScheme
            // 
            this.mbDropDownSettingsColorScheme.AutoResize = false;
            this.mbDropDownSettingsColorScheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mbDropDownSettingsColorScheme.Depth = 0;
            this.mbDropDownSettingsColorScheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mbDropDownSettingsColorScheme.DropDownHeight = 174;
            this.mbDropDownSettingsColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mbDropDownSettingsColorScheme.DropDownWidth = 121;
            this.mbDropDownSettingsColorScheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mbDropDownSettingsColorScheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mbDropDownSettingsColorScheme.FormattingEnabled = true;
            this.mbDropDownSettingsColorScheme.Hint = "Color Scheme";
            this.mbDropDownSettingsColorScheme.IntegralHeight = false;
            this.mbDropDownSettingsColorScheme.ItemHeight = 43;
            this.mbDropDownSettingsColorScheme.Location = new System.Drawing.Point(7, 148);
            this.mbDropDownSettingsColorScheme.MaxDropDownItems = 4;
            this.mbDropDownSettingsColorScheme.MouseState = MaterialSkin.MouseState.OUT;
            this.mbDropDownSettingsColorScheme.Name = "mbDropDownSettingsColorScheme";
            this.mbDropDownSettingsColorScheme.Size = new System.Drawing.Size(324, 49);
            this.mbDropDownSettingsColorScheme.StartIndex = 0;
            this.mbDropDownSettingsColorScheme.TabIndex = 7;
            this.mbDropDownSettingsColorScheme.SelectedIndexChanged += new System.EventHandler(this.mbDropDownSettingsColorScheme_SelectedIndexChanged);
            // 
            // mbTextBoxEditPassword_GetRandomNum
            // 
            this.mbTextBoxEditPassword_GetRandomNum.Location = new System.Drawing.Point(406, 175);
            this.mbTextBoxEditPassword_GetRandomNum.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.mbTextBoxEditPassword_GetRandomNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mbTextBoxEditPassword_GetRandomNum.Name = "mbTextBoxEditPassword_GetRandomNum";
            this.mbTextBoxEditPassword_GetRandomNum.Size = new System.Drawing.Size(48, 22);
            this.mbTextBoxEditPassword_GetRandomNum.TabIndex = 13;
            this.mbTextBoxEditPassword_GetRandomNum.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // mbTextBoxEditPassword_GetRandom
            // 
            this.mbTextBoxEditPassword_GetRandom.AutoSize = false;
            this.mbTextBoxEditPassword_GetRandom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbTextBoxEditPassword_GetRandom.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbTextBoxEditPassword_GetRandom.Depth = 0;
            this.mbTextBoxEditPassword_GetRandom.HighEmphasis = true;
            this.mbTextBoxEditPassword_GetRandom.Icon = null;
            this.mbTextBoxEditPassword_GetRandom.Location = new System.Drawing.Point(407, 149);
            this.mbTextBoxEditPassword_GetRandom.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbTextBoxEditPassword_GetRandom.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbTextBoxEditPassword_GetRandom.Name = "mbTextBoxEditPassword_GetRandom";
            this.mbTextBoxEditPassword_GetRandom.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbTextBoxEditPassword_GetRandom.Size = new System.Drawing.Size(47, 25);
            this.mbTextBoxEditPassword_GetRandom.TabIndex = 12;
            this.mbTextBoxEditPassword_GetRandom.Text = "R";
            this.mbTextBoxEditPassword_GetRandom.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbTextBoxEditPassword_GetRandom.UseAccentColor = false;
            this.mbTextBoxEditPassword_GetRandom.UseVisualStyleBackColor = true;
            this.mbTextBoxEditPassword_GetRandom.Click += new System.EventHandler(this.mbTextBoxEditPassword_GetRandom_Click);
            // 
            // mbButtonSettingsBackup
            // 
            this.mbButtonSettingsBackup.AutoSize = false;
            this.mbButtonSettingsBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsBackup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsBackup.Depth = 0;
            this.mbButtonSettingsBackup.HighEmphasis = true;
            this.mbButtonSettingsBackup.Icon = null;
            this.mbButtonSettingsBackup.Location = new System.Drawing.Point(339, 405);
            this.mbButtonSettingsBackup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsBackup.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsBackup.Name = "mbButtonSettingsBackup";
            this.mbButtonSettingsBackup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsBackup.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsBackup.TabIndex = 4;
            this.mbButtonSettingsBackup.Text = "Backup";
            this.mbButtonSettingsBackup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsBackup.UseAccentColor = false;
            this.mbButtonSettingsBackup.UseVisualStyleBackColor = true;
            this.mbButtonSettingsBackup.Click += new System.EventHandler(this.mbButtonSettingsBackup_Click);
            // 
            // mbDropDownSettingsClipboardDelay
            // 
            this.mbDropDownSettingsClipboardDelay.AutoResize = false;
            this.mbDropDownSettingsClipboardDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mbDropDownSettingsClipboardDelay.Depth = 0;
            this.mbDropDownSettingsClipboardDelay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mbDropDownSettingsClipboardDelay.DropDownHeight = 174;
            this.mbDropDownSettingsClipboardDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mbDropDownSettingsClipboardDelay.DropDownWidth = 121;
            this.mbDropDownSettingsClipboardDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mbDropDownSettingsClipboardDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mbDropDownSettingsClipboardDelay.FormattingEnabled = true;
            this.mbDropDownSettingsClipboardDelay.Hint = "Clear clipboard after:";
            this.mbDropDownSettingsClipboardDelay.IntegralHeight = false;
            this.mbDropDownSettingsClipboardDelay.ItemHeight = 43;
            this.mbDropDownSettingsClipboardDelay.Location = new System.Drawing.Point(7, 213);
            this.mbDropDownSettingsClipboardDelay.MaxDropDownItems = 4;
            this.mbDropDownSettingsClipboardDelay.MouseState = MaterialSkin.MouseState.OUT;
            this.mbDropDownSettingsClipboardDelay.Name = "mbDropDownSettingsClipboardDelay";
            this.mbDropDownSettingsClipboardDelay.Size = new System.Drawing.Size(324, 49);
            this.mbDropDownSettingsClipboardDelay.StartIndex = 0;
            this.mbDropDownSettingsClipboardDelay.TabIndex = 14;
            this.mbDropDownSettingsClipboardDelay.SelectedIndexChanged += new System.EventHandler(this.mbDropDownSettingsClipboardDelay_SelectedIndexChanged);
            // 
            // mbButtonSettingsExportJSON
            // 
            this.mbButtonSettingsExportJSON.AutoSize = false;
            this.mbButtonSettingsExportJSON.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsExportJSON.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsExportJSON.Depth = 0;
            this.mbButtonSettingsExportJSON.HighEmphasis = true;
            this.mbButtonSettingsExportJSON.Icon = null;
            this.mbButtonSettingsExportJSON.Location = new System.Drawing.Point(173, 357);
            this.mbButtonSettingsExportJSON.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsExportJSON.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsExportJSON.Name = "mbButtonSettingsExportJSON";
            this.mbButtonSettingsExportJSON.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsExportJSON.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsExportJSON.TabIndex = 15;
            this.mbButtonSettingsExportJSON.Text = "EXPORT JSON";
            this.mbButtonSettingsExportJSON.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsExportJSON.UseAccentColor = false;
            this.mbButtonSettingsExportJSON.UseVisualStyleBackColor = true;
            this.mbButtonSettingsExportJSON.Click += new System.EventHandler(this.mbButtonSettingsExportJSON_Click);
            // 
            // mbButtonSettingsImportJSON
            // 
            this.mbButtonSettingsImportJSON.AutoSize = false;
            this.mbButtonSettingsImportJSON.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonSettingsImportJSON.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonSettingsImportJSON.Depth = 0;
            this.mbButtonSettingsImportJSON.HighEmphasis = true;
            this.mbButtonSettingsImportJSON.Icon = null;
            this.mbButtonSettingsImportJSON.Location = new System.Drawing.Point(7, 357);
            this.mbButtonSettingsImportJSON.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbButtonSettingsImportJSON.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonSettingsImportJSON.Name = "mbButtonSettingsImportJSON";
            this.mbButtonSettingsImportJSON.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonSettingsImportJSON.Size = new System.Drawing.Size(158, 36);
            this.mbButtonSettingsImportJSON.TabIndex = 16;
            this.mbButtonSettingsImportJSON.Text = "Import JSON";
            this.mbButtonSettingsImportJSON.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonSettingsImportJSON.UseAccentColor = false;
            this.mbButtonSettingsImportJSON.UseVisualStyleBackColor = true;
            this.mbButtonSettingsImportJSON.Click += new System.EventHandler(this.mbButtonSettingsImportJSON_Click);
            // 
            // mbDropDownSettingsImportExportBackup
            // 
            this.mbDropDownSettingsImportExportBackup.AutoResize = false;
            this.mbDropDownSettingsImportExportBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mbDropDownSettingsImportExportBackup.Depth = 0;
            this.mbDropDownSettingsImportExportBackup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mbDropDownSettingsImportExportBackup.DropDownHeight = 174;
            this.mbDropDownSettingsImportExportBackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mbDropDownSettingsImportExportBackup.DropDownWidth = 121;
            this.mbDropDownSettingsImportExportBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mbDropDownSettingsImportExportBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mbDropDownSettingsImportExportBackup.FormattingEnabled = true;
            this.mbDropDownSettingsImportExportBackup.Hint = "Backup / Import / Export";
            this.mbDropDownSettingsImportExportBackup.IntegralHeight = false;
            this.mbDropDownSettingsImportExportBackup.ItemHeight = 43;
            this.mbDropDownSettingsImportExportBackup.Location = new System.Drawing.Point(7, 344);
            this.mbDropDownSettingsImportExportBackup.MaxDropDownItems = 4;
            this.mbDropDownSettingsImportExportBackup.MouseState = MaterialSkin.MouseState.OUT;
            this.mbDropDownSettingsImportExportBackup.Name = "mbDropDownSettingsImportExportBackup";
            this.mbDropDownSettingsImportExportBackup.Size = new System.Drawing.Size(324, 49);
            this.mbDropDownSettingsImportExportBackup.StartIndex = 0;
            this.mbDropDownSettingsImportExportBackup.TabIndex = 17;
            this.mbDropDownSettingsImportExportBackup.SelectedIndexChanged += new System.EventHandler(this.mbDropDownSettingsImportExportBackup_SelectedIndexChanged);
            // 
            // mbDropDownSettings
            // 
            this.mbDropDownSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mbDropDownSettings.Image = global::GL8.Properties.Resources.icon_image_0_40;
            this.mbDropDownSettings.InitialImage = global::GL8.Properties.Resources.icon_image_0_40;
            this.mbDropDownSettings.Location = new System.Drawing.Point(758, 38);
            this.mbDropDownSettings.Name = "mbDropDownSettings";
            this.mbDropDownSettings.Size = new System.Drawing.Size(36, 33);
            this.mbDropDownSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mbDropDownSettings.TabIndex = 18;
            this.mbDropDownSettings.TabStop = false;
            this.mbDropDownSettings.Click += new System.EventHandler(this.mbDropDownSettings_Click);
            // 
            // mbDropDownSettingsImportBackupFrequency
            // 
            this.mbDropDownSettingsImportBackupFrequency.AutoResize = false;
            this.mbDropDownSettingsImportBackupFrequency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mbDropDownSettingsImportBackupFrequency.Depth = 0;
            this.mbDropDownSettingsImportBackupFrequency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mbDropDownSettingsImportBackupFrequency.DropDownHeight = 174;
            this.mbDropDownSettingsImportBackupFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mbDropDownSettingsImportBackupFrequency.DropDownWidth = 121;
            this.mbDropDownSettingsImportBackupFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mbDropDownSettingsImportBackupFrequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mbDropDownSettingsImportBackupFrequency.FormattingEnabled = true;
            this.mbDropDownSettingsImportBackupFrequency.Hint = "AutoBackup every X startups:";
            this.mbDropDownSettingsImportBackupFrequency.IntegralHeight = false;
            this.mbDropDownSettingsImportBackupFrequency.ItemHeight = 43;
            this.mbDropDownSettingsImportBackupFrequency.Location = new System.Drawing.Point(7, 280);
            this.mbDropDownSettingsImportBackupFrequency.MaxDropDownItems = 4;
            this.mbDropDownSettingsImportBackupFrequency.MouseState = MaterialSkin.MouseState.OUT;
            this.mbDropDownSettingsImportBackupFrequency.Name = "mbDropDownSettingsImportBackupFrequency";
            this.mbDropDownSettingsImportBackupFrequency.Size = new System.Drawing.Size(323, 49);
            this.mbDropDownSettingsImportBackupFrequency.StartIndex = 0;
            this.mbDropDownSettingsImportBackupFrequency.TabIndex = 19;
            this.mbDropDownSettingsImportBackupFrequency.SelectedIndexChanged += new System.EventHandler(this.mbDropDownSettingsImportBackupFrequency_SelectedIndexChanged);
            // 
            // mbDialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mbDropDownSettingsImportBackupFrequency);
            this.Controls.Add(this.mbDropDownSettings);
            this.Controls.Add(this.mbDropDownSettingsImportExportBackup);
            this.Controls.Add(this.mbDropDownSettingsClipboardDelay);
            this.Controls.Add(this.mbTextBoxEditPassword_GetRandomNum);
            this.Controls.Add(this.mbTextBoxEditPassword_GetRandom);
            this.Controls.Add(this.mbDropDownSettingsColorScheme);
            this.Controls.Add(this.mbButtonSettingsChangeMasterPass_newConfirm);
            this.Controls.Add(this.mbButtonSettingsChangeMasterPass_new);
            this.Controls.Add(this.mbButtonSettingsChangeMasterPass_current);
            this.Controls.Add(this.mbButtonSettingsDebug);
            this.Controls.Add(this.mbSettingsSwitchHidePswd);
            this.Controls.Add(this.mbButtonSettingsChangeMasterPassword);
            this.Controls.Add(this.mbButtonSettingsClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mbDialogSettings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.mbTextBoxEditPassword_GetRandomNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mbDropDownSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton mbButtonSettingsClose;
        private MaterialSkin.Controls.MaterialSwitch mbSettingsSwitchHidePswd;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsDebug;
        private MaterialSkin.Controls.MaterialTextBox2 mbButtonSettingsChangeMasterPass_current;
        private MaterialSkin.Controls.MaterialTextBox2 mbButtonSettingsChangeMasterPass_new;
        private MaterialSkin.Controls.MaterialTextBox2 mbButtonSettingsChangeMasterPass_newConfirm;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsChangeMasterPassword;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsImportCSV;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsExportCSV;
        private MaterialSkin.Controls.MaterialComboBox mbDropDownSettingsColorScheme;
        private System.Windows.Forms.NumericUpDown mbTextBoxEditPassword_GetRandomNum;
        private MaterialSkin.Controls.MaterialButton mbTextBoxEditPassword_GetRandom;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsBackup;
        private MaterialSkin.Controls.MaterialComboBox mbDropDownSettingsClipboardDelay;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsExportJSON;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsImportJSON;
        private MaterialSkin.Controls.MaterialComboBox mbDropDownSettingsImportExportBackup;
        private System.Windows.Forms.PictureBox mbDropDownSettings;
        private MaterialSkin.Controls.MaterialComboBox mbDropDownSettingsImportBackupFrequency;
    }
}