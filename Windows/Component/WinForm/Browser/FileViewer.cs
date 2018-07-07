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

namespace MiMFa_Framework.Component.WinForm.Browser
{
    public partial class FileViewer : Browser
    {
        [CategoryAttribute]
        public event EventHandler ValueChanged = (o,e)=> { };
        public Exclusive.Display.MiMFa_DisplayHTML Display = new Exclusive.Display.MiMFa_DisplayHTML();
        public string Path { get; private set; }
        public object Value { get; private set; }
        public bool FullScreenAllowance {  get; set;  } = true;
        public bool AutoStart {  get; set;  } = false;
        public bool SpecialView { get; set; } = true;

        string StartHTML = "<html style='width:100%; overflow-x:hidden;'><head><meta charset='UTF-8'/></head><body style='width:100%; overflow-x:hidden;'>";
        string ShowSimplyStartHTML = @"<html style='width:100%; overflow-x:hidden; overflow-y:hidden;'><head><meta charset='UTF-8'/>
                <style>
                    body {
	                padding: 0;
	                margin: 0;
	                border: 0;
	                outline: 0;
	                font-size: 100%;
	                vertical-align: baseline;
                    text-align:center;
	                background: transparent;
	                line-height: 1;
                    width:100%;
                    overflow-x:hidden;
                    height:100%;
                    overflow-y:hidden;
                }
                </style>
</head><body>";
        string EndHTML = "</body></html>";
        public FileViewer()
        {
            InitializeComponent();
            Display.Size = Size;
        }

        public bool View(object value)
        {
            if (value == null) Clear();
            else if (value is string && Open(value.ToString())) return true;
            else return Show(value);
            return false;
        }

        public bool Open(string path)
        {
            if (!string.IsNullOrEmpty(path))
                if (MiMFa_GetDetail.IsAbsoluteURL(path))
                {
                    Browse(path);
                    return true;
                }
                else
                {
                    string mime = "";
                    try { mime = General.MiMFa_GetDetail.GetMimeFile(path).Split('/')[0].Trim().ToLower(); } catch { }
                    if (mime == "image") ShowBrowser(MiMFa_IOService.TryDeserialize(File.ReadAllBytes(path)), true);
                    else if (mime == "text") ShowBrowser(MiMFa_StringService.ToHTML(MiMFa_IOService.FileToString(path)));
                    else if (mime == "") Clear();
                    else
                    {
                        bool b = General.MiMFa_GetDetail.IsBinaryFile(path);
                        if (b)
                        {
                            string ext = System.IO.Path.GetExtension(path).ToLower();
                            if (ext == ".pdf"
                                || ext.StartsWith(".doc")
                                || ext.StartsWith(".xls")
                                ) OpenBrowser(path);
                            else OpenMediaPlayer(path);
                        }
                        else ShowBrowser(MiMFa_IOService.FileToString(path));
                        return true;
                    }
                }
            else Clear(); 
            return false;
        }
        public void OpenMediaPlayer(string path)
        {
            Clear();
            if (string.IsNullOrEmpty(path)) return;
            Path = path;
            //WMP.Visible = true;
            MiMFa_ControlService.SetControlThreadSafe(
                WMP,
                new Action<object[]>((arg) =>
                {
                    WMP.settings.autoStart = AutoStart;
                    WMP.URL = path;
                    WMP.Visible = true;
                }), new object[] { });
                ValueChanged(this, EventArgs.Empty);
        }
        public void OpenBrowser(string path)
        {
            Clear();
            if (string.IsNullOrEmpty(path)) return;
            Path = path;
            WB.Visible = true;
            WB.Navigate(Path);
            ValueChanged(this, EventArgs.Empty);
        }

