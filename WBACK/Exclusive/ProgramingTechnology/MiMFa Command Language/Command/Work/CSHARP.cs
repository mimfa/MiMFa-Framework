using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class CSHARP : CommandBase
    {
        public override string description => "Provider from c# codes";
        public override string aliasname => "c#";
        public CSHARP() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _executecode = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool E
        {
            get { return _executecode; }
            set {
                //if (_) _event = value;
                //else
                    _executecode = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        #endregion

        #region Environment Variable => PROPERTY (Any Type & get;)
        #endregion

        #region Allowances
        public override bool IsInternal { get; set; } = true;
        public override bool IsCommand { get; set; } = true;
        public override bool IsSurface { get; set; } = false;
        public override bool IsApplication { get; set; } = true;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = true;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = false;
        #endregion

        #region Function Switch => METHOD

        public override object EXECUTE(params object[] po)
        {
            if (po == null) throw new System.Exception("This command must be have inputs!");
            if (_executecode)
            {
                string code = po[0].ToString();
                string namespacename = "MRL";
                string classname = "Program";
                string functionname = "Main";
                bool isstatic = true;
                object[] args = null;
                try
                {
                    namespacename = po[1].ToString(); ;
                    classname = po[2].ToString(); ;
                    functionname = po[3].ToString();
                    isstatic = Convert.ToBoolean(po[4]);
                    args = MiMFa_CollectionService.GetPart(po, 5);
                }
                catch { }
                executecode(code, namespacename, classname, functionname, isstatic, args);
            }
            else
            {
                string code = po[0].ToString();
                string address = "out.exe";
                if (po.Length > 1) address = po[1].ToString().Trim();
                return provide(code, address);
            }

            return Null;
        }

        public override object execute(object obj, int index, int length)
        {
            if (obj == null) return Null;
            return obj;
        }

        public object provide(string code, string output = "out.exe")
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();

            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            //Make sure we generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, code);
            string result = "Compiler Errors :" + "" + Environment.NewLine;
            if (results.Errors.Count > 0)
            {
                if (_error)
                    foreach (CompilerError error in results.Errors)
                        result += string.Format("Line {0},{1}\t: {2}\n" + "" + Environment.NewLine, error.Line, error.Column, error.ErrorText);
            }
            else //Successful Compile
                result = "Success!";
            return result;
        }
        public object executecode(string code, string namespacename = "MRL", string classname = "Program", string functionname = "Main", bool isstatic = true, params object[] args)
        {
            object returnval = null;
            Assembly asm = buildassembly(code);
            object instance = null;
            Type type = null;
            if (isstatic)
            {
                type = asm.GetType(namespacename + "." + classname);
            }
            else
            {
                instance = asm.CreateInstance(namespacename + "." + classname);
                type = instance.GetType();
            }
            MethodInfo method = type.GetMethod(functionname);
            returnval = method.Invoke(instance, args);
            return returnval;
        }
        public Assembly buildassembly(string code)
        {
            Microsoft.CSharp.CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters compilerparams = new CompilerParameters();
            compilerparams.GenerateExecutable = false;
            compilerparams.GenerateInMemory = true;
            CompilerResults results = compiler.CompileAssemblyFromSource(compilerparams, code);
            if (results.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder("Compiler Errors :" + "" + Environment.NewLine);
                foreach (CompilerError error in results.Errors)
                {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n", error.Line, error.Column, error.ErrorText);
                }
                throw new System.Exception(errors.ToString());
            }
            else
            {
                return results.CompiledAssembly;
            }
        }
        #endregion
    }
}
