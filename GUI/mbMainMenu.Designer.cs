namespace GL8.CORE
{
    partial class mbMainMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mbDataView = new System.Windows.Forms.DataGridView();
            this.pswdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pswdLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pswdPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pswdAddress = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pswdCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pswdEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pswdAdditionalInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mbButtonNewItem = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonExit = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonRemoveItem = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonOptions = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonEdit = new MaterialSkin.Controls.MaterialButton();
            this.mbSearchTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbSearchFilter = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mbDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // mbDataView
            // 
            this.mbDataView.AllowUserToAddRows = false;
            this.mbDataView.AllowUserToDeleteRows = false;
            this.mbDataView.AllowUserToOrderColumns = true;
            this.mbDataView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mbDataView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.mbDataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mbDataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.mbDataView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mbDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mbDataView.ColumnHeadersHeight = 30;
            this.mbDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pswdName,
            this.pswdLogin,
            this.pswdPass,
            this.pswdAddress,
            this.pswdCategory,
            this.pswdEmail,
            this.pswdAdditionalInfo});
            this.mbDataView.GridColor = System.Drawing.Color.Gainsboro;
            this.mbDataView.Location = new System.Drawing.Point(304, 86);
            this.mbDataView.Margin = new System.Windows.Forms.Padding(4);
            this.mbDataView.MultiSelect = false;
            this.mbDataView.Name = "mbDataView";
            this.mbDataView.ReadOnly = true;
            this.mbDataView.RowHeadersWidth = 51;
            this.mbDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.mbDataView.Size = new System.Drawing.Size(922, 460);
            this.mbDataView.TabIndex = 0;
            // 
            // pswdName
            // 
            this.pswdName.DataPropertyName = "pswdName";
            this.pswdName.HeaderText = "Name";
            this.pswdName.MinimumWidth = 6;
            this.pswdName.Name = "pswdName";
            this.pswdName.ReadOnly = true;
            this.pswdName.ToolTipText = "Contains Name or other reference for credentials entry.";
            this.pswdName.Width = 125;
            // 
            // pswdLogin
            // 
            this.pswdLogin.DataPropertyName = "pswdLogin";
            this.pswdLogin.HeaderText = "Login";
            this.pswdLogin.MinimumWidth = 6;
            this.pswdLogin.Name = "pswdLogin";
            this.pswdLogin.ReadOnly = true;
            this.pswdLogin.ToolTipText = "Contains Login for credentials entry.";
            this.pswdLogin.Width = 125;
            // 
            // pswdPass
            // 
            this.pswdPass.DataPropertyName = "pswdPass";
            this.pswdPass.HeaderText = "Password";
            this.pswdPass.MinimumWidth = 6;
            this.pswdPass.Name = "pswdPass";
            this.pswdPass.ReadOnly = true;
            this.pswdPass.ToolTipText = "Contains Password for credentials entry.";
            this.pswdPass.Width = 125;
            // 
            // pswdAddress
            // 
            this.pswdAddress.ActiveLinkColor = System.Drawing.Color.Silver;
            this.pswdAddress.DataPropertyName = "pswdAddress";
            this.pswdAddress.HeaderText = "Site";
            this.pswdAddress.LinkColor = System.Drawing.Color.Silver;
            this.pswdAddress.MinimumWidth = 6;
            this.pswdAddress.Name = "pswdAddress";
            this.pswdAddress.ReadOnly = true;
            this.pswdAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pswdAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.pswdAddress.ToolTipText = "Contains URL (link) to related site.";
            this.pswdAddress.VisitedLinkColor = System.Drawing.Color.Gray;
            this.pswdAddress.Width = 101;
            // 
            // pswdCategory
            // 
            this.pswdCategory.DataPropertyName = "pswdCategory";
            this.pswdCategory.HeaderText = "Category";
            this.pswdCategory.MinimumWidth = 6;
            this.pswdCategory.Name = "pswdCategory";
            this.pswdCategory.ReadOnly = true;
            this.pswdCategory.ToolTipText = "Contains Category of credentials entry. Can be empty.";
            this.pswdCategory.Width = 125;
            // 
            // pswdEmail
            // 
            this.pswdEmail.DataPropertyName = "pswdEmail";
            this.pswdEmail.HeaderText = "eMail";
            this.pswdEmail.MinimumWidth = 6;
            this.pswdEmail.Name = "pswdEmail";
            this.pswdEmail.ReadOnly = true;
            this.pswdEmail.ToolTipText = "Contains eMail address for credentials entry.";
            this.pswdEmail.Width = 125;
            // 
            // pswdAdditionalInfo
            // 
            this.pswdAdditionalInfo.DataPropertyName = "pswdAdditionalInfo";
            this.pswdAdditionalInfo.HeaderText = "Notes";
            this.pswdAdditionalInfo.MinimumWidth = 6;
            this.pswdAdditionalInfo.Name = "pswdAdditionalInfo";
            this.pswdAdditionalInfo.ReadOnly = true;
            this.pswdAdditionalInfo.ToolTipText = "Contains notes related to credentials entry.";
            this.pswdAdditionalInfo.Width = 125;
            // 
            // mbButtonNewItem
            // 
            this.mbButtonNewItem.AutoSize = false;
            this.mbButtonNewItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonNewItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonNewItem.Depth = 0;
            this.mbButtonNewItem.HighEmphasis = true;
            this.mbButtonNewItem.Icon = null;
            this.mbButtonNewItem.Location = new System.Drawing.Point(11, 86);
            this.mbButtonNewItem.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonNewItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonNewItem.Name = "mbButtonNewItem";
            this.mbButtonNewItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonNewItem.Size = new System.Drawing.Size(288, 44);
            this.mbButtonNewItem.TabIndex = 1;
            this.mbButtonNewItem.Text = "Add New";
            this.mbButtonNewItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonNewItem.UseAccentColor = false;
            this.mbButtonNewItem.UseVisualStyleBackColor = true;
            this.mbButtonNewItem.Click += new System.EventHandler(this.mbButtonNewItem_Click);
            // 
            // mbButtonExit
            // 
            this.mbButtonExit.AutoSize = false;
            this.mbButtonExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonExit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonExit.Depth = 0;
            this.mbButtonExit.HighEmphasis = true;
            this.mbButtonExit.Icon = null;
            this.mbButtonExit.Location = new System.Drawing.Point(9, 498);
            this.mbButtonExit.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonExit.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonExit.Name = "mbButtonExit";
            this.mbButtonExit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonExit.Size = new System.Drawing.Size(288, 44);
            this.mbButtonExit.TabIndex = 3;
            this.mbButtonExit.Text = "Exit";
            this.mbButtonExit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonExit.UseAccentColor = false;
            this.mbButtonExit.UseVisualStyleBackColor = true;
            this.mbButtonExit.Click += new System.EventHandler(this.mbButtonExit_Click);
            // 
            // mbButtonRemoveItem
            // 
            this.mbButtonRemoveItem.AutoSize = false;
            this.mbButtonRemoveItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonRemoveItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonRemoveItem.Depth = 0;
            this.mbButtonRemoveItem.HighEmphasis = true;
            this.mbButtonRemoveItem.Icon = null;
            this.mbButtonRemoveItem.Location = new System.Drawing.Point(9, 202);
            this.mbButtonRemoveItem.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonRemoveItem.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonRemoveItem.Name = "mbButtonRemoveItem";
            this.mbButtonRemoveItem.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonRemoveItem.Size = new System.Drawing.Size(288, 44);
            this.mbButtonRemoveItem.TabIndex = 4;
            this.mbButtonRemoveItem.Text = "Delete";
            this.mbButtonRemoveItem.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonRemoveItem.UseAccentColor = false;
            this.mbButtonRemoveItem.UseVisualStyleBackColor = true;
            this.mbButtonRemoveItem.Click += new System.EventHandler(this.mbButtonRemoveItem_Click);
            // 
            // mbButtonOptions
            // 
            this.mbButtonOptions.AutoSize = false;
            this.mbButtonOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonOptions.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonOptions.Depth = 0;
            this.mbButtonOptions.HighEmphasis = true;
            this.mbButtonOptions.Icon = null;
            this.mbButtonOptions.Location = new System.Drawing.Point(9, 439);
            this.mbButtonOptions.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonOptions.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonOptions.Name = "mbButtonOptions";
            this.mbButtonOptions.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonOptions.Size = new System.Drawing.Size(288, 44);
            this.mbButtonOptions.TabIndex = 6;
            this.mbButtonOptions.Text = "Settings";
            this.mbButtonOptions.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonOptions.UseAccentColor = false;
            this.mbButtonOptions.UseVisualStyleBackColor = true;
            this.mbButtonOptions.Click += new System.EventHandler(this.mbButtonOptions_Click);
            // 
            // mbButtonEdit
            // 
            this.mbButtonEdit.AutoSize = false;
            this.mbButtonEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonEdit.Depth = 0;
            this.mbButtonEdit.HighEmphasis = true;
            this.mbButtonEdit.Icon = null;
            this.mbButtonEdit.Location = new System.Drawing.Point(9, 144);
            this.mbButtonEdit.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.mbButtonEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbButtonEdit.Name = "mbButtonEdit";
            this.mbButtonEdit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbButtonEdit.Size = new System.Drawing.Size(288, 44);
            this.mbButtonEdit.TabIndex = 1;
            this.mbButtonEdit.Text = "Edit";
            this.mbButtonEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbButtonEdit.UseAccentColor = false;
            this.mbButtonEdit.UseVisualStyleBackColor = true;
            this.mbButtonEdit.Click += new System.EventHandler(this.mbButtonEdit_Click);
            // 
            // mbSearchTextBox
            // 
            this.mbSearchTextBox.AnimateReadOnly = false;
            this.mbSearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.mbSearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.mbSearchTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mbSearchTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mbSearchTextBox.Depth = 0;
            this.mbSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mbSearchTextBox.HideSelection = true;
            this.mbSearchTextBox.Hint = "Search:";
            this.mbSearchTextBox.LeadingIcon = null;
            this.mbSearchTextBox.Location = new System.Drawing.Point(9, 302);
            this.mbSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mbSearchTextBox.MaxLength = 32767;
            this.mbSearchTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.mbSearchTextBox.Name = "mbSearchTextBox";
            this.mbSearchTextBox.PasswordChar = '\0';
            this.mbSearchTextBox.PrefixSuffixText = null;
            this.mbSearchTextBox.ReadOnly = false;
            this.mbSearchTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mbSearchTextBox.SelectedText = "";
            this.mbSearchTextBox.SelectionLength = 0;
            this.mbSearchTextBox.SelectionStart = 0;
            this.mbSearchTextBox.ShortcutsEnabled = true;
            this.mbSearchTextBox.Size = new System.Drawing.Size(288, 48);
            this.mbSearchTextBox.TabIndex = 7;
            this.mbSearchTextBox.TabStop = false;
            this.mbSearchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mbSearchTextBox.TrailingIcon = null;
            this.mbSearchTextBox.UseSystemPasswordChar = false;
            this.mbSearchTextBox.TextChanged += new System.EventHandler(this.mbSearchTextBox_TextChanged);
            // 
            // mbSearchFilter
            // 
            this.mbSearchFilter.AutoResize = false;
            this.mbSearchFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mbSearchFilter.Depth = 0;
            this.mbSearchFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mbSearchFilter.DropDownHeight = 174;
            this.mbSearchFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mbSearchFilter.DropDownWidth = 121;
            this.mbSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mbSearchFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mbSearchFilter.FormattingEnabled = true;
            this.mbSearchFilter.IntegralHeight = false;
            this.mbSearchFilter.ItemHeight = 43;
            this.mbSearchFilter.Items.AddRange(new object[] {
            "ALL",
            "Name",
            "Address",
            "Category",
            "Login",
            "Email",
            "Additional Info"});
            this.mbSearchFilter.Location = new System.Drawing.Point(11, 368);
            this.mbSearchFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mbSearchFilter.MaxDropDownItems = 4;
            this.mbSearchFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.mbSearchFilter.Name = "mbSearchFilter";
            this.mbSearchFilter.Size = new System.Drawing.Size(287, 49);
            this.mbSearchFilter.StartIndex = 0;
            this.mbSearchFilter.TabIndex = 8;
            this.mbSearchFilter.SelectedIndexChanged += new System.EventHandler(this.mbSearchFilter_SelectedIndexChanged);
            // 
            // mbMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 552);
            this.Controls.Add(this.mbSearchFilter);
            this.Controls.Add(this.mbSearchTextBox);
            this.Controls.Add(this.mbButtonOptions);
            this.Controls.Add(this.mbButtonRemoveItem);
            this.Controls.Add(this.mbButtonExit);
            this.Controls.Add(this.mbButtonEdit);
            this.Controls.Add(this.mbButtonNewItem);
            this.Controls.Add(this.mbDataView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1799, 552);
            this.MinimumSize = new System.Drawing.Size(1066, 552);
            this.Name = "mbMainMenu";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 4, 4);
            this.Sizable = true;
            this.Text = "GL8";
            ((System.ComponentModel.ISupportInitialize)(this.mbDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView mbDataView;
        private MaterialSkin.Controls.MaterialButton mbButtonNewItem;
        private MaterialSkin.Controls.MaterialButton mbButtonExit;
        private MaterialSkin.Controls.MaterialButton mbButtonRemoveItem;
        private MaterialSkin.Controls.MaterialButton mbButtonOptions;
        private MaterialSkin.Controls.MaterialButton mbButtonEdit;
        private MaterialSkin.Controls.MaterialTextBox2 mbSearchTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn pswdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pswdLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn pswdPass;
        private System.Windows.Forms.DataGridViewLinkColumn pswdAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn pswdCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn pswdEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn pswdAdditionalInfo;
        private MaterialSkin.Controls.MaterialComboBox mbSearchFilter;
    }
}