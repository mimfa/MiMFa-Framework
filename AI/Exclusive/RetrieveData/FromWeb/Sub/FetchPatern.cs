using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.RetrieveData.FromWeb
{
    [Serializable]
    public enum FetchType
    {
        Null = -1,
        Simple = 0,
        Loop = 1,
        InterActive = 2,
        InterActiveLoop = 3
    }
    [Serializable]
    public struct FetchPatern
    {
        public string Name { get; set; }
        public string URL => this + "";
        public string BaseURL { get; set; }
        public List<URLRequest> Requests { get; set; }
        public List<HTMLElementPatern> HTMLElementsPatern { get; set; }
        public List<MiMFa_XMLElement> SampleHTMLElements { get; set; }

        public Object Parent { get; set; }
        public string Source { get; set; }
        public object Extra { get; set; }
        public FetchType FetchType { get; set; }
        public bool TransposeResult { get; set; }
        public bool ValidURLCharacters { get; set; }
        public int IntervalDelay { get; set; }
        public int MaximumTry { get; set; }
        public int Alert { get; set; }
        public bool FetchSuccessFul { get; set; }

        public string TableAddress { get; set; }

        public FetchPatern(string name,string baseurl, List<URLRequest> requests, object parent = null, FetchType fetchType = FetchType.Simple, string source = "",bool transpose = false, bool toValidCharacters = false,int intervalDelay = 2000,int maximumTry = 15,int alert = 1,object extra = null)
        {
            TransposeResult = transpose;
            Name = name;
            FetchType = fetchType;
            Parent = parent;
            TableAddress = "";
            Source = source;
            FetchSuccessFul = false;
            Alert = alert;
            ValidURLCharacters = toValidCharacters;
            IntervalDelay = intervalDelay;
            MaximumTry = maximumTry;
            baseurl = MiMFa_Convert.ToAbsoluteURL(baseurl);
            Extra = extra;
            BaseURL = baseurl;
            Requests = requests;
            HTMLElementsPatern = new List<HTMLElementPatern>();
            SampleHTMLElements = new List<MiMFa_XMLElement>();
        }
        public FetchPatern(string name, string url, object parent = null, FetchType fetchType = FetchType.Simple, string source = "",bool transpose = false, bool toValidCharacters = false, int intervalDelay = 2000, int maximumTry = 15, int alert = 1, object extra = null)
        {
            Name = name;
            FetchType = fetchType;
            Parent = parent;
            TableAddress = "";
            TransposeResult = transpose;
            Source = source;
            FetchSuccessFul = false;
            Alert = alert;
            ValidURLCharacters = toValidCharacters;
            IntervalDelay = intervalDelay;
            MaximumTry = maximumTry;
            url = MiMFa_Convert.ToAbsoluteURL(url);
            Extra = extra;
            var gurl = CreateURLPaternKeyValuePair(url, toValidCharacters);
            BaseURL = gurl.Key;
            Requests = gurl.Value;
            HTMLElementsPatern = new List<HTMLElementPatern>();
            SampleHTMLElements = new List<MiMFa_XMLElement>();
        }
        public FetchPatern(string name, string baseurl, List<URLRequest> requests, List<HTMLElementPatern> htmlElementsPatern, List<MiMFa_XMLElement> sampleHTMLElements, object parent = null, FetchType fetchType = FetchType.Simple, string source = "",bool transpose = false, bool toValidCharacters = false, int intervalDelay = 2000, int maximumTry = 15, int alert = 1, object extra = null)
        {
            Name = name;
            FetchType = fetchType;
            Parent = parent;
            TransposeResult = transpose;
            TableAddress = "";
            Source = source;
            FetchSuccessFul = false;
            Alert = alert;
            ValidURLCharacters = toValidCharacters;
            IntervalDelay = intervalDelay;
            MaximumTry = maximumTry;
            baseurl = MiMFa_Convert.ToAbsoluteURL(baseurl);
            Extra = extra;
            BaseURL = baseurl;
            Requests = requests;
            HTMLElementsPatern = htmlElementsPatern;
            SampleHTMLElements = sampleHTMLElements;
        }
        public FetchPatern(string name, string url, List<HTMLElementPatern> htmlElementsPatern, List<MiMFa_XMLElement> sampleHTMLElements, object parent = null, FetchType fetchType = FetchType.Simple, string source = "",bool transpose = false, bool toValidCharacters = false, int intervalDelay = 2000, int maximumTry = 15, int alert = 1, object extra = null)
        {
            Name = name;
            FetchType = fetchType;
            Parent = parent;
            TableAddress = "";
            TransposeResult = transpose;
            Source = source;
            FetchSuccessFul = false;
            Alert = alert;
            ValidURLCharacters = toValidCharacters;
            IntervalDelay = intervalDelay;
            MaximumTry = maximumTry;
            url = MiMFa_Convert.ToAbsoluteURL(url);
            Extra = extra;
            var gurl = CreateURLPaternKeyValuePair(url, toValidCharacters);
            BaseURL = gurl.Key;
            Requests = gurl.Value;
            this.HTMLElementsPatern = htmlElementsPatern;
            this.SampleHTMLElements = sampleHTMLElements;
        }
        public FetchPatern(FetchPatern fp, string source, object extra)
        {
            Name = fp.Name;
            FetchType = fp.FetchType;
            Parent = fp.Parent;
            TransposeResult = fp.TransposeResult;
            TableAddress = "";
            Source = source;
            FetchSuccessFul = false;
            Alert = fp.Alert;
            ValidURLCharacters = fp.ValidURLCharacters;
            IntervalDelay = fp.IntervalDelay;
            MaximumTry = fp.MaximumTry;
            BaseURL = fp.BaseURL;
            Requests = new List<URLRequest>();
            foreach (var item in fp.Requests)
                Requests.Add(new URLRequest(item));
            HTMLElementsPatern = new List<HTMLElementPatern>();
            foreach (var item in fp.HTMLElementsPatern)
                HTMLElementsPatern.Add(new HTMLElementPatern(item));
            SampleHTMLElements = fp.SampleHTMLElements;
            Extra = extra ?? fp.Extra;
        }
        public FetchPatern(FetchPatern fp, string url, string source, object extra)
        {
            Name = fp.Name;
            FetchType = fp.FetchType;
            Parent = fp.Parent;
            TableAddress = "";
            TransposeResult = fp.TransposeResult;
            Source = source;
            FetchSuccessFul = false;
            ValidURLCharacters = fp.ValidURLCharacters;
            Alert = fp.Alert;
            IntervalDelay = fp.IntervalDelay;
            MaximumTry = fp.MaximumTry;
            url = MiMFa_Convert.ToAbsoluteURL(url);
            var gurl = CreateURLPaternKeyValuePair(url, fp.Requests, fp.ValidURLCharacters);
            BaseURL = gurl.Key;
            Requests = gurl.Value;
            HTMLElementsPatern = new List<HTMLElementPatern>();
            foreach (var item in fp.HTMLElementsPatern)
                HTMLElementsPatern.Add(new HTMLElementPatern(item));
            SampleHTMLElements = fp.SampleHTMLElements;
            Extra = extra ?? fp.Extra;
        }
        public FetchPatern(FetchPatern fp, string url)
        {
            Name = fp.Name;
            FetchType = fp.FetchType;
            Parent = fp.Parent;
            TransposeResult = fp.TransposeResult;
            TableAddress = "";
            FetchSuccessFul = false;
            ValidURLCharacters = fp.ValidURLCharacters;
            Source = fp.Source;
            Alert = fp.Alert;
            IntervalDelay = fp.IntervalDelay;
            MaximumTry = fp.MaximumTry;
            Extra = fp.Extra;
            url = MiMFa_Convert.ToAbsoluteURL(url);
            var gurl = CreateURLPaternKeyValuePair(url,fp.Requests, fp.ValidURLCharacters);
            BaseURL = gurl.Key;
            Requests = gurl.Value;
            HTMLElementsPatern = new List<HTMLElementPatern>();
            foreach (var item in fp.HTMLElementsPatern)
                HTMLElementsPatern.Add(new HTMLElementPatern(item));
            SampleHTMLElements = fp.SampleHTMLElements;
        }

        public FetchPatern Create(string source,object extra, params string[] values)
        {
            FetchPatern fp = new FetchPatern(this, source, extra);
            int j = 0;
            for (int i = 0; i < fp.Requests.Count; i++)
                if (fp.Requests[i].AllowReplaceValue)
                    fp.Requests[i] = new URLRequest(fp.Requests[i].Name, fp.Requests[i].DefaultValue,values.Length>j?values[j++]:"", fp.Requests[i].Title, ValidURLCharacters);
            return fp;
        }
        public FetchPatern Create(string value,string source, object extra = null)
        {
            FetchPatern fp = new FetchPatern(this,source,extra);
            for (int i = 0; i < fp.Requests.Count; i++)
                if (fp.Requests[i].AllowReplaceValue)
                    fp.Requests[i] = new URLRequest(fp.Requests[i].Name, fp.Requests[i].DefaultValue,value, fp.Requests[i].Title, ValidURLCharacters);
            return fp;
        }

        public static FetchPatern ChangeBaseURL(FetchPatern fp,string baseurl, object extra = null)
        {
            fp.BaseURL = baseurl + "";
            return fp;
        }
        public static FetchPatern AppendLocalURL(FetchPatern fp, string baseurl, object extra = null)
        {
            bool b0 = fp.BaseURL.EndsWith("/");
            bool b1 = baseurl.StartsWith("/");
            if (b0 != b1) fp.BaseURL += baseurl;
            else if (!b0) fp.BaseURL += "/" + baseurl;
            else fp.BaseURL += baseurl.Substring(1);
            fp.Extra = extra;
            return fp;
        }
        public static FetchPatern UpdateURLRequests(FetchPatern fp, string value)
        {
            if (value == null) return fp;
            for (int i = 0; i < fp.Requests.Count; i++)
                if (fp.Requests[i].AllowReplaceValue) fp.Requests[i] = new URLRequest(fp.Requests[i].Name, value, fp.Requests[i].Title, fp.Requests[i].AllowReplaceValue,fp.ValidURLCharacters);
            return fp;
        }
        public static FetchPatern UpdateURLRequests(FetchPatern fp,params string[] values)
        {
            if (values.Length < 1) return fp;
            int r = 0;
            for (int i = 0; i < fp.Requests.Count; i++)
                if (fp.Requests[i].AllowReplaceValue) fp.Requests[i] = new URLRequest(fp.Requests[i].Name, values.Length > r?values[r++]:"", fp.Requests[i].Title, fp.Requests[i].AllowReplaceValue,fp.ValidURLCharacters);
            return fp;
        }

        public bool IsDuplicate(FetchPatern withThisElement)
        {
            return IsDuplicate(this, withThisElement);
        }
        public bool IsSame(FetchPatern withThisElement)
        {
            return IsSame(this, withThisElement);
        }
        public bool IsLike(FetchPatern withThisElement)
        {
            return IsLike(this, withThisElement);
        }

        public bool IsLoop()
        {
            return IsLoop(this);
        }
        public bool IsInteractive()
        {
            return IsInteractive(this);
        }

        public static bool IsDuplicate(FetchPatern thisElem, FetchPatern withThisElem)
        {
            bool b = thisElem.Name == withThisElem.Name && thisElem.BaseURL == withThisElem.BaseURL && thisElem.Requests.Count == withThisElem.Requests.Count;
            if (b)
                for (int i = 0; i < thisElem.Requests.Count; i++)
                    if (withThisElem.Requests.FindIndex((r) => r.Name == thisElem.Requests[i].Name && r.DefaultValue == thisElem.Requests[i].DefaultValue) < 0)
                        return false;
            return b;
        }
        public static bool IsSame(FetchPatern thisElem, FetchPatern withThisElem)
        {
            bool b = thisElem.Name == withThisElem.Name && thisElem.BaseURL == withThisElem.BaseURL && thisElem.Requests.Count == withThisElem.Requests.Count;
            if (b)
                for (int i = 0; i < thisElem.Requests.Count; i++)
                    if (withThisElem.Requests.FindIndex((r) => r.Name == thisElem.Requests[i].Name) < 0)
                        return false;
            return b;
        }
        public static bool IsLike(FetchPatern thisElem, FetchPatern withThisElem)
        {
            bool b = thisElem.BaseURL == withThisElem.BaseURL;
            if (b)
            {
                List<URLRequest> min = new List<URLRequest>();
                List<URLRequest> max = new List<URLRequest>();
                if(thisElem.Requests.Count > withThisElem.Requests.Count)
                {
                    max = thisElem.Requests;
                    min = withThisElem.Requests;
                }
                else
                {
                    min = thisElem.Requests;
                    max = withThisElem.Requests;
                }
                for (int i = 0; i < min.Count; i++)
                    if (max.FindIndex((r) => r.Name == min[i].Name) < 0)
                        return false;
            }
            return b;
        }

        public static bool IsLoop(FetchPatern fp)
        {
            return fp.FetchType == FetchType.InterActiveLoop || fp.FetchType == FetchType.Loop;
        }
        public static bool IsInteractive(FetchPatern fp)
        {
            return fp.FetchType == FetchType.InterActiveLoop || fp.FetchType == FetchType.InterActive;
        }

        public override string ToString() => URL;

        public static implicit operator KeyValuePair<string, List<URLRequest>>(FetchPatern patern)
        {
            return new KeyValuePair<string, List<URLRequest>>(patern.BaseURL?? "", patern.Requests?? new List<URLRequest>());
        }
        public static explicit operator FetchPatern(KeyValuePair<string, List<URLRequest>> kvp)
        {
            return new FetchPatern(kvp.Key, kvp.Key, kvp.Value);
        }

        public static implicit operator string(FetchPatern patern)
        {
            string url = patern.BaseURL + "";
            var reqs = patern.Requests;
            url = MiMFa_Convert.ToAbsoluteURL(url);
            if (reqs != null && reqs.Count > 0)
            {
                url = url.Split('?').First() + "?";
                foreach (var item in reqs)
                  url += string.Join("", item.Name , "=" , item.Value , "&");
                url = url.Substring(0, url.Length - 1);
            }
            return url;
        }
        public static explicit operator FetchPatern(string url)
        {
            return CreateWithURL(url);
        }

        public static FetchPatern CreateWithURL(string url)
        {
            string[] sa = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(url, "?");
            List<URLRequest> reqList = new List<URLRequest>();
            if (sa.Length > 1)
                foreach (var item in sa.Last().Split('&'))
                    reqList.Add(CreateRequest(item));
            return new FetchPatern(sa.First(), sa.First(), reqList);
        }
        public static KeyValuePair<string, List<URLRequest>> CreateURLPaternKeyValuePair(string url, bool toValidChar = true)
        {
            string[] sa = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(url, "?");
            List<URLRequest> reqList = new List<URLRequest>();
            if (sa.Length > 1)
                foreach (var item in sa.Last().Split('&'))
                    reqList.Add(CreateRequest(item, toValidChar));
            return new KeyValuePair<string, List<URLRequest>>(sa.First(), reqList);
        }
        public static KeyValuePair<string, List<URLRequest>> CreateURLPaternKeyValuePair(string url, List<URLRequest> patern, bool toValidChar = true)
        {
            string[] sa = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(url, "?");
            List<URLRequest> reqList = new List<URLRequest>();
            if (sa.Length > 1)
                foreach (var item in sa.Last().Split('&'))
                {
                    int ind = patern.FindIndex((p) => item.StartsWith(p.Name));
                    reqList.Add(CreateRequest(item,ind>-1?patern[ind]:new URLRequest(), toValidChar));
                }
            return new KeyValuePair<string, List<URLRequest>>(sa.First(), reqList);
        }
        public static URLRequest CreateRequest(string request, bool toValidChar = true)
        {
            string[] sa = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(request, "=");
            string name = sa.First();
            string value = (sa.Length > 1) ? sa.Last() : "";
            return new URLRequest(name, value, "", false, toValidChar);
        }
        public static URLRequest CreateRequest(string request, URLRequest paternrequest, bool toValidChar = true)
        {
            string[] sa = MiMFa_Framework.Service.MiMFa_StringService.FirstFindAndSplit(request, "=");
            string name = sa.First();
            string value = (sa.Length > 1) ? sa.Last() : "";
            return new URLRequest(name, value, "", paternrequest.AllowReplaceValue, toValidChar);
        }
    }
}
