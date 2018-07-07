using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.ProgramingTechnology.ReportLanguage;
using MiMFa_Framework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage
{
    public class Options
    {

        public Options()
        {
        }
        
        public bool CaseSensivity { get; set; } = false;
        public bool Relax { get; set; } = false;
        public object FunctionResult { get; set; }
        public string UserName => Environment.UserName;
        public string MachineName => Environment.MachineName;
        public string UserDomainName => Environment.UserDomainName;
        public string IPv4 => MiMFa_Framework.Network.MiMFa_Net.GetInternalIPv4().ToString();
        public string MAC => MiMFa_Framework.Network.MiMFa_Net.GetMAC().ToString();

        public string Translate(string word)
        {
            return MiMFa_Framework.Exclusive.Language.MiMFa_LanguageReader.GetText(MiMFa_MessageType.Text, word);
        }
        public string Translate(params string[] words)
        {
            return MiMFa_Framework.Exclusive.Language.MiMFa_LanguageReader.GetText(MiMFa_MessageType.Text, words);
        }
        public void UpdateTranslator(string key, string value)
        {
            MiMFa_MessageType mt = MiMFa_MessageType.Text;

            Language.MiMFa_LanguageReader.SetValue(
                key, value, mt);
        }
    }
}
