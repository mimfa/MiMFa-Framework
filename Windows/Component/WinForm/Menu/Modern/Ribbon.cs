using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime;
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
using System.Design;
using System.Runtime.InteropServices;
using MiMFa_Framework.Component.WinForm.Menu;

namespace MiMFa_Framework.Component.WinForm.Menu
{
    [DesignTimeVisible(true)]
    [DefaultEvent("TabChanged")]
    [DefaultProperty("TabItems")]
    public partial class Ribbon : UserControl
    {
        public Control RelatedControl = null;

        #region CategoryAttribute
        [CategoryAttribute()]
        public event EventHandler TabChanged = (o, a) => { };

        public List<RibbonPanel> TabItems
        {
            get
            {
                List<RibbonPanel> cll = new List<RibbonPanel>();
                foreach (RibbonPanel item in MainPanel.Controls)
                    cll.Add(item);
                return cll;
            }
            set
            {
                //TabPanel.Controls.Clear();
                foreach (RibbonPanel item in value)
                    AddTab(item);
            }
        }
        public override string Text { get { return Label.Text; }set { Label.Text=value; } }
        public bool AllowHide { get { return DockButton.Visible; } set { DockButton.Visible = value; } }
        public DockStyle LabelDock { get { return LabelPanel.Dock; } set { LabelPanel.Dock = value; } }
        public bool LabelVisible { get { return LabelPanel.Visible; } set { LabelPanel.Visible = value; } }
        public Size LabelSize { get { return LabelPanel.Size; } set { LabelPanel.Size = value; } }
        public DockStyle TabDock { get { return TabPanel.Dock; } set { TabPanel.Dock = value; } }
        public Font TabFont { get { return TabPanel.Font; } set { TabPanel.Font = value; } }
        public bool TabVisible { get { return TabPanel.Visible; } set { TabPanel.Visible = value; } }
        public Size TabSize { get { return TabPanel.Size; } set { TabPanel.Size = value; } }
        public bool TabAutoSize { get { return TabPanel.AutoSize; } set { TabPanel.AutoSize = value; } }
        public bool TabLabelAutoSize { get; set; } = true;
        public Size TabLabelSize { get; set; } = new Size(70,25);
        public Padding TabLabelPadding { get; set; } = new Padding(2);
        public Padding TabLabelMargin { get; set; } = new Padding(0);
        public FlowDirection TabLabelFlowDirection { get { return TabPanel.FlowDirection; } set { TabPanel.FlowDirection = value; } }
        public bool RibbonAutoSize { get { return MainPanel.AutoSize; } set { MainPanel.AutoSize = value; } }
        public Font RibbonFont { get { return MainPanel.Font; } set { MainPanel.Font = value; } }
        #endregion

        #region Override

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                if (value) MainPanel.Dock = DockStyle.Top;
                else  MainPanel.Dock = DockStyle.Fill;
                base.AutoSize = value;
            }
        }
        public override bool AutoScroll
        {
            get
            {
                return MainPanel.AutoScroll;
            }

            set
            {
                MainPanel.AutoScroll = value;
            }
        }
        #endregion

        public Ribbon()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }

        public void AddTab(RibbonPanel p)
        {
            foreach (RibbonPanel item in TabItems)
                if (item.Name == p.Name) return;
            SlideButton sb = new SlideButton();
            sb.Click += (s, a) =>
            {
                MainPanel.Visible = true;
                p.BringToFront();
                TabChanged(p, EventArgs.Empty);
            };
            sb.DesignClick += (o, a) => { sb.PerformClick(); };
            p.TextChanged += (s, a) =>
            {
                sb.Label = p.Label;
            };
            sb.RelatedControl = p;
            p.RelatedControl = sb;
            TabPanel.Controls.Add(sb);
            MainPanel.Controls.Add(p);
            sb.ShowImage = false;
            sb.AutoSize = TabLabelAutoSize;
            sb.HoverBorderStyle = BorderStyle.None;
            sb.Size = TabLabelSize;
            sb.Padding = TabLabelPadding;
            sb.Margin = TabLabelMargin;
            sb.Label = p.Label;
        }

        #region Private Region
        private void DockButton_Click(object sender, EventArgs e)
        {
            MainPanel.Visible = false;
        }
        private void MainPanel_VisibleChanged(object sender, EventArgs e)
        {
            DockButton.Visible = MainPanel.Visible;
            try { ((SlideButton)((RibbonPanel)sender).RelatedControl).ThisSelected = true; } catch { }
        }
        private void TabPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            try { MainPanel.Controls.Remove(((SlideButton)e.Control).RelatedControl); } catch { }
        }
        private void MainPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            try { TabPanel.Controls.Remove(((RibbonPanel)e.Control).RelatedControl); } catch { }
        }
        #endregion

    }
}