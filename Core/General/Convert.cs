using System;
using System.Linq;
using System.Data;
using System.IO;
using System.Reflection;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using MiMFa_Framework.Service;
using MiMFa_Framework.Exclusive.DateAndTime;
using MiMFa_Framework.Exclusive.Collection;
using MiMFa_Framework.Exclusive.Collection.Instance;
using MiMFa_Framework.Component.WinForm.ButtonPack;
using MiMFa_Framework.Model;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Documents;
using System.Threading;
using MiMFa_Framework.Exclusive.ProgramingTechnology.Tools.Pickup;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.OleDb;

namespace MiMFa_Framework.General
{
    public class MiMFa_Convert
    {
        #region MiMFa Type
        public static Dictionary<string, string> ToDictionary<T>(List<T> lt) where T : MiMFa_Instance
        {
            return (
                from v in lt
                select new { Key = v.UID, Value = v.Name }
                ).ToDictionary(x => x.Key, x => x.Value);
        }
        public static Dictionary<string, string> ToDictionary<T>(T[] lt) where T : MiMFa_Instance
        {
            return (
                from v in lt
                select new { Key = v.UID, Value = v.Name }
                ).ToDictionary(x => x.Key, x => x.Value);
        }

        public static MiMFa_Time ToMiMFaTime(string op1)
        {
            string[] sta = op1.Split(':', '-', '_', ',', '/', '\\', ';');
            if (sta.Length > 2) return new MiMFa_Time(int.Parse(sta[0]), int.Parse(sta[1]), int.Parse(sta[2]));
            if (sta.Length > 2) return new MiMFa_Time(0, int.Parse(sta[0]), int.Parse(sta[1]));
            return new MiMFa_Time(0, 0, int.Parse(sta[0]));
        }
        public static MiMFa_Date ToMiMFaDate(string op1)
        {
            string[] sta = op1.Split('/', '-', '_', ',', ':', '\\', ';');
            if (sta.Length > 2) return new MiMFa_Date(int.Parse(sta[2]), int.Parse(sta[1]), int.Parse(sta[0]));
            if (sta.Length > 1) return new MiMFa_Date(0, int.Parse(sta[1]), int.Parse(sta[0]));
            return new MiMFa_Date(int.Parse(sta[0]), 0, 0);
        }
        public static MiMFa_Date ToMiMFaDate(DateTime dateTime)
        {
            return new MiMFa_Date(dateTime.Year, dateTime.Month, dateTime.Day);
        }
        public static MiMFa_Time ToMiMFaTime(DateTime dateTime)
        {
            return new MiMFa_Time(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
        public static DateTime ToDateTime(MiMFa_Date date)
        {
            return date.GetDateTime();
        }
        public static DateTime ToDateTime(MiMFa_Time time)
        {
            return time.GetDateTime();
        }
        public static int ToHijriDayOfWeekNum(DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Saturday:
                    return 0;
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                default: return (int)dow;
            }
        }


        public static int ToDayOfWeekNum(MiMFa_Date date, MiMFa_TimeZone timeZone = MiMFa_TimeZone.IranStandard)
        {
            MiMFa_DateTime dt = new MiMFa_DateTime();
            dt.TimeZone = timeZone;
            return ToDayOfWeekNum(date, dt);
        }
        public static int ToDayOfWeekNum(MiMFa_Date date, MiMFa_DateTime dateTime)
        {
            MiMFa_Date now = dateTime.GetDatePAC();
            int dow = dateTime.GetDayOfWeekNumber();
            int toleranse = now.GetLengthDay(date);
            int day = Math.Abs(toleranse % 7);
            if (toleranse > 0)//اگر تاریخ بعد از امروز بود
                for (int i = 0; i < day; i++)
                    if (++dow > 6) dow = 0;
                    else continue;
            else for (int i = 0; i < day; i++)
                    if (--dow < 0) dow = 6;
                    else continue;
            return dow;
        }

        public static string ToDayOfWeekName(MiMFa_Date date, MiMFa_TimeZone timeZone = MiMFa_TimeZone.IranStandard)
        {
            MiMFa_DateTime dt = new MiMFa_DateTime();
            dt.TimeZone = timeZone;
            return ToDayOfWeekName(date, dt);
        }
        public static string ToDayOfWeekName(int DayNum, MiMFa_DateTime dateTime)
        {
            if (dateTime.ZoneCalendar is PersianCalendar)
                return ToPersianDayOfWeek(DayNum);
            else if (dateTime.ZoneCalendar is HijriCalendar)
                return ToArabicDayOfWeek(DayNum);
            else
                return ToEnglishDayOfWeek(DayNum);
        }
        public static string ToDayOfWeekName(MiMFa_Date date, MiMFa_DateTime dateTime)
        {
            int dayOfWeek = ToDayOfWeekNum(date, dateTime);
            if (dateTime.ZoneCalendar is PersianCalendar)
                return ToPersianDayOfWeek(dayOfWeek);
            else if (dateTime.ZoneCalendar is HijriCalendar)
                return ToArabicDayOfWeek(dayOfWeek);
            else
                return ToEnglishDayOfWeek(dayOfWeek);
        }
        public static string ToPersianDayOfWeek(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 0:
                    return "شنبه";
                case 1:
                    return "یکشنبه";
                case 2:
                    return "دوشنبه";
                case 3:
                    return "سه شنبه";
                case 4:
                    return "چهارشنبه";
                case 5:
                    return "پنجشنبه";
                case 6:
                    return "آدینه";
            }
            return null;
        }
        public static string ToArabicDayOfWeek(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 0:
                    return "السبت";
                case 1:
                    return "الأحد";
                case 2:
                    return "الاثنين";
                case 3:
                    return "الثلاثاء";
                case 4:
                    return "الاربعاء";
                case 5:
                    return "الخميس";
                case 6:
                    return "الجمعة";
            }
            return null;
        }

