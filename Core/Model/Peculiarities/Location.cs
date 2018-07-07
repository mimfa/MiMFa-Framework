using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model.Peculiarities
{
    [Serializable]
    public struct MiMFa_Location
    {
        int X;
        int Y;
        int Z;

        public MiMFa_Location(int x = 0, int y = 0, int z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
