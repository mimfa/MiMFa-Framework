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

namespace MiMFa_Framework.Component.WinForm.Menu
{
 
    public partial class SlidingMenu : Menu
    {
        #region CategoryAttribute
        [CategoryAttribute()]
        public bool OpenStart
        {
            get { return _OpenStart; }
            set
            {
                _OpenStart = value;
                CheackState();
            }
        }
        private bool _OpenStart = false;

        #endregion

        #region Override
        public override bool LockState
        {
            get { return base.LockState; }
            set
            {   
                base.LockState = value;
                CheackState();
                if (!base.LockState) MiMFa_Coloristic.AllChildsControlColorChange(this, base.ColorOrder, ColorRangeList);
            }
        }
        public override MiMFa_Layout LayoutMode
        {
            get { return base.LayoutMode; }
            set
            {
                base.LayoutMode = value;
                CheackState();
            }
        }
        public override bool ViewLabel
        {
            get { return base.ViewLabel; }
            set
            {
                base.ViewLabel = value;
                CheackState();
            }
        }
        public override bool ViewImage
        {
            get { return base.ViewImage; }
            set
            {
                base.ViewImage = value;
                CheackState();
            }
        }
        public override MiMFa_SelectFromRange ColorOrder
        {
            get { return base.ColorOrder; }
            set
            {
                base.ColorOrder = value;
                if (!LockState) MiMFa_Coloristic.AllChildsControlColorChange(this, base.ColorOrder, ColorRangeList);
            }
        }
        public override MiMFa_Coloristic.ColorRange ColorRange
        {
            get { return base.ColorRange; }
            set
            {
                base.ColorRange = value;
                if (!LockState) MiMFa_Coloristic.AllChildsControlColorChange(this, base.ColorOrder, ColorRangeList);
            }
        }
        #endregion

        public SlidingMenu()
        {
            InitializeComponent();
        }

        #region Private Region

        private void SlidingMenu_Resize(object sender, EventArgs e)
        {
            if (!AutoScroll) CheackState();
        }
        private void CheackState()
        {
            if (!string.IsNullOrEmpty(ConfigurationAddress))
            {
                SORTER = new MiMFa_ControlSorter(ConfigurationAddress, this);
                SORTER.ControlsSort(this);
            }
            if (!base.LockState)
            {
                MiMFa_Regularization.ChildControlsLayout(this, base.LayoutMode);
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    this.Controls[i].Click += new EventHandler(base.IncrimentByClick);
                    if (this.Controls[i] is SubSlidingMenu)
                    {
                        ((SubSlidingMenu)this.Controls[i]).ViewImage = base.ViewImage;
                        ((SubSlidingMenu)this.Controls[i]).ViewLabel = base.ViewLabel;
                        ((SubSlidingMenu)this.Controls[i]).OpenStart = _OpenStart;
                    }
                }
            }
        }
        private void SlidingMenu_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}