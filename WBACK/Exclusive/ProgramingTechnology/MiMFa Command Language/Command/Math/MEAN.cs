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
    public class MEAN : CommandBase
    {
        public override string description => "Return mean of values";
        public override string structure =>
            name
            + " "
            + "value1 "
            + MCLTools.SplitSign
            + "value2 "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public MEAN() : base()
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
                List<double> ld = new List<double>();
                for (int i = 0; i < po.Length; i++)
                    ld.Add(MiMFa_Convert.ForceToDouble(po[i]));
                int dn = ld.Count / 2;
                if (ld.Count % 2 == 0) return ld.GetRange(dn-1, 2);
                return ld.GetRange(dn,1).First();
            }
            return Null;
        }
       
        #endregion
    }
}
