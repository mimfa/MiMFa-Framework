using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiMFa_Framework.Exclusive.Security;

namespace MiMFa_Framework.General
{
    public class MiMFa_UnicCode
    {
        public static string CreateNewString(int length)
        {
            MiMFa_Cryptography cr = new MiMFa_Cryptography();
            string s = (DateTime.Now.Ticks.ToString() + DateTime.Now.Millisecond)
                .Replace("10", "a")
                .Replace("11", "b")
                .Replace("12", "c")
                .Replace("13", "d")
                .Replace("14", "e")
                .Replace("15", "f");
            return (s+s+s+s).Substring((4*s.Length-1)-length);
        }
        public static double CreateNewInciment()
        {
            Random r = new Random();
            return Convert.ToDouble(DateTime.Now.Ticks.ToString().Substring(12) + DateTime.Now.Millisecond + "" + r.Next(1111, 9999));
        }
        public static long CreateNewLong()
        {
            Random r = new Random();
            string s = DateTime.Now.Ticks.ToString().Substring(8) + DateTime.Now.Millisecond;
            s = s.Substring(s.Length - 4) + r.Next(1111, 9999);
            return Convert.ToInt32(s);
        }
        public static int CreateRandomInteger(int seed=2,int min = 11,int max = 99)
        {
            Random r = new Random(seed);
            return r.Next(min,max);
        }
    }
}
