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
    public class SET : CommandBase
    {
        public override string description => "objects, classes, functions and etc apply reusable";
        public override string structure =>
             name
             + " ObjectCode";
        public override int structureindex => structure.Length - 10;

        public SET() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _address = false;
        public bool _class = false;
        public bool _function = false;
        public bool _other = false;
        public bool _project = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool A
        {
            get { return _address; }
            set
            {
                //if (_)  = value;
                //else
                _address = value;
            }
        }
        public virtual bool C
        {
            get { return _class; }
            set
            {
                //if (_)  = value;
                //else
                _class = value;
            }
        }
        public virtual bool F
        {
            get { return _function; }
            set
            {
                //if (_)  = value;
                //else
                _function = value;
            }
        }
        public virtual bool O
        {
            get { return _other; }
            set
            {
                //if (_)  = value;
                //else
                _other = value;
            }
        }
        public virtual bool P
        {
            get { return _project; }
            set
            {
                //if (_)  = value;
                //else
                _project = value;
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
        public override bool IsSurface { get; set; } = true;
        public override bool IsApplication { get; set; } = false;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD

        public override object EXECUTE(params object[] po)
        {
            if (_print) return search(po);
            if (_delete) return delete(po);
            return echo(po);
        }
        public override object execute(object obj, int index, int length)
        {
            if (obj is Function)
            {
                Function f = (Function)obj;
                string path = MCL.Address.BaseFunctionDirectory + f.Name + "(" + f.Inputs.Length + ")" + MCL.Address.FunctionExtension;
                string content = f.Access.Status.ToString().ToLower() + " function " +  f.Name + "(" + MiMFa_CollectionService.GetAllItems(f.Inputs, ",") + ")" + Environment.NewLine + f.Commands + ";";
                MiMFa_IOService.StringToFullFile(path, content);
            }
            else
            {
                string path = MiMFa_Path.CreateValidPathName(MCL.Address.BaseOtherDirectory,"out", MCL.Address.BinaryExtension,false);
                MiMFa_IOService.SaveSerializeFile(path, obj);
            }
            return obj;
        }

        public virtual List<string> Function(params object[] po)
        {
            List<string> ls = MiMFa_Path.GetAllFiles(MCL.Address.BaseFunctionDirectory, true, MCL.Address.FunctionExtension);
            if (!_address) ls = MiMFa_CollectionService.ExecuteInAllItems(ls, (s) =>System.IO.Path.GetFileNameWithoutExtension(s));
            return ls;

        }
        public virtual List<string> Class(params object[] po)
        {
            List<string> ls = MiMFa_Path.GetAllFiles(MCL.Address.BaseClassDirectory, true, MCL.Address.ClassExtension);
            if (!_address) ls = MiMFa_CollectionService.ExecuteInAllItems(ls, (s) => System.IO.Path.GetFileNameWithoutExtension(s));
            return ls;
        } 
        public virtual List<string> Project(params object[] po)
        {
            List<string> ls = MiMFa_Path.GetAllFiles(MCL.Address.BaseProjectDirectory, true, MCL.Address.ProjectExtension);
            if (!_address) ls = MiMFa_CollectionService.ExecuteInAllItems(ls, (s) => System.IO.Path.GetFileNameWithoutExtension(s));
            return ls;
        }  
        public virtual List<string> Other(params object[] po)
        {
            List<string> ls = MiMFa_Path.GetAllFiles(MCL.Address.BaseOtherDirectory, true, MCL.Address.BinaryExtension);
            if (!_address) ls = MiMFa_CollectionService.ExecuteInAllItems(ls, (s) => System.IO.Path.GetFileNameWithoutExtension(s));
            return ls;
        }
        public virtual List<string> all(params object[] po)
        {
            List<string> ls = MiMFa_Path.GetAllFiles(MCL.Address.BaseDirectory, true);
            if (!_address) ls = MiMFa_CollectionService.ExecuteInAllItems(ls, (s) => System.IO.Path.GetFileNameWithoutExtension(s));
            return ls;
        } 

        public virtual List<string> search( params object[] po)
        {
            List<string> ls = new List<string>();
            if (_function) ls.AddRange(Function(po));
            if (_class) ls.AddRange(Class(po));
            if (_project) ls.AddRange(Project(po));
            if (_other) ls.AddRange(Other(po));
            if (_all) ls.AddRange(all(po));
            if (po != null && po.Length > 0)
                foreach (var item in po)
                    ls = (from v in ls where System.IO.Path.GetFileNameWithoutExtension(v).ToLower().Contains((item + "").ToLower()) select v).ToList();
            return ls;
        }

        public virtual List<string> delete( params object[] po)
        {
            _address = true;
            List<string> ls = search(po);
            MiMFa_Path.DeleteFiles(ls.ToArray());
            (new FUNCTION()).restart();
            return ls;
        }

        public static object get(string name)
        {
            return MiMFa_IOService.OpenDeserializeFile(MCL.Address.BaseOtherDirectory + name.ToLower() + MCL.Address.BinaryExtension);
        }
        #endregion
    }
}
