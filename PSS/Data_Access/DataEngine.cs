using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Business_Logic;

namespace PSS.Data_Access
{
    public static class DataEngine
    {
        public static List<Client> GetAllClients()
        {
            DataHandler dh = new DataHandler();

            string ICsql = "SELECT * FROM IndividualClient";
            string BCsql = "SELECT * FROM BusinessClient";

            DataTable IC = dh.getDataTable(ICsql);
            DataTable BC = dh.getDataTable(BCsql);


            List<Client> ret = new List<Client>();


            foreach (DataRow row in IC.Rows)
            {
                ret.Add(new IndividualClient(row));
            }

            foreach (DataRow row in BC.Rows)
            {
                ret.Add(new BusinessClient(row));
            }


            return ret;
        }

        public static DataRow GetByID(string TableName, string IDColumn, int ID)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}", TableName, IDColumn, ID);
            DataHandler dh = new DataHandler();
            DataTable dt = dh.getDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                //TODO: Throw Exception
            }
            return dt.Rows[0];
        }

        public static int GetNextID(string TableName, string IDColumn)
        {
            string sql = string.Format("SELECT * FROM {0} GROUP BY {1} DESC", TableName, IDColumn);
            DataHandler dh = new DataHandler();
            return dh.getDataTable(sql).Rows[0].Field<int>(IDColumn) + 1;
        }
    }
}
