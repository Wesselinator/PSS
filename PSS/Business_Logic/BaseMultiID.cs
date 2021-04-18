using System;
using System.Collections.Generic;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class BaseMultiID : BaseTable
    {
        protected int[] IDs { get; set; }
        protected string[] IDColumns { get; private set; }

        protected BaseMultiID(string tableName, params string[] idColumns) : base(tableName)
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
                throw new Exception(); //TODO: Throw Exception
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
    }
}
