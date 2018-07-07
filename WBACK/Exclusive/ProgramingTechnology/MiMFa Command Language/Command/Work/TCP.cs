using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using MiMFa_Framework.Network.TCP;
using MiMFa_Framework.Model;
using System.Net;
using System.Windows.Forms;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class TCP : CommandBase
    {
        public override string description => "Work with Tcp protocol";
        public TCP() : base()
        {
            timer.Tick += (o, e) =>
            {
                if (content != Null)
                    MCL.SetToResultDic(-1, MCL.Display.Done(content));
                content = Null;
            };
            timer.Interval = 1;
        }

        #region Allowance Switch => FIELD (bool)
        public bool _pause = false;
        public bool _receive = false;
        public bool _send = false;
        public bool _mode1 = false;
        public bool _mode2 = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool P
        {
            get { return _pause; }
            set
            {
                //if (_)  = value;
                //else
                _pause = value;
            }
        }
        public virtual bool R
        {
            get { return _receive; }
            set
            {
                //if (_)  = value;
                //else
                _receive = value;
            }
        }
        public virtual bool S
        {
            get { return _send; }
            set
            {
                //if (_)  = value;
                //else
                _send = value;
            }
        }
        public virtual bool M
        {
            get { return _mode1; }
            set
            {
                if (_mode1) { _mode2 = value; _mode1 = false; }
                else _mode1 = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual int port { get; set; } = 7952;
        public virtual int buffer { get; set; } = 1024 * 1024;
        public virtual int sendtimeout { get; set; } = 3000;
        public virtual int receivetimeout { get; set; } = 3000;
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
        public override object EXECUTE(params object[] po)
        {
            timer.Enabled = !_stop;
            if (_mode1) return mode1(po);
            if (_mode2) return mode2(po);
            return mode0(po);
        }
        object content = Null;
        Timer timer = new Timer();
        MiMFa_Receiver reciever = null;
        MiMFa_Sender sender = null;
        public virtual object mode0(params object[] po)
        {
            if (reciever == null)
            {
                reciever = new MiMFa_Receiver();
                sender = new MiMFa_Sender();
                reciever.EndReceiveData += (o, ip, i) => content= echo(o).ToString();
                sender.EndSendData += (o, ip, i) => content = echo(ip).ToString();
            }
            sender.BufferSize = reciever.BufferSize = buffer;
            sender.Port = reciever.Port = port;
            reciever.Timeout = receivetimeout;
            sender.Timeout = sendtimeout;
            sender.Run = reciever.Run = !_pause;
            if ((_send || s)&&po.Length > 1  )
            {
                for (int i = 1; i < po.Length; i++)
                    sender.Start(po[0], po[i].ToString());//
                return Null;
            }
            else if (_receive || r)
                if (po != null && po.Length > 0)
                    for (int i = 0; i < po.Length; i++)
                        reciever.Start(IPAddress.Parse(po[i].ToString()));
                else reciever.Start(IPAddress.Any);
            return Null;
        }
        MiMFa_DataTransit dt = null;
        public virtual object mode1(params object[] po)
        {
            if (dt == null)
            {
                dt = new MiMFa_DataTransit();
                dt.EndDownloadData += (o, ip, i) => content = echo(o).ToString();
            }
            dt.BufferSize = buffer;
            dt.Port = port;
            dt.SendTimeout = sendtimeout;
            dt.ReceiveTimeout = receivetimeout;
            dt.Run = !_pause;
            if ((_send || s)&&po.Length > 1  )
                {
                    for (int i = 1; i < po.Length; i++)
                    dt.Send(po[0], po[i].ToString());//
                return Null;
            }
            else if (_receive || r)
                if (po != null && po.Length > 0)
                    for (int i = 0; i < po.Length; i++)
                        dt.Receive(IPAddress.Parse(po[i].ToString()));
                else dt.Receive(IPAddress.Any);
            return Null;
        }
        public virtual object mode2(params object[] po)
        {
            if (dt == null)
            {
                dt = new MiMFa_DataTransit();
                dt.EndDownloadData += (o, ip, i) => content = echo(o).ToString();
            }
            dt.BufferSize = buffer;
            dt.Port = port;
            dt.SendTimeout = sendtimeout;
            dt.ReceiveTimeout = receivetimeout;
            dt.Run = !_pause;
            if ((_send || s)&&po.Length > 1  )
                {
                    for (int i = 1; i < po.Length; i++)
                    dt.SocketSend(po[0], po[i].ToString());//
                return Null;
            }
            else if (_receive || r)
                if (po != null && po.Length > 0)
                    for (int i = 0; i < po.Length; i++)
                        dt.SocketReceive(IPAddress.Parse(po[i].ToString()));
                else dt.SocketReceive(IPAddress.Any);
            return Null;
        }
        #endregion
    }
}
