using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Drawing;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Collection;

namespace MiMFa_Framework.Exclusive.DateAndTime
{
    [Serializable]
    public class MiMFa_DateTime
    {
        public Calendar ZoneCalendar = new PersianCalendar();
        public MiMFa_TimeZone TimeZone
        {
            get { return _TimeZone; }
            set
            {
                switch (value)
                {
                    case MiMFa_TimeZone.IranStandard:
                        ZoneCalendar = new PersianCalendar();
                        break;
                    case MiMFa_TimeZone.IranDaylight:
                        ZoneCalendar = new PersianCalendar();
                        break;
                    case MiMFa_TimeZone.ArabiaStandard:
                        ZoneCalendar = new HijriCalendar();
                        break;
                    case MiMFa_TimeZone.GeorgiaStandard:
                        ZoneCalendar = new GregorianCalendar();
                        break;
                    case MiMFa_TimeZone.JapanStandard:
                        ZoneCalendar = new JapaneseCalendar();
                        break;
                    case MiMFa_TimeZone.IsraelStandard:
                        ZoneCalendar = new HebrewCalendar();
                        break;
                    case MiMFa_TimeZone.IsraelDaylight:
                        ZoneCalendar = new HebrewCalendar();
                        break;
                    case  MiMFa_TimeZone.KoreaStandard:
                        ZoneCalendar = new KoreanCalendar();
                        break;
                    case MiMFa_TimeZone.China:
                        ZoneCalendar = new TaiwanCalendar();
                        break;
                    default:
                        ZoneCalendar = new GregorianCalendar();
                        break;
                }
                _TimeZone = value;
            }
        }
        private MiMFa_TimeZone _TimeZone = MiMFa_TimeZone.IranStandard;

        public MiMFa_DateTime()
        { }
        public MiMFa_DateTime(MiMFa_TimeZone timeZone = MiMFa_TimeZone.IranStandard)
        {
            TimeZone = timeZone;
        }

        public MiMFa_Date GetDatePAC()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return new MiMFa_Date(dt.Year, dt.Month, dt.Day);
            else
                return new MiMFa_Date(ZoneCalendar.GetYear(dt), ZoneCalendar.GetMonth(dt), ZoneCalendar.GetDayOfMonth(dt));
        }
        public string GetDate()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return string.Format("{0:d2}\\{1:d2}\\{2:d4}", dt.Day, dt.Month, dt.Year);
            else
                return string.Format("{0:d2}\\{1:d2}\\{2:d4}", ZoneCalendar.GetDayOfMonth(dt), ZoneCalendar.GetMonth(dt), ZoneCalendar.GetYear(dt));
        }
        public int GetYear()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.Year;
            else
                return ZoneCalendar.GetYear(dt);
        }
        public int GetMonth()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.Month;
            else
                return ZoneCalendar.GetMonth(dt);
        }
        public int GetDay()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.Day;
            else
                return ZoneCalendar.GetDayOfMonth(dt);
        }
        public DayOfWeek GetDayOfWeek()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.DayOfWeek;
            else
                return ZoneCalendar.GetDayOfWeek(dt);
        }
        public int GetDayOfWeekNumber()
        {
            return MiMFa_Convert.ToHijriDayOfWeekNum( GetDayOfWeek());
        }
        public string GetDayOfWeekName(int dayOfWeek = -1)
        {
            if (dayOfWeek < 0) return MiMFa_Convert.ToDayOfWeekName(this.GetDatePAC(), this);
            return MiMFa_Convert.ToDayOfWeekName(dayOfWeek, this);
        }
        public string GetMonthName()
        {
            return MiMFa_Convert.ToMonthName(GetDatePAC(), this);
        }
        public int GetDayOfYear()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.DayOfYear;
            else
                return ZoneCalendar.GetDayOfYear(dt);
        }

        public MiMFa_Time GetTimePAC()
        {
            DateTime dt = DateTime.Now;
            return new MiMFa_Time( dt.Hour, dt.Minute, dt.Second);
        }
        public string GetTime()
        {
            DateTime dt = DateTime.Now;
            return string.Format("{0:d2}:{1:d2}:{2:d2}", dt.Hour, dt.Minute, dt.Second);
        }
        public int GetHour()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.Hour;
            else
                return ZoneCalendar.GetHour(dt);
        }
        public int GetMinute()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.Minute;
            else
                return ZoneCalendar.GetMinute(dt);
        }
        public int GetSecond()
        {
            DateTime dt = DateTime.Now;
            if (ZoneCalendar == null)
                return dt.Second;
            else
                return ZoneCalendar.GetSecond(dt);
        }
        public Color GetSkyColor()
        {
            switch (GetHour())
            {
                case 0: return Color.MidnightBlue;
                case 1: return Color.MidnightBlue;
                case 2: return Color.Navy;
                case 3: return Color.DarkBlue;
                case 4: return Color.MediumBlue;
                case 5: return Color.RoyalBlue;
                case 6: return Color.CornflowerBlue;
                case 7: return Color.Lavender;
                case 8: return Color.AliceBlue;
                case 9: return Color.GhostWhite;
                case 10: return Color.MintCream;
                case 11: return Color.Honeydew;
                case 12: return Color.Ivory;
                case 13: return Color.LightYellow;
                case 14: return Color.Cornsilk;
                case 15: return Color.OldLace;
                case 16: return Color.PapayaWhip;
                case 17: return Color.NavajoWhite;
                case 18: return Color.Tan;
                case 19: return Color.SlateGray;
                case 20: return Color.DarkSlateGray;
                case 21: return Color.DarkBlue;
                case 22: return Color.Navy;
                case 23: return Color.MidnightBlue;
                default: return Color.DeepSkyBlue;
            }
        }

        public static MiMFa_Time GetThisTimePAC()
        {
            DateTime dt = DateTime.Now;
            return new MiMFa_Time(dt.Hour, dt.Minute, dt.Second);
        }
        public static string GetThisTime()
        {
            DateTime dt = DateTime.Now;
            return string.Format("{0:d2}:{1:d2}:{2:d2}", dt.Hour, dt.Minute, dt.Second);
        }

        public static MiMFa_Date GetThisDatePAC(Calendar zoneCalendar)
        {
            DateTime dt = DateTime.Now;
            if (zoneCalendar == null)
                return new MiMFa_Date(dt.Year, dt.Month, dt.Day);
            else
                return new MiMFa_Date(zoneCalendar.GetYear(dt), zoneCalendar.GetMonth(dt), zoneCalendar.GetDayOfMonth(dt));
        }
        public static string GetThisDate(Calendar zoneCalendar)
        {
            DateTime dt = DateTime.Now;
            if (zoneCalendar == null)
                return string.Format("{0:d2}\\{1:d2}\\{2:d4}", dt.Day, dt.Month, dt.Year);
            else
                return string.Format("{0:d2}\\{1:d2}\\{2:d4}", zoneCalendar.GetDayOfMonth(dt), zoneCalendar.GetMonth(dt), zoneCalendar.GetYear(dt));
        }
    }
}
