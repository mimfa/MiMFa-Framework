using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.DateAndTime;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public partial class TimePicker : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public MiMFa_Time Time
        {
            get { return _Time; }
            set
            {
                _Time = value;
                if(_Time != null) mtb_Time.Text = _Time.GetTime();
            }
        }
        public event EventHandler ValueChanged = null;
        public bool ThisTime
        {
            get { return _ThisTime; }
            set
            {
                _ThisTime = value;
                if(_ThisTime)
                {
                    MiMFa_DateTime dt = new MiMFa_DateTime();
                    _Time.Hour = dt.GetHour();
                    _Time.Minute = dt.GetMinute();
                    _Time.Second = dt.GetSecond();
                    mtb_Time.Text = _Time.GetTime();
                }
                else
                {
                    MiMFa_Time md = new MiMFa_Time(0, 0, 0);
                    mtb_Time.Text = md.GetTime();
                }
            }
        }
        #endregion
        public TimePicker()
        {
            InitializeComponent();
            mtb_Time.MouseWheel += thisMouseWheel;
            mtb_Time.BackColor = BackColor;
            SetAllEventParentToControls();
        }

        #region Private Region

        private bool _ThisTime = false;
        private MiMFa_Time _Time = new MiMFa_Time();
        
        private void thisMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) btn_Top_Click(sender, new EventArgs());
            else btn_Bottom_Click(sender, new EventArgs());
        }
        private void btn_Top_Click(object sender, EventArgs e)
        {
           int ss =  mtb_Time.SelectionStart;
            if (mtb_Time.SelectionStart < 3)
                Time.Hour++;
            else if (mtb_Time.SelectionStart < 6)
                Time.Minute++;
            else if (mtb_Time.SelectionStart < 9)
                Time.Second++;
            else Time.Minute++;
            mtb_Time.Text = _Time.GetTime();
            mtb_Time.SelectionStart = ss;
        }
        private void btn_Bottom_Click(object sender, EventArgs e)
        {
            int ss = mtb_Time.SelectionStart;
            if (mtb_Time.SelectionStart < 3)
                Time.Hour--;
            else if (mtb_Time.SelectionStart < 6)
                Time.Minute--;
            else if (mtb_Time.SelectionStart < 9)
                Time.Second--;
            else Time.Minute--;
            mtb_Time.Text = _Time.GetTime();
            mtb_Time.SelectionStart = ss;
        }
        private void mtb_Time_TextChanged(object sender, EventArgs e)
        {
            if (mtb_Time.Text.Length >= 8)
            {
                mtb_Time.Text = mtb_Time.Text.Replace(' ', '0');
                mtb_Time.Text = mtb_Time.Text.Replace('_', '0');
                string[] sa = mtb_Time.Text.Split(':');
                Time.Hour = Convert.ToInt32(sa[0]);
                Time.Minute = Convert.ToInt32(sa[1]);
                Time.Second = Convert.ToInt32(sa[2]);
            }
            if (ValueChanged != null) ValueChanged(this, e);
        }
        private void TimePicker_BackColorChanged(object sender, EventArgs e)
        {
            mtb_Time.BackColor = BackColor;
        }
        #endregion


    }
}
