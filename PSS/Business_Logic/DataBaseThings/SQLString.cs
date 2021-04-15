using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSS.Business_Logic.DataBaseThings
{
    public static class SQLString
    {
        public static class Select
        {
            public static string All(string Table)
            {
                return string.Format("SELECT * FROM {0}", Table);
            }

            public static string DecendingID(string Table, string IDColumn)
            {
                return string.Format("SELECT * FROM {0} GROUP BY {1} DESC", Table, IDColumn);
            }

            //do this beeter?
            public static string ID(string Table, string IDColumn, int ID)
            {
                return string.Format("SELECT * FROM {0} WHERE {1} = {2}", Table, IDColumn, ID);
            }

            public static string ID(string Table, string IDColumn, string ID)
            {
                return string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", Table, IDColumn, ID);
            }
        }

        public static class Update
        {
            public static string ID(string Table, string IDColumn, int ID, SQLParameterList pl)
            {
                StringBuilder ret = new StringBuilder();

                ret.AppendLine("UPDATE " + Table);
                ret.AppendLine("SET " + pl.GetValueString());
                ret.AppendLine("WHERE " + IDColumn + " = " + ID.ToString());

                return ret.ToString();
            }
        }
    }
}
