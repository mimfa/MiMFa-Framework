using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Attribute;
using MiMFa_Framework.Service;
using System.Reflection;
using System.IO;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using System.ComponentModel;
using MiMFa_Framework.Model;
using MiMFa_Framework.Exclusive.Display;
using MiMFa_Framework.General;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    [DefaultMethod("main")]
    public abstract class CommandBase
    {
        public delegate bool Condition(params object[] args);
        public static MiMFa_CommandLanguage MCL { get; set; }
        public CommandBase()
        {
            helpaddress = MCL.Address.HelpDirectory + this.GetType().Name + Address.HTMLExtension;
        }
        public virtual string name => this.GetType().Name.ToLower();
        public virtual string aliasname => this.GetType().Name.ToLower();
        public virtual string structure
        {
            get
            {
                string str = "";
                //if (IsHardCommand) str += MCLTools.StartSignParenthesis + nameof(VAR) + " _" + name.ToLower() + " = ";
                str += name + " ";
                if (!IsValue)
                {
                    if (!IsSimplyCommand)
                    {
                        if (IsNotNullInput) str += "value" + " ";
                        if (IsSwichable)
                            if (_exes) str += "-x" + " ";
                            else str += "-_" + " ";
                    }
                    //if (IsHardCommand) str += MCLTools.EndSignParenthesis;
                    else str += MCLTools.SignFinish;
                }
                else if (IsHardCommand) str += MCLTools.EndSignParenthesis;
                return str;
            }
        }
        public virtual int structureindex => structure.Length - (1 + MCLTools.SignFinish.Length);
        public virtual string description => "This is an executable command";

        #region Allowance Switch => FIELD (bool)
        public bool __ = false;
        public bool _all = false;
        public bool _attach = false;
        public bool _args = false;
        public bool _background = false;
        public bool _base = false;
        public bool _cool = false;// ~ _force
        public bool _copy = false;// * _paste
        public bool _clearscreen = false;
        public bool _crudeinput = false;
        public bool _delete = false;// ~_insert
        public bool _detail = false;
        public bool _error = false;
        public bool exe = false;// * _reexecute
        public bool _exes = false;// * _reexecute
        public bool _force = false;// ~ _cool
        public bool _get = false;// * _set
        public bool _humanreadable = false;
        public bool _help = false;
        public bool _insert = false;// ~ _delete
        public bool _input = false;
        public bool _kill = false;// ~ _run
        public bool _longview = false;
        public bool _maintype = false;
        public bool _mode = false;
        public bool _new = false;
        public bool _newline = false;
        public bool _no = false;// ~ _yes
        public bool _freeze = false;// no execute END method
        public bool _null = false;// = gotohell
        public bool _start = false;// ~ _stop
        public bool _paste = false;// * _copy
        public bool _print = false;
        public bool _process = false;
        public bool _quit = false;
        public bool _reexecute = false;// * _execute
        public bool _refrence = false;
        public bool _refresh = false;
        public bool _restart = false;
        public bool _run = false;// ~ _kill
        public bool _search = false;// match
        public bool _set = false;// * _get
        public bool _separate = false;
        public bool _stop = false;// ~ _start
        public bool _stopwatch = false;
        public bool _this = false;
        public bool _thread = false;
        public bool _update = false;
        public bool _user = false;
        public bool _value = false;
        public bool _write = false;
        public bool _yes = false;// ~ _no
        public bool _yield = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool _
        {
            get
            {
                if (__) return !(__ = false);
                return __;
            }
            set { __ = value; }
        }
        public virtual bool a
        {
            get { return _all; }
            set
            {
                if (_) _args = value;
                else
                    _all = value;
            }
        }
        public virtual bool b
        {
            get { return _background; }
            set {
                if (_) _base = value;
                else
                    _background = value;
            }
        }
        public virtual bool c
        {
            get { return _cool; }
            set
            {
                if (_) _copy = value;
                else  _crudeinput = _cool = value;
            }
        }
        public virtual bool d
        {
            get { return _detail; }
            set {
                if (_) _delete = value;
                else
                    _detail = value;
            }
        }
        public virtual bool e
        {
            get { return _error; }
            set
            {
                if (_) _stopwatch = value;
                else
                    _error = value;
            }
        }
        public virtual bool f
        {
            get { return _force; }
            set
            {
                if (_) _search = value;
                else
                    _force = value;
            }
        }
        public virtual bool g
        {
            get { return _get; }
            set
            {
                if (_) _restart = value;
                else
                    _get = _base = value;
            }
        }
        public virtual bool h
        {
            get { return _humanreadable; }
            set {
                if (_) _help = value;
                else
                    _humanreadable = value;
            }
        }
        public virtual bool i
        {
            get { return _input; }
            set
            {
                if (_) _insert = value;
                else _input = value;
            }
        }
        public virtual bool j
        {
            get { return _attach; }
            set
            {
                if (_)  _refresh = value;
                else
                    _attach = value;
            }
        }
        public virtual bool k
        {
            get { return _separate; }
            set
            {
                if (_) _kill = value;
                else
                    _separate = value;
            }
        }
        public virtual bool l
        {
            get { return _longview; }
            set
            {
                if (_) _newline  = value;
                else
                    _longview = value;
            }
        }
        public virtual bool m
        {
            get { return _mode; }
            set {
                //if (_)  = value;
                //else
                    _mode = value; }
        }
        public virtual bool n
        {
            get { return _no; }
            set {
                if (_) _new = value;
                else
                    _no = value; }
        }
        public virtual bool o
        {
            get { return _start; }
            set {
                if (_) _clearscreen = value;
                else
                    _start = value; }
        }
        public virtual bool p
        {
            get { return _print; }
            set {
                if (_) _process = value;
                else
                    _print = value; }
        }
        public virtual bool q
        {
            get { return _maintype; }
            set {
                if (_) _quit = value;
                else
                    _maintype = value;
            }
        }
        public virtual bool r
        {
            get { return _refrence; }
            set {
                if (_) _run = value;
                else
                    _refrence = value; }
        }
        public virtual bool s
        {
            get { return _set; }
            set {
                if (_) _stop = value;
                else
                    _set = _base = value;
            }
        }
        public virtual bool t
        {
            get { return _thread; }
            set {
                if (_) _this = value;
                else
                    _thread = value;
            }
        }
        public virtual bool u
        {
            get { return _user; }
            set {
                if (_) _update = value;
                else
                    _user = value; }
        }
        public virtual bool v
        {
            get { return _value; }
            set {
                if (_) _paste = value;
                else
                    _value = value; }
        }
        public virtual bool w
        {
            get { return _write; }
            set {
                if (_)_crudeinput  = value;
                else
                    _write = value;
            }
        }
        public virtual bool x
        {
            get { return exe; }
            set {
                if (_) _reexecute = value;
                else
                { exe = value; _exes = true; }
            }
        }
        public virtual bool y
        {
            get { return _yes; }
            set {
                if (_) _yield = value;
                else
                    _yes = value;
            }
        }
        public virtual bool z
        {
            get { return _null; }
            set
            {
                if (_) _freeze = value;
                else
                    _null = value;
            }
        }

        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual bool showerror { get { return _showerror; } set { _showerror = value; } }
        protected static bool _showerror = true;
        #endregion

        #region Environment Variable => PROPERTY (Any Type & get; protected set;)
        public static object Null { get; protected set; } = new MiMFa_Empty<object>();
        public virtual string helpaddress { get; protected set; } = "";
        #endregion

        #region Allowances
        public virtual bool IsInternal { get; set; } = true;
        public virtual bool IsCommand { get; set; } = true;
        public virtual bool IsSurface { get; set; } = false;
        public virtual bool IsApplication { get; set; } = false;
        public virtual bool IsStatic { get; set; } = false;
        public virtual bool IsConfirmationRequired { get; set; } = false;
        public virtual bool IsSwichable { get; set; } = true;
        public virtual bool IsSSwichable { get; set; } = true;
        public virtual bool IsCrudeInput { get; set; } = false;
        public virtual bool IsNotNullInput { get; set; } = true;
        public virtual bool IsReturnResult { get; set; } = true;

        public virtual bool IsExternal => !IsInternal;
        public virtual bool IsSimplyCommand => !IsSwichable && !IsSSwichable && !IsNotNullInput && !IsCrudeInput;
        public virtual bool IsHardCommand => IsReturnResult && !IsSimplyCommand && !IsValue && !IsCrudeInput;
        public virtual bool IsValue => !IsApplication && !IsSurface && IsInternal && IsStatic && IsSimplyCommand && IsReturnResult;
        public virtual bool IsChanger => IsStatic && !IsReturnResult;
        #endregion

        #region Function Switch => METHOD
        public virtual Condition condition { get; set; } = (args) => breakrun == 0;
        public int nest { get; set; } = 0;
        public static int breakrun { get { return _breakrun; } set { _breakrun = (value >= 0) ? value : 0; } }
        private static int _breakrun = 0;

        public virtual string ba => _beginattach + beginattach;
        public virtual string ea => _endattach + endattach;
        public virtual string beginattach { get; set; } = "";
        public virtual string endattach { get; set; } = "";
        public static string _beginattach { get; set; } = "";
        public static string _endattach { get; set; } = "";
        public static object previous { get; set; } = null;
        public static object next { get; set; } = null;

        public static object clipboard { get; set; } = null;
        public static object That { get; set; } = null;
        public static object This { get; set; } = null;
        public virtual object prev { get; set; } = null;
        public virtual object curr { get; set; } = null;

        public object main(params object[] po)
        {
            nest++;
            try
            {
                if (!_exes) exe = true;
                if (_restart) restart();
                if (_refresh) refresh();
                if (_help) return help();
                if (!_yes && (_delete || _kill || IsConfirmationRequired))
                    if(_no) throw new Exception("This command is stop!");
                    else if((new DIALOG()).show(((IsConfirmationRequired)? description:(_delete)? "Delete!":(_kill)? "Killing!":description)+Environment.NewLine + "Are you sure?","Confirm",Collection.MiMFa_MessageType.Alert) != DialogResult.Yes)
                        throw new Exception("This command is stop!");
                if (_paste)
                    if (po == null || po.Length < 0) po = new object[] { clipboard };
                    else po = MiMFa_CollectionService.Concat(new object[] { clipboard }, po);
                if (_cool)
                {
                    _cool = false;
                    return END((po == null || po.Length < 0 || po[0] == null) ? Null :
                        MCL.Parser(po[0].ToString(), this));
                }
                if (_this)
                    return this;
                prev = curr;
                curr = null;
                if (_base)
                    if (_get && _value) curr = getvalues(po);
                    else if (_get) curr = get(po);
                    else if (_set) curr = set(po);
                    else curr = echo(po);
                else
                {
                    if (_thread)
                    {
                        Thread th = new Thread(() => 
                        {
                            if (_stopwatch) curr = STOPWATCHEXECUTE(po);
                            else curr = EXECUTE(po);
                        });
                        th.IsBackground = _background;
                        th.SetApartmentState(_mode ? ApartmentState.MTA : ApartmentState.STA);
                        curr = Null;
                        th.Start();
                    }
                    else
                    {
                        if (_stopwatch) curr = STOPWATCHEXECUTE(po);
                        else curr = EXECUTE(po);
                    }
                }
                return END(curr, po);
            }
            catch (System.Exception ex)
            {
                return ERROR(ex);
            }
            finally
            {
                nest--;
            }
        }
        public virtual object STOPWATCHEXECUTE(params object[] po)
        {
            double time = DateTime.Now.TimeOfDay.TotalMilliseconds;
            object obj = EXECUTE(po);
            time = DateTime.Now.TimeOfDay.TotalMilliseconds - time;
            return new object[] { time, obj };
        }
        public virtual object EXECUTE(params object[] po)
        {
            if (_get && _print && _value) curr = print(getvalues(po));
            else if (_get && _print) curr = print(get(po));
            else if (_get) curr = get(po);
            else if (_set) curr = set(po);
            else curr = echo(po);
            return curr;
        }
        public virtual object END(object result, params object[] po)
        {
            That = This;
            This = result;
            if (_null && _value) curr = Null;
            if (!_maintype && _print && result != Null)
                try
                {
                    string rpt = result.GetType().Name.ToLower();
                    if (rpt.EndsWith("[]")) result = print(MiMFa_Convert.ToArray(result));
                    else if (result is IList) result = print(MiMFa_Convert.ToList(result).ToArray());
                    else if (result is IDictionary) result = print(MiMFa_Convert.ToDictionary(result));
                    else if (rpt.EndsWith("collection"))
                        result = print(MiMFa_Convert.ToArray(result).ToArray());
                    else result = print(result);
                }
                catch { result = print(result); }
                finally
                {
                    if (_thread) result += " [" + Configuration.Default.Time;
                    if (_thread && _longview) result += " " + Configuration.Default.Date + "]";
                    else if (_thread) result += "]";
                }
            else if (!_maintype && _print)
            {
                if (_thread) result += " [" + Configuration.Default.Time;
                if (_thread && _longview) result += " " + Configuration.Default.Date + "]";
                else if (_thread) result += "]";
            }
            if (_copy) clipboard = This;
            if (_null) result = Null;
            if (_clearscreen) (new CLEAN()).main();
            if (_quit) (new QUIT()).main();
            if (_reexecute)
            {
                _reexecute = false;
                result = main(result);
            }
            if (!_freeze)
            {
                Type type = this.GetType();
                FieldInfo[] fi = type.GetFields();
                fi = (from ff in fi where ff.FieldType == typeof(bool) && ff.Name.StartsWith("_") select ff).ToArray();
                for (int i = 0; i < fi.Length; i++)
                    fi[i].SetValue(this, false);
            }
            if(IsReturnResult) return result;
            return Null;
        }
        public virtual object ERROR(System.Exception ex)
        {
            if (_error && _showerror && !_yield)
                return MCLTools.StartSignIndex + "ERROR(" + ex.HResult + "): " + ex.Message + MCLTools.EndSignIndex;
            object obj = Null;
                if (_yield)
                    obj = END(curr, ex);
                if (!_freeze && !_yield)
                {
                    Type type = this.GetType();
                    FieldInfo[] fi = type.GetFields();
                    fi = (from ff in fi where ff.FieldType == typeof(bool) && ff.Name.StartsWith("_") select ff).ToArray();
                    for (int i = 0; i < fi.Length; i++)
                        fi[i].SetValue(this, false);
                }
                return obj;
        }

        public virtual object execute(object obj,int index,int length) => obj;
        public virtual object value() => curr;

        public object echo(object obj, int index = 0, int length = 0)
        {
            if (breakrun != 0 || (!_refrence && !exe)) return Null;
            object o = (exe)?execute(obj, index, length): null;
            if (_background) return Null;
            if (_refrence && !exe) o = obj;
            else if (_refrence && exe) o = new KeyValuePair<object,object>(obj, o);
            if (_detail) try { Console.WriteLine(print(MiMFa_Convert.ToArray(o))); } catch { Console.WriteLine(print(o)); }
            return o;
        }
        public object echo(object[] po, bool separate, bool refrence = false, bool exec = false, bool humanreadable = false, bool longview = false, bool newline = false, bool background = false)
        {
            List<object> lo = new List<object>();
            for (int i = 0; i < po.Length && breakrun ==0; i++)
                if (exec) lo.Add( echo(po[i], i, po.Length));
            return Normalization(lo.ToArray());
        }
        public object echo(object[] po)
        {
            return echo(po, _separate, _refrence, exe, _humanreadable, _longview, _newline, _background);
        }

        public static dynamic Normalization(params object[] po)
        {
            if (po == null) return Null;
            if (po.Length == 0) return Null;
            List<object> lo = po.ToList();
            lo.RemoveAll((o) => o != null && o == Null);
            if (lo.Count == 0) return Null;
            if (lo.Count == 1) return lo[0];
            return lo.ToArray();
        }

        public virtual string print()
        {
            return print(curr);
        }
        public virtual string print(object obj, int index = 0, int length = 0)
        {
            if (obj == null) return null;
            string s = "";
            if (breakrun == 0)
            {
                s += MCL.Display.Done(obj, false);
                if (_background) return "";
            }
            return s;
        }
        public virtual string print(object[] po, bool separate, bool refrence = false, bool exec = false, bool humanreadable = false, bool longview = false, bool newline = false, bool background = false)
        {
            string s = "";
            if (separate) s += MCL.Display.StartSign;
            for (int i = 0; i < po.Length && breakrun == 0; i++)
            {
                s += print(po[i], i, po.Length);
                if (i < po.Length - 1)
                    if (humanreadable || newline) s += MCL.Display.BreakSign;
                    else if (longview) s += MCL.Display.TabSign;
            }
            if (separate) s += MCL.Display.EndSign ;
            if (background) return "";
            return s;
        }
        public virtual string print(object[] po)
        {
            return print(po, _separate, _refrence, exe, _humanreadable, _longview, _newline, _background);
        }
        public virtual string print(KeyValuePair<string, object> item)
        {
            string s = "";
            if (_refrence && item.Key != null) s += MCL.Display.Done(item.Key, false);
            if (_longview && _refrence) s += MCL.Display.MiddleSign;
            s += MCL.Display.Done(item.Value, false);
            if (!_humanreadable && _longview) s += MCL.Display.SplitSign;
            if (_humanreadable || _newline) s += MCL.Display.BreakSign;

            if (_background) return "";
            return s;
        }
        public virtual string print(Dictionary<string, object> dic)
        {
            string s = "";
            if (_separate) s += MCL.Display.StartSign;
            foreach (var item in dic)
            {
                if (breakrun != 0) break;
                s+= print(item);
            }
            if (!_humanreadable && _longview && dic.Count > 0) s = s.Substring(0, s.Length - MCL.Display.BreakSign.Length);
            if ((_humanreadable || _newline) && dic.Count > 0) s = s.Substring(0, s.Length - MCL.Display.BreakSign.Length);
            if (_separate) s += MCL.Display.EndSign;
            if (_background) return "";
            return s;
        }

        public virtual object gth(params object[] po) => new MiMFa_Empty<object>();

        public virtual string help()
        {
            Dictionary<string, bool> chkdic = new Dictionary<string, bool>();
            chkdic.Add("Internal", IsInternal);
            chkdic.Add("External", IsExternal);
            chkdic.Add("Surface", IsSurface);
            chkdic.Add("Application", IsApplication);
            chkdic.Add("Command", IsCommand);
            chkdic.Add("Static", IsStatic);
            chkdic.Add("Confirmation Required", IsConfirmationRequired);
            chkdic.Add("Swichable", IsSwichable);
            chkdic.Add("Strong Swichable", IsSSwichable);
            chkdic.Add("Crude Input", IsCrudeInput);
            chkdic.Add("Not Null Input", IsNotNullInput);
            chkdic.Add("Return Result", IsReturnResult);
            chkdic.Add("Simply Command", IsSimplyCommand);
            chkdic.Add("Hard Command", IsHardCommand);
            chkdic.Add("Value", IsValue);
            chkdic.Add("Changer", IsChanger);
            string str = "";
            string specialswichs = "";
            if (IsSwichable)
            {
                PropertyInfo[] pi = this.GetType().GetProperties();
                var filter = from p in pi where p.Name.Length == 1 && p.Name != "_" && p.Name == p.Name.ToUpper() select p;
                foreach (var item in filter)
                    specialswichs += " " + MCLTools.SignCharacterSwitch + item.Name;
            }
            string helpcontent = MiMFa_IOService.FileToString(helpaddress);
            if (string.IsNullOrEmpty(Normalization(helpcontent).Trim()))
                helpcontent = MCL.Display.Done(getrelations());
            if (MCL.DisplayType == MiMFa_DisplayType.HTML)
            {
                string ischk = "<div style='text-align:center;margin:10pt;color:fefefe;'>";
                foreach (var item in chkdic)
                    if (item.Value)
                    {
                        ischk += "<font style='padding:3pt;margin:1pt;background-color:097815;'>";
                        ischk += MCL.Display.Done(item.Key);
                        ischk += "</font>";
                    }
                ischk += "</div>";
                str =
                   MCL.Display.BreakLineSign
                   + "<div style='font-weight:bolder;text-align:center;padding:10pt;background-color:096078;color:fefefe;'>"
                   + name.ToUpper()
                   + "</div>"
                   + "<div style='padding:10pt;padding-top:0pt;background-color:096078;color:fefefe;'>"
                   + description
                   + "</div>"
                   + MCL.Display.BreakLineSign
                   + ischk
                   + "Alias Name: "
                   + aliasname
                   + MCL.Display.BreakSign
                   + "Normal Straucture: "
                   + structure
                   + MCL.Display.BreakSign
                   + "Dedicated switches: "
                   + specialswichs
                   + MCL.Display.BreakLineSign
                   + helpcontent
                   + MCL.Display.BreakSign
                   + MCL.Display.BreakLineSign;
            }
            else
            {
                string ischk = "";
                foreach (var item in chkdic)
                    if (item.Value)
                        ischk += MCL.Display.Done(item.Key) + " | ";
                str =
                    MCL.Display.BreakLineSign
                    + name.ToUpper()
                    + MCL.Display.BreakLineSign
                    + description
                    + MCL.Display.BreakLineSign
                    + ischk
                   + MCL.Display.BreakLineSign
                   + "Alias Name: "
                   + aliasname
                   + MCL.Display.BreakSign
                   + "Normal Straucture: "
                   + structure
                   + MCL.Display.BreakSign
                   + "Dedicated switches: "
                   + specialswichs
                   + MCL.Display.BreakLineSign
                    + helpcontent
                    + MCL.Display.BreakSign
                    + MCL.Display.BreakLineSign;
            }
            if (_get)
                str += print(get())
                + MCL.Display.BreakLineSign;
            return str;
        }

        public virtual void restart()
        {
            Type type = this.GetType();
            FieldInfo[] fi = type.GetFields();
            fi = (from ff in fi where ff.FieldType == typeof(bool) && ff.Name.StartsWith("_") select ff).ToArray();
            for (int i = 0; i < fi.Length; i++)
                fi[i].SetValue(this, false);
        }
        public virtual void refresh()
        {

        }

        public virtual bool equals(object obj)
        {
            if (curr == null) return obj == null; return curr.Equals(obj);
        }
        public virtual string tostring()
        {
            if (curr == null) return null; return curr.ToString();
        }
        public virtual Type gettype()
        {
            if (curr == null) return null; return curr.GetType();
        }
        public virtual int gethashcode()
        {
            if (curr == null) return 0;return curr.GetHashCode();
        }
        public virtual Dictionary<string, object> getspecialrelations()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (!IsSwichable && !IsSSwichable) return dic;
            Type tt = this.GetType();
            FieldInfo[] fiarr = (from pp in tt.GetFields() where pp.FieldType == typeof(bool) select pp).ToArray();
            PropertyInfo[] piarr = (from pp in tt.GetProperties() where pp.Name.Length == 1 && pp.Name == pp.Name.ToUpper()&& pp.Name != "_" && pp.PropertyType == typeof(bool) select pp).ToArray();
            object[] objarr = new object[piarr.Length];
            for (int i = 0; i < fiarr.Length; i++)
                try
                {
                    objarr[i] = fiarr[i].GetValue(this);
                    if (fiarr[i].Name.StartsWith("_") && fiarr[i].FieldType == typeof(bool))
                        fiarr[i].SetValue(this, false);
                }
                catch { }
            for (int i = 0; i < piarr.Length; i++)
            {
                if (piarr[i].PropertyType == typeof(bool) && piarr[i].Name.Length == 1)
                {
                    try
                    {
                        piarr[i].SetValue(this, true);
                        for (int j = 0; j < fiarr.Length; j++)
                            if (fiarr[j].FieldType == typeof(bool) && (bool)fiarr[j].GetValue(this) && fiarr[j].Name.StartsWith("_"))
                            {
                                dic.Add(piarr[i].Name, fiarr[j].Name);
                                break;
                            }
                        piarr[i].SetValue(this, false);
                    }
                    catch { }
                }
                else
                    dic.Add(piarr[i].Name, piarr[i].GetValue(this));
            }
            for (int i = 0; i < piarr.Length; i++)
                try
                {
                    fiarr[i].SetValue(this, objarr[i]);
                }
                catch { }
            return dic;
        }
        public virtual Dictionary<string, object> getrelations()
        {
            Dictionary<string, object> dic = getspecialrelations();
            if (!IsSwichable && !IsSSwichable) return dic;
            dic.Add("a", "_all");
            dic.Add("_a", "_args");
            dic.Add("b", "_background");
            dic.Add("_b", "_base");
            dic.Add("c", "_cool");
            dic.Add("_c", "_copy");
            dic.Add("d", "_detail");
            dic.Add("_d", "_delete");
            dic.Add("e", "_error");
            dic.Add("f", "_force");
            dic.Add("_f", "_search");
            dic.Add("g", "_get");
            dic.Add("_g", "_restart");
            dic.Add("h", "_humanreadable");
            dic.Add("_h", "_help");
            dic.Add("i", "_input");
            dic.Add("_i", "_insert");
            dic.Add("j", "_attach");
            dic.Add("_j", "_refresh");
            dic.Add("k", "_separate");
            dic.Add("_k", "_kill");
            dic.Add("l", "_longview");
            dic.Add("_l", "_newline ");
            dic.Add("m", "_mode");
            dic.Add("n", "_no");
            dic.Add("_n", "_new");
            dic.Add("o", "_start");
            dic.Add("_o", "_clearscreen");
            dic.Add("p", "_print");
            dic.Add("_p", "_process");
            dic.Add("q", "_maintype");
            dic.Add("_q", "_quit");
            dic.Add("r", "_refrence");
            dic.Add("_r", "_run");
            dic.Add("s", "_set");
            dic.Add("_s", "_stop");
            dic.Add("t", "_thread");
            dic.Add("_t", "_this");
            dic.Add("u", "_user");
            dic.Add("_u", "_update");
            dic.Add("v", "_value");
            dic.Add("_v", "_paste");
            dic.Add("w", "_write");
            dic.Add("_w", "_crudeinput");
            dic.Add("x", "exe");
            dic.Add("_x", "_reexecute");
            dic.Add("y", "_yes");
            dic.Add("_y", "_yield");
            dic.Add("z", "_null");
            dic.Add("_z", "_freeze");
            return dic;
        }
        public virtual string toupper()
        {
            if (curr == null) return null; return curr.ToString().ToUpper();
        }
        public virtual string tolower()
        {
            if (curr == null) return null; return curr.ToString().ToLower();
        }
        public virtual string trim()
        {
            if (curr == null) return null; return curr.ToString().Trim();
        }
        public virtual string trimstart()
        {
            if (curr == null) return null; return curr.ToString().TrimStart();
        }
        public virtual string trimend()
        {
            if (curr == null) return null; return curr.ToString().TrimEnd();
        }

        public virtual void writeto(string address)
        {
            FileAccess fileaccess = FileAccess.Write;
            FileMode filemode = FileMode.OpenOrCreate;
            if (_new && _start) filemode = FileMode.OpenOrCreate;
            else if (_attach && !_write) filemode = FileMode.Append;
            else if (_start) filemode = FileMode.Open;
            else if (_new) filemode = FileMode.Truncate;
            FileStream fs = new FileStream(address, filemode, fileaccess);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                if (_newline) sw.WriteLine(sw.NewLine + print());
                else sw.Write(print());
                sw.Close();
            }
            catch { }
            finally { sw.Close(); }
        }
        public virtual void appendto(object obj, string address)
        {
            _attach = true;
            writeto(address);
        }
        public virtual object readfrom(string address)
        {
            if(l || h) return curr = MiMFa_IOService.FileToString(address);
            return curr = MiMFa_IOService.FileToTrimedString(address);
        }
        public virtual byte[] serialize() => MiMFa_IOService.Serialize(curr);
        public virtual object deserialize() => MiMFa_IOService.Deserialize((byte[])curr);
        public virtual void saveto(string address) => MiMFa_IOService.SaveSerializeFile(address, curr);
        public virtual object openfrom(string address) => curr = MiMFa_IOService.OpenDeserializeFile(address);

        public virtual Dictionary<object, object> getvalues(params object[] po)
        {
            Type t = this.GetType();
            Dictionary<object, object> dic = new Dictionary<object, object>();
            MemberInfo[] mi = get(po);
            foreach (var item in mi)
            {
                if ((_all || _property) && item is PropertyInfo) dic.Add(item ,((PropertyInfo)item).GetValue(this));
                else if ((_all || _field) && item is FieldInfo) dic.Add(item, ((FieldInfo)item).GetValue(this));
                else if ((_all || _method) && item is MethodInfo) dic.Add(item, print(((MethodInfo)item).GetParameters(), false,true, false, true, true, false, false));
                else if ((_all || _event) && item is EventInfo) dic.Add(item, print(((EventInfo)item).GetOtherMethods(), false, true, false, true, true, false, false));
                else if((_all || _constructor) && item is ConstructorInfo) dic.Add(item, print(((ConstructorInfo)item).GetParameters(), false, true, false, true, true, false, false));
                else if ((_all || _interface) && item is Type) dic.Add(item, ((Type)item).FullName);
                else if (_all && item != null) dic.Add(item, ((Type)item).FullName);
            }
            return dic;
        }
        public virtual MemberInfo[] get(params object[] po)
        {
            Type t = this.GetType();
            List<MemberInfo> list = new List<MemberInfo>();
            if (_all && !_interface && !_constructor && !_event && !_field && !_method && !_property)
                if(po == null || po.Length == 0) return t.GetMembers();
                else foreach (var item in po)
                    if (string.IsNullOrEmpty(item.ToString())) return t.GetMembers();
                    else list.AddRange(t.GetMember(item.ToString()));
            else {
                if (_all || _property) list.AddRange(properties(po));
                if (_all || _field) list.AddRange(fields(po));
                if (_all || _method) list.AddRange(methods(po));
                if (_all || _event) list.AddRange(events(po));
                if (_all || _constructor) list.AddRange(constructors(po));
                if (_all || _interface) list.AddRange(interfaces(po));
            }
            return list.ToArray();
        }
        public virtual object set(params object[] po)
        {
            Type t = this.GetType();
            MemberInfo mi;
            MemberInfo[] miarr;
            string name = po[0].ToString();
            if ((_property || _all) && (mi=t.GetProperty(name))!=null)
                ((PropertyInfo)mi).SetValue(this, po[1]);
            else if ((_field || _all) && (mi = t.GetField(name)) != null)
                ((FieldInfo)mi).SetValue(this, po[1]);
            else if ((_method || _all) && (mi = t.GetMethod(name)) != null)
                ((MethodInfo)mi).Invoke(this, MiMFa_CollectionService.GetPart(po, 1));
            else if ((_event || _all) && (mi = t.GetEvent(name)) != null)
                ((EventInfo)mi).AddEventHandler(this, (Delegate)po[1]);
            else if ((_constructor || _all) && (miarr = t.GetConstructors()) != null)
                ((ConstructorInfo)miarr[0]).Invoke(this, po);
            return null;
        }

        public bool _constructor = false;
        public virtual ConstructorInfo[] constructors(params object[] po)
        {
            Type t = this.GetType();
            return t.GetConstructors();
        }
        public bool _event = false;
        public virtual EventInfo[] events(params object[] po)
        {
            Type t = this.GetType();
            List<EventInfo> list = new List<EventInfo>();
            foreach (var item in po)
                if(item.ToString() == "*") return t.GetEvents();
                else  list.Add(t.GetEvent(item.ToString()));
            return list.ToArray();
        }
        public bool _field = false;
        public virtual FieldInfo[] fields(params object[] po)
        {
            Type t = this.GetType();
            List<FieldInfo> list = new List<FieldInfo>();
            foreach (var item in po)
                if (item.ToString() == "*") return t.GetFields();
                     else   list.Add(t.GetField(item.ToString()));
            return list.ToArray();
        }
        public bool _interface = false;
        public virtual Type[] interfaces(params object[] po)
        {
            Type t = this.GetType();
            List<Type> list = new List<Type>();
            foreach (var item in po)
                if (item.ToString() == "*") return t.GetInterfaces();
                  else   list.Add(t.GetInterface(item.ToString()));
            return list.ToArray();
        }
        public bool _method = false;
        public virtual MethodInfo[] methods(params object[] po)
        {
            Type t = this.GetType();
            List<MethodInfo> list = new List<MethodInfo>();
            foreach (var item in po)
                if (item.ToString() == "*") return t.GetMethods();
                  else list.Add(t.GetMethod(item.ToString()));
            return list.ToArray();
        }
        public bool _property = false;
        public virtual PropertyInfo[] properties(params object[] po)
        {
            Type t = this.GetType();
            List<PropertyInfo> list = new List<PropertyInfo>();
            foreach (var item in po)
                if (item.ToString() == "*") return t.GetProperties();
                else     list.Add(t.GetProperty(item.ToString()));
            return list.ToArray();
        }


        #endregion
    }
}
