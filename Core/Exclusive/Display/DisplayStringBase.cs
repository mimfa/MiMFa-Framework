using MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage;
using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using MiMFa_Framework.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.Display
{
    public abstract class MiMFa_DisplayStringBase
    {
        public virtual string SignTranslate { get; set; } = "";
        public virtual bool Translate { get; set; } = false;
        public virtual bool InternalParameterTranslate
        {
            get { return SignTranslate.Contains("¶"); }
            set
            {
                if (Translate = value) SignTranslate = "¶"+ SignTranslate;
                else SignTranslate.Replace("¶", "");
            }
        }
        public virtual bool TryTranslate
        {
            get { return SignTranslate.Contains("§"); }
            set
            {
                if (Translate = value) SignTranslate = "§"+ SignTranslate;
                else SignTranslate.Replace("§", "");
            }
        }
        public virtual bool NoTranslate
        {
            get { return SignTranslate.Contains("▬"); }
            set
            {
                if (Translate = value) SignTranslate = "▬"+ SignTranslate;
                else SignTranslate.Replace("▬", "");
            }
        }
        public virtual bool FullTranslate
        {
            get { return SignTranslate.Contains("↨"); }
            set
            {
                if (Translate = value) SignTranslate = "↨"+ SignTranslate;
                else SignTranslate.Replace("↨", "");
            }
        }

        public bool AllowMime = false;
        public bool AllowDictionary = true;
        public bool AllowKeyValuePair = true;
        public bool AllowList = true;
        public bool AllowArray = true;
        public bool AllowCollection = true;
        public bool AllowStack = true;
        public bool AllowDataTable = true;
        public bool AllowDataRow = true;
        public bool AllowEnum = true;
        public bool AllowBitmap = true;
        public bool AllowByte = true;
        public bool AllowEventPack = true;
        public bool AllowString = true;
        public bool AllowUri = true;

        public virtual string TempDirectory { get; set; } = Configuration.Default.ApplicationPath + @"Temp\";
        public virtual string StartSign { get; set; } = "";
        public virtual string MiddleSign { get; set; } = "=";
        public virtual string PointerSign { get; set; } = "->";
        public virtual string EndSign { get; set; } = "";
        public virtual string SplitSign { get; set; } = ", ";
        public virtual string TabSign { get; set; } = "\t ";
        public virtual string BreakSign { get; set; } = Environment.NewLine;
        public virtual string BreakLineSign { get; set; } = "----------------------------------" + Environment.NewLine;
        public virtual string Table_ { get; set; } = "----------------------------------" + Environment.NewLine;
        public virtual string TableRow_ { get; set; } = "_________________________________" + Environment.NewLine;
        public virtual string TableCell_ { get; set; } = "";
        public virtual string _TableCell { get; set; } = "\t\t";
        public virtual string _TableRow { get; set; } = Environment.NewLine + "_________________________________";
        public virtual string _Table { get; set; } = Environment.NewLine + "----------------------------------";
        public virtual Func<string, string> Highlight { get; set; } = (s) => " «" + s + "» ";

        public virtual object TryDone(object obj)
        {
            if (obj == null) return "";
            Type t = obj.GetType();
            string tn = t.Name.ToLower();

            if (AllowDictionary &&( t is IDictionary || tn.StartsWith("dictionary") || tn.StartsWith("mimfa_dictionary")))
                return Done(MiMFa_Convert.ToDictionary(obj));
            if (AllowDictionary && (tn.StartsWith("mimfa_matrix")))
                return Done(MiMFa_Convert.ToMiMFaMatrix(obj));
            if (AllowKeyValuePair && tn.StartsWith("keyvaluepair"))
                return Done(MiMFa_Convert.ToKeyValuePair(obj));
            if (AllowList && (t is IList || tn.StartsWith("list") || tn.StartsWith("mimfa_list")))
                return Done(MiMFa_Convert.ToList(obj));
            if (AllowByte && AllowArray && t == typeof(byte[]))
                return Done((byte[])obj);
            if (AllowArray && tn.EndsWith("[]"))
                return Done(MiMFa_Convert.ToArray(obj));
            if (AllowCollection && t is ICollection)
                return Done(MiMFa_Convert.ToArray(obj));
            if (AllowStack && tn.StartsWith("stack"))
                return Done(MiMFa_Convert.ToStack(obj));
            if (AllowStack && tn.StartsWith("queue"))
                return Done(MiMFa_Convert.ToQueue(obj));
            if (AllowDataTable && tn.StartsWith("datatable"))
                return Done((DataTable)obj);
            if (AllowDataRow && tn.StartsWith("datarow"))
                return Done((DataRow)obj);
            if (AllowEnum && obj is Enum)
                return Done(obj + "");
            if (AllowBitmap && obj is Bitmap)
                return Done((Bitmap)obj);
            if (AllowUri && obj is Uri)
                return Done((Uri)obj);
            if (AllowEventPack && obj is EventPack)
                return Done((EventPack)obj);
            if (AllowByte && obj is byte)
                return Done((byte)obj);
            if (AllowString && obj is String)
                return Done(obj + "");
            if (double.NaN.Equals(obj))
                return "NaN";
            if (t == typeof(Int64) || t == typeof(long))
                return Done(Convert.ToInt64(obj));
            if (t == typeof(UInt64) || t == typeof(Double))
                return Done(Convert.ToDouble(obj));
            return Normalization(obj);
        }
        public virtual String Done(object obj, bool withStartAndEndSign = false)
        {
            return (withStartAndEndSign)? StartSign + Done(TryDone(obj) + "") + EndSign : Done(TryDone(obj) + "");
        }
        public virtual object Normalization(object obj)
        {
            return (AllowMime)?  DoneByMime(obj):obj;
        }
        private object DoneByMime(object arg)
        {
            string ext = MiMFa_GetDetail.GetMimeObject(arg).Split('/').First().Trim().ToLower();
            try
            {
                switch (ext)
                {
                    case "image":
                        return Done(Image.FromStream(new System.IO.MemoryStream(MiMFa_IOService.Serialize(arg))));
                    default:
                        return arg;
                }
            }
            catch { return arg; }
        }
        public virtual String Done(string arg)
        {
            if (Translate) arg = Language.MiMFa_LanguageReader.GetText(SignTranslate + (arg));
            return arg;
        }
        public virtual String Done<T>(T[] arg)
        {
            if (arg == null) return "";
            string str = "";
            for (int i = 0; i < arg.Length; i++)
                str += Done(arg[i]) + SplitSign;
            if (str.Length > SplitSign.Length) return str.Substring(0, str.Length - SplitSign.Length);
            return "";
        }
        public virtual String Done<T>(IList<T> arg)
        {
            if (arg == null) return "";
            string str = "";
            for (int i = 0; i < arg.Count; i++)
                str += Done(arg[i]) + TabSign;
            if (str.Length > TabSign.Length) return str.Substring(0, str.Length - TabSign.Length);
            return "";
        }
        public virtual String Done<T>(MiMFa_Matrix<T> arg)
        {
            if (arg == null) return "";
            string str = "";
            for (int i = 0; i < arg.Count; i++)
                str += Done(arg[i]) + BreakSign;
            if (str.Length > BreakSign.Length) return str.Substring(0, str.Length - BreakSign.Length);
            return "";
        }
        public virtual String Done<T, F>(IDictionary<T, F> arg)
        {
            if (arg == null) return "";
            string str = "";
            foreach (var item in arg)
                str += Done(item) + BreakSign;
            if (str.Length > BreakSign.Length) return str.Substring(0, str.Length - BreakSign.Length);
            return "";
        }
        public virtual String Done<T, F>(KeyValuePair<T, F> arg)
        {
            string str = "";
            str += Done(arg.Key) + PointerSign + Done(arg.Value);
            return str;
        }
        public virtual String Done<T>(Stack<T> arg)
        {
            if (arg == null) return "";
            string str = "";
            var ar = arg.ToList();
            for (int i = 0; i < ar.Count; i++)
                str += Done(ar[i]) + BreakSign;
            if (str.Length > BreakSign.Length) return str.Substring(0, str.Length - BreakSign.Length);
            return "";
        }
        public virtual String Done<T>(Queue<T> arg)
        {
            if (arg == null) return "";
            string str = "";
            var ar = arg.ToList();
            for (int i = 0; i < ar.Count; i++)
                str += Done(ar[i]) + BreakSign;
            if (str.Length > BreakSign.Length) return str.Substring(0, str.Length - BreakSign.Length);
            return "";
        }
        public virtual String Done(DataTable arg)
        {
            if (arg == null) return "";
            string str = "";
            str += TableRow_;
            foreach (DataColumn item in arg.Columns)
                str += TableCell_ + Done(item.ColumnName) + _TableCell;
            str += _TableRow;
            foreach (DataRow item in arg.Rows)
                str += Done(item);
            return Table_ + str + _Table;
        }
        public virtual String Done(DataRow arg)
        {
            if (arg == null) return "";
            string str = "";
            foreach (var item in arg.ItemArray)
                str += TableCell_ + Done(item) + _TableCell;
            return TableRow_ + str + _TableRow;
        }
        public virtual String Done(EventPack arg)
        {
            return arg.Target;
        }
        public virtual String Done(Bitmap arg)
        {
            string address = TempDirectory + DateTime.Now.Ticks + ".jpg";
            arg.Save(address);
            Process.Start(address);
            return null;
        }
        public virtual String Done(Uri arg)
        {
            return arg.OriginalString;
        }
        public virtual String Done(byte[] arg)
        {
            if (arg == null) return "";
            string ext = "data";
            try { ext = MiMFa_GetDetail.GetMimeObject(arg).Split('/').Last().Trim().Split(' ').First(); } catch { }
            string address = TempDirectory + DateTime.Now.Ticks + "." + ext; System.IO.File.WriteAllBytes(address,arg);
            Process.Start(address);
            return null;
        }
        public virtual String Done(byte arg)
        {
            return arg + "";
        }
        public virtual String Done(long arg)
        {
            return arg + "";
        }
        public virtual String Done(double arg)
        {
            if (Double.IsPositiveInfinity(arg)) return "∞";
            if (Double.IsNegativeInfinity(arg)) return "-∞";
            return arg + "";
        }

        public virtual bool CaseSensitiveSearch { get; set; } = false;
        public virtual object TrySearch(object inObj, bool showAll, bool highlight, params object[] theseObjects)
        {
            if (showAll && !highlight) return inObj;
            if (inObj == null) return "";
            Type t = inObj.GetType();
            string tn = t.Name.ToLower();
            try
            {
                if (AllowDictionary && (t is IDictionary || tn.StartsWith("dictionary") || tn.StartsWith("mimfa_dictionary")))
                    return Search(MiMFa_Convert.ToDictionary(inObj), showAll, highlight, theseObjects);
                if (AllowKeyValuePair && tn.StartsWith("keyvaluepair"))
                    return Search(MiMFa_Convert.ToKeyValuePair(inObj), showAll, highlight, theseObjects);
                if (AllowList && (t is IList || tn.StartsWith("list") || tn.StartsWith("mimfa_list")))
                    return Search(MiMFa_Convert.ToList(inObj), showAll, highlight, theseObjects);
                if (AllowArray && tn.EndsWith("[]"))
                    return Search(MiMFa_Convert.ToArray(inObj), showAll, highlight, theseObjects);
                if (AllowCollection && t is ICollection)
                    return Search(MiMFa_Convert.ToArray(inObj), showAll, highlight, theseObjects);
                if (AllowStack && tn.StartsWith("stack"))
                    return Search(MiMFa_Convert.ToStack(inObj), showAll, highlight, theseObjects);
                if (AllowDataTable && tn.StartsWith("datatable"))
                    return Search((DataTable)inObj, showAll, highlight, theseObjects);
                if (AllowDataRow && tn.StartsWith("datarow"))
                    return Search((DataRow)inObj, showAll, highlight, theseObjects);
                if (AllowEnum && inObj is Enum)
                    return Search(inObj + "", showAll, highlight, theseObjects);
                if (AllowUri && inObj is Uri)
                    return Search((Uri)inObj, showAll, highlight, theseObjects);
                if (AllowString && inObj is String)
                    return Search(inObj + "", showAll, highlight, theseObjects);
                object o = null;
                foreach (var item in theseObjects)
                    if (o == null) o = Find(inObj, highlight, theseObjects);
                    else return o;
            }
            catch
            {
            }
            return (showAll) ? inObj : null;
        }
        private object Find(object arg, bool highlight, object thisobj)
        {
            if (arg == null) return null;
            if (!(arg is string))
                return (arg == thisobj)? arg:null;
            string narg = (CaseSensitiveSearch) ? (arg + "") : (arg + "").ToLower();
            string nthisobj = (CaseSensitiveSearch) ? (thisobj + "") : (thisobj + "").ToLower();
            if (!highlight) return (narg.Contains(nthisobj))?arg:null;
            return (narg.Contains(nthisobj))? (arg+"").Replace(thisobj + "",Highlight(thisobj + "")):null;
        }
        public virtual string Search(string arg, bool showAll, bool highlight, object[] theseObjects)
        {
            foreach (var item in theseObjects)
            {
                object a = Find(arg, highlight, item + "");
                if (a != null) return a+"";
            }
            return (showAll)?arg:null;
        }
        public virtual T[] Search<T>(T[] arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            List<T> ta = new List<T>();
            for (int i = 0; i < arg.Length; i++)
            {
                object a = TrySearch(arg[i], showAll, highlight, theseObjects);
                if (a != null) ta.Add((T)a);
            }
            return ta.ToArray();
        }
        public virtual IList<T> Search<T>(IList<T> arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            List<T> ta = new List<T>();
            for (int i = 0; i < arg.Count; i++)
            {
                object a = TrySearch(arg[i], showAll, highlight, theseObjects);
                if (a != null) ta.Add((T)a);
            }
            return ta;
        }
        public virtual IDictionary<T, F> Search<T, F>(IDictionary<T, F> arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            IDictionary<T, F> ta = new Dictionary<T, F>();
            foreach (var item in arg)
            {
                object a = TrySearch(item.Key, showAll, highlight, theseObjects);
                if (a != null) ta.Add((T)a, item.Value);
                else
                {
                    a = TrySearch(item.Value, showAll, highlight, theseObjects);
                    if (a != null) ta.Add(item.Key, (F)a);
                }
            }
            return ta;
        }
        public virtual KeyValuePair<T, F> Search<T, F>(KeyValuePair<T, F> arg, bool showAll, bool highlight, object[] theseObjects)
        {
            object a = TrySearch(arg.Key, showAll, highlight, theseObjects);
            if (a != null) return new KeyValuePair<T, F>((T)a, arg.Value);
            else
            {
                a = TrySearch(arg.Value, showAll, highlight, theseObjects);
                if (a != null) return new KeyValuePair<T, F>(arg.Key, (F)a);
            }
            return arg;
        }
        public virtual Stack<T> Search<T>(Stack<T> arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            List<T> lo = arg.ToList();
            return new Stack<T>(Search(lo, showAll, highlight, theseObjects));
        }
        public virtual Queue<T> Search<T>(Queue<T> arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            List<T> lo = arg.ToList();
            return new Queue<T>(Search(lo, showAll, highlight, theseObjects));
        }
        public virtual DataTable Search(DataTable arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            DataTable ta = arg.Clone();
            for (int i = 0; i < arg.Rows.Count; i++)
            {
                object a = Search(arg.Rows[i], showAll, highlight, theseObjects);
                if (a != null) ta.Rows.Add((a as DataRow).ItemArray);
            }
            return ta;
        }
        public virtual DataRow Search(DataRow arg, bool showAll, bool highlight, object[] theseObjects)
        {
            if (arg == null) return null;
            for (int i = 0; i < arg.ItemArray.Length; i++)
                if ((arg.ItemArray[i] = TrySearch(arg.ItemArray[i], showAll, highlight, theseObjects)) != null)
                    return arg;
            return null;
        }
        public virtual Uri Search(Uri arg, bool showAll, bool highlight, object[] theseObjects)
        {
            string a = null;
            foreach (var item in theseObjects)
                if (a == null) a = Find(arg.OriginalString, highlight, theseObjects) + "";
                else return arg;
            return null;
        }
    }
}
