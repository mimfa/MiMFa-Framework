using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class DICTIONARY : CommandBase
    {
        public override string description => "Create a dictionary from datas";
        public override string structure =>
            name
            + " "
            + "v1 -> value1 "
            + MCLTools.SignFinish;
        public override int structureindex => 2;

        public DICTIONARY() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _sorted = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool S
        {
            get { return _sorted; }
            set
            {
                //if (_)  = value;
                //else
                _sorted = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        #endregion

        #region Environment Variable => PROPERTY (Any Type & get;)

        #endregion

        #region Allowances
        public override bool IsInternal { get; set; } = true;
        public override bool IsCommand { get; set; } = true;
        public override bool IsSurface { get; set; } = false;
        public override bool IsApplication { get; set; } = false;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            MiMFa_Dictionary<object, object> lo = new MiMFa_Dictionary<object, object>();
            if (po != null)
            {
                for (int i = 0; i < po.Length; i++)
                {
                    KeyValuePair<object, object> kvp = MiMFa_Convert.ToKeyValuePair(po[i]);
                    lo.Add(kvp.Key, kvp.Value);
                }
                if (_sorted) lo = MiMFa_CollectionService.Sort(lo);
            }
            return lo;
        }

        #endregion
    }
}
