using System;
using MiMFa_Framework.General;
using MiMFa_Framework.Exclusive.RetrieveData;
using MiMFa_Framework.Exclusive.RetrieveData.FromWeb;
using MiMFa_Framework.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MiMFa_Framework.Exclusive.ProgramingTechnology.CommandLanguage;
using System.Data;
using MiMFa_Framework.Network;
using MiMFa_Framework.Model;
using System.Windows.Forms;
using MiMFa_Framework.Exclusive.Collection;

namespace MiMFa_Framework.Exclusive.RetrieveData.FromWeb
{
    public delegate void URLEventHandler(object sender, FetchPatern url);
    public delegate void GetTableEventHandler(object sender, MiMFa_Table table, FetchPatern url);
    public delegate void GetTableMessageEventHandler(object sender, FetchPatern url, string message);
    public delegate void GetTableErrorEventHandler(object sender, FetchPatern url, string html,Exception ex);

    [Serializable]
    public class WebRetriever
    {
        public event URLEventHandler GetTableStart = (o, u) => { };
        public event URLEventHandler GetTableStop = (o, u) => { };
        public event URLEventHandler GetTableResume = (o, u) => { };
        public event URLEventHandler GetTableComplete = (o, u) => { };
        public event URLEventHandler URLNavigated = (o, u) => { };
        public event URLEventHandler GettingTableStart = (o, u) => { };
        public event URLEventHandler GettingTablePause = (o, u) => { };
        public event URLEventHandler GettingTable = (o, u) => { };
        public event GetTableEventHandler GettingTableSuccess = (o, t, u) => { };
        public event GetTableErrorEventHandler GettingTableError = (o, u, h, ex) => { };
        public event URLEventHandler CurrentPaternChanged = (o, u) => { };
        public event GetTableMessageEventHandler GettingTableInteractivePause = (o, u, m) => { };

        public string BeginDocument { get; set; } = "";
        public string FinishDocument { get; set; } = "";
        public string TempDirectory { get; set; } = Address.TempDirectory + "WebRetriever\\";

        public bool IsGotTable => FetchedSuccessList.Count > 0;
        public bool IsGetTableCompleted => FetchQueue.Count < 1 && !IsGetTableRun;
        public bool IsGetTableRun { get { return fetch_timer.Enabled; } set { fetch_timer.Enabled = value; } }

        public Queue<FetchPatern> FetchQueue = new Queue<FetchPatern>();
        public List<FetchPatern> FetchedSuccessList = new List<FetchPatern>();
        public List<FetchPatern> FetchedErrorList = new List<FetchPatern>();

        public int NumberOfAllPaterns => FetchedSuccessList.Count + FetchedErrorList.Count + FetchQueue.Count;
        public int NumberOfAllTableRows { get; set; } = 0;
        public int NumberOfLastTableRows { get; set; } = 0;

        public MiMFa_Table SampleTable = new MiMFa_Table();

        private int fetch_try_interval = 0;
        private WebBrowser fetch_browser = new WebBrowser();
        private Timer fetch_timer = new Timer();
        private WebPatern fetch_webpatern = new WebPatern();
        private FetchPatern fetch_url;

        public static string FileDialogFilter => "MiMFa Web Retriever Patern File (*" + Extention + ") | *" + Extention + ";";
        public static string Extention = ".mwrp";
        public void SaveInFile(string fileaddress)
        {
            SaveInFile(fetch_webpatern, fileaddress);
        }
        public static void SaveInFile(WebPatern wr, string fileaddress)
        {
            MiMFa_IOService.SaveSerializeFile(fileaddress, wr);
        }
        public void FromFile(string fileaddress)
        {
            fetch_webpatern = OpenFromFile(fileaddress);
        }
        public static WebPatern OpenFromFile(string fileaddress)
        {
            WebPatern wr = new WebPatern();
            MiMFa_IOService.OpenDeserializeFile(fileaddress, ref wr);
            return wr;
        }

        public WebRetriever()
        {
            MiMFa_Path.CreateAllDirectories(TempDirectory);
            MiMFa_Path.DeleteAllFilesInAllDirectoriesInPath(TempDirectory);
            SetBrowser(fetch_browser);
            SetTimer(fetch_timer);
        }