        public static string ToEnglishDayOfWeek(int dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case 0:
                    return "Saturday";
                case 1:
                    return "Sunday";
                case 2:
                    return "Monday";
                case 3:
                    return "Tuesday";
                case 4:
                    return "Wednesday";
                case 5:
                    return "Thursday";
                case 6:
                    return "Friday";
            }
            return null;
        }
        public static string ToMonthName(MiMFa_Date date, MiMFa_DateTime dateTime)
        {
            if (dateTime.ZoneCalendar is PersianCalendar)
                return ToPersianMonth(date.Month);
            else if (dateTime.ZoneCalendar is HijriCalendar)
                return ToArabicMonth(date.Month);
            else
                return ToEnglishMonth(date.Month);
        }
        public static string ToPersianMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
            }
            return null;
        }
        public static string ToArabicMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "محرم";
                case 2:
                    return "صفر";
                case 3:
                    return "ربیع‌الاول";
                case 4:
                    return "ربیع‌الثانی";
                case 5:
                    return "جمادی‌الاول";
                case 6:
                    return "جمادی‌الثانی";
                case 7:
                    return "رجب";
                case 8:
                    return "شعبان";
                case 9:
                    return "رمضان";
                case 10:
                    return "شوال";
                case 11:
                    return "ذیقعده";
                case 12:
                    return "ذیحجه";
            }
            return null;
        }
        public static string ToEnglishMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
            }
            return null;
        }

        public static ButtonAction ToButtonAction(object obj)
        {
            ButtonAction ba = new ButtonAction();
            if (obj != null)
                try { ba = (ButtonAction)obj; }
                catch { }
            return ba;
        }

        #endregion

        #region *Image*
        public static Graphics ToGraphics(Bitmap bitmap)
        {
            Size s = bitmap.Size;
            Graphics memoryGraphics = Graphics.FromImage(bitmap);
            return memoryGraphics;
        }
        public static Icon ToIcon(Image image)
        {
            var thumb = (Bitmap)image.GetThumbnailImage(64, 64, null, IntPtr.Zero);
            thumb.MakeTransparent();
            return Icon.FromHandle(thumb.GetHicon());
        }
        public static Image ToImage(Icon icon)
        {
            try { return icon.ToBitmap(); } catch { }
            return null;
        }
        #endregion

        #region *byte*

        public static byte[] ToByteArray(Image image)
        {
            if (image == null) return null;
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }
        public static Image ToImage(byte[] byteimage)
        {
            if (byteimage == null) return null;
            MemoryStream ms = new MemoryStream(byteimage);
            return Image.FromStream(ms);
        }
        public static byte[] ToByteArray(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public static string ToString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        public static byte[] ToByteArrayFile(string fileAddress)
        {
            if (string.IsNullOrEmpty(fileAddress)) return null;
            return File.ReadAllBytes(fileAddress);
        }
        public static void ToFile(string exportToaAddress, byte[] bytes)
        {
            if (string.IsNullOrEmpty(exportToaAddress)) return;
            File.WriteAllBytes(exportToaAddress, bytes);
        }
        #endregion

        #region *string*

        public static string ToString(object Obj)
        {
            return Obj + "";
        }
        public static string ToString<T>(List<T> list)
        {
            string str = "";
            for (int i = 0; i < list.Count; i++)
                str += list[i] + Environment.NewLine;
            return str;
        }
        public static string ToString<T>(T[] array)
        {
            string str = "";
            for (int i = 0; i < array.Length; i++)
                str += array[i] + Environment.NewLine;
            return str;
        }
        public static string ToSeparatedWords(string cancatedString)
        {
            string str = "";
            bool uperfind = false;
            if (cancatedString != null)
            {
                for (int i = 0; i < cancatedString.Length; i++)
                {
                    string ch = cancatedString[i] + "";
                    if (ch == ch.ToUpper())
                    {
                        if (i == 0) uperfind = true;
                        else if (!uperfind)
                        {
                            str += " ";
                            uperfind = true;
                        }
                    }
                    else uperfind = false;
                    str += ch;
                }
            }
            return str;
        }
        public static string ToSeparatedWordsFast(string cancatedString)
        {
            string str = "";
            if (cancatedString != null)
            {
                for (int i = 0; i < cancatedString.Length; i++)
                {
                    string ch = cancatedString[i] + "";
                    if (ch == ch.ToUpper() && i > 0)
                        str += " ";
                    str += ch;
                }
            }
            return str;
        }
        public static string ToCancatedName(string name, bool justASCIIAlfabet = true)
        {
            if (name == null) return "";
            if (justASCIIAlfabet)
            {
                string nn = "";
                bool isalfabet = false;
                foreach (var item in name)
                {
                    byte b = (byte)item;
                    if ((b < 91 && b > 64) || (b < 123 && b > 96))
                    {
                        nn += isalfabet ? item + "" : (item + "").ToUpper();
                        isalfabet = true;
                    }
                    else isalfabet = false;
                }
                return nn;
            }
            string[] stra = name.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            name = "";
            foreach (var item in stra)
                try { name += (item[0] + "").ToUpper() + item.Substring(1); } catch { }
            return name;
        }
        public static string ToAlfabetCharacters(string name, string alter = " ")
        {
            if (name == null) return "";
            string nn = "";
            foreach (var item in name)
            {
                byte b = (byte)item;
                if ((b < 91 && b > 64) || (b < 123 && b > 96))
                    nn += item;
                else nn += alter;
            }
            return nn;
        }
        public static string ToAbsoluteURL(string url)
        {
            url = url.Trim();
            string lurl = url.ToLower();
            if (!lurl.StartsWith("http://") && !lurl.StartsWith("https://"))
            {
                while (lurl.StartsWith("/")) url = url.Substring(1);
                url = "http://" + url;
            }
            return url;
        }
        public static string ToValidAtributeName(string name)
        {
            if (name == null) return "";
            name = name
                .Replace("&", "And")
                .Replace("|", "Or")
                .Replace("^", "Power")
                .Replace("!", "Not")
                .Replace("@", "At")
                .Replace("#", "Num")
                .Replace("$", "Dollar")
                .Replace("%", "Percent")
                .Replace("*", "Product")
                .Replace("=", "Equals")
                .Replace("-", "Minus")
                .Replace("+", "Plus")
                .Replace(">", "GT")
                .Replace("<", "LT")
                .Replace(".", "Dot")
                .Replace(Environment.NewLine, " ")
                ;
            return ToCancatedName(name, true);
        }
        public static string ToValidURLCharacters(string name)
        {
            return System.Web.HttpUtility.UrlEncode(name);
        }

        private static string[] Alphabets = new string[] {
            "Z","A","B","C","D","E","F","G","H","I","J",
            "K","L","M","N","O","P","Q","R","S","T",
            "U","V","W","X","Y"
        };
        public static string ToAlphabet(int number)
        {
            if (number == 0) return "";
            return string.Join("", ToAlphabet((number-1) / 26), Alphabets[number % 26]);
        }
        #endregion

        #region *file*
        public static string ToTrimedString(string fileAddress)
        {
            return MiMFa_IOService.FileToTrimedString(fileAddress);
        }
        public static string ToString(string fileAddress)
        {
            return MiMFa_IOService.FileToString(fileAddress);
        }
        public static void ToFile(string fileAddress, Dictionary<string, string> Dic, string SplitChar = "|")
        {
            MiMFa_IOService.DictionaryToFile(fileAddress, Dic, SplitChar);
        }
        public static Image ToImage(string fileAddress)
        {
            Image image = null;
            try { image = Image.FromFile(fileAddress); } catch { }
            return image;
        }

        #endregion

        #region *html*
        public static string ToHTMLTag(Image img, string imageFileAddress, string cssClassName = "Image", int id = 0)
        {
            string str = "";
            if (!File.Exists(imageFileAddress)) img.Save(imageFileAddress);
            str += @"<img class='" + cssClassName + "' name='" + cssClassName + "" + id + "' src='" + imageFileAddress + "'/>";
            return str;
        }
        public static void ToImage(string html, string imageFileAddress, Size size, bool forceOpen = true)
        {
            var bm = ToImage(html, size);
            var ext = Path.GetExtension(imageFileAddress).ToLower();
            switch (ext)
            {
                case ".png":
                    bm.Save(imageFileAddress, ImageFormat.Png);
                    break;
                case ".bmp":
                    bm.Save(imageFileAddress, ImageFormat.Bmp);
                    break;
                case ".tif":
                case ".tiff":
                    bm.Save(imageFileAddress, ImageFormat.Tiff);
                    break;
                case ".gif":
                    bm.Save(imageFileAddress, ImageFormat.Gif);
                    break;
                case ".icon":
                    bm.Save(imageFileAddress, ImageFormat.Icon);
                    break;
                case ".wmf":
                    bm.Save(imageFileAddress, ImageFormat.Wmf);
                    break;
                case ".emf":
                    bm.Save(imageFileAddress, ImageFormat.Emf);
                    break;
                case ".exif":
                    bm.Save(imageFileAddress, ImageFormat.Exif);
                    break;
                default:
                    bm.Save(imageFileAddress, ImageFormat.Jpeg);
                    break;
            }
            if (forceOpen) System.Diagnostics.Process.Start(imageFileAddress);
        }
        public static Bitmap ToImage(string html, Size size)
        {
            WebBrowser wb = new WebBrowser();
            wb.ScriptErrorsSuppressed = true;
            MiMFa_ControlService.WebBrowserDocument(ref wb, html);
            wb.ScrollBarsEnabled = false;
            wb.Size = size;
            Bitmap bm = new Bitmap(size.Width, size.Height);
            wb.DrawToBitmap(bm, new Rectangle(0, 0, size.Width, size.Height));
            return bm;
            //Point loc = new Point(0, 0);
            //MiMFa_ControlService.WebBrowserDocument(wb, html);
            //while (true)
            //{
            //    wb.DrawToBitmap(bm, new Rectangle(loc.X, loc.Y, size.Width, size.Height));
            //    loc.Y += size.Height;
            //    yield return bm;
            //    if (loc.Y > wb.Document.Body.ScrollRectangle.Height) yield break;
            //    else wb.Document.Body.ScrollTop = loc.Y;
            //}
        }
        public static string ToXHTMLElements(string text)
        {
            return "<html><head></head><body>" + MiMFa_StringService.ToHTML(text) + "</body></html>";
        }
        public static string ToHTML(string html)
        {
            return MiMFa_StringService.FromHTML(html);
        }
        public static MiMFa_XMLElement ToMiMFaHTMLElement(HtmlElement html,int childindex = 0, MiMFa_XMLElement parent = null)
        {
            string[] stra = new string[] { "<" + html.TagName + ">" };
            string s = "", e = "";
            if (html.OuterHtml != null)
                if (html.InnerHtml == null)
                {
                    stra = html.OuterHtml.Split(new string[] { "></" }, StringSplitOptions.None);
                    if (stra.Length > 1)
                    {
                        stra[0] += ">";
                        e = "</" + stra.Last();
                    }
                }
                else if ((stra = html.OuterHtml.Split(new string[] { html.InnerHtml }, StringSplitOptions.None)).Length > 1)
                    e = stra.Last().Trim();
            else if (stra.Length > 1) e = stra.Last().Trim();
            s = stra.First().Trim();
            MiMFa_XMLElement p = new MiMFa_XMLElement(childindex, html.TagName,s,e,null, parent);
            for (int i = 0; i < html.Children.Count; i++)
                p.Children.Add(ToMiMFaHTMLElement(html.Children[i], i, p));
            return p;
        }
        public static List<MiMFa_XMLElement> ToMiMFaHTMLElements(WebBrowser wb, bool quick = false)
        {
            //string html =
            //@"
            //<doctype type='html'/>
            //<!--[if ex] <html> <head>< <comment1 [end if]-->
            //    <head>
            //        <script type='text'>
            //        func
            //        </script>
            //        <style>
            //            a{}b{}
            //        </style>
            //    </head>
            //    <body>
            //        <hr/><!-- comment1--><hr>
            //        <br>
            //        <div ho='<aa> ali<br> </aa>'>
            //            div 1
            //            <br>
            //            <h1>aaaaa</h1>
            //            <div>
            //                div 1-2
            //            </div>
            //            <div>
            //                div 1-3
            //            </div
            //        </div>
            //        <div style='back:black'>
            //            <div>
            //                div 2-1
            //            </div>
            //            <a href='http://nazkd.com'>
            //                <!-- comment2-->nazkd link
            //            </a>
            //        </div><!-- comment3-->
            //    </body>
            //</html>
            //";
            //
            //HtmlElement he = wb.Document.Body;
            //while (he.Parent != null) he = he.Parent;
            //return ToMiMFaHTMLElements(he);
            //
            //string html = "";
            //if (quick) html = wb.DocumentText;
            //else
            //{
            //    int num = 0;
            //    while (num++ < 15)
            //        if (!wb.IsBusy) { html = wb.DocumentText; break; }
            //}
            ////
            string html = wb.DocumentText;
            return ToMiMFaHTMLElements(html, quick);
        }
        public static List<MiMFa_XMLElement> ToMiMFaHTMLElements( HtmlElementCollection elems)
        {
            List<MiMFa_XMLElement> res = new List<MiMFa_XMLElement>();
            for (int i = 0; i < elems.Count; i++)
                res.Add(ToMiMFaHTMLElement(elems[i], i, null));
            return res;
        }
        public static List<MiMFa_XMLElement> ToMiMFaHTMLElements(params HtmlElement[] elems)
        {
            List<MiMFa_XMLElement> res = new List<MiMFa_XMLElement>();
            for (int i = 0; i < elems.Length; i++)
                res.Add(ToMiMFaHTMLElement(elems[i], i, null));
            return res;
        }
        public static List<MiMFa_XMLElement> ToMiMFaHTMLElements(string html, bool quick = false)
        {
            MiMFa_Pickup mscriptp = new MiMFa_Pickup("" + "[|SCRIPT|]" + "", "<SCRIPT", "</SCRIPT>", false);
            MiMFa_Pickup mxmpp = new MiMFa_Pickup("" + "[|XMP|]" + "", "<XMP", "</XMP>", false);
            MiMFa_Pickup mcodep = new MiMFa_Pickup("" + "[|CODE|]" + "", "<CODE", "</CODE>", false);
            html = mscriptp.Pick(html);
            html = mxmpp.Pick(html);
            html = mcodep.Pick(html);
            if (quick) html = mscriptp.ParseTo(html, "");
            var res = ToMiMFaXMLElements(html);
            for (int i = 0; i < res.Count; i++)
                res[i] = parse1(res[i],
                    mcodep,
                    mxmpp,
                    mscriptp);
            return res;
        }
        private static MiMFa_XMLElement parse1(MiMFa_XMLElement xmle,params MiMFa_Pickup[] picks)
        {
            foreach (var pick in picks)
                xmle.StartTag = pick.Parse(xmle.StartTag);
            for (int i = 0; i < xmle.Children.Count; i++)
                xmle.Children[i] = parse1(xmle.Children[i], picks);
            return xmle;
        }
        #endregion

        #region object
        public static bool ToBoolean(object obj)
        {
            return Convert.ToBoolean(obj);
        }
        public static double ToDouble(object obj)
        {
            string str = (obj + "").Trim();//.Replace("/",".");
            double d = 0;
            try { d = Convert.ToInt16(str); } catch { }
            if (d + "" == str) return d;
            else try { d = Convert.ToInt32(str); } catch { }
            if (d + "" == str) return d;
            else try { d = Convert.ToInt64(str); } catch { }
            if (d + "" == str) return d;
            else try { d = Convert.ToSingle(str); } catch { }
            if (d + "" == str) return d;
            else try { d = Convert.ToDouble(str); } catch { }
            if (d + "" == str) return d;
            //else try { d = Convert.ToDecimal(str); } catch { }
            //if (d + "" == str) return d;
            else throw new InvalidOperationException();
        }
        public static double ForceToDouble(object obj)
        {
            if (MiMFa_GetDetail.IsNumber(obj)) return Convert.ToDouble(obj);
            return MiMFa_IOService.Serialize(obj).Length;
        }
        public static double TryToDouble(object obj, double defaultVal = 0)
        {
            try { return ToDouble((obj+"").Trim()); } catch { return defaultVal; }
        }
        public static int TryToInt(object obj,int defaultVal = 0)
        {
            try { return Convert.ToInt32(obj); } catch { return defaultVal; }
        }
        #endregion

        #region datatable
        public static string ToString(MiMFa_Table miMFa_Table)
        {
            string s = "";
            int len = miMFa_Table.Rows.Count;
            for (int i = 0; i < len; i++)
                s += string.Join("\t", miMFa_Table.MainTable.Rows[i].ItemArray)+ Environment.NewLine;
            return s.TrimEnd();
        }
        public static string ToString(DataTable dt)
        {
            string s = "";
            for (int i = 0; i < dt.Columns.Count; i++)
                s += dt.Columns[i].ColumnName + "\t";
            s = s.TrimEnd('\t');
            int len = dt.Rows.Count;
            for (int i = 0; i < len; i++)
                s += Environment.NewLine + string.Join("\t", dt.Rows[i].ItemArray);
            return s;
        }
        public static List<T> ToList<T>(DataTable dataTable,params object[] constructorParams)
        {
            List<T> result = new List<T>();
            Type type = typeof(T);
            FieldInfo[] fi = type.GetFields();
            PropertyInfo[] pi = type.GetProperties();
            if (dataTable != null)
                if (dataTable.Rows.Count > 0)
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        T tm = (T)Activator.CreateInstance(type, constructorParams);
                        foreach (DataColumn item in dataTable.Columns)
                            tm = MiMFa_IOService.ValueToObject(tm, item.ColumnName, dataTable.Rows[i][item.ColumnName]);
                        result.Add(tm);
                    }
            return result;
        }
        public static T ToObject<T>(DataTable dt, int row, ref T obj)
        {
            try
            {
                if (dt.Rows.Count <= 0) throw new NullReferenceException("This table is empty!");
                foreach (DataColumn item in dt.Columns)
                    if (dt.Rows[row][item.ColumnName].GetType() != typeof(DBNull))
                        obj = MiMFa_IOService.ValueToObject(obj, item.ColumnName, dt.Rows[row][item.ColumnName]);
            }
            catch { }
            return obj;
        }
        public static DataTable ToPropertiesDataTable<T>(List<T> lt)
        {
            DataTable obj = new DataTable();
            if(lt.Count>0)try
            {
                Type t = lt.First().GetType();
                var pi = t.GetProperties();
                foreach (var item in pi)
                    obj.Columns.Add(item.Name,item.PropertyType);
                foreach (var item in lt)
                    obj.Rows.Add(ToPropertiesValueArray(item,t));
            }
            catch { }
            return obj;
        }
        public static DataTable ToPropertiesDataTable<T>(List<T> lt, string[] properties)
        {
            DataTable obj = new DataTable();
            if (lt.Count > 0) try
                {
                    Type t = lt.First().GetType();
                    foreach (var item in properties)
                    {
                        var pi = t.GetProperty(item);
                        obj.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    foreach (var item in lt)
                        obj.Rows.Add(ToPropertiesValueArray(item, t));
                }
                catch { }
            return obj;
        }
        public static object[] ToPropertiesValueArray<T>(T o)
        {
            List<object> obj = new List<object>();
            try
            {
                Type t = o.GetType();
                var pi = t.GetProperties();
                foreach (var item in pi)
                    obj.Add(item.GetValue(o));
            }
            catch { }
            return obj.ToArray();
        }
        public static object[] ToPropertiesValueArray<T>(T o, Type t, string[] properties)
        {
            List<object> obj = new List<object>();
            try
            {
                foreach (var item in properties)
                    try { obj.Add(t.GetProperty(item).GetValue(o)); } catch { }
            }
            catch { }
            return obj.ToArray();
        }
        public static object[] ToPropertiesValueArray<T>(T o, Type t)
        {
            List<object> obj = new List<object>();
            try
            {
                var pi = t.GetProperties();
                foreach (var item in pi)
                    obj.Add(item.GetValue(o));
            }
            catch { }
            return obj.ToArray();
        }
        public static object[] ToPropertiesValueArray<T>(T o, string[] properties)
        {
            List<object> obj = new List<object>();
            try
            {
                Type t = o.GetType();
                foreach (var item in properties)
                    try { obj.Add(t.GetProperty(item).GetValue(o)); } catch { }
            }
            catch { }
            return obj.ToArray();
        }
        #endregion

        #region Other      
        public static MiMFa_Dictionary<T,F> ToMiMFaDictionary<T,F>(params KeyValuePair<T,F>[] args)
        {
            MiMFa_Dictionary<T, F> dic = new MiMFa_Dictionary<T, F>();
            for (int i = 0; i < args.Length; i++)
                dic.Add(args[i].Key,args[i].Value);
            return dic;
        }
        public static Dictionary<T,F> ToDictionary<T,F>(params KeyValuePair<T,F>[] args)
        {
            Dictionary<T, F> dic = new Dictionary<T, F>();
            for (int i = 0; i < args.Length; i++)
                dic.Add(args[i].Key,args[i].Value);
            return dic;
        }
        #endregion

        #region Objects     
        public static object[] ToArray(object obj)
        {
            if (obj == null) return null;
            var Inewobj = obj as ICollection;
            if (Inewobj == null) return null;
            return Inewobj.Cast<object>()
                .ToArray();
        }
        public static List<object> ToList(object obj)
        {
            if (obj == null) return null;
            var Inewobj = obj as IList;
            if (Inewobj == null) return null;
            List<object> lo = new List<object>();
            for (int i = 0; i < Inewobj.Count; i++)
                lo.Add(Inewobj[i]);
            return lo;
        }
        public static Dictionary<object, object> ToDictionary(dynamic obj)
        {
            if (!MiMFa_GetDetail.IsDictionary(obj)) return null;
            Dictionary<object, object> dic = new Dictionary<object, object>();
            foreach (var item in obj)
                dic.Add(item.Key, item.Value);
            return dic;
        }
        public static MiMFa_Matrix<object> ToMiMFaMatrix(dynamic obj)
        {
            if (!MiMFa_GetDetail.IsMatrix(obj)) return null;
            MiMFa_Matrix<object> mat = new MiMFa_Matrix<object>();
            foreach (var item in obj)
                mat.AddRow(item);
            return mat;
        }
        public static KeyValuePair<object, object> ToKeyValuePair(dynamic obj)
        {
            return new KeyValuePair<object, object>(obj.Key, obj.Value);
        }
        public static Stack<object> ToStack(object obj)
        {
            if (obj == null) return null;
            var Inewobj = obj as Stack;
            if (Inewobj == null) return null;
            Stack<object> lo = new Stack<object>();
            object[] arr = Inewobj.ToArray();
            for (int i = 0; i < Inewobj.Count; i++)
                lo.Push(arr[i]);
            return lo;
        }
        public static Queue<object> ToQueue(object obj)
        {
            if (obj == null) return null;
            var Inewobj = obj as Queue;
            if (Inewobj == null) return null;
            Queue<object> lo = new Queue<object>();
            object[] arr = Inewobj.ToArray();
            for (int i = 0; i < Inewobj.Count; i++)
                lo.Enqueue(arr[i]);
            return lo;
        }
        public static object[] ToParents<T>(T[] arg)
        {
            if (arg == null) return null;
            object[] lo = new object[arg.Length];
            for (int i = 0; i < arg.Length; i++)
                lo[i] = arg[i];
            return lo.ToArray();
        }
        public static List<object> ToParents<T>(IList<T> arg)
        {
            if (arg == null) return null;
            List<object> lo = new List<object>();
            for (int i = 0; i < arg.Count; i++)
                lo.Add(arg[i]);
            return lo;
        }
        public static Dictionary<object,object> ToDictionary<T,F>(IDictionary<T,F> arg)
        {
            if (arg == null) return null;
            Dictionary<object, object> lo = new Dictionary<object, object>();
            foreach (var item in arg.Keys)
                lo.Add(item,arg[item]);
            return lo;
        }
        public static Stack<object> ToStack<T>(Stack<T> arg)
        {
            if (arg == null) return null;
            Stack<object> lo = new Stack<object>();
            List<T> lt = arg.ToList();
            for (int i = 0; i < lt.Count; i++)
                lo.Push(lt[i]);
            return lo;
        }
        public static MiMFa_Stack<object> ToMiMFaStack<T>(MiMFa_Stack<T> arg)
        {
            if (arg == null) return null;
            MiMFa_Stack<object> lo = new MiMFa_Stack<object>();
            List<T> lt = arg.ToList();
            for (int i = 0; i < lt.Count; i++)
                lo.Push(lt[i]);
            return lo;
        }
        #endregion

        #region PDF
        public static string ToString(string pdfAddress, int beginPageNumber = 1, int maxNumberOfPage = -1, int numberOfCharsToKeep = 35)
        {
            try
            {
                PdfReader reader = new PdfReader(pdfAddress);
                int numPage = maxNumberOfPage < 0 ? reader.NumberOfPages : Math.Min(maxNumberOfPage, reader.NumberOfPages);
                List<string> result = new List<string>();
                for (int page = beginPageNumber; page <= numPage; page++)
                    try { result.Add(PDFBytesToText(reader.GetPageContent(page), numberOfCharsToKeep)); } catch { }
                return string.Join(Environment.NewLine + Environment.NewLine, result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool ToTextFile(string pdfAddress, string textAddress, int beginPageNumber = 1, int maxNumberOfPage = -1, int numberOfCharsToKeep = 15)
        {
            StreamWriter outFile = null;
            try
            {
                string text = ToString(pdfAddress, beginPageNumber, maxNumberOfPage, numberOfCharsToKeep);
                if (text != null)
                {
                    outFile = new StreamWriter(textAddress, false, Encoding.UTF8);
                    outFile.Write(text);
                }
                else return false;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (outFile != null) outFile.Close();
            }
        }
        private static string PDFBytesToText(byte[] input, int numberOfCharsToKeep = 15)
        {
            if (input == null || input.Length == 0) return "";
            try
            {
                string resultString = "";
                bool inTextObject = false;
                bool nextLiteral = false;
                int bracketDepth = 0;
                char[] previousCharacters = new char[numberOfCharsToKeep];
                for (int j = 0; j < numberOfCharsToKeep; j++) previousCharacters[j] = ' ';
                for (int i = 0; i < input.Length; i++)
                {
                    char c = (char)input[i];

                    if (inTextObject)
                    {
                        // Position the text
                        if (bracketDepth == 0)
                        {
                            if (CheckToken(new string[] { "TD", "Td" }, previousCharacters,numberOfCharsToKeep))
                            {
                                resultString += "\n\r";
                            }
                            else
                            {
                                if (CheckToken(new string[] {"'", "T*", "\""}, previousCharacters, numberOfCharsToKeep))
                                {
                                    resultString += "\n";
                                }
                                else
                                {
                                    if (CheckToken(new string[] { "Tj" }, previousCharacters, numberOfCharsToKeep))
                                    {
                                        resultString += " ";
                                    }
                                }
                            }
                        }

                        // End of a text object, also go to a new line.
                        if (bracketDepth == 0 && 
                            CheckToken( new string[]{"ET"}, previousCharacters, numberOfCharsToKeep))
                        {

                            inTextObject = false;
                            resultString += " ";
                        }
                        else
                        {
                            // Start outputting text
                            if ((c == '(') && (bracketDepth == 0) && (!nextLiteral))
                            {
                                bracketDepth = 1;
                            }
                            else
                            {
                                // Stop outputting text
                                if ((c == ')') && (bracketDepth == 1) && (!nextLiteral))
                                {
                                    bracketDepth = 0;
                                }
                                else
                                {
                                    // Just a normal text character:
                                    if (bracketDepth == 1)
                                    {
                                        // Only print out next character no matter what. 
                                        // Do not interpret.
                                        if (c == '\\' && !nextLiteral)
                                        {
                                            nextLiteral = true;
                                        }
                                        else
                                        {
                                            if (((c >= ' ') && (c <= '~')) ||
                                                ((c >= 128) && (c < 255)))
                                            {
                                                resultString += c.ToString();
                                            }

                                            nextLiteral = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Store the recent characters for 
                    // when we have to go back for a checking
                    for (int j = 0; j < numberOfCharsToKeep - 1; j++)
                    {
                        previousCharacters[j] = previousCharacters[j + 1];
                    }
                    previousCharacters[numberOfCharsToKeep - 1] = c;

                    // Start of a text object
                    if (!inTextObject && CheckToken(new string[]{"BT"}, previousCharacters, numberOfCharsToKeep))
                    {
                        inTextObject = true;
                    }
                }
                return resultString;
            }
            catch
            {
                return "";
            }
        }
        private static bool CheckToken(string[] tokens, char[] recent, int numberOfCharsToKeep = 15)
        {
            foreach (string token in tokens)
            {
                if ((recent[numberOfCharsToKeep - 3] == token[0]) &&
                    (recent[numberOfCharsToKeep - 2] == token[1]) &&
                    ((recent[numberOfCharsToKeep - 1] == ' ') ||
                    (recent[numberOfCharsToKeep - 1] == 0x0d) ||
                    (recent[numberOfCharsToKeep - 1] == 0x0a)) &&
                    ((recent[numberOfCharsToKeep - 4] == ' ') ||
                    (recent[numberOfCharsToKeep - 4] == 0x0d) ||
                    (recent[numberOfCharsToKeep - 4] == 0x0a))
                    )
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Excel      
        public static void ToExcelFile(DataGridView dgv, string exceladdress, string sheetName = "sheet1",bool openAfter = true)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program
            
            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = sheetName;

            // storing header part in Excel
            for (int i = 0,col = 1; i < dgv.Columns.Count; i++)
            if(dgv.Columns[i].Visible) worksheet.Cells[1,col++] = dgv.Columns[i].HeaderText;

            // storing Each row and column value to excel sheet
            for (int i = 0, row = 2; i < dgv.Rows.Count; i++, row++)
                if (dgv.Rows[i].Visible)
                    for (int j = 0, col = 1; j < dgv.Columns.Count; j++)
                        if (dgv.Columns[j].Visible)
                            worksheet.Cells[row, col++] = dgv.Rows[i].Cells[j].Value + "";
            

            // save the application
            workbook.SaveAs(exceladdress, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            if (openAfter) app.Visible = true;
            else app.Quit();
        }
        public static void ToExcelFile(DataTable dt, string exceladdress, string sheetName = "sheet1", bool openAfter = true)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program
            //app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = sheetName;

            // storing header part in Excel
            for (int i = 0; i < dt.Columns.Count; i++)
                worksheet.Cells[1,i+1] = dt.Columns[i].ColumnName;

            // storing Each row and column value to excel sheet
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j] + "";

            // save the application
            workbook.SaveAs(exceladdress, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            if (openAfter) app.Visible = true;
            else app.Quit();
        }
        public static void ToExcelFile(MiMFa_Table dt, string exceladdress, string sheetName = "sheet1", bool openAfter = true)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program
            //app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = sheetName;

            // storing Each row and column value to excel sheet
            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                    worksheet.Cells[i + 1, j + 1] = dt.Rows[i][j] + "";

            // save the application
            workbook.SaveAs(exceladdress, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            if (openAfter) app.Visible = true;
            else app.Quit();
        }
        public static void ToExcelFile<T, F>(Dictionary<T,F> dic, string exceladdress, string sheetName = "sheet1", bool openAfter = true)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program
            //app.Visible = true;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = sheetName;

            // storing Each row and column value to excel sheet
            int i = 1;
            foreach (var item in dic)
            {
                worksheet.Cells[i, 1] = item.Key;
                worksheet.Cells[i++, 2] = item.Value;
            }
            // save the application
            workbook.SaveAs(exceladdress, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            if (openAfter) app.Visible = true;
            else app.Quit();
        }
        public static void ToExcelFile<T>(List<T> lt, string exceladdress, string sheetName = "sheet1", bool openAfter = true, bool showProcess = false)
        {
            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program
            app.Visible = showProcess;

            // get the reference of first sheet. By default its name is Sheet1.
            // store its reference to worksheet
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            // changing the name of active sheet
            worksheet.Name = sheetName;

            // storing Each row and column value to excel sheet
            for (int i = 0; i < lt.Count; i++)
                    worksheet.Cells[i+1, 1] = lt[i];

            // save the application
            workbook.SaveAs(exceladdress, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application
            if (openAfter) app.Visible = true;
            else app.Quit();
        }
        public static void ToExcelFile<T>(T[] lt, string exceladdress, string sheetName = "sheet1", bool openAfter = true)
        {
            ToExcelFile(lt.ToList(),exceladdress,sheetName,openAfter);
        }
        public static DataTable ToDataTable(string exceladdress,string sheetName, string condition = "")
        {
            DataSet ds = ToDataSet(exceladdress, new List<string> { sheetName }, condition);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }
        public static DataSet ToDataSet(string exceladdress, string sheetName, string condition = "")
        {
            return ToDataSet(exceladdress, new List<string>{ sheetName}, condition);
        }
        public static DataSet ToDataSet(string exceladdress, string condition = "")
        {
            return ToDataSet(exceladdress, 0,-1, condition);
        }
        public static DataSet ToDataSet(string exceladdress, int startRecord = 0, int maxRecord = -1, string condition = "")
        {
            DataSet result = new DataSet();
            using (OleDbConnection connection = new OleDbConnection((exceladdress.TrimEnd().ToLower().EndsWith("x")) ? "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + exceladdress + "';" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'"
                : "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + exceladdress + "';Extended Properties=Excel 8.0;"))
                try
                {
                    connection.Open();
                    DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow drSheet in schema.Rows)
                        if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                        {
                            string s = drSheet["TABLE_NAME"].ToString();
                            if (s.StartsWith("'")) s = s.Substring(1, s.Length - 2);
                            System.Data.OleDb.OleDbDataAdapter command =
                                new System.Data.OleDb.OleDbDataAdapter(string.Join("", "SELECT * FROM [", s, "] ", condition), connection);
                            DataTable dt = new DataTable();
                            if (maxRecord > -1 && startRecord > -1) command.Fill(startRecord, maxRecord, dt);
                            else command.Fill(dt);
                            result.Tables.Add(dt);
                        }
                    return result;
                }
                catch (Exception ex) { return null; }
                finally { connection.Close(); }
        }
        public static DataSet ToDataSet(string exceladdress, List<string> sheetNames, string condition = "")
        {
            OleDbConnection MyConnection = new OleDbConnection((exceladdress.TrimEnd().ToLower().EndsWith("x")) ? "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + exceladdress + "';" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'"
                : "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + exceladdress + "';Extended Properties=Excel 8.0;");
            try
            {
                System.Data.DataSet result = new System.Data.DataSet();
                foreach (var item in sheetNames)
                {
                    System.Data.OleDb.OleDbDataAdapter command = new System.Data.OleDb.OleDbDataAdapter(string.Join("", "SELECT * FROM [", item, "$] ", condition), MyConnection);
                    DataTable dt = new DataTable();
                    command.Fill(dt);
                    result.Tables.Add(dt);
                }
                return result;
            }
            catch (Exception ex) { return null; }
            finally { MyConnection.Close(); }
        }
        public static MiMFa_Table ToMiMFaTable(string exceladdress, string sheetName, string condition = "")
        {
            DataTable dt = ToDataTable(exceladdress, sheetName, condition);
            if (dt == null) return null;
            return new MiMFa_Table(dt) ;
        }
        public static List<MiMFa_Table> ToMiMFaTableList(string exceladdress,int startRecord = 0,int maxRecord = -1, string condition = "")
        {
            DataSet ds = ToDataSet(exceladdress, startRecord, maxRecord, condition);
            List<MiMFa_Table> ml = new List<MiMFa_Table>();
            if (ds == null) return ml;
            foreach (DataTable item in ds.Tables)
                ml.Add(new MiMFa_Table(item));
            return ml;
        }
        public static List<string> ToExcelsSheetList(string exceladdress)
        {
            List<string> sheets = new List<string>();
            using (OleDbConnection connection = new OleDbConnection((exceladdress.TrimEnd().ToLower().EndsWith("x")) ? "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + exceladdress + "';" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'"
                : "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + exceladdress + "';Extended Properties=Excel 8.0;"))
            {
                connection.Open();
                try
                {
                    DataTable dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow drSheet in dt.Rows)
                        if (drSheet["TABLE_NAME"].ToString().Contains("$"))
                        {
                            string s = drSheet["TABLE_NAME"].ToString();
                            sheets.Add(s.StartsWith("'") ? s.Substring(1, s.Length - 3) : s.Substring(0, s.Length - 1));
                        }
                }
                catch { }
                finally { connection.Close(); }
            }
            return sheets;
        }
        #endregion

        #region XAML
        public static string ToXAML(string rtfText)
        {
            var richTextBox = new System.Windows.Controls.RichTextBox();
            if (string.IsNullOrEmpty(rtfText)) return "";
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var rtfMemoryStream = new MemoryStream())
            {
                using (var rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                {
                    rtfStreamWriter.Write(rtfText);
                    rtfStreamWriter.Flush();
                    rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                    textRange.Load(rtfMemoryStream, System.Windows.DataFormats.Rtf);
                }
            }
            using (var rtfMemoryStream = new MemoryStream())
            {
                textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Save(rtfMemoryStream, System.Windows.DataFormats.Xaml);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }
        }
        public static string ToRTF(string xamlText)
        {
            var richTextBox = new System.Windows.Controls.RichTextBox();
            if (string.IsNullOrEmpty(xamlText)) return "";
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var xamlMemoryStream = new MemoryStream())
            {
                using (var xamlStreamWriter = new StreamWriter(xamlMemoryStream))
                {
                    xamlStreamWriter.Write(xamlText);
                    xamlStreamWriter.Flush();
                    xamlMemoryStream.Seek(0, SeekOrigin.Begin);
                    textRange.Load(xamlMemoryStream, System.Windows.DataFormats.Xaml);
                }
            }
            using (var rtfMemoryStream = new MemoryStream())
            {
                textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Save(rtfMemoryStream, System.Windows.DataFormats.Rtf);
                rtfMemoryStream.Seek(0, SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }
        }
        #endregion

        #region XML
        public static List<MiMFa_XMLElement> ToMiMFaXMLElements_Quick1(string xml)
        {
            List<KeyValuePair<int, MiMFa_XMLElement>> nested = new List<KeyValuePair<int, MiMFa_XMLElement>>();
            Stack<MiMFa_XMLElement> child = new Stack<MiMFa_XMLElement>();
            Stack<string> stack = new Stack<string>();
            string startTag = "", endTag = "";
            string mhtml = "";
            MiMFa_Route route = MiMFa_Route.Null;

            Func<bool> textcheck = () =>
           {
               bool t = false;
               if (t = !string.IsNullOrWhiteSpace(startTag))
                   stack.Push(startTag.Trim());
               startTag = "";
               return t;
           };
            Func<int, bool> helcheck = (count) =>
            {
                for (int i = nested.Count - 1; i >= 0; i--)
                    if (nested[i].Key > count)
                    {
                        child.Push(nested[i].Value);
                        nested.RemoveAt(i);
                    }
                return true;
            };

            for (int i = 0; i < xml.Length; i++)
            {
                mhtml = xml.Substring(i);
                switch (route)
                {
                    case MiMFa_Route.Start:
                        if (mhtml.StartsWith(">"))
                        {
                            startTag += ">";
                            stack.Push(startTag);
                            startTag = "";
                            route = MiMFa_Route.Middle;
                        }
                        else startTag += xml[i];
                        break;
                    case MiMFa_Route.Null:
                    case MiMFa_Route.Middle:
                        if (mhtml.StartsWith("</"))
                        {
                            textcheck();
                            endTag = "</";
                            i++;
                            route = MiMFa_Route.End;
                        }
                        else if (mhtml.StartsWith("<"))
                        {
                            textcheck();
                            startTag = "<";
                            route = MiMFa_Route.Start;
                        }
                        else startTag += xml[i];
                        break;
                    case MiMFa_Route.End:
                        if (mhtml.StartsWith(">"))
                        {
                            textcheck();
                            endTag += ">";
                            string tne = endTag.Replace("</", "").Replace("<", "").Replace(">", "").Trim().ToUpper();
                            int num = -1;
                            if ((num = stack.ToList().FindIndex((x) =>
                            {
                                string tns = x.StartsWith("<") ? MiMFa_StringService.FirstFindAndSplit(x + " ", " ", 1).First().Replace("<", "").Replace("/>", "").Replace(">", "").ToUpper() : "";
                                return tns == tne;
                            })) > -1)
                            {
                                int ni = 0;
                                string ss, tns;
                                while (ni++ < num)
                                {
                                    ss = stack.Pop();
                                    bool isTag = ss.StartsWith("<");
                                    tns = isTag ? MiMFa_StringService.FirstFindAndSplit(ss + " ", " ", 1).First().Replace("<", "").Replace("/>", "").Replace(">", "").ToUpper() : "";
                                    helcheck(stack.Count);
                                    child.Push(new MiMFa_XMLElement(-1, tns, ss, ""));
                                }
                                ss = stack.Pop();
                                tns = MiMFa_StringService.FirstFindAndSplit(ss + " ", " ", 1).First().Replace("<", "").Replace("/>", "").Replace(">", "").ToUpper();
                                helcheck(stack.Count);
                                MiMFa_XMLElement elem = new MiMFa_XMLElement(-1, tns, ss, endTag);
                                elem.Children = child.ToList();
                                child = new Stack<MiMFa_XMLElement>();
                                nested.Add(new KeyValuePair<int, MiMFa_XMLElement>(stack.Count, elem));
                            }
                            endTag = "";
                            route = MiMFa_Route.Null;
                        }
                        else endTag += xml[i];
                        break;
                }
            }
            while (stack.Count > 0)
            {
                helcheck(stack.Count);
                child.Push(new MiMFa_XMLElement(child.Count, "", stack.Pop(), ""));
            }
            helcheck(0);

            List<MiMFa_XMLElement> res = child.ToList();
            for (int i = 0; i < res.Count; i++)
            {
                res[i].Index = i;
                res[i].Parent = null;
                res[i].Refresh();
            }
            return res;
        }
        public static List<MiMFa_XMLElement> ToMiMFaXMLElements_Quick2(string xml)
        {
            List<KeyValuePair<int, MiMFa_XMLElement>> nested = new List<KeyValuePair<int, MiMFa_XMLElement>>();
            Stack<MiMFa_XMLElement> child = new Stack<MiMFa_XMLElement>();
            Stack<string> stack = new Stack<string>();
            string startTag = "", endTag = "";
            string mhtml = "";
            MiMFa_Route route = MiMFa_Route.Null;

            Func<bool> textcheck = () =>
           {
               bool t = false;
               if (t = !string.IsNullOrWhiteSpace(startTag))
                   stack.Push(startTag.Trim());
               startTag = "";
               return t;
           };
            Func<int, bool> nestedcheck = (tothisindex) =>
            {
                for (int i = nested.Count - 1; i >= 0; i--)
                    if (nested[i].Key > tothisindex)
                    {
                        child.Push(nested[i].Value);
                        nested.RemoveAt(i);
                    }
                return true;
            };

            for (int i = 0; i < xml.Length; i++)
            {
                mhtml = xml.Substring(i);
                switch (route)
                {
                    case MiMFa_Route.Start:
                        if (mhtml.StartsWith("/>"))
                        {
                            startTag += "/>";
                            stack.Push(startTag);
                            startTag = "";
                            i++;
                            route = MiMFa_Route.Null;
                        }
                        else if (mhtml.StartsWith(">"))
                        {
                            startTag += ">";
                            stack.Push(startTag);
                            startTag = "";
                            route = MiMFa_Route.Middle;
                        }
                        else startTag += xml[i];
                        break;
                    case MiMFa_Route.Null:
                    case MiMFa_Route.Middle:
                        if (mhtml.StartsWith("</"))
                        {
                            textcheck();
                            endTag = "</";
                            i++;
                            route = MiMFa_Route.End;
                        }
                        else if (mhtml.StartsWith("<"))
                        {
                            textcheck();
                            startTag = "<";
                            route = MiMFa_Route.Start;
                        }
                        else startTag += xml[i];
                        break;
                    case MiMFa_Route.End:
                        if (mhtml.StartsWith(">"))
                        {
                            textcheck();
                            endTag += ">";
                            string endtagname = endTag.Replace("</", "").Replace("<", "").Replace(">", "").Trim().ToUpper();
                            int starttagindex = -1;
                            if ((starttagindex = stack.ToList().FindIndex((x) =>
                            {
                                if (x.StartsWith("<"))
                                {
                                    string tns = MiMFa_StringService.FirstFindAndSplit(x + " ", " ", 1).First().Replace("<", "").Replace(">", "").ToUpper();
                                    return tns == endtagname;
                                }
                                return false;
                            })) > -1)
                            {
                                int ni = 0;
                                string starttag, starttagname;
                                while (ni++ < starttagindex)
                                {
                                    starttag = stack.Pop();
                                    bool isTag = starttag.StartsWith("<");
                                    nestedcheck(stack.Count);
                                    starttagname = isTag? MiMFa_StringService.FirstFindAndSplit(starttag + " ", " ", 1).First().Replace("<", "").Replace(">", "").ToUpper():"";
                                    child.Push(new MiMFa_XMLElement(-1, starttagname, starttag, ""));
                                }
                                if (stack.Count > 0)
                                {
                                    starttag = stack.Pop();
                                    starttagname = MiMFa_StringService.FirstFindAndSplit(starttag + " ", " ", 1).First().Replace("<", "").Replace(">", "").ToUpper();
                                }
                                else
                                {
                                    starttag = "";
                                    starttagname = endtagname;
                                }
                                nestedcheck(stack.Count);
                                MiMFa_XMLElement elem = new MiMFa_XMLElement(-1, starttagname, starttag, endTag);
                                elem.Children = child.ToList();
                                child = new Stack<MiMFa_XMLElement>();
                                nested.Add(new KeyValuePair<int, MiMFa_XMLElement>(stack.Count, elem));
                            }
                            endTag = "";
                            route = MiMFa_Route.Null;
                        }
                        else endTag += xml[i];
                        break;
                }
            }
            while (stack.Count > 0)
            {
                nestedcheck(stack.Count);
                child.Push(new MiMFa_XMLElement(child.Count, "", stack.Pop(), ""));
            }
            nestedcheck(0);

            List<MiMFa_XMLElement> result = child.ToList();
            for (int i = 0; i < result.Count; i++)
            {
                result[i].Index = i;
                result[i].Parent = null;
                result[i].Refresh();
            }
            return result;
        }
        public static List<MiMFa_XMLElement> ToMiMFaXMLElements(string xml)
        {
            Stack<KeyValuePair<bool, MiMFa_XMLElement>> resultStack = new Stack<KeyValuePair<bool, MiMFa_XMLElement>>();
            string startTag = "", endTag = "";
            string mhtml = "";
            MiMFa_Route route = MiMFa_Route.Null;
            string quote = "'", dblquote = "\"", cmnt = "<!-", sign = "";
            Func<string, bool> Append = (value) =>
             {
                 if (route == MiMFa_Route.End)
                     endTag += value;
                 else startTag += value;
                 return true;
             };
            Func<bool> StartTag = () =>
            {
                startTag = startTag.Trim();
                if (string.IsNullOrEmpty(startTag)) return false;
                if (startTag.StartsWith("<"))// if is tag
                {
                    string[] tag = MiMFa_StringService.FirstFindAndSplit(startTag + " ", " ", 1);
                    string tagname = tag.First().Replace("<", "").Replace("/>", "").Replace(">", "").ToUpper();
                    resultStack.Push(new KeyValuePair<bool, MiMFa_XMLElement>(
                        !startTag.EndsWith("/>"),
                        new MiMFa_XMLElement(resultStack.Count, tagname, startTag, null, null)));
                }
                else // if is text
                {
                    resultStack.Push(new KeyValuePair<bool, MiMFa_XMLElement>(
                        false,
                        new MiMFa_XMLElement(resultStack.Count, "", startTag, "", null, null)));
                }
                startTag = "";
               return true;
            };
            Func<bool> EndTag = () =>
            {
                string tagname = endTag.Replace("</", "").Replace("<", "").Replace(">", "").Trim().ToUpper();
                if (string.IsNullOrEmpty(tagname)) return false;
                bool find = false;
                foreach (var item in resultStack)
                    if (find = item.Key && item.Value.TagName == tagname)
                        break;
                if (find)
                {
                    Stack<MiMFa_XMLElement> childStack = new Stack<MiMFa_XMLElement>();
                    find = false;
                    while (!find)
                    {
                        KeyValuePair<bool, MiMFa_XMLElement> kvp = resultStack.Pop();
                        if (find = kvp.Key && kvp.Value.TagName == tagname)
                        {
                            kvp.Value.Index = resultStack.Count;
                            kvp.Value.Children = childStack.ToList();
                            kvp.Value.EndTag = endTag;
                            resultStack.Push(new KeyValuePair<bool, MiMFa_XMLElement>(false, kvp.Value));
                        }
                        else childStack.Push(kvp.Value);
                    }
                }
                endTag = "";
                return true;
            };
            for (int i = 0; i < xml.Length; i++)
            {
                mhtml = xml.Substring(i);
                if (sign == "")
                    if (mhtml.StartsWith(quote))
                    { Append(sign = quote); i += quote.Length - 1; }
                    else if (mhtml.StartsWith(dblquote))
                    { Append(sign = dblquote); i += dblquote.Length - 1; }
                    else if (mhtml.StartsWith(cmnt))
                    { sign = "-->"; Append(cmnt); i += cmnt.Length - 1; }
                    else switch (route)
                        {
                            case MiMFa_Route.Start:
                                if (mhtml.StartsWith("/>"))
                                {
                                    startTag += "/>";
                                    StartTag();
                                    i++;
                                    route = MiMFa_Route.Null;
                                }
                                else if (mhtml.StartsWith(">"))
                                {
                                    startTag += ">";
                                    StartTag();
                                    route = MiMFa_Route.Middle;
                                }
                                else startTag += xml[i];
                                break;
                            case MiMFa_Route.End:
                                if (mhtml.StartsWith(">"))
                                {
                                    endTag += ">";
                                    EndTag();
                                    route = MiMFa_Route.Null;
                                }
                                else endTag += xml[i];
                                break;
                            //case MiMFa_Route.Null:
                            //case MiMFa_Route.Middle:
                            default:
                                if (mhtml.StartsWith("</"))
                                {
                                    StartTag();
                                    endTag = "</";
                                    i++;
                                    route = MiMFa_Route.End;
                                }
                                else if (mhtml.StartsWith("<"))
                                {
                                    StartTag();
                                    startTag = "<";
                                    route = MiMFa_Route.Start;
                                }
                                else startTag += xml[i];
                                break;
                        }
                else if (mhtml.StartsWith(sign))
                { Append(sign); i += sign.Length - 1; sign = ""; }
                else Append(xml[i] + "");
            }
            List<MiMFa_XMLElement> result = (resultStack.Count > 0)? (from kvp in resultStack select kvp.Value).Reverse().ToList():new List<MiMFa_XMLElement>();
            for (int i = 0; i < result.Count; i++)
                result[i].Refresh();
            return result;
        }

        public static Dictionary<string,string> ToDictionaryRecord(List<MiMFa_XMLElement> xmls,string attrName)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < xmls.Count; i++)
                if (string.IsNullOrWhiteSpace(xmls[i].TagName))
                {
                    string p = xmls[i].Parent == null ? "" : xmls[i].Parent.TagName + ":"+xmls[i].Parent.GetAttribute(attrName);
                    try { dic.Add(p, xmls[i].StartTag); }
                    catch { dic.Add(p + "_" + dic.Count, xmls[i].StartTag); }
                }
                else
                {
                    Dictionary<string, string> d = ToDictionaryRecord(xmls[i].Children, attrName);
                    foreach (var item in d)
                        try { dic.Add(item.Key, item.Value); }
                        catch { dic.Add(item.Key+ "_" + dic.Count, item.Value); }
                }
            return dic;
        }
        public static List<KeyValuePair<string, string>> ToListRecord(List<MiMFa_XMLElement> xmls,string attrName)
        {
            List<KeyValuePair<string, string>> dic = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < xmls.Count; i++)
                if (string.IsNullOrWhiteSpace(xmls[i].TagName))
                {
                    string p = xmls[i].Parent == null ? "" : xmls[i].Parent.TagName + ":"+xmls[i].Parent.GetAttribute(attrName);
                    dic.Add(new KeyValuePair<string, string>(p, xmls[i].StartTag));
                }
                else
                {
                    List<KeyValuePair<string, string>> d = ToListRecord(xmls[i].Children, attrName);
                    dic.AddRange(d);
                }
            return dic;
        }
        #endregion
    }
}

