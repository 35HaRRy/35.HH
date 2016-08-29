using System;
using System.IO;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace AudioRenamer
{
    public partial class Form1 : Form
    {
        #region Items
        private string rootPath;
        private string tempPath;
        private string[] folderPaths;

        private int totalFileCount = 0;
        private TagLib.File audioFile; 
        #endregion

        public Form1()
        {
            InitializeComponent();

            PrepareForm();
        }

        #region BtnEvents
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fBD.ShowDialog().Equals(DialogResult.OK))
                txtBrowse.Text = tempPath = rootPath = fBD.SelectedPath;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            totalFileCount = 0;

            if (!String.IsNullOrEmpty(tempPath))
                new Thread(new ThreadStart(SetAudoFile)).Start();
            else
                MessageBox.Show("Root director is empty");
        }
        #endregion

        #region Utils
        private void PrepareForm()
        {
            fBD.RootFolder = Environment.SpecialFolder.Desktop;
        }

        private void SetAudoFile()
        {
            foreach (string filePath in Directory.GetFiles(tempPath))
            {
                totalFileCount++;
            }

            folderPaths = Directory.GetDirectories(tempPath);
            if (folderPaths.Length > 0)
            {
                foreach (string folderPath in folderPaths)
                {
                    tempPath = folderPath;
                    SetAudoFile();
                }
            }
        }
        #endregion
    }
}