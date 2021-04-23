using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class MultiIntID : BaseTable
    {
        protected int[] IDs { get; set; }
        protected string[] IDColumns { get; private set; }

        protected MultiIntID(string tableName, params string[] idColumns) : base(tableName)
        {
            this.IDColumns = idColumns;
            this.IDs = new int[idColumns.Length];
        }

        public DataRow GetByIDs(params int[] ids)
        {
            if (ids.Length != IDColumns.Length)
            {
                throw new Exception();
            }

            string sql = string.Format("SELECT * FROM {0} {1}", TableName, WhereIDs(ids));

            DataTable dt = DataHandler.getDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                throw new CustomException("Error: entity not found"); //TODO: Throw Exception
            }
            return dt.Rows[0];
        }

        private string WhereIDs(int[] ids)
        {
            string[] wheres = new string[IDColumns.Length];
            for (int i = 0; i < IDColumns.Length; i++)
            {
                wheres[i] = string.Format("{0} = {1}", IDColumns[i], ids[i]);
            }
            return "WHERE " + string.Join(" AND ", wheres);
        }

        protected override sealed bool IDExists()
        {
            string sql = string.Format("SELECT * FROM {0} {1}", TableName, WhereIDs(IDs));
            DataTable dt = DataHandler.getDataTable(sql);
            return dt.Rows.Count != 0;
        }

        public virtual void FillWithIDs(params int[] ids)
        {
            if (ids.Length != IDs.Length)
            {
                throw new Exception();
            }

            FillFromRow(GetByIDs(ids));
        }

        public virtual DataTable GetAllOnPivot(int id, string column)
        {
            if (Array.Exists(IDColumns, s => s == column))
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, column, id);
                return DataHandler.getDataTable(sql);
            }

            throw new Exception();
        }

        //TODO: Move this up for OOP
        protected int GetNextIDOn(int column)
        {
            //VERBOSE: Becuase I want to see everything that happens
            string sql = string.Format("SELECT * FROM {0} ORDER BY {1} DESC;", TableName, IDColumns[column]);
            DataTable dt = DataHandler.getDataTable(sql);
            try
            {
                DataRow dr = dt.Rows[0];
                int nextID = dr.Field<int>(column) + 1;
                return nextID;
            }
            catch (IndexOutOfRangeException)
            {
                return 0; //empty 
            }
        }
    }
}
