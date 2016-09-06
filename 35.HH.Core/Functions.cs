using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Reflection;
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
        
        public static DataTable GetSqlInstances(Boolean isLocal = false)
        {
            DataTable dt = new DataTable();

            if (isLocal)
            {
                dt.Columns.Add("ServerName");
                dt.Columns.Add("InstanceName");

                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    RegistryKey rk = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                    string[] instances = rk.GetValue("InstalledInstances") as string[];

                    if (instances.Length > 0)
                    {
                        foreach (string element in instances)
                            dt.Rows.Add(Environment.MachineName, element);
                    }
                }
            }
            else
                dt = SqlDataSourceEnumerator.Instance.GetDataSources();

            return dt;
        }
    }
}