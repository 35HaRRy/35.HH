using System;

using _35.HH.Core;

using PixelSoftOffice.Data;

namespace _35.HH.AudioDAL
{
    public class AudioDBBase : Base
    {
        public AudioDBBase()
        {
            connection.ConnectionString = connection.ConnectionString.Replace("#DBPath#", Functions.GetProjectPath("35.HH"));
        }
    }
}
