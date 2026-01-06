using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    public class CreateChartForEachRow : IDataConnectionEvents
    {
        private CDataConnection data;

        private HBarChart chart;

        private Color[] colors;

        public CreateChartForEachRow()
        {
            data = null;
            chart = null;
            colors = new Color[12]
            {
            Color.FromArgb(255, 200, 255, 255),
            Color.FromArgb(255, 150, 200, 255),
            Color.FromArgb(255, 100, 100, 200),
            Color.FromArgb(255, 255, 60, 130),
            Color.FromArgb(255, 250, 200, 255),
            Color.FromArgb(255, 255, 255, 0),
            Color.FromArgb(255, 255, 155, 55),
            Color.FromArgb(255, 150, 200, 155),
            Color.FromArgb(255, 255, 255, 200),
            Color.FromArgb(255, 100, 150, 200),
            Color.FromArgb(255, 130, 235, 250),
            Color.FromArgb(255, 150, 240, 80)
            };
        }

        public void SetData(object chart, object dataConnection)
        {
            this.chart = chart as HBarChart;
            data = dataConnection as CDataConnection;
        }

        public void DataSource_ItemUpdated(int nRowIndex, int nColIndex)
        {
            if (nRowIndex < 0 || chart == null || nRowIndex != data.LastSelectedRowIndex)
            {
                return;
            }
            if (nColIndex < 0)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    ArrayList arrayList = (ArrayList)data.Rows[nRowIndex];
                    if (arrayList != null && arrayList[i] != null && arrayList[i] != Convert.DBNull)
                    {
                        chart.ModifyAt(i, Convert.ToDouble(arrayList[i]));
                    }
                    else
                    {
                        chart.ModifyAt(i, 0.0);
                    }
                }
            }
            else
            {
                double dNewValue = Convert.ToDouble(((ArrayList)data.Rows[nRowIndex])[nColIndex]);
                chart.ModifyAt(nColIndex, dNewValue);
            }
            chart.RedrawChart();
        }

        public void DataSource_ItemDeleted(int nItemIndex)
        {
            if (nItemIndex >= 0 && chart != null && nItemIndex == data.LastSelectedRowIndex)
            {
                chart.Items.Clear();
                chart.RedrawChart();
            }
        }

        public void DataSource_ItemAdded(int nItemIndex)
        {
            if (data.LastSelectedRowIndex == nItemIndex)
            {
                DataSource_ResetItems();
            }
        }

        public void DataSource_SelectedRowChanged(int nPosition)
        {
            if (nPosition < 0 || chart == null)
            {
                return;
            }
            chart.Items.Clear();
            Random random = new Random(1);
            for (int i = 0; i < data.Columns.Count; i++)
            {
                ArrayList arrayList = (ArrayList)data.Rows[nPosition];
                if (arrayList != null && arrayList[i] != null && arrayList[i] != Convert.DBNull)
                {
                    chart.Add(Convert.ToDouble(arrayList[i]), string.IsNullOrEmpty(data.Columns[i].DisplayName) ? data.Columns[i].Name : data.Columns[i].DisplayName, colors[random.Next(0, colors.Length - 1)]);
                }
                else
                {
                    chart.Add(null);
                }
            }
            chart.RedrawChart();
        }

        public void DataSource_ResetItems()
        {
            if (data.LastSelectedRowIndex < 0 || chart == null)
            {
                return;
            }
            chart.Items.Clear();
            Random random = new Random(1);
            for (int i = 0; i < data.Columns.Count; i++)
            {
                ArrayList arrayList = (ArrayList)data.Rows[data.LastSelectedRowIndex];
                if (arrayList != null && arrayList[i] != null && arrayList[i] != Convert.DBNull)
                {
                    chart.Add(Convert.ToDouble(arrayList[i]), string.IsNullOrEmpty(data.Columns[i].DisplayName) ? data.Columns[i].Name : data.Columns[i].DisplayName, colors[random.Next(0, colors.Length - 1)]);
                }
                else
                {
                    chart.Add(null);
                }
            }
            chart.RedrawChart();
        }

        public void DataSource_DataBoundCompleted()
        {
            if (chart != null)
            {
                DataSource_ResetItems();
            }
        }
    }
}
