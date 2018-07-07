using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;
using System.Net.NetworkInformation;
using MiMFa_Framework.Network;
using System.Net;
using MiMFa_Framework.General;
using System.Windows;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class GET  : CommandBase
    {
        public override string description => "Get information or stored value";
        public GET() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _concatwords = false;
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
        #endregion

        #region Property Switch => PROPERTY or FIELD (Any Type & get;set;)
        public virtual string separatetext { get; set; } = " ";
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
        public override bool IsNotNullInput { get; set; } = false;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        public override object EXECUTE(params object[] po)
        {
            return echo(po);
        }

        public override object execute(object obj, int index, int length)
        {
            if (obj == null) return Null;
            string str = (obj + "").ToLower();
            Model.MiMFa_List<object> objlist = new Model.MiMFa_List<object>();
            foreach (var item in str.Split(' ', ','))
            {
                switch (item.Trim())
                {
                    case "inf":
                    case "info":
                    case "detail":
                    case "details":
                        obj = MCL.Display.BreakLineSign
                            + "Name: " + MCL.Name + MCL.Display.BreakLineSign
                            + "Description: " + MCL.Description + MCL.Display.BreakLineSign
                            + "Version: " + MCL.Version + MCL.Display.BreakLineSign
                            + "Made By: MiMFa" + MCL.Display.BreakLineSign
                            + "Programmer: MuhaMad Fathi" + MCL.Display.BreakLineSign
                            ;
                        break;
                    case "mac":
                    case "mediaaccesscontrol":
                        obj = mac();
                        break;
                    case "macs":
                    case "mediaaccesscontrols":
                        obj = macs();
                        break;
                    case "ips":
                    case "ipas":
                    case "InternetProtocols":
                    case "InternetProtocoladdresses":
                        obj = ips();
                        break;
                    case "ip":
                    case "ipa":
                    case "InternetProtocol":
                    case "InternetProtocoladdresse":
                    case "ipv4":
                    case "ipav4":
                        obj = ipv4();
                        break;
                    case "ipv6":
                    case "ipav6":
                        obj = ipv6();
                        break;
                    case "hn":
                    case "cn":
                    case "hostname":
                    case "computername":
                        obj = hostname();
                        break;
                    case "dt":
                    case "date":
                        obj = date();
                        break;
                    case "tm":
                    case "time":
                        obj = time();
                        break;
                    case "vs":
                    case "vid":
                    case "volumeserial":
                        obj = volumeserial();
                        break;
                    case "vss":
                    case "vids":
                    case "volumesserial":
                    case "volumeserials":
                        obj = volumesserial();
                        break;
                    case "vp":
                    case "vps":
                    case "vsp":
                    case "volumepartition":
                    case "volumepartitions":
                    case "volumespartition":
                        obj = volumespartitions();
                        break;
                    case "vm":
                    case "vsm":
                    case "vms":
                    case "volumesmodel":
                    case "volumemodels":
                        obj = volumesmodel();
                        break;
                    case "ps":
                    case "pid":
                    case "processorserial":
                        obj = processorserial();
                        break;
                    case "pss":
                    case "pids":
                    case "processorsserial":
                    case "processorserials":
                        obj = processorsserial();
                        break;
                    case "ms":
                    case "mbs":
                    case "mid":
                    case "mbid":
                    case "motherboardserial":
                        obj = motherboardserial();
                        break;
                    case "mss":
                    case "mbss":
                    case "mids":
                    case "mbids":
                    case "motherboardserials":
                    case "motherboardsserial":
                        obj = motherboardsserial();
                        break;
                    case "mp":
                    case "mypath":
                        obj = Config.ApplicationPath;
                        break;
                    case "ws":
                    case "wsl":
                    case "vl":
                    case "vsl":
                    case "var":
                    case "vars":
                    case "variable":
                    case "variables":
                    case "variableslist":
                    case "workspacelist":
                        obj = MiMFa_CommandLanguage.WorkSpaceList;
                        break;
                    case "put":
                    case "puts":
                        obj = MCL.PutsDic;
                        break;
                    case "hl":
                    case "hsl":
                    case "handlerslist":
                        obj = MiMFa_CommandLanguage.HandlersList;
                        break;
                    case "cl":
                    case "csl":
                    case "commandslist":
                        obj = MiMFa_CommandLanguage.CommandsDic;
                        break;
                    case "cb":
                    case "tcb":
                    case "clipboard":
                    case "textclipboard":
                        obj = Clipboard.GetText();
                        break;
                    case "icb":
                    case "imageclipboard":
                        obj = Clipboard.GetImage();
                        break;
                    case "dcb":
                    case "docb":
                    case "dataclipboard":
                    case "dataobjectclipboard":
                        obj = Clipboard.GetDataObject();
                        break;
                    case "fcb":
                    case "fdcb":
                    case "fileclipboard":
                    case "filedropclipboard":
                        obj = Clipboard.GetFileDropList();
                        break;
                    case "acb":
                    case "ascb":
                    case "audioclipboard":
                    case "audiostreamclipboard":
                        obj = Clipboard.GetAudioStream();
                        break;
                    case "ca":
                    case "cfa":
                    case "confa":
                    case "conffa":
                    case "configfileaddress":
                    case "configurationaddress":
                    case "configurationfileaddress":
                        obj = Config.ConfigFile;
                        break;
                    case "confd":
                    case "conffd":
                    case "configfiledirectory":
                    case "configurationdirectory":
                    case "configurationfiledirectory":
                        obj = Config.ConfigurationDirectory;
                        break;
                    case "conf":
                    case "conff":
                    case "configfile":
                    case "configuration":
                    case "configurationfile":
                        obj = Config.ConfigDic;
                        break;
                    case "cd":
                    case "dir":
                    case "directory":
                    case "currentdirectory":
                        obj = Config.ApplicationPath;
                        break;
                    case "site":
                    case "website":
                        obj = Config.ProductURL;
                        break;
                    case "oh":
                    case "help":
                    case "onlinehelp":
                        obj = MCL.Parser(typeof(GO).Name + " \"" + Config.ProductHelpURL + "\";");
                        break;
                    case "lang":
                    case "language":
                        obj = MiMFa_LanguageReader.Language;
                        break;
                    case "rd":
                    case "rsd":
                    case "rdic":
                    case "rsdic":
                    case "resultsdic":
                    case "resultsdictionary":
                        obj = MCL.ResultsDic;
                        break;
                    case "desc":
                    case "description":
                        obj = MCL.Description;
                        break;
                    case "ui":
                    case "userinterface":
                        obj = MCL.UserInterface;
                        break;
                    case "ver":
                    case "version":
                        obj = MCL.Version;
                        break;
                    case "0":
                        obj = MCL.root0;
                        break;
                    case "1":
                        obj = MCL.root1;
                        break;
                    case "2":
                        obj = MCL.root2;
                        break;
                    default:
                        obj = SET.get(str);
                        break;
                }
                objlist.Add(obj);
            }
            if (!_concatwords && index < length - 1) return objlist + separatetext;
            return objlist;
        }

        private object time()
        {
            return Configuration.Default.Time;
        }
        private object date()
        {
            return Configuration.Default.Date;
        }
        private string hostname()
        {
            return MiMFa_GetDetail.GetHostName();
        }
        private List<IPAddress> ips()
        {
            return MiMFa_GetDetail.GetInternalIPs();
        }
        private IPAddress ipv4()
        {
            return MiMFa_GetDetail.GetInternalIPv4();
        }
        private IPAddress ipv6()
        {
            return MiMFa_GetDetail.GetInternalIPv6();
        }
        public virtual PhysicalAddress mac()
        {
            return MiMFa_GetDetail.GetMAC();
        }
        public virtual List<PhysicalAddress> macs()
        {
            return MiMFa_GetDetail.GetMACs();
        }
        public virtual string processorserial()
        {
            return MiMFa_GetDetail.ProcessorSerial();
        }
        public virtual List<string> processorsserial()
        {
            return MiMFa_GetDetail.ProcessorsSerial();
        }
        public virtual string volumeserial()
        {
            return MiMFa_GetDetail.VolumeSerial();
        }
        public virtual List<string> volumesserial()
        {
            return MiMFa_GetDetail.VolumesSerial();
        }
        public virtual List<string> volumesmodel()
        {
            return MiMFa_GetDetail.VolumesModel();
        }
        public virtual List<uint> volumespartitions()
        {
            return MiMFa_GetDetail.VolumesPartitions();
        }
        public virtual string motherboardserial()
        {
            return MiMFa_GetDetail.MotherBoardSerial();
        }
        public virtual List<string> motherboardsserial()
        {
            return MiMFa_GetDetail.MotherBoardsSerial();
        }
        #endregion
    }
}
