using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic.DataBaseThings
{
    public struct SQLParameter
    {
        public string ColumnName { get; set; }
        public string Value { get; set; }

        public SQLParameter(string columnName, string value)
        {
            ColumnName = columnName;
            Value = value;
        }

        /// <summary>
        /// Get the SET SQL string
        /// </summary>
        public string SET { get => ColumnName + " = " + Value; }
    }
}
