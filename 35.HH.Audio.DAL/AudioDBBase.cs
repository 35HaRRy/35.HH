using System;
using System.Data;

using _35.HH.Core;

using PixelSoftOffice.Data;

namespace _35.HH.AudioDAL
{
    public class AudioDBBase : Base
    {
        public AudioDBBase()
        {
            //DataRow dr = Functions.GetSqlInstances(true).Rows[0];
            //connection.ConnectionString = connection.ConnectionString.Replace("#DBPath#", Functions.GetProjectPath("35.HH")).Replace("#DataSource#", dr["ServerName"] + "\\" + dr["InstanceName"]);
            
            connection.ConnectionString = connection.ConnectionString.Replace("#DBPath#", Functions.GetProjectPath("35.HH"));
        }
    }
}
