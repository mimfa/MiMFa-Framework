using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.IO;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class MCL : CommandBase
    {
        public override string description => "Working directly with MCL commands";
        public override string structure =>
        name
        + " "
        + "\""
        + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "MyFile "+name + ".ext"
        + "\" "
        + MCLTools.SplitSign
            + " "
        + MCLTools.StartSignCollection
        + " "
        + MCLTools.EndSignCollection
        + " "
        + MCLTools.SignCharacterSSwitch
            + "_save "
        + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 10;

        public MCL() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _open = false;
        public bool _save = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool O
        {
            get { return _open; }
            set
            {
                //if (_) _args = value;
                //else
                _open = value;
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
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string extention { get; set; } = ".mcl";
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
                var sa = MiMFa_StringService.FirstFindAndSplit(po[0].ToString(), ",");
                if (_open || o)
                    return MCL.Compile(MiMFa_IOService.FileToString(PATH.getpath(MCL.Compile(sa[0]))));
                else if (_save || s || sa.Length == 2)
                    MiMFa_IOService.StringToFile(MCL.Parse(PATH.getpath(sa[0] + extention)), MCL.CrudeText(sa[1]));
            }
            return Null;
        }
        #endregion
    }
}
