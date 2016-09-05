using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using _35.HH.AudioDAL;

using PixelSoftOffice.Data;

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
                sqlParams.Add(new SqlParameter("@FilePath", audioFile.Name));
                sqlParams.Add(new SqlParameter("@Title", audioFile.Tag.Title.ToDBValue()));
                sqlParams.Add(new SqlParameter("@Album", audioFile.Tag.Album.ToDBValue()));
                sqlParams.Add(new SqlParameter("@Performers", string.Join(", ", audioFile.Tag.Performers).ToDBValue()));
                sqlParams.Add(new SqlParameter("@Composers", string.Join(", ", audioFile.Tag.Composers).ToDBValue()));
                sqlParams.Add(new SqlParameter("@Duration", audioFile.Properties.Duration.TotalSeconds));
                sqlParams.Add(new SqlParameter("@Track", Convert.ToInt32(audioFile.Tag.Track)));
                sqlParams.Add(new SqlParameter("@TrackCount", Convert.ToInt32(audioFile.Tag.TrackCount)));
                sqlParams.Add(new SqlParameter("@Genres", string.Join(", ", audioFile.Tag.Genres).ToDBValue()));
                sqlParams.Add(new SqlParameter("@Lyrics", audioFile.Tag.Lyrics.ToDBValue()));
                sqlParams.Add(new SqlParameter("@Conductor", audioFile.Tag.Conductor.ToDBValue()));
                sqlParams.Add(new SqlParameter("@Copyright", audioFile.Tag.Copyright.ToDBValue()));
                sqlParams.Add(new SqlParameter("@Comment", audioFile.Tag.Comment.ToDBValue()));
                //sqlParams.Add(new SqlParameter("@Pictures", string.Join(", ", audioFile.Tag.Pictures)));
                sqlParams.Add(new SqlParameter("@Description", audioFile.Properties.Description.ToDBValue()));
                sqlParams.Add(new SqlParameter("@PossiblyCorrupt", audioFile.PossiblyCorrupt.ToDBValue()));
                sqlParams.Add(new SqlParameter("@CorruptionReasons", audioFile.CorruptionReasons.ToDBValue()));

                sqlParams.Add(new SqlParameter("@Length", file.Length));
                sqlParams.Add(new SqlParameter("@CreationTime", file.CreationTime));
                sqlParams.Add(new SqlParameter("@LastWriteTime", file.LastWriteTime));
                sqlParams.Add(new SqlParameter("@RegDate", DateTime.Now));

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
