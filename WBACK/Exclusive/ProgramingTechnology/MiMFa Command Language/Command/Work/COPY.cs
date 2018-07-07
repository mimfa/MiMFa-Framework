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
    public class COPY : CommandBase
    {
        public override string description => "Copy or Copy and Paste anything";
        public override string aliasname => "cp";
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

        public COPY() : base()
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
            if (po != null) echo(po);
            return po;
        }

        public override object execute(object obj, int index, int length)
        {
            FileMode f = (_create) ? FileMode.OpenOrCreate : FileMode.Open;
            if (index == 0)
                source = obj;
            else if (obj != null && obj is string)
                if (source != null && source is string)
                {
                    string s = PATH.getpath(source.ToString().Trim());
                    string d = PATH.getpath(obj.ToString().Trim());
                    bool sf = PATH.isfile(s);
                    bool df = PATH.isfile(d);
                    if (!df && !_nocreatedestinationdirectory)
                        MiMFa_Path.CreateAllDirectories(d);
                    if (!df && !sf)
                        MiMFa_Path.DirectoryCopy(s, d, _copysubdirectory);//copy directory to directory
                    else if (!df && sf)
                        File.Copy(s, d + Path.GetFileName(s));
                    else if (df && !sf)
                        throw new ArgumentException("Can not copy a directory in file!");
                    else File.Copy(s, d);
                }
                else if (source != null)
                    if (_serialize) MiMFa_IOService.SaveSerializeFile(obj.ToString(), source,f);
                    else if (_append) MiMFa_IOService.StringNewLineAppendFile(obj.ToString(), MCL.Display.Done(source),f);
                    else MiMFa_IOService.StringToFile(obj.ToString(), MCL.Display.Done(source),f);
                else throw new ArgumentNullException("Can not be null sources!");
            else obj = source;
            return Null;
        }

        #endregion
    }
}
