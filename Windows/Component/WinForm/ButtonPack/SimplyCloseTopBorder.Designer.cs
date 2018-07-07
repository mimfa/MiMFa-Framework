namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
    partial class SimplyCloseTopBorder
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.l_Title = new System.Windows.Forms.Label();
            LABEL = this.l_Title;
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Exit.Font = new System.Drawing.Font("B Nazanin", 8F);
            this.btn_Exit.Location = new System.Drawing.Point(237, 1);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(20, 22);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "x";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // l_Subject
            // 
            this.l_Title.BackColor = System.Drawing.Color.Transparent;
            this.l_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_Title.Location = new System.Drawing.Point(1, 1);
            this.l_Title.Name = "l_Subject";
            this.l_Title.Size = new System.Drawing.Size(256, 22);
            this.l_Title.TabIndex = 2;
            this.l_Title.Text = " ";
            this.l_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.l_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.l_Title.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.l_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.l_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            // 
            // ButtonPack_CloseBorderTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.l_Title);
            this.Name = "ButtonPack_CloseBorderTop";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(258, 24);
            this.Load += new System.EventHandler(this.ButtonPack_CloseBorderTop_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            this.MouseLeave += new System.EventHandler(this.FormMove_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label l_Title;
    }
}
