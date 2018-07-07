using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Model;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class EVER : CommandBase
    {
        public override string description => "Something that should always be present";
        public override string aliasname => "constructor";
        public override string structure =>
             name
             + MCLTools.StartSignCollection
             + " "
             + MCLTools.EndSignCollection
             + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 2;

        public EVER() : base()
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
            if (_print) return MiMFa_IOService.FileToString(MCL.Address.Constructor);
            else if (_delete && _all) MiMFa_IOService.ClearFileContent(MCL.Address.Constructor);
            else if (po != null && po.Length > 0)
            {
                string cmd = MCL.CrudeText(Normalization(po[0].ToString()).Replace("  ", " ")) + ";";
                if (_delete)
                    MiMFa_IOService.StringRemoveFromFile(MCL.Address.Constructor, cmd + ";");
                else
                {
                    MiMFa_IOService.StringNewLineAppendFile(MCL.Address.Constructor, cmd);
                    MCL.Parse(cmd);
                }
            }
            return Null;
        }

        #endregion
    }
}
