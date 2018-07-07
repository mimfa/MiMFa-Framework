using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.General;
using System.Windows;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class DIALOG : CommandBase
    {
        public override string description => "Question for allowance";
        public override string aliasname => "message";
        public DIALOG() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _alertmsg = false;
        public bool _binary = false;
        public bool _circleview = false;
        public bool _errormsg = false;
        public bool _informationmsg = false;
        public bool _riskmsg = false;
        public bool _successmsg = false;
        public bool _translate = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool A
        {
            get { return _alertmsg; }
            set
            {
                //if (_) _alert = value;
                //else
                    _alertmsg = value;
            }
        }
        public virtual bool B
        {
            get { return _binary; }
            set
            {
                //if (_) _alert = value;
                //else
                _binary = value;
            }
        }
        public virtual bool C
        {
            get { return _circleview; }
            set
            {
                //if (_) _alert = value;
                //else
                _circleview = value;
            }
        }
        public virtual bool E
        {
            get { return _errormsg; }
            set
            {
                //if (_) _alert = value;
                //else
                _errormsg = value;
            }
        }
        public virtual bool I
        {
            get { return _informationmsg; }
            set
            {
                //if (_) _alert = value;
                //else
                _informationmsg = value;
            }
        }
        public virtual bool R
        {
            get { return _riskmsg; }
            set
            {
                //if (_) _alert = value;
                //else
                _riskmsg = value;
            }
        }
        public virtual bool S
        {
            get { return _successmsg; }
            set
            {
                //if (_) _alert = value;
                //else
                _successmsg = value;
            }
        }
        public virtual bool T
        {
            get { return _translate; }
            set
            {
                //if (_) _alert = value;
                //else
                _translate = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        #endregion

        #region Environment Variable => PROPERTY (Any Type & get;)
        #endregion

        #region Allowances
        public override bool IsInternal { get; set; } = false;
        public override bool IsCommand { get; set; } = true;
        public override bool IsSurface { get; set; } = true;
        public override bool IsApplication { get; set; } = true;
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
            string cap = "";
            string msg = "";
            if (po != null && po.Length > 1)
            {
                cap = po[0] + "";
                msg = po[1] + "";
            }
            else if (po != null && po.Length > 0) msg = po[0] + "";
            Collection.MiMFa_MessageType typ = Collection.MiMFa_MessageType.Null;
            if (_alertmsg) typ = Collection.MiMFa_MessageType.Alert;
            else if (_errormsg) typ = Collection.MiMFa_MessageType.Error;
            else if (_informationmsg) typ = Collection.MiMFa_MessageType.Text;
            else if (_riskmsg) typ = Collection.MiMFa_MessageType.Risk;
            else if (_successmsg) typ = Collection.MiMFa_MessageType.Success;
            var dr = show(msg, cap, typ);
            if (_binary)
                if (dr == System.Windows.Forms.DialogResult.Yes) return true;
                else return false;
            return dr;
        }
        public System.Windows.Forms.DialogResult show(string message,string caption = "", Collection.MiMFa_MessageType typ = Collection.MiMFa_MessageType.Text)
        {
            if (_circleview) return MiMFa_MessageBoxService.ShowFormCircle(caption, _translate, typ, message);
            return (MCL.UserInterface == null) ? MiMFa_MessageBoxService.ShowConsole(caption, _translate, typ, message): MiMFa_MessageBoxService.ShowMessageBox(caption, _translate, typ, message);
        }

        #endregion
    }
}
