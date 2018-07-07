using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class VARIABLE : CommandBase
    {
        public override string description => "Variable definition";
        public override string aliasname => "var";
        public VARIABLE() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool nonewcreate = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public override bool d
        {
            get
            {
                return base.d;
            }

            set
            {
                _crudeinput = true;
                base.d = value;
            }
        }
        public virtual bool N
        {
            get { return nonewcreate; }
            set
            {
                //if (_)  = value;
                //else
                nonewcreate = value;
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
            if (_all && _print) return printall(po);
            else if (_all && _delete) return deleteall(po);
            else if (_delete) return delete(po);
            else {
                string s = po[0].ToString();
                MiMFa_CommandLanguage.CommandType type = MCL.TypeDetector(ref s, null).Key;
                bool allow =
                    type != MiMFa_CommandLanguage.CommandType.Evaluatable
                    && type != MiMFa_CommandLanguage.CommandType.Property
                    && type != MiMFa_CommandLanguage.CommandType.Collection
                    && type != MiMFa_CommandLanguage.CommandType.Command
                    && type != MiMFa_CommandLanguage.CommandType.Comparable
                    && type != MiMFa_CommandLanguage.CommandType.String
                    && !MCL.IsSwitch(s)
                    && !MCL.IsSSwitch(s)
                    && type != MiMFa_CommandLanguage.CommandType.Function
                    && type != MiMFa_CommandLanguage.CommandType.MultiSlice
                    && !nonewcreate;
                if (_force
                    || (!s.Contains("=")
                    && !s.Contains(",") && allow))
                {
                    MCL.AddVar(s, Null);
                    return Null;
                }
                if ((s.Contains("=")
                    || s.Contains(",")) && allow)
                {
                    string[] stra = s.Split(',');
                    _null = !_print;
                    return echo(stra);
                }
                else throw new System.Exception("This name is not valid for variable");
            }
        }

        public override object execute(object obj, int index, int length)
        {
            if (obj == null) return Null;
            string[] cas = obj.ToString().Split('=');
            if (cas.Length > 1) curr = MCL.Parser(cas.Last());
            else curr = Null;
            for (int i = 0; i < cas.Length - 1; i++)
                MCL.AddVar(cas[i].Trim(), curr);
            return curr;
        }

        public virtual object printall(params object[] po)
        {
            return print(MiMFa_CommandLanguage.WorkSpaceList);
        }
        public override string print()
        {
            if (MiMFa_CommandLanguage.WorkSpaceList.Count > 0)
                return print(MiMFa_CommandLanguage.WorkSpaceList);
            return null;
        }
        public virtual object deleteall(params object[] po)
        {
            MiMFa_CommandLanguage.WorkSpaceList.Clear();
            return null;
        }
        public virtual object delete(params object[] po)
        {
            foreach (var item in po)
               MCL.RemoveVar(item.ToString());
            return null;
        }
        #endregion
    }
}