        public void SetBrowser(WebBrowser wb)
        {
            fetch_browser = wb;
            fetch_browser.ScriptErrorsSuppressed = true;
            MiMFa_ControlService.WebBrowserDocument(ref fetch_browser, BeginDocument);
            fetch_browser.Navigated += (s, e) => { if (!IsGetTableCompleted)
                {
                    if(!fetch_url.IsInteractive()) fetch_url = GetCurrentPatern();
                    URLNavigated(fetch_browser, fetch_url);
                }
            };
            fetch_browser.NewWindow += (s, e) =>
            {
                e.Cancel = true;
                fetch_browser.Navigate(fetch_browser.StatusText);
            };
        }
        public void SetTimer(Timer timer)
        {
            fetch_timer = timer;
            fetch_timer.Enabled = false;
            fetch_timer.Interval = 1000;
            fetch_timer.Tick += (s, e) => FetchCurrent();
        }

        public bool NavigateNext()
        {
            if (!IsGetTableRun) return false;
            bool b = FetchQueue.Count > 0;
            fetch_try_interval = 0;
            if (b)
            {
                GettingTableStart(this, fetch_url = FetchQueue.Dequeue());
                if (fetch_url.IsLoop()) FetchQueue.Enqueue(fetch_url);
                fetch_timer.Interval = fetch_url.IntervalDelay;
                fetch_browser.Tag = fetch_url.URL;
                fetch_browser.Navigate(new Uri(fetch_url.URL));
                if (fetch_url.IsInteractive())
                {
                    PauseFetch();
                    GettingTableInteractivePause(this, fetch_url, "Process is paused for get a new order!");
                }
            }
            else
            {
                IsGetTableRun = false;
                MiMFa_ControlService.WebBrowserDocument(ref fetch_browser, FinishDocument);
                GetTableComplete(this, fetch_url);
                fetch_url = new FetchPatern();
            }
            return b;
        }
        public void FetchCurrent()
        {
            string html = fetch_browser.DocumentText+"";
            if (fetch_url.FetchSuccessFul = (
                !fetch_browser.IsBusy 
                || (fetch_try_interval >= fetch_url.MaximumTry-1 && html.Length > 1000)
                ) && html.Length>1)
            {
                GettingTable(this, fetch_url);
                MiMFa_Table dt = GetTable(fetch_url);
                if (dt != null && dt.MainTable.Rows.Count > 1) CurrentPaternSuccess(dt);
                else CurrentPaternError(new Exception("Can not fetch table of document!"), html);
            }
            else
            {
                if (fetch_try_interval++ > fetch_url.MaximumTry)
                    CurrentPaternError(new Exception("This Document is not trust!"), html);
                else if (!MiMFa_Internet.IsWellURL(fetch_url.ToString().Replace(" ", "+")))
                    GettingTableError(this, fetch_url, html, new Exception("This URL is not trust!"));
                else
                    GettingTableError(this, fetch_url, html, new Exception("Trying to navigate this URL..."));
            }
        }

        public FetchPatern GetCurrentPatern()
        {
            FetchPatern fp = fetch_webpatern.FindFetchPatern(fetch_browser.Url + "", fetch_url.Source);
            fp.Parent = fetch_url;
            fp.Extra = fetch_url.Extra;
            return fp;
        }
        public FetchPatern GetCurrentChildPatern()
        {
            //FetchPatern fp = fetch_webpatern.FindFetchPaternChildFor(fetch_browser.Url + "",fetch_url.Source);
            FetchPatern fp = fetch_webpatern.FindFetchPaternChildFor(new FetchPatern("", fetch_browser.Url + "", fetch_url,FetchType.Simple, fetch_url.Source, fetch_url.TransposeResult, fetch_url.ValidURLCharacters, fetch_url.IntervalDelay, fetch_url.MaximumTry, fetch_url.Alert, fetch_url.Extra));
            fp.Parent = fetch_url;
            fp.Extra = fetch_url.Extra;
            return fp;
        }
        public void CurrentPaternChange(FetchPatern patern)
        {
            fetch_url = patern;
            fetch_timer.Interval = fetch_url.IntervalDelay;
            IsGetTableRun = true;
            CurrentPaternChanged(this, fetch_url);
        }
        public void CurrentPaternSuccess(MiMFa_Table dt)
        {
            FetchedSuccessList.Add(fetch_url);
            GettingTableSuccess(this, dt, fetch_url);
            NavigateNext();
        }
        public void CurrentPaternError(Exception ex, string html="")
        {
            GettingTableError(this, fetch_url, html, ex);
            FetchedErrorList.Add(fetch_url);
            IsGetTableRun = true;
            NavigateNext();
        }

