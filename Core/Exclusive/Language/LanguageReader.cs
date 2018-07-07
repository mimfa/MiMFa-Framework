using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MiMFa_Framework;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.Accessibility;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.ProgramingTechnology.DataBase;
using MiMFa_Framework.Service;
using System.IO;


namespace MiMFa_Framework.Exclusive.Language
{

    public static class MiMFa_LanguageReader
    {
        #region Property
        private static string SignInternalParameter = "¶";
        private static string SignTryTranslate = "§";
        private static string SignNoTranslate = "▬";
        private static string SignFullTranslate = "↨";
        private static string SplitSign = " | ";
        private static MiMFa_Language _Language = MiMFa_Language.Persian;
        private static MiMFa_Language MainLanguage = MiMFa_Language.Null;
        private static Properties.Settings DIC = Properties.Settings.Default;
        public static Address Address = new Address();
        public static MiMFa_PropertyToContentInjection PTCI = new MiMFa_PropertyToContentInjection('¶', Application.CompanyName);
        public static MiMFa_MessageType MessageType = MiMFa_MessageType.Text;
        public static RightToLeft RTL = RightToLeft.Yes;
        public static Image Flag = Properties.Resources.Flag_Iran;
        public static string Name = "پارسی";
        public static bool Start = false;
        public static bool WithNormalization = true;
        public static bool WithWordSpace = true;
        public static string Conditions = " COLLATE NOCASE";
        private static bool _CaseSensitive = false;
        public static string ConfigurationTableName = "Configuration";
        public static string TextTableName = MiMFa_MessageType.Text.ToString();
        public static string SuccessTableName = MiMFa_MessageType.Success.ToString();
        public static string AlertTableName = MiMFa_MessageType.Alert.ToString();
        public static string ErrorTableName = MiMFa_MessageType.Error.ToString();
        public static string[] ResultSpliter = new string[] { SplitSign };
        public static MiMFa_SQLite db = new MiMFa_SQLite(LanguagePath);

        public static string LanguageDirectory
        {
            get { return Address.ThisDirectory; }
            set
            {
                Address.ThisDirectory = value;
                Restart();
            }
        }
        public static MiMFa_Language Language
        {
            get { return _Language; }
            set
            {
                _Language = value;
                Restart();
            }
        }
        public static string LanguagePath { get; set; } = Address.ThisDirectory + Language + Address.LANGExtension;
        public static bool CaseSensitive
        {
            get { return _CaseSensitive; }
            set
            {
                if (!(_CaseSensitive = value))
                {
                    if (!MiMFa_StringService.ExistAny(Conditions,false , "COLLATE NOCASE")) Conditions += " " + "COLLATE NOCASE";
                }
                else Conditions = Conditions.Replace("COLLATE NOCASE", "");
            }
        }
        #endregion

        #region Translate        
        
        /// <summary>
        /// if key start with:
        /// ¶ (Alt + 20): is Internal Parameter & Converted to than Parameter
        /// § (Alt + 21): if cant translated, no changed
        /// ▬ (Alt + 22): No Translate, No Change
        /// 
        /// Example: ¶FName => MyNameParameter
        /// Example: §FName => FirstName
        /// Example: ▬FName => FName
        /// </summary>
        /// <param name="Keys"></param>
        /// <returns></returns>  
        public static string GetReverseText(params string[] Keys)
        {
            if (!Start) Restart();
            string result = "";
            for (int i = 0; i < Keys.Length; i++)
            {
                string word = "";
                if (Keys[i].StartsWith(SignInternalParameter)) word = GetInternalParameter(Keys[i]);
                else if (Language == MainLanguage) word += Keys[i]
                    .Replace(SignInternalParameter, "")
                    .Replace(SignNoTranslate, "")
                    .Replace(SignFullTranslate, "")
                    .Replace(SignTryTranslate, "");
                else if (Keys[i].StartsWith(SignNoTranslate)) word = GetNoTranslate(Keys[i]);
                else if (Keys[i].StartsWith(SignFullTranslate)) word = GetReverseFullTranslate(Keys[i]);
                else if (DIC == null || string.IsNullOrEmpty(word = GetFromDIC(Keys[i]))) word = GetReverseTranslate(Keys[i]);
                result += word;
                if (i < Keys.Length - 1 && !string.IsNullOrEmpty(word.Trim()) && WithWordSpace) result += " ";
            }
            return GetInternalParameter(result);
        }

