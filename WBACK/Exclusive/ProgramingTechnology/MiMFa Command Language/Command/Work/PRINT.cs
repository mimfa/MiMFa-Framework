using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class PRINT : CommandBase
    {
        public override string description => "Print crude text";
        public PRINT() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _concatwords = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
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
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string separatetext { get; set; } = " ";
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
            if (po == null||po.Length == 0) return Null;
            string str = po[0].ToString();
            str = MCL.CrudeText(str);
            return print(str.Split(','));
        }
        #endregion
    }
}
