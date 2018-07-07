using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using System.Diagnostics;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class HERE : CommandBase
    {
        public override string description => "Get current directory";
        public override string aliasname => "cd";
        public HERE() : base()
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
        public override bool IsCommand { get; set; } = false;
        public override bool IsSurface { get; set; } = false;
        public override bool IsApplication { get; set; } = false;
        public override bool IsStatic { get; set; } = true;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public static string current { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        public override object EXECUTE(params object[] po)
        {
            if (po != null && po.Length > 0)return echo(po);
            return current;
        }
        public override object execute(object obj,int index, int length)
        {
            return PATH.setpath(PATH.getpath(obj+""));
        }
        public override void restart()
        {
            base.restart();
            current = AppDomain.CurrentDomain.BaseDirectory;
        }

        #endregion
    }
}
