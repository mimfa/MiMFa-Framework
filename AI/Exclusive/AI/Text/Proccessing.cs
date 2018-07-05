using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.AI.Text
{
    public class MiMFa_TextProccessing
    {
        public static MiMFa_Percent NameLikePerCent(string str1, string str2)
        {
            MiMFa_Percent p = LikePerCent(str1, str2);
            if (p.Positive > 70) return p;
            str1 = MiMFa_Convert.ToSeparatedWordsFast(str1).ToLower();
            str2 = MiMFa_Convert.ToSeparatedWordsFast(str2).ToLower();
            var lst1 = str1.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", "؛", ";", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries);
            var lst2 = str2.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", "؛", ";", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries);
            p = new MiMFa_Percent();
            decimal f = 100 / Math.Max(lst1.Length, lst2.Length);
            for (int i = 0; i < lst1.Length; i++)
                for (int j = 0; j < lst2.Length; j++)
                    if (lst1[i].Length > lst2[j].Length)
                    { if (lst1[i].StartsWith(lst2[j])) { p.AddValue(f); break; } }
                    else
                    { if (lst2[j].StartsWith(lst1[i])) { p.AddValue(f); break; } }
            return p;
        }

        public static MiMFa_Percent LikePerCent(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, 0, 100);
            if (string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str2)) return new MiMFa_Percent(-100, 0, 0);
            if (!string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, -100, 0);
            MiMFa_Percent percent;
            if ((percent = ComparePerCent(str1, str2)).Both > 70) return percent;
            List<string> lst1 = str1.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", "؛", ";", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lst2 = str2.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", "؛", ";", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (lst1.Count < 2 && lst2.Count < 2) return percent.Normalization();
            if ((lst1.Count >= 2 * lst2.Count) || (lst2.Count >= 2 * lst1.Count))
                return new MiMFa_Percent(-100, 0, 0);
            decimal unit = Convert.ToDecimal(93) / ((lst2.Count + lst1.Count) / 2);
            percent = new MiMFa_Percent(-7, 0, 0);
            MiMFa_Percent newf = new MiMFa_Percent(0, 0, 0);
            MiMFa_Percent maxf = new MiMFa_Percent(0, 0, 0);
            int maxindex = -1;
            for (int i = 0; i < lst1.Count; i++)
            {
                maxf = new MiMFa_Percent(0, 0, 0);
                for (int j = 0; j < lst2.Count; j++)
                {
                    newf = ComparePerCent(lst1[i], lst2[j]);
                    if (newf > maxf)
                    {
                        maxf.SetValue(newf);
                        maxindex = j;
                    }
                }
                if (maxf > 50)
                {
                    if (maxindex > -1) lst2.RemoveAt(maxindex);
                    percent.AddValue((maxf / 100) * unit);
                }
                else percent.AddValue(-unit);
            }
            return percent.Normalization();
        }
        public static MiMFa_Percent ComparePerCent(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, 0, 100);
            if (string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str2)) return new MiMFa_Percent(-100, 0, 0);
            if (!string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, -100, 0);
            if (str1 == str2) return new MiMFa_Percent(0, 0, 100);
            str1 = str1.Trim().Replace(Environment.NewLine, " ").Replace("   ", " ").Replace("  ", " ");
            str2 = str2.Trim().Replace(Environment.NewLine, " ").Replace("   ", " ").Replace("  ", " ");
            if (str1 == str2) return new MiMFa_Percent(-1, 0, 99);
            int ct = str1.CompareTo(str2);
            if (ct == 0) return new MiMFa_Percent(-5, 0, 95);
            string str1l = str1.ToLower();
            string str2l = str2.ToLower();
            if (str1l == str2l)
            {
                MiMFa_Percent mm = new MiMFa_Percent(0, 0, 90);
                decimal fu = Convert.ToDecimal(10) / str1.Length;
                for (int i = 0; i < str1.Length; i++)
                    mm.AddValue((str1[i] == str2[i]) ? fu : -fu);
                return mm.Normalization();
            }
            ct = str1l.CompareTo(str2l);
            if (ct == 0) return new MiMFa_Percent(-10, 0, 90);
            decimal unit = Convert.ToDecimal(100) / ((str2.Length + str1.Length) / 2);
            int telor = Math.Abs(str1.Length - str2.Length);
            decimal tu = telor * unit;
            if (str1.Contains(str2l) || str2l.Contains(str1))
                return (new MiMFa_Percent(-tu, 0, 100 - tu)).Normalization();
            if (str1l.Contains(str2l) || str2l.Contains(str1l))
                return (new MiMFa_Percent(-10 - tu, 0, 90 - tu)).Normalization();
            if (str1.Length < 2 || str2.Length < 2) return new MiMFa_Percent(-100, 0, 0);
            int m1 = str1.Length / 2;
            int m2 = str2.Length / 2;
            MiMFa_Percent percent1 = ComparePerCent(str1.Substring(0, m1), str2.Substring(0, m2)) / 2;
            MiMFa_Percent percent2 = ComparePerCent(str1.Substring(m1), str2.Substring(m2)) / 2;
            MiMFa_Percent percent = percent1 + percent2;
            percent.Normalization();
            if (percent.Positive > 60) return percent;
            string s1 = str1, s2 = str2;
            if (str1.Length < str2.Length)
            {
                s1 = str2;
                s2 = str1;
            }
            int j = 0;
            percent = new MiMFa_Percent(-30, 0, 0);
            for (int i = 0; i < s2.Length; i++)
                if (s1[i] != s2[j++] && s1[i] != s2[(j>0)?j - 1: 0])
                    percent.AddValue(-unit);
                else
                    percent.AddValue(unit);
            percent.AddValue(-tu);
            percent = percent.Normalization();
            return percent;
        }

        public static MiMFa_Percent ContentLikePerCent(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, 0, 100);
            if (string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str2)) return new MiMFa_Percent(-100, 0, 0);
            if (!string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, -100, 0);
            MiMFa_Percent percent;
            if (((percent = ContentComparePerCent(str1, str2))) > 70) return percent;
            List<string> lst1 = GetKeywords(str1).ValueList;
            List<string> lst2 = GetKeywords(str2).ValueList;
            List<string> nlst1 = str1.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", ";", "؛", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> nlst2 = str2.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", ";", "؛", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (lst1.Count < 2 * nlst1.Count / 3 || lst2.Count < 2 * nlst2.Count / 3)
            {
                lst1 = nlst1;
                lst2 = nlst2;
            }
            else return ContentComparePerCent(MiMFa_CollectionService.GetAllItems(lst1, " "), MiMFa_CollectionService.GetAllItems(lst2, " "));
            if (lst1.Count < 2 && lst2.Count < 2) return percent.Normalization();
            if ((lst1.Count >= 2 * lst2.Count) || (lst2.Count >= 2 * lst1.Count))
                return new MiMFa_Percent(-100, 0, 0);
            decimal unit = Convert.ToDecimal(93) / ((lst2.Count + lst1.Count) / 2);
            percent = new MiMFa_Percent(-7, 0, 0);
            MiMFa_Percent newf = new MiMFa_Percent(0, 0, 0);
            MiMFa_Percent maxf = new MiMFa_Percent(0, 0, 0);
            int maxindex = -1;
            for (int i = 0; i < lst1.Count; i++)
            {
                maxf = new MiMFa_Percent(0, 0, 0);
                for (int j = 0; j < lst2.Count; j++)
                {
                    newf = ContentComparePerCent(lst1[i], lst2[j]);
                    if (newf > maxf)
                    {
                        maxf.SetValue(newf);
                        maxindex = j;
                    }
                }
                if (maxf > 50)
                {
                    if (maxindex > -1) lst2.RemoveAt(maxindex);
                    percent.AddValue((maxf / 100) * unit);
                }
                else percent.AddValue(-unit);
            }
            return percent.Normalization();
        }
        public static MiMFa_Percent ContentComparePerCent(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, 0, 100);
            if (string.IsNullOrEmpty(str1) && !string.IsNullOrEmpty(str2)) return new MiMFa_Percent(-100, 0, 0);
            if (!string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) return new MiMFa_Percent(0, -100, 0);
            if (str1 == str2) return new MiMFa_Percent(0, 0, 100);
            str1 = str1.Trim().Replace(Environment.NewLine, " ").Replace("   ", " ").Replace("  ", " ");
            str2 = str2.Trim().Replace(Environment.NewLine, " ").Replace("   ", " ").Replace("  ", " ");
            if (str1 == str2) return new MiMFa_Percent(-1, 0, 99);
            int ct = str1.CompareTo(str2);
            if (ct == 0) return new MiMFa_Percent(-5, 0, 95);
            string str1l = str1.ToLower();
            string str2l = str2.ToLower();
            if (str1l == str2l)
            {
                MiMFa_Percent mm = new MiMFa_Percent(0, 0, 90);
                decimal fu = Convert.ToDecimal(10) / str1.Length;
                for (int i = 0; i < str1.Length; i++)
                    mm.AddValue((str1[i] == str2[i]) ? fu : -fu);
                return mm.Normalization();
            }
            ct = str1l.CompareTo(str2l);
            if (ct == 0) return new MiMFa_Percent(-10, 0, 90);
            MiMFa_Percent percent = ContentSameWordPerCent(str1, str2);
            percent = percent.Normalization();
            return percent;
        }
        public static MiMFa_Percent ContentSameWordPerCent(string str1, string str2)
        {
            MiMFa_Percent mp = new MiMFa_Percent(0, 0, 0);
            MiMFa_Percent nnmp = new MiMFa_Percent(0, 0, 0);
            str1 = (str1 + "").ToUpper();
            str2 = (str2 + "").ToUpper();
            string[] sa1 = str1.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", "؛", ";", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries);
            string[] sa2 = str2.Split(new string[] { "   ", "  ", " ", "&", ",", "،", "'", "`", ":", "؛", ";", ".", "?", "؟", "!" }, StringSplitOptions.RemoveEmptyEntries);
            int l = Math.Abs(sa1.Length - sa2.Length);
            List<string> lmin = new List<string>();
            List<string> lmax = new List<string>();
            if (sa1.Length > sa2.Length) { lmin = sa2.ToList(); lmax = sa1.ToList(); }
            else { lmin = sa1.ToList(); lmax = sa2.ToList(); }
            if (l == 0) mp.AddValue(20, true);
            else if (l == 1) mp.AddValue(-50);
            else if ((lmin.Count - l) < 0) mp.AddValue(-100);
            else mp.AddValue(-50);
            decimal unit = 100 / lmin.Count;
            mp.AddValue(-unit * l);
            for (int i = 0; i < lmin.Count; i++)
            {
                for (int j = 0; j < Math.Min(lmax.Count, lmin.Count); j++)
                    if (lmin[i].Contains(lmax[j]) || lmax[j].Contains(lmin[i]))
                        if (lmin[i] == lmax[j])
                        {
                            mp.AddValue(unit);
                            lmax.RemoveAt(j);
                            break;
                        }
                        else
                        {
                            if (i == 0 || i >= lmin.Count - 1) mp.AddValue(-100);
                            else mp.AddValue(-unit);
                            lmax.RemoveAt(j);
                            break;
                        }
                    else if ((nnmp = ComparePerCent(lmin[i], lmax[j])).Positive > 60)
                    {
                        mp.AddValue(nnmp.Positive*unit/100);
                    }
                    else if (i >= lmin.Count - 1)
                    {
                        mp.AddValue(-1 * unit);
                    }
            }
            if (mp.Negative < -1 * unit && mp.Positive >= 100) mp.AddValue(-100);
            return mp;
        }

        public static MiMFa_KeyWords<int, string> GetKeywords(string text)
        {
            MiMFa_KeyWords<int, string> kws = new MiMFa_KeyWords<int, string>();
            List<string> ls = 
                MiMFa_CollectionService.Distinct(
                MiMFa_CollectionService.ExecuteInAllItems(
                MiMFa_CollectionService.Concat(
                GetKeywordFromStruct(text),
                GetKeywordFromAnd(text),
                GetKeywordFromComma(text),
                GetKeywordFromNumber(text),
                GetKeywordFromEqual(text),
                GetKeywordFromParenthesis(text),
                GetKeywordFromBrackets(text),
                GetKeywordFromBraces(text),
                GetKeywordFromQuotation(text),
                GetKeywordFromDoubleQuotation(text)
                ),(t)=> t
                .Replace("."," ")
                .Replace(",", " ")
                .Replace("،", " ")
                .Replace("؛", " ")
                .Replace(";", " ")
                .Replace("?", " ")
                .Replace("؟", " ")
                .Replace("!", " ")
                .Replace("'", " ")
                .Replace("`", " ")
                .Replace("\"", " ")
                .Replace("(", " ")
                .Replace(")", " ")
                .Replace("[", " ")
                .Replace("]", " ")
                .Replace("{", " ")
                .Replace("}", " ")
                .Replace("&", " ")
                .Trim()));
            foreach (var item in ls)
                kws.Add(MiMFa_StringService.NumberOfWordsInText(text,item), item);
            return kws;
        }
        public static List<string> GetKeywordFromAnd(string text)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] sta = text.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < sta.Length; i++)
                {
                    var st = sta[i].Split(new string[] { " ", "'", "`" }, StringSplitOptions.RemoveEmptyEntries);
                    if (i > 0) ls.Add(st.First());
                    if (i < sta.Length - 1) ls.Add(st.Last());
                }
            }
            catch { }

            return ls;
        }
        public static List<string> GetKeywordFromComma(string text)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] sta = text.Split(new string[] { ",", "،" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < sta.Length; i++)
                {
                    var st = sta[i].Split(new string[] { " ", "'", "`" }, StringSplitOptions.RemoveEmptyEntries);
                    if (i > 0) ls.Add(st.First());
                    if (i < sta.Length - 1) ls.Add(st.Last());
                }
            }
            catch { }

            return ls;
        }
        public static List<string> GetKeywordFromNumber(string text)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] sta = text.Split(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < sta.Length; i++)
                {
                    var st = sta[i].Split(new string[] { " ", "'", "`" }, StringSplitOptions.RemoveEmptyEntries);
                    if (i > 0) ls.Add(st.First());
                    if (i < sta.Length - 1) ls.Add(st.Last());
                }
            }
            catch { }
            return ls;
        }
        public static List<string> GetKeywordFromEqual(string text)
        {
            List<string> ls = new List<string>();
            try
            {
                string[] sta = text.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < sta.Length; i++)
                {
                    var st = sta[i].Split(new string[] { "=", "\n", ";", "؛" }, StringSplitOptions.RemoveEmptyEntries);
                    if (i > 0) ls.Add(st.First());
                    if (i < sta.Length - 1) ls.Add(st.Last());
                }
            }
            catch { }
            return ls;
        }
        public static List<string> GetKeywordFromParenthesis(string text)
        {
            List<string> ls = MiMFa_StringService.GetAllWordsBetween(text, "(", ")", false);
            return ls;
        }


        public static List<string> GetKeywordFromBrackets(string text)
        {
            List<string> ls = MiMFa_StringService.GetAllWordsBetween(text, "[", "]", false);
            return ls;
        }
        public static List<string> GetKeywordFromBraces(string text)
        {
            List<string> ls = new List<string>();
            try
            {
                var sta = MiMFa_StringService.GetAllWordsBetween(text, "{", "}", false);
                for (int i = 0; i < sta.Count; i++)
                {
                    var st = sta[i].Split(new string[] { ",", "،", "\n", ";" }, StringSplitOptions.RemoveEmptyEntries);
                    if (i > 0) ls.Add(st.First());
                    if (i < sta.Count - 1) ls.Add(st.Last());
                }
            }
            catch { }

            return ls;
        }
        public static List<string> GetKeywordFromQuotation(string text)
        {
            List<string> ls = MiMFa_StringService.GetAllWordsBetween(text, "'", "'", false);
            return ls;
        }
        public static List<string> GetKeywordFromDoubleQuotation(string text)
        {
            List<string> ls = MiMFa_StringService.GetAllWordsBetween(text, "\"", "\"", false);
            return ls;
        }
        public static List<string> GetKeywordFromStruct(string text)
        {
            List<string> ls = new List<string>();
            List<string> sen = GetSentences(text);
            try
            {
                foreach (var item in sen)
                {
                    string[] sta = item.Split(new string[] { "  ", " ", "'", "`"}, StringSplitOptions.RemoveEmptyEntries);
                    if (sta.Length > 0 && sta.Length < 5) ls.AddRange(sta);
                    else
                        for (int i = 1; i < sta.Length; i++)
                            if (sta[i - 1].Length <= sta[i].Length || sta[i].Length == 1) ls.Add(sta[i]);
                }
            }
            catch { }

            return ls;
        }

        public static List<string> GetSentences(string text)
        {
            return text.Split(new string[] { ".", ";", "؛", "\n", "!", "؟", "?" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static List<string> NamesListCompletion(List<string> namesList)
        {
            List<string> result = new List<string>();
            List<List<string>> com = new List<List<string>>();
            string[] splittor = new string[] { " ", "." };
            try
            {
                com = (from name in namesList
                       where Statement.And((from part in name.Split(splittor, StringSplitOptions.RemoveEmptyEntries)
                                            select part.Length > 1).ToArray())
                       select name.Split(splittor, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
            }
            catch { }
            foreach (var item in namesList)
            {
                string[] arr = item.Split(splittor, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    result.Add(MiMFa_CollectionService.GetAllItems(com.Find((name)=>
                    {
                        if (arr.Length != name.Count) return false;
                        for (int i = 0; i < name.Count; i++)
                            if (!name[i].StartsWith(arr[i])) return false;
                        return true;
                    })," "));
                } catch { result.Add(item); }
            }

            return result;
        }

    }
}
