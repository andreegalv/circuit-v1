using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBComputadora.View.Utils.Http
{
    public class FilterValuesSession
    {
        public FilterValuesSession()
        {
            FilterValues = new List<FilterValue>();
        }

        public FilterValue this[string keyName]
        {
            get { return FilterValues.First(filter => filter.KeyName.Equals(keyName)); }
        }

        public List<FilterValue> FilterValues { get; }
        public void AddFilter(string keyName, object value)
        {
            if (IsExistKey(keyName))
                throw new Exception(string.Format("there is already exists a key with the same name as '{0}'", keyName));

            FilterValues.Add(new FilterValue(keyName, value));
        }
        public bool IsExistKey(string keyName) 
        {
            return FilterValues.Exists(filter => filter.KeyName.Equals(keyName));
        }
    }
    
    public class FilterValue
    {
        public FilterValue(string keyName, object value)
        {
            KeyName = keyName;
            Value = value;
        }

        public string KeyName { get; set; }
        public object Value { get; set; }
    }
}