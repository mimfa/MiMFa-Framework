namespace MiMFa_Framework.Component.WinForm.DateTime
{
    partial class IntervalTimeSet
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
            this.tlp_TimingPriod = new System.Windows.Forms.TableLayoutPanel();
            this.ToTime = new MiMFa_Framework.Component.WinForm.DateTime.TimePicker();
            this.l_To = new System.Windows.Forms.Label();
            this.l_Text = new System.Windows.Forms.Label();
            this.FromTime = new MiMFa_Framework.Component.WinForm.DateTime.TimePicker();
            this.l_Time = new System.Windows.Forms.Label();
            this.tlp_TimingPriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_TimingPriod
            // 
            this.tlp_TimingPriod.AutoSize = true;
            this.tlp_TimingPriod.BackColor = System.Drawing.Color.Transparent;
            this.tlp_TimingPriod.ColumnCount = 5;
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.Controls.Add(this.ToTime, 3, 0);
            this.tlp_TimingPriod.Controls.Add(this.l_To, 2, 0);
            this.tlp_TimingPriod.Controls.Add(this.l_Text, 0, 0);
            this.tlp_TimingPriod.Controls.Add(this.FromTime, 1, 0);
            this.tlp_TimingPriod.Controls.Add(this.l_Time, 4, 0);
            this.tlp_TimingPriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_TimingPriod.Location = new System.Drawing.Point(0, 0);
            this.tlp_TimingPriod.Name = "tlp_TimingPriod";
            this.tlp_TimingPriod.RowCount = 1;
            this.tlp_TimingPriod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlp_TimingPriod.Size = new System.Drawing.Size(300, 100);
            this.tlp_TimingPriod.TabIndex = 0;
            // 
            // ToTime
            // 
            this.ToTime.AutoSize = true;
            this.ToTime.BackColor = System.Drawing.SystemColors.Window;
            this.ToTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToTime.DateAndTime = null;
            this.ToTime.InvertColor = false;
            this.ToTime.Location = new System.Drawing.Point(183, 3);
            this.ToTime.LockState = false;
            this.ToTime.Name = "ToTime";
            this.ToTime.Size = new System.Drawing.Size(82, 27);
            this.ToTime.TabIndex = 0;
            this.ToTime.ThisTime = false;
            this.ToTime.Time = null;
            this.ToTime.ValueChanged += new System.EventHandler(this.dttp_FromHour_ValueChanged);
            this.ToTime.Dock = System.Windows.Forms.DockStyle.Left;
            // 
            // l_To
            // 
            this.l_To.AutoSize = true;
            this.l_To.BackColor = System.Drawing.Color.Transparent;
            this.l_To.Location = new System.Drawing.Point(157, 0);
            this.l_To.Name = "l_To";
            this.l_To.Size = new System.Drawing.Size(20, 13);
            this.l_To.TabIndex = 1;
            this.l_To.Text = "To";
            this.l_To.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_To.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Text
            // 
            this.l_Text.AutoSize = true;
            this.l_Text.BackColor = System.Drawing.Color.Transparent;
            this.l_Text.Location = new System.Drawing.Point(3, 0);
            this.l_Text.Name = "l_Text";
            this.l_Text.Size = new System.Drawing.Size(60, 13);
            this.l_Text.TabIndex = 2;
            this.l_Text.Text = "From Clock";
            this.l_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_Text.Dock = System.Windows.Forms.DockStyle.Left;
            // 
            // FromTime
            // 
            this.FromTime.AutoSize = true;
            this.FromTime.BackColor = System.Drawing.SystemColors.Window;
            this.FromTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FromTime.DateAndTime = null;
            this.FromTime.InvertColor = false;
            this.FromTime.Location = new System.Drawing.Point(69, 3);
            this.FromTime.LockState = false;
            this.FromTime.Name = "FromTime";
            this.FromTime.Size = new System.Drawing.Size(82, 27);
            this.FromTime.TabIndex = 3;
            this.FromTime.ThisTime = false;
            this.FromTime.Time = null;
            this.FromTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.FromTime.ValueChanged += new System.EventHandler(this.dttp_FromHour_ValueChanged);
            // 
            // l_Time
            // 
            this.l_Time.AutoSize = true;
            this.l_Time.BackColor = System.Drawing.Color.Transparent;
            this.l_Time.Location = new System.Drawing.Point(271, 0);
            this.l_Time.Name = "l_Time";
            this.l_Time.Size = new System.Drawing.Size(19, 13);
            this.l_Time.TabIndex = 4;
            this.l_Time.Text = "24";
            this.l_Time.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IntervalTimeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_TimingPriod);
            this.Name = "IntervalTimeSet";
            this.Size = new System.Drawing.Size(300, 30);
            this.tlp_TimingPriod.ResumeLayout(false);
            this.tlp_TimingPriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_TimingPriod;
        private System.Windows.Forms.Label l_Time;
        public TimePicker ToTime;
        private System.Windows.Forms.Label l_To;
        public TimePicker FromTime;
        private System.Windows.Forms.Label l_Text;
    }
}
