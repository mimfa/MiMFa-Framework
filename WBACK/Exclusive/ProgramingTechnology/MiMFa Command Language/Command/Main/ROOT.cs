using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class ROOT : CommandBase
    {
        public override string description => "Basical command";
        public override string aliasname => "done";
        public ROOT() : base()
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
        public override bool IsCrudeInput { get; set; } = true;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            if (po == null) return Null;
            if (po.Length == 0) return Null;
            //string MCLCode = po[0].ToString();
            //if (MCLCode == null) return null;
            //if ( MCL.IsSimplyTextOrAddress(MCLCode)) return MCLCode;
            //MCL.InResult = MCL.Translator(MCLCode.Trim(), (po.Length == 2) ? po[1] : null);
            //if (MCL.ISCrudeText(MCL.InResult)) MCL.InResult = main(MCL.InResult.ToString(), null);
            //return MCL.InResult;
            return echo(po);
        }
        
        #endregion
    }
}
