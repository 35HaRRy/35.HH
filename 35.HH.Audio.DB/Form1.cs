using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using _35.HH.Core;
using _35.HH.Audio.DAL;

namespace AudioDB
{
    public partial class Form1 : Form
    {
        #region Properities
        private AudioDAL AudioDAL;

        private string rootPath;

        private string resultMessage;

        private int finishedThreadCount;
        private int finishedWorkerCount;

        //private Size editCellSize;

        private int pageSize = 20;
        public List<TagLib.File> audioFiles = new List<TagLib.File>();
        #endregion

        public Form1()
        {
            InitializeComponent();

            LoadForm();
        }

        #region BtnEvents
        private void btnList_Click(object sender, EventArgs e)
        {
            fBD.Description = "Choose Musics director";
            if (fBD.ShowDialog().Equals(DialogResult.OK))
            {
                new Thread(new ThreadStart(() =>
                {
                    rootPath = fBD.SelectedPath;

                    gvAudios.RowsClear();
                    //ListAudoFile();
                    ListAudoFile2();
                })).Start();
            }
            //else
            //    MessageBox.Show("Root director is empty");
        }
        private void btnDBList_Click(object sender, EventArgs e)
        {
            gvAudios.AutoGenerateColumns = false;
            gvAudios.DataSource = AudioDAL.GetAudios();
        }
        private void btnCheckSDElemnts_Click(object sender, EventArgs e)
        {
            string sdPath = null;
            string elementPath = null;

            fBD.Description = "Choose SD director";
            if (fBD.ShowDialog().Equals(DialogResult.OK))
                sdPath = fBD.SelectedPath;

            fBD.Description = "Choose Elements director";
            if (fBD.ShowDialog().Equals(DialogResult.OK))
                elementPath = fBD.SelectedPath;

            if (!string.IsNullOrEmpty(sdPath) && !string.IsNullOrEmpty(elementPath))
            {
                string[] sdFiles = Directory.GetFiles(sdPath, "*.*", SearchOption.AllDirectories).Select(x => x.Replace(sdPath, "")).ToArray();
                string[] elementFiles = Directory.GetFiles(elementPath, "*.*", SearchOption.AllDirectories).Select(x => x.Replace(elementPath, "")).ToArray();

                string[] differentSDFiles = sdFiles.Where(x => !elementFiles.Contains(x)).Select(x => sdPath + x).ToArray();
                string[] differentElementFiles = elementFiles.Where(x => !sdFiles.Contains(x) && (x.Split('.').Last() == "mp3" || x.Split('.').Last() == "flv")).Select(x => elementPath + x).ToArray();

                if (differentSDFiles.Length > 0 || differentElementFiles.Length > 0)
                {
                    string logFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\DifferentList.txt";
                    File.WriteAllText(logFilePath, string.Join("\n", differentSDFiles.Concat(differentElementFiles).ToArray()));

                    Process.Start(logFilePath);

                    if (MessageBox.Show("Copy files ?") == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (string differentSDFile in differentSDFiles)
                            //File.Copy(differentSDFile, differentSDFile.Replace(sdPath, elementPath));
                            CopyFile(differentSDFile, sdPath, elementPath);

                        foreach (string differentElementFile in differentElementFiles)
                            //File.Copy(differentElementFile, differentElementFile.Replace(elementPath, sdPath));
                            CopyFile(differentElementFile, elementPath, sdPath);
                    }
                }
            }
            else
                MessageBox.Show("SD or Elements directory is empty");
        }
        #endregion

        #region WorkerEvents
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            SetAudoFile(e.Argument.ToString());
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finishedWorkerCount++;
        }
        #endregion

        #region BindingSource Events
        private void bsAudios_CurrentChanged(object sender, EventArgs e)
        {
            IEnumerable<TagLib.File> remainingFiles = audioFiles.Skip((int)bsAudios.Current * pageSize);
            //gvAudios.DataSource = remainingFiles.Count() < pageSize ? remainingFiles : remainingFiles.Take(pageSize);
            gvAudios.SetPropertyInThread("DataSource", remainingFiles.Count() < pageSize ? remainingFiles : remainingFiles.Take(pageSize));
        }
        #endregion

        #region Bindings
        private void ListAudoFile()
        {
            resultMessage = "";

            AudioDAL.DeleteAudios();

            string[] filePaths = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);
            lblTotal.SetText("Total " + filePaths.Length);

            bnAudios.BindingSource = bsAudios;
            bsAudios.DataSource = new PageOffsetList();

            List<Thread> threads = new List<Thread>();
            finishedThreadCount = 0;

