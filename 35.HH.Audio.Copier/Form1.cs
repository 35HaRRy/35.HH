using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FileCopier
{
    public partial class Form1 : Form
    {
        #region Items
        public FileInfo[] sourceFiles;
        public char sourceRule = '-';

        public string sourcePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Musics\";
        public string destionationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Yabancı\";
        
        public List<string> copiedFileNames = new List<string>();
        #endregion

        public Form1()
        {
            InitializeComponent();

            LoadForm();
        }

        #region Utils
        private void LoadForm()
        {
            string message = "";
            string resultMessage = "";

            string sourceRuleName = "";
            string lastRuleName = "";

            int sourceRuleNameCount = 0;

            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            sourceFiles = sourceDirectory.GetFiles().OrderBy(x => x.Name).ToArray<FileInfo>();
            
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
                resultMessage += string.Format("\nDosyaların bazıları kopylanamadı. Lütfen kontrol ediniz.\nKopyalanan dosya sayısı: {0}. Kaynak dosya sayısı: {1}\nKopyalanamayan dosyalar:", copiedFileNames.Count, sourceFiles.Length);
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
            fInfo.CopyTo(path + @"\" + fInfo.Name, true);
            copiedFileNames.Add(fInfo.Name);
        }
        #endregion
    }
}