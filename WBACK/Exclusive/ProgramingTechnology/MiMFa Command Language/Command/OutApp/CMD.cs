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
    public class CMD : CommandBase
    {
        public override string description => "Open the command prompt";
        public CMD() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _concatwords = false;
        public bool _hidden = false;
        public bool _maximize = false;
        public bool _normalize = false;
        public bool _minimize = false;
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
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string SeparateText { get; set; } = " ";
        #endregion

        #region Environment Variable => PROPERTY (Any Type & get;)
        #endregion

        #region Allowances
        public override bool IsInternal { get; set; } = false;
        public override bool IsCommand { get; set; } = false;
        public override bool IsSurface { get; set; } = false;
        public override bool IsApplication { get; set; } = true;
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
            if (po == null || po.Length == 0) Process.Start("cmd.exe");
            else {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (_hidden) startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                else if (_normalize) startInfo.WindowStyle = ProcessWindowStyle.Normal;
                else if (_minimize) startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                else if (_maximize) startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = po[0].ToString();
                process.StartInfo = startInfo;
                process.Start();
            }
            return Null;
        }

        #endregion
    }
}
