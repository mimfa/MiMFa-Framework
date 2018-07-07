using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiMFa_Framework.Service;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.Tools.Pickup
{
    public class MiMFa_Pickup : MiMFa_ProviderTools
    {
        public virtual string ReplaceSign { get; set; } = "" + "PICKED" + ""/*(Alt + 900)STR(Alt + 900)*/;
        public virtual string StartSign { get; set; } = "{";
        public virtual string EndSign { get; set; } = "}";
        public virtual bool CaseSensitive { get; set; } = false;
        public static int NumberOfPick { get; set; } = 0;
        public static char HideSign => '';

        public MiMFa_Pickup(string replaceSign, string startSign, string endSign,bool caseSensitive = false)
        {
            ReplaceSign = replaceSign;
            StartSign = startSign;
            EndSign = endSign;
            CaseSensitive = caseSensitive;
        }

        public Dictionary<string, string> SignDic = new Dictionary<string, string>();

        public virtual void Start()
        {
            SignDic.Clear();
        }

        public virtual string Pick(string MRLCode)
        {
            Dictionary<int, string> dim = new Dictionary<int, string>();
            string sign = ReplaceSignCreator(NumberOfPick++);
            MRLCode = MiMFa_StringService.ReplaceWithAllWordBetween(MRLCode, StartSign, EndSign,(i,s)=> sign + i + HideSign, out dim, CaseSensitive);
            SignDic = new Dictionary<string, string>();
            foreach (var item in dim)
                SignDic.Add(sign + item.Key + HideSign, item.Value);
            return MRLCode;
        }
        public virtual string RePick(string MRLCode)
        {
            Dictionary<int, string> dim = new Dictionary<int, string>();
            string sign = ReplaceSignCreator(NumberOfPick++);
            MRLCode = MiMFa_StringService.ReplaceWithAllWordBetween(MRLCode, StartSign, EndSign, (i, s) => sign + i + HideSign, out dim, CaseSensitive);
            foreach (var item in dim)
                SignDic.Add(sign + item.Key + HideSign, item.Value);
            return MRLCode;
        }
        public virtual string Replace(string MRLCode,string sign = "")
        {
            Dictionary<int, string> dim = new Dictionary<int, string>();
            return MiMFa_StringService.ReplaceWithAllWordBetween(MRLCode, StartSign, EndSign,(i,s)=> sign, out dim, CaseSensitive);
        }

        public virtual string Parse(string MRLCode, params object[] po)
        {
            if (MRLCode.Contains(ReplaceSign))
                foreach (var item in SignDic)
                    MRLCode = MRLCode.Replace(item.Key,item.Value);
            return MRLCode;
        }
        public virtual string FullParse(string MRLCode, params object[] po)
        {
            if (MRLCode.Contains(ReplaceSign))
            {
                int si = StartSign.Length;
                int ei = EndSign.Length;
                foreach (var item in SignDic)
                    MRLCode.Replace(item.Key, item.Value.Substring(si, item.Value.Length-ei));
            }
            return MRLCode;
        }
        public virtual string ParseTo(string MRLCode, string sign = "")
        {
            if (MRLCode.Contains(ReplaceSign))
                foreach (var item in SignDic)
                    MRLCode = MRLCode.Replace(item.Key, sign);
            return MRLCode;
        }
        private string ReplaceSignCreator(int number)
        {
            return HideSign + NumberOfPick++ + HideSign + ReplaceSign;
        }
    }
}
