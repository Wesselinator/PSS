using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic.DataBaseThings
{
    public class SQLParameterList : List<SQLParameter>
    {
        public SQLParameterList()
        {

        }

        public SQLParameterList(int capacity) : base(capacity)
        {

        }

        public SQLParameterList(IEnumerable<SQLParameter> collection) : base(collection)
        {

        }



        public void Add(string ColumnName, string Value)
        {
            string val = string.Format("'{0}'", Value);
            Add(new SQLParameter(ColumnName, val));
        }

        public void Add(string ColumnName, int Value)
        {
            string val = string.Format("{0}", Value);
            Add(new SQLParameter(ColumnName, val));
        }

        public void Add(string ColumnName, double Value)
        {
            string val = string.Format("{0:0.00}", Value);
            Add(new SQLParameter(ColumnName, val));
        }

        public void Add(string ColumnName, DateTime Value)
        {
            string val = string.Format("'{0}'", Value.ToString("yyyy-MM-dd HH:mm:ss"));
            Add(new SQLParameter(ColumnName, val));
        }


        public string GetColumnString() //don't know if this is required but for incase
        {
            StringBuilder ret = new StringBuilder();

            foreach (SQLParameter item in this)
            {
                ret.Append(item.ColumnName);
                ret.Append(", ");
            }
            
            ret.Remove(ret.Length - 2, 2); //0 based

            return ret.ToString();
        }

        public string GetValueString()
        {
            StringBuilder ret = new StringBuilder();

            foreach (SQLParameter item in this)
            {
                ret.Append(item.SET);
                ret.Append(", ");
            }

            ret.Remove(ret.Length - 2, 2); //0 based

            return ret.ToString();
        }
    }
}
