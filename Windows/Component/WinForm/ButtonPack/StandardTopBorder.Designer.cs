namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
    partial class StandardTopBorder
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
            this.p_btn = new System.Windows.Forms.Panel();
            this.pb_Help = new System.Windows.Forms.PictureBox();
            this.pb_Minimize = new System.Windows.Forms.PictureBox();
            this.pb_WS = new System.Windows.Forms.PictureBox();
            this.pb_Exit = new System.Windows.Forms.PictureBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.p_Light = new System.Windows.Forms.Panel();
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            this.ButtonLabel = new System.Windows.Forms.Label();
           LABEL =  this.ButtonLabel;
            this.l_Text = new System.Windows.Forms.Label();
            this.p_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Help)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_WS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Exit)).BeginInit();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // p_btn
            // 
            this.p_btn.AutoSize = true;
            this.p_btn.BackColor = System.Drawing.Color.Transparent;
            this.p_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_btn.Controls.Add(this.pb_Help);
            this.p_btn.Controls.Add(this.pb_Minimize);
            this.p_btn.Controls.Add(this.pb_WS);
            this.p_btn.Controls.Add(this.pb_Exit);
            this.p_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_btn.Location = new System.Drawing.Point(245, 1);
            this.p_btn.Name = "p_btn";
            this.p_btn.Padding = new System.Windows.Forms.Padding(4, 4, 5, 4);
            this.p_btn.Size = new System.Drawing.Size(82, 22);
            this.p_btn.TabIndex = 3;
            this.p_btn.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            // 
            // pb_Help
            // 
            this.pb_Help.BackgroundImage = global::MiMFa_Framework.Properties.Resources.BackV2;
            this.pb_Help.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Help.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_Help.Image = global::MiMFa_Framework.Properties.Resources.Help;
            this.pb_Help.Location = new System.Drawing.Point(4, 4);
            this.pb_Help.Name = "pb_Help";
            this.pb_Help.Size = new System.Drawing.Size(14, 14);
            this.pb_Help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Help.TabIndex = 3;
            this.pb_Help.TabStop = false;
            this.pb_Help.Click += new System.EventHandler(this.pb_Help_Click);
            this.pb_Help.MouseEnter += new System.EventHandler(this.Hilight_MouseEnter);
            this.pb_Help.MouseLeave += new System.EventHandler(this.Hilight_MouseLeave);
            // 
            // pb_Minimize
            // 
            this.pb_Minimize.BackgroundImage = global::MiMFa_Framework.Properties.Resources.BackV2;
            this.pb_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_Minimize.Image = global::MiMFa_Framework.Properties.Resources.BMinimize;
            this.pb_Minimize.Location = new System.Drawing.Point(18, 4);
            this.pb_Minimize.Name = "pb_Minimize";
            this.pb_Minimize.Size = new System.Drawing.Size(17, 14);
            this.pb_Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Minimize.TabIndex = 2;
            this.pb_Minimize.TabStop = false;
            this.pb_Minimize.Click += new System.EventHandler(this.Minimize_Click);
            this.pb_Minimize.MouseEnter += new System.EventHandler(this.Hilight_MouseEnter);
            this.pb_Minimize.MouseLeave += new System.EventHandler(this.Hilight_MouseLeave);
            // 
            // pb_WS
            // 
            this.pb_WS.BackgroundImage = global::MiMFa_Framework.Properties.Resources.BackV2;
            this.pb_WS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_WS.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_WS.Image = global::MiMFa_Framework.Properties.Resources.BWindowsState1;
            this.pb_WS.Location = new System.Drawing.Point(35, 4);
            this.pb_WS.Name = "pb_WS";
            this.pb_WS.Size = new System.Drawing.Size(25, 14);
            this.pb_WS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_WS.TabIndex = 1;
            this.pb_WS.TabStop = false;
            this.pb_WS.Click += new System.EventHandler(this.WindowsState_Click);
            this.pb_WS.MouseEnter += new System.EventHandler(this.Hilight_MouseEnter);
            this.pb_WS.MouseLeave += new System.EventHandler(this.Hilight_MouseLeave);
            // 
            // pb_Exit
            // 
            this.pb_Exit.BackgroundImage = global::MiMFa_Framework.Properties.Resources.BackV2;
            this.pb_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pb_Exit.Image = global::MiMFa_Framework.Properties.Resources.Bexit;
            this.pb_Exit.Location = new System.Drawing.Point(60, 4);
            this.pb_Exit.Name = "pb_Exit";
            this.pb_Exit.Size = new System.Drawing.Size(17, 14);
            this.pb_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Exit.TabIndex = 0;
            this.pb_Exit.TabStop = false;
            this.pb_Exit.Click += new System.EventHandler(this.Exit_Click);
            this.pb_Exit.MouseEnter += new System.EventHandler(this.Hilight_MouseEnter);
            this.pb_Exit.MouseLeave += new System.EventHandler(this.Hilight_MouseLeave);
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 4;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.Controls.Add(this.l_Text, 3, 0);
            this.tlp_Main.Controls.Add(this.ButtonLabel, 2, 0);
            this.tlp_Main.Controls.Add(this.pb_Logo, 1, 0);
            this.tlp_Main.Controls.Add(this.p_Light, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(1, 1);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(244, 22);
            this.tlp_Main.TabIndex = 7;
            this.tlp_Main.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            this.tlp_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.tlp_Main.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.tlp_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.tlp_Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            // 
            // p_Light
            // 
            this.p_Light.BackColor = System.Drawing.Color.Transparent;
            this.p_Light.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_Light.Dock = System.Windows.Forms.DockStyle.Left;
            this.p_Light.Location = new System.Drawing.Point(0, 0);
            this.p_Light.Margin = new System.Windows.Forms.Padding(0);
            this.p_Light.Name = "p_Light";
            this.p_Light.Size = new System.Drawing.Size(5, 22);
            this.p_Light.TabIndex = 7;
            this.p_Light.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            this.p_Light.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.p_Light.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.p_Light.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.p_Light.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            // 
            // pb_Logo
            // 
            this.pb_Logo.BackColor = System.Drawing.Color.Transparent;
            this.pb_Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Logo.Location = new System.Drawing.Point(5, 0);
            this.pb_Logo.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(23, 22);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Logo.TabIndex = 8;
            this.pb_Logo.TabStop = false;
            this.pb_Logo.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            this.pb_Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.pb_Logo.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.pb_Logo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.pb_Logo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            // 
            // l_Title
            // 
            this.ButtonLabel.AutoSize = true;
            this.ButtonLabel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonLabel.Font = new System.Drawing.Font("IranNastaliq", 7F);
            this.ButtonLabel.Location = new System.Drawing.Point(28, 0);
            this.ButtonLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonLabel.Name = "l_Title";
            this.ButtonLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ButtonLabel.Size = new System.Drawing.Size(10, 22);
            this.ButtonLabel.TabIndex = 9;
            this.ButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ButtonLabel.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            this.ButtonLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.ButtonLabel.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.ButtonLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.ButtonLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            // 
            // l_Text
            // 
            this.l_Text.BackColor = System.Drawing.Color.Transparent;
            this.l_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Text.Location = new System.Drawing.Point(38, 0);
            this.l_Text.Margin = new System.Windows.Forms.Padding(0);
            this.l_Text.Name = "l_Text";
            this.l_Text.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.l_Text.Size = new System.Drawing.Size(206, 22);
            this.l_Text.TabIndex = 10;
            this.l_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_Text.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            this.l_Text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.l_Text.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.l_Text.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.l_Text.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            // 
            // StandardTopBorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MiMFa_Framework.Properties.Resources.MiMFa_shapH;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.p_btn);
            this.DoubleBuffered = true;
            this.Name = "StandardTopBorder";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(328, 24);
            this.Load += new System.EventHandler(this.StandardTopBorder_Load);
            this.DoubleClick += new System.EventHandler(this.WindowsState_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            this.p_btn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Help)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_WS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Exit)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_btn;
        private System.Windows.Forms.PictureBox pb_Exit;
        private System.Windows.Forms.PictureBox pb_Help;
        private System.Windows.Forms.PictureBox pb_Minimize;
        private System.Windows.Forms.PictureBox pb_WS;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Label l_Text;
        private System.Windows.Forms.Label ButtonLabel;
        private System.Windows.Forms.PictureBox pb_Logo;
        private System.Windows.Forms.Panel p_Light;
    }
}
