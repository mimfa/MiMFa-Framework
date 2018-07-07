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
    public class FOR : CommandBase
    {
        public override string description => "Work with loop";
        public override string aliasname => "loop";
        public override string structure =>
            name 
            + " "
            + MCLTools.StartSignParenthesis
            + nameof(VARIABLE) 
            + " i = 0 "
            + MCLTools.SplitSign
            + " i < Lenght "
            + MCLTools.SplitSign
            + " i = i + 1"
            + MCLTools.EndSignParenthesis
            + " "
            + MCLTools.StartSignCollection
            + " "
            + MCLTools.EndSignCollection
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public FOR() : base()
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
            string definition = MiMFa_StringService.GetFirstWordBetween(cmd, "(", ")", false);
            if (definition != null) cmd = MiMFa_StringService.FirstFindAndReplace(cmd, "(" + definition + ")", "");
            else definition = "";
            if (string.IsNullOrEmpty(definition.Trim())) definition = "";
            string[] elements = definition.Split(',');
            elements = MiMFa_CollectionService.ExecuteInAllItems(elements, (s) => s.Trim());
            string def = (elements.Length == 3) ? elements[0] : "";
            string condition = (elements.Length == 3 && !string.IsNullOrEmpty(elements[1])) ? elements[1] : "true";
            string after = (elements.Length == 3) ? elements[2] : "";

            MCL.PushAccess();
            MCL.Parse(def);
            MiMFa_List<object> result = new MiMFa_List<object>();
            for (; breakrun-- == 0 && Convert.ToBoolean(MCL.Parser(condition)); MCL.Parse(after))
                result.Add(echo(cmd));
            MCL.PopRemoveAccess();
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
