using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiMFa_Framework.Exclusive.DateAndTime
{
    [Serializable]
    public class MiMFa_IntervalDate
    {
        public MiMFa_Date FromDate = new MiMFa_Date();
        public MiMFa_Date ToDate = new MiMFa_Date();
        public MiMFa_Date Date
        {
            get { return FromDate.GetLengthDate(ToDate); }
        }
    }

}