        /// <summary>
        /// if key start with:
        /// ¶ (Alt + 20): is Internal Parameter & Converted to than Parameter
        /// § (Alt + 21): if cant translated, no changed
        /// ▬ (Alt + 22): No Translate, No Change
        /// ↨ (Alt + 23): Full Translate
        /// 
        /// Example: ¶FName => MyNameParameter
        /// Example: §FName => FirstName
        /// Example: ▬FName => FName
        /// </summary> 
        public static string GetText(params string[] Keys)
        {
            if (!Start) Restart();
            string result = "";
            for (int i = 0; i < Keys.Length; i++)
            {
                string word = "";
                if (string.IsNullOrEmpty(Keys[i])) continue;
                else if (Keys[i].StartsWith(SignInternalParameter)) word = GetInternalParameter(Keys[i]);
                else if (Language == MainLanguage) word += Keys[i]
                        .Replace(SignInternalParameter, "")
                        .Replace(SignNoTranslate, "")
                        .Replace(SignFullTranslate, "")
                        .Replace(SignTryTranslate, "");
                else if (Keys[i].StartsWith(SignNoTranslate)) word = GetNoTranslate(Keys[i]);
                else if (Keys[i].StartsWith(SignFullTranslate)) word = GetFullTranslate(Keys[i]);
                else if (DIC == null || string.IsNullOrEmpty(word = GetFromDIC(Keys[i]))) word = GetTranslate(Keys[i]);
                result += (WithNormalization) ? MiMFa_StringService.ReplaceWithAllWordBetween(MiMFa_StringService.ReplaceWithAllWordBetween(word, "(", ")", ""), "[", "]", "") : word;
                if (i < Keys.Length - 1 && !string.IsNullOrEmpty(word.Trim()) && WithWordSpace) result += " ";
            }
            return GetInternalParameter(result);
        }

        /// <summary>
        /// if key start with:
        /// ¶ (Alt + 20): is Internal Parameter & Converted to than Parameter
        /// § (Alt + 21): if cant translated, no changed
        /// ▬ (Alt + 22): No Translate, No Change
        /// ↨ (Alt + 23): Full Translate
        /// 
        /// Example: ¶FName => MyNameParameter
        /// Example: §FName => FirstName
        /// Example: ▬FName => FName
        /// </summary>
        public static string[] GetTextArray(params string[] Keys)
        {
            string[] stra = new string[Keys.Length];
            for (int i = 0; i < Keys.Length; i++)
                stra[i] = GetText(Keys[i]);
            return PTCI.CheckStringArray(stra);
        }

        /// <summary>
        /// if key start with:
        /// ¶ (Alt + 20): is Internal Parameter & Converted to than Parameter
        /// § (Alt + 21): if cant translated, no changed
        /// ▬ (Alt + 22): No Translate, No Change
        /// ↨ (Alt + 23): Full Translate
        /// 
        /// Example: ¶FName => MyNameParameter
        /// Example: §FName => FirstName
        /// Example: ▬FName => FName
        /// </summary>
        public static string GetText(MiMFa_MessageType messageType, params string[] Keys)
        {
            MessageType = messageType;
            return GetText(Keys);
        }

        /// <summary>
        /// if key start with:
        /// ¶ (Alt + 20): is Internal Parameter & Converted to than Parameter
        /// § (Alt + 21): if cant translated, no changed
        /// ▬ (Alt + 22): No Translate, No Change
        /// ↨ (Alt + 23): Full Translate
        /// 
        /// Example: ¶FName => MyNameParameter
        /// Example: §FName => FirstName
        /// Example: ▬FName => FName
        /// </summary>
        public static string[] GetTextArray(MiMFa_MessageType messageType, params string[] Keys)
        {
            MessageType = messageType;
            return GetTextArray(Keys);
        }

        public static string GetInternalParameter(string str)
        {
            return PTCI.CheckString(str);
        }
        public static string GetNoTranslate(string str)
        {
            return str.Replace(SignNoTranslate, "");
        }
        public static string GetFromDIC(string str)
        {
            foreach (var item in DIC.Properties)
                if ((item.ToString().ToLower() == str.Replace(SignInternalParameter, "").Replace(SignTryTranslate, "").Replace(SignNoTranslate, "").ToLower()))
                   return DIC[item.ToString()].ToString();
            return null;
        }
        public static string GetFullTranslate(string str)
        {
            str = str.Replace(SignFullTranslate, "");
            string[] sa = str.Split(new string[] { " " }, StringSplitOptions.None);
            List<KeyValuePair<bool, string>> dic = new List<KeyValuePair<bool, string>>();
            if (sa.Length > 1)
                for (int i = 0; i < sa.Length; i++)
                {
                    string s = GetText(sa[i]);
                    dic.Add(new KeyValuePair<bool, string>(s != sa[i], s));
                }
            else dic.Add(new KeyValuePair<bool, string>(false, str));
            for (int i = 0; i < dic.Count; i++)
                if (!dic[i].Key)
                {
                    sa = MiMFa_Convert.ToSeparatedWords(dic[i].Value).Split(new string[] { " " }, StringSplitOptions.None);
                    if (sa.Length > 1)
                    {
                        dic[i] = new KeyValuePair<bool, string>(true,"");
                        foreach (var itm in sa)
                            dic[i] = new KeyValuePair<bool, string>(dic[i].Key, dic[i].Value + " " + GetText(itm));
                    }
                }
            string word = "";
            foreach (var item in dic)
            {
                word += item.Value;
                if (!string.IsNullOrEmpty(item.Value.Trim()))
                    word += " ";
            }
            if (word.Length > 0) word = word.Substring(0, word.Length - 1);
            return word;
        }
        public static string GetTranslate(string str)
        {
            string tablename;
            switch (MessageType)
            {
                case MiMFa_MessageType.Success:
                    tablename = SuccessTableName;
                    break;
                case MiMFa_MessageType.Alert:
                    tablename = AlertTableName;
                    break;
                case MiMFa_MessageType.Error:
                    tablename = ErrorTableName;
                    break;
                default:
                    tablename = TextTableName;
                    break;
            }
            try
            {
                string ss = "";
                object obj = null;
                obj = db.GetValue(tablename, str, Conditions);
                if (obj != null)
                    return obj.ToString().Split(ResultSpliter, StringSplitOptions.None)[0];
                else if (str.StartsWith(SignTryTranslate))
                    if ((obj = db.GetValue(tablename, str = str.Replace(SignTryTranslate, ""), Conditions)) != null)
                        return obj.ToString().Split(ResultSpliter, StringSplitOptions.None)[0];
                    else return str;
                else if ((obj = db.GetValue(tablename, ss = MiMFa_Convert.ToSeparatedWords(str), Conditions)) != null)
                    return obj.ToString().Split(ResultSpliter, StringSplitOptions.None)[0];
                if (ss.Contains(" ")) return GetFullTranslate(str);
            }
            catch { }
            return str;
        }

