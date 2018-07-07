namespace MiMFa_Framework.Component.WinForm.DateTime
{
    partial class MeetTime
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
            this.mTime = new MiMFa_Framework.Component.WinForm.DateTime.TimePicker();
            this.l_To = new System.Windows.Forms.Label();
            this.l_Text = new System.Windows.Forms.Label();
            this.mDate = new MiMFa_Framework.Component.WinForm.DateTime.DatePicker();
            this.tlp_TimingPriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_TimingPriod
            // 
            this.tlp_TimingPriod.BackColor = System.Drawing.Color.Transparent;
            this.tlp_TimingPriod.ColumnCount = 4;
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_TimingPriod.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_TimingPriod.Controls.Add(this.mTime, 3, 0);
            this.tlp_TimingPriod.Controls.Add(this.l_To, 2, 0);
            this.tlp_TimingPriod.Controls.Add(this.l_Text, 0, 0);
            this.tlp_TimingPriod.Controls.Add(this.mDate, 1, 0);
            this.tlp_TimingPriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_TimingPriod.Location = new System.Drawing.Point(0, 0);
            this.tlp_TimingPriod.Name = "tlp_TimingPriod";
            this.tlp_TimingPriod.RowCount = 1;
            this.tlp_TimingPriod.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_TimingPriod.Size = new System.Drawing.Size(268, 21);
            this.tlp_TimingPriod.TabIndex = 0;
            // 
            // mTime
            // 
            this.mTime.BackColor = System.Drawing.SystemColors.Window;
            this.mTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTime.InvertColor = false;
            this.mTime.Location = new System.Drawing.Point(166, 0);
            this.mTime.LockState = false;
            this.mTime.Margin = new System.Windows.Forms.Padding(0);
            this.mTime.Name = "mTime";
            this.mTime.Size = new System.Drawing.Size(10, 21);
            this.mTime.TabIndex = 0;
            this.mTime.ThisTime = false;
            this.mTime.ValueChanged += new System.EventHandler(this.Date_ValueChanged);
            // 
            // l_To
            // 
            this.l_To.AutoSize = true;
            this.l_To.BackColor = System.Drawing.Color.Transparent;
            this.l_To.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_To.Location = new System.Drawing.Point(132, 0);
            this.l_To.Margin = new System.Windows.Forms.Padding(0);
            this.l_To.Name = "l_To";
            this.l_To.Size = new System.Drawing.Size(34, 21);
            this.l_To.TabIndex = 1;
            this.l_To.Text = "Clock";
            this.l_To.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_Text
            // 
            this.l_Text.AutoSize = true;
            this.l_Text.BackColor = System.Drawing.Color.Transparent;
            this.l_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Text.Location = new System.Drawing.Point(0, 0);
            this.l_Text.Margin = new System.Windows.Forms.Padding(0);
            this.l_Text.Name = "l_Text";
            this.l_Text.Size = new System.Drawing.Size(30, 21);
            this.l_Text.TabIndex = 2;
            this.l_Text.Text = "Date";
            this.l_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mDate
            // 
            this.mDate.BackColor = System.Drawing.SystemColors.Window;
            this.mDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDate.InvertColor = false;
            this.mDate.Location = new System.Drawing.Point(30, 0);
            this.mDate.LockState = false;
            this.mDate.Margin = new System.Windows.Forms.Padding(0);
            this.mDate.Name = "mDate";
            this.mDate.Size = new System.Drawing.Size(10, 21);
            this.mDate.TabIndex = 3;
            this.mDate.ThisDate = false;
            this.mDate.ValueChanged += new System.EventHandler(this.Date_ValueChanged);
            // 
            // MeetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_TimingPriod);
            this.Name = "MeetTime";
            this.Size = new System.Drawing.Size(268, 21);
            this.tlp_TimingPriod.ResumeLayout(false);
            this.tlp_TimingPriod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_TimingPriod;
        public TimePicker mTime;
        private System.Windows.Forms.Label l_To;
        private System.Windows.Forms.Label l_Text;
        public DatePicker mDate;
    }
}
