using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;
using System.IO;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class SEARCH : CommandBase
    {
        public override string description => "Search and looking for anything in outputs";
        public override string aliasname => "find";
        public override string structure =>
                name
                + " "
                + "\"word\""
                + MCLTools.SignFinish;
        public override int structureindex => structure.Length -2;

        public SEARCH() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _casesensitive = false;
        public bool _highlight = false;
        public bool _showall = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool A
        {
            get { return _showall; }
            set
            {
                //if (_)  = value;
                //else
                _showall = value;
            }
        }
        public virtual bool C
        {
            get { return _casesensitive; }
            set
            {
                //if (_)  = value;
                //else
                _casesensitive = value;
            }
        }
        public virtual bool H
        {
            get { return _highlight; }
            set
            {
                //if (_)  = value;
                //else
                _highlight = value;
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            MCL.Display.CaseSensitiveSearch = _casesensitive;
            if (po != null)
                return MCL.Display.TrySearch(This,_showall|| _all,_highlight,po);
            return This;
        }
        #endregion
    }
}
