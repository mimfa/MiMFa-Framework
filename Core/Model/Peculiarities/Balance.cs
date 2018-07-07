using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model.Peculiarities
{
    [Serializable]
    public struct MiMFa_Balance
    {
        int Right;
        int Left;
        int Top;
        int Bottom;
        int Front;
        int Back;

        public MiMFa_Balance(int right=0, int left = 0, int top = 0, int bottom = 0, int front = 0, int back = 0)
        {
            Right = right;
            Left = left;
            Top = top;
            Bottom = bottom;
            Front = front;
            Back = back;
        }
    }
}
