namespace GL8.CORE
{
    partial class mbCSVImportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Define controls for delimiter selection
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.ComboBox cmbDelimiter;
        private System.Windows.Forms.TextBox txtCustomDelimiter;
        private System.Windows.Forms.Label lblCustomDelimiter;
        private System.Windows.Forms.Button btnApplyCustomDelimiter; // Apply button

        // Define OK and Cancel buttons
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.cmbDelimiter = new System.Windows.Forms.ComboBox();
            this.lblCustomDelimiter = new System.Windows.Forms.Label();
            this.txtCustomDelimiter = new System.Windows.Forms.TextBox();
            this.btnApplyCustomDelimiter = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(20, 10);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(63, 16);
            this.lblDelimiter.TabIndex = 0;
            this.lblDelimiter.Text = "Delimiter:";
            // 
            // cmbDelimiter
            // 
            this.cmbDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDelimiter.FormattingEnabled = true;
            this.cmbDelimiter.Items.AddRange(new object[] {
            "Comma (,)",
            "Semicolon (;)",
            "Tab (\\t)",
            "Pipe (|)",
            "Space ( )",
            "Custom"});
            this.cmbDelimiter.Location = new System.Drawing.Point(100, 7);
            this.cmbDelimiter.Name = "cmbDelimiter";
            this.cmbDelimiter.Size = new System.Drawing.Size(150, 24);
            this.cmbDelimiter.TabIndex = 1;
            this.cmbDelimiter.SelectedIndexChanged += new System.EventHandler(this.cmbDelimiter_SelectedIndexChanged);
            // 
            // lblCustomDelimiter
            // 
            this.lblCustomDelimiter.AutoSize = true;
            this.lblCustomDelimiter.Location = new System.Drawing.Point(20, 40);
            this.lblCustomDelimiter.Name = "lblCustomDelimiter";
            this.lblCustomDelimiter.Size = new System.Drawing.Size(111, 16);
            this.lblCustomDelimiter.TabIndex = 2;
            this.lblCustomDelimiter.Text = "Custom Delimiter:";
            this.lblCustomDelimiter.Visible = false;
            // 
            // txtCustomDelimiter
            // 
            this.txtCustomDelimiter.Location = new System.Drawing.Point(124, 34);
            this.txtCustomDelimiter.Name = "txtCustomDelimiter";
            this.txtCustomDelimiter.Size = new System.Drawing.Size(130, 22);
            this.txtCustomDelimiter.TabIndex = 3;
            this.txtCustomDelimiter.Visible = false;
            // 
            // btnApplyCustomDelimiter
            // 
            this.btnApplyCustomDelimiter.Location = new System.Drawing.Point(260, 35);
            this.btnApplyCustomDelimiter.Name = "btnApplyCustomDelimiter";
            this.btnApplyCustomDelimiter.Size = new System.Drawing.Size(80, 23);
            this.btnApplyCustomDelimiter.TabIndex = 4;
            this.btnApplyCustomDelimiter.Text = "Apply";
            this.btnApplyCustomDelimiter.UseVisualStyleBackColor = true;
            this.btnApplyCustomDelimiter.Visible = false;
            this.btnApplyCustomDelimiter.Click += new System.EventHandler(this.btnApplyCustomDelimiter_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(220, 400);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // mbCSVImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
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
            this.Text = "Map CSV Columns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
