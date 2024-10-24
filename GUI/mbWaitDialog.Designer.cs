
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.Windows.Forms;

namespace GL8.CORE
{
    partial class mbWaitDialog
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
            this.mbWaitDialogLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // mbWaitDialogLabel1
            // 
            this.mbWaitDialogLabel1.AutoSize = true;
            this.mbWaitDialogLabel1.Depth = 0;
            this.mbWaitDialogLabel1.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mbWaitDialogLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.mbWaitDialogLabel1.Location = new System.Drawing.Point(86, 119);
            this.mbWaitDialogLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbWaitDialogLabel1.Name = "mbWaitDialogLabel1";
            this.mbWaitDialogLabel1.Size = new System.Drawing.Size(355, 41);
            this.mbWaitDialogLabel1.TabIndex = 0;
            this.mbWaitDialogLabel1.Text = "Working - Please Wait...";
            this.mbWaitDialogLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mbWaitDialogLabel1.UseWaitCursor = true;
            // 
            // mbWaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(490, 208);
            this.ControlBox = false;
            this.Controls.Add(this.mbWaitDialogLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mbWaitDialog";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GL8 - Please Wait";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel mbWaitDialogLabel1;
    }
}