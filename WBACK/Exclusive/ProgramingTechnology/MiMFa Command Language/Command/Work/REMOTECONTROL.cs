using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Diagnostics;
using MiMFa_Framework.Configuration;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class REMOTECONTROL : CommandBase
    {
        public override string description => "Change computer mode";
        public override string aliasname => "rc";
        public REMOTECONTROL() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _hibernate = false;
        public bool _lock = false;
        public bool _logoff = false;
        public bool _reboot = false;
        public bool _shutdown = false;
        public bool _sleep = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool C
        {
            get { return _lock; }
            set {
                //if (_)  = value;
                //else
                _lock = value;
            }
        }
        public virtual bool H
        {
            get { return _hibernate; }
            set {
                //if (_)  = value;
                //else
                _hibernate = value;
            }
        }
        public virtual bool K
        {
            get { return _shutdown; }
            set {
                //if (_)  = value;
                //else
                _shutdown = value;
            }
        }
        public virtual bool L
        {
            get { return _logoff; }
            set {
                //if (_)  = value;
                //else
                _logoff = value;
            }
        }
        public virtual bool O
        {
            get { return _shutdown; }
            set {
                //if (_)  = value;
                //else
                _shutdown = value;
            }
        }
        public virtual bool R
        {
            get { return _reboot; }
            set {
                //if (_)  = value;
                //else
                _reboot = value;
            }
        }
        public virtual bool S
        {
            get { return _sleep; }
            set {
                //if (_)  = value;
                //else
                _sleep = value;
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
        public override bool IsConfirmationRequired { get; set; } = true;
        public override bool IsSwichable { get; set; } = true;
        public override bool IsSSwichable { get; set; } = true;
        public override bool IsCrudeInput { get; set; } = false;
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            string filename = string.Empty;
            string arguments = string.Empty;

            if (_shutdown || o || k)// Shutdown
            {
                filename = "shutdown.exe";
                arguments = "-s";
            }
            else if (_reboot || r)// "Restart":
            {
                filename = "shutdown.exe";
                arguments = "-r";
            }
            else if (_logoff || l)// "Logoff":
            {
                filename = "shutdown.exe";
                arguments = "-l";
            }
            else if (_lock || c)//"Lock":
            {
                filename = "Rundll32.exe";
                arguments = "User32.dll, LockWorkStation";
            }
            else if (_hibernate || h)// "Hibernation":
            {
                filename = "shutdown.exe";
                arguments = "-h";
            }
            else if (_sleep || s)// "Sleep":
            {
                filename = "Rundll32.exe";
                arguments = "powrprof.dll, SetSuspendState 0,1,0";
            }

            if (_thread) arguments += " -t " + po[0].ToString();
            if (_force) arguments += " -f";
            if (!string.IsNullOrEmpty(filename))
                new System.Threading.Thread(() =>
             {
                 System.Diagnostics.Process process = new System.Diagnostics.Process();
                 System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                 startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 startInfo.FileName = filename;
                 startInfo.Arguments = arguments;
                 process.StartInfo = startInfo;
                 process.Start();
             }).Start();
            if (_detail || _thread) return Default.Date + " " + Default.Time;
            else return Null;
        }

        public override object execute(object obj,int index, int length)
        {
            return Null;
        }
        #endregion
    }
}
