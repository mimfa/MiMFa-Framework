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
    public partial class DatePicker : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler ValueChanged = null;
        public MiMFa_Date Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                if (value != null)
                    _Date = value;
                else _Date = new MiMFa_Date(0, 0, 0);
                mtb_Date.Text = _Date.GetDate();
            }
        }
        public bool ThisDate
        {
            get { return _ThisDate; }
            set
            {
                _ThisDate = value;
                if (_ThisDate)
                {
                    MiMFa_DateTime dt = new MiMFa_DateTime();
                    _Date.Year = dt.GetYear();
                    _Date.Month = dt.GetMonth();
                    _Date.Day = dt.GetDay();
                    mtb_Date.Text = _Date.GetDate();
                }
                else
                {
                    MiMFa_Date md = new MiMFa_Date(1, 1, 1);
                    mtb_Date.Text = md.GetDate();
                }
            }
        }

        #endregion

        public DatePicker()
        {
            InitializeComponent();
            mtb_Date.MouseWheel += thisMouseWheel;
            mtb_Date.BackColor = BackColor;
            SetAllEventParentToControls();
        }
        private void mtb_Date_Enter(object sender, EventArgs e)
        {
            mtb_Date.SelectAll();
        }
        private void DatePicker_BackColorChanged(object sender, EventArgs e)
        {
            mtb_Date.BackColor = BackColor;
        }
        #region Private Region

        private bool _ThisDate = false;
        private MiMFa_Date _Date = new MiMFa_Date();

        private void thisMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) btn_Top_Click(sender, new EventArgs());
            else btn_Bottom_Click(sender, new EventArgs());
        }
        private void btn_Top_Click(object sender, EventArgs e)
        {
           int ss =  mtb_Date.SelectionStart;
            if (mtb_Date.SelectionStart < 3)
                Date.Day++;
            else if (mtb_Date.SelectionStart < 6)
                Date.Month++;
            else if (mtb_Date.SelectionStart < 11)
                Date.Year++;
            else Date.Day++;
            mtb_Date.Text = _Date.GetDate();
            mtb_Date.SelectionStart = ss;
        }
        private void btn_Bottom_Click(object sender, EventArgs e)
        {
            int ss = mtb_Date.SelectionStart;
            if (mtb_Date.SelectionStart < 3)
                Date.Day--;
            else if (mtb_Date.SelectionStart < 6)
                Date.Month--;
            else if (mtb_Date.SelectionStart < 11)
                Date.Year--;
            else Date.Day--;
            mtb_Date.Text = _Date.GetDate();
            mtb_Date.SelectionStart = ss;
        }
        private void mtb_Date_TextChanged(object sender, EventArgs e)
        {
            if (mtb_Date.Text.Length >= 10)
            {
                mtb_Date.Text = mtb_Date.Text.Replace(' ', '0');
                mtb_Date.Text = mtb_Date.Text.Replace('_', '0');
                string[] sa = mtb_Date.Text.Split('/');
                Date.Year = Convert.ToInt32(sa[2]);
                Date.Month = Convert.ToInt32(sa[1]);
                Date.Day = Convert.ToInt32(sa[0]);
            }
            if (ValueChanged != null) ValueChanged(this, e);
        }

        #endregion


    }
}
