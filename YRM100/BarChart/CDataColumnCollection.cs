using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    public class CDataColumnCollection : IList<CDataColumnItem>, ICollection<CDataColumnItem>, IEnumerable<CDataColumnItem>, IEnumerable
    {
        private List<CDataColumnItem> items;

        public CDataColumnItem this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public CDataColumnCollection()
        {
            items = new List<CDataColumnItem>();
        }

        public int IndexOf(CDataColumnItem item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, CDataColumnItem item)
        {
            items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public void Add(CDataColumnItem item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(CDataColumnItem item)
        {
            return items.Contains(item);
        }

        public void CopyTo(CDataColumnItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(CDataColumnItem item)
        {
            return items.Remove(item);
        }

        public IEnumerator<CDataColumnItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
