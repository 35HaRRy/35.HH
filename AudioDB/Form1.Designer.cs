namespace AudioDB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gvAudios = new System.Windows.Forms.DataGridView();
            this.fBD = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTotal = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Performers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Album = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.editSelectedFileWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkSDElemntsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvAudios)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvAudios
            // 
            this.gvAudios.AllowUserToAddRows = false;
            this.gvAudios.AllowUserToDeleteRows = false;
            this.gvAudios.AllowUserToOrderColumns = true;
            this.gvAudios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvAudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAudios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvSelected,
            this.FileName,
            this.Titles,
            this.TrackNo,
            this.Performers,
            this.Album,
            this.Edit});
            this.gvAudios.Location = new System.Drawing.Point(12, 64);
            this.gvAudios.Name = "gvAudios";
            this.gvAudios.Size = new System.Drawing.Size(648, 181);
            this.gvAudios.TabIndex = 6;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 37);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(672, 24);
            this.menu.TabIndex = 9;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listUpdateToolStripMenuItem,
            this.listDataBaseToolStripMenuItem,
            this.checkSDElemntsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // listUpdateToolStripMenuItem
            // 
            this.listUpdateToolStripMenuItem.Name = "listUpdateToolStripMenuItem";
            this.listUpdateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listUpdateToolStripMenuItem.Text = "List - Update";
            this.listUpdateToolStripMenuItem.Click += new System.EventHandler(this.btnList_Click);
            // 
            // listDataBaseToolStripMenuItem
            // 
            this.listDataBaseToolStripMenuItem.Name = "listDataBaseToolStripMenuItem";
            this.listDataBaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listDataBaseToolStripMenuItem.Text = "List - DataBase";
            this.listDataBaseToolStripMenuItem.Click += new System.EventHandler(this.btnDBList_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSelectedFileToolStripMenuItem,
            this.editSelectedFileWithToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editSelectedFileToolStripMenuItem
            // 
            this.editSelectedFileToolStripMenuItem.Name = "editSelectedFileToolStripMenuItem";
            this.editSelectedFileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editSelectedFileToolStripMenuItem.Text = "Edit Selected File";
            // 
            // gvSelected
            // 
            this.gvSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gvSelected.FillWeight = 10F;
            this.gvSelected.HeaderText = "";
            this.gvSelected.Name = "gvSelected";
            // 
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.DataPropertyName = "FilePath";
            this.FileName.FillWeight = 97.58388F;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            // 
            // Titles
            // 
            this.Titles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Titles.DataPropertyName = "Title";
            this.Titles.FillWeight = 97.58388F;
            this.Titles.HeaderText = "Title";
            this.Titles.Name = "Titles";
            // 
            // TrackNo
            // 
            this.TrackNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TrackNo.DataPropertyName = "Tarck";
            this.TrackNo.FillWeight = 15.0129F;
            this.TrackNo.HeaderText = "#";
            this.TrackNo.Name = "TrackNo";
            // 
            // Performers
            // 
            this.Performers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Performers.DataPropertyName = "Performers";
            this.Performers.FillWeight = 97.58388F;
            this.Performers.HeaderText = "Performers";
            this.Performers.Name = "Performers";
            // 
            // Album
            // 
            this.Album.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Album.DataPropertyName = "Album";
            this.Album.FillWeight = 97.58388F;
            this.Album.HeaderText = "Album";
            this.Album.Name = "Album";
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle5.NullValue")));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.DefaultCellStyle = dataGridViewCellStyle5;
            this.Edit.FillWeight = 10F;
            this.Edit.HeaderText = "";
            this.Edit.Image = global::AudioDB.Properties.Resources.edit;
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.ToolTipText = "Edit";
            // 
            // editSelectedFileWithToolStripMenuItem
            // 
            this.editSelectedFileWithToolStripMenuItem.Name = "editSelectedFileWithToolStripMenuItem";
            this.editSelectedFileWithToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editSelectedFileWithToolStripMenuItem.Text = "Edit Selected File With";
            // 
            // checkSDElemntsToolStripMenuItem
            // 
            this.checkSDElemntsToolStripMenuItem.Name = "checkSDElemntsToolStripMenuItem";
            this.checkSDElemntsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.checkSDElemntsToolStripMenuItem.Text = "Check SD - Elements";
            this.checkSDElemntsToolStripMenuItem.Click += new System.EventHandler(this.btnCheckSDElemnts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 261);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.gvAudios);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gvAudios)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvAudios;
        private System.Windows.Forms.FolderBrowserDialog fBD;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listDataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedFileToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titles;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Performers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Album;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.ToolStripMenuItem editSelectedFileWithToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkSDElemntsToolStripMenuItem;


    }
}

