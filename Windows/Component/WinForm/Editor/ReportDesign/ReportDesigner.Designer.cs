namespace MiMFa_Framework.Component.WinForm.Editor.ReportDesign
{
    partial class ReportDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDesigner));
            this.tp_Main = new System.Windows.Forms.TabControl();
            this.tp_View = new System.Windows.Forms.TabPage();
            this.pb = new MiMFa_Framework.Component.WinForm.ProgressBar.ProgressBarCycleWait();
            this.wb_View = new System.Windows.Forms.WebBrowser();
            this.tp_Code = new System.Windows.Forms.TabPage();
            this.p_Edit = new System.Windows.Forms.Panel();
            this.rtb_Code = new System.Windows.Forms.RichTextBox();
            this.Edit_Tools = new System.Windows.Forms.TableLayoutPanel();
            this.EventList = new System.Windows.Forms.ListBox();
            this.l_Event_Tags = new System.Windows.Forms.Label();
            this.FeidList = new System.Windows.Forms.ListBox();
            this.l_Object_TAGs = new System.Windows.Forms.Label();
            this.TagList = new System.Windows.Forms.ListBox();
            this.l_MRL_TAGs = new System.Windows.Forms.Label();
            this.tp_CSS = new System.Windows.Forms.TabPage();
            this.p_Css = new System.Windows.Forms.Panel();
            this.rtb_Template = new System.Windows.Forms.RichTextBox();
            this.Css_Tools = new System.Windows.Forms.Panel();
            this.MRLTemplate = new System.Windows.Forms.ListBox();
            this.l_MRLTemplate = new System.Windows.Forms.Label();
            this.tp_Script = new System.Windows.Forms.TabPage();
            this.rtb_Script = new System.Windows.Forms.RichTextBox();
            this.tp_HTML = new System.Windows.Forms.TabPage();
            this.rtb_HTML = new System.Windows.Forms.RichTextBox();
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.tsb_Ok = new System.Windows.Forms.ToolStripButton();
            this.tsb_Refresh = new System.Windows.Forms.ToolStripButton();
            this.tstb_Subject = new System.Windows.Forms.ToolStripTextBox();
            this.tsb_Save = new System.Windows.Forms.ToolStripButton();
            this.tsb_Import = new System.Windows.Forms.ToolStripButton();
            this.tsb_Export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddressViewer = new System.Windows.Forms.ToolStripLabel();
            this.tscb_EditorStyle = new System.Windows.Forms.ToolStripComboBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.CMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tp_Main.SuspendLayout();
            this.tp_View.SuspendLayout();
            this.tp_Code.SuspendLayout();
            this.p_Edit.SuspendLayout();
            this.Edit_Tools.SuspendLayout();
            this.tp_CSS.SuspendLayout();
            this.p_Css.SuspendLayout();
            this.Css_Tools.SuspendLayout();
            this.tp_Script.SuspendLayout();
            this.tp_HTML.SuspendLayout();
            this.ts_Main.SuspendLayout();
            this.CMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tp_Main
            // 
            resources.ApplyResources(this.tp_Main, "tp_Main");
            this.tp_Main.Controls.Add(this.tp_View);
            this.tp_Main.Controls.Add(this.tp_Code);
            this.tp_Main.Controls.Add(this.tp_CSS);
            this.tp_Main.Controls.Add(this.tp_Script);
            this.tp_Main.Controls.Add(this.tp_HTML);
            this.tp_Main.Multiline = true;
            this.tp_Main.Name = "tp_Main";
            this.tp_Main.SelectedIndex = 0;
            this.tp_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tp_Main.SelectedIndexChanged += new System.EventHandler(this.tlp_Main_TabIndexChanged);
            // 
            // tp_View
            // 
            this.tp_View.Controls.Add(this.pb);
            this.tp_View.Controls.Add(this.wb_View);
            resources.ApplyResources(this.tp_View, "tp_View");
            this.tp_View.Name = "tp_View";
            this.tp_View.UseVisualStyleBackColor = true;
            // 
            // pb
            // 
            resources.ApplyResources(this.pb, "pb");
            this.pb.BackColor = System.Drawing.Color.Transparent;
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.InvertColor = false;
            this.pb.LockState = false;
            this.pb.Name = "pb";
            this.pb.ProcessShow = false;
            this.pb.ProgressImage = ((System.Drawing.Image)(resources.GetObject("pb.ProgressImage")));
            this.pb.ProgressType = MiMFa_Framework.Exclusive.Collection.MiMFa_GeneralAge.Modern;
            this.pb.SleepTime = 5000;
            this.pb.Value = 0F;
            // 
            // wb_View
            // 
            resources.ApplyResources(this.wb_View, "wb_View");
            this.wb_View.Name = "wb_View";
            this.wb_View.ScriptErrorsSuppressed = true;
            // 
            // tp_Code
            // 
            this.tp_Code.Controls.Add(this.p_Edit);
            this.tp_Code.Controls.Add(this.Edit_Tools);
            resources.ApplyResources(this.tp_Code, "tp_Code");
            this.tp_Code.Name = "tp_Code";
            this.tp_Code.UseVisualStyleBackColor = true;
            // 
            // p_Edit
            // 
            this.p_Edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Edit.Controls.Add(this.rtb_Code);
            resources.ApplyResources(this.p_Edit, "p_Edit");
            this.p_Edit.Name = "p_Edit";
            // 
            // rtb_Code
            // 
            this.rtb_Code.AcceptsTab = true;
            this.rtb_Code.AutoWordSelection = true;
            this.rtb_Code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtb_Code, "rtb_Code");
            this.rtb_Code.ForeColor = System.Drawing.Color.DimGray;
            this.rtb_Code.Name = "rtb_Code";
            // 
            // Edit_Tools
            // 
            resources.ApplyResources(this.Edit_Tools, "Edit_Tools");
            this.Edit_Tools.Controls.Add(this.EventList, 0, 3);
            this.Edit_Tools.Controls.Add(this.l_Event_Tags, 0, 2);
            this.Edit_Tools.Controls.Add(this.FeidList, 0, 5);
            this.Edit_Tools.Controls.Add(this.l_Object_TAGs, 0, 4);
            this.Edit_Tools.Controls.Add(this.TagList, 0, 1);
            this.Edit_Tools.Controls.Add(this.l_MRL_TAGs, 0, 0);
            this.Edit_Tools.Name = "Edit_Tools";
            // 
            // EventList
            // 
            this.EventList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.EventList, "EventList");
            this.EventList.FormattingEnabled = true;
            this.EventList.Name = "EventList";
            this.EventList.DoubleClick += new System.EventHandler(this.EventList_SelectedIndexChanged);
            // 
            // l_Event_Tags
            // 
            resources.ApplyResources(this.l_Event_Tags, "l_Event_Tags");
            this.l_Event_Tags.BackColor = System.Drawing.Color.Gray;
            this.l_Event_Tags.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_Event_Tags.Name = "l_Event_Tags";
            // 
            // FeidList
            // 
            this.FeidList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.FeidList, "FeidList");
            this.FeidList.FormattingEnabled = true;
            this.FeidList.Name = "FeidList";
            this.FeidList.DoubleClick += new System.EventHandler(this.FieldList_SelectedIndexChanged);
            // 
            // l_Object_TAGs
            // 
            resources.ApplyResources(this.l_Object_TAGs, "l_Object_TAGs");
            this.l_Object_TAGs.BackColor = System.Drawing.Color.Gray;
            this.l_Object_TAGs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_Object_TAGs.Name = "l_Object_TAGs";
            // 
            // TagList
            // 
            this.TagList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.TagList, "TagList");
            this.TagList.FormattingEnabled = true;
            this.TagList.Name = "TagList";
            this.TagList.DoubleClick += new System.EventHandler(this.TagListCode_SelectedIndexChanged);
            // 
            // l_MRL_TAGs
            // 
            resources.ApplyResources(this.l_MRL_TAGs, "l_MRL_TAGs");
            this.l_MRL_TAGs.BackColor = System.Drawing.Color.Gray;
            this.l_MRL_TAGs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_MRL_TAGs.Name = "l_MRL_TAGs";
            // 
            // tp_CSS
            // 
            this.tp_CSS.Controls.Add(this.p_Css);
            this.tp_CSS.Controls.Add(this.Css_Tools);
            resources.ApplyResources(this.tp_CSS, "tp_CSS");
            this.tp_CSS.Name = "tp_CSS";
            this.tp_CSS.UseVisualStyleBackColor = true;
            // 
            // p_Css
            // 
            this.p_Css.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Css.Controls.Add(this.rtb_Template);
            resources.ApplyResources(this.p_Css, "p_Css");
            this.p_Css.Name = "p_Css";
            // 
            // rtb_Template
            // 
            this.rtb_Template.AcceptsTab = true;
            this.rtb_Template.AutoWordSelection = true;
            this.rtb_Template.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtb_Template, "rtb_Template");
            this.rtb_Template.ForeColor = System.Drawing.Color.DimGray;
            this.rtb_Template.Name = "rtb_Template";
            // 
            // Css_Tools
            // 
            this.Css_Tools.Controls.Add(this.MRLTemplate);
            this.Css_Tools.Controls.Add(this.l_MRLTemplate);
            resources.ApplyResources(this.Css_Tools, "Css_Tools");
            this.Css_Tools.Name = "Css_Tools";
            // 
            // MRLTemplate
            // 
            this.MRLTemplate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.MRLTemplate, "MRLTemplate");
            this.MRLTemplate.FormattingEnabled = true;
            this.MRLTemplate.Name = "MRLTemplate";
            this.MRLTemplate.Click += new System.EventHandler(this.MRLTemplate_Click);
            // 
            // l_MRLTemplate
            // 
            this.l_MRLTemplate.BackColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.l_MRLTemplate, "l_MRLTemplate");
            this.l_MRLTemplate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.l_MRLTemplate.Name = "l_MRLTemplate";
            // 
            // tp_Script
            // 
            this.tp_Script.Controls.Add(this.rtb_Script);
            resources.ApplyResources(this.tp_Script, "tp_Script");
            this.tp_Script.Name = "tp_Script";
            this.tp_Script.UseVisualStyleBackColor = true;
            // 
            // rtb_Script
            // 
            this.rtb_Script.AcceptsTab = true;
            this.rtb_Script.AutoWordSelection = true;
            this.rtb_Script.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtb_Script, "rtb_Script");
            this.rtb_Script.ForeColor = System.Drawing.Color.DimGray;
            this.rtb_Script.Name = "rtb_Script";
            // 
            // tp_HTML
            // 
            this.tp_HTML.Controls.Add(this.rtb_HTML);
            resources.ApplyResources(this.tp_HTML, "tp_HTML");
            this.tp_HTML.Name = "tp_HTML";
            this.tp_HTML.UseVisualStyleBackColor = true;
            // 
            // rtb_HTML
            // 
            this.rtb_HTML.AcceptsTab = true;
            this.rtb_HTML.AutoWordSelection = true;
            this.rtb_HTML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtb_HTML, "rtb_HTML");
            this.rtb_HTML.ForeColor = System.Drawing.Color.DimGray;
            this.rtb_HTML.Name = "rtb_HTML";
            // 
            // ts_Main
            // 
            this.ts_Main.BackColor = System.Drawing.Color.Transparent;
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Ok,
            this.tsb_Refresh,
            this.tstb_Subject,
            this.tsb_Save,
            this.tsb_Import,
            this.tsb_Export,
            this.toolStripSeparator1,
            this.AddressViewer,
            this.tscb_EditorStyle});
            resources.ApplyResources(this.ts_Main, "ts_Main");
            this.ts_Main.Name = "ts_Main";
            // 
            // tsb_Ok
            // 
            this.tsb_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Ok.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Yes_btn;
            resources.ApplyResources(this.tsb_Ok, "tsb_Ok");
            this.tsb_Ok.Name = "tsb_Ok";
            this.tsb_Ok.Click += new System.EventHandler(this.tsb_Ok_Click);
            // 
            // tsb_Refresh
            // 
            this.tsb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsb_Refresh, "tsb_Refresh");
            this.tsb_Refresh.Name = "tsb_Refresh";
            this.tsb_Refresh.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // tstb_Subject
            // 
            resources.ApplyResources(this.tstb_Subject, "tstb_Subject");
            this.tstb_Subject.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tstb_Subject.Name = "tstb_Subject";
            this.tstb_Subject.TextChanged += new System.EventHandler(this.tstb_Subject_TextChanged);
            // 
            // tsb_Save
            // 
            this.tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Save.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Save;
            resources.ApplyResources(this.tsb_Save, "tsb_Save");
            this.tsb_Save.Name = "tsb_Save";
            this.tsb_Save.Click += new System.EventHandler(this.tsb_Save_Click);
            // 
            // tsb_Import
            // 
            this.tsb_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Import.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Import;
            resources.ApplyResources(this.tsb_Import, "tsb_Import");
            this.tsb_Import.Name = "tsb_Import";
            this.tsb_Import.Click += new System.EventHandler(this.tsb_Import_Click);
            // 
            // tsb_Export
            // 
            this.tsb_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Export.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Export;
            resources.ApplyResources(this.tsb_Export, "tsb_Export");
            this.tsb_Export.Name = "tsb_Export";
            this.tsb_Export.Click += new System.EventHandler(this.tsb_Export_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // AddressViewer
            // 
            this.AddressViewer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AddressViewer.Name = "AddressViewer";
            resources.ApplyResources(this.AddressViewer, "AddressViewer");
            // 
            // tscb_EditorStyle
            // 
            resources.ApplyResources(this.tscb_EditorStyle, "tscb_EditorStyle");
            this.tscb_EditorStyle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscb_EditorStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tscb_EditorStyle.Items.AddRange(new object[] {
            resources.GetString("tscb_EditorStyle.Items"),
            resources.GetString("tscb_EditorStyle.Items1"),
            resources.GetString("tscb_EditorStyle.Items2")});
            this.tscb_EditorStyle.Name = "tscb_EditorStyle";
            // 
            // OFD
            // 
            resources.ApplyResources(this.OFD, "OFD");
            this.OFD.RestoreDirectory = true;
            // 
            // SFD
            // 
            this.SFD.DefaultExt = "mrds";
            this.SFD.FileName = "MyReportStyle.mrds";
            resources.ApplyResources(this.SFD, "SFD");
            this.SFD.RestoreDirectory = true;
            // 
            // CMS
            // 
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.CMS.Name = "CMS";
            resources.ApplyResources(this.CMS, "CMS");
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            resources.ApplyResources(this.applyToolStripMenuItem, "applyToolStripMenuItem");
            this.applyToolStripMenuItem.Click += new System.EventHandler(this.tsb_Ok_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            resources.ApplyResources(this.refreshToolStripMenuItem, "refreshToolStripMenuItem");
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.tsb_Save_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.tsb_Export_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.Click += new System.EventHandler(this.tsb_Import_Click);
            // 
            // ReportDesigner
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.CMS;
            this.Controls.Add(this.tp_Main);
            this.Controls.Add(this.ts_Main);
            this.Name = "ReportDesigner";
            this.Load += new System.EventHandler(this.ReportDesigner_Load);
            this.tp_Main.ResumeLayout(false);
            this.tp_View.ResumeLayout(false);
            this.tp_Code.ResumeLayout(false);
            this.p_Edit.ResumeLayout(false);
            this.Edit_Tools.ResumeLayout(false);
            this.Edit_Tools.PerformLayout();
            this.tp_CSS.ResumeLayout(false);
            this.p_Css.ResumeLayout(false);
            this.Css_Tools.ResumeLayout(false);
            this.tp_Script.ResumeLayout(false);
            this.tp_HTML.ResumeLayout(false);
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.CMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tp_Main;
        private System.Windows.Forms.TabPage tp_View;
        private System.Windows.Forms.WebBrowser wb_View;
        private System.Windows.Forms.TabPage tp_Code;
        private System.Windows.Forms.TabPage tp_CSS;
        private System.Windows.Forms.TabPage tp_Script;
        private System.Windows.Forms.RichTextBox rtb_Script;
        private System.Windows.Forms.TabPage tp_HTML;
        private System.Windows.Forms.RichTextBox rtb_HTML;
        private System.Windows.Forms.TableLayoutPanel Edit_Tools;
        private System.Windows.Forms.ListBox FeidList;
        private System.Windows.Forms.ListBox TagList;
        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.ToolStripButton tsb_Export;
        private System.Windows.Forms.ToolStripButton tsb_Import;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStripButton tsb_Ok;
        private System.Windows.Forms.ToolStripButton tsb_Refresh;
        private System.Windows.Forms.Label l_Object_TAGs;
        private System.Windows.Forms.Label l_MRL_TAGs;
        private System.Windows.Forms.Panel p_Edit;
        private System.Windows.Forms.RichTextBox rtb_Code;
        private System.Windows.Forms.Panel p_Css;
        private System.Windows.Forms.RichTextBox rtb_Template;
        private System.Windows.Forms.Panel Css_Tools;
        private System.Windows.Forms.ListBox MRLTemplate;
        private System.Windows.Forms.Label l_MRLTemplate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tstb_Subject;
        private System.Windows.Forms.ToolStripComboBox tscb_EditorStyle;
        private System.Windows.Forms.ToolStripButton tsb_Save;
        private System.Windows.Forms.ListBox EventList;
        private System.Windows.Forms.Label l_Event_Tags;
        private System.Windows.Forms.ToolStripLabel AddressViewer;
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private ProgressBar.ProgressBarCycleWait pb;
    }
}
