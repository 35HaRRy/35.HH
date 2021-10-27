using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

using _35.HH.Core;

namespace _35.HH.Copier
{
    public partial class Copier : Form
    {
        #region Items
        public FileInfo[] sourceFiles;
        public char sourceRule = '-';

        public string sourcePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Source\";
        public string destionationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Downloaded Musics\Yabancı\";

        public List<string> copiedFileNames = new List<string>();
        #endregion

        public Copier()
        {
            InitializeComponent();

            new Thread(new ThreadStart(LoadForm)).Start();
        }

        #region Utils
        private void LoadForm()
        {
            lbResult.ItemsClear();

            string message = "";
            string resultMessage = "";

            string sourceRuleName = "";
            string lastRuleName = "";

            int sourceRuleNameCount = 0;

            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            sourceFiles = sourceDirectory.GetFiles().OrderBy(x => x.Name).ToArray<FileInfo>();
            lblSourceFileCount.SetPropertyInThread("Text", sourceFiles.Length.ToString());

            copiedFileNames = new List<string>();
            foreach (FileInfo sourceFile in sourceFiles)
            {
                sourceRuleName = sourceFile.Name.Split(sourceRule)[0].Trim();
                if (sourceRuleName != lastRuleName)
                {
                    if (!string.IsNullOrEmpty(lastRuleName))
                    {
                        CreateNewRuleProcess(lastRuleName, sourceRuleNameCount, out message);
                        resultMessage += message;
                    }

                    lastRuleName = sourceRuleName;
                    sourceRuleNameCount = 1;
                }
                else
                {
                    if (sourceFile.Name.Trim().StartsWith("-"))
                        CopyFile(destionationPath + "Diğer", sourceFile);

                    sourceRuleNameCount++;
                }
            }

            CreateNewRuleProcess(lastRuleName, sourceRuleNameCount, out message);
            resultMessage += message;

            if (sourceFiles.Length > copiedFileNames.Count)
            {
                resultMessage += "\nDosyaların bazıları kopylanamadı. Lütfen kontrol ediniz.\nKopyalanamayan dosyalar:";
                foreach (string fileName in sourceFiles.Select(x => x.Name).Except(copiedFileNames))
                    resultMessage += "\n\t" + fileName;
            }

            if (!string.IsNullOrEmpty(resultMessage))
                MessageBox.Show(resultMessage);
        }

        private void CreateNewRuleProcess(string newRuleName, int newRuleCount, out string message)
        {
            message = "";

            FileInfo[] newRuleFiles = sourceFiles.Where(x => x.Name.Split(sourceRule)[0].Trim() == newRuleName).ToArray<FileInfo>();

            if (newRuleCount == 1)
            {
                try
                {
                    FileInfo newRuleFile = newRuleFiles.Last<FileInfo>();
                    CopyFile(destionationPath + "Diğer", newRuleFile);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                if (Directory.CreateDirectory(destionationPath + newRuleName).Exists)
                {
                    foreach (FileInfo newRuleFile in newRuleFiles)
                    {
                        try
                        {
                            CopyFile(destionationPath + newRuleName, newRuleFile);
                        }
                        catch (Exception ex)
                        {
                            message += ex.Message + "\n";
                        }
                    }
                }
            }
        }
        private void CopyFile(string path, FileInfo fInfo)
        {
            FileInfo copiedFile = fInfo.CopyTo(path + @"\" + fInfo.Name, true);
            if (copiedFile.Exists)
            {
                copiedFileNames.Add(fInfo.Name);

                lblCopiedFileCount.SetPropertyInThread("Text", copiedFileNames.Count.ToString());
                lbResult.AddItem(string.Format(@"""{0}"" dosyası, ""{1}"" klasörüne kopyalandı", fInfo.Name, path));
            }

            Thread.Sleep(200);
        }
        #endregion
    }
}