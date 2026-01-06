using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    public class CDataSourceManager
    {
        private object owner;

        private CDataConnection data;

        public object DataSource => data.DataSource;

        public string DataMember
        {
            get
            {
                if (data == null)
                {
                    return null;
                }
                return data.DataMember;
            }
        }

        public CDataConnection DataConnection => data;

        public object DataEventHandler
        {
            get
            {
                if (data == null)
                {
                    return null;
                }
                return data.DataEventHandler;
            }
            set
            {
                if (data == null)
                {
                    data = new CDataConnection((UserControl)owner, value);
                }
                else
                {
                    data.DataEventHandler = value;
                }
            }
        }

        internal void ConnectTo(object dataSource, string dataMember)
        {
            if (data == null)
            {
                data = new CDataConnection((UserControl)owner, null);
            }
            data.SetDataSource(dataSource, dataMember);
        }

        public CDataSourceManager(HBarChart owner)
        {
            this.owner = owner;
        }
    }
}
