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
    public class ROUND : CommandBase
    {
        public override string description => "Return round value";
        public override string structure =>
            name
            + " "
            + "The number of decimals "
            + MCLTools.SplitSign
            + "value "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public ROUND() : base()
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
            if (po != null && po.Length > 1)
                return echo(po);
            else return Null;
        }

        public int decimalsnumber = 0;
        public override object execute(object obj, int index, int length)
        {
            if (index == 0)
            {
                decimalsnumber = Convert.ToInt32(obj);
                return Null;
            }
            return Math.Round(Convert.ToDecimal(obj), decimalsnumber);
        }
        #endregion
    }
}
