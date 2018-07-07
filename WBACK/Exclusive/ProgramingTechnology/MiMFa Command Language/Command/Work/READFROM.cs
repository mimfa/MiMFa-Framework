using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class READFROM : CommandBase
    {
        public override string description => "Open file";
        public override string aliasname => "read";
        public override string structure =>
            name
            + " "
            + " \"address\" "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public READFROM() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _block = false;
        public bool _concatwords = false;
        public bool _line = false;
        public bool _serialize = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool B
        {
            get { return _block; }
            set
            {
                //if (_)  = value;
                //else
                _block = value;
            }
        }
        public virtual bool C
        {
            get { return _concatwords; }
            set
            {
                //if (_)  = value;
                //else
                _concatwords = value;
            }
        }
        public virtual bool L
        {
            get { return _line; }
            set
            {
                //if (_)  = value;
                //else
                _line = value;
            }
        }
        public virtual bool S
        {
            get { return _serialize; }
            set
            {
                //if (_)  = value;
                //else
                _serialize = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string SeparateText { get; set; } = " ";
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
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            if (po == null || po.Length < 0) return Null;
            if (_line && po.Length > 1) return line(po);
            if (_block && po.Length > 2) return block(po);
            return echo(po);
        }

        public override object execute(object obj,int index, int length)
        {
            if (obj == null) return Null;
            string str = "";
            if (_serialize) return MiMFa_IOService.OpenDeserializeFile(PATH.getpath(obj.ToString()));
            else if (_longview || _humanreadable) return MiMFa_IOService.FileToStringArray(PATH.getpath(obj.ToString()));
            else str = MiMFa_IOService.FileToTrimedString(PATH.getpath(obj.ToString()));
            if (!_concatwords && index < length -1) return str + SeparateText;
            return str;
        }
        public virtual object line(params object[] po)
        {
            object obj = po[0];
            if (obj == null) return Null;
            string str = "";
            List<int> li = new List<int>();
            for (int i = 1; i < po.Length; i++)
                try { li.Add(Convert.ToInt32(PATH.getpath(po[i].ToString()))); } catch { }
            if (l || h) str = MiMFa_IOService.FileToString(PATH.getpath(obj.ToString()),li.ToArray());
            else str = MiMFa_IOService.FileToTrimedString(PATH.getpath(obj.ToString()), li.ToArray());
            if (!_concatwords) return str + SeparateText;
            return str;
        }
        public virtual object block(params object[] po)
        {
            object obj = po[0];
            if (obj == null) return Null;
            string str = "";
            int index = Convert.ToInt32(po[1]);
            int count = Convert.ToInt32(po[2]);
            if (l || h) str = MiMFa_IOService.FileToString(PATH.getpath((obj.ToString())), index,count);
            else str = MiMFa_IOService.FileToTrimedString(PATH.getpath(obj.ToString()), index, count);
            if (!_concatwords) return str + SeparateText;
            return str;
        }
        #endregion
    }
}
