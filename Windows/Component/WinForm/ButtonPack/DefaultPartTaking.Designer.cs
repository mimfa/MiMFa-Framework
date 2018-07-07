namespace MiMFa_Framework.Component.WinForm.ButtonPack
{
    partial class DefaultPartTakingButtonPack : ButtonPack
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
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Menu = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Done = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 5;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.btn_Next, 3, 0);
            this.tlp_Main.Controls.Add(this.btn_Menu, 2, 0);
            this.tlp_Main.Controls.Add(this.btn_Back, 1, 0);
            this.tlp_Main.Controls.Add(this.btn_Done, 4, 0);
            this.tlp_Main.Controls.Add(this.btn_Reset, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(335, 28);
            this.tlp_Main.TabIndex = 0;
            // 
            // btn_Next
            // 
            this.btn_Next.AutoSize = true;
            this.btn_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Next.Location = new System.Drawing.Point(198, 3);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(49, 22);
            this.btn_Next.TabIndex = 4;
            this.btn_Next.Text = "►";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Menu
            // 
            this.btn_Menu.AutoSize = true;
            this.btn_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Menu.Location = new System.Drawing.Point(143, 3);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(49, 22);
            this.btn_Menu.TabIndex = 3;
            this.btn_Menu.Text = "Menu";
            this.btn_Menu.UseVisualStyleBackColor = true;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.AutoSize = true;
            this.btn_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Back.Location = new System.Drawing.Point(88, 3);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(49, 22);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = "◄";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Done
            // 
            this.btn_Done.AutoSize = true;
            this.btn_Done.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Done.Location = new System.Drawing.Point(278, 3);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(54, 22);
            this.btn_Done.TabIndex = 1;
            this.btn_Done.Text = "Done";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.AutoSize = true;
            this.btn_Reset.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Reset.Location = new System.Drawing.Point(3, 3);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(39, 22);
            this.btn_Reset.TabIndex = 0;
            this.btn_Reset.Text = "New";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // DefaultPartTakingButtonPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "DefaultPartTakingButtonPack";
            this.Size = new System.Drawing.Size(335, 28);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        public System.Windows.Forms.Button btn_Next;
        public System.Windows.Forms.Button btn_Reset;
        public System.Windows.Forms.Button btn_Done;
        public System.Windows.Forms.Button btn_Back;
        public System.Windows.Forms.Button btn_Menu;
    }
}