        public void StartFetch(bool resume = false)
        {
            IsGetTableRun = true;
            if (resume) GetTableResume(this, fetch_url);
            else
            {
                GetTableStart(this, fetch_url);
                NavigateNext();
            }
        }
        public void StartFetch(WebPatern patern)
        {
            SetPatern(patern);
            StartFetch(false);
        }
        public void ResumeFetch()
        {
            StartFetch(true);
        }
        public void StopFetch()
        {
            IsGetTableRun = false;
            FetchQueue.Clear();
            GetTableStop(this, fetch_url);
        }
        public void PauseFetch()
        {
            IsGetTableRun = false;
            GettingTablePause(this, fetch_url);
        }

        public void SetPatern(WebPatern patern)
        {
            fetch_webpatern = patern;
            FetchQueue = new Queue<FetchPatern>();
            FetchedSuccessList = new List<FetchPatern>();
            FetchedErrorList = new List<FetchPatern>();
            NumberOfAllTableRows = 0;
            NumberOfLastTableRows = 0;

            AppendInFetchQueue(patern,false);
        }
        public void AppendInFetchQueue(WebPatern patern,bool start =false)
        {
            foreach (var item in patern.FetchList)
                FetchQueue.Enqueue(item);
            if(start) StartFetch(false);
        }
        public void AppendInFetchQueue(FetchPatern url, bool start = false)
        {
            FetchQueue.Enqueue(url);
            if(start)StartFetch(false);
        }
        public MiMFa_Table FetchSampleTable()
        {
            return FetchSampleTable(fetch_webpatern);
        }
        public MiMFa_Table FetchSampleTable(WebPatern patern)
        {
            if (patern.Paterns.Count == 0 && patern.DefaultPatern != null) return SampleTable = GetTable(patern.DefaultPatern, MiMFa_XMLElement.GetCopy(patern.DefaultPatern.SampleHTMLElements));
            return SampleTable;
        }

