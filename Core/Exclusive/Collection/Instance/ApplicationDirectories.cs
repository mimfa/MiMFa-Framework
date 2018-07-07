using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.General;
using System.Reflection;

namespace MiMFa_Framework.Exclusive.Collection.Instance
{
    public class MiMFa_ApplicationDirectories : Config
    {
        public string SecuritySetTableName = "Security";
        public string SystemSetTableName = "System";
        public string ViewSetTableName = "View";

        public string dbPath;
        public string dbDataPath;
        public string dbSettingPath;
        public string dbTemporaryPath;
        public string dbBackupPath;

        public string TableName = "MFT";
        public string HeavyTableName = "HeavyData";
        public string TempTableName = "Temp";
        public string LogTableName = "Log";

        public string LogRecoveryFileAddress;
        public string UILConfigurationAddress;
        public string CLLConfigurationAddress;
        public string MFLConfigurationAddress;
        public string SHIConfigurationAddress;
        public string FrameWorksConfigurationAddress;
        public string ArchiveReportStyleAddress;

        public string DefaultAddress;
        public string FullFileAddress;

        public new string ThisDirectory { get; set; }
        public new string ConfigurationDirectory { get; set; }
        public new string TempDirectory { get; set; }
        public new string LogDirectory { get; set; }
        public string DataTempDirectory { get; set; }
        public virtual string DataDirectory { get; set; }
        public virtual string BaseDirectory { get; set; }
        public virtual string LanguageDirectory { get; set; }
        public virtual string ViewDirectory { get; set; }
        public virtual string FileDirectory { get; set; }
        public virtual string TemplateDirectory { get; set; }
        public virtual string ComponentDirectory { get; set; }
        public virtual string PluginDirectory { get; set; }

        public virtual string DefaultDirectory { get; set; }
        public virtual string ThemeDirectory { get; set; }

        public MiMFa_ApplicationDirectories() : base()
        {
            DefaultValues();
            CreateAllPath();
        }
        public override void DefaultValues()
        {
            ThisDirectory = ApplicationPath;
            base.DefaultValues();
            ThisDirectory = ApplicationPath;
            ConfigurationDirectory = ThisDirectory + @"Configuration\";
            TempDirectory = ThisDirectory + @"Temp\";
            LogDirectory = ThisDirectory + @"Log\";
            DataDirectory = ThisDirectory + @"Data\";
            BaseDirectory = ThisDirectory + @"Base\";
            LanguageDirectory = ThisDirectory + @"Language\";
            ViewDirectory = ThisDirectory + @"View\";
            FileDirectory = ThisDirectory + @"My Files\";
            TemplateDirectory = ThisDirectory + @"Template\";
            ComponentDirectory = ThisDirectory + @"Component\";
            PluginDirectory = ThisDirectory + @"Plugin\";

            DataTempDirectory = TempDirectory + @"Data\";
            DefaultDirectory = ConfigurationDirectory + @"Default\";
            ThemeDirectory = ViewDirectory + @"Theme\";

            dbPath = DataDirectory + @"Main" + DataBaseExtension;
            dbDataPath = DataDirectory + @"Data" + DataBaseExtension;
            dbSettingPath = DataDirectory + @"Setting" + DataBaseExtension;
            dbTemporaryPath = DataDirectory + @"Temporary" + DataBaseExtension;
            dbBackupPath = DataDirectory + @"Backup" + DataBaseExtension;


            LogRecoveryFileAddress = LogDirectory + @"RecoveryFileAddress" + LogExtension;
            UILConfigurationAddress = ConfigurationDirectory + @"UILC" + ConfigurationExtension;
            CLLConfigurationAddress = ConfigurationDirectory + @"CLLC" + ConfigurationExtension;
            MFLConfigurationAddress = ConfigurationDirectory + @"MFLC" + ConfigurationExtension;
            SHIConfigurationAddress = ConfigurationDirectory + @"SHIC" + ConfigurationExtension;
            FrameWorksConfigurationAddress = ConfigurationDirectory + @"MFWC" + ConfigurationExtension;
            ArchiveReportStyleAddress = DefaultDirectory + @"Archive" + ProgramingTechnology.ReportLanguage.ReportStyle.Extension;

            DefaultAddress = FileDirectory + FileName + FileExtension;
            FullFileAddress = null;
        }


        public virtual  string[] GetOpenFileLogs() => MiMFa_Framework.Service.MiMFa_IOService.FileToStringArray(LogRecoveryFileAddress);
        public virtual  void SetOpenFileLogs(string[] files) => MiMFa_Framework.Service.MiMFa_IOService.StringArrayToFile(LogRecoveryFileAddress, files);
        public  virtual void AppendOpenFileLogs(string file) => MiMFa_Framework.Service.MiMFa_IOService.StringNewLineAppendFile(LogRecoveryFileAddress, file);

        public virtual Dictionary<string, string> GetDicOfRecoveryData()
        {
            string[] files = System.IO.Directory.GetFiles(DataTempDirectory);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (files.Length > 1)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    var fi = new System.IO.FileInfo(files[i]);
                    if (!MiMFa_Path.IsUsingByProccess(files[i]))
                        dic.Add(files[i], (dic.Count + 1) + "- " + Exclusive.Language.MiMFa_LanguageReader.GetText("Date") + " " + MiMFa_Convert.ToMiMFaDate(fi.LastAccessTime).GetDate() + " " + Exclusive.Language.MiMFa_LanguageReader.GetText("On Clock") + " " + MiMFa_Convert.ToMiMFaTime(fi.LastAccessTime).GetTime() + " ---> (" + fi.Length + " byte)");
                }
            }
            return dic;
        }
    }
}
