using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class WHILE : CommandBase
    {
        public override string description => "Conditional loop";
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
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public WHILE() : base()
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
        public override object EXECUTE(params object[] po)
        {
            string cmd = po[0].ToString().Trim();
            cmd = MCLTools.ParenthesisPU.Parse(cmd);
            string condition = MiMFa_StringService.GetFirstWordBetween(cmd, "(", ")", false);
            if (condition != null) cmd = MiMFa_StringService.FirstFindAndReplace(cmd, "(" + condition + ")", "");
            else condition = "";
            if (string.IsNullOrEmpty(condition.Trim())) condition = "true";
            MiMFa_List<object> result = new MiMFa_List<object>();
            while (breakrun-- == 0 && Convert.ToBoolean(MCL.Parser(condition)) )
                result.Add(echo(cmd));
            return Normalization(result.ToArray());
        }

        public override object execute(object obj,int index, int length)
        {
            if (obj == null) return Null;
            return MCL.Parser(obj.ToString());
        }
        #endregion
    }
}
