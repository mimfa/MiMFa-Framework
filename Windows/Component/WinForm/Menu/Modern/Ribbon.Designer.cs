namespace MiMFa_Framework.Component.WinForm.Menu
{
    partial class Ribbon
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
            this.MainPanel = new MiMFa_Framework.Component.WinForm.Panel.Panel();
            this.TabPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.DockButton = new System.Windows.Forms.Label();
            this.LabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.AutoSize = true;
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.ColorOrder = MiMFa_Framework.Exclusive.Collection.MiMFa_SelectFromRange.Null;
            this.MainPanel.ColorRange = MiMFa_Framework.Exclusive.Effect.MiMFa_Coloristic.ColorRange.Null;
            this.MainPanel.ColorRangeList = new System.Drawing.Color[] {
        System.Drawing.Color.Transparent};
            this.MainPanel.ConfigurationAddress = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE\\MiMFa Framework\\E" +
    "xclusive\\Language\\Configuration\\Menu_panel1.cnf";
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.InvertColor = false;
            this.MainPanel.LayoutMode = MiMFa_Framework.Exclusive.Collection.MiMFa_Layout.Horizental;
            this.MainPanel.Location = new System.Drawing.Point(0, 19);
            this.MainPanel.LockState = false;
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RelatedControl = null;
            this.MainPanel.Size = new System.Drawing.Size(304, 78);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.VisibleChanged += new System.EventHandler(this.MainPanel_VisibleChanged);
            this.MainPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.MainPanel_ControlRemoved);
            // 
            // TabPanel
            // 
            this.TabPanel.AutoSize = true;
            this.TabPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabPanel.Location = new System.Drawing.Point(0, 19);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.Size = new System.Drawing.Size(304, 0);
            this.TabPanel.TabIndex = 2;
            this.TabPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.TabPanel_ControlRemoved);
            // 
            // DockButton
            // 
            this.DockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DockButton.AutoSize = true;
            this.DockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DockButton.Location = new System.Drawing.Point(290, 89);
            this.DockButton.Name = "DockButton";
            this.DockButton.Padding = new System.Windows.Forms.Padding(2);
            this.DockButton.Size = new System.Drawing.Size(12, 11);
            this.DockButton.TabIndex = 5;
            this.DockButton.Text = "▲";
            this.DockButton.Click += new System.EventHandler(this.DockButton_Click);
            // 
            // LabelPanel
            // 
            this.LabelPanel.AutoSize = true;
            this.LabelPanel.BackColor = System.Drawing.Color.Transparent;
            this.LabelPanel.BackgroundImage = global::MiMFa_Framework.Properties.Resources.Light1;
            this.LabelPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LabelPanel.ColumnCount = 1;
            this.LabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabelPanel.Controls.Add(this.Label, 0, 0);
            this.LabelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelPanel.Location = new System.Drawing.Point(0, 0);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.RowCount = 1;
            this.LabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LabelPanel.Size = new System.Drawing.Size(304, 19);
            this.LabelPanel.TabIndex = 1;
            this.LabelPanel.Visible = false;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label.Location = new System.Drawing.Point(3, 0);
            this.Label.Name = "Label";
            this.Label.Padding = new System.Windows.Forms.Padding(3);
            this.Label.Size = new System.Drawing.Size(298, 19);
            this.Label.TabIndex = 1;
            this.Label.Text = "Label";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::MiMFa_Framework.Properties.Resources.MiMFa_Shadow_HB;
            this.pictureBox1.Location = new System.Drawing.Point(0, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 5);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Ribbon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DockButton);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.LabelPanel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Ribbon";
            this.Size = new System.Drawing.Size(304, 102);
            this.LabelPanel.ResumeLayout(false);
            this.LabelPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Panel.Panel MainPanel;
        private System.Windows.Forms.TableLayoutPanel LabelPanel;
        public System.Windows.Forms.Label Label;
        public System.Windows.Forms.FlowLayoutPanel TabPanel;
        private System.Windows.Forms.Label DockButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
