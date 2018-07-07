using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.IO;
using MiMFa_Framework.Model;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class REMEMBER : CommandBase
    {
        public override string description => "Save in or load from file your project";
        public override string aliasname => "rem";
        public override string structure =>
        name
        + " "
        + "\""
        + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "MyFile "+name + MCL.Address.WorkSpaceExtension
        + "\" "
        + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 10;

        public REMEMBER() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _functionslist = false;
        public bool _handlerslist = false;
        public bool _load = false;
        public bool _save = false;
        public bool _workspacelist = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool F
        {
            get { return _functionslist; }
            set
            {
                //if (_) _args = value;
                //else
                _functionslist = value;
            }
        }
        public virtual bool H
        {
            get { return _handlerslist; }
            set
            {
                //if (_) _args = value;
                //else
                _handlerslist = value;
            }
        }
        public virtual bool L
        {
            get { return _load; }
            set
            {
                //if (_) _args = value;
                //else
                _load = value;
            }
        }
        public virtual bool S
        {
            get { return _save; }
            set
            {
                //if (_) _args = value;
                //else
                _save = value;
            }
        }
        public virtual bool W
        {
            get { return _workspacelist; }
            set
            {
                //if (_) _args = value;
                //else
                _workspacelist = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string extention { get; set; } = MCL.Address.WorkSpaceExtension;
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
            if (po != null && po.Length > 0)
            {
                if (_save || s) save(po); 
                if (_load || l) load(po);
            }
            return Null;
        }

        public object save(params object[] po)
        {
                object[] obj = new object[3] { new List<object>(), new MiMFa_List<Variable>(), new MiMFa_List<Function>() };
            bool b = !_workspacelist && !_functionslist && !_handlerslist && !h && !f && !w;
                if (_handlerslist || h) obj[0] = MiMFa_CommandLanguage.HandlersList;
                if (b || _workspacelist || w) obj[1] = MiMFa_CommandLanguage.WorkSpaceList;
                if (b || _functionslist || f) obj[2] = MiMFa_CommandLanguage.FunctionsList;
                MiMFa_IOService.SaveSerializeFile(PATH.getpath(po[0] + extention), obj);
            return Null;
        }
        public object load(params object[] po)
        {
            object[] obj = null;
            MiMFa_IOService.OpenDeserializeFile<object[]>(PATH.getpath(po[0] + extention), ref obj);
            bool b = !_workspacelist && !_functionslist && !_handlerslist && !h && !f && !w;
            if (_handlerslist || h)
            {
                MiMFa_CommandLanguage.HandlersList.AddRange((List<object>)obj[0]);
                MiMFa_CommandLanguage.HandlersList = MiMFa_CollectionService.Distinct(MiMFa_CommandLanguage.HandlersList);
            }
            if (b || _workspacelist || w)
            {
                MiMFa_CommandLanguage.WorkSpaceList.AddRange((MiMFa_List<Variable>)obj[1]);
                MiMFa_CommandLanguage.WorkSpaceList = MiMFa_CollectionService.Distinct(MiMFa_CommandLanguage.WorkSpaceList);
            }
            if (b || _functionslist || f)
            {
                MiMFa_CommandLanguage.FunctionsList.AddRange((MiMFa_List<Function>)obj[2]);
                MiMFa_CommandLanguage.FunctionsList = MiMFa_CollectionService.Distinct(MiMFa_CommandLanguage.FunctionsList);
            }
            return Null;
        }
        #endregion
    }
}
