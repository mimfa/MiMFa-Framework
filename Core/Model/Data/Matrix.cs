using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa_Framework.Model
{
    [Serializable]
    public class MiMFa_Matrix<T> : MiMFa_List<MiMFa_List<T>>
    {
        public T this[int i,int j]
        {
            get { return this[i][j]; }
            set { this[i][j] = value; }
        }
            
        public string SplitLineSign { get; set; } = Environment.NewLine;

        public override string ToString()
        {
            return MiMFa_CollectionService.GetAllItems(this, SplitLineSign, 0);
        }
        
        public MiMFa_Matrix()
        {

        }
        public MiMFa_Matrix(int mn, T defval)
        {
            for (int i = 0; i < mn; i++)
            { 
                AddRow();
                for (int j = 0; j < mn; j++)
                    this[i].Add(defval);
            }
        }
        public MiMFa_Matrix(int m,int n,T defval)
        {
            for (int i = 0; i < m; i++)
            {
                AddRow();
                for (int j = 0; j < n; j++)
                    this[i].Add(defval);
            }
        }
        public override MiMFa_List<T>[] AddArray(params MiMFa_List<T>[] array)
        {
            AddRange(array);
            return array;
        }
        public virtual void AddRow(params T[] array)
        {
            var l = new MiMFa_List<T>();
            l.AddRange(array);
            this.Add(l);
        }
        public virtual void AddRow() => this.Add(new MiMFa_List<T>());
        public virtual void AddColumn(params T[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (this.Count > i) this[i].Add(array[i]);
                else AddRow(array[i]);
        }
        public virtual void AddCell(params T[] array)=>this.Last().AddRange(array);
    }
}
