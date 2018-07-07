using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using MiMFa_Framework.Exclusive.Collection.Instance;
using MiMFa_Framework.Framework.Model_Format_Layer.Execute;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;

namespace MiMFa_Framework.Framework.Model_Format_Layer.Execute
{
    public class ReportStyles : Execute<ReportStyle>
    {
        public ReportStyles(MiMFa_Framework.Exclusive.ProgramingTechnology.DataBase.MiMFa_SQLite msql) : base(msql)
        {
        }
        public override string TableName => "ReportStyles";
        public override ReportStyle DefaultConstructor => new ReportStyle();
        public override bool DefaultIFNotExist { get; set; } = false;
        public override Dictionary<string, string> ColumnDic
        {
            get
            {
                Dictionary<string, string> cdic = new Dictionary<string, string>();
                cdic.Add("RSID", MSQL.TYPE.DOUBLE + " NOT NULL");
                cdic.Add("Style", MSQL.TYPE.BLOB);
                cdic.Add("UID", MSQL.TYPE.TEXT + " NOT NULL, PRIMARY KEY (ID)");
                return cdic;
            }
        }
    }
}