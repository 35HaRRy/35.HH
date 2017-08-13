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

namespace _35.HH.Downloader
{
    public partial class YoutubeDownloader : Form
    {
        #region Properities
        public XDocument doc;
        public YouTubeService youtubeService;

        public int fileCount
        {
            get
            {
                return lblTotal.GetCounter();
            }
            set
            {
                lblTotal.SetCounter(value);
            }
        }
        private int completedFileCount
        {
            get
            {
                return lblProcessing.GetCounter();
            }
            set
            {
                lblProcessing.SetCounter(value);
            }
        }
        private Boolean isProgress
        {
            get { return fileCount != completedFileCount; }
        }

        private string downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Musics\\";
        private string urlFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\links.html";
        #endregion

        public YoutubeDownloader()
        {
            InitializeComponent();

            try
            {
                RunApi().Wait();
            }
            catch (AggregateException ex)
            {
                SetApiError(ex);
            }

            txtDownloadFolder.Text = downloadFolder;
        }

        #region BtnEvents
        private void btnDialog_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
                txtDownloadFolder.Text = fbd.SelectedPath;
        }
        private void btnSelectedLists_Click(object sender, EventArgs e)
        {
            lblDownloading.SetCounter(0);
            lblExtracting.SetCounter(0);
            lblSuccessful.SetCounter(0);
            lblUnSuccessful.SetCounter(0);

            fileCount = completedFileCount = 0;

            //gvPlayList' deki seçililerin id'leri ile başlat
            DownloadAudioFromApiByListIds(new string[] { "PLklI4fp4DoMg5jgJ1LOuBYoNbzJ4Nmi4A" });
        }
        #endregion

