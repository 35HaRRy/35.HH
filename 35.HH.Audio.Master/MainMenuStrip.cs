using System.Windows.Forms;

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
