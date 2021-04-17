using System;
using System.Data;

namespace PSS.Data_Access
{
    public class TableEngine
    {
        public string TableName { get; private set; }
        public string[] IDColumns { get; private set; }
        public string IDColumn { get => IDColumns[0]; private set => IDColumns = new string[] { value }; } //IMPORTANT: setting IDcolumn recreates IDColums[]!
        private bool IsSingle { get => IDColumns.Length == 1; }

        public TableEngine(string tableName, params string[] idColumns)
        {
            this.TableName = tableName;
            this.IDColumns = idColumns;
        }

        public TableEngine(string tableName, string idColumn)// : this(tableName, new string[] { idColumn })
        {
            this.TableName = tableName;
            this.IDColumn = idColumn; //test
        }

        public int GetNextID()
        {
            if (!IsSingle)
            {
                throw new Exception(); //TODO: Nice Exception
            }

            //VERBOSE: Becuase I want to see everything that happens
            string sql = string.Format("SELECT * FROM {0} ORDER BY {1} DESC", TableName, IDColumn);
            DataTable dt = DataHandler.getDataTable(sql);
            DataRow dr = dt.Rows[0];
            int nextID = dr.Field<int>(IDColumn) + 1;
            return nextID;
        }

        #region GetByID

        public DataRow GetByID(params int[] IDs)
        {
            //exists
            string sql = string.Format("SELECT * FROM {0} ", TableName);

            if (IsSingle)
            {
                sql += WhereID(IDs[0]);
            }
            else
            {
                if (IDs.Length != IDColumns.Length) // IDs entered do not coraspond to Columns
                {
                    throw new Exception(); //TODO: Nice Exception
                }

                sql += WhereIDs(IDs);
            }


            DataTable dt = DataHandler.getDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                throw new Exception(); //TODO: Throw Exception
            }
            return dt.Rows[0];
        }

        //eventually move to SQLstring class
        public string WhereID(int id)
        {
            return string.Format("WHERE {0} = {1}", IDColumn, id);
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

        #endregion


        public void UpdateORInsert(IModifyable data, int ID)
        {

        }
    }
}
