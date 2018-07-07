using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiMFa_Framework.Exclusive.DateAndTime
{
    [Serializable]
    public class MiMFa_IntervalTime
    {
        public MiMFa_Time FromTime = new MiMFa_Time();
        public MiMFa_Time ToTime = new MiMFa_Time();
        public MiMFa_Time Time
        {
            get { return FromTime.GetLengthTime(ToTime); }
        }
    }

}
