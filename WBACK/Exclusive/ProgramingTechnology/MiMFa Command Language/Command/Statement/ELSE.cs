using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class ELSE : CommandBase
    {
        public override string description => "Executed this commands if not true IF command";
        public override string structure =>
            name
            + " "
            + MCLTools.StartSignCollection
            + " "
            + MCLTools.EndSignCollection
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public ELSE() : base()
        {
            condition += (args) => !IF.cnd;
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
            string cmd = po[0].ToString().Trim();
            return echo(cmd);
        }

        public override object execute(object obj,int index, int length)
        {
            if (obj == null) return Null;
            return MCL.Parser(obj.ToString());
        }
        #endregion
    }
}
