using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_Queue<T> : Queue<T>
    {
        public string SplitSign { get; set; } = Environment.NewLine;

        public override string ToString()
        {
            return MiMFa_CollectionService.GetAllItems(this.ToArray(), SplitSign,0);
        }
    }
}
