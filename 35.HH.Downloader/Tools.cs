using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using _35.HH.Core;

namespace Downloader
{
    public static class Tools
    {
        public static void IncreaseCounter(this Label lbl)
        {
            lbl.SetCounter(lbl.GetCounter() + 1);
        }
        public static void SetCounter(this Label lbl, int counter)
        {
            lbl.SetText(lbl.Text.Split(new string[] { " : " }, StringSplitOptions.None)[0] + " : " + counter);
        }

        public static int GetCounter(this Label lbl)
        {
            return Convert.ToInt32(lbl.Text.Split(new string[] { " : " }, StringSplitOptions.None)[1]);
        }
    }
}
