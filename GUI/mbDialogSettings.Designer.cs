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
            this.mbSettingsSwitchHidePswd.Location = new System.Drawing.Point(3, 84);
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
            // mbDialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mbButtonSettingsDebug);
            this.Controls.Add(this.mbSettingsSwitchHidePswd);
            this.Controls.Add(this.mbButtonSettingsClose);
            this.Name = "mbDialogSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton mbButtonSettingsClose;
        private MaterialSkin.Controls.MaterialSwitch mbSettingsSwitchHidePswd;
        private MaterialSkin.Controls.MaterialButton mbButtonSettingsDebug;
    }
}