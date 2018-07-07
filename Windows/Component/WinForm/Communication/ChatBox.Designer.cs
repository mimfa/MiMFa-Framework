namespace MiMFa_Framework.Component.WinForm.Communication
{
    partial class ChatBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatBox));
            this.WB = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.tileButton2 = new MiMFa_Framework.Component.WinForm.Tools.TileButton();
            this.ATTACH = new MiMFa_Framework.Component.WinForm.Tools.TileButton();
            this.SMILE = new MiMFa_Framework.Component.WinForm.Tools.TileButton();
            this.SendSmile = new MiMFa_Framework.Component.WinForm.Special.SelectSmile();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WB
            // 
            this.WB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB.IsWebBrowserContextMenuEnabled = false;
            this.WB.Location = new System.Drawing.Point(0, 0);
            this.WB.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB.Name = "WB";
            this.WB.ScriptErrorsSuppressed = true;
            this.WB.Size = new System.Drawing.Size(413, 239);
            this.WB.TabIndex = 0;
            this.WB.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB_DocumentCompleted);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.RTB);
            this.panel1.Controls.Add(this.tileButton2);
            this.panel1.Controls.Add(this.ATTACH);
            this.panel1.Controls.Add(this.SMILE);
            this.panel1.Controls.Add(this.SendSmile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 239);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(413, 126);
            this.panel1.TabIndex = 1;
            // 
            // RTB
            // 
            this.RTB.BackColor = System.Drawing.SystemColors.Window;
            this.RTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RTB.Location = new System.Drawing.Point(63, 63);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(283, 63);
            this.RTB.TabIndex = 0;
            this.RTB.Text = "";
            this.RTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_CMD_KeyDown);
            // 
            // tileButton2
            // 
            this.tileButton2.BackColor = System.Drawing.SystemColors.Window;
            this.tileButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tileButton2.HoverBackColor = System.Drawing.Color.WhiteSmoke;
            this.tileButton2.HoverBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileButton2.HoverEffect = MiMFa_Framework.Exclusive.Effect.MiMFa_Highlight.Mode.Shadow;
            this.tileButton2.HoverForeColor = System.Drawing.Color.Black;
            this.tileButton2.HoverImage = global::MiMFa_Framework.Properties.Resources.BackV3;
            this.tileButton2.Image = global::MiMFa_Framework.Properties.Resources.cb2507b0f9fe9d160e7bc4857d6f4b07x;
            this.tileButton2.ImageLayout = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tileButton2.ImagePadding = new System.Windows.Forms.Padding(3);
            this.tileButton2.InvertColor = false;
            this.tileButton2.InvertImage = false;
            this.tileButton2.Label = "SubTile";
            this.tileButton2.LabelAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tileButton2.Location = new System.Drawing.Point(346, 63);
            this.tileButton2.LockState = false;
            this.tileButton2.Name = "tileButton2";
            this.tileButton2.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.tileButton2.ShowImage = true;
            this.tileButton2.ShowLabel = false;
            this.tileButton2.Size = new System.Drawing.Size(67, 63);
            this.tileButton2.TabIndex = 3;
            this.tileButton2.ThisSelected = false;
            this.tileButton2.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // ATTACH
            // 
            this.ATTACH.BackColor = System.Drawing.SystemColors.Window;
            this.ATTACH.Dock = System.Windows.Forms.DockStyle.Left;
            this.ATTACH.HoverBackColor = System.Drawing.Color.WhiteSmoke;
            this.ATTACH.HoverBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ATTACH.HoverEffect = MiMFa_Framework.Exclusive.Effect.MiMFa_Highlight.Mode.Shadow;
            this.ATTACH.HoverForeColor = System.Drawing.Color.Black;
            this.ATTACH.HoverImage = global::MiMFa_Framework.Properties.Resources.BackV3;
            this.ATTACH.Image = ((System.Drawing.Image)(resources.GetObject("ATTACH.Image")));
            this.ATTACH.ImageLayout = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ATTACH.ImagePadding = new System.Windows.Forms.Padding(3);
            this.ATTACH.InvertColor = false;
            this.ATTACH.InvertImage = false;
            this.ATTACH.Label = "SubTile";
            this.ATTACH.LabelAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ATTACH.Location = new System.Drawing.Point(28, 63);
            this.ATTACH.LockState = false;
            this.ATTACH.Name = "ATTACH";
            this.ATTACH.Padding = new System.Windows.Forms.Padding(4);
            this.ATTACH.ShowImage = true;
            this.ATTACH.ShowLabel = false;
            this.ATTACH.Size = new System.Drawing.Size(35, 63);
            this.ATTACH.TabIndex = 2;
            this.ATTACH.ThisSelected = false;
            this.ATTACH.Click += new System.EventHandler(this.ATTACH_Click);
            // 
            // SMILE
            // 
            this.SMILE.BackColor = System.Drawing.SystemColors.Window;
            this.SMILE.Dock = System.Windows.Forms.DockStyle.Left;
            this.SMILE.HoverBackColor = System.Drawing.Color.WhiteSmoke;
            this.SMILE.HoverBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SMILE.HoverEffect = MiMFa_Framework.Exclusive.Effect.MiMFa_Highlight.Mode.Shadow;
            this.SMILE.HoverForeColor = System.Drawing.Color.Black;
            this.SMILE.HoverImage = global::MiMFa_Framework.Properties.Resources.BackV3;
            this.SMILE.Image = global::MiMFa_Framework.Properties.Resources.favorite;
            this.SMILE.ImageLayout = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SMILE.ImagePadding = new System.Windows.Forms.Padding(3);
            this.SMILE.InvertColor = false;
            this.SMILE.InvertImage = false;
            this.SMILE.Label = "SubTile";
            this.SMILE.LabelAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SMILE.Location = new System.Drawing.Point(0, 63);
            this.SMILE.LockState = false;
            this.SMILE.Name = "SMILE";
            this.SMILE.Padding = new System.Windows.Forms.Padding(2);
            this.SMILE.ShowImage = true;
            this.SMILE.ShowLabel = false;
            this.SMILE.Size = new System.Drawing.Size(28, 63);
            this.SMILE.TabIndex = 5;
            this.SMILE.ThisSelected = false;
            this.SMILE.Click += new System.EventHandler(this.SMILE_Click);
            // 
            // SendSmile
            // 
            this.SendSmile.BackColor = System.Drawing.SystemColors.Window;
            this.SendSmile.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendSmile.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.SendSmile.InvertColor = false;
            this.SendSmile.Location = new System.Drawing.Point(0, 2);
            this.SendSmile.LockState = false;
            this.SendSmile.Name = "SendSmile";
            this.SendSmile.Size = new System.Drawing.Size(413, 61);
            this.SendSmile.SmileSize = new System.Drawing.Size(30, 30);
            this.SendSmile.TabIndex = 6;
            this.SendSmile.Value = null;
            this.SendSmile.Visible = false;
            this.SendSmile.ValueChanged += new System.EventHandler(this.SendSmile_ValueChanged);
            this.SendSmile.VisibleChanged += new System.EventHandler(this.SendSmile_VisibleChanged);
            // 
            // OFD
            // 
            this.OFD.Multiselect = true;
            this.OFD.RestoreDirectory = true;
            this.OFD.Title = "Send file";
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.WB);
            this.Controls.Add(this.panel1);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(413, 365);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox RTB;
        private Tools.TileButton ATTACH;
        private Tools.TileButton tileButton2;
        private System.Windows.Forms.OpenFileDialog OFD;
        private Tools.TileButton SMILE;
        private Special.SelectSmile SendSmile;
    }
}
