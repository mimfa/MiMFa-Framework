using MiMFa_Framework.General;
using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiMFa_Framework.Exclusive.DateAndTime
{
    [Serializable]
    public class MiMFa_Time
    {
        public int Hour
        {
            get { return _Hour; }
            set
            {
                if (value > 23)
                {
                    _Hour = value % 24;
                }
                else if (value < 0)
                {
                    _Hour = 24 + value % 24;
                }
                else _Hour = value;
            }
        }
        public int Minute
        {
            get { return _Minute; }
            set
            {
                if (value > 59)
                {
                    Hour += value/60;
                    _Minute = value % 60;
                }
                else if (value < 0)
                {
                    Hour -= ((value / 60) + 1);
                    _Minute = 60 + value % 60;
                }
                else _Minute = value;
            }
        }
        public int Second
        {
            get { return _Second; }
            set
            {
                if (value > 59)
                {
                    Minute += value/60;
                    _Second = value % 60;
                }
                else if (value < 0)
                {
                    Minute -= ((value/60) +1);
                    _Second = 60 + value % 60;
                }
                else _Second = value;
            }
        }

        /// <summary>
        /// Unlimited Hour
        /// </summary>
        public int ULHour
        {
            get { return _Hour; }
            set
            {_Hour = value;
            }
        }
        /// <summary>
        /// Unlimited Minute
        /// </summary>
        public int ULMinute
        {
            get { return _Minute; }
            set
            {
                if (value > 59)
                {
                    ULHour += value / 60;
                    _Minute = value % 60;
                }
                else if (value < 0)
                {
                    ULHour -= ((value / 60) + 1);
                    _Minute = 60 + value % 60;
                }
                else _Minute = value;
            }
        }
        /// <summary>
        /// Unlimited ULSecond
        /// </summary>
        public int ULSecond
        {
            get { return _Second; }
            set
            {
                if (value > 59)
                {
                    ULMinute += value / 60;
                    _Second = value % 60;
                }
                else if (value < 0)
                {
                    ULMinute -= ((value / 60) + 1);
                    _Second = 60 + value % 60;
                }
                else _Second = value;
            }
        }
        public float LengthHour
        {
           get{ return(this != new MiMFa_Time(0, 0, 0))? 
                    GetLengthHour(new MiMFa_Time(0, 0, 0), this) :
                    0;}
        }
        public float LengthMinute
        {
           get{ return (this != new MiMFa_Time(0, 0, 0)) ?
                    GetLengthMinute(new MiMFa_Time(0, 0, 0), this) :0;}
        }
        public float LengthSecond
        {
            get { return (this != new MiMFa_Time(0, 0, 0)) ?
                    GetLengthSecond(new MiMFa_Time(0, 0, 0), this) :0; }
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
                return (this == (MiMFa_Time)op1);
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            return this.GetTime();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static implicit operator string(MiMFa_Time op1)
        {
            return op1.GetTime();
        }
        public static implicit operator long(MiMFa_Time op1)
        {
            return Convert.ToInt64(string.Format("{0}{1:d2}{2:d2}", op1.Hour ,op1.Minute ,op1.Second));
        }
        public static implicit operator double(MiMFa_Time op1)
        {
            return Convert.ToDouble(string.Format("{0}{1:d2}{2:d2}", op1.Hour, op1.Minute, op1.Second));
        }
        public static implicit operator decimal(MiMFa_Time op1)
        {
            return Convert.ToDecimal(string.Format("{0}{1:d2}{2:d2}", op1.Hour, op1.Minute, op1.Second));
        }
        public static implicit operator float(MiMFa_Time op1)
        {
            return Convert.ToSingle(string.Format("{0}{1:d2}{2:d2}", op1.Hour , op1.Minute , op1.Second));
        }
        public static implicit operator int(MiMFa_Time op1)
        {
            return Convert.ToInt32(string.Format("{0}{1:d2}{2:d2}", op1.Hour , op1.Minute , op1.Second));
        }
        public static implicit operator byte[] (MiMFa_Time op1)
        {
            return MiMFa_IOService.Serialize(op1);
        }
        public static implicit operator DateTime(MiMFa_Time op1)
        {
            return GetDateTime(op1);
        }

        public static explicit operator MiMFa_Time(DateTime op1)
        {
            return MiMFa_Convert.ToMiMFaTime(op1);
        }
        public static explicit operator MiMFa_Time(MiMFa_DateTime dateTime)
        {
            MiMFa_Time d = new MiMFa_Time();
            d.SetTime(dateTime.GetYear(), dateTime.GetMonth(), dateTime.GetDay());
            return d;
        }
        public static explicit operator MiMFa_Time(string op1)
        {
            return MiMFa_Convert.ToMiMFaTime(op1);
        }
        public static explicit operator MiMFa_Time(double op1)
        {
            var t = new MiMFa_Time();
            t.SetTime(op1);
            return t;
        }

        public static MiMFa_Time operator !(MiMFa_Time op1)
        {
            if (op1.Hour > 12) op1.Hour = op1.Hour - 12;
            else op1.Hour = op1.Hour + 12;
            return op1;
        }
        public static MiMFa_Time operator ++(MiMFa_Time op1)
        {
            op1.Second++;
            return op1;
        }
        public static MiMFa_Time operator --(MiMFa_Time op1)
        {
            op1.Second--;
            return op1;
        }
        public static MiMFa_Time operator +(MiMFa_Time op1, MiMFa_Time op2)
        {
           var op = new MiMFa_Time( op1);
            op.IncreaseWith(op2);
            return op;
        }
        public static MiMFa_Time operator -(MiMFa_Time op1, MiMFa_Time op2)
        {
            var op = new MiMFa_Time(op1);
            op.DecreaseWith(op2);
            return op;
        }
        public static MiMFa_Time operator *(MiMFa_Time op1, MiMFa_Time op2)
        {
            var op = new MiMFa_Time(op1);
            op.Hour *= op1.Hour;
            op.Minute *= op1.Minute;
            op.Second *= op1.Second;
            return op;
        }
        public static MiMFa_Time operator /(MiMFa_Time op1, MiMFa_Time op2)
        {
            var op = new MiMFa_Time(op1);
            op.Hour /= op1.Hour;
            op.Minute /= op1.Minute;
            op.Second /= op1.Second;
            return op;
        }
        public static bool operator ==(MiMFa_Time op1, MiMFa_Time op2)
        {
            try
            {
                return op1.IsSame(op2);
            }
            catch { return ReferenceEquals(op1, op2); }
        }
        public static bool operator !=(MiMFa_Time op1, MiMFa_Time op2)
        {
            return !(op1 == op2);
        }
        public static bool operator >(MiMFa_Time op1, MiMFa_Time op2)
        {
            return op1.IsNext(op2);
        }
        public static bool operator <(MiMFa_Time op1, MiMFa_Time op2)
        {
            return op1.IsBack(op2);
        }
        public static bool operator >=(MiMFa_Time op1, MiMFa_Time op2)
        {
            return op1 == op2 || op1 > op2;
        }
        public static bool operator <=(MiMFa_Time op1, MiMFa_Time op2)
        {
            return op1 == op2 || op1 < op2;
        }
        public static MiMFa_Time operator ~(MiMFa_Time op1)
        {
            return new MiMFa_Time(0, 0, 0);
        }
        #endregion

        public MiMFa_Time(int hour = 0, int min = 0, int sec = 0)
        {
            SetTime(hour, min, sec);
        }
        public MiMFa_Time(DateTime dt)
        {
            SetTime(dt.TimeOfDay.Hours, dt.TimeOfDay.Minutes, dt.TimeOfDay.Seconds);
        }
        public MiMFa_Time(MiMFa_DateTime mdt)
        {
            SetTime(mdt);
        }

        public void IncrementSecond()
        {
            Second++;
        }
        public void DecrementSecond()
        {
            Second--;
        }

        public void SetTime(int hour = 0, int min = 0, int sec = 0)
        {
            _Hour = hour;
            _Minute = min;
            _Second = sec;
        }
        public void SetTime(MiMFa_DateTime dateTime)
        {
            SetTime( dateTime.GetHour(),dateTime.GetMinute(), dateTime.GetSecond());
        }
        public void SetTime(DateTime dateTime)
        {
            SetTime(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
        public void SetTime(string time)
        {
            SetTime(MiMFa_Convert.ToMiMFaTime(time));
        }
        public void SetTime(double date)
        {
            string str = date + "";
            if (str.Length > 6) { _Second = Convert.ToInt32(str.Substring(6)); str = str.Substring(0, 6); }
            if (str.Length > 4) { _Minute = Convert.ToInt32(str.Substring(4)); str = str.Substring(0, 4); }
            if (str.Length > 0) _Hour = Convert.ToInt32(str.Substring(0));
        }
        public void SetTime(MiMFa_Time time)
        {
            SetTime(time.Hour, time.Minute, time.Second);
        }
        public string GetTime()
        {
            return GetTime(this) ;
        } 

        public static string GetTime(MiMFa_Time time)
        {
            return string.Format("{0:d2}:{1:d2}:{2:d2}", time.Hour, time.Minute, time.Second);
        }
        public DateTime GetDateTime()
        {
            return GetDateTime(this);
        }
        public static DateTime GetDateTime(MiMFa_Time time)
        {
            DateTime dt = new DateTime();
            dt = new DateTime(dt.Year, dt.Month, dt.Day, time.Hour, time.Minute, time.Second);
            return dt;
        }
        public string GetSpecialTime()
        {
            string ti = "";
            if (_Hour != 0) ti = string.Format("{0:d2}:{1:d2}:{2:d2}", Hour, Minute, Second);
            else if (_Minute != 0) ti = string.Format("{0:d2}:{1:d2}", Minute, Second);
            else ti = string.Format("{0:d2}", Second);
            return ti;
        }
     
        #region Service

        public void CopyTo(MiMFa_Time thisTime)
        {
            CopyTo(this, thisTime);
        }
        public static void CopyTo(MiMFa_Time ofThisTime, MiMFa_Time toThisTime)
        {
            toThisTime._Hour = ofThisTime._Hour;
            toThisTime._Minute = ofThisTime._Minute;
            toThisTime._Second = ofThisTime._Second;
        }

        public void IncreaseWith(params MiMFa_Time[] withThisTimes)
        {
            Increase(this, withThisTimes);
        }
        public static void Increase(MiMFa_Time thisTime,params MiMFa_Time[] withThisTimes)
        {
            foreach (var item in withThisTimes)
            {
                thisTime.ULHour += item._Hour;
                thisTime.ULMinute += item._Minute;
                thisTime.ULSecond += item._Second;
            }
        }
        public void DecreaseWith(params MiMFa_Time[] withThisTimes)
        {
            Decrease(this, withThisTimes);
        }
        public static void Decrease(MiMFa_Time thisTime, params MiMFa_Time[] withThisTimes)
        {
            foreach (var item in withThisTimes)
            {
                thisTime.ULHour -= item._Hour;
                thisTime.ULMinute -= item._Minute;
                thisTime.ULSecond -= item._Second;
            }
        }

        public bool Compare(MiMFa_Time thisTime)
        {
            return Compare(this, thisTime);
        }
        public static bool Compare(MiMFa_Time thisTime, MiMFa_Time rhitThisTime)
        {
            if (rhitThisTime._Hour == thisTime._Hour &&
            rhitThisTime._Minute == thisTime._Minute &&
            rhitThisTime._Second == thisTime._Second)
                return true;
            return false;
        }

        public bool IsSame(MiMFa_Time thisTime)
        {
            return IsSame(this, thisTime);
        }
        public static bool IsSame(MiMFa_Time thisTime, MiMFa_Time rhitthisTime)
        {
            return (rhitthisTime._Hour == thisTime._Hour &&
            rhitthisTime._Minute == thisTime._Minute &&
            rhitthisTime._Second == thisTime._Second) ;
        }
        public bool IsBetween(MiMFa_Time fromthisTime, MiMFa_Time tothisTime)
        {
            return IsBetween(this, fromthisTime, tothisTime);
        }
        public static bool IsBetween(MiMFa_Time thisTime, MiMFa_Time fromthisTime, MiMFa_Time tothisTime)
        {
            if (IsSame(thisTime, fromthisTime)
                || IsSame(thisTime, tothisTime)
                || (IsNext(thisTime, fromthisTime)
                && IsBack(thisTime, tothisTime)))
                return true;
            return false;
        }
        public bool IsBack(MiMFa_Time fromthisTime)
        {
            return IsBack(this, fromthisTime);
        }
        public static bool IsBack(MiMFa_Time thisTime, MiMFa_Time fromthisTime)
        {
            if (ReferenceEquals(thisTime, null) || ReferenceEquals(fromthisTime, null)) return false;
            if (thisTime.Hour < fromthisTime.Hour) return true;
            if (thisTime.Hour == fromthisTime.Hour && thisTime.Minute < fromthisTime.Minute) return true;
            if (thisTime.Hour == fromthisTime.Hour && thisTime.Minute == fromthisTime.Minute && thisTime._Second < fromthisTime._Second) return true;
            return false;
        }
        public bool IsNext(MiMFa_Time fromthisTime)
        {
            return IsNext(this, fromthisTime);
        }
        public static bool IsNext(MiMFa_Time thisTime, MiMFa_Time fromthisTime)
        {
            if (ReferenceEquals(thisTime, null) || ReferenceEquals(fromthisTime, null)) return false;
            if (thisTime.Hour > fromthisTime.Hour) return true;
            if (thisTime.Hour == fromthisTime.Hour && thisTime.Minute > fromthisTime.Minute) return true;
            if (thisTime.Hour == fromthisTime.Hour && thisTime.Minute == fromthisTime.Minute && thisTime.Second > fromthisTime.Second) return true;
            return false;
        }


        public MiMFa_Time GetLengthTime(MiMFa_Time toThisTime)
        {
            return GetLengthTime(this, toThisTime);
        }
        public static MiMFa_Time GetLengthTime(MiMFa_Time ofThisTime, MiMFa_Time toThisTime)
        {
            float Len = GetLengthSecond(ofThisTime, toThisTime);
            int h = (int)Len / 3600;
            int m = (int)(Len % 3600) / 60;
            int s = (int)(Len % 3600) % 60;
            MiMFa_Time time = new MiMFa_Time();
            time._Hour = h;
            time._Minute = m;
            time._Second = s;
            return time;
        }
        public float GetLengthHour(MiMFa_Time toThisTime)
        {
            return GetLengthHour(this, toThisTime);
        }
        public static float GetLengthHour(MiMFa_Time ofThisTime, MiMFa_Time toThisTime)
        {
            return GetLengthSecond(ofThisTime, toThisTime) / 3600;
        }
        public float GetLengthMinute(MiMFa_Time toThisTime)
        {
            return GetLengthMinute(this, toThisTime);
        }
        public static float GetLengthMinute(MiMFa_Time ofThisTime, MiMFa_Time toThisTime)
        {
            return GetLengthSecond(ofThisTime, toThisTime) / 60;
        }
        public float GetLengthSecond(MiMFa_Time toThisTime)
        {
            return GetLengthSecond(this, toThisTime);
        }
        public static float GetLengthSecond(MiMFa_Time ofThisTime, MiMFa_Time toThisTime)
        {
            int sec = 0;
            if (ofThisTime.Hour >= toThisTime.Hour && ofThisTime.Minute >= toThisTime.Minute && ofThisTime.Second >= toThisTime.Second)
                sec += (24 - (ofThisTime.Hour - toThisTime.Hour)) * 3600;
            else sec += ((toThisTime.Hour - ofThisTime.Hour) * 3600);
            sec += ((toThisTime.Minute - ofThisTime.Minute) * 60);
            sec += toThisTime.Second - ofThisTime.Second;

            return sec;
        }

        #endregion

        #region Private Region

        public int _Hour;
        public int _Minute;
        public int _Second;

        #endregion
    }
}
