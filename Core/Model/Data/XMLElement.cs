using MiMFa_Framework.General;
using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public enum ElementScope
    {
        Null = -1,
        Parent = 0,
        Self = 1,
        Child = 2,
        Children = 3
    }

    [Serializable]
    public enum MiMFa_XMLElementItems
    {
        Null = -1,
        ThisContent = 0,
        ChildContent = 1,
        ChildrenContent = 2,
        ThisTag = 3,
        ChildTag = 4,
        ChildrenTag = 5,
        ThisAttribute = 6,
        ChildAttribute = 7,
        ChildrenAttribute = 8
    }

    [Serializable]
    public class MiMFa_XMLElement
    {
        public int Index { get; set; }
        public string TagName { get; set; }
        public MiMFa_XMLElement Parent { get; set; }
        public List<MiMFa_XMLElement> Children { get; set; } = new List<MiMFa_XMLElement>();
        public string ID => string.Join("-", ParentID , Index);
        public string ParentID => Parent == null? "0" : Parent.ID;

        public Dictionary<string, string> Attributes
        {
            get
            {
                if (_Attributes != null) return _Attributes;
                _Attributes = new Dictionary<string, string>();
                string startTag = StartTag;
                if (!startTag.Contains(" ")) return _Attributes;
                return _Attributes = GetAttributeFromTagBody(MiMFa_StringService.FirstFindAndSplit(startTag, " ", TagName.Length+1).Last().Trim());
            }
        }
        private Dictionary<string, string> _Attributes = null;
        public string ParentNestedTag
        {
            get
            {
                if (_ParentNestedTag != null) return _ParentNestedTag;
                RefreshNested();
                return _ParentNestedTag;
            }
        }
        private string _ParentNestedTag = null;
        public string NestedTag
        {
            get
            {
                if (_NestedTag != null) return _NestedTag;
                RefreshNested();
                return _NestedTag;
            }
        }
        private string _NestedTag = null;
        public int NestedNumber
        {
            get
            {
                if (_NestedNumber > 0) return _NestedNumber;
                RefreshNested();
                return _NestedNumber;
            }
        }
        private int _NestedNumber = 0;

        public string OuterText => MiMFa_StringService.FromHTML(Outer);
        public string InnerText => MiMFa_StringService.FromHTML(Inner);
        public string Outer => string.Join("", StartTag , Inner , EndTag);
        public string Inner => Children == null ? "" : MiMFa_CollectionService.GetAllItems(Children, "");
        public string StartTag { get; set; }
        public string EndTag { get; set; }
        public string Body => GetBody();
        public bool IsTag => !string.IsNullOrEmpty(TagName);

        [Obsolete]
        public MiMFa_XMLElement(string ID)
        {
            var sa = MiMFa_StringService.LastFindAndSplit(ID, "-");
            int num = ID.Split('-').Length;
            TagName = "";
            StartTag = "";
            EndTag = "";
            Index = MiMFa_Convert.TryToInt(sa.Last(), 0);
            if (num > 2) Parent = new MiMFa_XMLElement(sa.First());
            else Parent = null;
        }
        public MiMFa_XMLElement(int index = 0, string tagName = "", string startTag = "", string endTag = "", Dictionary<string, string> attribute = null, MiMFa_XMLElement parent = null)
        {
            TagName = tagName;
            StartTag = startTag;
            EndTag = endTag;
            Parent = parent;
            Index = index;
            _Attributes = attribute;
        }
        public MiMFa_XMLElement(MiMFa_XMLElement elem)
        {
            _Attributes = elem._Attributes;
            _NestedNumber = elem._NestedNumber;
            _NestedTag = elem._NestedTag;
            _ParentNestedTag = elem._ParentNestedTag;
            TagName = elem.TagName;
            StartTag = elem.StartTag;
            EndTag = elem.EndTag;
            Parent = elem.Parent;
            Index = elem.Index;
            Children = GetCopy(elem.Children);
        }

        public override string ToString() => Outer;

        public void Refresh()
        {
            if (Children != null)
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Index = i;
                    Children[i].Parent = this;
                    Children[i].Refresh();
                }
        }
        public void RefreshNested()
        {
            MiMFa_XMLElement elem = this;
            _NestedNumber = 1;
            _NestedTag = elem.TagName;
            _ParentNestedTag = "";
            while (elem.Parent != null)
            {
                elem = elem.Parent;
                _NestedNumber++;
                _NestedTag = string.Join("-", elem.TagName , _NestedTag);
                _ParentNestedTag = string.Join("-", elem.TagName , _ParentNestedTag);
            }
            _ParentNestedTag = _ParentNestedTag.TrimEnd('-');
        }

        public bool IsThis(MiMFa_XMLElement thisElement)
        {
            return IsThis(this  ,thisElement);
        }
        public bool IsDuplicate(MiMFa_XMLElement withThisElement)
        {
            return IsDuplicate(this, withThisElement);
        }
        public bool IsSame(MiMFa_XMLElement withThisElement)
        {
            return IsSame(this, withThisElement);
        }
        public bool IsLike(MiMFa_XMLElement withThisElement)
        {
            return IsLike(this, withThisElement);
        }
        public bool IsCongruent(MiMFa_XMLElement withThisElement)
        {
            return IsCongruent(this, withThisElement);
        }

        public MiMFa_XMLElement FindDuplicate(MiMFa_XMLElement xmlPatern)
        {
            return FindDuplicate(this, xmlPatern);
        }
        public List<MiMFa_XMLElement> FindDuplicateList(MiMFa_XMLElement xmlPatern)
        {
            return FindDuplicateList(this, xmlPatern);
        }

        public MiMFa_XMLElement FindSame(MiMFa_XMLElement xmlPatern)
        {
            return FindSame(this, xmlPatern);
        }
        public List<MiMFa_XMLElement> FindSameList(MiMFa_XMLElement xmlPatern)
        {
            return FindSameList(this, xmlPatern);
        }

        public MiMFa_XMLElement FindLike(MiMFa_XMLElement xmlPatern)
        {
            return FindLike(this, xmlPatern);
        }
        public List<MiMFa_XMLElement> FindLikeList(MiMFa_XMLElement xmlPatern)
        {
            return FindLikeList(this, xmlPatern);
        }

        public MiMFa_XMLElement FindCongruent(MiMFa_XMLElement xmlPatern)
        {
            return FindCongruent(this, xmlPatern);
        }
        public List<MiMFa_XMLElement> FindCongruentList(MiMFa_XMLElement xmlPatern)
        {
            return FindCongruentList(this, xmlPatern);
        }
        public MiMFa_XMLElement Find(MiMFa_XMLElement xmlPatern)
        {
            return Find(this, xmlPatern);
        }
        public MiMFa_XMLElement Find(string search)
        {
            return Find(this, search);
        }
        public List<MiMFa_XMLElement> FindList(MiMFa_XMLElement xmlPatern)
        {
            return FindList(this, xmlPatern);
        }
        public List<MiMFa_XMLElement> FindList(string search)
        {
            return FindList(this, search);
        }

        public string GetAttribute(string name)
        {
            return GetAttributes(this, name);
        }
        public List<string> GetChildAttributes(string name)
        {
            return GetChildAttributes(this,name);
        }
        public string GetBody()
        {
            return GetBody(this);
        }

        public List<MiMFa_XMLElement> GetAllChildren()
        {
            return GetAllChildren(this);
        }
        public MiMFa_XMLElement GetElementByID(string id)
        {
            return GetElementByID(this, id);
        }
        public List<MiMFa_XMLElement> GetElementsByParentID(string id)
        {
            return GetElementsByParentID(this, id);
        }
        public MiMFa_XMLElement GetFirstElementByTagName(string tagName)
        {
            return GetFirstElementByTagName(this, tagName);
        }
        public List<MiMFa_XMLElement> GetElementsByTagName(string tagName)
        {
            return GetElementsByTagName(this, tagName);
        }
        public MiMFa_XMLElement GetFirstChildElementByTagName(string tagName)
        {
            return GetFirstChildElementByTagName(this, tagName);
        }
        public List<MiMFa_XMLElement> GetChildElementsByTagName(string tagName)
        {
            return GetChildElementsByTagName(this, tagName);
        }
        public MiMFa_XMLElement GetFirstChildrenElementByTagName(string tagName)
        {
            return GetFirstChildrenElementByTagName(this, tagName);
        }
        public List<MiMFa_XMLElement> GetChildrenElementsByTagName(string tagName)
        {
            return GetChildrenElementsByTagName(this, tagName);
        }

        public List<MiMFa_XMLElement> GetFrom(MiMFa_XMLElement fromThisElement)
        {
            return GetFrom(new List<MiMFa_XMLElement>() { this }, fromThisElement);
        }
        public List<MiMFa_XMLElement> GetTo(MiMFa_XMLElement toThisElement)
        {
            return GetTo(new List<MiMFa_XMLElement>() { this}, toThisElement);
        }

        public static List<MiMFa_XMLElement> GetCopy(IEnumerable<MiMFa_XMLElement> list)
        {
            List<MiMFa_XMLElement> result = new List<MiMFa_XMLElement>();
            if (list == null) return result;
            foreach (var item in list)
                result.Add(new MiMFa_XMLElement(item));
            return result;
        }
        public static MiMFa_XMLElement GetCopy(MiMFa_XMLElement elem)
        {
            return new MiMFa_XMLElement(elem);
        }

        public static string GetOuter(IEnumerable<MiMFa_XMLElement> htmlElements)
        {
            return string.Join("", from v in htmlElements select v.Outer);
        }
        public static string GetInner(IEnumerable<MiMFa_XMLElement> htmlElements)
        {
            return string.Join("", from v in htmlElements select v.Inner);
        }
        public static string GetOuterText(IEnumerable<MiMFa_XMLElement> htmlElements)
        {
            return string.Join("", from v in htmlElements select v.OuterText);
        }
        public static string GetInnerText(IEnumerable<MiMFa_XMLElement> htmlElements)
        {
            return string.Join("", from v in htmlElements select v.InnerText);
        }

        public static bool IsThis(MiMFa_XMLElement thisElement, MiMFa_XMLElement withThisElement)
        {
            if (thisElement == null && withThisElement == null) return true;
            try
            {
                return thisElement.ID == withThisElement.ID
               && IsDuplicate(thisElement, withThisElement);
            }catch { return false; }
        }
        public static bool IsDuplicate(MiMFa_XMLElement thisElement, MiMFa_XMLElement withThisElement)
        {
            if (thisElement == null && withThisElement == null) return true;
            try
            {
                bool b = thisElement.TagName == withThisElement.TagName
            && thisElement.Children.Count == withThisElement.Children.Count
            && IsCongruent(thisElement.Parent, withThisElement.Parent);
                if (b)
                {
                    var th = thisElement.Attributes;
                    var wth = withThisElement.Attributes;
                    b = th.Count == wth.Count;
                    if (b)
                        foreach (var item in wth)
                            try
                            {
                                b = item.Value == th[item.Key];
                                if (!b) return false;
                            }
                            catch { return false; }
                }
                if (b) b = thisElement.InnerText == withThisElement.InnerText;
                return b;
            }
            catch { return false; }
        }
        public static bool IsSame(MiMFa_XMLElement thisElement, MiMFa_XMLElement withThisElement)
        {
            if (thisElement == null && withThisElement == null) return true;
            try
            {
                bool b = thisElement.TagName == withThisElement.TagName
            && IsCongruent(thisElement.Parent, withThisElement.Parent);
                if (b)
                {
                    var th = thisElement.Attributes;
                    var wth = withThisElement.Attributes;
                    b = th.Count == wth.Count;
                    if (b)
                        foreach (var item in wth)
                            try
                            {
                                b = item.Value == th[item.Key];
                                if (!b) return false;
                            }
                            catch { return false; }
                }
                return b;
            }
            catch { return false; }
        }
        public static bool IsLike(MiMFa_XMLElement thisElement, MiMFa_XMLElement withThisElement)
        {
            if (thisElement == null && withThisElement == null) return true;
            try
            {
                bool b = thisElement.TagName == withThisElement.TagName
            && IsCongruent(thisElement.Parent, withThisElement.Parent);
                if (b)
                {
                    var th = thisElement.Attributes;
                    var wth = withThisElement.Attributes;
                    if (b)
                        foreach (var item in wth)
                            try { string s = th[item.Key]; } catch { return false; }
                }
                return b;
            }
            catch { return false; }
        }
        public static bool IsCongruent(MiMFa_XMLElement thisElement, MiMFa_XMLElement withThisElement)
        {
            if (thisElement == null && withThisElement == null) return true;
            if (thisElement == null || withThisElement == null) return false;
            try
            {
                bool b = thisElement.TagName == withThisElement.TagName;
                if (b)
                {
                    var th = thisElement.Attributes;
                    var wth = withThisElement.Attributes;
                    if (b)
                        foreach (var item in wth)
                            try { string s = th[item.Key]; } catch { return false; }
                }
                return b;
            }catch { return false; }
        }

        public static bool operator >(MiMFa_XMLElement obj1, MiMFa_XMLElement obj2)
        {
            string id1 = obj1.ID;
            string id2 = obj2.ID;
            if (id1 == id2) return false;
            if (id1.StartsWith(id2)) return true;
            if (id2.StartsWith(id1)) return false;
            int[] ia1 = (from i in id1.Split('-') select MiMFa_Convert.TryToInt(i, 0)).ToArray();
            int[] ia2 = (from i in id2.Split('-') select MiMFa_Convert.TryToInt(i, 0)).ToArray();
            int len = Math.Min(ia1.Length,ia2.Length);
            for (int i = 0; i < len; i++)
                if (ia1[i] > ia2[i]) return true;
                else if (ia1[i] < ia2[i]) return false;
            return false;
        }
        public static bool operator <(MiMFa_XMLElement obj1, MiMFa_XMLElement obj2)
        {
            string id1 = obj2.ID;
            string id2 = obj1.ID;
            if (id1 == id2) return false;
            if (id1.StartsWith(id2)) return true;
            if (id2.StartsWith(id1)) return false;
            int[] ia1 = (from i in id1.Split('-') select MiMFa_Convert.TryToInt(i, 0)).ToArray();
            int[] ia2 = (from i in id2.Split('-') select MiMFa_Convert.TryToInt(i, 0)).ToArray();
            int len = Math.Min(ia1.Length, ia2.Length);
            for (int i = 0; i < len; i++)
                if (ia1[i] > ia2[i]) return true;
                else if (ia1[i] < ia2[i]) return false;
            return false;
        }
        public static bool operator >=(MiMFa_XMLElement obj1, MiMFa_XMLElement obj2)
        {
            return obj1 > obj2 || obj1.ID == obj2.ID;
        }
        public static bool operator <=(MiMFa_XMLElement obj1, MiMFa_XMLElement obj2)
        {
            return obj1 < obj2 || obj1.ID == obj2.ID;
        }

        public static MiMFa_XMLElement FindDuplicate(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = null;
            for (int i = 0; i < inThisList.Count; i++)
                if ((elem = FindDuplicate(inThisList[i], xmlPatern)) != null)
                    return elem;
            return null;
        }
        public static MiMFa_XMLElement FindDuplicate(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = IsDuplicate(inThisElement,xmlPatern) ? inThisElement : null;
            if (elem == null)
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((elem = FindDuplicate(inThisElement.Children[i],xmlPatern)) != null) return elem;
            return elem;
        }
        public static List<MiMFa_XMLElement> FindDuplicateList(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> mls = new List<MiMFa_XMLElement>();
            for (int i = 0; i < inThisList.Count; i++)
                if ((mls = FindDuplicateList(inThisList[i], xmlPatern)).Count > 0)
                    ls.AddRange(mls);
            return ls;
        }
        public static List<MiMFa_XMLElement> FindDuplicateList(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> lsr = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> lsm = new List<MiMFa_XMLElement>();
            if (IsDuplicate(inThisElement, xmlPatern)) lsr.Add(inThisElement);
            else
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((lsm = FindDuplicateList(inThisElement.Children[i], xmlPatern)).Count > 0) lsr.AddRange(lsm);
            return lsr;
        }

        public static MiMFa_XMLElement FindSame(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = null;
            for (int i = 0; i < inThisList.Count; i++)
                if ((elem = FindSame(inThisList[i], xmlPatern)) != null)
                    return elem;
            return null;
        }
        public static MiMFa_XMLElement FindSame(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = IsSame(inThisElement, xmlPatern) ? inThisElement : null;
            if (elem == null )
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((elem = FindSame(inThisElement.Children[i], xmlPatern)) != null) return elem;
            return elem;
        }
        public static List<MiMFa_XMLElement> FindSameList(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> mls = new List<MiMFa_XMLElement>();
            for (int i = 0; i < inThisList.Count; i++)
                if ((mls = FindSameList(inThisList[i], xmlPatern)).Count > 0)
                    ls.AddRange(mls);
            return ls;
        }
        public static List<MiMFa_XMLElement> FindSameList(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> lsr = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> lsm = new List<MiMFa_XMLElement>();
            if (IsSame(inThisElement, xmlPatern)) lsr.Add(inThisElement);
            else
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((lsm = FindSameList(inThisElement.Children[i], xmlPatern)).Count > 0) lsr.AddRange(lsm);
            return lsr;
        }

        public static MiMFa_XMLElement FindLike(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = null;
            for (int i = 0; i < inThisList.Count; i++)
                if ((elem = FindLike(inThisList[i], xmlPatern)) != null)
                    return elem;
            return null;
        }
        public static MiMFa_XMLElement FindLike(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = IsLike(inThisElement, xmlPatern) ? inThisElement : null;
            if (elem == null)
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((elem = FindLike(inThisElement.Children[i], xmlPatern)) != null) return elem;
            return elem;
        }
        public static List<MiMFa_XMLElement> FindLikeList(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> mls = new List<MiMFa_XMLElement>();
            for (int i = 0; i < inThisList.Count; i++)
                if ((mls = FindLikeList(inThisList[i], xmlPatern)).Count > 0)
                    ls.AddRange(mls);
            return ls;
        }
        public static List<MiMFa_XMLElement> FindLikeList(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> lsr = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> lsm = new List<MiMFa_XMLElement>();
            if (IsLike(inThisElement, xmlPatern)) lsr.Add(inThisElement);
            else
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((lsm = FindLikeList(inThisElement.Children[i], xmlPatern)).Count > 0) lsr.AddRange(lsm);
            return lsr;
        }

        public static MiMFa_XMLElement FindCongruent(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = null;
            for (int i = 0; i < inThisList.Count; i++)
                if ((elem = FindCongruent(inThisList[i], xmlPatern)) != null)
                    return elem;
            return null;
        }
        public static MiMFa_XMLElement FindCongruent(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = IsCongruent(inThisElement, xmlPatern) ? inThisElement : null;
            if (elem == null)
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((elem = FindCongruent(inThisElement.Children[i], xmlPatern)) != null) return elem;
            return elem;
        }
        public static List<MiMFa_XMLElement> FindCongruentList(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> mls = new List<MiMFa_XMLElement>();
            for (int i = 0; i < inThisList.Count; i++)
                if ((mls = FindCongruentList(inThisList[i], xmlPatern)).Count > 0)
                    ls.AddRange(mls);
            return ls;
        }
        public static List<MiMFa_XMLElement> FindCongruentList(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> lsr = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> lsm = new List<MiMFa_XMLElement>();
            if (IsCongruent(inThisElement, xmlPatern)) lsr.Add(inThisElement);
            else
                for (int i = 0; i < inThisElement.Children.Count; i++)
                    if ((lsm = FindCongruentList(inThisElement.Children[i], xmlPatern)).Count > 0) lsr.AddRange(lsm);
            return lsr;
        }

        public static MiMFa_XMLElement Find(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = null;
            for (int i = 0; i < inThisList.Count; i++)
                if ((elem = Find(inThisList[i], xmlPatern)) != null)
                    return elem;
            return null;
        }
        public static MiMFa_XMLElement Find(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            MiMFa_XMLElement elem = inThisElement.GetElementByID(xmlPatern.ID);
            if (elem == null || (elem != null && !elem.IsSame(xmlPatern)))
            {
                List<MiMFa_XMLElement> ls = inThisElement.GetElementsByParentID(xmlPatern.ParentID) ?? new List<MiMFa_XMLElement>();
                for (int i = 0; i < ls.Count; i++)
                    if (ls[i].IsSame(xmlPatern)) return ls[i];
                if ((elem = FindDuplicate(inThisElement, xmlPatern)) != null) return elem;
                if ((elem = FindSame(inThisElement, xmlPatern)) != null) return elem;
                if ((elem = FindLike(inThisElement, xmlPatern)) != null) return elem;
            }
            return elem;
        }
        public static MiMFa_XMLElement Find(MiMFa_XMLElement inThisElement, string search)
        {
            if(inThisElement.StartTag.ToLower().Contains(search.ToLower())) return inThisElement;
            return Find(inThisElement.Children,search);
        }
        public static MiMFa_XMLElement Find(List<MiMFa_XMLElement> inThisList, string search)
        {
            MiMFa_XMLElement elem = null;
            for (int i = 0; i < inThisList.Count && elem == null; i++)
                elem = Find(inThisList[i], search);
            return elem;
        }
        public static List<MiMFa_XMLElement> FindList(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            for (int i = 0; i < inThisList.Count; i++)
                if ((ls = FindList(inThisList[i], xmlPatern)).Count >0)
                    return ls;
            return new List<MiMFa_XMLElement>();
        }
        public static List<MiMFa_XMLElement> FindList(MiMFa_XMLElement inThisElement, MiMFa_XMLElement xmlPatern)
        {
            List<MiMFa_XMLElement> lsr = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> ls = inThisElement.GetElementsByParentID(xmlPatern.ParentID) ?? new List<MiMFa_XMLElement>();
            for (int i = 0; i < ls.Count; i++)
                if (ls[i].IsSame(xmlPatern)) lsr.Add(ls[i]);
            return lsr;
        }
        public static List<MiMFa_XMLElement> FindList(MiMFa_XMLElement inThisElement, string search)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            if (inThisElement.StartTag.ToLower().Contains(search.ToLower())) ls.Add(inThisElement);
            ls.AddRange(FindList(inThisElement.Children, search));
            return ls;
        }
        public static List<MiMFa_XMLElement> FindList(List<MiMFa_XMLElement> inThisList, string search)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            List<MiMFa_XMLElement> elems = new List<MiMFa_XMLElement>();
            for (int i = 0; i < inThisList.Count; i++)
                if ((elems = FindList(inThisList[i], search)).Count > 0) ls.AddRange(elems);
            return ls;
        }

        public static string GetAttributes(MiMFa_XMLElement thisElement, string name)
        {
            Dictionary<string, string> dic = thisElement.Attributes;
            try { return dic[name.Trim()]; }
            catch { return ""; }
        }
        private List<string> GetChildAttributes(MiMFa_XMLElement miMFa_XMLElement, string name)
        {
            List<string> ls = new List<string>();
            string str = "";
            foreach (var item in miMFa_XMLElement.Children)
                if (!string.IsNullOrEmpty(str = item.GetAttribute(name))) ls.Add(str);
                return ls;
        }
        public static string GetBody(MiMFa_XMLElement elem)
        {
            return GetBody(elem.Attributes);
        }
        public static string GetBody(Dictionary<string,string> attributes)
        {
            string result = "";
            foreach (var item in attributes)
            {
                if (item.Value.Contains("\""))
                    result += string.Join("",item.Key , "='" , item.Value , "' ");
                else result += string.Join("", item.Key , "=\"" , item.Value , "\" ");
            }
            return result.TrimEnd();
        }

        public static Dictionary<string, string> GetAttributeFromTagBody(string tagBody)
        {
            Dictionary<string, string> attrdic = new Dictionary<string, string>();
            if (tagBody.EndsWith("/>")) tagBody = tagBody.Substring(0, tagBody.Length - 2);
            else if (tagBody.EndsWith(">")) tagBody = tagBody.Substring(0, tagBody.Length - 1);
            string m = "";
            char sign = ' ';
            string attr = "";
            string val = "";
            int attrMode = -1;
            for (int i = 0; i < tagBody.Length; i++)
            {
                char c = tagBody[i];
                if (attrMode < 0) // is Key
                {
                    if (c == '=')
                    {
                        sign = ' ';
                        attr = m.Trim();
                        m = "";
                        attrMode = 0;
                    }
                    else if (c == ' ' && !string.IsNullOrWhiteSpace(m) && !tagBody.Substring(i).TrimStart().StartsWith("="))
                    {
                        sign = c;
                        attr = m.Trim();
                        val = "true";
                        try { attrdic.Add(attr, val); } catch { attrdic[attr] = val; }
                        m = "";
                        attrMode = -1;
                    }
                    else if (c != ' ') m += c;
                }
                else if (attrMode > 0) // is Value
                {
                    if (c == sign)
                    {
                        sign = c;
                        val = m.Trim();
                        try { attrdic.Add(attr, val); } catch { attrdic[attr] += " " + val; }
                        m = "";
                        attrMode = -1;
                    }
                    else if (i == tagBody.Length - 2)
                    {
                        sign = ' ';
                        m += c;
                        val = m.Trim();
                        try { attrdic.Add(attr, val); } catch { attrdic[attr] += " " + val; }
                        m = "";
                        attrMode = -1;
                    }
                    else m += c;
                }
                else if (c == '\'' || c == '"')// is None
                {
                    sign = c;
                    attrMode = 1;
                }
                else
                {
                    sign = ' ';
                    m = c+"";
                    attrMode = 1;
                }
            }
            return attrdic;
        }

        public static MiMFa_XMLElement GetElementsCommonParent(List<MiMFa_XMLElement> elements)
        {
            if (elements != null && elements.Count > 0)
            {
                MiMFa_XMLElement cf = elements.First();
                MiMFa_XMLElement cl = elements.Last();
                if (cf.ID.StartsWith(cl.ID)) return cl;
                if (cl.ID.StartsWith(cf.ID)) return cf;
                while (cf.Parent != null && cl.Parent != null)
                {
                    cf = cf.Parent;
                    if (cl.ID.StartsWith(cf.ID)) return cf;
                    cl = cl.Parent;
                    if (cf.ID.StartsWith(cl.ID)) return cl;
                }
            }
            return null;
        }

        public static List<MiMFa_XMLElement> GetAllChildren(MiMFa_XMLElement element)
        {
            List<MiMFa_XMLElement> le = new List<MiMFa_XMLElement>();
            le.AddRange(element.Children);
            for (int i = 0; i < element.Children.Count; i++)
                le.AddRange(GetAllChildren(element.Children[i]));
            return le;
        }
        public static MiMFa_XMLElement GetElementByID(MiMFa_XMLElement element, string id)
        {
            return GetElementByID(new List<MiMFa_XMLElement>() { element }, id);
        }
        public static List<MiMFa_XMLElement> GetElementsByParentID(MiMFa_XMLElement element, string id)
        {
            return GetElementsByParentID(new List<MiMFa_XMLElement>() { element }, id);
        }
        public static MiMFa_XMLElement GetFirstElementByTagName(MiMFa_XMLElement element, string tagName)
        {
            return GetFirstElementByTagName(new List<MiMFa_XMLElement>() { element }, tagName);
        }
        public static List<MiMFa_XMLElement> GetElementsByTagName(MiMFa_XMLElement element, string tagName)
        {
            return GetElementsByTagName(new List<MiMFa_XMLElement>() { element }, tagName);
        }
        public static MiMFa_XMLElement GetFirstChildElementByTagName(MiMFa_XMLElement element, string tagName)
        {
            tagName = tagName.Trim().ToUpper();
            for (int i = 0; i < element.Children.Count; i++)
                if (element.Children[i].TagName == tagName) return element.Children[i];
            return null;
        }
        public static List<MiMFa_XMLElement> GetChildElementsByTagName(MiMFa_XMLElement element, string tagName)
        {
            tagName = tagName.Trim().ToUpper();
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            for (int i = 0; i < element.Children.Count; i++)
                if (element.Children[i].TagName == tagName) ls.Add(element.Children[i]);
            return ls;
        }
        public static MiMFa_XMLElement GetFirstChildrenElementByTagName(MiMFa_XMLElement element, string tagName)
        {
            return GetFirstElementByTagName(element.Children, tagName);
        }
        public static List<MiMFa_XMLElement> GetChildrenElementsByTagName(MiMFa_XMLElement element, string tagName)
        {
            return GetElementsByTagName(element.Children, tagName);
        }

        public static MiMFa_XMLElement GetElementByID(List<MiMFa_XMLElement> elements, string id)
        {
            MiMFa_XMLElement he = null;
            for (int i = 0; i < elements.Count; i++)
                if (id.StartsWith(elements[i].ID))
                    if (id == elements[i].ID) return elements[i];
                    else if ((he = GetElementByID(elements[i].Children, id)) != null)
                        return he;
            return null;
        }
        public static List<MiMFa_XMLElement> GetElementsByParentID(List<MiMFa_XMLElement> elements, string id)
        {
            MiMFa_XMLElement el = GetElementByID(elements, id);
            return el == null ? null : el.Children;
        }
        public static MiMFa_XMLElement GetFirstElementByTagName(List<MiMFa_XMLElement> elements, string tagName)
        {
            tagName = tagName.ToUpper();
            MiMFa_XMLElement he = null;
            for (int i = 0; i < elements.Count; i++)
                if (elements[i].TagName == tagName) return elements[i];
                else if ((he = GetFirstElementByTagName(elements[i].Children, tagName)) != null)
                    return he;
            return null;
        }
        public static List<MiMFa_XMLElement> GetElementsByTagName(List<MiMFa_XMLElement> elements, string tagName)
        {
            List<MiMFa_XMLElement> ls = new List<MiMFa_XMLElement>();
            tagName = tagName.ToUpper();
            List<MiMFa_XMLElement> hes;
            for (int i = 0; i < elements.Count; i++)
                if (elements[i].TagName == tagName) ls.Add(elements[i]);
                else if ((hes = GetElementsByTagName(elements[i].Children, tagName)).Count > 0)
                    ls.AddRange(hes.ToArray());
            return ls;
        }

        public static bool RemoveElementByID( List<MiMFa_XMLElement> elements, string id)
        {
            for (int i = 0; i < elements.Count; i++)
                if (id.StartsWith(elements[i].ID))
                    if (id == elements[i].ID) { elements.RemoveAt(i); return true; }
                    else if (RemoveElementByID(elements[i].Children, id)) return true;
            return false;
        }
        public static bool RemoveFirstElementByTagName( List<MiMFa_XMLElement> elements, string tagName)
        {
            tagName = tagName.ToUpper();
            MiMFa_XMLElement he = null;
            for (int i = 0; i < elements.Count; i++)
                if (elements[i].TagName == tagName) { elements.RemoveAt(i); return true; }
                else if (RemoveFirstElementByTagName( elements[i].Children, tagName)) return true;
            return false;
        }

        public static List<MiMFa_XMLElement> GetFrom(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement fromThisElement)
        {
            int ind = -1;
            for (int i = 0; i < inThisList.Count; i++)
                if (inThisList[i] <= fromThisElement) ind = i;
                else break;
            if (ind < 0) return inThisList;
            MiMFa_XMLElement m = inThisList.Last();
            if (!fromThisElement.ID.StartsWith(m.ID) && m < fromThisElement) return new List<MiMFa_XMLElement>();
            inThisList[ind].Children = GetFrom(inThisList[ind].Children, fromThisElement);
            return MiMFa_CollectionService.GetPart(inThisList, ind);
        }
        public static List<MiMFa_XMLElement> GetTo(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement toThisElement)
        {
            int ind = -1;
            for (int i = 0; i < inThisList.Count; i++)
                if (inThisList[i] <= toThisElement) ind = i;
                else break;
            if (ind < 0) return new List<MiMFa_XMLElement>();
            if (inThisList.Last() < toThisElement) return inThisList;
            inThisList[ind].Children = GetTo(inThisList[ind].Children, toThisElement);
            return MiMFa_CollectionService.GetPart(inThisList, 0,ind);
        }
        public static List<MiMFa_XMLElement> GetFrom(List<MiMFa_XMLElement> inThisList, string fromThisElementID)
        {
            return GetFrom(inThisList, new MiMFa_XMLElement(fromThisElementID));
        }
        public static List<MiMFa_XMLElement> GetTo(List<MiMFa_XMLElement> inThisList, string toThisElementID)
        {
            return GetTo(inThisList,new MiMFa_XMLElement(toThisElementID));
        }

        public static List<MiMFa_XMLElement> GetLastSplitIn(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement fromThisElement)
        {
                fromThisElement.Index++;
                string id = fromThisElement.ID;
                fromThisElement.Index--;
                return GetFrom(inThisList, id);
        }
        public static List<MiMFa_XMLElement> GetFirstSplitIn(List<MiMFa_XMLElement> inThisList, MiMFa_XMLElement toThisElement)
        {
            toThisElement.Index++;
            string id = toThisElement.ID;
            toThisElement.Index--;
            return GetFrom(inThisList, id);
        }
    }

}
