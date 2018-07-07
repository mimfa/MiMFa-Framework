using System;
using System.ComponentModel;
using System.Drawing;
using MiMFa_Framework.Exclusive.Animate;
using MiMFa_Framework.Exclusive.Effect;
using MiMFa_Framework.Exclusive.Collection;
using System.ComponentModel.Design;

namespace MiMFa_Framework.Component.WinForm.Menu
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public class Menu : WinForm
    {
        #region Field

        protected MiMFa_ControlSorter SORTER = null;
        private Image _BackgroundImageItems = Properties.Resources.MiMFa_shapH;
        private MiMFa_Layout _LayoutMode = MiMFa_Layout.Horizental;
        private bool _ViewLabel = true;
        private bool _ViewImage = true;
        private MiMFa_SelectFromRange _ColorOrder = MiMFa_SelectFromRange.Null;
        private MiMFa_Coloristic.ColorRange _ColorRange = MiMFa_Coloristic.ColorRange.Null;
        private Color[] _ColorRangeList = MiMFa_Coloristic.Null;
        private string _ConfigurationAddress = Config.ConfigurationExtension;


        #endregion

        #region Property
        [CategoryAttribute()]

        public virtual MiMFa_Layout LayoutMode
        {
            get { return _LayoutMode; }
            set
            {
                _LayoutMode = value;
            }
        }
        public virtual bool ViewLabel
        {
            get { return _ViewLabel; }
            set
            {
                _ViewLabel = value;
            }
        }
        public virtual bool ViewImage
        {
            get { return _ViewImage; }
            set
            {
                _ViewImage = value;
            }
        }
        public virtual Image BackgroundImageItems
        {
            get { return _BackgroundImageItems; }
            set { _BackgroundImageItems = value; }
        }
        public virtual MiMFa_SelectFromRange ColorOrder
        {
            get { return _ColorOrder; }
            set
            {
                _ColorOrder = value;
                _ColorRangeList = MiMFa_Coloristic.GetColorRenge(_ColorRange, MiMFa_SelectFromRange.OrderBy);
            }
        }
        public virtual MiMFa_Coloristic.ColorRange ColorRange
        {
            get { return _ColorRange; }
            set
            {
                _ColorRange = value;
                _ColorRangeList = MiMFa_Coloristic.GetColorRenge(_ColorRange, MiMFa_SelectFromRange.OrderBy);
            }
        }
        public virtual Color[] ColorRangeList
        {
            get { return _ColorRangeList; }
            set
            {
                _ColorRangeList = value;
            }
        }
        public virtual string ConfigurationAddress
        {
            get
            {
                if (_ConfigurationAddress == Config.ConfigurationExtension) return (_ConfigurationAddress = Config.ConfigurationDirectory + @"Menu_" + this.Name + Config.ConfigurationExtension);
                else return _ConfigurationAddress;
            }
            set
            {
                _ConfigurationAddress = value;
            }
        }

        #endregion

        #region Function


        #endregion

        #region Target

        public virtual void IncrimentByClick(object sender, EventArgs e)
        {
            SORTER.Increment(sender, e);
        }

        #endregion
    }
}
