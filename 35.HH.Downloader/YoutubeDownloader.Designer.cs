namespace _35.HH.Downloader
{
    partial class YoutubeDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoutubeDownloader));
            this.gvFiles = new System.Windows.Forms.DataGridView();
            this.gvcLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.gvcTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvcProgress = new global::_35.HH.Downloader.DataGridViewProgressColumn();
            this.gvcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvcStatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.gvcErrorNodeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.btnDownloadFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectedLists = new System.Windows.Forms.Button();
            this.dataGridViewProgressColumn1 = new global::_35.HH.Downloader.DataGridViewProgressColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblUnSuccessful = new System.Windows.Forms.Label();
            this.lblSuccessful = new System.Windows.Forms.Label();
            this.lblExtracting = new System.Windows.Forms.Label();
            this.lblDownloading = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblProcessing = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).BeginInit();
            this.SuspendLayout();
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
            this.gvFiles.Location = new System.Drawing.Point(25, 154);
            this.gvFiles.Name = "gvFiles";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gvFiles.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvFiles.Size = new System.Drawing.Size(910, 302);
            this.gvFiles.TabIndex = 4;
            this.gvFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFiles_CellContentClick);
            // 
            // gvcLink
            // 
            this.gvcLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcLink.FillWeight = 12F;
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
            this.gvcProgress.FillWeight = 6F;
            this.gvcProgress.HeaderText = "İndirilen";
            this.gvcProgress.Name = "gvcProgress";
            this.gvcProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gvcProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gvcStatus
            // 
            this.gvcStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvcStatus.FillWeight = 7F;
            this.gvcStatus.HeaderText = "Durum";
            this.gvcStatus.Name = "gvcStatus";
            this.gvcStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(107, 17);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(294, 20);
            this.txtDownloadFolder.TabIndex = 0;
            // 
            // btnDownloadFolder
            // 
            this.btnDownloadFolder.Location = new System.Drawing.Point(407, 17);
            this.btnDownloadFolder.Name = "btnDownloadFolder";
            this.btnDownloadFolder.Size = new System.Drawing.Size(56, 23);
            this.btnDownloadFolder.TabIndex = 1;
            this.btnDownloadFolder.Text = "Gözat";
            this.btnDownloadFolder.UseVisualStyleBackColor = true;
            this.btnDownloadFolder.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "İndirme Klasörü";
            // 
            // btnSelectedLists
            // 
            this.btnSelectedLists.Location = new System.Drawing.Point(484, 17);
            this.btnSelectedLists.Name = "btnSelectedLists";
            this.btnSelectedLists.Size = new System.Drawing.Size(56, 23);
            this.btnSelectedLists.TabIndex = 5;
            this.btnSelectedLists.Text = "Seçili Listelerle Başla";
            this.btnSelectedLists.UseVisualStyleBackColor = true;
            this.btnSelectedLists.Click += new System.EventHandler(this.btnSelectedLists_Click);
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewProgressColumn1.FillWeight = 7F;
            this.dataGridViewProgressColumn1.HeaderText = "Durum";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.FillWeight = 1F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // lblUnSuccessful
            // 
            this.lblUnSuccessful.AutoSize = true;
            this.lblUnSuccessful.Location = new System.Drawing.Point(540, 115);
            this.lblUnSuccessful.Name = "lblUnSuccessful";
            this.lblUnSuccessful.Size = new System.Drawing.Size(57, 13);
            this.lblUnSuccessful.TabIndex = 14;
            this.lblUnSuccessful.Text = "Başarısız : ";
            // 
            // lblSuccessful
            // 
            this.lblSuccessful.AutoSize = true;
            this.lblSuccessful.Location = new System.Drawing.Point(464, 115);
            this.lblSuccessful.Name = "lblSuccessful";
            this.lblSuccessful.Size = new System.Drawing.Size(49, 13);
            this.lblSuccessful.TabIndex = 13;
            this.lblSuccessful.Text = "Başarılı : ";
            // 
            // lblExtracting
            // 
            this.lblExtracting.AutoSize = true;
            this.lblExtracting.Location = new System.Drawing.Point(357, 115);
            this.lblExtracting.Name = "lblExtracting";
            this.lblExtracting.Size = new System.Drawing.Size(57, 13);
            this.lblExtracting.TabIndex = 12;
            this.lblExtracting.Text = "Çıkartma : ";
            // 
            // lblDownloading
            // 
            this.lblDownloading.AutoSize = true;
            this.lblDownloading.Location = new System.Drawing.Point(262, 115);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(50, 13);
            this.lblDownloading.TabIndex = 11;
            this.lblDownloading.Text = "İndirme : ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(32, 115);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 13);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Toplam : ";
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(129, 115);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(106, 13);
            this.lblProcessing.TabIndex = 15;
            this.lblProcessing.Text = "İşlemi Tamamlanan : ";
            // 
            // YoutubeDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(958, 468);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.lblUnSuccessful);
            this.Controls.Add(this.lblSuccessful);
            this.Controls.Add(this.lblExtracting);
            this.Controls.Add(this.lblDownloading);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSelectedLists);
            this.Controls.Add(this.gvFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownloadFolder);
            this.Controls.Add(this.txtDownloadFolder);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YoutubeDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Downloader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFiles;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Button btnDownloadFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button btnSelectedLists;
        private System.Windows.Forms.DataGridViewLinkColumn gvcLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcTitle;
        private DataGridViewProgressColumn gvcProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcStatus;
        private System.Windows.Forms.DataGridViewImageColumn gvcStatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcErrorNodeString;
        private DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblUnSuccessful;
        private System.Windows.Forms.Label lblSuccessful;
        private System.Windows.Forms.Label lblExtracting;
        private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblProcessing;
    }
}

