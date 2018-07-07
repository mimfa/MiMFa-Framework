using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class IF : CommandBase
    {
        public override string description => "Execute command if is true conditions";
        public override string structure =>
            name
            + " "
            + MCLTools.StartSignParenthesis
            + nameof(TRUE)
            + MCLTools.EndSignParenthesis
            + " "
            + MCLTools.StartSignCollection
            + " "
            + MCLTools.EndSignCollection
            + MCLTools.SignFinish
            + (new ELSE()).structure;
        public override int structureindex =>structure.Length - 2;

        public IF() : base()
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD

        public static bool cnd = false;

        public override object EXECUTE(params object[] po)
        {
            string cmd = po[0].ToString().Trim();
            cmd = MCLTools.ParenthesisPU.Parse(cmd);
            string cond = MiMFa_StringService.GetFirstWordBetween(cmd, "(", ")", false);
            if (cond != null) cmd = MiMFa_StringService.FirstFindAndReplace(cmd, "(" + cond + ")", "");
            else cond = "";
            if (string.IsNullOrEmpty(cond.Trim())) throw new System.Exception("Not found any conditions");
            cnd = Convert.ToBoolean(MCL.Parser(cond));
            if (cnd)
                return echo(cmd);
            return Null;
        }

        public override object execute(object obj,int index, int length)
        {
            if (obj == null) return Null;
            return MCL.Parser(obj.ToString());
        }
        #endregion
    }
}
