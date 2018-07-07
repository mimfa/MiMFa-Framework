using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.Collection;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public partial class DayDetail : DateTime
    {
        #region CategoryAttribute

        #endregion

        public DayDetail()
        {
            InitializeComponent();
            base.Timer.Enabled = true;
            State_Compute();
        }

        #region Private Region

        protected override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            l_Time.Text = DateAndTime.GetTime();
            if (DateAndTime.GetSecond() == 0)
                State_Compute();
        }

        private void State_Compute()
        {
            l_Date.Text = DateAndTime.GetDate();
            l_DayOfWeek.Text = DateAndTime.GetDayOfWeekName();
            pb_AirView.BackColor = DateAndTime.GetSkyColor();
        }

        #endregion

        private void DayDetail_Load(object sender, EventArgs e)
        {
            State_Compute();
        }
    }
}
