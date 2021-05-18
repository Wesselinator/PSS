using System;
using PSS.Data_Access;
using System.Data;

namespace PSS.Business_Logic
{
    public abstract class BaseTable
    {
        public string TableName { get; private set; }

        protected BaseTable(string tableName)
        {
            TableName = tableName;
        }

        public virtual void Save()
        {
            UpdateORInsert();
        }

        protected void UpdateORInsert()
        {
            if (IDExists())
            {
                DataHandler.Update(Update());
            }
            else
            {
                DataHandler.Insert(Insert());
            }
        }

        protected abstract bool IDExists();
        protected abstract string Update();
        protected abstract string Insert();

        public virtual DataTable GetAll()
        {
            string sql = "SELECT * FROM " + TableName;
            return DataHandler.GetDataTable(sql);
        }

        public abstract void FillFromRow(DataRow row);

        protected int GetNextIDFor(string columnName)
        {
            //VERBOSE: Becuase I want to see everything that happens
            string sql = string.Format("SELECT * FROM {0} ORDER BY {1} DESC", TableName, columnName);
            DataTable dt = DataHandler.GetDataTable(sql);
            try
            {
                DataRow dr = dt.Rows[0];
                int nextID = dr.Field<int>(columnName) + 1;
                return nextID;
            }
            catch (IndexOutOfRangeException)
            {
                return 0; //empty 
            }
        }
    }
}