        public MiMFa_Table GetTable(int numberOfItems = -1)
        {
            if (FetchedSuccessList.Count < 1) return fetch_webpatern.DefaultPatern.TransposeResult? FetchSampleTable(fetch_webpatern).Transpose(true) : FetchSampleTable(fetch_webpatern);
            MiMFa_Table mdt = new MiMFa_Table();
            if (numberOfItems < 0)
                foreach (var item in FetchedSuccessList)
                {
                    if (!string.IsNullOrWhiteSpace(item.TableAddress))
                        try
                        {
                            MiMFa_Table dt = null;
                            MiMFa_IOService.OpenDeserializeFile(item.TableAddress, ref dt);
                            if (dt != null) mdt.ConcatTable(dt);
                        }
                        catch { }
                }
            else
            {
                int ind = 0;
                foreach (var item in FetchedSuccessList)
                {
                    if (ind++ == numberOfItems) break;
                    if (!string.IsNullOrWhiteSpace(item.TableAddress))
                        try
                        {
                            MiMFa_Table dt = null;
                            MiMFa_IOService.OpenDeserializeFile(item.TableAddress, ref dt);
                            if (dt != null) mdt.ConcatTable(dt);
                        }
                        catch { }
                }
            }
            return mdt;
        }
        public MiMFa_Table GetTable(FetchPatern patern)
        {
            return GetTable(patern,MiMFa_Convert.ToMiMFaHTMLElements(fetch_browser));
        }
        public MiMFa_Table GetTable(FetchPatern patern, List<MiMFa_XMLElement> xmls)
        {
            MiMFa_Table mdt = new MiMFa_Table();
            if (patern.HTMLElementsPatern == null) return mdt;
            List<HTMLElementPatern> continuehep = new List<HTMLElementPatern>();
            MiMFa_CollectionService.CopyTo(ref continuehep, patern.HTMLElementsPatern);
            List<MiMFa_XMLElement> me = new List<MiMFa_XMLElement>();
            foreach (var item in patern.HTMLElementsPatern)
                me.Add(item.SampleHTMLElement);
            MiMFa_XMLElement e = MiMFa_XMLElement.GetElementsCommonParent(me);
            while (continuehep.Count > 0)
            {
                if (e != null) e = MiMFa_XMLElement.Find(xmls, e);
                List<MiMFa_XMLElement> scope = e == null ? xmls : new List<MiMFa_XMLElement>() { e };
                bool all = false;
                MiMFa_XMLElement elem = null;
                int len = continuehep.Count;
                for (int i = 0; i < len; i++)
                {
                    MiMFa_XMLElement ele = null;
                    mdt = GetTable(mdt, continuehep[i], scope, out ele);
                    if (continuehep[i].All != MiMFa_Boolean.True)
                    {
                        continuehep.RemoveAt(i);
                        i--;
                        len--;
                    }
                    else if (ele != null)
                    {
                        elem = ele;
                        all = true;
                    }
                    if (ele != null)
                        if (continuehep.Count - 1 > i + 1 && continuehep[i].SampleHTMLElement == continuehep[i + 1].SampleHTMLElement.Parent)
                            ele.StartTag = "";
                        else xmls = MiMFa_XMLElement.GetLastSplitIn(xmls, ele);
                }
                if (e == null) break;
                if (elem == null) xmls = MiMFa_XMLElement.GetLastSplitIn(xmls, e);
                else if (all) xmls = MiMFa_XMLElement.GetLastSplitIn(xmls, elem);
                else break;
            }
            //
            if (fetch_url.TransposeResult) mdt = mdt.Transpose(true);
            NumberOfLastTableRows = mdt.MainTable.Rows.Count - 1;
            NumberOfAllTableRows += NumberOfLastTableRows;
            if (string.IsNullOrWhiteSpace(fetch_url.TableAddress)) fetch_url.TableAddress = TempDirectory + DateTime.Now.Ticks + MiMFa_Table.Extention;
            if (NumberOfLastTableRows > 0)
                try
                {
                    if (!string.IsNullOrWhiteSpace(fetch_url.Source))
                    {
                        DataColumn dcs = mdt.AddColumnSafe("auto_Source");
                        for (int i = 1; i < mdt.Rows.Count; i++)
                            mdt.Rows[i][dcs] = fetch_url.Source;
                    }
                }
                catch { }
            try
            {
                MiMFa_Table nmt = null;
                MiMFa_IOService.OpenDeserializeFile(fetch_url.TableAddress, ref nmt);
                if (nmt != null) nmt = MiMFa_Table.ConcatTable(nmt, mdt);
            }
            catch { }
            MiMFa_IOService.SaveSerializeFile(fetch_url.TableAddress, mdt);
            return mdt;
        }
        public MiMFa_Table GetTable(MiMFa_Table dt,HTMLElementPatern elementPatern, List<MiMFa_XMLElement> xmls,out MiMFa_XMLElement elem)
        {
            elem = null;
            switch (elementPatern.ElementSimilarity)
            {
                case MiMFa_Similarity.Congruent:
                    elem = MiMFa_XMLElement.FindCongruent(xmls, elementPatern.SampleHTMLElement);
                    break;
                case MiMFa_Similarity.Like:
                    elem = MiMFa_XMLElement.FindLike(xmls, elementPatern.SampleHTMLElement);
                    break;
                case MiMFa_Similarity.Same:
                    elem = MiMFa_XMLElement.FindSame(xmls, elementPatern.SampleHTMLElement);
                    break;
                case MiMFa_Similarity.Duplicate:
                    elem = MiMFa_XMLElement.FindDuplicate(xmls, elementPatern.SampleHTMLElement);
                    break;
                case MiMFa_Similarity.This:
                    elem = MiMFa_XMLElement.Find(xmls, elementPatern.SampleHTMLElement);
                    break;
            }
            return AddInTable(dt,elementPatern, elem, xmls);
        }

