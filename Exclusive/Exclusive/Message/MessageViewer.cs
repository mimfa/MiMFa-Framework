using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.Language;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.Message
{
    public class MessageViewer
    {
        public Control Container = null;
        public Control Label = null;
        public Color ForeColor = Color.Transparent;
        public Color BackColor = Color.Transparent;
        public Image Image = null;

        public string Message = "";
        public List<string> Logs = new List<string>();
        public MiMFa_MessageType MessageType = MiMFa_MessageType.Text;
        public int LenghtTime = 10;
        public Timer Timer = new Timer();

        public event EventHandler ShowMessage = (o, a) => { };
        public event EventHandler HideMessage = (o, a) => { };

        public MessageViewer()
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = 1000;
            Timer.Enabled = true;
        }

        public string Get(MiMFa_MessageType messageType,int lenghtTime,params string[] keys)
        {
            string message = MiMFa_LanguageReader.GetText(messageType, keys);
            switch (messageType)
            {
                case MiMFa_MessageType.Success:
                    return Success(message, lenghtTime);
                case MiMFa_MessageType.Alert:
                    return Alert(message, lenghtTime);
                case MiMFa_MessageType.Error:
                    return Error(message, lenghtTime);
                case MiMFa_MessageType.Text:
                    return Text(message, lenghtTime);
                default:
                    return message;
            }
        }
        public string Get(int lenghtTime,params string[] keys)
        {
            return Get(MessageType, lenghtTime, keys);
        }
        public string Get(params string[] keys)
        {
            return Get(MessageType, -1, keys);
        }
        public string Get(MiMFa_MessageType messageType,params string[] keys)
        {
            return Get(messageType,-1, keys);
        }
        public string Success(string message = "", int lenghtTime = -1)
        {
            ForeColor = SuccessForeColor;
            BackColor = SuccessBackColor;
            Image = SuccessImage;
            MessageType = MiMFa_MessageType.Success;
            Start(message,lenghtTime);
            return Message;
        }
        public string Alert(string message = "", int lenghtTime = -1)
        {
            ForeColor = AlertForeColor;
            BackColor = AlertBackColor;
            Image = AlertImage;
            MessageType = MiMFa_MessageType.Alert;
            Start(message,lenghtTime);
            return Message;
        }
        public string Error(string message = "", int lenghtTime = -1)
        {
            ForeColor = ErrorForeColor;
            BackColor = ErrorBackColor;
            Image = ErrorImage;
            MessageType = MiMFa_MessageType.Error;
            Start(message,lenghtTime);
            return Message;
        }
        public string Text(string message = "", int lenghtTime = -1)
        {
            ForeColor = TextForeColor;
            BackColor = TextBackColor;
            Image = TextImage;
            MessageType = MiMFa_MessageType.Text;
            Start(message,lenghtTime);
            return Message;
        }
        public string Success(params string[] keys)
        {
            string message = MiMFa_LanguageReader.GetText(MiMFa_MessageType.Success, keys);
            ForeColor = SuccessForeColor;
            BackColor = SuccessBackColor;
            Image = SuccessImage;
            MessageType = MiMFa_MessageType.Success;
            Start(message,-1);
            return Message;
        }
        public string Alert(params string[] keys)
        {
            string message = MiMFa_LanguageReader.GetText(MiMFa_MessageType.Alert, keys);
            ForeColor = AlertForeColor;
            BackColor = AlertBackColor;
            Image = AlertImage;
            MessageType = MiMFa_MessageType.Alert;
            Start(message, -1);
            return Message;
        }
        public DialogResult DialogAlert(params string[] message)
        {
            return Service.MiMFa_MessageBoxService.Show(MiMFa_MessageType.Alert,message);
        }
        public DialogResult DialogError(params string[] message)
        {
            return Service.MiMFa_MessageBoxService.Show(MiMFa_MessageType.Error,message);
        }
        public DialogResult DialogSuccess(params string[] message)
        {
            return Service.MiMFa_MessageBoxService.Show(MiMFa_MessageType.Success,message);
        }
        public DialogResult DialogText(params string[] message)
        {
            return Service.MiMFa_MessageBoxService.Show(MiMFa_MessageType.Text,message);
        }
        public DialogResult DialogRisk(params string[] message)
        {
            return Service.MiMFa_MessageBoxService.Show(MiMFa_MessageType.Risk,message);
        }
        public string Error(params string[] keys)
        {
            string message = MiMFa_LanguageReader.GetText(MiMFa_MessageType.Error, keys);
            ForeColor = ErrorForeColor;
            BackColor = ErrorBackColor;
            Image = ErrorImage;
            MessageType = MiMFa_MessageType.Error;
            Start(message, -1);
            return Message;
        }
        public string Text(params string[] keys)
        {
            string message = MiMFa_LanguageReader.GetText(MiMFa_MessageType.Text, keys);
            ForeColor = TextForeColor;
            BackColor = TextBackColor;
            Image = TextImage;
            MessageType = MiMFa_MessageType.Text;
            Start(message, -1);
            return Message;
        }

        public Image SuccessImage = null;
        public Color SuccessForeColor = Color.White;
        public Color SuccessBackColor = Color.DarkGreen;
        public Image ErrorImage = null;
        public Color ErrorForeColor = Color.White;
        public Color ErrorBackColor = Color.Red;
        public Image AlertImage = null;
        public Color AlertForeColor = Color.White;
        public Color AlertBackColor = Color.OrangeRed;
        public Image TextImage = null;
        public Color TextForeColor = Color.White;
        public Color TextBackColor = Color.DarkMagenta;

        int Time = 0;
        private void Start(string message,int lenghtTime)
        {
            ShowMessage(this, EventArgs.Empty);
            Time = 0;
            Logs.Add(Message = message);
            if(lenghtTime >= 0) LenghtTime = lenghtTime;
            if (Container != null)
                MiMFa_Framework.Service.MiMFa_ControlService.SetControlThreadSafe(Container, new Action<object[]>((oa) => {
                    Container.BackColor = BackColor;
                    Container.ForeColor = ForeColor;
                    Container.BackgroundImage = Image;
                }), new object[] { });
            if (Label != null)
                MiMFa_Framework.Service.MiMFa_ControlService.SetControlThreadSafe(Label, new Action<object[]>((oa) => {
                    Label.Visible = true;
                    Label.Text = Message;
                }), new object[] { });
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Time++ < LenghtTime) return;
            HideMessage(this, EventArgs.Empty);
            if (Container != null)
                MiMFa_Framework.Service.MiMFa_ControlService.SetControlThreadSafe(Container, new Action<object[]>((oa) =>
                {
                    Container.BackColor = Color.Transparent;
                    Container.ForeColor = Color.Transparent;
                    Container.BackgroundImage = null;
                }), new object[] { });
            if (Label != null)
                MiMFa_Framework.Service.MiMFa_ControlService.SetControlThreadSafe(Label, new Action<object[]>((oa) =>
                {
                    Label.Visible = false;
                    Label.Text = "";
                }), new object[] { });
        }
    }
}
