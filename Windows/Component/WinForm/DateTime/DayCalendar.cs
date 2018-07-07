using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.Effect;
using MiMFa_Framework.Exclusive.Animate;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public partial class DayCalendar : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public MiMFa_Date Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                if (_Date != null)
                {
                    l_Day.Text = _Date.Day.ToString();
                    l_Month.Text = _Date.MonthName;
                    l_Date.Text = _Date.GetDate();
                }
            }
        }
        public event EventHandler ValueChanged;
        public event MouseEventHandler MiddleMouseWheel;
        public bool WithMouseEvent
        {
            get { return _WithMouseEvent; }
            set { _WithMouseEvent = value; }
        }
        public Color MonthBackColor
        {
            get { return l_Month.BackColor; }
            set { p_Date.BackColor = l_Month.BackColor = value; }
        }
        public Color MonthForeColor
        {
            get { return l_Month.ForeColor; }
            set { p_Date.ForeColor = l_Month.ForeColor = value; }
        }
        public Font MonthFont
        {
            get { return l_Month.Font; }
            set { p_Date.Font = l_Month.Font = value; }
        }
        public Color DayBackColor
        {
            get { return l_Day.BackColor; }
            set { l_Day.BackColor = value; }
        }
        public Color DayForeColor
        {
            get { return l_Day.ForeColor; }
            set { l_Day.ForeColor = value; }
        }
        public Font DayFont
        {
            get { return l_Day.Font; }
            set { l_Day.Font = value; }
        }

        #endregion

        public DayCalendar()
        {
            InitializeComponent();
            p_Date.MaximumSize = p_Date.Size;
            l_Day.MouseWheel += l_Day_MouseWheel;
            l_Month.MouseWheel += l_Day_MouseWheel;
            SetAllEventParentToControls();
        }

        #region Private Region

        private MiMFa_Date _Date = new MiMFa_DateTime().GetDatePAC();
        private MiMFa_Highlight MH = new MiMFa_Highlight(MiMFa_Highlight.Mode.Shadow);
        private bool _WithMouseEvent = true;

        private void l_Day_MouseWheel(object sender, MouseEventArgs e)
        {
            if (MiddleMouseWheel != null) MiddleMouseWheel(sender, e);
        }
        private void l_Day_MouseEnter(object sender, EventArgs e)
        {
            if (_WithMouseEvent) MH.MouseEnter(tlp_Main);
            l_Day.Focus();
        }
        private void l_Day_MouseLeave(object sender, EventArgs e)
        {
            if (_WithMouseEvent) MH.MouseLeave(tlp_Main);
        }
        private void l_Day_Down(object sender, MouseEventArgs e)
        {
            //if (_WithMouseEvent) tlp_Main.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            SIMPLYSLIDER.StartEffect(p_Date, DockStyle.Top);
        }
        private void l_Day_MouseUp(object sender, MouseEventArgs e)
        {
            //tlp_Main.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            p_Date.Visible = false;
            //SIMPLYSLIDER.EndEffect(p_Date, DockStyle.Top);
        }
        private void l_Day_DoubleClick(object sender, EventArgs e)
        {
            if (_WithMouseEvent)
            if (this.BorderStyle == BorderStyle.None) this.BorderStyle = BorderStyle.FixedSingle;
            else this.BorderStyle = BorderStyle.None;
            p_Date.Visible = false;
        }
        private void l_Day_TextChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(sender, e);
        }

        #endregion


    }
}
