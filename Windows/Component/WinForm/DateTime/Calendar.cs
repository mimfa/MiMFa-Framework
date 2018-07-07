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
using MiMFa_Framework.General;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public partial class Calendar : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler ValueChanged;
        public event EventHandler DayDoubleClick;
        public event EventHandler DayClick;
        public List<MiMFa_Date> PriodList { get; set; } = new List<MiMFa_Date>();
        public MiMFa_Date FromDate
        {
            get { return _FromDate; }
            set 
            { 
                _FromDate = value;
                Reset(_FromDate);
            }
        }
        public MiMFa_Date ToDate
        {
            get{return _ToDate;}
            set{_ToDate = value;}
        }
        public Color TodayBackColor { get; set; } = Color.Lime;
        public Color PriodBackColor { get; set; } = Color.RoyalBlue;
        public Color AllDayBackColor { get; set; } = Color.Transparent;
        public int PriodLength
        {
            get { return _PriodLength; }
            set
            { 
                _PriodLength = value;
                Reset(_FromDate);
            }
        }
        public int Difference { get; set; } = 0;
        public bool SubjectDay
        {
            get { return Sunday.Visible; }
            set
            {
                List<System.Windows.Forms.Label> ca = MiMFa_ControlService.FindControlByType<System.Windows.Forms.Label>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].Visible = value;
            }
        }
        public bool MouseEvent
        {
            get { return dateTime_DayCalendar1.WithMouseEvent; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].WithMouseEvent = value;
            }
        }
        public Padding DayMargin
        {
            get { return dateTime_DayCalendar1.Margin; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].Margin = value;
            }
        }
        public Padding DayPadding
        {
            get { return dateTime_DayCalendar1.Padding; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].Padding = value;
            }
        }
        public Color MonthBackColor
        {
            get { return dateTime_DayCalendar1.MonthBackColor; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].MonthBackColor = value;
            }
        }
        public Color MonthForeColor
        {
            get { return dateTime_DayCalendar1.MonthForeColor; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].MonthForeColor = value;
            }
        }
        public Font MonthFont
        {
            get { return dateTime_DayCalendar1.MonthFont; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].MonthFont = value;
            }
        }
        public Color DayBackColor
        {
            get { return dateTime_DayCalendar1.DayBackColor; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].DayBackColor = value;
            }
        }
        public Color DayForeColor
        {
            get { return dateTime_DayCalendar1.DayForeColor; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].DayForeColor = value;
            }
        }
        public Font DayFont
        {
            get { return dateTime_DayCalendar1.DayFont; }
            set
            {
                List<DayCalendar> ca = MiMFa_ControlService.FindControlByType<DayCalendar>(__tlp_Main, false);
                for (int i = 0; i < ca.Count; i++)
                    ca[i].DayFont = value;
            }
        }
       
        #endregion

        public List<DayCalendar> Days
        {
            get
            {
                List<DayCalendar> days = new List<DayCalendar>();
                var c = this.__tlp_Main.Controls;
                for (int i = 0; i < c.Count; i++)
                    if (c[i].GetType() == typeof(DayCalendar)) days.Add((DayCalendar)c[i]);
                return days;
            }
        }
        public Calendar()
        {
            InitializeComponent();
            Start();
            Reset(FromDate);
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }

        public void Reset(MiMFa_Date fromDate = null)
        {
            if (FromDate != null || fromDate != null)
            {
                if (fromDate == null) FromDate.CopyTo(fromDate);
                MiMFa_Date md = new MiMFa_Date();
                fromDate.CopyTo( md);
                FromDate.CopyTo( _ToDate);
                bool ShowPriod = true;
                if (_PriodLength < 0)
                {
                    ToDate.Month++;
                    ToDate.Day = 1;
                    ToDate.Day--;
                }
                else if (_PriodLength == 0) ShowPriod = false;
                else ToDate.Day += (_PriodLength - 1);
                md.Day -= fromDate.DayOfWeekNum;
                PriodList = new List<MiMFa_Date>();
                for (int i = 1; i <= 42; i++)
                {
                    DayCalendar dc = (DayCalendar)__tlp_Main.Controls.Find("dateTime_DayCalendar" + i, false)[0];
                    MiMFa_Date mm = new MiMFa_Date();
                    md.CopyTo( mm);
                    dc.Date = mm;
                    if (MouseEvent)
                        if (md.IsBetween(FromDate, ToDate) && ShowPriod)
                        {
                            PriodList.Add(md);
                            dc.Enabled = true;
                            dc.BackColor = PriodBackColor;
                        }
                        else
                        {
                            dc.Enabled = false;
                            dc.BackColor = AllDayBackColor;
                        }
                    if (DateAndTime.GetDatePAC().IsSame(md)) dc.BackColor = TodayBackColor;
                    md.IncrementDay();
                }
            }
        }
        public void NextWeek()
        {
            Day_MouseWheel(dateTime_DayCalendar1,
                new MouseEventArgs(System.Windows.Forms.MouseButtons.Middle, 0, 0, 0, -120));
        }
        public void BackWeek()
        {
            Day_MouseWheel(dateTime_DayCalendar1,
                new MouseEventArgs(System.Windows.Forms.MouseButtons.Middle, 0, 0, 0, 120));
        }

        #region Private Region

        private MiMFa_Date _FromDate = new MiMFa_Date();
        private int _PriodLength = -1;
        private MiMFa_Date _ToDate = new MiMFa_Date();
        private MiMFa_Date _ShowOfDate = new MiMFa_Date();

        private void Start() 
        {
            DateAndTime.TimeZone = TimeZone;
            _FromDate.DateTimeStyle = DateAndTime;
            _FromDate = DateAndTime.GetDatePAC();
            _FromDate.Day = 1;
            FromDate.CopyTo( _ShowOfDate);
            Saturday.Text = DateAndTime.GetDayOfWeekName(0);
            Sunday.Text = DateAndTime.GetDayOfWeekName(1);
            Monday.Text = DateAndTime.GetDayOfWeekName(2);
            Tuesday.Text = DateAndTime.GetDayOfWeekName(3);
            Wednesday.Text = DateAndTime.GetDayOfWeekName(4);
            Thursday.Text = DateAndTime.GetDayOfWeekName(5);
            Friday.Text = DateAndTime.GetDayOfWeekName(6);
        }

        //target
        private void Day_MouseWheel(object sender, MouseEventArgs e)
        {
            _ShowOfDate.Day -= (7 * e.Delta / 120);
            if (_ShowOfDate.GetLengthDay(FromDate) < -15)
                FromDate.Month++;
            else if (_ShowOfDate.GetLengthDay(FromDate) > 15)
                FromDate.Month--;
            Reset(_ShowOfDate);
        }
        private void dateTime_DayCalendar18_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }
        private void dateTime_DayCalendar1_DoubleClick(object sender, EventArgs e)
        {
            if (DayDoubleClick != null) DayDoubleClick(sender, e);
        }
        private void dateTime_DayCalendar1_Click(object sender, EventArgs e)
        {
            if (DayClick != null) DayClick(sender, e);
        }

    }
        #endregion
}
