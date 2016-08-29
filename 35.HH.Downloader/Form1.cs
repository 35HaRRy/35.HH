using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.YouTube.v3.Data;

using YoutubeExtractor;

using _35.HH.Core;

namespace Downloader
{
    public partial class Form1 : Form
    {
        #region Properities
        public XDocument doc;
        public YouTubeService youtubeService;
        
        private static int fileCount = 0;
        private int completedFileCount = 0;
        private Boolean isProgress
        {
            get { return fileCount != completedFileCount; }
        }

        private string downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musics\\";
        private string urlFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\links.html"; 
        #endregion

        public Form1()
        {
            InitializeComponent();

            //new Thread(new ThreadStart(waitMessage)).Start();

            txtDownloadFolder.Text = downloadFolder;
            txtUrlFile.Text = urlFile;

            //doc = XDocument.Parse(File.ReadAllText(txtUrlFile.Text).Replace("&", "ampersan"));
            //try
            //{
            //    RunApi().Wait();
            //}
            //catch (AggregateException ex)
            //{
            //    SetApiError(ex);
            //}
        }

        #region BtnEvents
        private void btnDialog_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "btnUrlFile")
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtUrlFile.Text = ofd.FileName;
            }
            else
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    txtDownloadFolder.Text = fbd.SelectedPath;
            }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!isProgress)
            {
                lblTotal.SetCounter(0);
                lblDownloading.SetCounter(0);
                lblExtracting.SetCounter(0);
                lblSuccessful.SetCounter(0);
                lblUnSuccessful.SetCounter(0);

                gvFiles.Rows.Clear();
                completedFileCount = fileCount = 0;
                DownloadFromFile(txtUrlFile.Text); 
            }
        }
        #endregion

        #region GridView Events
        private void gvFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                Process.Start(gvFiles.Rows[e.RowIndex].Cells[0].Value.ToString());
            else if (e.ColumnIndex == 5)
                new Thread(() => DownloadAudio(gvFiles.Rows[e.RowIndex].Cells[0].Value.ToString())).Start();
        } 
        #endregion

        #region AudioDownload Events
        private void audioDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            AudioDownloader audioDownloader = sender as AudioDownloader;
            DataGridViewRow gvr = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.Equals(audioDownloader.Video.Title)).ToList().First();

            UpdateRow(gvr, "% " + (e.ProgressPercentage * 0.85), audioDownloader.Video.Title, "İndiriliyor", 0);

            if (e.ProgressPercentage == 0)
                lblDownloading.IncreaseCounter();
        }
        private void audioDownloader_AudioExtractionProgressChanged(object sender, ProgressEventArgs e)
        {
            AudioDownloader audioDownloader = sender as AudioDownloader;
            DataGridViewRow gvr = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.Equals(audioDownloader.Video.Title)).ToList().First();
            UpdateRow(gvr, "% " + (85 + e.ProgressPercentage * 0.15), audioDownloader.Video.Title, "İndirme Tamamlandı. Çıkartılıyor", 0);

            if (e.ProgressPercentage == 0)
                lblExtracting.IncreaseCounter();
        }
        private void audioDownloader_DownloadFinished(object sender, EventArgs e)
        {
            AudioDownloader audioDownloader = sender as AudioDownloader;
            DataGridViewRow gvr = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.Equals(audioDownloader.Video.Title)).ToList().First();
            UpdateRow(gvr, "% 100", audioDownloader.Video.Title, "Başarıyla tamamlandı.", 1);

            lblSuccessful.IncreaseCounter();
            
            FinishProcesses();
        }
        #endregion

        #region Utils
        private void SetApiError(AggregateException ex)
        {
            string errMsg = "";
            foreach (var e in ex.InnerExceptions)
                errMsg += e.Message;

            MessageBox.Show(errMsg);
        }
        private bool PrepareErrorList()
        {
            List<DataGridViewRow> errorList = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[2].Value.Equals("% 0")).ToList();
            if (errorList.Count() > 0)
            {
                StreamWriter sw = File.AppendText(txtDownloadFolder.Text + "logs.html");
                string format = "<tr style=\"background-color:red; \"><td><a href=\"{0}\">{0}</a></td><td>{1}</td><td>{2}</td></tr>";

                sw.WriteLine("<table style=\"color:white; width:100%;\">");
                errorList.ForEach(x => sw.WriteLine(format, x.Cells[0].Value, x.Cells[3].Value, DateTime.Now));
                sw.Write("</table>");
                
                //errorList.ForEach(x => sw.WriteLine(x.Cells[5].Value));

                sw.Close();

                Process.Start(txtDownloadFolder.Text + "logs.html");

                return false;
            }
            else
                return true;
        }

        private DataGridViewRow GetNewRow(string link, string nodeString)
        {
            DataGridViewRow gvr = new DataGridViewRow();
            gvr.CreateCells(gvFiles);

            gvr.Cells[0].Value = link;
            gvr.Cells[1].Value = "";
            gvr.Cells[2].Value = "% 0";
            gvr.Cells[3].Value = "İndirme işlemi başladı.";
            gvr.Cells[4].Value = Properties.Resources.Downloading;
            gvr.Cells[5].Value = nodeString;

            return gvr;
        }
        private void UpdateRow(DataGridViewRow gvr, string progress, string title, string message, int messageType)
        {
            DataGridViewRow gvrUpdate = new DataGridViewRow();
            gvrUpdate.CreateCells(gvFiles);
            gvrUpdate.Cells[0].Value = gvr.Cells[0].Value;
            gvrUpdate.Cells[4].Value = Properties.Resources.Downloading;
            gvrUpdate.Cells[5].Value = gvr.Cells[5].Value;

            gvrUpdate.Cells[1].Value = title;
            gvrUpdate.Cells[2].Value = progress;
            gvrUpdate.Cells[3].Value = message;
            if (messageType != 0)
                gvrUpdate.Cells[4].Value = messageType == 1 ? Properties.Resources.Successful : Properties.Resources.Error;

            gvr.SetValues(gvrUpdate.Cells.Cast<DataGridViewCell>().Select(x => x.Value).ToArray());
        }
        private void FinishProcesses()
        {
            completedFileCount++;
            if (!isProgress)
            {
                string[] successfuls = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[2].Value.Equals("% 100")).Select(x => x.Cells[5].Value.ToString()).ToArray();

                if(PrepareErrorList())
                    MessageBox.Show(txtUrlFile.Text + " deki dosyalar indirildi.");
            }
        }
        #endregion

        #region YoutubeApiUtils
        private async Task RunApi()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows for read-only access to the authenticated 
                    // user's account, but not other types of account access.
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );
            }

            youtubeService = new YouTubeService(
                new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.GetType().ToString()
                });

            string url;
            foreach (XElement element in doc.Root.Elements())
            {
                url = element.Elements().First().Attributes().First().Value.Replace("ampersan", "&");

                if (url.Contains("watch?v="))
                {
                    try
                    {
                        var newPlaylistItem = new PlaylistItem();
                        newPlaylistItem.Snippet = new PlaylistItemSnippet();
                        newPlaylistItem.Snippet.PlaylistId = "PLklI4fp4DoMg5jgJ1LOuBYoNbzJ4Nmi4A";
                        newPlaylistItem.Snippet.ResourceId = new ResourceId();
                        newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
                        newPlaylistItem.Snippet.ResourceId.VideoId = url.Split('/').Last().Split('&').First().Replace("watch?v=", "");
                        newPlaylistItem = youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").Execute();

                        //Console.WriteLine("Playlist item id {0} was added", newPlaylistItem.Id);
                        Console.WriteLine(url + ",");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("hatalı url " + url + "Hata : " + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region DownloadAudioUtils
        private void DownloadAudio(string link)
        {
            DownloadAudio(link, "");
        }
        private void DownloadAudio(string link, string nodeString)
        {
            DataGridViewRow gvr = GetNewRow(link, nodeString);
            try
            {
                Functions.AddRow(gvFiles, gvr);

                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);
                VideoInfo video = videoInfos.Where(info => info.CanExtractAudio).OrderByDescending(info => info.AudioBitrate).First();
                AudioDownloader audioDownloader = new AudioDownloader(video, Path.Combine(txtDownloadFolder.Text, video.Title + video.AudioExtension));

                UpdateRow(gvr, "% 0", audioDownloader.Video.Title, "İndiriliyor", 0);

                audioDownloader.DownloadProgressChanged += audioDownloader_DownloadProgressChanged;
                audioDownloader.AudioExtractionProgressChanged += audioDownloader_AudioExtractionProgressChanged;
                audioDownloader.DownloadFinished += audioDownloader_DownloadFinished;

                audioDownloader.Execute();
            }
            catch (Exception ex)
            {
                UpdateRow(gvr, gvr.Cells[2].Value.ToString(), gvr.Cells[1].Value.ToString(), ex.Message, -1);
                FinishProcesses();
            }
        }
        private void DownloadFromFile(string filePath)
        {
            string alltext = File.ReadAllText(filePath).Replace("&", "ampersan");
            doc = XDocument.Parse(alltext);
            fileCount = doc.Root.Elements().Count();

            foreach (XElement element in doc.Root.Elements())
                new Thread(() => DownloadAudio(element.Elements().First().Attributes().First().Value.Replace("ampersan", "&"), element.ToString())).Start();
        }
        private void DownloadFromChrome(dynamic bookmarks)
        {
            gvFiles.Rows.Clear();
            completedFileCount = 0;
            fileCount = bookmarks.Count;

            int count = 0;
            foreach (dynamic bookmark in bookmarks)
            {
                new Thread(() => DownloadAudio(bookmark.url.ToString(), bookmark.ToString())).Start();
                if (count++ == 4)
                    break;
            }
        }
        #endregion
    }
}