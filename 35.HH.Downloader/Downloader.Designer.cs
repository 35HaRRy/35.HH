namespace _35.HH.Downloader
{
    partial class Downloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloader));
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.txtUrlFile = new System.Windows.Forms.TextBox();
            this.btnUrlFile = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.btnDownloadFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gvFiles = new System.Windows.Forms.DataGridView();
            this.gvcLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.gvcTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvcProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvcStatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.gvcErrorNodeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.lblExtracting = new System.Windows.Forms.Label();
            this.lblSuccessful = new System.Windows.Forms.Label();
            this.lblUnSuccessful = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrlFile
            // 
            this.txtUrlFile.Location = new System.Drawing.Point(95, 36);
            this.txtUrlFile.Name = "txtUrlFile";
            this.txtUrlFile.Size = new System.Drawing.Size(295, 20);
            this.txtUrlFile.TabIndex = 0;
            // 
            // btnUrlFile
            // 
            this.btnUrlFile.Location = new System.Drawing.Point(406, 34);
            this.btnUrlFile.Name = "btnUrlFile";
            this.btnUrlFile.Size = new System.Drawing.Size(56, 23);
            this.btnUrlFile.TabIndex = 1;
            this.btnUrlFile.Text = "Gözat";
            this.btnUrlFile.UseVisualStyleBackColor = true;
            this.btnUrlFile.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(25, 79);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(910, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "İndir";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadFolder.Location = new System.Drawing.Point(579, 34);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(294, 20);
            this.txtDownloadFolder.TabIndex = 0;
            // 
            // btnDownloadFolder
            // 
            this.btnDownloadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadFolder.Location = new System.Drawing.Point(879, 34);
            this.btnDownloadFolder.Name = "btnDownloadFolder";
            this.btnDownloadFolder.Size = new System.Drawing.Size(56, 23);
            this.btnDownloadFolder.TabIndex = 1;
            this.btnDownloadFolder.Text = "Gözat";
            this.btnDownloadFolder.UseVisualStyleBackColor = true;
            this.btnDownloadFolder.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "İndirme Klasörü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Link Dosyası";
            // 
            // gvFiles
            // 
            this.gvFiles.AllowUserToAddRows = false;
            this.gvFiles.AllowUserToDeleteRows = false;
            this.gvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvcLink,
            this.gvcTitle,
            this.gvcProgress,
            this.gvcStatus,
            this.gvcStatusIcon,
            this.gvcErrorNodeString});
            this.gvFiles.Location = new System.Drawing.Point(25, 145);
            this.gvFiles.Name = "gvFiles";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gvFiles.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFiles.Size = new System.Drawing.Size(910, 311);
            this.gvFiles.TabIndex = 4;
            this.gvFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFiles_CellContentClick);
            // 
            // gvcLink
            // 
            this.gvcLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcLink.FillWeight = 15F;
            this.gvcLink.HeaderText = "Link";
            this.gvcLink.Name = "gvcLink";
            // 
            // gvcTitle
            // 
            this.gvcTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcTitle.FillWeight = 10F;
            this.gvcTitle.HeaderText = "Başlık";
            this.gvcTitle.Name = "gvcTitle";
            // 
            // gvcProgress
            // 
            this.gvcProgress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcProgress.FillWeight = 2F;
            this.gvcProgress.HeaderText = "İndirilen";
            this.gvcProgress.Name = "gvcProgress";
            // 
            // gvcStatus
            // 
            this.gvcStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcStatus.FillWeight = 8F;
            this.gvcStatus.HeaderText = "Durum";
            this.gvcStatus.Name = "gvcStatus";
            // 
            // gvcStatusIcon
            // 
            this.gvcStatusIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcStatusIcon.FillWeight = 1F;
            this.gvcStatusIcon.HeaderText = "";
            this.gvcStatusIcon.Name = "gvcStatusIcon";
            // 
            // gvcErrorNodeString
            // 
            this.gvcErrorNodeString.HeaderText = "";
            this.gvcErrorNodeString.Name = "gvcErrorNodeString";
            this.gvcErrorNodeString.Visible = false;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(22, 120);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Toplam : ";
            // 
            // lblDownloading
            // 
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.Location = new System.Drawing.Point(116, 120);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(52, 13);
            this.lblDownloading.TabIndex = 6;
            this.lblDownloading.Text = "İndirilen : ";
            // 
            // lblExtracting
            // 
            this.lblExtracting.AutoSize = true;
            this.lblExtracting.Location = new System.Drawing.Point(211, 120);
            this.lblExtracting.Name = "lblExtracting";
            this.lblExtracting.Size = new System.Drawing.Size(59, 13);
            this.lblExtracting.TabIndex = 7;
            this.lblExtracting.Text = "Çıkartılan : ";
            // 
            // lblSuccessful
            // 
            this.lblSuccessful.AutoSize = true;
            this.lblSuccessful.Location = new System.Drawing.Point(318, 120);
            this.lblSuccessful.Name = "lblSuccessful";
            this.lblSuccessful.Size = new System.Drawing.Size(49, 13);
            this.lblSuccessful.TabIndex = 8;
            this.lblSuccessful.Text = "Başarılı : ";
            // 
            // lblUnSuccessful
            // 
            this.lblUnSuccessful.AutoSize = true;
            this.lblUnSuccessful.Location = new System.Drawing.Point(394, 120);
            this.lblUnSuccessful.Name = "lblUnSuccessful";
            this.lblUnSuccessful.Size = new System.Drawing.Size(57, 13);
            this.lblUnSuccessful.TabIndex = 9;
            this.lblUnSuccessful.Text = "Başarısız : ";
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(958, 468);
            this.Controls.Add(this.lblUnSuccessful);
            this.Controls.Add(this.lblSuccessful);
            this.Controls.Add(this.lblExtracting);
            this.Controls.Add(this.lblDownloading);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.gvFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnDownloadFolder);
            this.Controls.Add(this.btnUrlFile);
            this.Controls.Add(this.txtDownloadFolder);
            this.Controls.Add(this.txtUrlFile);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Downloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Downloader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.TextBox txtUrlFile;
        private System.Windows.Forms.Button btnUrlFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Button btnDownloadFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvFiles;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.DataGridViewLinkColumn gvcLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcStatus;
        private System.Windows.Forms.DataGridViewImageColumn gvcStatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcErrorNodeString;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.Label lblExtracting;
        private System.Windows.Forms.Label lblSuccessful;
        private System.Windows.Forms.Label lblUnSuccessful;
    }
}

