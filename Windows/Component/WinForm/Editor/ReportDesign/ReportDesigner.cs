using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Component.WinForm.TabPage;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;

namespace MiMFa_Framework.Component.WinForm.Editor.ReportDesign
{
    public partial class ReportDesigner : Editor
    {
        #region CategoryAttribute
        [CategoryAttribute()]
        public event EventHandler RefreshClick;
        public event EventHandler DoneClick;
        public MiMFa_ReportLanguage MRL = new MiMFa_ReportLanguage();
        public ReportStyle ReportStyle = new ReportStyle();
        public Type ThisType = null;
        #endregion

        public ReportDesigner()
        {
            InitializeComponent();
            (new Exclusive.Language.MiMFa_Translator()).TryDone(Service.MiMFa_ControlService.GetAllObjects(this));
            (new Exclusive.Language.MiMFa_Translator()).TryDone(CMS);
            tp_Main.SelectedIndex = 1;
        }

        public void Initialize(Type thisType,ReportStyle reportStyle,bool subjectIsReadOnly = true)
        {
            ReportStyleCreate(thisType, reportStyle,true);
            if (reportStyle == null && thisType == null && !subjectIsReadOnly)
            {
                try
                {
                    reportStyle = new ReportStyle();
                    thisType = typeof(Exclusive.Collection.Instance.MiMFa_Instance);
                    reportStyle.Address = MRLTools.Address.ReportStyleDirectory + MRLTools.Address.DefaultName + ReportStyle.Extension;
                    MiMFa_IOService.OpenDeserializeFile(reportStyle.Address, ref reportStyle);
                }
                catch { }
            }
            if (reportStyle != null)
            {
                tstb_Subject.Text = reportStyle.Name;
                rtb_Code.Text = reportStyle.MRLCode;
                rtb_Template.Text = reportStyle.Css;
                rtb_Script.Text = reportStyle.Script;
                AddressViewer.Text = reportStyle.Address;
                if (tp_Main.SelectedIndex == 0) ViewRefresh(false);
                else if (tp_Main.SelectedIndex == 4) rtb_HTML.Text = GetVeiwHTML();
                CodeRefresh();
            }
            if (tstb_Subject.Text == "Default")
                tstb_Subject.ReadOnly = false;
            else  tstb_Subject.ReadOnly = subjectIsReadOnly;
            //Restart();
            if (TagList.Items.Count < 1)
            {
                string sreport = Environment.NewLine + "\t\t" + Environment.NewLine + "\t" + MRLTools.EndSignTag;
                string stable = Environment.NewLine + "\t\t\t" + Environment.NewLine + "\t\t" + MRLTools.EndSignTag;
                string srow = Environment.NewLine + "\t\t\t\t" + Environment.NewLine + "\t\t\t" + MRLTools.EndSignTag;
                string sdata = Environment.NewLine + "\t\t\t\t\t" + Environment.NewLine + "\t\t\t\t" + MRLTools.EndSignTag;
                string atable = Environment.NewLine + "\t\t\t" + Environment.NewLine + "\t\t" + MRLTools.EndSignAutoTag;
                string arow = Environment.NewLine + "\t\t\t\t" + Environment.NewLine + "\t\t\t" + MRLTools.EndSignAutoTag;
                string adata = Environment.NewLine + "\t\t\t\t\t" + Environment.NewLine + "\t\t\t\t" + MRLTools.EndSignAutoTag;
                TagList.Items.Clear();
                TagList.DisplayMember = "Key";
                TagList.ValueMember = "Value";
                foreach (var item in MRLTools.SimplyTagsDic.Keys)
                    if (item.StartsWith(MRLTools.StartSignAttachTag))
                        TagList.Items.Add(new KeyValuePair<string, string>(item, item + Environment.NewLine));
                TagList.Items.Add(new KeyValuePair<string, string>("Header", "HEADER> " + Environment.NewLine + "\t"));
                TagList.Items.Add(new KeyValuePair<string, string>("Content", "CONTENT> " + Environment.NewLine + "\t"));
                TagList.Items.Add(new KeyValuePair<string, string>("Footer", "FOOTER> " + Environment.NewLine + "\t"));
                TagList.Items.Add(new KeyValuePair<string, string>("Report Tag", Environment.NewLine + "\t<REPORT" + sreport));
                TagList.Items.Add(new KeyValuePair<string, string>("Report Table Tag", Environment.NewLine + "\t\t<T" + stable));
                TagList.Items.Add(new KeyValuePair<string, string>("Row Tag", Environment.NewLine + "\t\t\t<R" + srow));
                TagList.Items.Add(new KeyValuePair<string, string>("Cell Tag", Environment.NewLine + "\t\t\t\t<D" + sdata));
                TagList.Items.Add(new KeyValuePair<string, string>("Header Row Tag", Environment.NewLine + "\t\t\t<H" + srow));
                TagList.Items.Add(new KeyValuePair<string, string>("Footer Row Tag", Environment.NewLine + "\t\t\t<F" + srow));
                TagList.Items.Add(new KeyValuePair<string, string>("Header Cell Tag", Environment.NewLine + "\t\t\t\t<S" + adata));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Value Tag", Environment.NewLine + "\t\t" + MRLTools.StartSignAutoTag + "V" + atable));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Report Table Tag", Environment.NewLine + "\t\t" + MRLTools.StartSignAutoTag + "T" + atable));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Row Tag", Environment.NewLine + "\t\t\t" + MRLTools.StartSignAutoTag + "R" + arow));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Cell Tag", Environment.NewLine + "\t\t\t\t" + MRLTools.StartSignAutoTag + "D" + adata));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Header Row Tag", Environment.NewLine + "\t\t\t" + MRLTools.StartSignAutoTag + "H" + arow));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Footer Row Tag", Environment.NewLine + "\t\t\t" + MRLTools.StartSignAutoTag + "F" + arow));
                TagList.Items.Add(new KeyValuePair<string, string>("Auto Header Cell Tag", Environment.NewLine + "\t\t\t\t" + MRLTools.StartSignAutoTag + "S" + adata));
                TagList.Items.Add(new KeyValuePair<string, string>("Command", " " + MRLTools.StartSignCommandTag + "  " + MRLTools.EndSignCommandTag + " "));
                TagList.Items.Add(new KeyValuePair<string, string>("Comment Tag", " " + MRLTools.StartSignComment + "  " + MRLTools.EndSignComment + " "));
                TagList.Items.Add(new KeyValuePair<string, string>("Depletable Tag", " " + MRLTools.StartSignDepletableTag + "  " + MRLTools.EndSignDepletableTag + " "));
                TagList.Items.Add(new KeyValuePair<string, string>("Number Cell Tag", Environment.NewLine + "\t\t\t\t<DN" + sdata));
                TagList.Items.Add(new KeyValuePair<string, string>("Name Cell Tag", Environment.NewLine + "\t\t\t\t<DS" + sdata));
                TagList.Items.Add(new KeyValuePair<string, string>("Text Type Tag", " <TEXT  " + MRLTools.EndSignTag));
                TagList.Items.Add(new KeyValuePair<string, string>("Image Type Tag", " <IMAGE  " + MRLTools.EndSignTag));
                TagList.Items.Add(new KeyValuePair<string, string>("Number Type Tag", " <NUMBER  " + MRLTools.EndSignTag));
                TagList.Items.Add(new KeyValuePair<string, string>("Date Type Tag", " <DATE  " + MRLTools.EndSignTag));
                TagList.Items.Add(new KeyValuePair<string, string>("Time Type Tag", " <TIME  " + MRLTools.EndSignTag));
                TagList.Items.Add(new KeyValuePair<string, string>("List Type Tag", " <LIST  " + MRLTools.EndSignTag));
                TagList.Items.Add(new KeyValuePair<string, string>("End Tag", " " + MRLTools.EndSignTag + Environment.NewLine));
                TagList.Items.Add(new KeyValuePair<string, string>("End Auto Tag", " " + MRLTools.EndSignAutoTag + Environment.NewLine));
                TagList.Items.Add(new KeyValuePair<string, string>("Counter Command", MRLTools.StartSignCommandTag + "i = i + 1;" + MRLTools.EndSignCommandTag));

                EventList.Items.Clear();
                EventList.DisplayMember = "Key";
                EventList.ValueMember = "Value";
                EventList.Items.Add(new KeyValuePair<string, string>("Click", "data-Click=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("DoubleClick", "data-DoubleClick=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("Drag", "data-Drag=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("DragEnd", "data-DragEnd=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("DragLeave", "data-DragLeave=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("DragOver", "data-DragOver=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("Focusing", "data-Focusing=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("GotFocus", "data-GotFocus=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("KeyDown", "data-KeyDown=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("KeyPress", "data-KeyPress=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("KeyUp", "data-KeyUp=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("LosingFocus", "data-LosingFocus=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("LostFocus", "data-LostFocus=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("MouseDown", "data-MouseDown=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("MouseEnter", "data-MouseEnter=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("MouseLeave", "data-MouseLeave=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("MouseMove", "data-MouseMove=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("MouseOver", "data-MouseOver=\"\""));
                EventList.Items.Add(new KeyValuePair<string, string>("MouseUp", "data-MouseUp=\"\""));

                MRLTemplate.Items.Clear();
                MRLTemplate.DisplayMember = "Key";
                MRLTemplate.ValueMember = "Value";
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Header", ".HEADER"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Content", ".CONTENT"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Footer", ".FOOTER"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Report", ".REPORT"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Report Table", ".T{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Row", ".R{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Cell", ".D{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Header Row", ".H{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Footer Row", ".F{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Header Cell", ".S{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Value", ".AV"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Report Table", ".AT"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Row", ".AR"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Cell", ".AD"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Header Row", ".AH{"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Footer Row", ".AF"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Auto Header Cell", ".AS"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Number Cell", ".DN"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Name Cell", ".DS"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Text Type", ".TEXT"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Image Type", ".IMAGE"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Number Type", ".NUMBER"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Date Type", ".DATE"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("Time Type", ".TIME"));
                MRLTemplate.Items.Add(new KeyValuePair<string, string>("List Type", ".LIST"));
            }

            if (thisType != null)
            {
                ThisType = thisType;
                List<string> ls = GetAllFieldAndProperty();
                FeidList.Items.Clear();
                foreach (var item in ls)
                    FeidList.Items.Add(item);
            }
        }
        public void Restart(bool viewDocument = true)
        {
            ReportStyle.MRLCode = rtb_Code.Text;
            ReportStyle.Css = rtb_Template.Text;
            ReportStyle.Script = rtb_Script.Text;
            if(viewDocument) wb_View.DocumentText = rtb_HTML.Text = GetVeiwHTML();

        }

        public void ReportStyleCreate(Type thisType = null, ReportStyle reportStyle = null, bool refrence = false)
        {
            if (thisType != null) ThisType = thisType;
            if (reportStyle != null && refrence) ReportStyle = reportStyle;
            else if (reportStyle != null && !refrence)
                ReportStyle = new ReportStyle(reportStyle);
        }
        public List<string> GetAllFieldAndProperty()
        {
            List<string> ls = new List<string>();
            if (ThisType != null)
            {
                FieldInfo[] fi = ThisType.GetFields();
                foreach (var item in fi)
                    ls.Add(item.Name);
                PropertyInfo[] pi = ThisType.GetProperties();
                foreach (var item in pi)
                    ls.Add(item.Name);
            }
            return ls;
        }
        public string GetVeiwHTML()
        {
            return MRL.CompileToHTML(ReportStyle);
        }

        #region private

        private void ReportDesigner_Load(object sender, EventArgs e)
        {
        }
        private void tlp_Main_TabIndexChanged(object sender, EventArgs e)
        {
            switch (tp_Main.SelectedIndex)
            {
                case 0:
                    //HTMLRefresh();
                    ViewRefresh();
                    break;
                case 1:
                    CodeRefresh();
                    break;
                case 2:
                    CssRefresh();
                    break;
                case 3:
                    ScriptRefresh();
                    break;
                case 4:
                    HTMLRefresh();
                    break;
                default:
                    break;
            }
        }
        private void tstb_Subject_TextChanged(object sender, EventArgs e)
        {
            ReportStyle.Name = tstb_Subject.Text;
        }
        private void tsb_Export_Click(object sender, EventArgs e)
        {
            Restart(false);
            SFD.Filter = "MiMfa Report Package Style File (*" + ReportStyle.Extension + ") | *" + ReportStyle.Extension;
            SFD.FileName = ReportStyle.Name;
            if (SFD.InitialDirectory == null) SFD.InitialDirectory = ReportStyle.GetPath();
            if (!string.IsNullOrEmpty(SFD.FileName))
                SFD.FileName = ReportStyle.Address;
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                ReportStyle rs = new ReportStyle()
                {
                    RSID = ReportStyle.RSID,
                    Name = ReportStyle.Name,
                    Address = ReportStyle.Address,
                    MRLCode = ReportStyle.MRLCode,
                    Css = ReportStyle.Css,
                    Script = ReportStyle.Script,
                    Extra = ReportStyle.Extra
                };
                MiMFa_IOService.SaveSerializeFile(SFD.FileName, rs);
            }
        }
        private void tsb_Import_Click(object sender, EventArgs e)
        {
            OFD.Filter = "MiMfa Report Package Style File (*" + ReportStyle.Extension + ") | *" + ReportStyle.Extension;
            if (OFD.InitialDirectory == null) OFD.InitialDirectory = ReportStyle.GetPath();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                ReportStyle report = new ReportStyle();
                MiMFa_IOService.OpenDeserializeFile(OFD.FileName, ref report);
                if (string.IsNullOrEmpty(tstb_Subject.Text) || tstb_Subject.Text == "Default") ReportStyle = report;
                else
                {
                    ReportStyle.MRLCode = report.MRLCode;
                    ReportStyle.Script = report.Script;
                    ReportStyle.Css = report.Css;
                    ReportStyle.Extra = report.Extra;
                }
                ReportStyle.Address = OFD.FileName;
            }
            Initialize(null,ReportStyle,false);
        }
        private void tsb_Save_Click(object sender, EventArgs e)
        {
            Restart(false);
            MiMFa_IOService.SaveSerializeFile(ReportStyle.Address, ReportStyle);
        }
        private void tsb_Ok_Click(object sender, EventArgs e)
        {
            Restart(false);
            if (DoneClick != null) DoneClick(sender, e);
            //MiMFa_IOService.SaveSerializeFile(ReportStyle.Address, ReportStyle);
        }
        private void tsb_Refresh_Click(object sender, EventArgs e)
        {
            if (RefreshClick != null) RefreshClick(sender, e);
            Initialize(null,ReportStyle);
        }
        private void TagListCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TagList.SelectedIndex > -1)
            {
                int sel = rtb_Code.SelectionIndent;
                int ss = rtb_Code.SelectionStart;
                rtb_Code.Focus();
                string tag =  ((KeyValuePair<string, string>)TagList.SelectedItem).Value ;
                rtb_Code.SelectionIndent= sel ;
                rtb_Code.SelectionStart= ss ;
                rtb_Code.SelectedText = tag;
            }
        }
        private void FieldList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (FeidList.SelectedIndex > -1)
                {
                    rtb_Code.Focus();
                    int sel = rtb_Code.SelectionIndent;
                    int ss = rtb_Code.SelectionStart;
                    if (rtb_Code.SelectionStart <= 0) rtb_Code.SelectionStart = 0;
                    if (rtb_Code.SelectionStart > 2)
                        if (rtb_Code.Text[rtb_Code.SelectionStart - 1] == '.'
                            || rtb_Code.Text.Substring(rtb_Code.SelectionStart - 2).StartsWith(MRLTools.StartSignFieldTag)
                            || rtb_Code.Text.Substring(rtb_Code.SelectionStart).StartsWith(MRLTools.StartSignFieldTag))
                            rtb_Code.SelectedText = FeidList.SelectedItem.ToString();
                        else rtb_Code.SelectedText = MRLTools.StartSignFieldTag + FeidList.SelectedItem.ToString() + MRLTools.EndSignFieldTag;
                    else rtb_Code.SelectedText = MRLTools.StartSignFieldTag + FeidList.SelectedItem.ToString() + MRLTools.EndSignFieldTag;
                    rtb_Code.SelectionIndent = sel;
                    rtb_Code.SelectionStart = ss + FeidList.SelectedItem.ToString().Length + MRLTools.StartSignFieldTag.Length;
                }
            }
            catch { }
        }
        private void EventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (EventList.SelectedIndex > -1)
                {
                    rtb_Code.Focus();
                    int sel = rtb_Code.SelectionIndent;
                    int ss = rtb_Code.SelectionStart;
                    if (rtb_Code.SelectionStart <= 0) rtb_Code.SelectionStart = 0;
                    string tag = " " + ((KeyValuePair<string,string>)EventList.SelectedItem).Value + " ";
                    rtb_Code.SelectedText = tag;
                    rtb_Code.SelectionIndent = sel;
                    rtb_Code.SelectionStart = ss + tag.Length - 2;
                }
            }
            catch { }
        }
        private void MRLTemplate_Click(object sender, EventArgs e)
        {
            rtb_Template.Focus();
            string tag = ((KeyValuePair<string, string>)MRLTemplate.SelectedItem).Value;
            for (int i = 0; i < rtb_Template.Text.Length; i++)
                if (rtb_Template.Text.Substring(i).Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").StartsWith(tag))
                {
                    rtb_Template.SelectionStart = i+1;
                    rtb_Template.ScrollToCaret();
                    rtb_Template.SelectionLength = tag.Length;
                    return;
                }
            rtb_Template.AppendText(Environment.NewLine + tag + Environment.NewLine + Environment.NewLine + "}");
        }

        #region Editor
        private void ViewRefresh(bool restart = true)
        {
           if(restart) Restart(false);
            pb.Visible = true;
            MiMFa_ControlService.ThreadExecuteInControl(
                Exclusive.Collection.MiMFa_ThreadingMethod.Default,
                wb_View,new Action<object[]>(
                    (args)=>
                    {
                        MiMFa_ControlService.WebBrowserDocumentText(ref wb_View, GetVeiwHTML());
                        pb.Visible = false;
                    })
                    , new object[] { });
        }
        private void CodeRefresh()
        {
            //RichTextBox rtb = new RichTextBox();
            int sel = rtb_Code.SelectionIndent;
            int ss = rtb_Code.SelectionStart;
            if (tscb_EditorStyle.SelectedIndex < 2)
            {
                RichTextBox rtb = rtb_Code;
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignTag, MRLTools.EndSignTag, Color.Black);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignAttributeTag, MRLTools.EndSignAttributeTag, Color.Gray);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignAttachTag, MRLTools.EndSignAttachTag, Color.ForestGreen);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignAutoTag, MRLTools.EndSignAutoTag, Color.SlateBlue);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignFieldTag, MRLTools.EndSignFieldTag, Color.Red);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "HEADER", ">", Color.Crimson);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "CONTENT", ">", Color.Crimson);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "FOOTER", ">", Color.Crimson);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignCommandTag[0].ToString(), MRLTools.EndSignCommandTag, Color.DarkViolet);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignCommandTag, MRLTools.EndSignCommandTag, Color.DarkViolet);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignParenthesis, MRLTools.EndSignParenthesis, Color.DarkCyan);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "'", "'", Color.DarkRed);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignString, MRLTools.EndSignString, Color.DarkRed);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignStrongString, MRLTools.EndSignStrongString, Color.DarkRed);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignComment, MRLTools.EndSignComment, Color.LightGreen);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, MRLTools.StartSignDepletableTag, MRLTools.EndSignDepletableTag, Color.DarkGray);
                //rtb_Code = rtb;
            }
            rtb_Code.SelectionStart = ss;
            rtb_Code.SelectionIndent = sel;
            ReportStyle.MRLCode = rtb_Code.Text;
        }
        private void CssRefresh()
        {
            //RichTextBox rtb = new RichTextBox();
            int sel = rtb_Template.SelectionIndent;
            int ss = rtb_Template.SelectionStart;
            if (tscb_EditorStyle.SelectedIndex < 3)
            {
                RichTextBox rtb = rtb_Template;
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, ".", "{", Color.Firebrick);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "{", "}", Color.OrangeRed);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, ":", ";", Color.Blue);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "<!-", "->", Color.LightGreen);
                //rtb_Template = rtb;
            }
            rtb_Template.SelectionStart = ss;
            rtb_Template.SelectionIndent = sel;
            ReportStyle.Css = rtb_Template.Text;
        }
        private void ScriptRefresh()
        {
            //RichTextBox rtb = new RichTextBox();
            int sel = rtb_Script.SelectionIndent;
            int ss = rtb_Script.SelectionStart;
            if (tscb_EditorStyle.SelectedIndex < 4)
            {
                RichTextBox rtb = rtb_Script;
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "}", "{", Color.Black);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "(", ")", Color.DarkCyan);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "{", "}", Color.Black);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, ";", ";", Color.Maroon);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "/*", "*/", Color.LightGreen);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "//", Environment.NewLine, Color.LightGreen);
                //rtb_Script = rtb;
            }
            rtb_Script.SelectionStart = ss;
            rtb_Script.SelectionIndent = sel;
            ReportStyle.Script = rtb_Script.Text;
        }
        private void HTMLRefresh()
        {
            Restart(false);
            rtb_HTML.Text = GetVeiwHTML();
            //RichTextBox rtb = new RichTextBox();
            int sel = rtb_HTML.SelectionIndent;
            int ss = rtb_HTML.SelectionStart;
            if (tscb_EditorStyle.SelectedIndex < 5)
            {
                RichTextBox rtb = rtb_HTML;
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "\"", "\"", Color.DarkRed);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "'", "'", Color.DarkRed);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "<", ">", Color.Maroon);
                MiMFa_ControlService.RichTextBoxChangeWordColor(ref rtb, "<!--", "-->", Color.LightGreen);
                //rtb_HTML = rtb;
            }
            rtb_HTML.SelectionStart = ss;
            rtb_HTML.SelectionIndent = sel;
        }
        #endregion

    }
        #endregion
}
