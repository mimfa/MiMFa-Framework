using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools;
using MiMFa_Framework.Configuration;
using System.IO;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class FUNCTION : CommandBase
    {
        public override string description => "Create function of commands";
        public override string aliasname => "func";
        public override string structure =>
            name
            + " func "
            + MCLTools.StartSignParenthesis
            + nameof(VARIABLE)
            + " arg"
            + MCLTools.EndSignParenthesis
            + " "
            + MCLTools.StartSignCollection
            + " "
            + MCLTools.EndSignCollection
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public FUNCTION() : base()
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
            if (po != null && po.Length >0)
            {
                string name = po[0].ToString();
                name = MCLTools.ParenthesisPU.Parse(name);
                string[] stra = MiMFa_StringService.FirstFindAndSplit(name, MCLTools.StartSignParenthesis);
                Function fu = new Function();
                fu.Name = stra[0];
                fu.Access = MCL.EnvironmentAccess;
                stra = MiMFa_StringService.FirstFindAndSplit(stra[1], MCLTools.EndSignParenthesis);
                fu.Inputs = MiMFa_CollectionService.ExecuteInAllItems(stra[0].Split(MCLTools.SplitSign),(os)=>MCL.CrudeText(os).Trim());
                if (fu.Inputs.Length == 1 && string.IsNullOrEmpty(fu.Inputs[0])) fu.Inputs = new string[] { };
                fu.Commands = MCL.CrudeText(stra[1]).Trim();
                MiMFa_CommandLanguage.FunctionsList.Add(fu);
                return fu;
            }
            return Null;
        }
        public static dynamic INVOKE(Function func, params object[] inputs)
        {
            if (!Accessibility.IsAccess(MCL.EnvironmentAccess, func.Access)) throw new MethodAccessException("You not access to this function");
            if (inputs == null) inputs = new object[0];
            string nam = nameof(VARIABLE).ToLower();
            int length = Math.Min(func.Inputs.Length, inputs.Length);
            for (int i = 0; i < func.Inputs.Length; i++)
                if (func.Inputs[i].ToLower().StartsWith(nam))
                {
                    MCL.Parse(func.Inputs[i]);
                    if (inputs.Length > i)
                        MCL.SetVar(func.Inputs[i].Substring(nam.Length).Split('=')[0].Trim(), inputs[i]);
                }
                else MCL.AddVar(func.Inputs[i], (inputs.Length > i) ? inputs[i] : Null);
            return MCL.Parser(func.Commands);
        }
        public static Function search(string name, int inputsnum = -1)
        {
            name = name.ToLower();
            try
            {
                Function f = MiMFa_CommandLanguage.FunctionsList.Find((v) => v.Name.ToLower() == name && v.Inputs.Length == inputsnum);
                if (f != null) return f;
            }
            catch { }
            if (inputsnum > -1)
                try
                {
                    name = name + "(" + inputsnum + ")";
                    string pat = MCL.Address.BaseFunctionDirectory + name + MCL.Address.FunctionExtension;
                    if(File.Exists(pat)) return (Function)MCL.Parser(MiMFa_IOService.FileToString(pat));
                }
                catch { }
            else
                try
                {
                    string pat = (from v in General.MiMFa_Path.GetAllFiles(MCL.Address.BaseFunctionDirectory) where System.IO.Path.GetFileNameWithoutExtension(v).Split('(').First().ToLower() == name select v).First();
                    if (File.Exists(pat)) return (Function)MCL.Parser(MiMFa_IOService.FileToString(pat));
                }
                catch { }
            return null;
        }
        #endregion
    }
}
