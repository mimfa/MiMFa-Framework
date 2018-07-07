using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using MiMFa_Framework.Exclusive.Collection.Instance;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Configuration;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public struct MiMFa_Percent
    {
        public decimal Positive { get;  set; }
        public decimal None { get;  set; }
        public decimal Negative { get; set; }
        public decimal Both => Positive + None + Negative;
        public MiMFa_Score FinalScore { get; set; }

        public MiMFa_Percent(decimal negative = 0, decimal none = 0, decimal positive = 0, MiMFa_Score finalScore = MiMFa_Score.Positive)
        {
            Positive = positive;
            None = none;
            Negative = negative;
            FinalScore = finalScore;
        }
        public MiMFa_Percent(MiMFa_Percent mp)
        {
            Positive = mp.Positive;
            None = mp.None;
            Negative = mp.Negative;
            FinalScore = mp.FinalScore;
        }

        private static int ll  = 0;
        public MiMFa_Percent Normalization()
        {
            if (None < -100) None = -100;
            if (None > 100) None = 100;
            if (Negative > 0)
                Negative = 0;
            if (Positive < 0)
                Positive = 0;
            if (Positive > 100)
            {
                Negative += (Positive - 100);
                Positive = 100;
            }
            if (Negative < -100)
            {
                Positive += (Negative +100);
                Negative = -100;
            }
            if (Positive - Negative > 100)
            {
                decimal d = (Positive - Negative) - 100;
                Positive -= d / 2;
                Negative += d / 2;
            }
            else if (Negative - Positive  < -100)
            {
                decimal d = (Negative - Positive) + 100;
                Positive += d / 2;
                Negative -= d / 2;
            }
            var sa = (Math.Abs(Negative) + Math.Abs(Positive));
            if ((sa > 101 || sa < 99) && ll++ < 10) return this.Normalization();
            else ll = 0;
            return this;
        }
        public MiMFa_Percent AddValue(decimal dec, bool isNone = false)
        {
            if (isNone) None += dec;
            else if (dec > 0) Positive += dec;
            else if (dec < 0) Negative += dec;
            return this;
        }
        public MiMFa_Percent AddValue(MiMFa_Percent percent)
        {
            None += percent.None;
           Positive += percent.Positive;
         Negative += percent.Negative;
            return this;
        }
        public MiMFa_Percent RemoveValue(decimal dec, bool isNone = false)
        {
            if (isNone) None -= dec;
            else if (dec > 0) Positive -= dec;
            else if (dec < 0) Negative -= dec;
            return this;
        }
        public MiMFa_Percent RemoveValue(MiMFa_Percent percent)
        {
            None -= percent.None;
            Positive -= percent.Positive;
            Negative -= percent.Negative;
            return this;
        }
        public MiMFa_Percent SetValue(decimal dec, bool isNone = false)
        {
            if (isNone) None = dec;
            else if (dec > 0) Positive = dec;
            else if (dec < 0) Negative = dec;
            return this;
        }
        public MiMFa_Percent SetValue(MiMFa_Percent percent)
        {
            None = percent.None;
            Positive = percent.Positive;
            Negative = percent.Negative;
            return this;
        }
        public decimal GetValue()
        {
            return GetValue(this);
        }

        public static decimal GetValue(MiMFa_Percent th)
        {
            switch (th.FinalScore)
            {
                case MiMFa_Score.Null:
                    return th.None;
                case MiMFa_Score.Positive:
                    return th.Positive;
                case MiMFa_Score.Negative:
                    return th.Negative;
                case MiMFa_Score.Both:
                    return th.Positive + th.Negative + th.None;
                default:
                    return th.Positive;
            }
        }
        public static MiMFa_Percent Max(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            if(op1 > op2)  return op1;
            return op2;
        }
        public static MiMFa_Percent Min(MiMFa_Percent op1 , MiMFa_Percent op2)
        {
            if (op1 < op2) return op1;
            return op2;
        }

        public static implicit operator decimal(MiMFa_Percent op1)
        {
           return (GetValue(op1));
        }
        public static explicit operator MiMFa_Percent(decimal op1)
        {
            return (new MiMFa_Percent(0, 0, 0)).AddValue(op1, false);
        }
        public static implicit operator double(MiMFa_Percent op1)
        {
            return Convert.ToDouble( GetValue(op1));
        }
        public static explicit operator MiMFa_Percent(double op1)
        {
            return (new MiMFa_Percent(0, 0, 0)).AddValue(Convert.ToDecimal(op1), false);
        }
        public static implicit operator float(MiMFa_Percent op1)
        {
            return Convert.ToSingle(GetValue(op1));
        }
        public static explicit operator MiMFa_Percent(float op1)
        {
            return (new MiMFa_Percent(0, 0, 0)).AddValue(Convert.ToDecimal(op1), false);
        }
        public static implicit operator int(MiMFa_Percent op1)
        {
            return Convert.ToInt32(GetValue(op1));
        }
        public static explicit operator MiMFa_Percent(int op1)
        {
            return (new MiMFa_Percent(0, 0, 0)).AddValue(Convert.ToDecimal(op1), false);
        }
        public static implicit operator Color(MiMFa_Percent op1)
        {
            decimal d = GetValue(op1);
            if (d > 0) return Color.Honeydew;
            if (d < 0) return Color.MistyRose;
            return Color.Ivory;
        }
        public static bool operator ==(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            return op1.Both == op2.Both;
        }
        public static bool operator !=(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            return op1.Both != op2.Both;
        }
        public static bool operator >=(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            return op1.Both >= op2.Both;
        }
        public static bool operator <=(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            return op1.Both <= op2.Both;
        }
        public static bool operator >(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            return op1.Both > op2.Both;
        }
        public static bool operator <(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            return op1.Both < op2.Both;
        }
        public static MiMFa_Percent operator +(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            var op = new MiMFa_Percent(0,0,0);
            op.AddValue(op1.Negative);
            op.AddValue(op1.Positive);
            op.AddValue(op1.None, true);
            op.AddValue(op2.Negative);
            op.AddValue(op2.Positive);
            op.AddValue(op2.None, true);
            return op;
        }
        public static MiMFa_Percent operator -(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.AddValue(op1.Negative);
            op.AddValue(op1.Positive);
            op.AddValue(op1.None, true);
            op.AddValue(-op2.Negative);
            op.AddValue(-op2.Positive);
            op.AddValue(-op2.None, true);
            return op;
        }
        public static MiMFa_Percent operator /(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.SetValue(op1.Negative/op2.Negative);
            op.SetValue(op1.Positive/op2.Positive);
            op.SetValue(op1.None / op2.None,true);
            return op;
        }
        public static MiMFa_Percent operator *(MiMFa_Percent op1, MiMFa_Percent op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.SetValue(op1.Negative * op2.Negative);
            op.SetValue(op1.Positive * op2.Positive);
            op.SetValue(op1.None * op2.None, true);
            return op;
        }
        public static MiMFa_Percent operator +(MiMFa_Percent op1, decimal op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.AddValue(op1.Negative);
            op.AddValue(op1.Positive);
            op.AddValue(op1.None, true);
            op.AddValue(op2);
            op.AddValue(op2);
            op.AddValue(op2, true);
            return op;
        }
        public static MiMFa_Percent operator -(MiMFa_Percent op1, decimal op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.AddValue(op1.Negative);
            op.AddValue(op1.Positive);
            op.AddValue(op1.None, true);
            op.AddValue(-op2);
            op.AddValue(-op2);
            op.AddValue(-op2, true);
            return op;
        }
        public static MiMFa_Percent operator /(MiMFa_Percent op1, decimal op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.SetValue(op1.Negative / op2);
            op.SetValue(op1.Positive / op2);
            op.SetValue(op1.None / op2, true);
            return op;
        }
        public static MiMFa_Percent operator *(MiMFa_Percent op1, decimal op2)
        {
            var op = new MiMFa_Percent(0, 0, 0);
            op.SetValue(op1.Negative * op2);
            op.SetValue(op1.Positive * op2);
            op.SetValue(op1.None* op2, true);
            return op;
        }

        public override string ToString()
        {
            string str = "";
            str += "Negative: " + Negative;
            str += " , None: " + None;
            str += " , Positive: " + Positive;
            return str;
        }
    }
}