        #region GridView Events
        private void gvFiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                Process.Start(gvFiles.Rows[e.RowIndex].Cells[0].Value.ToString());
            else if (e.ColumnIndex == 5)
                new Thread(() => DownloadAudio(gvFiles.Rows[e.RowIndex].Cells[0].Value.ToString(), gvFiles.Rows[e.RowIndex].Cells[5].Value)).Start();
        }
        #endregion

        #region DownloadAudio Events
        private void audioDownloader_DownloadProgressChanged(object sender, ProgressEventArgs e)
        {
            AudioDownloader audioDownloader = sender as AudioDownloader;
            DataGridViewRow gvr = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.Equals(audioDownloader.Video.Title)).ToList().First();

            UpdateRow(gvr, e.ProgressPercentage * 0.85, audioDownloader.Video.Title, "İndiriliyor", 0);

            if (e.ProgressPercentage == 100)
                lblExtracting.IncreaseCounter();
        }
        private void audioDownloader_AudioExtractionProgressChanged(object sender, ProgressEventArgs e)
        {
            AudioDownloader audioDownloader = sender as AudioDownloader;
            DataGridViewRow gvr = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.Equals(audioDownloader.Video.Title)).ToList().First();
            UpdateRow(gvr, (85.0 + e.ProgressPercentage * 0.15), audioDownloader.Video.Title, "İndirme Tamamlandı. Çıkartılıyor", 0);
        }
        private void audioDownloader_DownloadFinished(object sender, EventArgs e)
        {
            AudioDownloader audioDownloader = sender as AudioDownloader;
            DataGridViewRow gvr = gvFiles.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.Equals(audioDownloader.Video.Title)).ToList().First();
            UpdateRow(gvr, 100, audioDownloader.Video.Title, "Başarıyla tamamlandı.", 1);

            lblSuccessful.IncreaseCounter();

            DeleteFromListWithApi((PlaylistItem)gvr.Cells[5].Value);
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
                string format = "<tr style=\"background-color:red; \"><td><a href=\"{0}\">{1}</a></td><td>{2}</td><td>{3}</td></tr>";

                sw.WriteLine("<table style=\"color:white; width:100%;\">");
                foreach (DataGridViewRow gvr in errorList)
                {
                    if (gvr.Cells[5].Value.GetType() == typeof(PlaylistItem))
                        sw.WriteLine(format, gvr.Cells[0].Value, ((PlaylistItem)gvr.Cells[5].Value).Snippet.Title, gvr.Cells[3].Value, DateTime.Now);
                    else
                        sw.WriteLine(format, gvr.Cells[0].Value, gvr.Cells[0].Value, gvr.Cells[3].Value, DateTime.Now);
                }

                sw.Write("</table>");
                sw.Close();

                Process.Start(txtDownloadFolder.Text + "logs.html");

                return false;
            }
            else
                return true;
        }

        private DataGridViewRow GetNewRow(string link, object linkValue)
        {
            DataGridViewRow gvr = new DataGridViewRow();
            gvr.CreateCells(gvFiles);

            gvr.Cells[0].Value = link;

            if (linkValue.GetType() == typeof(PlaylistItem))
                gvr.Cells[1].Value = ((PlaylistItem)linkValue).Snippet.Title;
            else
                gvr.Cells[1].Value = "";

            //gvr.Cells[2].Value = "% 0";
            gvr.Cells[2].Value = 0;
            gvr.Cells[3].Value = "İndirme işlemi başladı.";
            gvr.Cells[4].Value = Properties.Resources.Downloading;
            gvr.Cells[5].Value = linkValue;

            return gvr;
        }
        //private void UpdateRow(DataGridViewRow gvr, string progress, string title, string message, int messageType)
        private void UpdateRow(DataGridViewRow gvr, double progress, string title, string message, int messageType)
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
                if (PrepareErrorList())
                    MessageBox.Show("İndirme işlemi bitti.");
            }
        }
        #endregion

        #region DownloadAudioUtils
        private void DownloadAudioFromApiByListIds(string[] playListIds)
        {
            foreach (string playListId in playListIds)
            {
                fileCount = 0;

                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    //try
                    {
                        var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
                        playlistItemsListRequest.PlaylistId = playListId;
                        playlistItemsListRequest.MaxResults = 50;
                        playlistItemsListRequest.PageToken = nextPageToken;

                        var playlistItemsListResponse = playlistItemsListRequest.Execute();
                        fileCount += playlistItemsListResponse.Items.Count;

                        foreach (var playlistItem in playlistItemsListResponse.Items)
                        {
                            if (playlistItem.Snippet.Title.IndexOfAny(new char[] { '<', '>', '/', '\\', '?', '*', ':', '"', '|' }) == -1)
                                new Thread(() => DownloadAudio("https://www.youtube.com/watch?v=" + playlistItem.Snippet.ResourceId.VideoId, playlistItem)).Start();
                            else
                            {
                                DataGridViewRow gvr = GetNewRow("https://www.youtube.com/watch?v=" + playlistItem.Snippet.ResourceId.VideoId, "");
                                gvFiles.AddRow(gvr);
                                UpdateRow(gvr, 0.0, playlistItem.Snippet.Title, "Video başlığında '< > : ? / \\ * \" |' karakterleri olmamalı", -1);

                                lblUnSuccessful.IncreaseCounter();

                                FinishProcesses();
                            }
                        }

                        nextPageToken = playlistItemsListResponse.NextPageToken;
                    }
                    //catch (Exception ex)
                    //{
                    //    DataGridViewRow gvr = GetNewRow("http://www.youtube.com/playlist?list=" + playListId, "");
                    //    gvFiles.AddRow(gvr);
                    //    UpdateRow(gvr, 0.0, "", ex.Message, -1);

                        //FinishProcesses();
                    //}
                }
            }
        }
        private void DownloadAudio(string link, object linkValue)
        {
            DataGridViewRow gvr = GetNewRow(link, linkValue);
            try
            {
                gvFiles.AddRow(gvr);

                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(link);
                VideoInfo video = videoInfos.Where(info => info.CanExtractAudio).OrderByDescending(info => info.AudioBitrate).First();
                AudioDownloader audioDownloader = new AudioDownloader(video, Path.Combine(txtDownloadFolder.Text, video.Title + video.AudioExtension));

                UpdateRow(gvr, 0.0, audioDownloader.Video.Title, "İndiriliyor", 0);

                lblDownloading.IncreaseCounter();

                audioDownloader.DownloadProgressChanged += audioDownloader_DownloadProgressChanged;
                audioDownloader.AudioExtractionProgressChanged += audioDownloader_AudioExtractionProgressChanged;
                audioDownloader.DownloadFinished += audioDownloader_DownloadFinished;

                audioDownloader.Execute();
            }
            catch (Exception ex)
            {
                UpdateRow(gvr, Convert.ToInt32(gvr.Cells[2].Value), gvr.Cells[1].Value.ToString(), ex.Message, -1);
                FinishProcesses();

                lblUnSuccessful.IncreaseCounter();
            }
        }
        #endregion

        #region YoutubeApiUtils
        private void DeleteFromListWithApi(PlaylistItem playListItem)
        {
            var playListItemDeleteRequest = youtubeService.PlaylistItems.Delete(playListItem.Id);
            playListItemDeleteRequest.ExecuteAsync();
        }
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

            //var playListsRequest = youtubeService.Playlists.List("snippet");
            //playListsRequest.Mine = true;

            ////var playListsResponse = await playListsRequest.ExecuteAsync();
            //var playListsResponse = playListsRequest.Execute();
            //foreach (var playList in playListsResponse.Items)
            //{
            //    //Console.WriteLine("playList Name : {0}, playListId : {1}", playList.Snippet.Title, playList.Id);
            //}
        }
        #endregion
    }
}