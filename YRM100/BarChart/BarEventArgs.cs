using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace YRM100.BarChart
{
    public class BarEventArgs : EventArgs
    {
        private int nIndex;

        private HBarItem bar;

        public int BarIndex
        {
            get
            {
                return nIndex;
            }
            set
            {
                nIndex = value;
            }
        }

        public HBarItem Bar => bar;

        public BarEventArgs()
        {
            bar = null;
            nIndex = -1;
        }

        public BarEventArgs(HBarItem bar, int nBarIndex)
        {
            this.bar = bar;
            BarIndex = nBarIndex;
        }
    }
}
