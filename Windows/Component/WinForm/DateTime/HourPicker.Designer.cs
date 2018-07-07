namespace MiMFa_Framework.Component.WinForm.DateTime
{
    partial class HourPicker
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
            this.Hour = new System.Windows.Forms.NumericUpDown();
            this.Minute = new System.Windows.Forms.NumericUpDown();
            this.l_Seprator = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Hour
            // 
            this.Hour.AutoSize = true;
            this.Hour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Hour.Dock = System.Windows.Forms.DockStyle.Top;
            this.Hour.Location = new System.Drawing.Point(0, 0);
            this.Hour.Margin = new System.Windows.Forms.Padding(0);
            this.Hour.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Hour.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Hour.Name = "Hour";
            this.Hour.Size = new System.Drawing.Size(51, 16);
            this.Hour.TabIndex = 169;
            this.Hour.ValueChanged += new System.EventHandler(this.Minute_ValueChanged);
            // 
            // Minute
            // 
            this.Minute.AutoSize = true;
            this.Minute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Minute.Dock = System.Windows.Forms.DockStyle.Top;
            this.Minute.Location = new System.Drawing.Point(61, 0);
            this.Minute.Margin = new System.Windows.Forms.Padding(0);
            this.Minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Minute.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(34, 16);
            this.Minute.TabIndex = 170;
            this.Minute.ValueChanged += new System.EventHandler(this.Minute_ValueChanged);
            // 
            // l_Seprator
            // 
            this.l_Seprator.AutoSize = true;
            this.l_Seprator.BackColor = System.Drawing.Color.Transparent;
            this.l_Seprator.Dock = System.Windows.Forms.DockStyle.Top;
            this.l_Seprator.Location = new System.Drawing.Point(51, 0);
            this.l_Seprator.Margin = new System.Windows.Forms.Padding(0);
            this.l_Seprator.Name = "l_Seprator";
            this.l_Seprator.Size = new System.Drawing.Size(10, 13);
            this.l_Seprator.TabIndex = 171;
            this.l_Seprator.Text = ":";
            this.l_Seprator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoSize = true;
            this.tlp_Main.BackColor = System.Drawing.SystemColors.Window;
            this.tlp_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_Main.Controls.Add(this.Minute, 2, 0);
            this.tlp_Main.Controls.Add(this.l_Seprator, 1, 0);
            this.tlp_Main.Controls.Add(this.Hour, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.Size = new System.Drawing.Size(97, 19);
            this.tlp_Main.TabIndex = 172;
            // 
            // HourPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "HourPicker";
            this.Size = new System.Drawing.Size(97, 19);
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown Hour;
        public System.Windows.Forms.NumericUpDown Minute;
        private System.Windows.Forms.Label l_Seprator;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;

    }
}
