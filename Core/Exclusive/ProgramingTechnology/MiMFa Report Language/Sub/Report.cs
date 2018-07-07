using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Configuration;
using System.IO;
using MiMFa_Framework.Exclusive.Collection.Instance;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage
{
    [Serializable]
    public class Report : MiMFa_Instance
    {
        public static string Extension = ".mrp";

        public double RSID { get; set; }
        public override string Name { get; set; } = "Default";
        public string Address { get; set; } = "/My Folder/My Reports/";

        public ReportStyle Style { get; set; } = new ReportStyle();
        public object[] ObjectArray { get; set; } = null;
        public Type Type { get; set; } = typeof(Report);
        private string _HTML = "";
        public string HTML
        {
            get
            {
                AccessDate = Default.Date;
                AccessTime = Default.Time;
                return _HTML;
            }
            set { _HTML = value; }
        }
        public MiMFa_Date CreateDate { get; set; } = null;
        public MiMFa_Time CreateTime { get; set; } = null;
        public MiMFa_Date AccessDate { get; set; } = null;
        public MiMFa_Time AccessTime { get; set; } = null;
        public string CreatorName { get; set; } = "";
        public MiMFa_Accessibility Accessablity { get; set; } = MiMFa_Accessibility.User;

        public Report(
            string name = "Default",
            ReportStyle style = null,
            string html = "",
            Object extra = null,
            Type type = null,
            params object[] objectArray)
        {
            Set(
                name,
                style,
                html,
                extra,
                type,
                objectArray);
        }
        public Report(Report report)
        {
            Set( report);
        }
        public void Set(Report report)
        {
            Set(
            report.Name,
            report.Style,
            report.HTML,
            report.Extra,
            report.Type,
            report.ObjectArray);
        }
        public void Set(
        string name = "Default",
        ReportStyle style = null,
        string html = "",
        Object extra = null,
        Type type = null,
        params object[] objectArray)
        {
            Name = name;
            if (style != null) Style.Set(style);
            RSID = Style.RSID;
            ObjectArray = objectArray;
            Type = type;
            _HTML = html;
            Extra = extra;
            CreateDate = Default.Date;
            CreateTime = Default.Time;
            MiMFa_Path.CreateAllDirectories(Address);
        }
        public string GetPath()
        {
            return Path.GetFullPath(Address);
        }
    }
}
