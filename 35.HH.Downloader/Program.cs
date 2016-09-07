using System;
using System.Threading;
using System.Windows.Forms;

namespace _35.HH.Downloader
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Downloader());
            Application.Run(new YoutubeDownloader());
        }
    }
}