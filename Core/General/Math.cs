using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiMFa_Framework.General
{
    public class MiMFa_Math
    {
        public static int Fibonacci(int x)
        {
            if (x <= 1)
                return x;
            return Fibonacci(x - 1) + Fibonacci(x - 2);
        }
        public static bool IsEven(int x)
        {
            return (x % 2 == 0);
        }
        public static bool IsOdd(int x)
        {
            return (x % 2 > 0);
        }
        public static int ModOfPowerElement(int a, int b, int n)
        {
            int c = 0;
            int d = 1;
            int k = 31;
            while ((b >> k & 1) == 0) k--;
            for (int i = k; i >= 0; i--)
            {
                c = 2 * c;
                d = (d * d) % n;
                if ((b >> i & 1) == 1)
                {
                    c = c + 1;
                    d = (d * a) % n;
                }
            }
            return d;
        }
    }
}
