namespace AudioRenamer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fBD = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.dgvAudios = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Performers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Album = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // txtBrowse
            // 
            resources.ApplyResources(this.txtBrowse, "txtBrowse");
            this.txtBrowse.Name = "txtBrowse";
            // 
            // dgvAudios
            // 
            resources.ApplyResources(this.dgvAudios, "dgvAudios");
            this.dgvAudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAudios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.Titles,
            this.TrackNo,
            this.Performers,
            this.Album,
            this.Edit});
            this.dgvAudios.Name = "dgvAudios";
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.FillWeight = 130F;
            resources.ApplyResources(this.FileName, "FileName");
            this.FileName.Name = "FileName";
            // 
            // Titles
            // 
            this.Titles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Titles.FillWeight = 130F;
            resources.ApplyResources(this.Titles, "Titles");
            this.Titles.Name = "Titles";
            // 
            // TrackNo
            // 
            this.TrackNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TrackNo.FillWeight = 20F;
            resources.ApplyResources(this.TrackNo, "TrackNo");
            this.TrackNo.Name = "TrackNo";
            // 
            // Performers
            // 
            this.Performers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Performers.FillWeight = 130F;
            resources.ApplyResources(this.Performers, "Performers");
            this.Performers.Name = "Performers";
            // 
            // Album
            // 
            this.Album.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Album.FillWeight = 130F;
            resources.ApplyResources(this.Album, "Album");
            this.Album.Name = "Album";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.FillWeight = 60F;
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Image = global::AudioRenamer.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit.FillWeight = 60F;
            resources.ApplyResources(this.Edit, "Edit");
            this.Edit.Image = global::AudioRenamer.Properties.Resources.edit;
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAudios);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnBrowse);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fBD;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.DataGridView dgvAudios;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titles;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Performers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Album;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}

