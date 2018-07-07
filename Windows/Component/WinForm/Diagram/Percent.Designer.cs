namespace MiMFa_Framework.Component.WinForm.Diagram
{
    partial class Percent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Percent));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.p_FalseSide_Exam = new System.Windows.Forms.Panel();
            this.l_False_Exam = new System.Windows.Forms.Label();
            this.p_TrueSide_Exam = new System.Windows.Forms.Panel();
            this.l_True_Exam = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.p_FalseSide_Exam.SuspendLayout();
            this.p_TrueSide_Exam.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.p_FalseSide_Exam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.p_TrueSide_Exam, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 19);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // p_FalseSide_Exam
            // 
            this.p_FalseSide_Exam.BackColor = System.Drawing.Color.MistyRose;
            this.p_FalseSide_Exam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_FalseSide_Exam.BackgroundImage")));
            this.p_FalseSide_Exam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_FalseSide_Exam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_FalseSide_Exam.Controls.Add(this.l_False_Exam);
            this.p_FalseSide_Exam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_FalseSide_Exam.Location = new System.Drawing.Point(0, 0);
            this.p_FalseSide_Exam.Margin = new System.Windows.Forms.Padding(0);
            this.p_FalseSide_Exam.Name = "p_FalseSide_Exam";
            this.p_FalseSide_Exam.Padding = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.p_FalseSide_Exam.Size = new System.Drawing.Size(95, 19);
            this.p_FalseSide_Exam.TabIndex = 3;
            // 
            // l_False_Exam
            // 
            this.l_False_Exam.BackColor = System.Drawing.Color.DeepPink;
            this.l_False_Exam.Dock = System.Windows.Forms.DockStyle.Right;
            this.l_False_Exam.Location = new System.Drawing.Point(83, 1);
            this.l_False_Exam.Name = "l_False_Exam";
            this.l_False_Exam.Size = new System.Drawing.Size(10, 15);
            this.l_False_Exam.TabIndex = 1;
            this.l_False_Exam.Text = "0";
            this.l_False_Exam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // p_TrueSide_Exam
            // 
            this.p_TrueSide_Exam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(252)))), ((int)(((byte)(211)))));
            this.p_TrueSide_Exam.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_TrueSide_Exam.BackgroundImage")));
            this.p_TrueSide_Exam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_TrueSide_Exam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_TrueSide_Exam.Controls.Add(this.l_True_Exam);
            this.p_TrueSide_Exam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_TrueSide_Exam.Location = new System.Drawing.Point(95, 0);
            this.p_TrueSide_Exam.Margin = new System.Windows.Forms.Padding(0);
            this.p_TrueSide_Exam.Name = "p_TrueSide_Exam";
            this.p_TrueSide_Exam.Padding = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.p_TrueSide_Exam.Size = new System.Drawing.Size(95, 19);
            this.p_TrueSide_Exam.TabIndex = 2;
            // 
            // l_True_Exam
            // 
            this.l_True_Exam.BackColor = System.Drawing.Color.Lime;
            this.l_True_Exam.Dock = System.Windows.Forms.DockStyle.Left;
            this.l_True_Exam.Location = new System.Drawing.Point(0, 1);
            this.l_True_Exam.Name = "l_True_Exam";
            this.l_True_Exam.Size = new System.Drawing.Size(10, 15);
            this.l_True_Exam.TabIndex = 0;
            this.l_True_Exam.Text = "0";
            this.l_True_Exam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Percent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Percent";
            this.Size = new System.Drawing.Size(190, 19);
            this.Resize += new System.EventHandler(this.Percent_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.p_FalseSide_Exam.ResumeLayout(false);
            this.p_TrueSide_Exam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label l_True_Exam;
        internal System.Windows.Forms.Panel p_TrueSide_Exam;
        internal System.Windows.Forms.Label l_False_Exam;
        internal System.Windows.Forms.Panel p_FalseSide_Exam;
    }
}
