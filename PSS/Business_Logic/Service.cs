using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Business_Logic.DataBaseThings;
using System.Data;

namespace PSS.Business_Logic
{
    class Service : IDataInDataBase
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        public Service(int serviceID, string serviceName, string serviceDescription)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
        }

        public Service()
        {

        }


        //Database things

        private static string tableName = "Ticket"; //double check
        private static string idColumn = "TicketID"; //double check
        public static TableInDataBase<Service> DBTable = new TableInDataBase<Service>(tableName, idColumn);

        void IDataInDataBase.FillWith(DataRow DataRow)
        {
            ServiceID = DataRow.Field<int>(idColumn);
            ServiceName = DataRow.Field<string>("Service Name");
            ServiceDescription = DataRow.Field<string>("Description");
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, ServiceID);
            ret.Add("Service Name", ServiceName);
            ret.Add("Description", ServiceDescription);

            return ret;
        }


        //P4 Methods

        public void SetUpdate()
        {
            Service.DBTable.Set(this, ServiceID);
        }

        public static Service GetSelect(int ID)
        {
            return Service.DBTable.GetByID(ID);
        }
    }
}
