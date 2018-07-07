namespace MiMFa_Framework.Component.WinForm.Package.Reports
{
    partial class Viewer
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
            this.ReportViewer = new MiMFa_Framework.Component.WinForm.Browser.MRLReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.Editor = null;
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.LockState = false;
            this.ReportViewer.Archive = null;
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.Size = new System.Drawing.Size(503, 377);
            this.ReportViewer.TabIndex = 0;
            this.ReportViewer.URL = new System.Uri("http://www.Parsgo.ir", System.UriKind.Absolute);
            // 
            // ReportSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 377);
            this.Controls.Add(this.ReportViewer);
            this.Name = "ReportSystem";
            this.Text = "";
            this.Icon =  Properties.Resources.MiMFa_Report;
            this.ResumeLayout(false);

        }

        #endregion

        public Browser.MRLReportViewer ReportViewer;

        public object FreeImageBitmap { get; private set; }
    }
}