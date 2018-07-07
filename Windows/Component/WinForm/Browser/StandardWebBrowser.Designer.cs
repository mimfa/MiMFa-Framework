namespace MiMFa_Framework.Component.WinForm.Browser
{
    partial class StandardWebBrowser : Browser
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
            this.ts_Main = new System.Windows.Forms.ToolStrip();
            this.tsb_Back = new System.Windows.Forms.ToolStripButton();
            this.tsb_Home = new System.Windows.Forms.ToolStripButton();
            this.tsb_Next = new System.Windows.Forms.ToolStripButton();
            this.tss_ss = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Refresh = new System.Windows.Forms.ToolStripButton();
            this.tsb_Stop = new System.Windows.Forms.ToolStripButton();
            this.tlp_ToolStrip = new System.Windows.Forms.TableLayoutPanel();
            this.p_AddressBar = new System.Windows.Forms.Panel();
            this.tlp_Addressbar = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Progress = new System.Windows.Forms.PictureBox();
            this.tb_AddressBar = new System.Windows.Forms.TextBox();
            this.pb_Close = new System.Windows.Forms.PictureBox();
            this.Go = new System.Windows.Forms.PictureBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.ts_Main.SuspendLayout();
            this.tlp_ToolStrip.SuspendLayout();
            this.p_AddressBar.SuspendLayout();
            this.tlp_Addressbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Progress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Go)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ts_Main
            // 
            this.ts_Main.BackColor = System.Drawing.Color.Transparent;
            this.ts_Main.Dock = System.Windows.Forms.DockStyle.Left;
            this.ts_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Back,
            this.tsb_Home,
            this.tsb_Next,
            this.tss_ss,
            this.tsb_Refresh,
            this.tsb_Stop});
            this.ts_Main.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ts_Main.Location = new System.Drawing.Point(0, 0);
            this.ts_Main.Name = "ts_Main";
            this.ts_Main.Size = new System.Drawing.Size(158, 30);
            this.ts_Main.TabIndex = 36;
            // 
            // tsb_Back
            // 
            this.tsb_Back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Back.Image = global::MiMFa_Framework.Properties.Resources.Back;
            this.tsb_Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Back.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Back.Name = "tsb_Back";
            this.tsb_Back.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Back.Size = new System.Drawing.Size(26, 28);
            this.tsb_Back.Text = "Back";
            this.tsb_Back.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Back.Click += new System.EventHandler(this.tsb_Back_Click);
            // 
            // tsb_Home
            // 
            this.tsb_Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Home.Image = global::MiMFa_Framework.Properties.Resources.HomeOrig;
            this.tsb_Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Home.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Home.Name = "tsb_Home";
            this.tsb_Home.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Home.Size = new System.Drawing.Size(26, 28);
            this.tsb_Home.Text = "Home";
            this.tsb_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Home.Click += new System.EventHandler(this.tsb_Home_Click);
            // 
            // tsb_Next
            // 
            this.tsb_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Next.Image = global::MiMFa_Framework.Properties.Resources.Next;
            this.tsb_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Next.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Next.Name = "tsb_Next";
            this.tsb_Next.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Next.Size = new System.Drawing.Size(26, 28);
            this.tsb_Next.Text = "Next";
            this.tsb_Next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Next.Click += new System.EventHandler(this.tsb_Next_Click);
            // 
            // tss_ss
            // 
            this.tss_ss.Name = "tss_ss";
            this.tss_ss.Size = new System.Drawing.Size(6, 30);
            // 
            // tsb_Refresh
            // 
            this.tsb_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Refresh.Image = global::MiMFa_Framework.Properties.Resources.reset;
            this.tsb_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Refresh.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Refresh.Name = "tsb_Refresh";
            this.tsb_Refresh.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Refresh.Size = new System.Drawing.Size(26, 28);
            this.tsb_Refresh.Text = "Refresh";
            this.tsb_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Refresh.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // tsb_Stop
            // 
            this.tsb_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Stop.Image = global::MiMFa_Framework.Properties.Resources.exit;
            this.tsb_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Stop.Margin = new System.Windows.Forms.Padding(1);
            this.tsb_Stop.Name = "tsb_Stop";
            this.tsb_Stop.Padding = new System.Windows.Forms.Padding(3);
            this.tsb_Stop.Size = new System.Drawing.Size(26, 28);
            this.tsb_Stop.Text = "Stop";
            this.tsb_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Stop.Click += new System.EventHandler(this.tsb_Stop_Click);
            // 
            // tlp_ToolStrip
            // 
            this.tlp_ToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.tlp_ToolStrip.BackgroundImage = global::MiMFa_Framework.Properties.Resources.MiMFa_shapH;
            this.tlp_ToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlp_ToolStrip.ColumnCount = 2;
            this.tlp_ToolStrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_ToolStrip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_ToolStrip.Controls.Add(this.ts_Main, 0, 0);
            this.tlp_ToolStrip.Controls.Add(this.p_AddressBar, 1, 0);
            this.tlp_ToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.tlp_ToolStrip.Name = "tlp_ToolStrip";
            this.tlp_ToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tlp_ToolStrip.RowCount = 1;
            this.tlp_ToolStrip.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_ToolStrip.Size = new System.Drawing.Size(442, 30);
            this.tlp_ToolStrip.TabIndex = 39;
            // 
            // p_AddressBar
            // 
            this.p_AddressBar.BackColor = System.Drawing.SystemColors.Window;
            this.p_AddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_AddressBar.Controls.Add(this.tlp_Addressbar);
            this.p_AddressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_AddressBar.Location = new System.Drawing.Point(161, 3);
            this.p_AddressBar.Name = "p_AddressBar";
            this.p_AddressBar.Padding = new System.Windows.Forms.Padding(5, 0, 2, 0);
            this.p_AddressBar.Size = new System.Drawing.Size(278, 24);
            this.p_AddressBar.TabIndex = 37;
            // 
            // tlp_Addressbar
            // 
            this.tlp_Addressbar.ColumnCount = 4;
            this.tlp_Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Addressbar.Controls.Add(this.pb_Progress, 0, 0);
            this.tlp_Addressbar.Controls.Add(this.tb_AddressBar, 1, 0);
            this.tlp_Addressbar.Controls.Add(this.pb_Close, 2, 0);
            this.tlp_Addressbar.Controls.Add(this.Go, 3, 0);
            this.tlp_Addressbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Addressbar.Location = new System.Drawing.Point(5, 0);
            this.tlp_Addressbar.Name = "tlp_Addressbar";
            this.tlp_Addressbar.RowCount = 1;
            this.tlp_Addressbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Addressbar.Size = new System.Drawing.Size(269, 22);
            this.tlp_Addressbar.TabIndex = 2;
            // 
            // pb_Progress
            // 
            this.pb_Progress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_Progress.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Progress.Image = global::MiMFa_Framework.Properties.Resources.loading;
            this.pb_Progress.Location = new System.Drawing.Point(3, 3);
            this.pb_Progress.Name = "pb_Progress";
            this.pb_Progress.Size = new System.Drawing.Size(14, 16);
            this.pb_Progress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Progress.TabIndex = 44;
            this.pb_Progress.TabStop = false;
            this.pb_Progress.Visible = false;
            // 
            // tb_AddressBar
            // 
            this.tb_AddressBar.AutoCompleteCustomSource.AddRange(new string[] {
            "MiMFa.net",
            "Google.com"});
            this.tb_AddressBar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_AddressBar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.tb_AddressBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_AddressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_AddressBar.Location = new System.Drawing.Point(23, 4);
            this.tb_AddressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.tb_AddressBar.Name = "tb_AddressBar";
            this.tb_AddressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_AddressBar.Size = new System.Drawing.Size(203, 13);
            this.tb_AddressBar.TabIndex = 43;
            this.tb_AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_AddressBar_KeyDown);
            // 
            // pb_Close
            // 
            this.pb_Close.BackgroundImage = global::MiMFa_Framework.Properties.Resources.close;
            this.pb_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Close.Location = new System.Drawing.Point(232, 3);
            this.pb_Close.Name = "pb_Close";
            this.pb_Close.Size = new System.Drawing.Size(14, 16);
            this.pb_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Close.TabIndex = 42;
            this.pb_Close.TabStop = false;
            this.pb_Close.Click += new System.EventHandler(this.pb_Close_Click);
            this.pb_Close.MouseEnter += new System.EventHandler(this.Go_MouseEnter);
            this.pb_Close.MouseLeave += new System.EventHandler(this.Go_MouseLeave);
            // 
            // Go
            // 
            this.Go.BackgroundImage = global::MiMFa_Framework.Properties.Resources.RightGo;
            this.Go.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Go.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Go.Location = new System.Drawing.Point(252, 3);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(14, 16);
            this.Go.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Go.TabIndex = 41;
            this.Go.TabStop = false;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            this.Go.MouseEnter += new System.EventHandler(this.Go_MouseEnter);
            this.Go.MouseLeave += new System.EventHandler(this.Go_MouseLeave);
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.BackgroundImage = global::MiMFa_Framework.Properties.Resources.MiMFa_shapH;
            this.tlp_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.Browser, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 30);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(442, 214);
            this.tlp_Main.TabIndex = 40;
            // 
            // Browser
            // 
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(3, 3);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.ScriptErrorsSuppressed = true;
            this.Browser.Size = new System.Drawing.Size(436, 208);
            this.Browser.TabIndex = 2;
            this.Browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            this.Browser.FileDownload += new System.EventHandler(this.Browser_FileDownload);
            this.Browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.Browser_Navigated);
            this.Browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Browser_Navigating);
            this.Browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.Browser_NewWindow);
            // 
            // StandardWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.tlp_ToolStrip);
            this.Name = "StandardWebBrowser";
            this.Size = new System.Drawing.Size(442, 244);
            this.ts_Main.ResumeLayout(false);
            this.ts_Main.PerformLayout();
            this.tlp_ToolStrip.ResumeLayout(false);
            this.tlp_ToolStrip.PerformLayout();
            this.p_AddressBar.ResumeLayout(false);
            this.tlp_Addressbar.ResumeLayout(false);
            this.tlp_Addressbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Progress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Go)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_Main;
        private System.Windows.Forms.ToolStripButton tsb_Back;
        private System.Windows.Forms.ToolStripButton tsb_Home;
        private System.Windows.Forms.ToolStripButton tsb_Next;
        private System.Windows.Forms.ToolStripSeparator tss_ss;
        private System.Windows.Forms.ToolStripButton tsb_Refresh;
        private System.Windows.Forms.ToolStripButton tsb_Stop;
        private System.Windows.Forms.TableLayoutPanel tlp_ToolStrip;
        private System.Windows.Forms.Panel p_AddressBar;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Addressbar;
        private System.Windows.Forms.PictureBox pb_Progress;
        private System.Windows.Forms.TextBox tb_AddressBar;
        private System.Windows.Forms.PictureBox pb_Close;
        private System.Windows.Forms.PictureBox Go;
        public System.Windows.Forms.WebBrowser Browser;
    }
}
