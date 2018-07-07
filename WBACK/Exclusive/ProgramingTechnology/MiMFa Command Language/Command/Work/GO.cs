using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Windows.Forms;
using System.Windows.Documents;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class GO : CommandBase
    {
        public override string description => "Go and view your address";
        public GO() : base()
        {
        }
        public override string structure =>
            name
            + " "
            + "\"http://\" "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length - 3;

        #region Allowance Switch => FIELD (bool)
        public bool _file = false;
        public bool _web = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool F
        {
            get { return _file; }
            set
            {
                //if (_) _args = value;
                //else
                    _file = value;
            }
        }
        public virtual bool W
        {
            get { return _web; }
            set
            {
                //if (_) _base = value;
                //else
                    _web = value;
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
            if(po != null && po.Length >0) return echo(po);
            return execute(HERE.current,0,0);
        }

        public override object execute(object obj,int index, int length)
        {
            string str = obj.ToString().ToLower().Trim();
            if (string.IsNullOrEmpty(str) || str.Contains("\\") || _file) return file(obj);
            if (!_web && !(str.StartsWith("www.")
                    || str.StartsWith("http")
                    || str.EndsWith(".com")
                    || str.EndsWith(".ir")
                    || str.EndsWith(".de")
                    || str.EndsWith(".net")
                    || str.EndsWith(".org")
                    || str.EndsWith(".tv")
                    || str.EndsWith(".uk") 
                    || str.Contains("/"))) return file(obj);
            return web(obj);
        }

        public static object file(object address)
        {
            string addr = PATH.getpath(address);
            try
            {
                if (MCL.UserInterface is WebBrowser)
                    ((WebBrowser)MCL.UserInterface).Navigate(addr);
                else if (MCL.UserInterface is System.Windows.Controls.WebBrowser)
                    ((System.Windows.Controls.WebBrowser)MCL.UserInterface).Navigate(addr);
                else throw new InvalidProgramException();
                HERE.current = addr;
            }
            catch
            {
                try
                { System.Diagnostics.Process.Start(addr); }
                catch { }
            }
            return Null;
        }
        public static object web(object address)
        {
            try
            {
                string adrs = address.ToString().ToLower().Trim();
                adrs = (!adrs.StartsWith("http"))? "http://" + adrs: adrs;
                if (MCL.UserInterface is WebBrowser)
                    ((WebBrowser)MCL.UserInterface).Navigate(adrs);
                else if (MCL.UserInterface is System.Windows.Controls.WebBrowser)
                    ((System.Windows.Controls.WebBrowser)MCL.UserInterface).Navigate(adrs);
                else throw new InvalidProgramException();
            }
            catch
            {
                try
                { System.Diagnostics.Process.Start(address.ToString()); }
                catch { }
            }
            return Null;
        }

        public override void restart()
        {
            base.restart();
            HERE.current = AppDomain.CurrentDomain.BaseDirectory;
        }
        #endregion
    }
}
