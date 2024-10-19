using MaterialSkin.Controls;

namespace GL8.CORE
{
    partial class mbCSVImportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Define controls for delimiter selection
        private MaterialLabel lblDelimiter;
        private MaterialComboBox cmbDelimiter;
        private MaterialTextBox2 txtCustomDelimiter;
        private MaterialLabel lblCustomDelimiter;
        private MaterialButton btnApplyCustomDelimiter; // Apply button

        // Define OK and Cancel buttons
        private MaterialButton btnOK;
        private MaterialButton btnCancel;

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
            this.lblDelimiter = new MaterialSkin.Controls.MaterialLabel();
            this.cmbDelimiter = new MaterialSkin.Controls.MaterialComboBox();
            this.lblCustomDelimiter = new MaterialSkin.Controls.MaterialLabel();
            this.txtCustomDelimiter = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnApplyCustomDelimiter = new MaterialSkin.Controls.MaterialButton();
            this.btnOK = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Depth = 0;
            this.lblDelimiter.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDelimiter.Location = new System.Drawing.Point(40, 606);
            this.lblDelimiter.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(68, 19);
            this.lblDelimiter.TabIndex = 0;
            this.lblDelimiter.Text = "Delimiter:";
            // 
            // cmbDelimiter
            // 
            this.cmbDelimiter.AutoResize = false;
            this.cmbDelimiter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDelimiter.Depth = 0;
            this.cmbDelimiter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDelimiter.DropDownHeight = 174;
            this.cmbDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDelimiter.DropDownWidth = 121;
            this.cmbDelimiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDelimiter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDelimiter.FormattingEnabled = true;
            this.cmbDelimiter.IntegralHeight = false;
            this.cmbDelimiter.ItemHeight = 43;
            this.cmbDelimiter.Items.AddRange(new object[] {
            "Comma (,)",
            "Semicolon (;)",
            "Tab (\\t)",
            "Pipe (|)",
            "Space ( )",
            "Custom"});
            this.cmbDelimiter.Location = new System.Drawing.Point(180, 588);
            this.cmbDelimiter.MaxDropDownItems = 4;
            this.cmbDelimiter.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDelimiter.Name = "cmbDelimiter";
            this.cmbDelimiter.Size = new System.Drawing.Size(165, 49);
            this.cmbDelimiter.StartIndex = 0;
            this.cmbDelimiter.TabIndex = 1;
            this.cmbDelimiter.SelectedIndexChanged += new System.EventHandler(this.cmbDelimiter_SelectedIndexChanged);
            // 
            // lblCustomDelimiter
            // 
            this.lblCustomDelimiter.AutoSize = true;
            this.lblCustomDelimiter.Depth = 0;
            this.lblCustomDelimiter.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomDelimiter.Location = new System.Drawing.Point(40, 669);
            this.lblCustomDelimiter.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomDelimiter.Name = "lblCustomDelimiter";
            this.lblCustomDelimiter.Size = new System.Drawing.Size(60, 19);
            this.lblCustomDelimiter.TabIndex = 2;
            this.lblCustomDelimiter.Text = "Custom:";
            this.lblCustomDelimiter.Visible = false;
            // 
            // txtCustomDelimiter
            // 
            this.txtCustomDelimiter.AnimateReadOnly = false;
            this.txtCustomDelimiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCustomDelimiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCustomDelimiter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCustomDelimiter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCustomDelimiter.Depth = 0;
            this.txtCustomDelimiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomDelimiter.HideSelection = true;
            this.txtCustomDelimiter.Hint = "Custom";
            this.txtCustomDelimiter.LeadingIcon = null;
            this.txtCustomDelimiter.Location = new System.Drawing.Point(180, 657);
            this.txtCustomDelimiter.MaxLength = 32767;
            this.txtCustomDelimiter.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomDelimiter.Name = "txtCustomDelimiter";
            this.txtCustomDelimiter.PasswordChar = '\0';
            this.txtCustomDelimiter.PrefixSuffixText = null;
            this.txtCustomDelimiter.ReadOnly = false;
            this.txtCustomDelimiter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomDelimiter.SelectedText = "";
            this.txtCustomDelimiter.SelectionLength = 0;
            this.txtCustomDelimiter.SelectionStart = 0;
            this.txtCustomDelimiter.ShortcutsEnabled = true;
            this.txtCustomDelimiter.Size = new System.Drawing.Size(165, 48);
            this.txtCustomDelimiter.TabIndex = 3;
            this.txtCustomDelimiter.TabStop = false;
            this.txtCustomDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCustomDelimiter.TrailingIcon = null;
            this.txtCustomDelimiter.UseSystemPasswordChar = false;
            this.txtCustomDelimiter.Visible = false;
            // 
            // btnApplyCustomDelimiter
            // 
            this.btnApplyCustomDelimiter.AutoSize = false;
            this.btnApplyCustomDelimiter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyCustomDelimiter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnApplyCustomDelimiter.Depth = 0;
            this.btnApplyCustomDelimiter.HighEmphasis = true;
            this.btnApplyCustomDelimiter.Icon = null;
            this.btnApplyCustomDelimiter.Location = new System.Drawing.Point(352, 669);
            this.btnApplyCustomDelimiter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnApplyCustomDelimiter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnApplyCustomDelimiter.Name = "btnApplyCustomDelimiter";
            this.btnApplyCustomDelimiter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnApplyCustomDelimiter.Size = new System.Drawing.Size(97, 30);
            this.btnApplyCustomDelimiter.TabIndex = 4;
            this.btnApplyCustomDelimiter.Text = "Apply";
            this.btnApplyCustomDelimiter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnApplyCustomDelimiter.UseAccentColor = false;
            this.btnApplyCustomDelimiter.UseVisualStyleBackColor = true;
            this.btnApplyCustomDelimiter.Visible = false;
            this.btnApplyCustomDelimiter.Click += new System.EventHandler(this.btnApplyCustomDelimiter_Click);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = false;
            this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOK.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOK.Depth = 0;
            this.btnOK.HighEmphasis = true;
            this.btnOK.Icon = null;
            this.btnOK.Location = new System.Drawing.Point(353, 754);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOK.Size = new System.Drawing.Size(96, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOK.UseAccentColor = false;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(457, 754);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(97, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // mbCSVImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.cmbDelimiter);
            this.Controls.Add(this.lblCustomDelimiter);
            this.Controls.Add(this.txtCustomDelimiter);
            this.Controls.Add(this.btnApplyCustomDelimiter);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mbCSVImportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CSV Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
