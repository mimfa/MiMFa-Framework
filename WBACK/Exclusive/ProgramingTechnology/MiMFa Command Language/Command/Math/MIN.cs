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
    public class MIN : CommandBase
    {
        public override string description => "Return minimum value";
        public override string structure =>
            name
            + " "
            + "value1 "
            + MCLTools.SplitSign
            + "value2 "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public MIN() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD

        public override object EXECUTE(params object[] po)
        {
            if (po != null && po.Length > 0)
            {
                Double min = MiMFa_Convert.ForceToDouble(po[0]);
                for (int i = 1; i < po.Length; i++)
                    min = Math.Min(min, MiMFa_Convert.ForceToDouble(po[i]));
                return min;
            }
            return Null;
        }
       
        #endregion
    }
}
