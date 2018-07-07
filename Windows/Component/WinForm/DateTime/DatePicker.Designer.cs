namespace MiMFa_Framework.Component.WinForm.DateTime
{
    partial class DatePicker
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
            this.tlp_Btn = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Top = new System.Windows.Forms.Button();
            this.btn_Bottom = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mtb_Date = new System.Windows.Forms.MaskedTextBox();
            this.tlp_Main.SuspendLayout();
            this.tlp_Btn.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoSize = true;
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlp_Main.Controls.Add(this.tlp_Btn, 1, 0);
            this.tlp_Main.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(90, 20);
            this.tlp_Main.TabIndex = 0;
            // 
            // tlp_Btn
            // 
            this.tlp_Btn.BackColor = System.Drawing.SystemColors.Control;
            this.tlp_Btn.ColumnCount = 1;
            this.tlp_Btn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Btn.Controls.Add(this.btn_Top, 0, 0);
            this.tlp_Btn.Controls.Add(this.btn_Bottom, 0, 1);
            this.tlp_Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Btn.Location = new System.Drawing.Point(72, 0);
            this.tlp_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Btn.Name = "tlp_Btn";
            this.tlp_Btn.RowCount = 2;
            this.tlp_Btn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Btn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Btn.Size = new System.Drawing.Size(18, 20);
            this.tlp_Btn.TabIndex = 3;
            // 
            // btn_Top
            // 
            this.btn_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.btn_Top.Location = new System.Drawing.Point(0, 0);
            this.btn_Top.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Top.Name = "btn_Top";
            this.btn_Top.Size = new System.Drawing.Size(18, 10);
            this.btn_Top.TabIndex = 1;
            this.btn_Top.TabStop = false;
            this.btn_Top.Text = "▲";
            this.btn_Top.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Top.UseVisualStyleBackColor = true;
            this.btn_Top.Click += new System.EventHandler(this.btn_Top_Click);
            // 
            // btn_Bottom
            // 
            this.btn_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F);
            this.btn_Bottom.Location = new System.Drawing.Point(0, 10);
            this.btn_Bottom.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Bottom.Name = "btn_Bottom";
            this.btn_Bottom.Size = new System.Drawing.Size(18, 10);
            this.btn_Bottom.TabIndex = 1;
            this.btn_Bottom.TabStop = false;
            this.btn_Bottom.Text = "▼";
            this.btn_Bottom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Bottom.UseVisualStyleBackColor = true;
            this.btn_Bottom.Click += new System.EventHandler(this.btn_Bottom_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.mtb_Date, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(72, 20);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // mtb_Date
            // 
            this.mtb_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtb_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtb_Date.HideSelection = false;
            this.mtb_Date.Location = new System.Drawing.Point(0, 3);
            this.mtb_Date.Margin = new System.Windows.Forms.Padding(0);
            this.mtb_Date.Mask = "00/00/0000";
            this.mtb_Date.Name = "mtb_Date";
            this.mtb_Date.Size = new System.Drawing.Size(72, 13);
            this.mtb_Date.TabIndex = 1;
            this.mtb_Date.Text = "00000000";
            this.mtb_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtb_Date.TextChanged += new System.EventHandler(this.mtb_Date_TextChanged);
            this.mtb_Date.Enter += new System.EventHandler(this.mtb_Date_Enter);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tlp_Main);
            this.Name = "DatePicker";
            this.Size = new System.Drawing.Size(90, 20);
            this.BackColorChanged += new System.EventHandler(this.DatePicker_BackColorChanged);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Btn.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_Btn;
        private System.Windows.Forms.Button btn_Top;
        private System.Windows.Forms.Button btn_Bottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox mtb_Date;
    }
}
