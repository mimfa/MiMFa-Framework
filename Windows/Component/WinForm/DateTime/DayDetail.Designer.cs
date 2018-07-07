namespace MiMFa_Framework.Component.WinForm.DateTime
{
    partial class DayDetail
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
            this.@__tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.l_Date = new System.Windows.Forms.Label();
            this.l_DayOfWeek = new System.Windows.Forms.Label();
            this.l_Time = new System.Windows.Forms.Label();
            this.pb_AirView = new System.Windows.Forms.PictureBox();
            this.@__tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AirView)).BeginInit();
            this.SuspendLayout();
            // 
            // __tlp_Main
            // 
            this.@__tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.@__tlp_Main.ColumnCount = 4;
            this.@__tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.@__tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.16666F));
            this.@__tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.@__tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.@__tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.@__tlp_Main.Controls.Add(this.l_Date, 3, 0);
            this.@__tlp_Main.Controls.Add(this.l_DayOfWeek, 2, 0);
            this.@__tlp_Main.Controls.Add(this.l_Time, 1, 0);
            this.@__tlp_Main.Controls.Add(this.pb_AirView, 0, 0);
            this.@__tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@__tlp_Main.Location = new System.Drawing.Point(1, 1);
            this.@__tlp_Main.Margin = new System.Windows.Forms.Padding(2);
            this.@__tlp_Main.Name = "__tlp_Main";
            this.@__tlp_Main.RowCount = 1;
            this.@__tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.@__tlp_Main.Size = new System.Drawing.Size(238, 28);
            this.@__tlp_Main.TabIndex = 1;
            // 
            // l_Date
            // 
            this.l_Date.BackColor = System.Drawing.Color.Transparent;
            this.l_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Date.Location = new System.Drawing.Point(157, 0);
            this.l_Date.Margin = new System.Windows.Forms.Padding(0);
            this.l_Date.Name = "l_Date";
            this.l_Date.Size = new System.Drawing.Size(81, 28);
            this.l_Date.TabIndex = 70;
            this.l_Date.Text = "00/00/0000";
            this.l_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_DayOfWeek
            // 
            this.l_DayOfWeek.AllowDrop = true;
            this.l_DayOfWeek.AutoEllipsis = true;
            this.l_DayOfWeek.BackColor = System.Drawing.Color.Transparent;
            this.l_DayOfWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_DayOfWeek.Location = new System.Drawing.Point(98, 0);
            this.l_DayOfWeek.Margin = new System.Windows.Forms.Padding(0);
            this.l_DayOfWeek.Name = "l_DayOfWeek";
            this.l_DayOfWeek.Size = new System.Drawing.Size(59, 28);
            this.l_DayOfWeek.TabIndex = 65;
            this.l_DayOfWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Time
            // 
            this.l_Time.AutoEllipsis = true;
            this.l_Time.BackColor = System.Drawing.Color.Transparent;
            this.l_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Time.Location = new System.Drawing.Point(29, 0);
            this.l_Time.Margin = new System.Windows.Forms.Padding(0);
            this.l_Time.Name = "l_Time";
            this.l_Time.Size = new System.Drawing.Size(69, 28);
            this.l_Time.TabIndex = 64;
            this.l_Time.Text = "00:00:00";
            this.l_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_AirView
            // 
            this.pb_AirView.BackColor = System.Drawing.Color.Transparent;
            this.pb_AirView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_AirView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_AirView.Image = global::MiMFa_Framework.Properties.Resources.Home;
            this.pb_AirView.InitialImage = null;
            this.pb_AirView.Location = new System.Drawing.Point(2, 2);
            this.pb_AirView.Margin = new System.Windows.Forms.Padding(2);
            this.pb_AirView.Name = "pb_AirView";
            this.pb_AirView.Size = new System.Drawing.Size(25, 24);
            this.pb_AirView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_AirView.TabIndex = 60;
            this.pb_AirView.TabStop = false;
            // 
            // DayDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@__tlp_Main);
            this.Name = "DayDetail";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(240, 30);
            this.Load += new System.EventHandler(this.DayDetail_Load);
            this.@__tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_AirView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel __tlp_Main;
        private System.Windows.Forms.Label l_Date;
        private System.Windows.Forms.Label l_DayOfWeek;
        private System.Windows.Forms.Label l_Time;
        private System.Windows.Forms.PictureBox pb_AirView;
    }
}
