using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MiMFa_Framework.Component.WinForm.Tools;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Animate;
using MiMFa_Framework.Exclusive.Effect;
using MiMFa_Framework.Exclusive.Collection;

namespace MiMFa_Framework.Component.WinForm.Panel
{
    public partial class iPanel : Panel
    {
        #region CategoryAttribute
        [CategoryAttribute()]
        public bool Sortable { get; set; } = false;
        #endregion

        #region Override
        public override bool LockState
        {
            get { return base.LockState; }
            set
            {
                base.LockState = value;
                CheckStateTile();
            }
        }
        public override MiMFa_Layout LayoutMode
        {
            get { return base.LayoutMode; }
            set
            {
                base.LayoutMode = value;
                CheckStateTile();
            }
        }
        public override MiMFa_SelectFromRange ColorOrder
        {
            get { return base.ColorOrder; }
            set
            {
                base.ColorOrder = value;
                MiMFa_Coloristic.AllChildsControlColorChange(this, base.ColorOrder, ColorRangeList);
            }
        }
        public override MiMFa_Coloristic.ColorRange ColorRange
        {
            get { return base.ColorRange; }
            set
            {
                base.ColorRange = value;
                MiMFa_Coloristic.AllChildsControlColorChange(this, base.ColorOrder, ColorRangeList);
            }
        }
        #endregion

        public iPanel()
        {
            InitializeComponent();
        }
        private void CheckStateTile()
        {
            if (!string.IsNullOrEmpty(ConfigurationAddress) && Sortable)
            {
                SORTER = new MiMFa_ControlSorter(ConfigurationAddress, this);
                SORTER.ControlsSort(this);
            }
           if(ColorOrder != MiMFa_SelectFromRange.Null || ColorRange != MiMFa_Coloristic.ColorRange.Null)  MiMFa_Coloristic.AllChildsControlColorChange(this, ColorOrder, ColorRangeList);
            if (!LockState)
            {
                MiMFa_Regularization.ChildControlsLayout(this, LayoutMode);
            }
        }

        private void iPanel_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
                Controls[i].Click += base.IncrimentByClick;
            CheckStateTile();
        }

        private void iPanel_Resize(object sender, EventArgs e)
        {
            CheckStateTile();
        }
        private void iPanel_VisibleChanged(object sender, EventArgs e)
        {
            CheckStateTile();
        }
    }
}
