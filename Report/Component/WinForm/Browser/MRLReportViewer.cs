using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Archive.Reports;
using MiMFa_Framework.Component.WinForm.TabPage;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Component.WinForm.Editor.ReportDesign;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace MiMFa_Framework.Component.WinForm.Browser
{
    public partial class MRLReportViewer : Browser
    {
        #region CategoryAttribute
        [CategoryAttribute()]
        public MiMFa_ReportLanguage MRL { get; set; } = new MiMFa_ReportLanguage();
        public Report CurrentReport = new Report();
        public Report MainReport = new Report();
        private MiMFa_ReportsArchive _Archive = null;
        public MiMFa_ReportsArchive Archive
        {
            get { return _Archive; }
            set
            {
                _Archive = value;
                tsb_AddToArchive.Visible = _Archive != null;
            }
        }
        public TabPage.TabPage TabViewer = null;
        private ReportDesigner _Editor = null;
        public ReportDesigner Editor
        {
            get { return _Editor; }
            set
            {
                _Editor = value;
                tsb_ChangeRPS.Visible = _Editor != null;
            }
        }
        public int ShowCount
        {
            get { return Convert.ToInt32(tsl_Count.Text); }
            set { tsl_Count.Text = value + ""; }
        }
        public int FromRecord = 0;
        public int ToRecord = -1;
        public Func<string,Report> SetReportQuery { get; set; } = (s) => new Report();
        public string Query { get; set; } = "SELECT * FROM [Table]";
        #endregion

        #region Override
        #endregion

        public MRLReportViewer()
        {
            InitializeComponent();
            (new Exclusive.Language.MiMFa_Translator()).TryDone(CMS);
            //CheckForIllegalCrossThreadCalls = false;
            //MRL.CommandTag.HandlersList.Add(this);
        }
        private void ReportDetail(Report report)
        {
            MainReport = report ?? new Report();
            tsl_Name.Text = MainReport.Name;
            if (MainReport.ObjectArray != null) tsl_Count.Text = MainReport.ObjectArray.Length.ToString();
            else tsl_Count.Text = "0";
        }
        public void Show(Report report = null, bool withCompile = false)
        {
            Thread th = new Thread(() =>
            {
                if (ProgressBar != null) ProgressBar.ProcessRun(1);
                if (report == null) report = CurrentReport = new Report();
                CurrentReport = report;
                if (withCompile) report.HTML = MRL.CompileToHTML(report);
                try
                {
                    ShowReport(report.HTML);
                    if (ProgressBar != null) ProgressBar.ProcessRun(100);
                }
                catch { }
            });
            th.IsBackground = true;
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void ShowReport(string html)
        {
            if (!this.Viewer.InvokeRequired)
            {
                MiMFa_ControlService.WebBrowserDocumentText(ref this.Viewer, html);
                Viewer.Document.Title = MainReport.Name + "";
                MRL.MCL.UserInterface = this.Viewer;
            }
            else this.Viewer.Invoke(new Action<string>(ShowReport), html);
        }
        public void ShowReport(Func<Report> report, bool withCompile = false)
        {
            SetReportQuery =(s)=> report();
            RefreshReport(withCompile);
        }
        public void ShowReport(Func<string, Report> report,string query, bool withCompile = false)
        {
            Query = query;
            SetReportQuery = report;
            RefreshReport(withCompile);
        }
        public void ShowReport(Report report = null, bool withCompile = false)
        {
            SetReportQuery = (s) => MainReport = report;
            RefreshReport(withCompile);
        }
        public void OnlyShowReport(Report report = null, bool withCompile = false)
        {
            ShowReport(report, Exclusive.Collection.MiMFa_SidePosition.Null, -1, withCompile);
        }
        public void ShowReport(Report report, MiMFa_SidePosition side = MiMFa_SidePosition.Null, int length = -1, bool withCompile = true)
        {
            if (ProgressBar != null) ProgressBar.ProcessRun(1);
            if (report.ObjectArray != null && report.ObjectArray.Length > 0)
            {
                if (length <= 0)
                    if (!int.TryParse(tscb_NumberOFRecord.Text.ToString(), out length))
                    {
                        if (ProgressBar != null) ProgressBar.ProcessRun(100);
                        return;
                    }
                CurrentReport = new Report(report);
                switch (side)
                {
                    case MiMFa_SidePosition.Right:
                        FromRecord = ToRecord + 1;
                        break;
                    case MiMFa_SidePosition.Left:
                        FromRecord = FromRecord - length;
                        break;
                    default:
                        break;
                }
                ToRecord = FromRecord + length - 1;
                if (FromRecord <= 0)
                {
                    FromRecord = 0;
                    tsb_PageDown.Enabled = false;
                }
                else tsb_PageDown.Enabled = true;
                if (ToRecord >= report.ObjectArray.Length || ToRecord < FromRecord)
                {
                    ToRecord = report.ObjectArray.Length - 1;
                    tsb_PageUp.Enabled = false;
                }
                else tsb_PageUp.Enabled = true;
                CurrentReport.ObjectArray = MiMFa_CollectionService.GetPart(CurrentReport.ObjectArray, FromRecord, ToRecord);
                Show(CurrentReport, withCompile);
                return;
            }
            Show(report, withCompile);
        }
        [Obsolete]
        public void ShowReport(string name, ReportStyle reportStyle, object extra, params object[] objectArray)
        {
            if (ProgressBar != null) ProgressBar.ProcessRun(1);
            SetReportQuery = (s) =>
            {
                MainReport = new Report();
                MainReport.Name = name;
                MainReport.ObjectArray = objectArray ?? new object[] { };
                MainReport.Style = reportStyle;
                if (MainReport.ObjectArray.Length > 0) MainReport.Type = MainReport.ObjectArray[0].GetType();
                else MainReport.Type = typeof(Exclusive.Collection.Instance.MiMFa_Instance);
                MainReport.Extra = extra;
                return MainReport;
            };
            RefreshReport(true);
        }
        [Obsolete]
        public void ShowReport(string name, ReportStyle reportStyle, object extra, Type type, params object[] objectArray)
        {
            if (ProgressBar != null) ProgressBar.ProcessRun(1);
            MainReport.Type = type;
            ShowReport(name, reportStyle, extra, objectArray);
        }

        public void AddToArchive()
        {
            if (ProgressBar != null) ProgressBar.ProcessRun(1);
            MainReport.Name = tsl_Name.Text;
            MainReport.HTML = this.Viewer.DocumentText;
            _Archive.Store(MainReport);
            if (ProgressBar != null) ProgressBar.ProcessRun(100);
        }
        public void RefreshPage()
        {
            //this.Browser.DocumentText = null;
            ShowReport(MainReport, true);
            //this.Browser.Refresh();
        }
        public void RefreshReport(bool withCompile = true)
        {
            MainReport = SetReportQuery(Query);
            FromRecord = 0;
            ReportDetail(MainReport);
            ShowReport(MainReport, Exclusive.Collection.MiMFa_SidePosition.Null, -1, withCompile);
        }

        public void Open()
        {
            OFD.Filter = "All File(*.*) | *.*";
            if (OFD.InitialDirectory != null) OFD.InitialDirectory = MainReport.GetPath();
            if (OFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(OFD.FileName))
                if (Path.GetExtension(OFD.FileName) == Report.Extension)
                {
                    MiMFa_IOService.OpenDeserializeFile(OFD.FileName, ref MainReport);
                    ShowReport(() => MainReport, true);
                }
                else this.Viewer.Navigate(OFD.FileName);
        }
        public void Open(object o,string addr)
        {
            if (o is Report)
                try
                {
                    ShowReport((Report)o, true);
                }
                catch { }
            else if (Path.GetExtension(addr).ToLower() == MiMFa_CommandLanguage.Extension)
                try
                {
                    Report r = new Report(Path.GetFileNameWithoutExtension(addr), new ReportStyle(addr, MiMFa_IOService.FileToString(addr)));
                    ShowReport(r,true);
                }
                catch { }
            else this.Viewer.Navigate(addr);
        }
        public void Save()
        {
            try
            {
                SFD.Filter = "MiMfa Report File (*" + Report.Extension + ") | *" + Report.Extension;
                SFD.FileName = MainReport.Name;
                if (SFD.InitialDirectory != null) SFD.InitialDirectory = MainReport.GetPath();
                if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
                {
                    MainReport.Address = SFD.FileName;
                    MiMFa_IOService.SaveSerializeFile(SFD.FileName, MainReport);
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    Save();
            }
        }
        public void SaveImage()
        {
            try
            {
                SFD.Filter = @"JPEG File (*.jpeg, *.jpg) | *.jpg | PNG File (*.png) | *.png | BMP File (*.bmp) | *.bmp | TIFF File (*.tif, *.tiff) | *.tiff | GIF File (*.gif) | *.gif | EMF File (*.emf) | *.emf ";
                SFD.FileName = MainReport.Name;
                if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
                {
                    MiMFa_Convert.ToImage(this.Viewer.DocumentText, SFD.FileName, Viewer.Document.Body.ScrollRectangle.Size, false);
                    //Exclusive.Extension.MiMFa_Convert pc = new Exclusive.Extension.MiMFa_Convert();
                    //string addr = Config.TempDirectory + "mrloutput.html";
                    //MiMFa_IOService.StringToFile(addr, Viewer.DocumentText);
                    //pc.ToImage(addr, SFD.FileName,false);
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    SaveImage();
            }
        }
        public void SaveBrowser()
        {
            Viewer.ShowSaveAsDialog();
        }
        public void SavePDF()
        {
            try
            {
                SFD.Filter = "Adobe Acrobat Reader File (*.pdf) | *.pdf";
                SFD.FileName = MainReport.Name;
                if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
                    Output(Aspose.Words.SaveFormat.Pdf, SFD.FileName, false);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    SavePDF();
            }
        }
        public void SaveWord()
        {
            try
            {
                SFD.Filter = "Microsoft Word File (*.doc) | *.doc | Microsoft Word File (*.docx) | *.docx | Rich Text Format File (*.rtf) | *.rtf | Text File (*.txt) | *.txt";
                SFD.FileName = MainReport.Name;
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
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    SaveWord();
            }
        }
        public void SaveXPS()
        {
            try
            {
                SFD.Filter = "XML Paper Specification File (*.xps) | *.xps";
                SFD.FileName = MainReport.Name;
                if (SFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(SFD.FileName))
                    Output(Aspose.Words.SaveFormat.Xps, SFD.FileName, false);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    SaveXPS();
            }
        }
        public void SaveOpenXPS()
        {

        }
        public void SaveExcel()
        {
            MiMFa_ControlService.DataTableToExcel(MiMFa_Convert.ToPropertiesDataTable(MRL.CL));
        }
        private void Output(Aspose.Words.SaveFormat to, string dest, bool openforce = false)
        {
            Exclusive.Extension.MiMFa_Convert pc = new Exclusive.Extension.MiMFa_Convert();
            string addr = Config.TempDirectory + System.DateTime.Now.Ticks + "mrloutput.html";
            MiMFa_IOService.StringToFile(addr, MiMFa_StringService.ReplaceWithAllWordBetween(Viewer.DocumentText,"<input ","/>",""));
            pc.To(addr, dest, to, openforce);
        }

        public void Print()
        {
            this.Viewer.Print();
        }
        public void PrintDialog()
        {
            this.Viewer.ShowPrintDialog();
        }
        public void PrintPreviewDialog()
        {
            this.Viewer.ShowPrintPreviewDialog();
        }
        public void PageSetupDialog()
        {
            this.Viewer.ShowPageSetupDialog();
        }

        public void Edit()
        {
            try
            {
                _Editor.Initialize(MainReport.Type, MainReport.Style, true);
                if (_Editor.ParentForm != null) _Editor.ParentForm.Text = Exclusive.Language.MiMFa_LanguageReader.GetText("Edit") + " " + MainReport.Name;
                if (TabViewer != null) TabViewer.ShowPage(_Editor.ParentForm, false);
                else if (_Editor.ParentForm != null) _Editor.ParentForm.Show();
                else tsb_ChangeRPS.Visible = false;
            }
            catch { tsb_ChangeRPS.Visible = false; }
        }
        public void Filter(string text)
        {
            Report r = new Report(MainReport);
            r.HTML = MRL.Filter(text, r);
            OnlyShowReport(r, false);
        }
        public void NumbersOfRecords(int num)
        {
            ReportDetail(MainReport);
            FromRecord = 0;
            ShowReport(MainReport, Exclusive.Collection.MiMFa_SidePosition.Null, num, true);
        }
        private void BackPage()
        {
            //ReportDetail(MainReport);
            ShowReport(MainReport, Exclusive.Collection.MiMFa_SidePosition.Left, -1, true);
        }
        private void NextPage()
        {
            //ReportDetail(MainReport);
            ShowReport(MainReport, Exclusive.Collection.MiMFa_SidePosition.Right, -1, true);
        }
        public void ChangeStyle(string fileName)
        {
            ReportStyle rs = new ReportStyle();
            MiMFa_IOService.OpenDeserializeFile(fileName, ref rs);
            Report r = new Report(MainReport);
            r.Style = rs;
            ShowReport(r, true);
        }

        #region Private Region 
        private void tsb_AddToArchive_Click(object sender, EventArgs e)
        {
            AddToArchive();
        }
        private void tsb_Refresh_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }
        private void tsb_RefreshReport_Click(object sender, EventArgs e)
        {
            RefreshReport(true);
        }
        private void tsb_Open_Click(object sender, EventArgs e)
        {
            Open();
        }
        private void tsmi_Save_MiMFaReportPackage_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void tsmi_Save_Image_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
        private void tsmi_Save_Browser_Click(object sender, EventArgs e)
        {
            SaveBrowser();
        }
        private void tsmi_Save_PDF_Click(object sender, EventArgs e)
        {
            SavePDF();
        }
        private void tsmi_Save_Word_Click(object sender, EventArgs e)
        {
            SaveWord();
        }
        private void tsmi_Save_Xps_Click(object sender, EventArgs e)
        {
            SaveXPS();
        }
        private void tsmi_Save_OpenXps_Click(object sender, EventArgs e)
        {
            SaveOpenXPS();
        }
        private void tsmi_Save_Excel_Click(object sender, EventArgs e)
        {
            SaveExcel();
        }
        private void tsb_Print_Click(object sender, EventArgs e)
        {
            PrintDialog();
        }
        private void tsb_PrintPreview_Click(object sender, EventArgs e)
        {
             PrintPreviewDialog();
        }
        private void tsb_PageSetup_Click(object sender, EventArgs e)
        {
             PageSetupDialog();
        }
        private void tsb_ChangeRPS_Click(object sender, EventArgs e)
        {
            Edit();
        }
        private void tstb_Filter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)Filter(tstb_Filter.Text);
        }
        private void tscb_NumberOFRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscb_NumberOFRecord.SelectedIndex == 0)
                NumbersOfRecords(99999999);
            else NumbersOfRecords( -1);
        }
        private void tsb_PageUp_Click(object sender, EventArgs e)
        {
            NextPage();
        }
        private void tsb_PageDown_Click(object sender, EventArgs e)
        {
            BackPage();
        }
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MRL.MCL.DocumentEventUpdate((WebBrowser)sender);
            if (ProgressBar != null) ProgressBar.ProcessRun(100);
        }
        private void tsb_ChangeStyle_Click(object sender, EventArgs e)
        {
            OFD.Filter = "All File(*" + ReportStyle.Extension + ") | *" + ReportStyle.Extension + "";
            if (OFD.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(OFD.FileName))
                ChangeStyle(OFD.FileName);
        }
        private void MRLReportViewer_Load(object sender, EventArgs e)
        {


        }
        private void ts_Main_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                object o = null;
                if (data != null)
                    foreach (var item in data)
                    {
                        MiMFa_IOService.OpenDeserializeFile(item, ref o);
                        Open(o, item);
                    }
            }
            catch { }
        }
        private void ts_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
    #endregion
}
