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
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.Effect;
using MiMFa_Framework.Exclusive.Collection;

namespace MiMFa_Framework.Component.WinForm.DateTime
{
    public class DateTime: WinForm
    {
        #region Field

        private Timer _Timer = null;
        private MiMFa_DateTime _DateAndTime = new MiMFa_DateTime();

        #endregion

        #region Property
        [CategoryAttribute()]

        public virtual Timer Timer
        {
            get
            {
                if (_Timer == null)
                {
                    _Timer = new Timer();
                    _Timer.Tick += new EventHandler(Timer_Tick);
                    _Timer.Interval = 1000;
                    _Timer.Enabled = true;
                }
                return _Timer;
            }
            set { _Timer = value; }
        }
        public virtual MiMFa_DateTime DateAndTime
        {
            get { return _DateAndTime; }
            set { _DateAndTime = value; }
        }
        public virtual MiMFa_TimeZone TimeZone
        {
            get { return _DateAndTime.TimeZone; }
            set { _DateAndTime.TimeZone = value; }
        }

        #endregion

        #region Function


        #endregion

        #region Target

        protected virtual void Timer_Tick(object sender,EventArgs e)
        {

        }

        #endregion
    }
}
