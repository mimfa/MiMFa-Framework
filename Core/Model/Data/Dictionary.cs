using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_Dictionary<T, F> : Dictionary<T, F>
    {
        public string MiddleSign { get; set; } = " -> ";
        public string SplitSign { get; set; } = Environment.NewLine;
        public MiMFa_KeyValuePair<T,F>.DisplayMember Display { get; set; } = MiMFa_KeyValuePair<T, F>.DisplayMember.Value;

        public override string ToString()
        {
            switch (Display)
            {
                case MiMFa_KeyValuePair < T,F > .DisplayMember.Key:
                    return MiMFa_CollectionService.GetAllKeysItem(this, SplitSign);
                case MiMFa_KeyValuePair<T, F>.DisplayMember.Value:
                    return MiMFa_CollectionService.GetAllValuesItem(this, SplitSign);
                default:
                    return MiMFa_CollectionService.GetAllItems(this, MiddleSign, SplitSign);
            }
        }
        public virtual Dictionary<T, F> Dictionary => this;
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
            try { this[key]= value; return true; } catch { return false; }
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
        public virtual bool TryGet(T key,ref F value)
        {
            try { value = this[key]; return true; } catch { return false; }
        }
        public virtual bool TryGet(Func<KeyValuePair<T, F>,bool> func,ref F value)
        {
            try
            {
                foreach (var item in this)
                    if (func(item))
                    {
                        value = item.Value;
                        return true;
                    }
            }
            catch { return false; }
            return false;
        }
        public virtual bool TryGet(Func<KeyValuePair<T, F>,bool> func,ref KeyValuePair<T, F> kvp)
        {
            try
            {
                foreach (var item in this)
                    if (func(item))
                    {
                        kvp = item;
                        return true;
                    }
            }
            catch { return false; }
            return false;
        }

        public virtual void AddRange(MiMFa_Dictionary<T, F> dic)
        {
            foreach (var item in dic)
                Add(item.Key, item.Value);
        }
        public virtual void AddRange(params MiMFa_KeyValuePair<T, F>[] kvps)
        {
            foreach (var item in kvps)
                Add(item.Key, item.Value);
        }
        public virtual void AddRange(Dictionary<T, F> dic)
        {
            foreach (var item in dic)
                Add(item.Key, item.Value);
        }
        public virtual void AddRange(params KeyValuePair<T, F>[] kvps)
        {
            foreach (var item in kvps)
                Add(item.Key, item.Value);
        }
        public virtual void AddOrSetRange(MiMFa_Dictionary<T, F> dic)
        {
            foreach (var item in dic)
                AddOrSet(item.Key, item.Value);
        }
        public virtual void AddOrSetRange(params MiMFa_KeyValuePair<T, F>[] kvps)
        {
            foreach (var item in kvps)
                AddOrSet(item.Key, item.Value);
        }
        public virtual void AddOrSetRange(Dictionary<T, F> dic)
        {
            foreach (var item in dic)
                AddOrSet(item.Key, item.Value);
        }
        public virtual void AddOrSetRange(params KeyValuePair<T, F>[] kvps)
        {
            foreach (var item in kvps)
                AddOrSet(item.Key, item.Value);
        }
        public virtual void TryAddRange(MiMFa_Dictionary<T, F> dic)
        {
            foreach (var item in dic)
                TryAdd(item.Key, item.Value);
        }
        public virtual void TryAddRange(params MiMFa_KeyValuePair<T, F>[] kvps)
        {
            foreach (var item in kvps)
                TryAdd(item.Key, item.Value);
        }
        public virtual void TryAddRange(Dictionary<T, F> dic)
        {
            foreach (var item in dic)
                TryAdd(item.Key, item.Value);
        }
        public virtual void TryAddRange(params KeyValuePair<T, F>[] kvps)
        {
            foreach (var item in kvps)
                TryAdd(item.Key, item.Value);
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

        public new void Add(T key, F value)
        {
            base.Add(key,value);
        }

        public virtual void Add(KeyValuePair<T, F> kvp)
        {
            Add(kvp.Key,kvp.Value);
        }

        public virtual void Add(MiMFa_KeyValuePair<T, F> kvp)
        {
            Add(kvp.Key,kvp.Value);
        }

        public virtual bool ExistKey(T key)
        {
            try { F v = this[key]; return true; } catch { return false; }
        }
        public virtual bool ExistValue(F value)
        {
            return this.Values.ToList().Exists((v)=> v.Equals(value));
        }

        public virtual bool FindKey(F value,ref T key)
        {
            foreach (var item in this)
                if (item.Value.Equals(value))
                {
                    key = item.Key;
                    return true;
                }
            return false;
        }
        public virtual bool FindValue(T key,ref F value)
        {
            try { value = this[key]; return true; } catch { return false; }
        }

    }
}
