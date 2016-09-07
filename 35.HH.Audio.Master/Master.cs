using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using _35.HH.Core;

namespace _35.HH.MusicMaster
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();

            LoadControls();
        }

        #region ToolStripMenuItem Events
        private void dBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;

            IsMdiContainer = true;

            IEnumerable<Form> childs = MdiChildren.Where(x => x.Name == tsmi.Text);
            if (childs.Count() == 0)
            {
                Form child = Activator.CreateInstance("35.HH.Audio." + tsmi.Text, "35.HH.Audio." + tsmi.Text + "." + tsmi.Text).Unwrap() as Form;
                child.MdiParent = this;
                child.Show();
            }
            else
            {
                Form child = childs.ElementAt(0);

                ActivateMdiChild(child);
                child.WindowState = FormWindowState.Maximized;
            }

            //Process p = Process.Start(string.Format(@"{0}35.HH.Audio.{1}\bin\debug\{1}.exe", Functions.GetProjectPath("35.HH"), tsmi.Text));
            //Thread.Sleep(500); // Allow the process to open it's window
            //SetParent(p.MainWindowHandle, Handle);

        }
        #endregion

        #region Utils
        private void LoadControls()
        {

        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        #endregion
    }
}
