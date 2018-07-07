namespace MiMFa_Framework.Component.WinForm.Menu
{
    partial class SubSlidingMenu
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
            this.p_btn = new System.Windows.Forms.Panel();
            this.btn_Title = new System.Windows.Forms.Label();
            this.p_Main = new System.Windows.Forms.Panel();
            this.tlp_Main.SuspendLayout();
            this.p_btn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoSize = true;
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.p_btn, 0, 0);
            this.tlp_Main.Controls.Add(this.p_Main, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.Size = new System.Drawing.Size(141, 35);
            this.tlp_Main.TabIndex = 1;
            // 
            // p_btn
            // 
            this.p_btn.AutoSize = true;
            this.p_btn.BackgroundImage = global::MiMFa_Framework.Properties.Resources.Tab_Hide;
            this.p_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_btn.Controls.Add(this.btn_Title);
            this.p_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_btn.Location = new System.Drawing.Point(3, 3);
            this.p_btn.Name = "p_btn";
            this.p_btn.Size = new System.Drawing.Size(135, 23);
            this.p_btn.TabIndex = 1;
            // 
            // btn_Title
            // 
            this.btn_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Title.Location = new System.Drawing.Point(0, 0);
            this.btn_Title.Name = "btn_Title";
            this.btn_Title.Size = new System.Drawing.Size(135, 23);
            this.btn_Title.TabIndex = 0;
            this.btn_Title.Text = "Menu";
            this.btn_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Title.Click += new System.EventHandler(this.btn_Tab_Click);
            this.btn_Title.MouseEnter += new System.EventHandler(this.l_btn_MouseEnter);
            this.btn_Title.MouseLeave += new System.EventHandler(this.l_btn_MouseLeave);
            // 
            // p_Main
            // 
            this.p_Main.AutoSize = true;
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_Main.Location = new System.Drawing.Point(3, 32);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(135, 0);
            this.p_Main.TabIndex = 2;
            // 
            // SubSlidingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tlp_Main);
            this.Name = "SubSlidingMenu";
            this.Size = new System.Drawing.Size(141, 36);
            this.Load += new System.EventHandler(this.SubSlidingMenu_Load);
            this.Resize += new System.EventHandler(this.SubSlidingMenu_Resize);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.p_btn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Panel p_btn;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.Label btn_Title;



    }
}
