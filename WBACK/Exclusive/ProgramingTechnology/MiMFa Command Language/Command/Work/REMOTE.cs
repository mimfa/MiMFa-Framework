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
using MiMFa_Framework.Exclusive.Security;
using MiMFa_Framework.Network;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class REMOTE : CommandBase
    {
        public override string description => "Remote local clients";
        public REMOTE() : base()
        {
            timer.Interval = 1;
            timer.Tick += (o, e) =>
            {
                if (content != Null)
                {
                    string st = "";
                    MCL.SetToResultDic(-9, st = MCL.Parse(content.ToString()));
                    bool sen = false;
                    int trl = 0;
                    while (!sen && trl < 15) try
                    { reciever.Send(st); sen = true;  }
                    catch { trl++; }
                }
                if (contentcallback != Null)
                    MCL.SetToResultDic(-91, MCL.Display.Done(contentcallback));
                contentcallback = Null; content = Null;
                 
            };
        }

        #region Allowance Switch => FIELD (bool)
        public bool _ip = false;
        public bool _password = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool I
        {
            get { return _ip; }
            set
            {
                //if (_)  = value;
                //else
                _ip = value;
            }
        }
        public virtual bool P
        {
            get { return _password; }
            set
            {
                //if (_)  = value;
                //else
                _password = value;
            }
        }
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual int port { get; set; } = 7959;
        public virtual int buffer { get; set; } = 1024 * 1024;
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
        public override bool IsCrudeInput { get; set; } = true;
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = false;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            if (_stop) { reciever.Stop();sender.Stop(); reciever = null; sender = null; }
            else if (_start) Start(po);
            else if (!_new && ipaddress != null && _password)
            {
                string[] stra = po[0].ToString().Split(',');
                setpassword(stra[0].Trim(), stra[1].Trim());
                return Null;
            }
            else if (Start(po))
                sender.Start(po[0],ipaddress);
            return Null;
        }

        private bool Start(params object[] po)
        {
            timer.Enabled = !_stop;
            if (_new || ipaddress == null || reciever == null || sender == null)
            {
                if (_password)
                {
                    string[] stra = po[0].ToString().Split(',');
                    setpassword("", stra.Last().Trim());
                    if (stra.Length > 1) po[0] = MiMFa_CollectionService.GetAllItems(MiMFa_CollectionService.GetPart(stra, 0, stra.Length - 1), ",", 0);
                    else po[0] = "";
                }
                ipaddress = IPAddress.Any;
                if (_all) ipaddress = IPAddress.Any;
                else try
                    {
                        ipaddress = IPAddress.Parse(MCL.Parse(po[0] + ""));
                    }
                    catch { }
                reciever = new MiMFa_Receiver();
                sender = new MiMFa_Sender();
                sender.Port = reciever.Port = port;
                sender.BufferSize = reciever.BufferSize = buffer;
                reciever.EndReceiveData += (b, ip, i) =>
                {
                    object o = MiMFa_IOService.Deserialize(b);
                    if (string.IsNullOrEmpty(password)) content = o;
                    else if (!MiMFa_CollectionService.ExistIn(remotedic, ip.Address))
                        remotedic.Add(ip.Address, crypt.GetHashString(o.ToString()));
                    else if (remotedic[ip.Address] == password) content = o;
                    else remotedic[ip.Address] = crypt.GetHashString(o.ToString());
                };
                reciever.SendCallBackData += (o, ip, i) =>
                {
                    contentcallback = o;
                };
                reciever.Start(ipaddress);
                if (ipaddress != IPAddress.Any) sender.InterlocutorIP = ipaddress;
                return false;
            }
            if (ipaddress != IPAddress.Any) sender.InterlocutorIP = ipaddress;
            else if (sender.InterlocutorIP == null || _ip || i)
                try
                {
                    string[] stra = po[0].ToString().Split(',');
                    ipaddress = sender.InterlocutorIP = IPAddress.Parse(stra.First().Trim());
                    if (stra.Length > 1) po[0] = MiMFa_CollectionService.GetAllItems(stra, ",", 1);
                    else po[0] = "";
                }
                catch { }
          sender.Port = reciever.Port = port; 
            sender.BufferSize = reciever.BufferSize = buffer;
            sender.Run = reciever.Run = !_stop;
            return true;
        }
        public void setpassword(string oldpass,string newpass)
        {
            if (crypt.GetHashString(oldpass) == password) password = crypt.GetHashString(newpass);
            else throw new Exception("Old Password is not valid");
        }

        object content = Null;
        object contentcallback = Null;
        Timer timer = new Timer();
        static IPAddress ipaddress = null;
        static private Dictionary<IPAddress,string> remotedic = new Dictionary<IPAddress, string>();
        static private string password = "";
        static MiMFa_Receiver reciever = null;
        static MiMFa_Sender sender = null;
        static MiMFa_Cryptography crypt = new MiMFa_Cryptography();
        #endregion
    }
}
