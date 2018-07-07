using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Windows.Forms;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class CLOCK : CommandBase
    {
        public override string description => "Show clock app";
        public CLOCK() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _analog = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool A
        {
            get { return _analog; }
            set
            {
                //if (_) _args = value;
                //else
                    _analog = value;
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
        public override bool IsApplication { get; set; } = true;
        public override bool IsStatic { get; set; } = false;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public virtual string htmladdress => MCL.Address.AttachDirectory + nameof(CLOCK) + Address.HTMLExtension ;
        public virtual string htmladdressA => MCL.Address.AttachDirectory + nameof(CLOCK) + "A" + Address.HTMLExtension ;
        public override object EXECUTE(params object[] po)
        {
            if(_analog) return MiMFa_IOService.FileToString(htmladdressA);
            return MiMFa_IOService.FileToString(htmladdress);
        }
        #endregion
    }
}
