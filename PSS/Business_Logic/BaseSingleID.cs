using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class BaseSingleID : BaseTable
    {
        protected int ID { get; set; }
        protected string IDColumn { get; private set; }

        protected BaseSingleID(string tableName, string idColumn) : base(tableName)
        {
            IDColumn = idColumn;
        }

        protected virtual int GetNextID()
        {
            //VERBOSE: Becuase I want to see everything that happens
            string sql = string.Format("SELECT * FROM {0} ORDER BY {1} DESC;", TableName, IDColumn);
            DataTable dt = DataHandler.getDataTable(sql);
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

        protected DataRow GetRowByID(int id)
        {
            DataTable dt = GetAllWhere(id);

            if (dt.Rows.Count == 0)
            {
                throw new Exception(); //TODO: Throw Exception
            }
            return dt.Rows[0];
        }

        public override DataTable GetAll()
        {
            return GetAllWhere(ID);
        }

        private DataTable GetAllWhere(int ID)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
            return DataHandler.getDataTable(sql);
        }

        protected override sealed bool IDExists()
        {
            return GetAll().Rows.Count != 0;
        }

        public void FillWithID(int ID)
        {
            FillFromRow(GetRowByID(ID));
        }
    }
}
