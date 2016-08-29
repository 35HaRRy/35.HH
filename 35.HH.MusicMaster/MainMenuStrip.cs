using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _35.HH.MusicMaster
{
    public partial class MainMenuStrip : MenuStrip
    {
        public MainMenuStrip()
        {
            InitializeComponent();

            LoadControl();
        }

        #region Utils
        private void LoadControl()
        {
            //ToolStripItem itmOptions = new ToolStripMenuItem("Options");
            //itmOptions.Click += itmOptions_Click;

            //this.Items.Add(itmOptions);
        }
        #endregion
    }
}
