using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Component.WinForm.Editor.ReportDesign;
using MiMFa_Framework.Component.WinForm.ProgressBar;
using MiMFa_Framework.Component.WinForm.TabPage;
using MiMFa_Framework.Exclusive.Archive.Reports;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using MiMFa_Framework.Exclusive.Language;

namespace MiMFa_Framework.Component.WinForm.Package.Reports
{
   public class ReportSystem
    {
        public MiMFa_ReportLanguage MRL { get; set; } //= new MiMFaReportLanguage();
        public MiMFa_ReportsArchive Archive { get; set; }

        public bool OpenInNewMRL = false;

        public TabPage.TabPage TabViewer;
        public ProgressBar.ProgressBar ProgressBar;
        public System.Drawing.Icon Icon = Properties.Resources.MiMFa_Report;
        public MiMFa_Translator TRANSLATE = new MiMFa_Translator();
        public ReportSystem(System.Drawing.Icon icon = null,StandardBrowserViewer tabViewer = null, ProgressBar.ProgressBar progressBar = null)
        {
            if (icon != null) Icon = icon;
            TabViewer = tabViewer;
            ProgressBar = progressBar;
        }
        public ReportSystem(MiMFa_ReportLanguage mRL,MiMFa_ReportsArchive archive)
        {
            MRL = mRL;
            Archive = archive;
        }
        public ReportSystem(MiMFa_ReportLanguage mRL,StandardBrowserViewer tabViewer = null, ProgressBar.ProgressBar progressBar = null)
        {
            MRL = mRL;
            TabViewer = tabViewer;
            ProgressBar = progressBar;
        }

        public void Open()
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "MiMFa Report (*.mrp, *.rps) | *.mrp; *.rps";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Open(ofd.FileName);
        }
        public void Open(string address)
        {
            object obj = null;
            MiMFa_Framework.Service.MiMFa_IOService.OpenDeserializeFile(address, ref obj);
            if (obj is ReportStyle) ShowEditor(null, (ReportStyle)obj, false);
            else Open(obj, address);
        }
        public void Open(object obj, string address)
        {
            Show(() =>
            {
                Viewer viewer = Initialize();
                TRANSLATE.TryDone(Service.MiMFa_ControlService.GetAllObjects(viewer));
                viewer.ReportViewer.Open(obj,address);
                viewer.Text = System.IO.Path.GetFileNameWithoutExtension(address);
                return viewer;
            });
        }

        public void ShowReport(Func<Report> report, bool withCompile = false)
        {
            Show(() =>
            {
                Viewer viewer = Initialize();
                TRANSLATE.TryDone(Service.MiMFa_ControlService.GetAllObjects(viewer));
                viewer.ReportViewer.ShowReport(report, withCompile);
                if(viewer.ReportViewer.MainReport != null) viewer.Text = viewer.ReportViewer.MainReport.Name + " (" + viewer.ReportViewer.MainReport.ID + ")";
                return viewer;
            });
        }
        [Obsolete]
        public void ShowReport(string name, ReportStyle reportStyle, object extra, params object[] objectArray)
        {
            Show(() =>
            {
                Viewer viewer = Initialize();
                TRANSLATE.TryDone(Service.MiMFa_ControlService.GetAllObjects(viewer));
                viewer.ReportViewer.ShowReport(name, reportStyle, extra, objectArray ?? new object[] { });
                viewer.Text = viewer.ReportViewer.MainReport.Name + " (" + viewer.ReportViewer.MainReport.ID + ")";
                return viewer;
            });
        }
        [Obsolete]
        public void ShowReport(string name, ReportStyle reportStyle, object extra, Type type, params object[] objectArray)
        {
            Show(() =>
            {
                Viewer viewer = Initialize();
                TRANSLATE.TryDone(Service.MiMFa_ControlService.GetAllObjects(viewer));
                viewer.ReportViewer.ShowReport(name, reportStyle, extra, type, objectArray?? new object[] { });
                viewer.Text = viewer.ReportViewer.MainReport.Name + " (" + viewer.ReportViewer.MainReport.ID + ")";
                return viewer;
            });
        }

        public void ShowEditor(Type type = null, ReportStyle rs = null, bool subjectReadonly = false)
        {
            Func<Editor> ed = () =>
            {
                Editor Editor = new Editor();
                Editor.ReportDesigner.Initialize(type, rs, subjectReadonly);
                return Editor;
            };
            if (TabViewer != null)
                Service.MiMFa_ControlService.ThreadExecuteInControl(
                    Exclusive.Collection.MiMFa_ThreadingMethod.Default
                    , TabViewer
                    , (args) =>
                        TabViewer.ShowPage(
                            (Func<Editor>)args[0]
                            , null
                            , false
                            , Exclusive.Collection.MiMFa_ThreadingMethod.Null)
                    , new object[] { ed });
            //TabViewer.ShowPage(
            //            ed
            //            , null
            //            , false
            //            , Exclusive.Collection.MiMFa_ThreadingMethod.Null);
            else ed().Show();
        }

        public void ShowArchive()
        {
            ShowReport(() => Archive.GetDefaultReportArchive(),true);
        }
        private Viewer Initialize()
        {
            Editor Editor = new Editor();
            Viewer Viewer = new Viewer();
            Viewer.Icon = Icon;
            MiMFa_ReportLanguage mrl;
            //if (OpenInNewMRL)
            //{
            //    mrl = new MiMFa_ReportLanguage();
            //}
            //else
                mrl = MRL;
            Viewer.ReportViewer.MRL = mrl;
            Viewer.ReportViewer.Editor = Editor.ReportDesigner;
            Viewer.ReportViewer.Editor.MRL = mrl;
            Viewer.ReportViewer.TabViewer = TabViewer;
            Viewer.ReportViewer.Archive = Archive;
            return Viewer;
        }
        private void Show(Func<Viewer> viewer)
        {
            if (TabViewer != null)
                //Service.MiMFa_ControlService.ThreadExecuteInControl(
                //    Exclusive.Collection.MiMFa_ThreadingMethod.Default
                //    , TabViewer
                //    , (args) =>
                //        TabViewer.ShowPage(
                //            (Func<Viewer>)args[0]
                //            , null
                //            , false
                //            , Exclusive.Collection.MiMFa_ThreadingMethod.Null)
                //    , new object[] { viewer });
                TabViewer.ShowPage(
                        viewer()
                        , null
                        , true);
            else viewer().Show();
        }

    }
}
