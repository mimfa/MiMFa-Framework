using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Layout;
using static System.Windows.Forms.Control;

namespace MiMFa_Framework.Component.WinForm.Menu
{
    public class RibbonPanelCollection : IList<RibbonPanel>, ICollection<RibbonPanel>, IEnumerable
    {
        public List<RibbonPanel> Items = new List<RibbonPanel>();

        public RibbonPanel this[int index]
        {
            get
            {
                return Items[index];
            }

            set
            {
                 Items[index] = value;
            }
        }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public void Add(RibbonPanel item)
        {
            Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(RibbonPanel item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(RibbonPanel[] array, int arrayIndex)
        {
            Items.CopyTo(array,arrayIndex);
        }

        public IEnumerator<RibbonPanel> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public int IndexOf(RibbonPanel item)
        {
            return Items.IndexOf(item);
        }

        public void Insert(int index, RibbonPanel item)
        {
             Items.Insert(index,item);
        }

        public bool Remove(RibbonPanel item)
        {
            return Items.Remove(item);
        }

        public void RemoveAt(int index)
        {
             Items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}