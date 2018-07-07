using System;
using System.Collections.Generic;

namespace MiMFa_Framework.Exclusive.Collection.Instance
{
    [Serializable]
    public class MiMFa_Dynasty : MiMFa_Instance
    {
        private List<MiMFa_Dynasty> _Childs = new List<MiMFa_Dynasty>();
        public MiMFa_Dynasty GrandParent
        {
            get {
                MiMFa_Dynasty mdy = this;
                while (mdy.Parent != null)
                    mdy = mdy.Parent;
                return mdy;
            }
        }
        public MiMFa_Dynasty Parent { get; set; } = null;
        public List<MiMFa_Dynasty> Childs
        {
            get
            {
                _Childs = Service.MiMFa_CollectionService.Distinct(_Childs);
                return _Childs;
            }
            set
            {
                _Childs = value;
                for (int i = 0; i < _Childs.Count; i++)
                    _Childs[i].Parent = this;
            }
        }
        public List<object> Items { get; set; } = new List<object>();

        public string Path => PathWithSign(" ← ");
        public Stack<string> ParentStack
        {
            get
            {
                Stack<string> ss = new Stack<string>();
                MiMFa_Dynasty mdy = this;
                ss.Push(mdy.Name);
                while (mdy.Parent != null)
                {
                    mdy = mdy.Parent;
                    ss.Push(mdy.Name);
                }
                return ss;
            }
        }

        public MiMFa_Dynasty(string name, bool incrementID = true) : base(incrementID)
        {
            Name = name;
        }

        public bool IsGrandParent(MiMFa_Dynasty dynasty)
        {
            return IsGrandParent(dynasty.ID);
        }
        public bool IsGrandParent(double dynastyID)
        {
           return IsGrandParent(this,dynastyID);
        }
        public static bool IsGrandParent(MiMFa_Dynasty inThisParent, MiMFa_Dynasty thisDynasty)
        {
            return IsGrandParent(inThisParent, thisDynasty.ID);
        }
        public static bool IsGrandParent(MiMFa_Dynasty inThisParent, double thisDynastyID)
        {
            MiMFa_Dynasty dyn = inThisParent;
            while (dyn != null)
                if (dyn.ID == thisDynastyID) return true;
                else dyn = dyn.Parent;
            return false;
        }

        public string PathWithSign(string sign)
        {
            Stack<string> ss = ParentStack;
            string result = "";
            while (ss.Count > 0)
                result += ss.Pop() + sign;
            result = result.Substring(0, result.Length - sign.Length);
            return result;
        }
        public void Overhead(MiMFa_Dynasty grandParent)
        {
            MiMFa_Dynasty dyn = this;
            while (dyn.Parent != null)
                dyn = dyn.Parent;
            dyn.Parent = grandParent;
        }
        public void Append(MiMFa_Dynasty grandChildren)
        {
            this.Childs.Add(grandChildren);
        }
    }
}
