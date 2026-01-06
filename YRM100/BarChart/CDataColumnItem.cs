using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.BarChart
{
    public class CDataColumnItem
    {
        private string name;

        private string displayName;

        private int boundIndex;

        private TypeConverter converter;

        private Type valueType;

        private bool isReadonly;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = value;
            }
        }

        public bool IsReadonly
        {
            get
            {
                return isReadonly;
            }
            set
            {
                isReadonly = value;
            }
        }

        public int BoundIndex
        {
            get
            {
                return boundIndex;
            }
            set
            {
                boundIndex = value;
            }
        }

        public TypeConverter Converter
        {
            get
            {
                return converter;
            }
            set
            {
                converter = value;
            }
        }

        public Type ValueType
        {
            get
            {
                return valueType;
            }
            set
            {
                valueType = value;
            }
        }
    }
}
