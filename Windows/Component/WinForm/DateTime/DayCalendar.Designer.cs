namespace MiMFa_Framework.Component.WinForm.DateTime
{
    partial class DayCalendar
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.l_Day = new System.Windows.Forms.Label();
            this.l_Month = new System.Windows.Forms.Label();
            this.p_Date = new System.Windows.Forms.Panel();
            this.l_Date = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.p_Date.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.l_Day, 0, 0);
            this.tlp_Main.Controls.Add(this.l_Month, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(93, 64);
            this.tlp_Main.TabIndex = 0;
            this.tlp_Main.DoubleClick += new System.EventHandler(this.l_Day_DoubleClick);
            // 
            // l_Day
            // 
            this.l_Day.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.l_Day.Location = new System.Drawing.Point(0, 0);
            this.l_Day.Margin = new System.Windows.Forms.Padding(0);
            this.l_Day.Name = "l_Day";
            this.l_Day.Size = new System.Drawing.Size(93, 38);
            this.l_Day.TabIndex = 15;
            this.l_Day.TabStop = true;
            this.l_Day.Text = "روز";
            this.l_Day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Day.TextChanged += new System.EventHandler(this.l_Day_TextChanged);
            this.l_Day.DoubleClick += new System.EventHandler(this.l_Day_DoubleClick);
            this.l_Day.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_Day_Down);
            this.l_Day.MouseEnter += new System.EventHandler(this.l_Day_MouseEnter);
            this.l_Day.MouseLeave += new System.EventHandler(this.l_Day_MouseLeave);
            this.l_Day.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l_Day_MouseUp);
            // 
            // l_Month
            // 
            this.l_Month.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Month.Location = new System.Drawing.Point(0, 38);
            this.l_Month.Margin = new System.Windows.Forms.Padding(0);
            this.l_Month.Name = "l_Month";
            this.l_Month.Size = new System.Drawing.Size(93, 26);
            this.l_Month.TabIndex = 17;
            this.l_Month.Text = "ماه";
            this.l_Month.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_Date
            // 
            this.p_Date.BackColor = System.Drawing.Color.Transparent;
            this.p_Date.BackgroundImage = global::MiMFa_Framework.Properties.Resources.BackD;
            this.p_Date.Controls.Add(this.l_Date);
            this.p_Date.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p_Date.Location = new System.Drawing.Point(0, 0);
            this.p_Date.Margin = new System.Windows.Forms.Padding(0);
            this.p_Date.Name = "p_Date";
            this.p_Date.Size = new System.Drawing.Size(93, 18);
            this.p_Date.TabIndex = 17;
            this.p_Date.Visible = false;
            // 
            // l_Date
            // 
            this.l_Date.BackColor = System.Drawing.Color.Transparent;
            this.l_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Date.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold);
            this.l_Date.Location = new System.Drawing.Point(0, 0);
            this.l_Date.Name = "l_Date";
            this.l_Date.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.l_Date.Size = new System.Drawing.Size(93, 18);
            this.l_Date.TabIndex = 2;
            this.l_Date.Text = "سال";
            this.l_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Date.TextChanged += new System.EventHandler(this.l_Day_TextChanged);
            // 
            // DayCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_Date);
            this.Controls.Add(this.tlp_Main);
            this.Name = "DayCalendar";
            this.Size = new System.Drawing.Size(93, 64);
            this.DoubleClick += new System.EventHandler(this.l_Day_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l_Day_Down);
            this.MouseEnter += new System.EventHandler(this.l_Day_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.l_Day_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l_Day_MouseUp);
            this.tlp_Main.ResumeLayout(false);
            this.p_Date.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        internal System.Windows.Forms.Label l_Day;
        internal System.Windows.Forms.Label l_Month;
        private System.Windows.Forms.Label l_Date;
        private System.Windows.Forms.Panel p_Date;
    }
}
