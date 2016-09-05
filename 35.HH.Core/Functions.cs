using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Data.Sql;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace _35.HH.Core
{
    public static class Functions
    {
        public static string GetStringFromObject(Object value)
        {
            string result = "";

            if (value != null)
                result = value.ToString();

            return result;
        }

        #region Set&Craete
        delegate void AddRowCallback(DataGridView gv, DataGridViewRow gc);
        delegate void UpdateRowCellsCallback(DataGridView gv, DataGridViewRow gvr, DataGridViewCellCollection gvrCells);
        delegate void AddColumnCallback(DataGridView gv, DataGridViewColumn gc);
        delegate void SetVisibiltyCallback(Control control, Boolean visible);
        delegate void SetTextCallback(Control control, string newText);
        delegate void AddItemCallback(ListBox lb, object item);
        delegate void ItemsClearCallback(ListBox lb);
        delegate void RowsClearCallback(DataGridView dgv);

        delegate void SetPropertyCallback(Control control, string propertyName, object value);
        delegate void SetBindingSourceCallback(BindingNavigator bn, BindingSource bs, IListSource datasource);

        delegate void ProcessDelegate();

        public static void AddRow(this DataGridView gv, DataGridViewRow gvr)
        {
            if (gv.InvokeRequired)
            {
                AddRowCallback _gvr = new AddRowCallback(AddRow);
                gv.Invoke(_gvr, new object[] { gv, gvr });
            }
            else
                gv.Rows.Add(gvr);
        }
        public static void UpdateRowCells(this DataGridView gv, DataGridViewRow gvr, DataGridViewCellCollection gvrCells)
        {
            if (gv.InvokeRequired)
            {
                UpdateRowCellsCallback _gvr = new UpdateRowCellsCallback(UpdateRowCells);
                gv.Invoke(_gvr, new object[] { gv, gvr, gvrCells });
            }
            else
                gvr.SetValues(gvrCells.Cast<DataGridViewCell>().Select(x => x.Value).ToArray());
        }
        public static void AddColumn(this DataGridView gv, DataGridViewColumn gc)
        {
            if (gv.InvokeRequired)
            {
                AddColumnCallback _gc = new AddColumnCallback(AddColumn);
                gv.Invoke(_gc, new object[] { gv, gc });
            }
            else
                gv.Columns.Add(gc);
        }
        public static void SetVisibilty(this Control control, Boolean visible)
        {
            if (control.InvokeRequired)
            {
                SetVisibiltyCallback _visible = new SetVisibiltyCallback(SetVisibilty);
                control.Invoke(_visible, new object[] { control, visible });
            }
            else
                control.Visible = visible;
        }
        public static void SetText(this Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextCallback _text = new SetTextCallback(SetText);
                control.Invoke(_text, new object[] { control, text });
            }
            else
                control.Text = text;
        }
        public static void AddItem(this ListBox lb, object item)
        {
            if (lb.InvokeRequired)
            {
                AddItemCallback _gvr = new AddItemCallback(AddItem);
                lb.Invoke(_gvr, new object[] { lb, item });
            }
            else
                lb.Items.Add(item);
        }
        public static void ItemsClear(this ListBox lb)
        {
            if (lb.InvokeRequired)
            {
                ItemsClearCallback _gvr = new ItemsClearCallback(ItemsClear);
                lb.Invoke(_gvr, new object[] { lb });
            }
            else
                lb.Items.Clear();
        }
        public static void RowsClear(this DataGridView dgv)
        {
            if (dgv.InvokeRequired)
            {
                RowsClearCallback _dgv = new RowsClearCallback(RowsClear);
                dgv.Invoke(_dgv, new object[] { dgv });
            }
            else
                dgv.Rows.Clear();
        }

        public static void SetPropertyInThread(this Control control, string propertyName, object value)
        {
            if (control.InvokeRequired)
            {
                SetPropertyCallback _control = new SetPropertyCallback(SetPropertyInThread);
                control.Invoke(_control, new object[] { control, propertyName, value });
            }
            else
                control.SetProperty(propertyName, value);
        }
        public static void SetBindingSourceSource(this BindingNavigator bn, BindingSource bs, IListSource datasource)
        {
            if (bn.InvokeRequired)
            {
                SetBindingSourceCallback _bn = new SetBindingSourceCallback(SetBindingSourceSource);
                bn.Invoke(_bn, new object[] { bn, bs, datasource });
            }
            else
                bs.DataSource = datasource;
        }
        public static void SetProperty(this Control control, string propertyName, object value)
        {
            PropertyInfo pInfo = control.GetType().GetProperty(propertyName);
            if (pInfo != null)
                pInfo.SetValue(control, value);
        }
        #endregion

        #region FileUtils
        public static long GetDirectoryFileSize(string directoryPath)
        {
            long size = 0;

            string[] filePaths = Directory.GetFiles(directoryPath, "*.*", System.IO.SearchOption.AllDirectories);
            foreach (string filePath in filePaths)
                size += new FileInfo(filePath).Length;

            return size;
        }
        public static string GetProjectPath(string projectName)
        {
            string[] pathItems = Assembly.GetExecutingAssembly().Location.Split('\\');
            return string.Join("\\", pathItems.TakeWhile(x => x != projectName).ToArray()) + "\\" + projectName + "\\";
        }

        public static string GetMimeFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename + " not found");

            byte[] buffer = new byte[256];
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                if (fs.Length >= 256)
                    fs.Read(buffer, 0, 256);
                else
                    fs.Read(buffer, 0, (int)fs.Length);
            }
            try
            {
                System.UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);

                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                string mime = Marshal.PtrToStringUni(mimeTypePtr);

                Marshal.FreeCoTaskMem(mimeTypePtr);

                return mime;
            }
            catch (Exception e)
            {
                return "unknown/unknown";
            }
        }

        public static List<string> AudioFileMimeTypes = new string[] { "application/octet-stream", "audio/audible", "audio/aac", "audio/vnd.audible.aax", "audio/ac3", "audio/vnd.dlna.adts", "audio/aac", "audio/x-aiff", "audio/aiff", "audio/basic", "audio/x-caf", "audio/x-gsm", "audio/x-mpegurl", "audio/x-mpegurl", "audio/m4a", "audio/m4b", "audio/m4p", "audio/x-m4r", "audio/mid", "audio/mid", "audio/mpeg", "audio/scpls", "audio/x-pn-realaudio", "audio/x-pn-realaudio", "audio/x-pn-realaudio-plugin", "audio/x-sd2", "audio/x-smd", "audio/basic", "audio/wav", "audio/wav", "audio/x-ms-wax", "audio/x-ms-wma" }.ToList();

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBC,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        ); 
        #endregion

        #region Drawing
        public static Bitmap Resize(this Bitmap img, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, size.Width, size.Height);
            }

            return b;
        }
        #endregion

        #region Utils
        public static DataTable GetSqlInstances(Boolean isLocal = false)
        {
            DataTable dt = new DataTable();

            if (isLocal)
            {
                dt.Columns.Add("ServerName");
                dt.Columns.Add("InstanceName");

                //RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names");
                //string[] instances = rk.GetValue("InstalledInstances") as string[];

                //if (instances.Length > 0)
                //{
                //    foreach (string element in instances)
                //        dt.Rows.Add(Environment.MachineName, element);
                //}


                Microsoft.SqlServer.Management.Smo.SmoApplication.EnumAvailableSqlServers
            }
            else
                dt = SqlDataSourceEnumerator.Instance.GetDataSources();

            return dt;
        }
        #endregion
    }
}