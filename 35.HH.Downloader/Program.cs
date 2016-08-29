using System;
using System.Threading;
using System.Windows.Forms;

namespace Downloader
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new YoutubeDownloader());
        }
    }
}