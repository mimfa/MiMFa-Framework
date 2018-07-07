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
    public partial class HourPicker : DateTime
    {
        #region CategoryAttribute
        [CategoryAttribute()]

        public event EventHandler ValueChanged;
        public MiMFa_Time Value
        {
            get
            {
                return new MiMFa_Framework.Exclusive.DateAndTime.MiMFa_Time((int)Hour.Value, (int)Minute.Value);
            }
            set
            {
                Hour.Value= value.Hour;
                Minute.Value = value.Minute;
            }
        }

        #endregion

        public HourPicker()
        {
            InitializeComponent();
        }

        #region Private Region
        private void Minute_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(this, e);
        }
        #endregion

    }
}
