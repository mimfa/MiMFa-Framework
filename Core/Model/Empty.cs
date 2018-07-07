using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_Empty<T>
    {
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
