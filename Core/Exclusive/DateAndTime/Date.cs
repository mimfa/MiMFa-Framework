using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.DateAndTime
{
    [Serializable]
    public class MiMFa_Date
    {
        public MiMFa_DateTime DateTimeStyle = new MiMFa_DateTime();
        public int Year
        {
            get { return _Year; }
            set
            {
                if (value < 0) _Year = 0;
                else _Year = value;
            }
        }
        public int Month
        {
            get { return _Month; }
            set
            {
                if (value > 12 )
                {
                    Year += value / 12;
                    _Month = value%12;
                }
                else if (value == 0)
                {
                    Year--;
                    _Month = 12;
                }
                else if (value < 0)
                {
                    Year += value / 12;
                    _Month = 12 - (value % 12);
                }
                else _Month = value;
            }
        }
        public int Day
        {
            get { return _Day; }
            set
            {
                if (value > 0) IncrimentDay(value);
                else DecrimentDay(value);
            }
        }
        public float LengthYear
        {
            get
            {
                return (this != new MiMFa_Date(0, 0, 0)) ?
                    GetLengthYear(new MiMFa_Date(0, 0, 0), this) :  0;
            }
        }
        public float LengthMonth
        {
            get
            {
                return (this != new MiMFa_Date(0, 0, 0)) ?
                    GetLengthMonth(new MiMFa_Date(0, 0, 0), this) : 0;
            }
        }
        public float LengthDay
        {
            get
            {
                return (this != new MiMFa_Date(0, 0, 0)) ?
                  GetLengthDay(new MiMFa_Date(0, 0, 0), this) : 0;
            }
        }
        public MiMFa_DayOfWeek DayOfWeek
        {
            get { return (MiMFa_DayOfWeek)GetDayOfWeekNum(this, DateTimeStyle); }
        }
        public int DayOfWeekNum
        {
           get{ return GetDayOfWeekNum(this, DateTimeStyle);}
        }
        public string DayOfWeekName
        {
           get{ return GetDayOfWeekName(this, DateTimeStyle);}
        }
        public string MonthName
        {
            get { return GetMonthName(this, DateTimeStyle); }
        }
        public int MonthNumberDays
        {
            get 
            {
                return GetMonthNumberDays(this);
            }
        }

        #region override
        public override bool Equals(object op1)
        {
            if (op1 == null)
            {
                return false;
            }
            try
            {
                return (this == (MiMFa_Date)op1);
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            return this.GetDate();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static implicit operator string(MiMFa_Date op1)
        {
            return op1.GetDate();
        }
        public static implicit operator long(MiMFa_Date op1)
        {
            return Convert.ToInt64(string.Format("{0:d4}{1:d2}{2:d2}", op1.Year, op1.Month, op1.Day));
        }
        public static implicit operator double(MiMFa_Date op1)
        {
            return Convert.ToDouble(string.Format("{0:d4}{1:d2}{2:d2}", op1.Year, op1.Month, op1.Day) );
        }
        public static implicit operator decimal(MiMFa_Date op1)
        {
            return Convert.ToDecimal(string.Format("{0:d4}{1:d2}{2:d2}", op1.Year, op1.Month, op1.Day));
        }
        public static implicit operator float(MiMFa_Date op1)
        {
            return Convert.ToSingle(string.Format("{0:d4}{1:d2}{2:d2}", op1.Year, op1.Month, op1.Day));
        }
        public static implicit operator int(MiMFa_Date op1)
        {
            return Convert.ToInt32(string.Format("{0:d4}{1:d2}{2:d2}", op1.Year, op1.Month, op1.Day));
        }
        public static implicit operator byte[](MiMFa_Date op1)
        {
            return MiMFa_IOService.Serialize(op1);
        }
        public static implicit operator DateTime(MiMFa_Date op1)
        {
            return GetDateTime(op1);
        }

        public static explicit operator MiMFa_Date(DateTime dateTime)
        {
            MiMFa_Date d = new MiMFa_Date();
            d.SetDate(dateTime);
            return d;
        }
        public static explicit operator MiMFa_Date(MiMFa_DateTime dateTime)
        {
            MiMFa_Date d = new MiMFa_Date();
            d.SetDate(dateTime);
            return d;
        }
        public static explicit operator MiMFa_Date(string date)
        {
            MiMFa_Date d = new MiMFa_Date();
            d.SetDate(date);
            return d;
        }
        public static explicit operator MiMFa_Date(double date)
        {
            MiMFa_Date d = new MiMFa_Date();
            d.SetDate(date);
            return d;
        }

        public static MiMFa_Date operator ++(MiMFa_Date op1)
        {
            op1.Day++;
            return op1;
        }
        public static MiMFa_Date operator --(MiMFa_Date op1)
        {
            op1.Day--;
            return op1;
        }
        public static MiMFa_Date operator +(MiMFa_Date op1, MiMFa_Date op2)
        {
            var op = new MiMFa_Date(op1);
            op.IncreaseWith(op2);
            return op;
        }
        public static MiMFa_Date operator -(MiMFa_Date op1, MiMFa_Date op2)
        {
            var op = new MiMFa_Date(op1);
            op.DecreaseWith(op2);
            return op;
        }
        public static MiMFa_Date operator *(MiMFa_Date op1, MiMFa_Date op2)
        {
            var op = new MiMFa_Date(op1);
            op.Year *= op2.Year;
            op.Month *= op2.Month;
            op.Day *= op2.Day;
            return op;
        }
        public static MiMFa_Date operator /(MiMFa_Date op1, MiMFa_Date op2)
        {
            var op = new MiMFa_Date(op1);
            op.Year /= op2.Year;
            op.Month /= op2.Month;
            op.Day /= op2.Day;
            return op;
        }
        public static bool operator ==(MiMFa_Date op1, MiMFa_Date op2)
        {
            try
            {
                return op1.IsSame(op2);
            }
            catch { return ReferenceEquals(op1, op2); }
        }
        public static bool operator !=(MiMFa_Date op1, MiMFa_Date op2)
        {
            return !(op1 == op2);
        }
        public static bool operator >(MiMFa_Date op1, MiMFa_Date op2)
        {
            return op1.IsNext(op2);
        }
        public static bool operator <(MiMFa_Date op1, MiMFa_Date op2)
        {
            return op1.IsBack(op2);
        }
        public static bool operator >=(MiMFa_Date op1, MiMFa_Date op2)
        {
            return op1 == op2 || op1 > op2;
        }
        public static bool operator <=(MiMFa_Date op1, MiMFa_Date op2)
        {
            return op1 == op2 || op1 < op2;
        }
        public static MiMFa_Date operator ~(MiMFa_Date op1)
        {
            return new MiMFa_Date(0,0,0);
        }
        #endregion 

        public MiMFa_Date(int year = 1, int month = 1, int day = 1)
        {
            SetDate(year, month, day);
        }
        public MiMFa_Date(DateTime dt)
        {
            SetDate(dt);
        }
        public MiMFa_Date(MiMFa_DateTime mdt)
        {
            SetDate(mdt);
        }

        public void IncrementDay()
        {
            Day++;
        }
        public void DecrementDay()
        {
            Day--;
        }

        public void SetDate(int year = 1, int month = 1, int day = 1)
        {
            _Year = year;
            _Month = month;
            _Day = day;
        }
        public void SetDate(MiMFa_DateTime dateTime)
        {
            DateTimeStyle = dateTime;
            SetDate(dateTime.GetYear(), dateTime.GetMonth(), dateTime.GetDay());
        }
        public void SetDate(string date)
        {
            SetDate(MiMFa_Convert.ToMiMFaDate(date));
        }
        public void SetDate(double date)
        {
            string str = date + "";
            if (str.Length > 6) { _Day = Convert.ToInt32(str.Substring(6));str = str.Substring(0, 6); }
            if (str.Length > 4) { _Month = Convert.ToInt32(str.Substring(4));str = str.Substring(0, 4); }
            if (str.Length > 0)  _Year = Convert.ToInt32(str.Substring(0));
        }
        public void SetDate(MiMFa_Date date)
        {
            SetDate(date.Year,date.Month,date.Day);
        }
        public void SetDate(DateTime dateTime)
        {
            SetDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }
        public DateTime GetDateTime()
        {
            return GetDateTime(this);
        }
        public static DateTime GetDateTime(MiMFa_Date date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        public string GetDate()
        {
            return GetDate(this);
        }
        public static string GetDate(MiMFa_Date date)
        {
            return string.Format("{0:d2}/{1:d2}/{2:d4}", date.Day, date.Month, date.Year);
        }

        #region Service

        public void CopyTo(MiMFa_Date thisDate)
        {
            CopyTo(this,thisDate);
        }
        public static void CopyTo(MiMFa_Date fromThisDate,MiMFa_Date toThisDate)
        {
            if (toThisDate == null) toThisDate = new MiMFa_Date();
            toThisDate._Year = fromThisDate._Year;
            toThisDate._Month = fromThisDate._Month;
            toThisDate._Day = fromThisDate._Day;
            toThisDate.DateTimeStyle = fromThisDate.DateTimeStyle;
        }

        public void IncreaseWith(params MiMFa_Date[] withThisDates)
        {
            Increase(this, withThisDates);
        }
        public static void Increase(MiMFa_Date thisDate, params MiMFa_Date[] withThisDates)
        {
            foreach (var item in withThisDates)
            {
                thisDate.Year += item._Year;
                thisDate.Month += item._Month;
                thisDate.Day += item._Day;
            }
        }
        public void DecreaseWith(params MiMFa_Date[] withThisDates)
        {
            Decrease(this, withThisDates);
        }
        public static void Decrease(MiMFa_Date thisDate, params MiMFa_Date[] withThisDates)
        {
            foreach (var item in withThisDates)
            {
                thisDate.Year -= item._Year;
                thisDate.Month -= item._Month;
                thisDate.Day -= item._Day;
            }
        }

        public bool IsSame(MiMFa_Date thisDate)
        {
            return IsSame(this, thisDate);
        }
        public static bool IsSame(MiMFa_Date thisDate, MiMFa_Date withThisDate)
        {
            if (withThisDate._Year == thisDate._Year &&
            withThisDate._Month == thisDate._Month &&
            withThisDate._Day == thisDate._Day)
                return true;
            return false;
        }
        public bool IsBetween(MiMFa_Date fromThisDate, MiMFa_Date toThisDate)
        {
            return IsBetween(this,fromThisDate, toThisDate);
        }
        public static bool IsBetween(MiMFa_Date thisDate, MiMFa_Date fromThisDate, MiMFa_Date toThisDate)
        {
            if (IsSame(thisDate,fromThisDate)
                ||IsSame(thisDate,toThisDate)
                ||(IsNext(thisDate,fromThisDate)
                && IsBack(thisDate,toThisDate)))
                return true;
            return false;
        }
        public bool IsBack(MiMFa_Date fromThisDate)
        {
            return IsBack(this, fromThisDate);
        }
        public static bool IsBack(MiMFa_Date thisDate, MiMFa_Date fromThisDate)
        {
            if (ReferenceEquals(thisDate, null) || ReferenceEquals(fromThisDate, null)) return false;
            if (thisDate.Year < fromThisDate.Year) return true;
            if (thisDate.Year == fromThisDate.Year && thisDate.Month < fromThisDate.Month) return true;
            if (thisDate.Year == fromThisDate.Year && thisDate.Month == fromThisDate.Month && thisDate.Day < fromThisDate.Day) return true;
            return false;
        }
        public bool IsNext(MiMFa_Date fromThisDate)
        {
            return IsNext(this, fromThisDate);
        }
        public static bool IsNext(MiMFa_Date thisDate, MiMFa_Date fromThisDate)
        {
            if (ReferenceEquals(thisDate, null) || ReferenceEquals(fromThisDate, null)) return false;
            if (thisDate.Year > fromThisDate.Year) return true;
            if (thisDate.Year == fromThisDate.Year && thisDate.Month > fromThisDate.Month) return true;
            if (thisDate.Year == fromThisDate.Year && thisDate.Month == fromThisDate.Month && thisDate.Day > fromThisDate.Day) return true;
            return false;
        }
        public bool IsLeapYear()
        {
            return IsLeapYear(this);
        }
        public static bool IsLeapYear(MiMFa_Date thisDate)
        {
            return thisDate.DateTimeStyle.ZoneCalendar.IsLeapYear(thisDate.Year);
        }

        public static int GetDayOfWeekNum(MiMFa_Date ThisDate, MiMFa_DateTime dateTime)
        {
            return MiMFa_Convert.ToDayOfWeekNum(ThisDate,dateTime);
        }
        public static string GetDayOfWeekName(MiMFa_Date ThisDate, MiMFa_DateTime dateTime)
        {
            return MiMFa_Convert.ToDayOfWeekName(ThisDate,dateTime);
        }
        public static string GetMonthName(MiMFa_Date ThisDate, MiMFa_DateTime dateTime)
        {
            return MiMFa_Convert.ToMonthName(ThisDate, dateTime);
        }
        public static int GetMonthNumberDays(MiMFa_Date ThisDate)
        {
            MiMFa_Date md = new MiMFa_Date();
            ThisDate.CopyTo(md);
            md.Month++;
            md.Day = 1;
            md.Day--;
            return md.Day;
        }

        public List<MiMFa_Date> GetDateList(MiMFa_Date toThisDate)
        {
            return GetDateList(this, toThisDate);
        }
        public static List<MiMFa_Date> GetDateList(MiMFa_Date ofThisDate, MiMFa_Date toThisDate)
        {
            return GetDateList(ofThisDate, ofThisDate.GetLengthDay(toThisDate));
        }
        public List<MiMFa_Date> GetDateList(int length)
        {
            return GetDateList(this, length);
        }
        public static List<MiMFa_Date> GetDateList(MiMFa_Date ofThisDate, int length)
        {
            List<MiMFa_Date> lmd = new List<MiMFa_Date>();
            MiMFa_Date md = new MiMFa_Date();
            ofThisDate.CopyTo(md);
            for (int i = 0; i < length; i++)
            {
                MiMFa_Date m = new MiMFa_Date();
                md.CopyTo(m);
                lmd.Add(m);
                md.Day++;
            }
            return lmd;
        }
        public MiMFa_Date GetLengthDate(MiMFa_Date toThisDate)
        {
            return GetLengthDate(this, toThisDate);
        }
        public static MiMFa_Date GetLengthDate(MiMFa_Date ofThisDate, MiMFa_Date toThisDate)
        {
            float Len = GetLengthDay(ofThisDate, toThisDate);
            int h = (int)Len / 365;
            int m = (int)(Len % 365) / 30;
            int s = (int)(Len % 365) % 30;
            MiMFa_Date Date = new MiMFa_Date();
            Date._Year = h;
            Date._Month = m;
            Date._Day = s;
            return Date;
        }
        public int GetLengthYear(MiMFa_Date toThisDate)
        {
            return GetLengthYear(this, toThisDate);
        }
        public static int GetLengthYear(MiMFa_Date fromThisDate, MiMFa_Date toThisDate)
        {
            return Convert.ToInt32(GetLengthDay(fromThisDate, toThisDate)/ 365.25F);
        }
        public int GetLengthMonth(MiMFa_Date toThisDate)
        {
            return GetLengthMonth(this, toThisDate);
        }
        public static int GetLengthMonth(MiMFa_Date fromThisDate, MiMFa_Date toThisDate)
        {
            return Convert.ToInt32(GetLengthDay(fromThisDate, toThisDate)/ 30.4375F);
        }
        public int GetLengthDay(MiMFa_Date toThisDate)
        {
            return GetLengthDay(this, toThisDate);
        }
        public static int GetLengthDay(MiMFa_Date fromThisDate, MiMFa_Date toThisDate)
        {
            int dayi = 0;
            int mc = 0;
            dayi += Convert.ToInt32((toThisDate.Year - fromThisDate.Year) * 365);
            if (toThisDate.Month > (mc = fromThisDate.Month))
                while (mc < toThisDate.Month)
                    if (mc++ <= 6) dayi += 31;
                    else dayi += 30;
            else if (toThisDate.Month < (mc = fromThisDate.Month))
                while (mc > toThisDate.Month)
                    if (mc-- <= 7) dayi -= 31;
                    else dayi -= 30;
            dayi += toThisDate.Day - fromThisDate.Day;
            if (toThisDate.Year > (mc = fromThisDate.Year))
                while (mc < toThisDate.Year)
                    if (fromThisDate.DateTimeStyle.ZoneCalendar.IsLeapYear(mc++)) dayi++;
            if (toThisDate.Year < (mc = fromThisDate.Year))
                while (mc > toThisDate.Year)
                    if (fromThisDate.DateTimeStyle.ZoneCalendar.IsLeapYear(mc++)) dayi--;
            return dayi;
        }

        #endregion

        #region Private Region

        public int _Year;
        public int _Month;
        public int _Day;

        internal void IncrimentDay(int dayNum)
        {
            if (dayNum <= 29) _Day = dayNum;
            else
                while (dayNum > 0)
                    if (_Month == 12)
                        if (DateTimeStyle.ZoneCalendar != null)
                            if (_Year <=0 || DateTimeStyle.ZoneCalendar.IsLeapYear(_Year))
                                if (dayNum > 30)
                                {
                                    dayNum -= 30;
                                    Month++;
                                    _Day = 1;
                                }
                                else
                                {
                                    _Day = dayNum;
                                    dayNum = 0;
                                }
                            else
                            {
                                if (dayNum > 29)
                                {
                                    dayNum -= 29;
                                    Month++;
                                    _Day = 1;
                                }
                                else
                                {
                                    _Day = dayNum;
                                    dayNum = 0;
                                }
                            }
                        else
                        {
                            if (DateTime.IsLeapYear(_Year))
                                if (dayNum > 30)
                                {
                                    dayNum -= 30;
                                    Month++;
                                    _Day = 1;
                                }
                                else
                                {
                                    _Day = dayNum;
                                    dayNum = 0;
                                }
                            else
                            {
                                if (dayNum > 29)
                                {
                                    dayNum -= 29;
                                    Month++;
                                    _Day = 1;
                                }
                                else
                                {
                                    _Day = dayNum;
                                    dayNum = 0;
                                }
                            }
                        }
                        else if (_Month > 6)
                            if (dayNum > 30)
                            {
                                dayNum -= 30;
                                Month++;
                                _Day = 1;
                            }
                            else
                            {
                                _Day = dayNum;
                                dayNum = 0;
                            }
                        else // 1 to 6
                            if (dayNum > 31)
                            {
                                dayNum -= 31;
                                Month++;
                                _Day = 1;
                            }
                            else
                            {
                                _Day = dayNum;
                                dayNum = 0;
                            }
            if (_Day == 0) _Day = 1;
        }
        internal void DecrimentDay(int dayNum)
        {
            while (dayNum < 0)
            {
                Month--;
                if (_Month == 12)
                    if (DateTimeStyle.ZoneCalendar != null)
                        if (DateTimeStyle.ZoneCalendar.IsLeapYear(_Year))
                            if (dayNum <= -30)
                            {
                                dayNum += 30;
                                _Day = 1;
                            }
                            else
                            {
                                _Day = 30 + dayNum;
                                dayNum = 0;
                            }
                        else
                        {
                            if (dayNum <= -29)
                            {
                                dayNum += 29;
                                _Day = 1;
                            }
                            else
                            {
                                _Day = 29 + dayNum;
                                dayNum = 0;
                            }
                        }
                    else
                    {
                        if (DateTime.IsLeapYear(_Year))
                            if (dayNum <= -30)
                            {
                                dayNum += 30;
                                _Day = 1;
                            }
                            else
                            {
                                _Day = 30 + dayNum;
                                dayNum = 0;
                            }
                        else
                        {
                            if (dayNum <= -29)
                            {
                                dayNum += 29;
                                _Day = 1;
                            }
                            else
                            {
                                _Day = 29 + dayNum;
                                dayNum = 0;
                            }
                        }
                    }
                else if (_Month > 6)
                    if (dayNum <= -30)
                    {
                        dayNum += 30;
                        _Day = 1;
                    }
                    else
                    {
                        _Day = 30 + dayNum;
                        dayNum = 0;
                    }
                else // 1 to 6
                    if (dayNum <= -31)
                    {
                        dayNum += 31;
                        _Day = 1;
                    }
                    else
                    {
                        _Day = 31 + dayNum;
                        dayNum = 0;
                    }
            }
            if (dayNum == 0)
            {
                Month--;
                if (Month == 12)
                    if (DateTimeStyle.ZoneCalendar != null)
                        if (DateTimeStyle.ZoneCalendar.IsLeapYear(_Year))
                            _Day = 30;
                        else _Day = 29;
                    else if (DateTime.IsLeapYear(_Year)) _Day = 30;
                    else _Day = 29;
                else if (Month > 6)
                    _Day = 30;
                else _Day = 31;
            }
        }

        #endregion
    }
}
