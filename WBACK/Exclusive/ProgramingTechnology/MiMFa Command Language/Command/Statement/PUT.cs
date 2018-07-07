using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Windows.Forms;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class PUT : CommandBase
    {
        public override string description => "Put a a;ias name for commands or anything";
        public PUT() : base()
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
        public override bool IsSurface { get; set; } = true;
        public override bool IsApplication { get; set; } = false;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = false;
        public override bool IsSSwichable { get; set; } = false;
        public override bool IsCrudeInput { get; set; } = true;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            string[] sa = MiMFa_StringService.FirstFindAndSplit(MCL.CrudeText(po[0].ToString()).Trim(), MCLTools.SignPointer);

            string expr = sa.First().Trim().ToLower();
            expr = MCL.DownLayer(expr);
            expr = expr.Replace(MiMFa_CommandLanguage.StartSignStrongString, "").Replace(MiMFa_CommandLanguage.EndSignStrongString, "")
                .Replace(MiMFa_CommandLanguage.StartSignString, "").Replace(MiMFa_CommandLanguage.EndSignString, "");
            string un = MCL.CrudeText(expr);

            expr = sa.Last().Trim().ToLower();
            expr = MCL.DownLayer(expr);
            expr = expr.Replace(MiMFa_CommandLanguage.StartSignStrongString, "").Replace(MiMFa_CommandLanguage.EndSignStrongString, "")
                .Replace(MiMFa_CommandLanguage.StartSignString, "").Replace(MiMFa_CommandLanguage.EndSignString, "");
            string cmd = MCL.CrudeText(expr);

            MCL.PutsDic.AddOrSet(un, cmd);
            return Null;
        }
        public override object execute(object obj,int index, int length)
        {
            return Null;
        }
        #endregion
    }
}
