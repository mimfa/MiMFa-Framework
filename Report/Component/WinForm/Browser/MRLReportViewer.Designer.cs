namespace MiMFa_Framework.Component.WinForm.Browser
{
    partial class MRLReportViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRLReportViewer));
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.tsb_AddToArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_RefreshReport = new System.Windows.Forms.ToolStripButton();
            this.tsb_RefreshPage = new System.Windows.Forms.ToolStripButton();
            this.tsb_ChangeStyle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Save = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_Save_MiMFaReportPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save_PDF = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save_Word = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save_Image = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save_Browser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_Open = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_PageSetup = new System.Windows.Forms.ToolStripButton();
            this.tsb_PrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tsb_Print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_PageDown = new System.Windows.Forms.ToolStripButton();
            this.tscb_NumberOFRecord = new System.Windows.Forms.ToolStripComboBox();
            this.tsb_PageUp = new System.Windows.Forms.ToolStripButton();
            this.tsl_Count = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsl_Name = new System.Windows.Forms.ToolStripLabel();
            this.tsb_ChangeRPS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tstb_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.Viewer = new System.Windows.Forms.WebBrowser();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgressBar = new MiMFa_Framework.Component.WinForm.ProgressBar.ProgressBarLineWait();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Main.SuspendLayout();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts_Main
            // 
            this.ts_Main.BackColor = System.Drawing.Color.Transparent;
            this.ts_Main.CanOverflow = false;
            this.ts_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_AddToArchive,
            this.toolStripSeparator1,
            this.tsb_RefreshReport,
            this.tsb_RefreshPage,
            this.tsb_ChangeStyle,
            this.toolStripSeparator2,
            this.tsb_Save,
            this.tsb_Open,
            this.toolStripSeparator3,
            this.tsb_PageSetup,
            this.tsb_PrintPreview,
            this.tsb_Print,
            this.toolStripSeparator4,
            this.tsb_PageDown,
            this.tscb_NumberOFRecord,
            this.tsb_PageUp,
            this.tsl_Count,
            this.toolStripSeparator6,
            this.tsl_Name,
            this.tsb_ChangeRPS,
            this.toolStripSeparator5,
            this.tstb_Filter});
            this.ts_Main.Location = new System.Drawing.Point(0, 0);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.ts_Main.Size = new System.Drawing.Size(611, 25);
            this.ts_Main.TabIndex = 0;
            this.ts_Main.TabStop = true;
            // 
            // tsb_AddToArchive
            // 
            this.tsb_AddToArchive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_AddToArchive.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Add;
            this.tsb_AddToArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AddToArchive.Name = "tsb_AddToArchive";
            this.tsb_AddToArchive.Size = new System.Drawing.Size(23, 22);
            this.tsb_AddToArchive.Text = "Add To Archive";
            this.tsb_AddToArchive.Click += new System.EventHandler(this.tsb_AddToArchive_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_RefreshReport
            // 
            this.tsb_RefreshReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_RefreshReport.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Refresh;
            this.tsb_RefreshReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RefreshReport.Name = "tsb_RefreshReport";
            this.tsb_RefreshReport.Size = new System.Drawing.Size(23, 22);
            this.tsb_RefreshReport.Text = "Refresh Report";
            this.tsb_RefreshReport.Click += new System.EventHandler(this.tsb_RefreshReport_Click);
            // 
            // tsb_RefreshPage
            // 
            this.tsb_RefreshPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_RefreshPage.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Recovery;
            this.tsb_RefreshPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RefreshPage.Name = "tsb_RefreshPage";
            this.tsb_RefreshPage.Size = new System.Drawing.Size(23, 22);
            this.tsb_RefreshPage.Text = "Refresh Page";
            this.tsb_RefreshPage.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // tsb_ChangeStyle
            // 
            this.tsb_ChangeStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ChangeStyle.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Drawing;
            this.tsb_ChangeStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ChangeStyle.Name = "tsb_ChangeStyle";
            this.tsb_ChangeStyle.Size = new System.Drawing.Size(23, 22);
            this.tsb_ChangeStyle.Text = "ChangeStyle";
            this.tsb_ChangeStyle.Click += new System.EventHandler(this.tsb_ChangeStyle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_Save
            // 
            this.tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Save_MiMFaReportPackage,
            this.tsmi_Save_PDF,
            this.toolStripMenuItem2,
            this.tsmi_Save_Word,
            this.toolStripMenuItem1,
            this.tsmi_Save_Image,
            this.tsmi_Save_Browser});
            this.tsb_Save.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Export;
            this.tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Save.Name = "tsb_Save";
            this.tsb_Save.Size = new System.Drawing.Size(29, 22);
            this.tsb_Save.Text = "Save";
            // 
            // tsmi_Save_MiMFaReportPackage
            // 
            this.tsmi_Save_MiMFaReportPackage.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Report_Package1;
            this.tsmi_Save_MiMFaReportPackage.Name = "tsmi_Save_MiMFaReportPackage";
            this.tsmi_Save_MiMFaReportPackage.Size = new System.Drawing.Size(202, 22);
            this.tsmi_Save_MiMFaReportPackage.Text = "MiMFa Report Package";
            this.tsmi_Save_MiMFaReportPackage.Click += new System.EventHandler(this.tsmi_Save_MiMFaReportPackage_Click);
            // 
            // tsmi_Save_PDF
            // 
            this.tsmi_Save_PDF.Image = global::MiMFa_Framework.Properties.Resources.Adobe_Reader;
            this.tsmi_Save_PDF.Name = "tsmi_Save_PDF";
            this.tsmi_Save_PDF.Size = new System.Drawing.Size(202, 22);
            this.tsmi_Save_PDF.Text = "Adobe Reader";
            this.tsmi_Save_PDF.Click += new System.EventHandler(this.tsmi_Save_PDF_Click);
            // 
            // tsmi_Save_Word
            // 
            this.tsmi_Save_Word.Image = global::MiMFa_Framework.Properties.Resources.Microsoft_Word;
            this.tsmi_Save_Word.Name = "tsmi_Save_Word";
            this.tsmi_Save_Word.Size = new System.Drawing.Size(202, 22);
            this.tsmi_Save_Word.Text = "Microsoft Word";
            this.tsmi_Save_Word.Click += new System.EventHandler(this.tsmi_Save_Word_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::MiMFa_Framework.Properties.Resources.XML_Paper_Specification;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem1.Text = "XML Paper Specification";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.tsmi_Save_Xps_Click);
            // 
            // tsmi_Save_Image
            // 
            this.tsmi_Save_Image.Image = global::MiMFa_Framework.Properties.Resources.BRIGHTS_PAINT_APPLICATION;
            this.tsmi_Save_Image.Name = "tsmi_Save_Image";
            this.tsmi_Save_Image.Size = new System.Drawing.Size(202, 22);
            this.tsmi_Save_Image.Text = "Image";
            this.tsmi_Save_Image.Click += new System.EventHandler(this.tsmi_Save_Image_Click);
            // 
            // tsmi_Save_Browser
            // 
            this.tsmi_Save_Browser.Image = global::MiMFa_Framework.Properties.Resources.Browser;
            this.tsmi_Save_Browser.Name = "tsmi_Save_Browser";
            this.tsmi_Save_Browser.Size = new System.Drawing.Size(202, 22);
            this.tsmi_Save_Browser.Text = "Browser";
            this.tsmi_Save_Browser.Click += new System.EventHandler(this.tsmi_Save_Browser_Click);
            // 
            // tsb_Open
            // 
            this.tsb_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Open.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Import;
            this.tsb_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Open.Name = "tsb_Open";
            this.tsb_Open.Size = new System.Drawing.Size(23, 22);
            this.tsb_Open.Text = "Open";
            this.tsb_Open.Click += new System.EventHandler(this.tsb_Open_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_PageSetup
            // 
            this.tsb_PageSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_PageSetup.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Page_Setup;
            this.tsb_PageSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_PageSetup.Name = "tsb_PageSetup";
            this.tsb_PageSetup.Size = new System.Drawing.Size(23, 22);
            this.tsb_PageSetup.Text = "Page Setup";
            this.tsb_PageSetup.Click += new System.EventHandler(this.tsb_PageSetup_Click);
            // 
            // tsb_PrintPreview
            // 
            this.tsb_PrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_PrintPreview.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Print_Preview;
            this.tsb_PrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_PrintPreview.Name = "tsb_PrintPreview";
            this.tsb_PrintPreview.Size = new System.Drawing.Size(23, 22);
            this.tsb_PrintPreview.Text = "Print Preview";
            this.tsb_PrintPreview.Click += new System.EventHandler(this.tsb_PrintPreview_Click);
            // 
            // tsb_Print
            // 
            this.tsb_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Print.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Print;
            this.tsb_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Print.Name = "tsb_Print";
            this.tsb_Print.Size = new System.Drawing.Size(23, 22);
            this.tsb_Print.Text = "Print";
            this.tsb_Print.Click += new System.EventHandler(this.tsb_Print_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_PageDown
            // 
            this.tsb_PageDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_PageDown.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Go_Left;
            this.tsb_PageDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_PageDown.Name = "tsb_PageDown";
            this.tsb_PageDown.RightToLeftAutoMirrorImage = true;
            this.tsb_PageDown.Size = new System.Drawing.Size(23, 22);
            this.tsb_PageDown.Text = "Page Down";
            this.tsb_PageDown.Click += new System.EventHandler(this.tsb_PageDown_Click);
            // 
            // tscb_NumberOFRecord
            // 
            this.tscb_NumberOFRecord.AutoSize = false;
            this.tscb_NumberOFRecord.Items.AddRange(new object[] {
            "*",
            "5",
            "10",
            "25",
            "50",
            "100"});
            this.tscb_NumberOFRecord.Name = "tscb_NumberOFRecord";
            this.tscb_NumberOFRecord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tscb_NumberOFRecord.Size = new System.Drawing.Size(50, 23);
            this.tscb_NumberOFRecord.Text = "20";
            this.tscb_NumberOFRecord.TextChanged += new System.EventHandler(this.tscb_NumberOFRecord_SelectedIndexChanged);
            // 
            // tsb_PageUp
            // 
            this.tsb_PageUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_PageUp.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Go_Right;
            this.tsb_PageUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_PageUp.Name = "tsb_PageUp";
            this.tsb_PageUp.RightToLeftAutoMirrorImage = true;
            this.tsb_PageUp.Size = new System.Drawing.Size(23, 22);
            this.tsb_PageUp.Text = "Page Up";
            this.tsb_PageUp.Click += new System.EventHandler(this.tsb_PageUp_Click);
            // 
            // tsl_Count
            // 
            this.tsl_Count.Margin = new System.Windows.Forms.Padding(10, 1, 2, 2);
            this.tsl_Count.Name = "tsl_Count";
            this.tsl_Count.Size = new System.Drawing.Size(13, 22);
            this.tsl_Count.Text = "0";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsl_Name
            // 
            this.tsl_Name.Name = "tsl_Name";
            this.tsl_Name.Size = new System.Drawing.Size(10, 22);
            this.tsl_Name.Text = " ";
            this.tsl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsb_ChangeRPS
            // 
            this.tsb_ChangeRPS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_ChangeRPS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_ChangeRPS.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Option;
            this.tsb_ChangeRPS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_ChangeRPS.Name = "tsb_ChangeRPS";
            this.tsb_ChangeRPS.Size = new System.Drawing.Size(23, 22);
            this.tsb_ChangeRPS.Text = "Change Report Package Style";
            this.tsb_ChangeRPS.Visible = false;
            this.tsb_ChangeRPS.Click += new System.EventHandler(this.tsb_ChangeRPS_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tstb_Filter
            // 
            this.tstb_Filter.Name = "tstb_Filter";
            this.tstb_Filter.Size = new System.Drawing.Size(100, 25);
            this.tstb_Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstb_Filter_KeyPress);
            // 
            // Viewer
            // 
            this.Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Viewer.IsWebBrowserContextMenuEnabled = false;
            this.Viewer.Location = new System.Drawing.Point(0, 25);
            this.Viewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.Viewer.Name = "Viewer";
            this.Viewer.ScriptErrorsSuppressed = true;
            this.Viewer.Size = new System.Drawing.Size(611, 316);
            this.Viewer.TabIndex = 11;
            this.Viewer.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            // 
            // OFD
            // 
            this.OFD.RestoreDirectory = true;
            this.OFD.Title = "Open a new Report";
            // 
            // SFD
            // 
            this.SFD.RestoreDirectory = true;
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToArchiveToolStripMenuItem,
            this.toolStripSeparator7,
            this.refreshToolStripMenuItem,
            this.themplateToolStripMenuItem,
            this.toolStripSeparator9,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripSeparator8,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem});
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(217, 176);
            this.CMS.Click += new System.EventHandler(this.tsb_ChangeStyle_Click);
            // 
            // addToArchiveToolStripMenuItem
            // 
            this.addToArchiveToolStripMenuItem.Name = "addToArchiveToolStripMenuItem";
            this.addToArchiveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.addToArchiveToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.addToArchiveToolStripMenuItem.Text = "Add To Archive";
            this.addToArchiveToolStripMenuItem.Click += new System.EventHandler(this.tsb_AddToArchive_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(213, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // themplateToolStripMenuItem
            // 
            this.themplateToolStripMenuItem.Name = "themplateToolStripMenuItem";
            this.themplateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.themplateToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.themplateToolStripMenuItem.Text = "Themplate";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(213, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.tsmi_Save_MiMFaReportPackage_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.tsb_Open_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(213, 6);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.tsb_PrintPreview_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.tsb_Print_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.ProgressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressBar.InvertColor = false;
            this.ProgressBar.Location = new System.Drawing.Point(249, 164);
            this.ProgressBar.LockState = false;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ProcessShow = false;
            this.ProgressBar.ProgressImage = ((System.Drawing.Image)(resources.GetObject("ProgressBar.ProgressImage")));
            this.ProgressBar.ProgressType = MiMFa_Framework.Exclusive.Collection.MiMFa_GeneralAge.Historical;
            this.ProgressBar.Size = new System.Drawing.Size(104, 38);
            this.ProgressBar.SleepTime = 5000;
            this.ProgressBar.TabIndex = 12;
            this.ProgressBar.Value = 0F;
            this.ProgressBar.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::MiMFa_Framework.Properties.Resources.Microsoft_Excel;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem2.Text = "Microsoft Excel";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.tsmi_Save_Excel_Click);
            // 
            // MRLReportViewer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.CMS;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Viewer);
            this.Controls.Add(this.ts_Main);
            this.Name = "MRLReportViewer";
            this.Size = new System.Drawing.Size(611, 341);
            this.Load += new System.EventHandler(this.MRLReportViewer_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ts_Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ts_Main_DragEnter);
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton tsb_AddToArchive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_RefreshPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton tsb_Save;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save_Browser;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save_PDF;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save_Word;
        private System.Windows.Forms.ToolStripButton tsb_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsb_PageSetup;
        private System.Windows.Forms.ToolStripButton tsb_PrintPreview;
        private System.Windows.Forms.ToolStripButton tsb_Print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel tsl_Name;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save_Image;
        private System.Windows.Forms.ToolStripButton tsb_ChangeRPS;
        private System.Windows.Forms.ToolStripTextBox tstb_Filter;
        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.ToolStripButton tsb_PageDown;
        private System.Windows.Forms.ToolStripComboBox tscb_NumberOFRecord;
        private System.Windows.Forms.ToolStripButton tsb_PageUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel tsl_Count;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        public System.Windows.Forms.WebBrowser Viewer;
        private System.Windows.Forms.ToolStripButton tsb_ChangeStyle;
        private ProgressBar.ProgressBarLineWait ProgressBar;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem addToArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save_MiMFaReportPackage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsb_RefreshReport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}