            foreach (string filePath in filePaths)
            {
                //if (CheckThreadLimit(threads))
                //{
                //    Thread thread = new Thread(new ThreadStart(() => SetAudoFile(filePath)));
                //    threads.Add(thread);

                //    thread.Start();
                //}

                SetAudoFile(filePath);
            }

            if (!string.IsNullOrEmpty(resultMessage))
                //MessageBox.Show(resultMessage);
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ErrorLog.txt", resultMessage);
        }
        private void ListAudoFile2()
        {
            resultMessage = "";

            AudioDAL.DeleteAudios();

            string[] filePaths = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);
            lblTotal.SetText("Total " + filePaths.Length);
            
            //bnAudios.SetPropertyInThread("BindingSource", bsAudios);
            //bnAudios.SetBindingSourceSource(bsAudios, new PageOffsetList());

            List<BackgroundWorker> workers = new List<BackgroundWorker>();
            finishedWorkerCount = 0;

            foreach (string filePath in filePaths)
            {
                if (CheckWorkerLimit(workers))
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += worker_DoWork;
                    worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                    workers.Add(worker);

                    worker.RunWorkerAsync(filePath);
                }
            }

            if (!string.IsNullOrEmpty(resultMessage))
                MessageBox.Show(resultMessage);
        }

        class PageOffsetList : IListSource
        {
            public bool ContainsListCollection { get; protected set; }
            public int TotalFileCount = 0;

            private int pageSize = 20;

            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < TotalFileCount; offset += pageSize)
                    pageOffsets.Add(offset);

                return pageOffsets;
            }
        }
        #endregion

        #region Utils
        private void LoadForm()
        {
            AudioDAL = new AudioDAL();

            //rootPath = fBD.SelectedPath = "C:\\Users\\hayri.PIXELSOFTOFFICE\\Desktop\\Hayri\\Music";
            rootPath = fBD.SelectedPath = "F:\\Music";
        }

        private void SetAudoFile(string filePath)
        {
            int messageType = 0;
            string message = "";

            try
            {
                TagLib.File audioFile = TagLib.File.Create(filePath);

                AudioDAL.InsertUpdateAudioFile(audioFile, out message, out messageType);
                audioFiles.Add(audioFile);
                //gvAudios.AddRow(GetNewRow(audioFile));

                bnAudios.SetPropertyInThread("BindingSource", bsAudios);
                bnAudios.SetBindingSourceSource(bsAudios, new PageOffsetList() { TotalFileCount = audioFiles.Count });

                //if (audioFiles.Count() % pageSize == 0)
                    bsAudios.Position = audioFiles.Count() / pageSize;
            }
            catch (Exception ex)
            {
                resultMessage += ex.Message + "\n";
            }

            finishedThreadCount++;
        }

        private DataGridViewRow GetNewRow(TagLib.File audioFile)
        {
            DataGridViewRow gvr = new DataGridViewRow();
            gvr.CreateCells(gvAudios);
            
            gvr.Cells[1].Value = audioFile.Name;
            gvr.Cells[2].Value = audioFile.Tag.Title;
            gvr.Cells[3].Value = audioFile.Tag.TrackCount;
            gvr.Cells[4].Value = string.Join(", ", audioFile.Tag.Performers);
            gvr.Cells[5].Value = audioFile.Tag.Album;

            return gvr;
        }

        private void CopyFile(string sourceFilePath, string sourceDirectoryPath, string destionDirectoryPath)
        {
            string destionationFilePath = sourceFilePath.Replace(sourceDirectoryPath + "\\", "");

            string destionationSubDirectoryPath = destionationFilePath.Replace(destionationFilePath.Split('\\').Last(), "");
            if (!string.IsNullOrEmpty(destionationSubDirectoryPath))
            {
                if (!Directory.Exists(destionDirectoryPath + "\\" + destionationSubDirectoryPath))
                    Directory.CreateDirectory(destionDirectoryPath + "\\" + destionationSubDirectoryPath);
            }

            File.Copy(sourceFilePath, destionDirectoryPath + "\\" + destionationFilePath);
        }

        private Boolean CheckThreadLimit(List<Thread> threads)
        {
            int threadLimit = 100;
            int runningThreadCount = threads.Count - finishedThreadCount;

            if (runningThreadCount < threadLimit)
                return true;
            else
            {
                Thread.Sleep(1000);
                return CheckThreadLimit(threads);
            }
        }
        private Boolean CheckWorkerLimit(List<BackgroundWorker> workers)
        {
            int workerLimit = 300;
            //int runningWorkerCount = workers.Count - finishedWorkerCount;
            int runningWorkerCount = workers.Count - workers.Count(x => !x.IsBusy);

            if (runningWorkerCount < workerLimit)
                return true;
            else
            {
                Thread.Sleep(1000);
                return CheckWorkerLimit(workers);
            }
        }
        #endregion
    }
}