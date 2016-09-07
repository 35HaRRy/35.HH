namespace _35.HH.MusicMaster
{
    partial class Master
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.msMain = new _35.HH.MusicMaster.MainMenuStrip();
            this.tsmiPrograms = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAudioDB = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDownloader = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenamer = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Location = new System.Drawing.Point(0, 27);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(284, 235);
            this.tbcMain.TabIndex = 1;
            this.tbcMain.Visible = false;
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrograms});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(284, 24);
            this.msMain.TabIndex = 0;
            // 
            // tsmiPrograms
            // 
            this.tsmiPrograms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopier,
            this.tsmiAudioDB,
            this.tsmiDownloader,
            this.tsmiRenamer});
            this.tsmiPrograms.Name = "tsmiPrograms";
            this.tsmiPrograms.Size = new System.Drawing.Size(70, 20);
            this.tsmiPrograms.Text = "Programs";
            // 
            // tsmiCopier
            // 
            this.tsmiCopier.Name = "tsmiCopier";
            this.tsmiCopier.Size = new System.Drawing.Size(152, 22);
            this.tsmiCopier.Text = "Copier";
            this.tsmiCopier.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // tsmiAudioDB
            // 
            this.tsmiAudioDB.Name = "tsmiAudioDB";
            this.tsmiAudioDB.Size = new System.Drawing.Size(152, 22);
            this.tsmiAudioDB.Text = "AudioDB";
            this.tsmiAudioDB.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // tsmiDownloader
            // 
            this.tsmiDownloader.Name = "tsmiDownloader";
            this.tsmiDownloader.Size = new System.Drawing.Size(152, 22);
            this.tsmiDownloader.Text = "Downloader";
            this.tsmiDownloader.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // tsmiRenamer
            // 
            this.tsmiRenamer.Name = "tsmiRenamer";
            this.tsmiRenamer.Size = new System.Drawing.Size(152, 22);
            this.tsmiRenamer.Text = "Renamer";
            this.tsmiRenamer.Click += new System.EventHandler(this.dBToolStripMenuItem_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.msMain);
            this.Name = "Master";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainMenuStrip msMain;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrograms;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopier;
        private System.Windows.Forms.ToolStripMenuItem tsmiAudioDB;
        private System.Windows.Forms.ToolStripMenuItem tsmiDownloader;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenamer;
    }
}