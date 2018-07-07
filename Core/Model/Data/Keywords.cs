using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_KeyWords<T, F>: List<KeyValuePair<T,F>>
    {
        public F this[T key]
        {
            get { return this.FindLast((kw) => kw.Key.Equals(key)).Value; }
            set { this[this.FindLastIndex((kw) => kw.Key.Equals(key))] = new KeyValuePair<T, F>(key , value); }
        }
        public T[] Keys => KeyList.ToArray();
        public F[] Values => ValueList.ToArray();
        public List<T> KeyList
        {
            get
            {
                List<T> arr = new List<T>();
                foreach (var item in this)
                    arr.Add(item.Key);
                return arr;
            }
        }
        public List<F> ValueList
        {
            get
            {
                List<F> arr = new List<F>();
                foreach (var item in this)
                    arr.Add(item.Value);
                return arr;
            }
        }

        public string MiddleSign { get; set; } = " -> ";
        public string SplitSignSign { get; set; } = Environment.NewLine;
        public MiMFa_KeyValuePair<T, F>.DisplayMember Display { get; set; } = MiMFa_KeyValuePair<T, F>.DisplayMember.Value;

        public override string ToString()
        {
            switch (Display)
            {
                case MiMFa_KeyValuePair<T, F>.DisplayMember.Key:
                    return MiMFa_CollectionService.GetAllKeysItem(this, SplitSignSign);
                case MiMFa_KeyValuePair<T, F>.DisplayMember.Value:
                    return MiMFa_CollectionService.GetAllValuesItem(this, SplitSignSign);
                default:
                    return MiMFa_CollectionService.GetAllItems(this, MiddleSign, SplitSignSign);
            }
        }

        public virtual void AddOrSet(T key, F value)
        {
            if (!TryAdd(key, value)) TrySet(key, value);
        }
        public virtual bool TryAdd(T key, F value)
        {
            try { Add(key, value); return true; } catch { return false; }
        }
        public virtual bool TrySet(T key, F value)
        {
            try { this[key] = value; return true; } catch { return false; }
        }

        public virtual void AddOrSet(KeyValuePair<T, F> kvp)
        {
            if (!TryAdd(kvp)) TrySet(kvp);
        }
        public virtual bool TryAdd(KeyValuePair<T, F> kvp)
        {
            try { Add(kvp); return true; } catch { return false; }
        }
        public virtual bool TrySet(KeyValuePair<T, F> kvp)
        {
            try { this[kvp.Key] = kvp.Value; return true; } catch { return false; }
        }

        public virtual void AddOrSet(MiMFa_KeyValuePair<T, F> kvp)
        {
            if (!TryAdd(kvp)) TrySet(kvp);
        }
        public virtual bool TryAdd(MiMFa_KeyValuePair<T, F> kvp)
        {
            try { Add(kvp); return true; } catch { return false; }
        }
        public virtual bool TrySet(MiMFa_KeyValuePair<T, F> kvp)
        {
            try { this[kvp.Key] = kvp.Value; return true; } catch { return false; }
        }

        public void Add(T key, F value)
        {
            base.Add(new KeyValuePair<T, F>(key, value));
        }
        public void Remove(T key, F value)
        {
            base.Remove(new KeyValuePair<T, F>(key, value));
        }
        public void Remove(T key)
        {
            Remove(key, this[key]);
        }
        public virtual void Add(MiMFa_KeyValuePair<T, F> kvp)
        {
            Add(kvp.Key, kvp.Value);
        }

        public bool Exist( T key)
        {
            return Find((a)=> a.Key.Equals(key)) != null;
        }
        public bool Exist( F value)
        {
            return Find((a)=> a.Value.Equals(value)) != null;
        }
        public KeyValuePair<T, F>? Find(Func<KeyValuePair<T, F>, bool> func)
        {
            foreach (var item in this)
                if (func(item)) return item;
            return null;
        }

    }
}
