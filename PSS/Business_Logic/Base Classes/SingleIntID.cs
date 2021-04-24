using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class SingleIntID : BaseSingleID<int> //Quality of life
    {
        protected SingleIntID(string tableName, string idColumn) : base(tableName, idColumn)
        {  }

        protected override int GetNextID()
        {
            return DefaultNextInt();
        }

        private int DefaultNextInt()
        {
            //VERBOSE: Becuase I want to see everything that happens
            string sql = string.Format("SELECT * FROM {0} ORDER BY {1} DESC;", TableName, IDColumn);
            DataTable dt = DataHandler.GetDataTable(sql);
            try
            {
                DataRow dr = dt.Rows[0];
                int nextID = dr.Field<int>(IDColumn) + 1;
                return nextID;
            }
            catch (IndexOutOfRangeException)
            {
                return 0; //empty 
            }
        }
    }
}