        public static string GetReverseFullTranslate(string str)
        {
            string word = "";
            foreach (var item in (MiMFa_Convert.ToSeparatedWords(str.Replace(SignFullTranslate, ""))).Split(' '))
            {
                var it = GetReverseText(item);
                word += it;
                if (!string.IsNullOrEmpty(it.Trim()))
                    word += " ";
            }
            return word;
        }
        public static string GetReverseTranslate(string str)
        {
            string tablename;
            switch (MessageType)
            {
                case MiMFa_MessageType.Success:
                    tablename = SuccessTableName;
                    break;
                case MiMFa_MessageType.Alert:
                    tablename = AlertTableName;
                    break;
                case MiMFa_MessageType.Error:
                    tablename = ErrorTableName;
                    break;
                default:
                    tablename = TextTableName;
                    break;
            }
            object obj = null;
                obj = db.GetKeys(tablename, str, Conditions)[0];
            if (obj != null)
                return obj.ToString().Split(new string[] { SplitSign }, StringSplitOptions.None)[0];
            else if (str.StartsWith(SignTryTranslate) && (obj = db.GetKeys(tablename,str = str.Replace(SignTryTranslate, ""), Conditions)) != null)
                return ((object[])obj)[0].ToString().Split(ResultSpliter, StringSplitOptions.None)[0];
            else if ((obj = db.GetKeys(tablename, MiMFa_Convert.ToSeparatedWords(str), Conditions)[0]) != null)
                return obj.ToString().Split(new string[] { SplitSign }, StringSplitOptions.None)[0];
            else return GetReverseFullTranslate(str);
        }
        #endregion

        #region Config
        public static void Restart()
        {
            Start = true;
            //db.ShowException = false;
            db.Start(LanguagePath);
            db.CreateDic(ConfigurationTableName, "BLOB");
            db.CreateDic(SuccessTableName, "TEXT");
            db.CreateDic(ErrorTableName, "TEXT");
            db.CreateDic(AlertTableName, "TEXT");
            db.CreateDic(TextTableName, "TEXT");
            //SaveConfiguration();
            UpdateConfiguration();
        }
        public static void ChangeLanguage(MiMFa_Language language)
        {
            LanguagePath = Address.ThisDirectory + language + Address.LANGExtension;
            Language = language;
            Restart();
        }
        public static void ChangeLanguage(string language)
        {
            LanguagePath = Address.ThisDirectory + language + Address.LANGExtension;
            Restart();
        }
        public static void ChangeLanguagePath(string path)
        {
            LanguagePath = path;
            Restart();
        }
        public static void SetValue(string key, object value, MiMFa_MessageType messageType = MiMFa_MessageType.Text)
        {
            if (!Start) Restart();
            string mt;
            switch (MessageType)
            {
                case MiMFa_MessageType.Success:
                    mt = SuccessTableName;
                    break;
                case MiMFa_MessageType.Alert:
                    mt = AlertTableName;
                    break;
                case MiMFa_MessageType.Error:
                    mt = ErrorTableName;
                    break;
                default:
                    mt = TextTableName;
                    break;
            }
            db.SetValue(mt, key, value);
        }

        public static void SaveConfiguration()
        {
            db.SetValue(ConfigurationTableName, "Name", Name, true);
            db.SetValue(ConfigurationTableName, "Language", Language, true);
            db.SetValue(ConfigurationTableName, "RightToLeft", RTL, true);
            db.SetValue(ConfigurationTableName, "Flag", MiMFa_Convert.ToByteArray(Flag));
        }
        public static void UpdateConfiguration()
        {
            try
            {
                Name = db.GetValue(ConfigurationTableName, "Name", true).ToString();
                _Language = (MiMFa_Language)db.GetValue(ConfigurationTableName, "Language", true);
                RTL = (RightToLeft)db.GetValue(ConfigurationTableName, "RightToLeft", true);
                Flag = (Bitmap)db.GetValue(ConfigurationTableName, "Flag");
            }
            catch{ }
        }

        #endregion
    }
}

