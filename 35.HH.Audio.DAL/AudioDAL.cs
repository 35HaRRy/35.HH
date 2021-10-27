using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using PixelSoftOffice.Web.Extensions;

namespace _35.HH.Audio.DAL
{
    public class AudioDAL
    {
        public void InsertUpdateAudioFile(TagLib.File audioFile, out string message, out int messageType)
        {
            try
            {
                FileInfo file = new FileInfo(audioFile.Name);

                if (audioFile.Writeable)
                {
                    string[] fileNameItems = file.Name.Split('-');
                    //if (fileNameItems.Length > 1 && string.IsNullOrEmpty(audioFile.Tag.Title))
                    if (fileNameItems.Length > 1)
                        audioFile.Tag.Title = fileNameItems[1].Split(new string[] { "ft." }, StringSplitOptions.None)[0].Trim().Replace(".mp3", "");

                    if (!string.IsNullOrEmpty(fileNameItems[0]))
                        audioFile.Tag.Performers = new string[] { fileNameItems[0] };

                    fileNameItems = file.Name.Split(new string[] { "ft." }, StringSplitOptions.None);
                    if (fileNameItems.Length > 1)
                        audioFile.Tag.Performers = audioFile.Tag.Performers.Concat(fileNameItems[1].Trim().Replace(".mp3", "").Split(',')).ToArray();

                    audioFile.Save();
                }

                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.AddParameter("@FilePath", audioFile.Name);
                sqlParams.AddParameter("@Title", audioFile.Tag.Title);
                sqlParams.AddParameter("@Album", audioFile.Tag.Album);
                sqlParams.AddParameter("@Performers", string.Join(", ", audioFile.Tag.Performers));
                sqlParams.AddParameter("@Composers", string.Join(", ", audioFile.Tag.Composers));
                sqlParams.AddParameter("@Duration", audioFile.Properties.Duration.TotalSeconds);
                sqlParams.AddParameter("@Track", Convert.ToInt32(audioFile.Tag.Track));
                sqlParams.AddParameter("@TrackCount", Convert.ToInt32(audioFile.Tag.TrackCount));
                sqlParams.AddParameter("@Genres", string.Join(", ", audioFile.Tag.Genres));
                sqlParams.AddParameter("@Lyrics", audioFile.Tag.Lyrics);
                sqlParams.AddParameter("@Conductor", audioFile.Tag.Conductor);
                sqlParams.AddParameter("@Copyright", audioFile.Tag.Copyright);
                sqlParams.AddParameter("@Comment", audioFile.Tag.Comment);
                //sqlParams.AddParameter("@Pictures", string.Join(", ", audioFile.Tag.Pictures));
                sqlParams.AddParameter("@Description", audioFile.Properties.Description);
                sqlParams.AddParameter("@PossiblyCorrupt", audioFile.PossiblyCorrupt);
                sqlParams.AddParameter("@CorruptionReasons", audioFile.CorruptionReasons);

                sqlParams.AddParameter("@Length", file.Length);
                sqlParams.AddParameter("@CreationTime", file.CreationTime);
                sqlParams.AddParameter("@LastWriteTime", file.LastWriteTime);
                sqlParams.AddParameter("@RegDate", DateTime.Now);

                new AudioDBBase().Execute("InsertUpdate_AudioFile", sqlParams, out message, out messageType);
                if (messageType == 0)
                    throw new Exception(message);
            }
            catch (Exception ex)
            {
                messageType = 0;
                message = audioFile.Name + " : " + ex.Message;
            }
        }

        public DataTable GetAudios()
        {
            return new AudioDBBase().Execute("Get_Audios");
        }

        public void DeleteAudios()
        {
            new AudioDBBase().Execute("Delete_Audios");
        }
    }
}
