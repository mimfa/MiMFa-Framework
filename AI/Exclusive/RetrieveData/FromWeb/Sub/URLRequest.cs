using MiMFa_Framework.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.RetrieveData.FromWeb
{
    [Serializable]
    public struct URLRequest
    {
        public bool AllowReplaceValue { get; set; }
        public string DefaultValue { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }

        public override string ToString() => string.Join("=", Name , Value);

        public URLRequest(URLRequest req)
        {
            Name = req.Name;
            Value = req.Value;
            DefaultValue = req.DefaultValue;
            Title = req.Title;
            AllowReplaceValue = req.AllowReplaceValue;
        }
        public URLRequest(string name,string value, string title, bool allowUse = true,bool toValidURLCharacters = true)
        {
            if (toValidURLCharacters)
            {
                Name = MiMFa_Convert.ToValidURLCharacters(name);
                Value = DefaultValue = MiMFa_Convert.ToValidURLCharacters(value);
            }
            else
            {
                Name = name;
                Value = DefaultValue = value;
            }
            Title = title;
            AllowReplaceValue = allowUse;
        }
        public URLRequest(string name, string defaultValue, string value, string title, bool allowUse = true, bool toValidURLCharacters = true)
        {
            if (toValidURLCharacters)
            {
                Name = MiMFa_Convert.ToValidURLCharacters(name);
                Value = MiMFa_Convert.ToValidURLCharacters(value);
                DefaultValue = MiMFa_Convert.ToValidURLCharacters(defaultValue);
            }
            else
            {
                Name = name;
                Value = value;
                DefaultValue = defaultValue;
            }
            Title = title;
            AllowReplaceValue = allowUse;
        }

    }
}
