using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using _35.HH.Core;

namespace FileCopier
{
    public partial class Form1 : Form
    {
        #region Items
        public FileInfo[] sourceFiles;
        public char sourceRule = '-';

        public string sourcePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Musics\";
        public string destionationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Yabancı\";

        public long destionationDirectorySize = 0;
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

            long sourceDirectorySize = 0;
            destionationDirectorySize = 0;

            DirectoryInfo sourceDirectory = new DirectoryInfo(sourcePath);
            sourceFiles = sourceDirectory.GetFiles().OrderBy(x => x.Name).ToArray<FileInfo>();
            
            foreach (FileInfo sourceFile in sourceFiles)
            {
                sourceDirectorySize += sourceFile.Length;
                
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
                    sourceRuleNameCount++;
            }

            CreateNewRuleProcess(lastRuleName, sourceRuleNameCount, out message);
            resultMessage += message;

            if (sourceDirectorySize != destionationDirectorySize)
                resultMessage += "\nDosyaların bazıları kopylanamadı. Lütfen kontrol ediniz.";

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
                    newRuleFile.CopyTo(destionationPath + "Diğer\\" + newRuleFile.Name, true);

                    destionationDirectorySize += newRuleFile.Length;
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
                            newRuleFile.CopyTo(destionationPath + newRuleName + "\\" + newRuleFile.Name, true);
                            destionationDirectorySize += newRuleFile.Length;
                        }
                        catch (Exception ex)
                        {
                            message += ex.Message + "\n";
                        }
                    }
                }
            }
        }
        #endregion
    }
}