using MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage;
using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.Display
{
    public class MiMFa_DisplayHTML : MiMFa_DisplayStringBase
    {
        public Size Size { get; set; } = new Size(0,0);
        public override bool Translate { get; set; } = false;

        public override string StartSign { get; set; } = "";
        public override string MiddleSign { get; set; } = "->";
        public override string EndSign { get; set; } = "";
        public override string SplitSign { get; set; } = " ";
        public override string BreakSign { get; set; } = "<br>";
        public override string TabSign { get; set; } = "\t ";
        public override string BreakLineSign { get; set; } = "<hr>";
        public override string Table_ { get; set; } = "<table>";
        public override string TableRow_ { get; set; } = "<tr>";
        public override string TableCell_ { get; set; } = "<td>";
        public override string _TableCell { get; set; } = "</td>";
        public override string _TableRow { get; set; } = "</tr>";
        public override string _Table { get; set; } = "</table>";
        public virtual string Hilight_ { get; set; } = "<span style='color: white; background-color: blue;'>";
        public virtual string _Hilight { get; set; } = "</span>";
        public override Func<string, string> Highlight { get; set; } = (s) => "<span style='color: red; background-color: yellow;'>" + s + "</span>"; 
        public override String Done(EventPack arg)
        {
            string str = "";
            str += "<input type='button' value='" + Done("Open") + "' " + arg.Before;
            str += " "+ arg.Name + "='";
            str +=  arg.Target + "' ";
            str += arg.After + "' />";
            return str;
        }
        public override String Done(Bitmap arg)
        {
            if (arg == null) return "";
            string address = TempDirectory + DateTime.Now.Ticks + ".img";
            arg.Save(address);
            string siz = "height='100%'";
            if(arg.Height < arg.Width && Size.Width <= Size.Height) siz = "width='100%'";
            return "<img src='" + address + "' "+siz+" class='AutoIMG'/>";
        }
        public override String Done(Uri arg)
        {
            return "<a href='" + arg.OriginalString + "'>" + Done("Open") + "</a>";
        }
        public override String Done(byte[] arg)
        {
            if (arg == null) return "";
            string ext = "data";
            try { ext = MiMFa_GetDetail.GetMimeObject(arg).Split('/').Last().Trim().Split(' ').First(); } catch { }
            string address = TempDirectory + DateTime.Now.Ticks + "." +( (ext == "unknown")?"mp4": ext);
            System.IO.File.WriteAllBytes(address, arg);
            return "<button src='" + address + "' class='AutoBTN' >" + Done("Download") + "</button>";
            //return @"<a href='" + address+"' class='AutoBTN' >" + Done("Download") + "</a>";
        }

    }
}
