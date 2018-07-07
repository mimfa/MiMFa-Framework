using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Exclusive.Language;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage.Command
{
    public class DOWNLOAD : CommandBase
    {
        public override string description => "Download data from external address";
        public override string structure =>
            name
            + " "
            + "\"http://\" "
            + MCLTools.SplitSign
            + " \""
            + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + "\\MyFile "+name.ToLower() + ".ext"
            + "\" "
            + MCLTools.SignCharacterSSwitch
            + "_file "
            + MCLTools.SignFinish;
        public override int structureindex => structure.Length -( 35 + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).Length);

        public DOWNLOAD() : base()
        {
        }

        #region Allowance Switch => FIELD (bool)
        public bool _data;
        public bool _file;
        public bool _string = false;
        #endregion

        #region Character Switch => PROPERTY (bool & get;set;)
        public virtual bool D
        {
            get { return _data; }
            set
            {
                //if (_)  = value;
                //else
                _data = value;
            }
        }
        public virtual bool F
        {
            get { return _file; }
            set
            {
                //if (_)  = value;
                //else
                _file = value;
            }
        }
        public virtual bool S
        {
            get { return _string; }
            set
            {
                //if (_)  = value;
                //else
                _string = value;
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
        public override bool IsNotNullInput { get; set; } = true;
        public override bool IsReturnResult { get; set; } = true;
        #endregion

        #region Function Switch => METHOD
        System.Net.WebClient wc = new System.Net.WebClient();
        public override object EXECUTE(params object[] po)
        {
            if (po == null || po.Length < 0) return Null;
            wc = new System.Net.WebClient();
			if(_process) wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
			if(_process || _print) wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
            if (_file)return file(po);
            return echo(po);
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled) MCL.SetToResultDic(-99, e.Error.Message);
            else MCL.SetToResultDic(-90,MiMFa_LanguageReader.GetText( "Download Completed"));
        }

        private void Wc_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            MCL.SetToResultDic(-97, "|" + e.ProgressPercentage + "%| " + e.BytesReceived + " Bytes from " + e.TotalBytesToReceive);
        }

        public override object execute(object obj,int index, int length)
        {
            if (obj == null) return Null;
            if(_string)return wc.DownloadString(obj.ToString());
            if(_data)return wc.DownloadData(obj.ToString());
            return Null;
        }

        public virtual object file(params object[] po)
        {
            if (po == null || po.Length < 0) return Null;
                wc.DownloadFile(po[0].ToString(), PATH.getpath(po.Last().ToString()));
            return Null;
        }
        #endregion
    }
}
