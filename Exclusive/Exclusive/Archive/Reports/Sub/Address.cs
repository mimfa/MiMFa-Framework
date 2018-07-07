using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.Archive.Reports
{
    public class Address : MiMFa_Framework.Config
    {
        public virtual string ReportsStyle { get; internal set; }
        public string ReportsArchive;
        public string ReportStyleArchivePath;

        public Address() : base()
        {
        }
        public override void DefaultValues()
        {
            base.DefaultValues();
            ReportsStyle = ThisDirectory + @"ReportsStyle\";
            ReportsArchive = ThisDirectory + "ReportsArchive.db";
            ReportStyleArchivePath = ReportsStyle + @"ReportsArchive" + ReportStyle.Extension;
        }
    }
}