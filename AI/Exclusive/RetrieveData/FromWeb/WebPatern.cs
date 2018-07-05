using MiMFa_Framework.General;
using MiMFa_Framework.Model;
using MiMFa_Framework.Network;
using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Exclusive.RetrieveData.FromWeb
{
    [Serializable]
    public enum ItemType
    {
        Null = -1,
        SelfMethod = 0,
        Absolute = 1,
        Root = 2,
        Relative = 3,
        Item = 4
    }
    [Serializable]
    public class WebPatern
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public Image Image { get; set; } = null;

        public string ItemsNormalizationCode { get; set; }  = ";";
        public List<FetchPatern> Paterns { get; set; } = new List<FetchPatern>();
        public FetchPatern DefaultPatern { get; set; } = new FetchPatern();
        public ItemType DefaultMethod { get; set; } = ItemType.Item;

        public List<FetchPatern> FetchList { get; set; } = new List<FetchPatern>();

        public FetchPatern[] CreateFetchPaternsFor(string source,object extra, params string[] values)
        {
            FetchPatern[] fpa = new FetchPatern[values.Length];
            for (int i = 0; i < values.Length; i++)
                fpa[i] = CreateFetchPaternFor(source,values[i],extra);
            return fpa;
        }
        public FetchPatern CreateFetchPaternFor(string value,string source, object extra = null)
        {
            return FindFetchPaternFor(DefaultPatern.Create(value,source, extra));
        }
        public FetchPatern CreateFetchPaternFor(string source,object extra, params string[] values)
        {
            return FindFetchPaternFor(DefaultPatern.Create(source,extra,values));
        }
        public FetchPatern FindFetchPaternFor(string url,string source)
        {
            return FindFetchPaternFor(new FetchPatern("", url,null,FetchType.Simple, source));
        }
        public FetchPatern FindFetchPaternFor(FetchPatern up)
        {
            FetchPatern fp = DefaultPatern;
            if (Paterns.Count > 0)
            {
                int index = Paterns.FindIndex((ur) => ur.IsSame(up));
                if (index < 0) index = Paterns.FindIndex((ur) => ur.IsLike(up));
                if (index < 0)
                {
                    string bss = MiMFa_StringService.LastFindAndSplit(up.BaseURL.TrimEnd(' ','/'), "/").First();
                    index = Paterns.FindIndex((ur) => MiMFa_StringService.LastFindAndSplit(ur.BaseURL.TrimEnd(' ', '/'), "/").First() == bss);
                    if (index < 0) index = Paterns.FindIndex((ur) => MiMFa_StringService.LastFindAndSplit(ur.BaseURL.TrimEnd(' ', '/'), "/").First().StartsWith(bss));
                }
                if (index > -1) fp = Paterns[index];
            }
            return new FetchPatern(fp,up.URL,up.Source,up.Extra);
        }
        public FetchPatern FindFetchPaternChildFor(FetchPatern up)
        {
            FetchPatern fp = DefaultPatern;
            if (Paterns.Count > 0)
            {
                int index = -1;
                if (up.Parent != null)
                {
                    FetchPatern parent = (FetchPatern)up.Parent;
                    try { index = Paterns.FindIndex((ur) => ur.Name == up.Name && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Name == up.Name && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Name == up.Name && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                }
                else
                {
                    try { index = Paterns.FindIndex((ur) => ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Parent == null && ur.Name == up.Name); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Name == up.Name); } catch { }
                }
                if (index > -1) fp = Paterns[index];
            }
            return new FetchPatern(fp,up.URL,up.Source,up.Extra);
        }
        public FetchPatern FindFetchPatern(string url,string source)
        {
            return FindFetchPatern(new FetchPatern("", url,null,FetchType.Simple, source));
        }
        public FetchPatern FindFetchPatern(FetchPatern up)
        {
            FetchPatern fp = DefaultPatern;
            if (Paterns.Count > 0)
            {
                int index = -1;
                if (up.Parent != null)
                {
                    FetchPatern parent = (FetchPatern)up.Parent;
                    try { index = Paterns.FindIndex((ur) => ur.Name == up.Name && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Name == up.Name && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Name == up.Name && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up) && ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(parent)); } catch { }
                }
                else
                {
                    try { index = Paterns.FindIndex((ur) => ur.Parent != null && ((FetchPatern)ur.Parent).IsDuplicate(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Parent != null && ((FetchPatern)ur.Parent).IsSame(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Parent != null && ((FetchPatern)ur.Parent).IsLike(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Parent == null && ur.Name == up.Name); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsDuplicate(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsSame(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.IsLike(up)); } catch { }
                    if (index < 0) try { index = Paterns.FindIndex((ur) => ur.Name == up.Name); } catch { }
                }
                if (index > -1) fp = Paterns[index];
                else return FindFetchPaternFor(up);
            }
            return new FetchPatern(fp,up.URL,up.Source,up.Extra);
        }
    }
}
