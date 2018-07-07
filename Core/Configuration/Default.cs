using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.DateAndTime;

namespace MiMFa_Framework.Configuration
{
    public static class Default
    {
        public static string ApplicationPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public static MiMFa_DateTime DateTime { get; set; } = new MiMFa_DateTime(Exclusive.Collection.MiMFa_TimeZone.IranStandard);
        public static MiMFa_Date Date { get { return DateTime.GetDatePAC(); } }
        public static MiMFa_Time Time { get { return DateTime.GetTimePAC(); } }

    }
}
