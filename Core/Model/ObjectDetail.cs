using MiMFa_Framework.Exclusive.Collection.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_ObjectDetail : MiMFa_Instance 
    {
        public string AliasName { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
