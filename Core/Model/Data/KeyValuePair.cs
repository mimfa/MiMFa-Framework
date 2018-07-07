using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_KeyValuePair<T, F>
    {
        public enum DisplayMember
        { KeyValue, Key, Value }

        public T Key { get; set; }
        public F Value { get; set; }
        public MiMFa_KeyValuePair(T key, F value)
        {
            Key = key;
            Value = value;
        }

        public string MiddleSign { get; set; } = " -> ";
        public DisplayMember Display { get; set; } = DisplayMember.Value;

        public override string ToString()
        {
            switch (Display)
            {
                case DisplayMember.Key:
                    return Key.ToString();
                case DisplayMember.Value:
                    return Value.ToString();
                default:
                    return Key + MiddleSign + Value;
            }
        }

        public static explicit operator KeyValuePair<T,F>(MiMFa_KeyValuePair<T, F> mkvp) => new KeyValuePair<T, F>(mkvp.Key, mkvp.Value);
        public static explicit operator MiMFa_KeyValuePair<T,F>(KeyValuePair<T, F> kvp) => new MiMFa_KeyValuePair<T, F>(kvp.Key, kvp.Value);
    }
}
