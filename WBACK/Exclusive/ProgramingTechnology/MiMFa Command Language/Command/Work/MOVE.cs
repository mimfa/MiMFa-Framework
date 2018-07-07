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
    public class MOVE : CommandBase
    {
        public override string description => "Copy or Copy and Paste anything";
        public override string aliasname => "mv";
        public override string structure =>
             name
             + " "
             + "\"sourceAddress\" "
             + MCLTools.SplitSign
             + "\""
             + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MyFile "+name.ToLower() + ".ext"
             + "\" "
             + MCLTools.SignFinish;
        public override int structureindex => structure.Length - (28 + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Length);

        public MOVE() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _append = false;
        public bool _copysubdirectory = false;
        public bool _create = false;
        public bool _nocreatedestinationdirectory = false;
        public bool _serialize = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool A
        {
            get { return _append; }
            set
            {
                //if (_)  = value;
                //else
                _append = value;
            }
        }
        public virtual bool C
        {
            get { return _create; }
            set
            {
                //if (_)  = value;
                //else
                _create = value;
            }
        }
        public virtual bool N
        {
            get { return _nocreatedestinationdirectory; }
            set
            {
                //if (_)  = value;
                //else
                _nocreatedestinationdirectory = value;
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
        public virtual bool U
        {
            get { return _copysubdirectory; }
            set
            {
                //if (_)  = value;
                //else
                _copysubdirectory = value;
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
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public static dynamic source { get; set; }

        public override object EXECUTE(params object[] po)
        {
            var copy = new COPY();
            copy._append = _append;
            copy._copysubdirectory = _copysubdirectory;
            copy._create = _create;
            copy._nocreatedestinationdirectory = _nocreatedestinationdirectory;
            copy._serialize = _serialize;
            copy.main(po);
            if (po != null && po.Length > 0)
                try
                {
                    string s = PATH.getpath(source.ToString().Trim());
                    bool sf = PATH.isfile(s);
                    if (!sf)
                        Directory.Delete(s, _copysubdirectory);//delete directory to directory
                    else File.Delete(s);
                }
                catch { }
            return po;
        }
        #endregion
    }
}
