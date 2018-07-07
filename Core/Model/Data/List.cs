using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_List<T> : List<T>
    {
        public string SplitSign { get; set; } = "\t";

        public override string ToString()
        {
            return MiMFa_CollectionService.GetAllItems(this, SplitSign, 0);
        }

        public virtual T[] AddArray(params T[] array)
        {
            AddRange(array);
            return array;
        }
    }
}
