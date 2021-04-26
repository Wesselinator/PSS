using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    /// <summary>
    /// Defines a BaseTable that has multiple INT IDs
    /// </summary>
    public abstract class MultiIntID : BaseTable
    {
        protected int[] IDs { get; set; }
        protected string[] IDColumns { get; private set; }
        private int CLength{ get => IDColumns.Length; } //Use this a bunch here

        protected MultiIntID(string tableName, params string[] idColumns) : base(tableName)
        {
            this.IDColumns = idColumns;
            this.IDs = new int[idColumns.Length];
        }

        public DataRow GetByIDs(params int[] ids)
        {
            if (ids.Length != CLength)
            {
                throw new IDsSizeDiscrepancy(CLength, ids.Length);
            }

            string sql = string.Format("SELECT * FROM {0} {1}", TableName, WhereIDs(ids));

            DataTable dt = DataHandler.GetDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                throw new IDDoesNotExist(TableName, ids);
            }
            return dt.Rows[0];
        }

        private string WhereIDs(int[] ids)
        {
            string[] wheres = new string[CLength];
            for (int i = 0; i < CLength; i++)
            {
                wheres[i] = string.Format("{0} = {1}", IDColumns[i], ids[i]);
            }
            return "WHERE " + string.Join(" AND ", wheres);
        }

        protected override sealed bool IDExists()
        {
            string sql = string.Format("SELECT * FROM {0} {1}", TableName, WhereIDs(IDs));
            DataTable dt = DataHandler.GetDataTable(sql);
            return dt.Rows.Count != 0;
        }

        public virtual void FillWithIDs(params int[] ids)
        {
            if (ids.Length != IDs.Length)
            {
                throw new IDsSizeDiscrepancy(CLength, ids.Length);
            }

            FillFromRow(GetByIDs(ids));
        }

        public virtual DataTable GetAllOnPivot(int id, string column)
        {
            if (IDColumnExists(column))
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, column, id);
                return DataHandler.GetDataTable(sql);
            }

            throw new IDColumnDoesNotExist(column);
        }

        private bool IDColumnExists(string column)
        {
            return Array.Exists(IDColumns, s => s == column);
        }

        protected int GetNextIDOn(int column)
        {
            return base.GetNextIDFor(IDColumns[column]);
        }
    }
}
