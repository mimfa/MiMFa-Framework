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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public partial class MeetTime : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler ValueChanged;
        public string IntervalText
        {
            get { return l_Text.Text; }
            set { l_Text.Text = value; }
        }
        public MiMFa_IntervalMeetTime Interval
        {
            get
            {
                MiMFa_IntervalMeetTime intr = new MiMFa_IntervalMeetTime();
                intr.Date = mDate.Date;
                intr.Time = mTime.Time;
                return intr;
            }
            set
            {
                mDate.Date = value.Date;
                mTime.Time = value.Time;
            }
        }
        public MiMFa_Date Date
        {
            get
            {
                return mDate.Date;
            }
            set
            {
                mDate.Date = value;
            }
        }
        public MiMFa_Time Time
        {
            get
            {
                return mTime.Time;
            }
            set
            {
                mTime.Time = value;
            }
        }
        #endregion

        public MeetTime()
        {
            InitializeComponent();
        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(sender, e);
        }
    }
}
