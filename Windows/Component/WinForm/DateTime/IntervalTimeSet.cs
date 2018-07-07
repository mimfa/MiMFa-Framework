using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Service;
using MiMFa_Framework.Exclusive.DateAndTime;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public partial class IntervalTimeSet : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler ValueChanged;
        public string IntervalText
        {
            get { return l_Text.Text; }
            set { l_Text.Text = value; }
        }
        public MiMFa_IntervalTime Interval
        {
            get
            {
                MiMFa_IntervalTime intr = new MiMFa_IntervalTime();
                intr.FromTime = FromTime.Time;
                intr.ToTime = ToTime.Time;
                return intr;
            }
            set
            {
                FromTime.Time = value.FromTime;
                ToTime.Time = value.ToTime;
            }
        }
        #endregion

        public IntervalTimeSet()
        {
            InitializeComponent();
            SetAllEventParentToControls();
        }

        #region Private
        private void dttp_FromHour_ValueChanged(object sender, EventArgs e)
        {
            l_Time.Text = FromTime.Time.GetLengthTime(ToTime.Time).GetTime();
            if (ValueChanged != null) ValueChanged(this, e);
        }
        #endregion
    }
}
