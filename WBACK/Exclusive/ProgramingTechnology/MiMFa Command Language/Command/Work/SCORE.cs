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
    public class SCORE : CommandBase
    {
        public override string description => "Computing score of all anything";
        public override string structure =>
            name
            + " "
            + "negativeValue "
            + MCLTools.SplitSign
            + "positiveValue "
            + MCLTools.SplitSign
            + "sensativity "
            + MCLTools.SplitSign
            + "noneValue "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public SCORE() : base()
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
                MiMFa_Percent percent = new MiMFa_Percent(0,0,0);
                percent.Negative = (po.Length > 0)? Convert.ToDecimal(po[0]):0;
                percent.Positive = (po.Length > 1)? Convert.ToDecimal(po[1]):0;
                decimal sens = (po.Length > 2)? Convert.ToDecimal(po[2]):100;
                percent.None = (po.Length > 3)? Convert.ToDecimal(po[3]):0;
                return execute(percent, sens);
            }
            return Null;
        }

        public MiMFa_Percent execute(MiMFa_Percent percent, decimal sensitivity)
        {
            percent.Positive += (((100 - sensitivity) / 100) * percent.Positive);
            percent.Normalization();
            return percent;
        }

        #endregion
    }
}
