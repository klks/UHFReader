using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    public class CDataConnection
    {
        public enum DataSourceStates
        {
            None,
            Initializing,
            Initialized
        }

        public enum ConnectionStates
        {
            None,
            Initializing,
            Initialized
        }

        private CDataColumnCollection columns;

        private ArrayList rows;

        private int nLastSelectedRowIndex;

        private UserControl parent;

        private object dataEventHandler;

        protected CurrencyManager currencyManager;

        private object dataSource;

        private string dataMember = string.Empty;

        private DataSourceStates dataSourceState;

        private ConnectionStates connectionState;

        public object DataSource => dataSource;

        public string DataMember => dataMember;

        public DataSourceStates DataSourceState => dataSourceState;

        public ConnectionStates ConnectionState => connectionState;

        public CurrencyManager CurrencyManager => currencyManager;

        public CDataColumnCollection Columns => columns;

        public ArrayList Rows => rows;

        public int LastSelectedRowIndex => nLastSelectedRowIndex;

        public object DataEventHandler
        {
            get
            {
                return dataEventHandler;
            }
            set
            {
                SetEventHandler(value);
            }
        }

        public void SetDataSource(object dataSource, string dataMember)
        {
            if (connectionState == ConnectionStates.Initializing)
            {
                return;
            }
            connectionState = ConnectionStates.Initializing;
            ISupportInitializeNotification supportInitializeNotification = this.dataSource as ISupportInitializeNotification;
            if (supportInitializeNotification != null && dataSourceState == DataSourceStates.Initializing)
            {
                supportInitializeNotification.Initialized -= DataSource_Initialized;
            }
            if (dataMember == null)
            {
                dataMember = string.Empty;
            }
            this.dataSource = dataSource;
            this.dataMember = dataMember;
            if (parent.BindingContext == null)
            {
                return;
            }
            try
            {
                if (currencyManager != null)
                {
                    currencyManager.PositionChanged -= CurrencyManager_PositionChanged;
                    currencyManager.ListChanged -= CurrencyManager_ListChanged;
                }
                if (this.dataSource != null && this.dataSource != Convert.DBNull)
                {
                    if (supportInitializeNotification != null && !supportInitializeNotification.IsInitialized)
                    {
                        if (dataSourceState == DataSourceStates.None)
                        {
                            dataSourceState = DataSourceStates.Initializing;
                            supportInitializeNotification.Initialized += DataSource_Initialized;
                        }
                        currencyManager = null;
                    }
                    else
                    {
                        currencyManager = parent.BindingContext[this.dataSource, this.dataMember] as CurrencyManager;
                        IDataConnectionEvents dataConnectionEvents = dataEventHandler as IDataConnectionEvents;
                        RenewAllData();
                        dataConnectionEvents?.DataSource_DataBoundCompleted();
                    }
                }
                else
                {
                    currencyManager = null;
                }
                if (currencyManager != null)
                {
                    currencyManager.PositionChanged += CurrencyManager_PositionChanged;
                    currencyManager.ListChanged += CurrencyManager_ListChanged;
                }
            }
            finally
            {
                connectionState = ConnectionStates.Initialized;
            }
        }

        private void DataSource_Initialized(object sender, EventArgs e)
        {
            if (dataSource is ISupportInitializeNotification supportInitializeNotification)
            {
                supportInitializeNotification.Initialized -= DataSource_Initialized;
            }
            dataSourceState = DataSourceStates.Initialized;
            SetDataSource(dataSource, dataMember);
        }

        private void CurrencyManager_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    AddItem(e.NewIndex);
                    break;
                case ListChangedType.ItemDeleted:
                    DeleteItem(e.NewIndex);
                    break;
                case ListChangedType.ItemChanged:
                    UpdateItem(e.NewIndex);
                    break;
                default:
                    ResetItems();
                    break;
            }
        }

        private void CurrencyManager_PositionChanged(object sender, EventArgs e)
        {
            OnSelecltedRowChanged();
        }

        public int GetColumnIndex(string dataPropertyName)
        {
            PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
            if (itemProperties == null)
            {
                return -1;
            }
            int result = -1;
            for (int i = 0; i < itemProperties.Count; i++)
            {
                if (string.Compare(itemProperties[i].Name, dataPropertyName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        private void UpdateItem(int itemIndex)
        {
            if (columns == null || columns.Count == 0)
            {
                RenewAllData();
            }
            if (columns == null || columns.Count == 0 || rows == null || rows.Count == 0)
            {
                return;
            }
            PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
            if (itemProperties == null)
            {
                return;
            }
            int num = -1;
            int num2 = 0;
            for (int i = 0; i < columns.Count; i++)
            {
                if (((ArrayList)rows[itemIndex])[i] != itemProperties[i].GetValue(currencyManager.List[itemIndex]))
                {
                    ((ArrayList)rows[itemIndex])[i] = itemProperties[i].GetValue(currencyManager.List[itemIndex]);
                    num = i;
                    num2++;
                }
            }
            if (dataEventHandler is IDataConnectionEvents dataConnectionEvents)
            {
                dataConnectionEvents.DataSource_ItemUpdated(itemIndex, (num2 == 1) ? num : (-1));
            }
        }

        private void DeleteItem(int itemIndex)
        {
            if (columns == null || columns.Count == 0)
            {
                RenewAllData();
            }
            if (columns != null && columns.Count != 0 && rows != null && rows.Count != 0 && currencyManager.GetItemProperties() != null && itemIndex < rows.Count)
            {
                if (dataEventHandler is IDataConnectionEvents dataConnectionEvents)
                {
                    dataConnectionEvents.DataSource_ItemDeleted(itemIndex);
                }
                rows.RemoveAt(itemIndex);
            }
        }

        private void AddItem(int itemIndex)
        {
            if (columns == null || columns.Count == 0)
            {
                RenewAllData();
            }
            if (columns == null || columns.Count == 0)
            {
                return;
            }
            PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
            if (itemProperties != null)
            {
                ArrayList arrayList = new ArrayList(columns.Count);
                for (int i = 0; i < columns.Count; i++)
                {
                    arrayList.Add(itemProperties[i].GetValue(currencyManager.List[itemIndex]));
                }
                rows.Insert(itemIndex, arrayList);
                arrayList = null;
                if (dataEventHandler is IDataConnectionEvents dataConnectionEvents)
                {
                    dataConnectionEvents.DataSource_ItemAdded(itemIndex);
                }
            }
        }

        private void OnSelecltedRowChanged()
        {
            if (nLastSelectedRowIndex != currencyManager.Position)
            {
                ResetColumns();
                ResetRows();
            }
            if (dataEventHandler is IDataConnectionEvents dataConnectionEvents)
            {
                dataConnectionEvents.DataSource_SelectedRowChanged(currencyManager.Position);
            }
            nLastSelectedRowIndex = currencyManager.Position;
        }

        private void ResetItems()
        {
            RenewAllData();
            if (dataEventHandler is IDataConnectionEvents dataConnectionEvents)
            {
                dataConnectionEvents?.DataSource_ResetItems();
            }
        }

        private void RenewAllData()
        {
            ResetColumns();
            ResetRows();
        }

        private void ResetRows()
        {
            rows.Clear();
            if (columns == null || columns.Count == 0 || currencyManager == null)
            {
                return;
            }
            PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
            if (itemProperties == null)
            {
                return;
            }
            for (int i = 0; i < currencyManager.List.Count; i++)
            {
                ArrayList arrayList = new ArrayList(columns.Count);
                for (int j = 0; j < columns.Count; j++)
                {
                    arrayList.Add(itemProperties[j].GetValue(currencyManager.List[i]));
                }
                rows.Add(arrayList);
            }
        }

        private void ResetColumns()
        {
            Columns.Clear();
            CDataColumnItem cDataColumnItem = null;
            if (currencyManager == null)
            {
                return;
            }
            PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
            if (itemProperties != null)
            {
                for (int i = 0; i < itemProperties.Count; i++)
                {
                    cDataColumnItem = new CDataColumnItem();
                    cDataColumnItem.BoundIndex = i;
                    cDataColumnItem.Converter = itemProperties[i].Converter;
                    cDataColumnItem.DisplayName = itemProperties[i].DisplayName;
                    cDataColumnItem.IsReadonly = itemProperties[i].IsReadOnly;
                    cDataColumnItem.Name = itemProperties[i].Name;
                    cDataColumnItem.ValueType = itemProperties[i].PropertyType;
                    Columns.Add(cDataColumnItem);
                    cDataColumnItem = null;
                }
            }
        }

        public CDataConnection(UserControl parent, object dataEventHandler)
            : this()
        {
            this.parent = parent;
            SetEventHandler(dataEventHandler);
        }

        private void SetEventHandler(object dataEventHandler)
        {
            if (this.dataEventHandler != dataEventHandler)
            {
                if (this.dataEventHandler != null)
                {
                    this.dataEventHandler = null;
                }
                this.dataEventHandler = dataEventHandler;
                if (dataEventHandler is IDataConnectionEvents dataConnectionEvents)
                {
                    dataConnectionEvents.SetData(parent, this);
                }
            }
        }

        public CDataConnection()
        {
            dataEventHandler = null;
            parent = null;
            columns = new CDataColumnCollection();
            rows = new ArrayList();
        }

        public void Dispose()
        {
            if (currencyManager != null)
            {
                currencyManager.PositionChanged -= CurrencyManager_PositionChanged;
                currencyManager.ListChanged -= CurrencyManager_ListChanged;
            }
            currencyManager = null;
            if (rows != null)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    ((ArrayList)rows[i]).Clear();
                }
                rows.Clear();
            }
            if (columns != null && columns.Count > 0)
            {
                columns.Clear();
            }
        }
    }
}
