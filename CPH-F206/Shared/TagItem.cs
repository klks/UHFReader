using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.Shared
{
    public class TagItem
    {
        public int mIndex;

        public ListViewItem viewItem;

        public int mReadTimes;

        public TagItem()
        {
            mIndex = 0;
            mReadTimes = 1;
            viewItem = null;
        }

        public void Increase()
        {
            mReadTimes++;
        }
    }
}
