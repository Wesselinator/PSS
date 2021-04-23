using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class BaseSingleID<T> : BaseTable where T : struct
    {
        protected T ID { get; set; }
        protected string IDColumn { get; private set; }

        protected BaseSingleID(string tableName, string idColumn) : base(tableName)
        {
            IDColumn = idColumn;
        }

        protected abstract T GetNextID();

        protected DataRow GetRowByID(T id)
        {
            DataTable dt = GetAllWhere(id);

            if (dt.Rows.Count == 0)
            {
                throw new IDDoesNotExist(TableName, id);
            }
            return dt.Rows[0];
        }

        public override DataTable GetAll()
        {
            return GetAllWhere(ID);
        }

        private DataTable GetAllWhere(T ID)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
            return DataHandler.getDataTable(sql);
        }

        protected override sealed bool IDExists()
        {
            return GetAll().Rows.Count != 0;
        }

        public void FillWithID(T ID)
        {
            FillFromRow(GetRowByID(ID));
        }
    }
}
