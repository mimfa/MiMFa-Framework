using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.Collection.Instance
{
    [Serializable]
    public class MiMFa_Instance
    {
        public static double _ID { get; set; } = 1;
        private string _UID = MiMFa_Framework.General.MiMFa_UnicCode.CreateNewString(15);
        public virtual string UID
        {
            get
            {
                if (string.IsNullOrEmpty(_UID))
                    _UID = ID.ToString();
                return _UID;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _UID = ID.ToString();
                else _UID = value;
            }
        }
        public virtual double ID { get; set;}
        public virtual string Name { get; set; }
        public virtual string Detail { get; set; }
        public virtual object Extra { get; set; }

        public virtual double GetID() => _ID;
        public virtual void SetID(double id) => _ID = id;

        public MiMFa_Instance(bool incrementID = true)
        {
            if (incrementID) ID = _ID++;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
