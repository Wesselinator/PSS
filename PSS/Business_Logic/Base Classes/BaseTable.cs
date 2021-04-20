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
            return DataHandler.getDataTable(sql);
        }

        public abstract void FillFromRow(DataRow row);
    }
}
