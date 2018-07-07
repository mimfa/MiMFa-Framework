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
    public class CALCULATOR : CommandBase
    {
        public override string description => "Show calculator app";
        public override string aliasname => "calc";
        public CALCULATOR() : base()
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
        public virtual string htmladdress => MCL.Address.AttachDirectory + nameof(CALCULATOR) + Address.HTMLExtension ;
        public override object EXECUTE(params object[] po)
        {
            return MiMFa_IOService.FileToString(htmladdress);
        }
        #endregion
    }
}
