namespace MiMFa_Framework.Component.WinForm.Editor
{
    partial class HTMLEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTMLEditor));
            this.TS = new System.Windows.Forms.ToolStrip();
            this.font = new System.Windows.Forms.ToolStripDropDownButton();
            this.font_bold = new System.Windows.Forms.ToolStripMenuItem();
            this.font_italic = new System.Windows.Forms.ToolStripMenuItem();
            this.font_OverLine = new System.Windows.Forms.ToolStripMenuItem();
            this.font_MiddleLine = new System.Windows.Forms.ToolStripMenuItem();
            this.font_UnderLine = new System.Windows.Forms.ToolStripMenuItem();
            this.alignment = new System.Windows.Forms.ToolStripDropDownButton();
            this.direction_ltr = new System.Windows.Forms.ToolStripMenuItem();
            this.direction_rtl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.alignment_ltr = new System.Windows.Forms.ToolStripMenuItem();
            this.alignment_center = new System.Windows.Forms.ToolStripMenuItem();
            this.alignment_rtl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.alignment_top = new System.Windows.Forms.ToolStripMenuItem();
            this.alignment_bottom = new System.Windows.Forms.ToolStripMenuItem();
            this.tag = new System.Windows.Forms.ToolStripDropDownButton();
            this.tag_MCL = new System.Windows.Forms.ToolStripMenuItem();
            this.tag_br = new System.Windows.Forms.ToolStripMenuItem();
            this.tag_nbsp = new System.Windows.Forms.ToolStripMenuItem();
            this.tag_hr = new System.Windows.Forms.ToolStripMenuItem();
            this.paragraph = new System.Windows.Forms.ToolStripDropDownButton();
            this.paragraph_paragraph = new System.Windows.Forms.ToolStripMenuItem();
            this.paragraph_preformatted = new System.Windows.Forms.ToolStripMenuItem();
            this.paragraph_blockQuote = new System.Windows.Forms.ToolStripMenuItem();
            this.paragraph_quote = new System.Windows.Forms.ToolStripMenuItem();
            this.paragraph_address = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.paragraph_toolTip = new System.Windows.Forms.ToolStripMenuItem();
            this.heading = new System.Windows.Forms.ToolStripDropDownButton();
            this.heading_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.heading_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.heading_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.heading_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.heading_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.heading_6 = new System.Windows.Forms.ToolStripMenuItem();
            this.View = new System.Windows.Forms.ToolStripButton();
            this.other = new System.Windows.Forms.ToolStripDropDownButton();
            this.other_Calc = new System.Windows.Forms.ToolStripMenuItem();
            this.other_Notepad = new System.Windows.Forms.ToolStripMenuItem();
            this.other_addcalc = new System.Windows.Forms.ToolStripMenuItem();
            this.other_addclock = new System.Windows.Forms.ToolStripMenuItem();
            this.other_time = new System.Windows.Forms.ToolStripMenuItem();
            this.other_adddate = new System.Windows.Forms.ToolStripMenuItem();
            this.Main = new System.Windows.Forms.ToolStripDropDownButton();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readyTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.TS.SuspendLayout();
            this.SuspendLayout();
            // 
            // TS
            // 
            this.TS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.font,
            this.alignment,
            this.tag,
            this.paragraph,
            this.heading,
            this.View,
            this.other,
            this.Main});
            this.TS.Location = new System.Drawing.Point(0, 0);
            this.TS.Name = "TS";
            this.TS.Size = new System.Drawing.Size(446, 25);
            this.TS.TabIndex = 0;
            this.TS.Text = "toolStrip1";
            // 
            // font
            // 
            this.font.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.font.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.font_bold,
            this.font_italic,
            this.font_OverLine,
            this.font_MiddleLine,
            this.font_UnderLine});
            this.font.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Font;
            this.font.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.font.Name = "font";
            this.font.Size = new System.Drawing.Size(29, 22);
            this.font.Text = "Font";
            // 
            // font_bold
            // 
            this.font_bold.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Font_Bold;
            this.font_bold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.font_bold.Name = "font_bold";
            this.font_bold.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.font_bold.Size = new System.Drawing.Size(178, 22);
            this.font_bold.Text = "Bold";
            this.font_bold.Click += new System.EventHandler(this.font_bold_Click);
            // 
            // font_italic
            // 
            this.font_italic.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Font_Italic;
            this.font_italic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.font_italic.Name = "font_italic";
            this.font_italic.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.font_italic.Size = new System.Drawing.Size(178, 22);
            this.font_italic.Text = "Italic";
            this.font_italic.Click += new System.EventHandler(this.font_italic_Click);
            // 
            // font_OverLine
            // 
            this.font_OverLine.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Font_UpLine;
            this.font_OverLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.font_OverLine.Name = "font_OverLine";
            this.font_OverLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.font_OverLine.Size = new System.Drawing.Size(178, 22);
            this.font_OverLine.Text = "OverLine";
            this.font_OverLine.Click += new System.EventHandler(this.font_upline_Click);
            // 
            // font_MiddleLine
            // 
            this.font_MiddleLine.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Font_MiddleLine;
            this.font_MiddleLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.font_MiddleLine.Name = "font_MiddleLine";
            this.font_MiddleLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.font_MiddleLine.Size = new System.Drawing.Size(178, 22);
            this.font_MiddleLine.Text = "MiddleLine";
            this.font_MiddleLine.Click += new System.EventHandler(this.font_middleline_Click);
            // 
            // font_UnderLine
            // 
            this.font_UnderLine.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Font_UnderLine;
            this.font_UnderLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.font_UnderLine.Name = "font_UnderLine";
            this.font_UnderLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.font_UnderLine.Size = new System.Drawing.Size(178, 22);
            this.font_UnderLine.Text = "UnderLine";
            this.font_UnderLine.Click += new System.EventHandler(this.font_underline_Click);
            // 
            // alignment
            // 
            this.alignment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.alignment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.direction_ltr,
            this.direction_rtl,
            this.toolStripSeparator1,
            this.alignment_ltr,
            this.alignment_center,
            this.alignment_rtl,
            this.toolStripSeparator3,
            this.alignment_top,
            this.alignment_bottom});
            this.alignment.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Align;
            this.alignment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignment.Name = "alignment";
            this.alignment.Size = new System.Drawing.Size(29, 22);
            this.alignment.Text = "Alignment";
            // 
            // direction_ltr
            // 
            this.direction_ltr.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Directin_LTR;
            this.direction_ltr.Name = "direction_ltr";
            this.direction_ltr.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Left)));
            this.direction_ltr.Size = new System.Drawing.Size(238, 22);
            this.direction_ltr.Text = "LTR Direction";
            this.direction_ltr.Click += new System.EventHandler(this.direction_ltr_Click);
            // 
            // direction_rtl
            // 
            this.direction_rtl.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Direction_RTL;
            this.direction_rtl.Name = "direction_rtl";
            this.direction_rtl.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Right)));
            this.direction_rtl.Size = new System.Drawing.Size(238, 22);
            this.direction_rtl.Text = "RTL Direction";
            this.direction_rtl.Click += new System.EventHandler(this.direction_rtl_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // alignment_ltr
            // 
            this.alignment_ltr.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_LTR_Align;
            this.alignment_ltr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignment_ltr.Name = "alignment_ltr";
            this.alignment_ltr.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.alignment_ltr.Size = new System.Drawing.Size(238, 22);
            this.alignment_ltr.Text = "Left to right";
            this.alignment_ltr.Click += new System.EventHandler(this.alignment_ltr_Click);
            // 
            // alignment_center
            // 
            this.alignment_center.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Center_Align;
            this.alignment_center.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignment_center.Name = "alignment_center";
            this.alignment_center.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.alignment_center.Size = new System.Drawing.Size(238, 22);
            this.alignment_center.Text = "Center";
            this.alignment_center.Click += new System.EventHandler(this.alignment_center_Click);
            // 
            // alignment_rtl
            // 
            this.alignment_rtl.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_RTL_Align;
            this.alignment_rtl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignment_rtl.Name = "alignment_rtl";
            this.alignment_rtl.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.alignment_rtl.Size = new System.Drawing.Size(238, 22);
            this.alignment_rtl.Text = "Right to left";
            this.alignment_rtl.Click += new System.EventHandler(this.alignment_rtl_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(235, 6);
            // 
            // alignment_top
            // 
            this.alignment_top.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Top_Align;
            this.alignment_top.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignment_top.Name = "alignment_top";
            this.alignment_top.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Up)));
            this.alignment_top.Size = new System.Drawing.Size(238, 22);
            this.alignment_top.Text = "Top";
            this.alignment_top.Click += new System.EventHandler(this.alignment_top_Click);
            // 
            // alignment_bottom
            // 
            this.alignment_bottom.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Bottom_Align;
            this.alignment_bottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.alignment_bottom.Name = "alignment_bottom";
            this.alignment_bottom.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.alignment_bottom.Size = new System.Drawing.Size(238, 22);
            this.alignment_bottom.Text = "Bottom";
            this.alignment_bottom.Click += new System.EventHandler(this.alignment_bottom_Click);
            // 
            // tag
            // 
            this.tag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tag.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tag_MCL,
            this.tag_br,
            this.tag_nbsp,
            this.tag_hr});
            this.tag.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(53, 22);
            this.tag.Text = "Useful";
            // 
            // tag_MCL
            // 
            this.tag_MCL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tag_MCL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tag_MCL.Name = "tag_MCL";
            this.tag_MCL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Tab)));
            this.tag_MCL.Size = new System.Drawing.Size(197, 22);
            this.tag_MCL.Text = "Command";
            this.tag_MCL.Click += new System.EventHandler(this.tag_MCL_Click);
            // 
            // tag_br
            // 
            this.tag_br.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tag_br.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tag_br.Name = "tag_br";
            this.tag_br.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.tag_br.Size = new System.Drawing.Size(197, 22);
            this.tag_br.Text = "Break Line";
            this.tag_br.Click += new System.EventHandler(this.tag_br_Click);
            // 
            // tag_nbsp
            // 
            this.tag_nbsp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tag_nbsp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tag_nbsp.Name = "tag_nbsp";
            this.tag_nbsp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.tag_nbsp.Size = new System.Drawing.Size(197, 22);
            this.tag_nbsp.Text = "Space";
            this.tag_nbsp.Click += new System.EventHandler(this.tag_nbsp_Click);
            // 
            // tag_hr
            // 
            this.tag_hr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tag_hr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tag_hr.Name = "tag_hr";
            this.tag_hr.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tag_hr.Size = new System.Drawing.Size(197, 22);
            this.tag_hr.Text = "Horizental Role";
            this.tag_hr.Click += new System.EventHandler(this.tag_hr_Click);
            // 
            // paragraph
            // 
            this.paragraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paragraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paragraph_paragraph,
            this.paragraph_preformatted,
            this.paragraph_blockQuote,
            this.paragraph_quote,
            this.paragraph_address,
            this.toolStripSeparator2,
            this.paragraph_toolTip});
            this.paragraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paragraph.Name = "paragraph";
            this.paragraph.Size = new System.Drawing.Size(74, 22);
            this.paragraph.Text = "Paragraph";
            // 
            // paragraph_paragraph
            // 
            this.paragraph_paragraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paragraph_paragraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paragraph_paragraph.Name = "paragraph_paragraph";
            this.paragraph_paragraph.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.paragraph_paragraph.Size = new System.Drawing.Size(185, 22);
            this.paragraph_paragraph.Text = "Paragraph";
            this.paragraph_paragraph.Click += new System.EventHandler(this.paragraph_paragraph_Click);
            // 
            // paragraph_preformatted
            // 
            this.paragraph_preformatted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.paragraph_preformatted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paragraph_preformatted.Name = "paragraph_preformatted";
            this.paragraph_preformatted.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.paragraph_preformatted.Size = new System.Drawing.Size(185, 22);
            this.paragraph_preformatted.Text = "Preformatted";
            this.paragraph_preformatted.Click += new System.EventHandler(this.paragraph_preformatted_Click);
            // 
            // paragraph_blockQuote
            // 
            this.paragraph_blockQuote.Name = "paragraph_blockQuote";
            this.paragraph_blockQuote.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.paragraph_blockQuote.Size = new System.Drawing.Size(185, 22);
            this.paragraph_blockQuote.Text = "BlockQuote";
            this.paragraph_blockQuote.Click += new System.EventHandler(this.paragraph_blockquote_Click);
            // 
            // paragraph_quote
            // 
            this.paragraph_quote.Name = "paragraph_quote";
            this.paragraph_quote.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.paragraph_quote.Size = new System.Drawing.Size(185, 22);
            this.paragraph_quote.Text = "Quote";
            this.paragraph_quote.Click += new System.EventHandler(this.paragraph_quote_Click);
            // 
            // paragraph_address
            // 
            this.paragraph_address.Name = "paragraph_address";
            this.paragraph_address.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.paragraph_address.Size = new System.Drawing.Size(185, 22);
            this.paragraph_address.Text = "Address";
            this.paragraph_address.Click += new System.EventHandler(this.paragraph_address_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // paragraph_toolTip
            // 
            this.paragraph_toolTip.Name = "paragraph_toolTip";
            this.paragraph_toolTip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.paragraph_toolTip.Size = new System.Drawing.Size(185, 22);
            this.paragraph_toolTip.Text = "ToolTip";
            this.paragraph_toolTip.Click += new System.EventHandler(this.paragraph_tooltip_Click);
            // 
            // heading
            // 
            this.heading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heading_1,
            this.heading_2,
            this.heading_3,
            this.heading_4,
            this.heading_5,
            this.heading_6});
            this.heading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(65, 22);
            this.heading.Text = "Heading";
            // 
            // heading_1
            // 
            this.heading_1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading_1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading_1.Name = "heading_1";
            this.heading_1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.heading_1.Size = new System.Drawing.Size(168, 22);
            this.heading_1.Text = "Heading 1";
            this.heading_1.Click += new System.EventHandler(this.heading_1_Click);
            // 
            // heading_2
            // 
            this.heading_2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading_2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading_2.Name = "heading_2";
            this.heading_2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.heading_2.Size = new System.Drawing.Size(168, 22);
            this.heading_2.Text = "Heading 2";
            this.heading_2.Click += new System.EventHandler(this.heading_2_Click);
            // 
            // heading_3
            // 
            this.heading_3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading_3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading_3.Name = "heading_3";
            this.heading_3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.heading_3.Size = new System.Drawing.Size(168, 22);
            this.heading_3.Text = "Heading 3";
            this.heading_3.Click += new System.EventHandler(this.heading_3_Click);
            // 
            // heading_4
            // 
            this.heading_4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading_4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading_4.Name = "heading_4";
            this.heading_4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.heading_4.Size = new System.Drawing.Size(168, 22);
            this.heading_4.Text = "Heading 4";
            this.heading_4.Click += new System.EventHandler(this.heading_4_Click);
            // 
            // heading_5
            // 
            this.heading_5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading_5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading_5.Name = "heading_5";
            this.heading_5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.heading_5.Size = new System.Drawing.Size(168, 22);
            this.heading_5.Text = "Heading 5";
            this.heading_5.Click += new System.EventHandler(this.heading_5_Click);
            // 
            // heading_6
            // 
            this.heading_6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.heading_6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heading_6.Name = "heading_6";
            this.heading_6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.heading_6.Size = new System.Drawing.Size(168, 22);
            this.heading_6.Text = "Heading 6";
            this.heading_6.Click += new System.EventHandler(this.heading_6_Click);
            // 
            // View
            // 
            this.View.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.View.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Eye;
            this.View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.View.Name = "View";
            this.View.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.View.Size = new System.Drawing.Size(30, 22);
            this.View.Text = "View";
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // other
            // 
            this.other.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.other_Calc,
            this.other_Notepad,
            this.other_addcalc,
            this.other_addclock,
            this.other_time,
            this.other_adddate});
            this.other.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(50, 22);
            this.other.Text = "Other";
            // 
            // other_Calc
            // 
            this.other_Calc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other_Calc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other_Calc.Name = "other_Calc";
            this.other_Calc.Size = new System.Drawing.Size(177, 22);
            this.other_Calc.Text = "Calculator Software";
            this.other_Calc.Click += new System.EventHandler(this.other_Calc_Click);
            // 
            // other_Notepad
            // 
            this.other_Notepad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other_Notepad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other_Notepad.Name = "other_Notepad";
            this.other_Notepad.Size = new System.Drawing.Size(177, 22);
            this.other_Notepad.Text = "Notepad Software";
            this.other_Notepad.Click += new System.EventHandler(this.other_Notepad_Click);
            // 
            // other_addcalc
            // 
            this.other_addcalc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other_addcalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other_addcalc.Name = "other_addcalc";
            this.other_addcalc.Size = new System.Drawing.Size(177, 22);
            this.other_addcalc.Text = "Add Calculator";
            this.other_addcalc.Click += new System.EventHandler(this.other_addcalc_Click);
            // 
            // other_addclock
            // 
            this.other_addclock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other_addclock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other_addclock.Name = "other_addclock";
            this.other_addclock.Size = new System.Drawing.Size(177, 22);
            this.other_addclock.Text = "Add Clock";
            this.other_addclock.Click += new System.EventHandler(this.other_addclock_Click);
            // 
            // other_time
            // 
            this.other_time.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other_time.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other_time.Name = "other_time";
            this.other_time.Size = new System.Drawing.Size(177, 22);
            this.other_time.Text = "Add Time";
            this.other_time.Click += new System.EventHandler(this.other_time_Click);
            // 
            // other_adddate
            // 
            this.other_adddate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.other_adddate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.other_adddate.Name = "other_adddate";
            this.other_adddate.Size = new System.Drawing.Size(177, 22);
            this.other_adddate.Text = "Add Date";
            this.other_adddate.Click += new System.EventHandler(this.other_adddate_Click);
            // 
            // Main
            // 
            this.Main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.toHTMLToolStripMenuItem,
            this.readyTagToolStripMenuItem});
            this.Main.Image = ((System.Drawing.Image)(resources.GetObject("Main.Image")));
            this.Main.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(29, 22);
            this.Main.Text = "Main";
            this.Main.Visible = false;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.View_Click);
            // 
            // toHTMLToolStripMenuItem
            // 
            this.toHTMLToolStripMenuItem.Name = "toHTMLToolStripMenuItem";
            this.toHTMLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
            this.toHTMLToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.toHTMLToolStripMenuItem.Text = "ToHTML";
            this.toHTMLToolStripMenuItem.Click += new System.EventHandler(this.toHTML_Click);
            // 
            // readyTagToolStripMenuItem
            // 
            this.readyTagToolStripMenuItem.Name = "readyTagToolStripMenuItem";
            this.readyTagToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.readyTagToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.readyTagToolStripMenuItem.Text = "ReadyTag";
            this.readyTagToolStripMenuItem.Click += new System.EventHandler(this.readyTagToolStripMenuItem_Click);
            // 
            // RTB
            // 
            this.RTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB.Location = new System.Drawing.Point(0, 25);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(446, 355);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            // 
            // HTMLEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.TS);
            this.Name = "HTMLEditor";
            this.Size = new System.Drawing.Size(446, 380);
            this.TS.ResumeLayout(false);
            this.TS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.ToolStripDropDownButton alignment;
        private System.Windows.Forms.ToolStrip TS;
        private System.Windows.Forms.ToolStripDropDownButton tag;
        private System.Windows.Forms.ToolStripDropDownButton paragraph;
        private System.Windows.Forms.ToolStripDropDownButton heading;
        private System.Windows.Forms.ToolStripMenuItem alignment_bottom;
        private System.Windows.Forms.ToolStripMenuItem alignment_top;
        private System.Windows.Forms.ToolStripMenuItem alignment_rtl;
        private System.Windows.Forms.ToolStripMenuItem alignment_center;
        private System.Windows.Forms.ToolStripMenuItem alignment_ltr;
        private System.Windows.Forms.ToolStripDropDownButton font;
        private System.Windows.Forms.ToolStripMenuItem font_bold;
        private System.Windows.Forms.ToolStripMenuItem font_italic;
        private System.Windows.Forms.ToolStripMenuItem font_OverLine;
        private System.Windows.Forms.ToolStripMenuItem font_MiddleLine;
        private System.Windows.Forms.ToolStripMenuItem font_UnderLine;
        private System.Windows.Forms.ToolStripMenuItem heading_6;
        private System.Windows.Forms.ToolStripMenuItem heading_5;
        private System.Windows.Forms.ToolStripMenuItem heading_4;
        private System.Windows.Forms.ToolStripMenuItem heading_3;
        private System.Windows.Forms.ToolStripMenuItem heading_2;
        private System.Windows.Forms.ToolStripMenuItem heading_1;
        private System.Windows.Forms.ToolStripMenuItem paragraph_preformatted;
        private System.Windows.Forms.ToolStripMenuItem paragraph_paragraph;
        private System.Windows.Forms.ToolStripMenuItem paragraph_blockQuote;
        private System.Windows.Forms.ToolStripMenuItem paragraph_quote;
        private System.Windows.Forms.ToolStripMenuItem paragraph_address;
        private System.Windows.Forms.ToolStripMenuItem paragraph_toolTip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tag_hr;
        private System.Windows.Forms.ToolStripMenuItem tag_nbsp;
        private System.Windows.Forms.ToolStripMenuItem tag_br;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton View;
        private System.Windows.Forms.ToolStripDropDownButton Main;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readyTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem direction_ltr;
        private System.Windows.Forms.ToolStripMenuItem direction_rtl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tag_MCL;
        private System.Windows.Forms.ToolStripMenuItem other_Notepad;
        private System.Windows.Forms.ToolStripMenuItem other_addcalc;
        private System.Windows.Forms.ToolStripMenuItem other_addclock;
        private System.Windows.Forms.ToolStripMenuItem other_time;
        private System.Windows.Forms.ToolStripMenuItem other_adddate;
        private System.Windows.Forms.ToolStripMenuItem other_Calc;
        private System.Windows.Forms.ToolStripDropDownButton other;
    }
}
