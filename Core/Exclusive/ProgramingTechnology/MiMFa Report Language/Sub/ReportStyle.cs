using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.General;
using System.IO;
using MiMFa_Framework.Exclusive.Collection.Instance;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage
{
    [Serializable]
    public class ReportStyle : MiMFa_Instance
    {
        public static string Extension { get; set; } = ".rps";

        public double RSID { get; set; }
        public override string Name { get; set; } = "Default";
        public string Address { get; set; } = "/My Folder/My ReportStyles/";

        public string MRLCode { get; set; } = "";
        public string Css { get; set; } = "";
        public string Script { get; set; } = "";

        public ReportStyle(
                string name = "Default",
                string mrlCode = "",
                string css = "",
                string script = "" ,
                object extra = null)
        {
            Set(name,
                 mrlCode,
                 css,
                 script,
                 extra);
        }
        public ReportStyle(ReportStyle reportStyle)
        {
            Set(reportStyle);
        }
        public ReportStyle(string reportStylePath)
        {
            ReportStyle reportStyle = new ReportStyle();
            Service.MiMFa_IOService.OpenDeserializeFile(reportStylePath, ref reportStyle);
            reportStyle.Address = reportStylePath;
            Set(reportStyle);
        }
        public void Set(ReportStyle reportStyle)
        {
            Set(reportStyle.Name,
             reportStyle.MRLCode,
             reportStyle.Css,
             reportStyle.Script,
             reportStyle.Extra);
        }
        public void Set(
        string name = "Default",
        string mrlCode = "",
        string css = "",
        string script = "",
        object extra = null)
        {
            Name = name;
            MRLCode = mrlCode;
            Css = css;
            Script = script;
            Extra = extra;
            MiMFa_Path.CreateAllDirectories(Address);
        }
        public string GetPath()
        {
            return Path.GetFullPath(Address);
        }

        public static ReportStyle FromAddress(string address)
        {
            return new ReportStyle(address);
        }
    }
}
