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
            this.mbDataView = new System.Windows.Forms.DataGridView();
            this.mbButtonNewItem = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonExit = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonRemoveItem = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonOptions = new MaterialSkin.Controls.MaterialButton();
            this.mbButtonEdit = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.mbDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // mbDataView
            // 
            this.mbDataView.AllowUserToAddRows = false;
            this.mbDataView.AllowUserToDeleteRows = false;
            this.mbDataView.ColumnHeadersHeight = 29;
            this.mbDataView.Location = new System.Drawing.Point(307, 82);
            this.mbDataView.Margin = new System.Windows.Forms.Padding(4);
            this.mbDataView.Name = "mbDataView";
            this.mbDataView.ReadOnly = true;
            this.mbDataView.RowHeadersWidth = 51;
            this.mbDataView.Size = new System.Drawing.Size(752, 464);
            this.mbDataView.TabIndex = 0;
            // 
            // mbButtonNewItem
            // 
            this.mbButtonNewItem.AutoSize = false;
            this.mbButtonNewItem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonNewItem.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonNewItem.Depth = 0;
            this.mbButtonNewItem.HighEmphasis = true;
            this.mbButtonNewItem.Icon = null;
            this.mbButtonNewItem.Location = new System.Drawing.Point(10, 82);
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
            this.mbButtonRemoveItem.Location = new System.Drawing.Point(9, 198);
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
            // 
            // mbButtonEdit
            // 
            this.mbButtonEdit.AutoSize = false;
            this.mbButtonEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbButtonEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbButtonEdit.Depth = 0;
            this.mbButtonEdit.HighEmphasis = true;
            this.mbButtonEdit.Icon = null;
            this.mbButtonEdit.Location = new System.Drawing.Point(9, 140);
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
            // mbMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mbButtonOptions);
            this.Controls.Add(this.mbButtonRemoveItem);
            this.Controls.Add(this.mbButtonExit);
            this.Controls.Add(this.mbButtonEdit);
            this.Controls.Add(this.mbButtonNewItem);
            this.Controls.Add(this.mbDataView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mbMainMenu";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
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
    }
}