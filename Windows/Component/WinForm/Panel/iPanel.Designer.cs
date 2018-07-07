namespace MiMFa_Framework.Component.WinForm.Panel
{
    partial class iPanel
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
            this.SuspendLayout();
            // 
            // iPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "iPanel";
            this.Load += new System.EventHandler(this.iPanel_Load);
            this.VisibleChanged += new System.EventHandler(this.iPanel_VisibleChanged);
            this.Resize += new System.EventHandler(this.iPanel_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