        public string GetValueFromXML(HTMLElementPatern elementPatern, MiMFa_XMLElement elem)
        {
            switch (elementPatern.Usage)
            {
                case MiMFa_Usage.Null:
                case MiMFa_Usage.Get:
                    switch (elementPatern.ElementItems)
                    {
                        case MiMFa_XMLElementItems.Null:
                        case MiMFa_XMLElementItems.ThisContent:
                            return elem.OuterText;
                        case MiMFa_XMLElementItems.ThisTag:
                            return elem.Outer;
                        case MiMFa_XMLElementItems.ThisAttribute:
                            return elem.GetAttribute(elementPatern.AttributeName);
                        case MiMFa_XMLElementItems.ChildContent:
                            return (elem.GetFirstChildElementByTagName(elementPatern.ChildName) ?? new MiMFa_XMLElement(-1, "", "", "")).OuterText;
                        case MiMFa_XMLElementItems.ChildTag:
                            return (elem.GetFirstChildElementByTagName(elementPatern.ChildName) ?? new MiMFa_XMLElement(-1, "", "", "")).Outer;
                        case MiMFa_XMLElementItems.ChildAttribute:
                            return (elem.GetFirstChildElementByTagName(elementPatern.ChildName) ?? new MiMFa_XMLElement(-1, "", "", "")).GetAttribute(elementPatern.AttributeName);
                        case MiMFa_XMLElementItems.ChildrenContent:
                            return (new MiMFa_XMLElement(-1, "", "", "") { Children = elem.GetChildrenElementsByTagName(elementPatern.ChildName) }).OuterText;
                        case MiMFa_XMLElementItems.ChildrenTag:
                            return (new MiMFa_XMLElement(-1, "", "", "") { Children = elem.GetChildrenElementsByTagName(elementPatern.ChildName) }).Outer;
                        case MiMFa_XMLElementItems.ChildrenAttribute:
                            return MiMFa_CollectionService.GetAllItems((new MiMFa_XMLElement(-1, "", "", "") { Children = elem.GetChildrenElementsByTagName(elementPatern.ChildName) }).GetChildAttributes(elementPatern.AttributeName),"¶");
                    }
                    break;
                case MiMFa_Usage.Set:
                    string str = elem.GetAttribute("href");
                    if (string.IsNullOrWhiteSpace(str)) str = elem.GetAttribute("src");
                    if (string.IsNullOrWhiteSpace(str)) str = elem.GetAttribute("url");
                    if (string.IsNullOrWhiteSpace(str)) str = elem.InnerText;
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        if (Uri.IsWellFormedUriString(str, UriKind.Relative))
                            str = MiMFa_Internet.GetBaseWebURL(fetch_url) + (str.StartsWith("/") ? "" : "/") + str;
                    }
                    else str = elem.OuterText;
                    return str;
            }
            return " ";
        }

        public MiMFa_Table AddInTable(MiMFa_Table dt, HTMLElementPatern elementPatern, MiMFa_XMLElement elem, List<MiMFa_XMLElement> xmls)
        {
            if (elem == null) return MiMFa_Table.AddInTable(dt, "", elementPatern.ColName, elementPatern.TableValuePositionType);
            string str = GetValueFromXML(elementPatern, elem);
            if (elementPatern.Usage != MiMFa_Usage.Set) dt = MiMFa_Table.AddInTable(dt, str, elementPatern.ColName, elementPatern.TableValuePositionType);
            else
                switch (elementPatern.LinkJob)
                {
                    case MiMFa_LinkJob.InternalPage:
                        AppendInFetchQueue(new FetchPatern(fetch_url, str), true);
                        break;
                    case MiMFa_LinkJob.ExternalPage:
                        AppendInFetchQueue(fetch_webpatern.FindFetchPaternFor(str, fetch_url.Source), true);
                        break;
                    //case MiMFa_LinkJob.Download:
                    default:
                        string file = string.Join("",elementPatern.DestinationPath , "\\" , MiMFa_UnicCode.CreateNewString(10) ,"_");
                        if (MiMFa_Internet.IsWellURL(str))
                            file += MiMFa_StringService.CompressedText(MiMFa_Path.NormalizeForFileAndFolderName(str.Split('/').Last()), 25, "");
                        bool b = MiMFa_Internet.DownloadOrSave(str, file);
                        dt = MiMFa_Table.AddInTable(dt, file, elementPatern.ColName, elementPatern.TableValuePositionType);
                        dt = MiMFa_Table.AddInTable(dt, str, string.Join("", "auto_" ,elementPatern.ColName, "_URL"), MiMFa_TableValuePositionType.NextColumnCell);
                        dt = MiMFa_Table.AddInTable(dt, b + "", string.Join("", "auto_" ,elementPatern.ColName , "_State"), MiMFa_TableValuePositionType.NextColumnCell);
                        break;
                }
            return dt;
        }


    }
}
