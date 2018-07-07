namespace MiMFa_Framework.Component.WinForm.Package.Reports
{
    partial class Editor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReportDesigner = new MiMFa_Framework.Component.WinForm.Editor.ReportDesign.ReportDesigner();
            this.SuspendLayout();
            // 
            // ReportDesigner
            // 
            this.ReportDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportDesigner.Location = new System.Drawing.Point(0, 0);
            this.ReportDesigner.LockState = false;
            this.ReportDesigner.Name = "ReportDesigner";
            this.ReportDesigner.Size = new System.Drawing.Size(554, 395);
            this.ReportDesigner.TabIndex = 0;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 395);
            this.Controls.Add(this.ReportDesigner);
            this.Name = "Editor";
            this.Text = "Editor";
            this.ResumeLayout(false);

        }

        #endregion

        public MiMFa_Framework.Component.WinForm.Editor.ReportDesign.ReportDesigner ReportDesigner;
    }
}