namespace MiMFa_Framework.Component.WinForm.Browser
{
    partial class LogViewer : Browser
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
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Back = new System.Windows.Forms.ToolStripButton();
            this.tsb_Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_printprev = new System.Windows.Forms.ToolStripButton();
            this.tsb_print = new System.Windows.Forms.ToolStripButton();
            this.tscmb_Alert = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 28);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.ScriptErrorsSuppressed = true;
            this.Browser.Size = new System.Drawing.Size(442, 216);
            this.Browser.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_clear,
            this.toolStripSeparator2,
            this.tsb_Back,
            this.tsb_Next,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.tsb_printprev,
            this.tsb_print,
            this.tscmb_Alert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(442, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_clear
            // 
            this.tsb_clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_clear.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Recovery;
            this.tsb_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_clear.Name = "tsb_clear";
            this.tsb_clear.Size = new System.Drawing.Size(23, 25);
            this.tsb_clear.Text = "Clear";
            this.tsb_clear.Click += new System.EventHandler(this.tsb_clear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsb_Back
            // 
            this.tsb_Back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Back.Image = global::MiMFa_Framework.Properties.Resources.Back;
            this.tsb_Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Back.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Back.Name = "tsb_Back";
            this.tsb_Back.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Back.Size = new System.Drawing.Size(26, 26);
            this.tsb_Back.Text = "Back";
            this.tsb_Back.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Back.Click += new System.EventHandler(this.tsb_Back_Click);
            // 
            // tsb_Next
            // 
            this.tsb_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Next.Image = global::MiMFa_Framework.Properties.Resources.Next;
            this.tsb_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Next.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Next.Name = "tsb_Next";
            this.tsb_Next.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Next.Size = new System.Drawing.Size(26, 26);
            this.tsb_Next.Text = "Next";
            this.tsb_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Next.Click += new System.EventHandler(this.tsb_Next_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFToolStripMenuItem,
            this.docToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Export;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 25);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.Image = global::MiMFa_Framework.Properties.Resources.pdf_icon;
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pDFToolStripMenuItem.Text = "Acrobat Reader";
            this.pDFToolStripMenuItem.Click += new System.EventHandler(this.pDFToolStripMenuItem_Click);
            // 
            // docToolStripMenuItem
            // 
            this.docToolStripMenuItem.Image = global::MiMFa_Framework.Properties.Resources.Microsoft_Word;
            this.docToolStripMenuItem.Name = "docToolStripMenuItem";
            this.docToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.docToolStripMenuItem.Text = "Word";
            this.docToolStripMenuItem.Click += new System.EventHandler(this.docToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Image = global::MiMFa_Framework.Properties.Resources.BRIGHTS_PAINT_APPLICATION;
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tsb_printprev
            // 
            this.tsb_printprev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_printprev.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Page_Setup;
            this.tsb_printprev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_printprev.Name = "tsb_printprev";
            this.tsb_printprev.Size = new System.Drawing.Size(23, 25);
            this.tsb_printprev.Text = "Print Preview";
            this.tsb_printprev.Click += new System.EventHandler(this.tsb_printprev_Click);
            // 
            // tsb_print
            // 
            this.tsb_print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_print.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Print;
            this.tsb_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_print.Name = "tsb_print";
            this.tsb_print.Size = new System.Drawing.Size(23, 25);
            this.tsb_print.Text = "Print";
            this.tsb_print.Click += new System.EventHandler(this.tsb_print_Click);
            // 
            // tscmb_Alert
            // 
            this.tscmb_Alert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscmb_Alert.Items.AddRange(new object[] {
            "None",
            "Short Beep",
            "Long Beep"});
            this.tscmb_Alert.Name = "tscmb_Alert";
            this.tscmb_Alert.Size = new System.Drawing.Size(75, 28);
            this.tscmb_Alert.Text = "Alert";
            this.tscmb_Alert.ToolTipText = "Alert";
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Browser);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LogViewer";
            this.Size = new System.Drawing.Size(442, 244);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.WebBrowser Browser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_clear;
        private System.Windows.Forms.ToolStripButton tsb_print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_printprev;
        private System.Windows.Forms.ToolStripComboBox tscmb_Alert;
        private System.Windows.Forms.ToolStripButton tsb_Next;
        private System.Windows.Forms.ToolStripButton tsb_Back;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
