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
    public partial class SortableTileMenu : Menu
    {
        #region CategoryAttribute
        [CategoryAttribute()]
        #endregion
    
        #region Override
        public override bool LockState
        {
            get { return base.LockState; }
            set
            {
                base.LockState = value;
                CheackStateTile();
                if (!base.LockState) MiMFa_Coloristic.AllChildsControlColorChange(this, base.ColorOrder, ColorRangeList);
            }
        }
        public override MiMFa_Layout LayoutMode
        {
            get { return base.LayoutMode; }
            set
            {
                base.LayoutMode = value;
                CheackStateTile();
            }
        }
        public override bool ViewLabel
        {
            get { return base.ViewLabel; }
            set
            {
                base.ViewLabel = value;
                CheackStateTile();
            }
        }
        public override bool ViewImage
        {
            get { return base.ViewImage; }
            set
            {
                base.ViewImage = value;
                CheackStateTile();
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

        public SortableTileMenu()
        {
            InitializeComponent();
        }

        #region Private Region
        
        private void SortableTileMenu_Resize(object sender, EventArgs e)
        {
            CheackStateTile();
        }
        private void CheackStateTile()
        {
            if (!LockState)
            {
                MiMFa_Regularization.ChildControlsLayout(this, LayoutMode);
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    ((TileButton)this.Controls[i]).ShowImage = ViewImage;
                    ((TileButton)this.Controls[i]).ShowLabel = ViewLabel;
                }
            }
        }
        private void Tile_Click(object sender, EventArgs e)
        {
            SORTER.Increment(sender,e);
        }
        private void SortableTileMenu_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ConfigurationAddress))
            {
                SORTER = new MiMFa_ControlSorter(ConfigurationAddress, this);
                SORTER.ControlsSort(this);
            }
            if (!LockState) MiMFa_Coloristic.AllChildsControlColorChange(this, ColorOrder, ColorRangeList);
        }
    }
        #endregion
}
