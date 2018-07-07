using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Service;
using System.IO;
using MiMFa_Framework.General;
using Aspose.Words;

namespace MiMFa_Framework.Component.WinForm.Browser
{
    public partial class LogViewer : Browser
    {
        [CategoryAttribute]
        public event EventHandler ValueChanged = (o, e) => { };
        public static SaveFileDialog SFD { get; set; } = new SaveFileDialog();

        public string StartHTML = @"<html style='width:100%; overflow-x:hidden; overflow-y:hidden;'><head><meta charset='UTF-8'/>
                <style>
                    body {
	                padding: 10;
	                margin: 0;
	                border: 0;
                    overflow-x:hidden;
                }
                </style></head><body>";
        public string EndHTML = "</body></html>";

        public bool AllowTopMenu { get { return toolStrip1.Visible; } set { toolStrip1.Visible = value; } }
        public bool AllowContentMenu
        {
            get { return !StartHTML.Contains(offcontextmenu); }
            set
            {
                StartHTML.Replace(offcontextmenu, "");
                if (value) StartHTML = StartHTML.Substring(0, StartHTML.Length - 2) + offcontextmenu + ">";
            }
        }
        private string offcontextmenu = " oncontextmenu='return false;'";
        public int AlertMethod { get { return tscmb_Alert.SelectedIndex; } set { tscmb_Alert.SelectedIndex = value; } }
        public int HeadFrequency { get; set; } = 800;
        public int SuccessFrequency { get; set; } = 1000;
        public int ErrorFrequency { get; set; } = 3500;
        public int MessageFrequency { get; set; } = 800;
        public LogViewer()
        {
            InitializeComponent();
            Clear();
        }

        public void Clear()
        {
            MiMFa_ControlService.WebBrowserDocument(ref Browser, StartHTML + EndHTML);
        }

        public HtmlElement Head(string message, string element = "P", string tagstyle = "color: #111; text-align: center; font-size: 16pt;", params KeyValuePair<string, string>[] attributes)
        {
            if (AlertMethod > 0) Console.Beep(HeadFrequency,AlertMethod*200);
            return Append(message, element, tagstyle, attributes);
        }
        public HtmlElement Message(string message, string element = "P", string tagstyle = "color: #555; font-size: 14pt;", params KeyValuePair<string, string>[] attributes)
        {
            if (AlertMethod > 0) Console.Beep(MessageFrequency,AlertMethod*50);
            return Append(message, element, tagstyle, attributes);
        }
        public HtmlElement Success(string message, string element = "P", string tagstyle = "color: #5a5; font-size: 12pt;", params KeyValuePair<string, string>[] attributes)
        {
            if (AlertMethod > 0) Console.Beep(SuccessFrequency,AlertMethod*100);
            return Append(message, element, tagstyle, attributes);
        }
        public HtmlElement Error(string message, string element = "P", string tagstyle = "color: #a55; font-size: 12pt;", params KeyValuePair<string, string>[] attributes)
        {
            if (AlertMethod > 0) Console.Beep(ErrorFrequency,AlertMethod*100);
            return Append(message, element, tagstyle , attributes);
        }

