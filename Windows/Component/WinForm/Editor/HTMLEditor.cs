using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Component.WinForm.Editor
{
    public partial class HTMLEditor : Editor
    {
        #region 
        [Category]
        public string Value
        {
            get { return RTB.Text; }
            set {  RTB.Text = value; }
        }
        public override string Text
        {
            get { return RTB.Text; }
            set {  RTB.Text = value; }
        }
        public string[] Lines
        {
            get { return RTB.Lines; }
            set {  RTB.Lines = value; }
        }
        public bool ShowMenuBar
        {
            get { return TS.Visible; }
            set { TS.Visible = value; }
        }
        public RichTextBoxScrollBars ScrollBars
        {
            get { return RTB.ScrollBars; }
            set { RTB.ScrollBars = value; }
        }
        public override Point AutoScrollOffset
        {
            get { return RTB.AutoScrollOffset; }
            set { RTB.AutoScrollOffset = value; }
        }
        public bool AutoWordSelection
        {
            get { return RTB.AutoWordSelection; }
            set { RTB.AutoWordSelection = value; }
        }
        public bool EnableAutoDragDrop
        {
            get { return RTB.EnableAutoDragDrop; }
            set { RTB.EnableAutoDragDrop = value; }
        }
        #endregion

        public HTMLEditor()
        {
            InitializeComponent();
        }

        public void InsertTag(string starttag, string endtag)
        {
            int l = RTB.SelectionStart;
            string st = RTB.SelectedText;
            RTB.SelectedText = starttag + st + endtag;
            RTB.SelectionStart = l + starttag.Length;
        }
        public void Clear()
        {
            RTB.Clear();
        }
        private void View_Click(object sender, EventArgs e)
        {
            Exclusive.ProgramingTechnology.CommandLanguage.MiMFa_CommandLanguage MCL = new Exclusive.ProgramingTechnology.CommandLanguage.MiMFa_CommandLanguage(Exclusive.Display.MiMFa_DisplayType.HTML);
            Form f = new Form();
            WebBrowser fv = new WebBrowser();
            fv.SuspendLayout();
            f.SuspendLayout();
            fv.Dock = DockStyle.Fill;
            f.Controls.Add(fv);
            MiMFa_ControlService.WebBrowserDocumentText(ref fv, "<html><body>" + MCL.CompileText(RTB.Text) + "</body></html>");
            fv.ResumeLayout();
            fv.PerformLayout();
            f.ResumeLayout();
            f.PerformLayout();
            f.TopMost = true;
            f.ShowDialog();
        }
        private void toHTML_Click(object sender, EventArgs e)
        {
            RTB.Text = MiMFa_StringService.ToHTML(RTB.Text);
        }

        private void font_bold_Click(object sender, EventArgs e)
        {
            InsertTag("<b>", "</b>");
        }
        private void font_italic_Click(object sender, EventArgs e)
        {
            InsertTag("<i>", "</i>");
        }
        private void font_upline_Click(object sender, EventArgs e)
        {
            InsertTag("<span style='text-decoration:overline;'>", "</span>");
        }
        private void font_middleline_Click(object sender, EventArgs e)
        {
            InsertTag("<del>", "</del>");
        }
        private void font_underline_Click(object sender, EventArgs e)
        {
            InsertTag("<ins>", "</ins>");
        }

        private void direction_ltr_Click(object sender, EventArgs e)
        {
            InsertTag("<div style='direction:ltr;'>", "</div>");
        }
        private void direction_rtl_Click(object sender, EventArgs e)
        {
            InsertTag("<div style='direction:rtl;'>", "</div>");
        }
        private void alignment_ltr_Click(object sender, EventArgs e)
        {
            InsertTag("<div style='text-align:left;'>", "</div>");
        }
        private void alignment_center_Click(object sender, EventArgs e)
        {
            InsertTag("<div style='text-align:center;'>", "</div>");
        }
        private void alignment_rtl_Click(object sender, EventArgs e)
        {
            InsertTag("<div style='text-align:right;'>", "</div>");
        }
        private void alignment_top_Click(object sender, EventArgs e)
        {
            InsertTag("<sup>", "</sup>");
        }
        private void alignment_bottom_Click(object sender, EventArgs e)
        {
            InsertTag("<sub>", "</sub>");
        }

        private void tag_MCL_Click(object sender, EventArgs e)
        {
            InsertTag("#{", "}#");
        }
        private void tag_br_Click(object sender, EventArgs e)
        {
            InsertTag("<br/>", "");
        }
        private void tag_nbsp_Click(object sender, EventArgs e)
        {
            InsertTag("&nbsp;", "");
        }
        private void tag_hr_Click(object sender, EventArgs e)
        {
            InsertTag("<hr/>", "");
        }

        private void paragraph_paragraph_Click(object sender, EventArgs e)
        {
            InsertTag("<p>", "</p>");
        }
        private void paragraph_preformatted_Click(object sender, EventArgs e)
        {
            InsertTag("<pre>", "</pre>");
        }
        private void paragraph_blockquote_Click(object sender, EventArgs e)
        {
            InsertTag("<blockquote>", "</blockquote>");
        }
        private void paragraph_quote_Click(object sender, EventArgs e)
        {
            InsertTag("<quote>", "</quote>");
        }
        private void paragraph_address_Click(object sender, EventArgs e)
        {
            InsertTag("<address>", "</address>");
        }
        private void paragraph_tooltip_Click(object sender, EventArgs e)
        {
            InsertTag("<abbr title='", "'></abbr>");
        }

        private void heading_1_Click(object sender, EventArgs e)
        {
            InsertTag("<h1>", "</h1>");
        }
        private void heading_2_Click(object sender, EventArgs e)
        {
            InsertTag("<h2>", "</h2>");

        }
        private void heading_3_Click(object sender, EventArgs e)
        {
            InsertTag("<h3>", "</h3>");

        }
        private void heading_4_Click(object sender, EventArgs e)
        {
            InsertTag("<h4>", "</h4>");

        }
        private void heading_5_Click(object sender, EventArgs e)
        {
            InsertTag("<h5>", "</h5>");

        }
        private void heading_6_Click(object sender, EventArgs e)
        {
            InsertTag("<h6>", "</h6>");
        }

        private void readyTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TS.Visible = !TS.Visible;
        }

        private void other_Calc_Click(object sender, EventArgs e)
        {
            InsertTag("#{process -R \"calc\";", "}#");
        }
        private void other_Notepad_Click(object sender, EventArgs e)
        {
            InsertTag("#{process -R \"notepad\";", "}#");
        }
        private void other_addcalc_Click(object sender, EventArgs e)
        {
            InsertTag("#{calculator;", "}#");
        }
        private void other_addclock_Click(object sender, EventArgs e)
        {
            InsertTag("#{clock;", "}#");
        }
        private void other_time_Click(object sender, EventArgs e)
        {
            InsertTag("#{get time;", "}#");
        }
        private void other_adddate_Click(object sender, EventArgs e)
        {
            InsertTag("#{get date;", "}#");
        }
    }
}
