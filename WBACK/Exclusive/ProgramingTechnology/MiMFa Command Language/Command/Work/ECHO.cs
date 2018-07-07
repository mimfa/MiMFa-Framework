using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using System.Collections;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class ECHO : CommandBase
    {
        public override string description => "Return and show command result and strings";
        public ECHO() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _concatwords = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool C
        {
            get { return _concatwords; }
            set
            {
                //if (_)  = value;
                //else
                _concatwords = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string separatetext { get; set; } = " ";
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
           object obj = echo(po);
            try
            {
                string rpt = obj.GetType().Name.ToLower();
                if (rpt.EndsWith("[]")) obj = print(MiMFa_Convert.ToArray(obj));
                else if (obj is IList) obj = print(MiMFa_Convert.ToList(obj).ToArray());
                else if (obj is IDictionary) obj = print(MiMFa_Convert.ToDictionary(obj));
                else if (rpt.EndsWith("collection"))
                    obj = print(MiMFa_Convert.ToArray(obj).ToArray());
                else obj = print(obj);
            }
            catch { obj = print(obj); }
            return obj;
        }

        public override object execute(object obj,int index, int length)
        {
            if (obj == null) return Null;
            if (!_concatwords && index < length -1)
                return MCL.Display.Done(obj) + separatetext;
            return MCL.Display.Done(obj);
        }
        #endregion
    }
}