        public bool Show(object value)
        {
            if (value != null)
                try
                {
                    if (value is Bitmap) ShowBrowser(value,true);
                    else if (value is Image) ShowBrowser(value, true);
                    else if (value is Uri) Browse((Uri)value);
                    else {
                        string mime = General.MiMFa_GetDetail.GetMimeObject(value).Split('/')[0].Trim().ToLower();
                        if (mime == "image") ShowBrowser(value, true);
                        else if (mime == "text") ShowBrowser(MiMFa_StringService.ToHTML(value + ""), false);
                        else ShowMediaPlayer(value);
                    }
                    return true;
                }
                catch { Clear(); }
            else Clear();
            return false;
        }
        public void ShowMediaPlayer(object value)
        {
            Clear();
            Value = value;
            //WMP.Visible = true;
            Path = TempDirectory + System.DateTime.Now.Ticks +".mp4";
            File.WriteAllBytes(Path, MiMFa_IOService.Serialize(Value));
            MiMFa_ControlService.SetControlThreadSafe(
                WMP,
                new Action<object[]>((arg) =>
                {
                    WMP.settings.autoStart = AutoStart;
                    WMP.URL = Path;
                    WMP.Visible = true;
                }), new object[] { });
                ValueChanged(this, EventArgs.Empty);
        }
        public void ShowBrowser(object value,bool inCenter = false)
        {
            Clear();
            Value = value;
            WB.Visible = true;
            MiMFa_ControlService.WebBrowserDocumentText(ref WB, ((SpecialView && inCenter) ? ShowSimplyStartHTML:StartHTML) + Display.Done(value) + EndHTML);
                ValueChanged(this, EventArgs.Empty);
        }
        public void Browse(Uri url)
        {
            ShowBrowser(null);
            WB.Navigate(url);
        }
        public void Browse(string url)
        {
            ShowBrowser(null);
            WB.Navigate(url);
        }

        public void Clear()
        {
            try
            {
                General.MiMFa_Path.CreateAllDirectories(TempDirectory);
                Path = string.Empty;
                Value = null;
                WB.Visible = false;
                WMP.Visible = false;
                WMP.URL = string.Empty;
                MiMFa_ControlService.SetControlThreadSafe(
                     WB,
                     new Action<object[]>((arg) =>
                     {
                         MiMFa_ControlService.WebBrowserDocumentText(ref WB, string.Empty);
                     }), new object[] { });
                MiMFa_ControlService.SetControlThreadSafe(
                    WMP,
                    new Action<object[]>((arg) =>
                    {
                        WMP.settings.autoStart = false;
                        WMP.URL = "";
                    }), new object[] { });
            }
            catch { }
            finally { ValueChanged(this, EventArgs.Empty); }
        }
        public void FullScreen()
        {
            if(FullScreenAllowance){
                Form f = new Form();
                FileViewer fv = new FileViewer();
                fv.SuspendLayout();
                f.SuspendLayout();
                f.Text = Path;
                fv.Dock = DockStyle.Fill;
                fv.SpecialView = false;
                fv.FullScreenAllowance = false;
                fv.AutoStart = false;
                if (Value != null) fv.Show(Value);
                else if (!string.IsNullOrEmpty(Path)) fv.Open(Path);
                f.Controls.Add(fv);
                fv.ResumeLayout();
                fv.PerformLayout();
                f.ResumeLayout();
                f.PerformLayout();
                f.TopMost = true;
                f.ShowDialog();
            }
        }

        private void p_Main_Resize(object sender, EventArgs e)
        {
            WMP.Size = p_Main.Size;
            WMP.Location = new Point(0,0);
        }
        private void FileViewer_Load(object sender, EventArgs e)
        {
        }
        private void WMP_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {

        }
        private void WMP_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            FullScreen();
        }
        private void WB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlElementCollection element = WB.Document.GetElementsByTagName("img");
                if (element != null)
                    for (int i = 0; i < element.Count; i++)
                    {
                        element[i].DoubleClick += (s, er) =>
                            FullScreen();
                        element[i].Click += (s, er) =>
                              OnClick(EventArgs.Empty);
                    }
                else
                {
                    element = WB.Document.GetElementsByTagName("body");
                    if (element != null)
                        for (int i = 0; i < element.Count; i++)
                        {
                            element[i].DoubleClick += (s, er) =>
                                FullScreen();
                            element[i].Click += (s, er) =>
                                  OnClick(EventArgs.Empty);
                        }
                }
            }
            catch { }
        }
        private void WMP_ErrorEvent(object sender, EventArgs e)
        {
            if (Value != null) ShowBrowser(Value);
            else OpenBrowser(Path);
        }
        private void WMP_Validated(object sender, EventArgs e)
        {
        }
    }
}
