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
    public class PATH : CommandBase
    {
        public override string description => "Copy or Copy and Paste anything";
        public override string aliasname => "ls";
        public override string structure =>
                name
                + " "
                + "\"directory\" "
                + MCLTools.SignFinish;
        public override int structureindex =>4;

        public PATH() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _attrib = false;
        public bool _create = false;
        public bool _directory = false;
        public bool _justName = false;
        public bool _file = false;
        public bool _go = false;
        public bool _reclusive = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool A
        {
            get { return _attrib; }
            set
            {
                //if (_)  = value;
                //else
                _attrib = value;
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
        public virtual bool D
        {
            get { return _directory; }
            set
            {
                //if (_)  = value;
                //else
                _directory = value;
            }
        }
        public virtual bool F
        {
            get { return _file; }
            set
            {
                //if (_)  = value;
                //else
                _file = value;
            }
        }
        public virtual bool R
        {
            get { return _reclusive; }
            set
            {
                //if (_)  = value;
                //else
                _reclusive = value;
            }
        }
        public virtual bool G
        {
            get { return _go; }
            set
            {
                //if (_)  = value;
                //else
                _go = value;
            }
        }
        public virtual bool J
        {
            get { return _justName; }
            set
            {
                //if (_)  = value;
                //else
                _justName = value;
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
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            if (po != null && po.Length>0) return echo(po);
            return echo(HERE.current);
        }

        public override object execute(object obj, int index, int length)
        {
            string str = obj + "";
            List<string> res = search(str);
            str = getpath(str);
            if (_go || g)
               res.Add( HERE.current = getpath(obj + ""));
            if ((_create|| c ||_new) && _directory)
                MiMFa_Path.CreateDirectories(str);
            if ((_create || c || _new) && _file)
                MiMFa_Path.CreateFiles(str);
            bool ifi = isfile(str);
            if (_delete && (_directory || d || !ifi))
                MiMFa_Path.DeleteAllDirectories(_file, str);
            if (_delete && (_file || f || ifi))
                MiMFa_Path.DeleteFiles(str);
            try
            {
                for (int i = 0; i < res.Count; i++)
                {
                    int s = res[i].Split('.').Last().Length;
                    if (isfile(res[i]))
                    {
                        if (!_longview) res[i] = res[i].Split('\\').Last();
                    }
                    else if (!_longview)
                        if (_justName) res[i] = Path.GetFileNameWithoutExtension(res[i]);
                        else res[i] = Path.GetFileName(res[i]);
                }
            }
            catch { }
            return res;
        }

        public List<string> search(string name)
        {
            List<string> res = new List<string>();
            string address = "";
            bool bb = (_search || ((_reclusive || r) && (_file || f || _directory || d || _delete || _create || c || _new)));
            if (bb) address = HERE.current;
            else address = getpath(name);
            if (_file || f)
                if (isfile(address)) res.Add(address);
                else res = MiMFa_Path.GetAllFiles(address, (_reclusive || r));
            else if (_directory || d)
                 res = MiMFa_Path.GetAllDirectories(address, (_reclusive || r));
            else res = MiMFa_CollectionService.Concat(MiMFa_Path.GetAllDirectories(address, (_reclusive || r)), MiMFa_Path.GetAllFiles(address, (_reclusive || r)));
            if (bb && !name.Contains("\\")) res = (from vv in res where vv.Split('\\').Last().Contains(name) select vv).ToList();
            return res;
        }
        public static bool isfile(string path)
        {
            return !File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        }
        public static string getpath(object path) => getpath( path + "");
        public static string getpath(string path)
        {
            if (path.Contains(":\\"))
                return path;
            string s = (HERE.current.EndsWith("\\"))? HERE.current.Substring(0,HERE.current.Length - 1) : HERE.current;
            if (path.StartsWith(".")|| path.StartsWith("~")) return getpath(s,path);
            if (path.StartsWith("\\")) return s + path;
            return s + "\\" + path;
        }
        public static string getpath(string path, string name)
        {
            path = (path.EndsWith("\\"))? path.Substring(0, path.Length - 1) : path;
            if (name.StartsWith("~\\")) return getpath(Directory.GetDirectoryRoot(path),name.Substring(2));
            if (name.StartsWith("..\\")) return getpath(Directory.GetParent(path).FullName,name.Substring(3));
            if (path.StartsWith(".\\")) return path + "\\" + name.Substring(2);
            if (path.StartsWith("\\")) return path + name;
            return path + "\\" + name;
        }
        public static string setpath(string path)
        {
            return HERE.current = path;
        }

        public override void restart()
        {
            base.restart();
            HERE.current = AppDomain.CurrentDomain.BaseDirectory;
        }
        #endregion
    }
}
