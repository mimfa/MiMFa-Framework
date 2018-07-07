using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using MiMFa_Framework.Model;
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools;
using System.Data;
using System.ComponentModel;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class FOREACH : CommandBase
    {
        public override string description => "Work in loop";
        public override string aliasname => "each";
        public override string structure =>
            name
            + " "
            + MCLTools.StartSignParenthesis
            + nameof(VARIABLE)
            + " item "
            + MCLTools.SplitSign
            + " collection"
            + MCLTools.EndSignParenthesis
            + " "
            + MCLTools.StartSignCollection
            + " "
            + MCLTools.EndSignCollection
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public FOREACH() : base()
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
            if (string.IsNullOrEmpty(definition.Trim())) throw new System.Exception("Not found any definitions");
            string[] elements = definition.Split(',');
            elements = MiMFa_CollectionService.ExecuteInAllItems(elements, (s) => s.Trim());
            if (elements.Length < 2) throw new System.Exception("Definition is not right");
            string def = elements[0];
            object eno = MCL.Execute(elements[1]);

            return Normalization(each(def, eno, cmd).ToArray());
        }

        public virtual MiMFa_List<object> each(string def, dynamic collection,string cmd)
        {
            MiMFa_List<object> result = new MiMFa_List<object>();
            MCL.PushAccess();
            MCL.Parse(def);
            string name = def.Trim().Split(' ').Last().Trim();
            foreach (var item in collection)
            {
                if (breakrun-- != 0) break;
                MCL.SetVar(name, item);
                object str = echo(cmd);
                curr = str;
                result.Add(str);
            }
            MCL.PopRemoveAccess();
            return result;
        }

        public override object execute(object obj, int index, int length)
        {
            if (obj == null) return Null;
            return MCL.Parser(obj.ToString());
        }
        #endregion
    }
}
