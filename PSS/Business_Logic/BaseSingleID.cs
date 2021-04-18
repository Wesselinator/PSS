using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class BaseSingleID : BaseMultiID
    {
        protected int ID { get => IDs[0]; set => IDs = new int[1] { value }; }
        protected string IDColumn { get => IDColumns[0]; }

        protected BaseSingleID(string tableName, string idColumn) : base(tableName, idColumn)
        {  }

        protected int GetNextID()
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

        public override DataRow GetByIDs(params int[] ids) //you should not use this one
        {
            return GetByID(ids[0]);
        }

        public DataRow GetByID(int id)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, id);

            DataTable dt = DataHandler.getDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                throw new Exception(); //TODO: Throw Exception
            }
            return dt.Rows[0];
        }

        protected override bool IDExists()
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
            DataTable dt = DataHandler.getDataTable(sql);
            return dt.Rows.Count != 0;
        }

        protected override void UpdateORInsert() //it just looks nicer and you can follow the logic closer
        {
            base.UpdateORInsert();
        }

    }
}
