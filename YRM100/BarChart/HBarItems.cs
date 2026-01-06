using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class HBarItems : IList<HBarItem>, ICollection<HBarItem>, IEnumerable<HBarItem>, IEnumerable
    {
        public enum DrawingModes
        {
            Glass,
            Rubber,
            Solid
        }

        private bool bShouldReCalculate;

        private List<HBarItem> items;

        private double dMaximumValue;

        private double dMinimumValue;

        private double dTotal;

        private double dABSMaximumValue;

        private double dABSMinimumValue;

        private double dABSTotalValue;

        private DrawingModes drawingMode;

        private int nBarWidth;

        public bool ShouldReCalculate
        {
            get
            {
                return bShouldReCalculate;
            }
            set
            {
                bShouldReCalculate = value;
            }
        }

        public double Maximum
        {
            get
            {
                if (ShouldReCalculate)
                {
                    ReCalculateAll();
                }
                return dMaximumValue;
            }
            set
            {
                dMaximumValue = value;
                dABSMaximumValue = Math.Abs(value);
            }
        }

        public double Minimum
        {
            get
            {
                if (ShouldReCalculate)
                {
                    ReCalculateAll();
                }
                return dMinimumValue;
            }
            set
            {
                dMinimumValue = value;
                dABSMinimumValue = Math.Abs(value);
            }
        }

        public double Total
        {
            get
            {
                if (ShouldReCalculate)
                {
                    ReCalculateAll();
                }
                return dTotal;
            }
        }

        public double ABSMaximum
        {
            get
            {
                if (ShouldReCalculate)
                {
                    ReCalculateAll();
                }
                return dABSMaximumValue;
            }
        }

        public double ABSMinimum
        {
            get
            {
                if (ShouldReCalculate)
                {
                    ReCalculateAll();
                }
                return dABSMinimumValue;
            }
        }

        public double ABSTotal
        {
            get
            {
                if (ShouldReCalculate)
                {
                    ReCalculateAll();
                }
                return dABSTotalValue;
            }
        }

        [Browsable(true)]
        [Category("Bar Chart")]
        public DrawingModes DrawingMode
        {
            get
            {
                return drawingMode;
            }
            set
            {
                drawingMode = value;
            }
        }

        [Browsable(true)]
        [Category("Bar Chart")]
        public int DefaultWidth
        {
            get
            {
                return nBarWidth;
            }
            set
            {
                nBarWidth = value;
            }
        }

        public HBarItem this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index].Parent = null;
                items[index] = value;
                items[index].Parent = this;
                ShouldReCalculate = true;
            }
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        private void ReCalculateAll()
        {
            if (items.Count <= 0)
            {
                dMaximumValue = (dMinimumValue = (dTotal = 0.0));
                dABSMaximumValue = (dABSMinimumValue = (dABSTotalValue = 0.0));
            }
            else
            {
                dTotal = (dABSTotalValue = 0.0);
                dMaximumValue = (dMinimumValue = items[0].Value);
                dABSMaximumValue = (dABSMinimumValue = Math.Abs(items[0].Value));
                foreach (HBarItem item in items)
                {
                    dTotal += item.Value;
                    dABSTotalValue += Math.Abs(item.Value);
                    if (item.Value > dMaximumValue)
                    {
                        dMaximumValue = item.Value;
                    }
                    else if (item.Value < dMinimumValue)
                    {
                        dMinimumValue = item.Value;
                    }
                    if (Math.Abs(item.Value) > dABSMaximumValue)
                    {
                        dABSMaximumValue = Math.Abs(item.Value);
                    }
                    else if (Math.Abs(item.Value) < dABSMinimumValue)
                    {
                        dABSMinimumValue = Math.Abs(item.Value);
                    }
                }
            }
            ShouldReCalculate = false;
        }

        public HBarItems()
        {
            items = new List<HBarItem>();
            dTotal = (dMaximumValue = (dMinimumValue = 0.0));
            DrawingMode = DrawingModes.Glass;
        }

        public int IndexOf(HBarItem item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, HBarItem item)
        {
            item.Parent = this;
            items.Insert(index, item);
            ShouldReCalculate = true;
        }

        public void RemoveAt(int index)
        {
            items[index].Parent = null;
            items.RemoveAt(index);
            ShouldReCalculate = true;
        }

        public void Add(HBarItem item)
        {
            items.Add(item);
            item.Parent = this;
            ShouldReCalculate = true;
        }

        public void Clear()
        {
            foreach (HBarItem item in items)
            {
                item.Parent = null;
            }
            items.Clear();
            ShouldReCalculate = true;
        }

        public bool Contains(HBarItem item)
        {
            return items.Contains(item);
        }

        public void CopyTo(HBarItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(HBarItem item)
        {
            item.Parent = null;
            bool result = items.Remove(item);
            ShouldReCalculate = true;
            return result;
        }

        public IEnumerator<HBarItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
