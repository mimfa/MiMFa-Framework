using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class PROCESS : CommandBase
    {
        public override string description => "Work with processes";
        public override string aliasname => "prc";
        public PROCESS() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _concatwords = false;
        public bool _hidden = false;
        public bool _id = false;
        public bool _maximize = false;
        public bool _minimize = false;
        public bool _normalize = false;
        public bool _othermachin = false;
        public bool _topmost = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool C
        {
            get { return _concatwords; }
            set
            {
                //if (_)  = value;
                //else
                _concatwords = value;
            }
        }
        public virtual bool H
        {
            get { return _hidden; }
            set
            {
                //if (_)  = value;
                //else
                _hidden = value;
            }
        }
        public virtual bool I
        {
            get { return _id; }
            set
            {
                //if (_)  = value;
                //else
                _id = value;
            }
        }
        public virtual bool M
        {
            get { return _maximize; }
            set
            {
                if (_) _minimize = value;
                else
                    _maximize = value;
            }
        }
        public virtual bool N
        {
            get { return _normalize; }
            set
            {
                //if (_)  = value;
                //else
                _normalize = value;
            }
        }
        public virtual bool O
        {
            get { return _othermachin; }
            set
            {
                //if (_)  = value;
                //else
                _othermachin = value;
            }
        }
        public virtual bool T
        {
            get { return _topmost; }
            set
            {
                //if (_)  = value;
                //else
                _topmost = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string SeparateText { get; set; } = " ";
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
            if (_print) return list(po);
            else if (_run || _start) return run(po);
            else if (_stop) return close(po);
            else if (_kill) return kill(po);
            else return run(po);
        }

        public override object execute(object obj, int index, int length)
        {
            Process prc;
            if (obj is Process) prc = (Process)obj;
            else return obj;
            return print(prc);
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        public virtual Process processrun(string address, string args = "")
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            if (_hidden)startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            else if (_normalize)startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            else if(_minimize)startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            else if(_maximize) startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            startInfo.FileName = address;
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
            if (_topmost) MiMFa_Process.SetTopMost(process);
            return process;
        }
        public virtual object run(object[] po)
        {
            List<string> ls = new List<string>();
            object obj = null;
            if (_args) processrun(po[0].ToString().Trim(), MiMFa_CollectionService.GetAllItems(MiMFa_CollectionService.GetPart(po, 1)));
            else foreach (var item in po)
                    try
                    {
                        obj = processrun(item.ToString().Trim());
                        ls.Add(obj.ToString());
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            if (_print) return echo(ls.ToArray());
            else return Null;
        }
        public virtual object close(object[] po)
        {
            List<string> ls = new List<string>();
            Process prc = null;
            if (_all)
            {
                Process[] pro = Process.GetProcesses();
                for (int i = 0; i < pro.Length; i++)
                    try
                    {
                        pro[i].Close();
                        ls.Add(pro[i].ToString());
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            }
            else if (_othermachin) (prc = Process.GetProcessById(Convert.ToInt32(po[0]), po[1].ToString())).Close();
            else if (_id) foreach (var item in po)
                    try
                    {
                        prc = Process.GetProcessById(Convert.ToInt32(item));
                        prc.Close();
                        ls.Add(prc.ToString());
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            else foreach (var item in po)
                    try
                    {
                        Process[] prcarr = Process.GetProcessesByName(item.ToString().Trim());
                        for (int i = 0; i < prcarr.Length; i++)
                        {
                            prcarr[i].Close();
                            ls.Add(prcarr[i].ToString());
                        }
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            if (_print) return echo(ls.ToArray());
            else return Null;
        }
        public virtual object kill(object[] po)
        {
            List<string> ls = new List<string>();
            Process prc = null;
            if (_all)
            {
                Process[] pro = Process.GetProcesses();
                for (int i = 0; i < pro.Length; i++)
                    try
                    {
                        pro[i].Kill();
                        ls.Add(pro[i].ToString());
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            }
            else if (_othermachin) (prc = Process.GetProcessById(Convert.ToInt32(po[0]), po[1].ToString())).Kill();
            else if(_id) foreach (var item in po)
                    try
                    {
                        prc = Process.GetProcessById(Convert.ToInt32(item));
                        prc.Kill();
                        ls.Add(prc.ToString());
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            else foreach (var item in po)
                    try
                    {
                        Process[] prcarr = Process.GetProcessesByName(item.ToString().Trim());
                        for (int i = 0; i < prcarr.Length; i++)
                        {
                            prcarr[i].Kill();
                            ls.Add(prcarr[i].ToString());
                        }
                    }
                    catch (System.Exception ex) { if (_error) ls.Add(ex.Message); }
            if (_print) return echo(ls.ToArray());
            else return Null;
        }
        public virtual object list(object[] po)
        {
            Process[] prca = null;
            if (po == null || po.Length == 0 || _all) prca = Process.GetProcesses();
            else if (_id && _othermachin && _args) prca = new Process[] { Process.GetProcessById(Convert.ToInt32(po[0]), po[1].ToString()) };
            else if (_id && po.Length == 1 && _args) prca = new Process[] { Process.GetProcessById(Convert.ToInt32(po[0])) };
            else if (_othermachin && po.Length <= 1) prca = Process.GetProcesses(po[0].ToString());
            else {
                List<Process> lp = new List<Process>();
                if (_othermachin)
                {
                    string machine = po[0].ToString();
                    for (int i = 1; i < po.Length; i++)
                        lp.AddRange(Process.GetProcessesByName(po[i].ToString(), machine));
                }
                else
                    for (int i = 0; i < po.Length; i++)
                        lp.AddRange(Process.GetProcessesByName(po[i].ToString()));
                prca = lp.ToArray();
            }
            return echo(prca);
        }
        public virtual string print(Process p)
        {
            string s = "";
            if(_id) s += p.Id ;
            if(_id && ( _longview || _humanreadable)) s +=  "\t";
            if (!_concatwords) s += SeparateText;
            if (_longview && _detail) s += p.MachineName + ".";
            s += p.ProcessName;
            if (!_concatwords) s += SeparateText;
            return s;
        }
        #endregion
    }
}