        public HtmlElement Image(string src, string element = "IMG", string tagstyle = "max-width: 95%; max-height: 300px;", params KeyValuePair<string, string>[] attributes)
        {
            if (attributes == null) attributes = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("src", src) };
            else
            {
                var ls = attributes.ToList();
                ls.Add(new KeyValuePair<string, string>("src", src));
                attributes = ls.ToArray();
            }
            return Append(null, element, tagstyle, attributes);
        }
        public HtmlElement Link(string anchor,string url, string element = "A", string tagstyle = "font-size: 12pt;", params KeyValuePair<string, string>[] attributes)
        {
            if (attributes == null) attributes = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("href", url) };
            else
            {
                var ls = attributes.ToList();
                ls.Add(new KeyValuePair<string, string>("href", url));
                attributes = ls.ToArray();
            }
            return Append(anchor, element, tagstyle,attributes);
        }
        public HtmlElement Button(string text,string url, string element = "A", string tagstyle = "background: #eef; color: #449; font-size: 14pt; font-wieght: bold; padding: 15px; margin: 10px; border: 3px solid #449; border-radius: 5px;", params KeyValuePair<string, string>[] attributes)
        {
            return Link(text,url,element,tagstyle,attributes);
        }
        public HtmlElement Button(string text, string element = "BUTTON", string tagstyle = "background: #eef; color: #449; font-size: 14pt; font-wieght: bold; padding: 15px; margin: 10px; border: 3px solid #449; border-radius: 5px; width: auto; cursor: pointer;", params KeyValuePair<string, string>[] attributes)
        {
            return Append(text, element, tagstyle, attributes);
        }
        public HtmlElement ButtonInDiv(string text, string element = "BUTTON", string tagstyle = "background: #eef; color: #449; font-size: 14pt; font-wieght: bold; padding: 15px; margin: 10px; border: 3px solid #449; border-radius: 5px; width: auto; cursor: pointer;", string divtagstyle = "text-align: center; width: 100%;", params KeyValuePair<string, string>[] attributes)
        {
            HtmlElement div = GetElement(null, "DIV", divtagstyle);
            HtmlElement button = GetElement(text,element,tagstyle,attributes);
            div.AppendChild(button);
            return Append(div);
        }
        public HtmlElement TextBox(string value="",string placeholder="", string element = "INPUT", string tagstyle = "background: #fff; color: #449; font-size: 14pt; font-wieght: bold; padding: 10px; margin: 10px; border: 3px solid #449; width: 95%;", params KeyValuePair<string, string>[] attributes)
        {
            if (attributes == null) attributes = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("type", "text"), new KeyValuePair<string, string>("placeholder", placeholder), new KeyValuePair<string, string>("value", value) };
            else
            {
                var ls = attributes.ToList();
                ls.AddRange(new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("type", "text"), new KeyValuePair<string, string>("placeholder", placeholder), new KeyValuePair<string, string>("value", value) });
                attributes = ls.ToArray();
            }
            return Append(null, element, tagstyle,attributes);
        }
        public HtmlElement TextBoxInDiv(string value = "", string placeholder = "", string element = "INPUT", string tagstyle = "background: #eef; color: #449; font-size: 14pt; font-wieght: bold; padding: 15px; margin: 10px; border: 3px solid #449; border-radius: 5px; width: 95%;", string divtagstyle = "text-align: center; width: 100%;", params KeyValuePair<string, string>[] attributes)
        {
            HtmlElement div = GetElement(null, "DIV", divtagstyle);
            if (attributes == null) attributes = new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("type", "text"), new KeyValuePair<string, string>("placeholder", placeholder), new KeyValuePair<string, string>("value", value) };
            else
            {
                var ls = attributes.ToList();
                ls.AddRange(new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("type", "text"), new KeyValuePair<string, string>("placeholder", placeholder), new KeyValuePair<string, string>("value", value) });
                attributes = ls.ToArray();
            }
            HtmlElement textbox = GetElement(null, element, tagstyle, attributes); 
            div.AppendChild(textbox);
            return Append(div);
        }
        public HtmlElement Code(string message, string element = "XMP", string tagstyle = "margin: 20px; padding: 10px; border: 1px solid black;font-size: 11pt;", params KeyValuePair<string, string>[] attributes)
        {
            return Append(message, element, tagstyle, attributes);
        }

        public HtmlElement HorizontalLine(params KeyValuePair<string, string>[] attributes) => Append(null,"HR", null,attributes);
        public HtmlElement BreakLine(params KeyValuePair<string, string>[] attributes) => Append(null,"BR", null,attributes);

        public HtmlElement Append(string message, string element = "P", string tagstyle = "",params KeyValuePair<string,string>[] attributes)
        {
            return Append(GetElement(message, element, tagstyle, attributes));
        }
        public HtmlElement Append(HtmlElement elem)
        {
            Browser.Document.Body.AppendChild(elem);
            if(!Browser.Focused) Browser.Document.Body.ScrollTop = Browser.Document.Body.ScrollRectangle.Size.Height;
            return elem;
        }
        public HtmlElement GetElement(string message, string element = "P", string tagstyle = "",params KeyValuePair<string,string>[] attributes)
        {
            HtmlElement elem = Browser.Document.CreateElement(element);
            if (tagstyle != null) elem.Style = tagstyle;
            if (message != null) elem.InnerText = message;
            if (attributes != null && attributes.Length > 0)
                foreach (var item in attributes)
                    elem.SetAttribute(item.Key,item.Value);
            return elem;
        }
        public void ShowJust(string html)
        {
            MiMFa_ControlService.WebBrowserDocument(ref Browser, html);
            Browser.Document.Body.ScrollTop = Browser.Document.Body.ScrollRectangle.Size.Height;
        }

        private void tsb_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void tsb_Back_Click(object sender, EventArgs e)
        {
            Browser.GoBack();
        }
        private void tsb_Next_Click(object sender, EventArgs e)
        {
            Browser.GoForward();
        }
        private void tsb_print_Click(object sender, EventArgs e)
        {
            Browser.ShowPrintDialog();
        }
        private void tsb_printprev_Click(object sender, EventArgs e)
        {
            Browser.ShowPrintPreviewDialog();
        }
        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFD.Filter = "Adobe Acrobat Reader File (*.pdf) | *.pdf";
            SFD.FileName = "Log";
            if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
                Output(Aspose.Words.SaveFormat.Pdf, SFD.FileName, false);
        }
        private void docToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFD.Filter = "Microsoft Word File (*.doc) | *.doc | Microsoft Word File (*.docx) | *.docx | Rich Text Format File (*.rtf) | *.rtf | Text File (*.txt) | *.txt";
            SFD.FileName = "Log";
            if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
                switch (System.IO.Path.GetExtension(SFD.FileName).ToLower())
                {
                    case ".docx":
                        Output(Aspose.Words.SaveFormat.Docx, SFD.FileName, false);
                        break;
                    case ".txt":
                        Output(Aspose.Words.SaveFormat.Text, SFD.FileName, false);
                        break;
                    case ".rtf":
                        Output(Aspose.Words.SaveFormat.Rtf, SFD.FileName, false);
                        break;
                    default:
                        Output(Aspose.Words.SaveFormat.Doc, SFD.FileName, false);
                        break;
                }
        }
        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFD.Filter = @"JPEG File (*.jpeg, *.jpg) | *.jpg | PNG File (*.png) | *.png | BMP File (*.bmp) | *.bmp | TIFF File (*.tif, *.tiff) | *.tiff | GIF File (*.gif) | *.gif | EMF File (*.emf) | *.emf ";
            SFD.FileName = "Log";
            if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
            {
                MiMFa_Convert.ToImage(this.Browser.DocumentText, SFD.FileName, Browser.Document.Body.ScrollRectangle.Size, false);
            }
        }

        private void Output(SaveFormat to, string fileName, bool openforce)
        {
            Exclusive.Extension.MiMFa_Convert pc = new Exclusive.Extension.MiMFa_Convert();
            string addr = Config.TempDirectory + System.DateTime.Now.Ticks + "htmlimportlogoutput.html";
            MiMFa_IOService.StringToFile(addr, Browser.DocumentText);
            pc.To(addr, fileName, to, openforce);
        }

    }
}
