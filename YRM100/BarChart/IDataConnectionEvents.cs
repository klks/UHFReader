using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    internal interface IDataConnectionEvents
    {
        void DataSource_ItemUpdated(int nRowIndex, int nColIndex);

        void DataSource_ItemDeleted(int nItemIndex);

        void DataSource_ItemAdded(int nItemIndex);

        void DataSource_SelectedRowChanged(int nPosition);

        void DataSource_ResetItems();

        void DataSource_DataBoundCompleted();

        void SetData(object chart, object dataConnection);
    }
}
