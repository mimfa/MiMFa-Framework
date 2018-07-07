using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MiMFa_Framework.Component.WinForm.Tools;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Animate;
using MiMFa_Framework.Exclusive.Effect;
using MiMFa_Framework.Exclusive.Collection;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace MiMFa_Framework.Component.WinForm.Menu
{
    [DesignTimeVisible(true)]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [DefaultProperty("Label")]
    public partial class RibbonPanel : UserControl
    {
        public Control RelatedControl = null;

        #region CategoryAttribute
        [Category()]
        public string Label { get { return LabelBox.Text; }set { LabelBox.Text=value; OnTextChanged(EventArgs.Empty); } }
        public DockStyle LabelDock { get { return LabelPanel.Dock; } set { LabelPanel.Dock = value; } }
        public bool LabelVisible { get { return LabelPanel.Visible; }set { LabelPanel.Visible = value; } }
        #endregion

        #region Override
        #endregion

        public RibbonPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region Private Region
        private void RibbonPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            LabelPanel.SendToBack();
        }
        #endregion

    }
}