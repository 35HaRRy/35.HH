namespace FileCopier
{
    partial class Form1
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
            this.lbResult = new System.Windows.Forms.ListBox();
            this.lblSourceFileCountTitle = new System.Windows.Forms.Label();
            this.lblSourceFileCount = new System.Windows.Forms.Label();
            this.lblCopiedFileCountTitle = new System.Windows.Forms.Label();
            this.lblCopiedFileCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbResult
            // 
            this.lbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResult.FormattingEnabled = true;
            this.lbResult.Location = new System.Drawing.Point(13, 39);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(637, 199);
            this.lbResult.TabIndex = 0;
            // 
            // lblSourceFileCountTitle
            // 
            this.lblSourceFileCountTitle.AutoSize = true;
            this.lblSourceFileCountTitle.Location = new System.Drawing.Point(13, 13);
            this.lblSourceFileCountTitle.Name = "lblSourceFileCountTitle";
            this.lblSourceFileCountTitle.Size = new System.Drawing.Size(138, 13);
            this.lblSourceFileCountTitle.TabIndex = 1;
            this.lblSourceFileCountTitle.Text = "Kopyalanacak Dosya Sayısı";
            // 
            // lblSourceFileCount
            // 
            this.lblSourceFileCount.AutoSize = true;
            this.lblSourceFileCount.Location = new System.Drawing.Point(166, 13);
            this.lblSourceFileCount.Name = "lblSourceFileCount";
            this.lblSourceFileCount.Size = new System.Drawing.Size(0, 13);
            this.lblSourceFileCount.TabIndex = 2;
            // 
            // lblCopiedFileCountTitle
            // 
            this.lblCopiedFileCountTitle.AutoSize = true;
            this.lblCopiedFileCountTitle.Location = new System.Drawing.Point(191, 13);
            this.lblCopiedFileCountTitle.Name = "lblCopiedFileCountTitle";
            this.lblCopiedFileCountTitle.Size = new System.Drawing.Size(126, 13);
            this.lblCopiedFileCountTitle.TabIndex = 1;
            this.lblCopiedFileCountTitle.Text = "Kopyalanan Dosya Sayısı";
            // 
            // lblCopiedFileCount
            // 
            this.lblCopiedFileCount.AutoSize = true;
            this.lblCopiedFileCount.Location = new System.Drawing.Point(344, 13);
            this.lblCopiedFileCount.Name = "lblCopiedFileCount";
            this.lblCopiedFileCount.Size = new System.Drawing.Size(0, 13);
            this.lblCopiedFileCount.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(671, 261);
            this.Controls.Add(this.lblCopiedFileCount);
            this.Controls.Add(this.lblSourceFileCount);
            this.Controls.Add(this.lblCopiedFileCountTitle);
            this.Controls.Add(this.lblSourceFileCountTitle);
            this.Controls.Add(this.lbResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbResult;
        private System.Windows.Forms.Label lblSourceFileCountTitle;
        private System.Windows.Forms.Label lblSourceFileCount;
        private System.Windows.Forms.Label lblCopiedFileCountTitle;
        private System.Windows.Forms.Label lblCopiedFileCount;
    }
}

