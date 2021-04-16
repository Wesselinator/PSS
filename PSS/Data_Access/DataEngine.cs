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
    }
}
