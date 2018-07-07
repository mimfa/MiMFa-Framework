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
    public class MOD : CommandBase
    {
        public override string description => "Logarithm calculations";
        public override string aliasname => "rem";
        public override string structure =>
            name
            + " "
            + "numerator "
            + MCLTools.SplitSign
            + "denumerator "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 7;

        public MOD() : base()
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
            if (po == null) return Null;
            if (po.Length == 1) return MiMFa_Convert.ForceToDouble(po[0]) % 2;
            if (po.Length == 2) return MiMFa_Convert.ForceToDouble(po[0])% MiMFa_Convert.ForceToDouble(po[1]);
            return MiMFa_Math.ModOfPowerElement(Convert.ToInt32(po[0]), Convert.ToInt32(po[1]), Convert.ToInt32(po[2]));
        }

        #endregion
    }
}
