using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PSS.Data_Access;

//CHECK
namespace PSS.Business_Logic
{
    class Service : SingleIntID
    {
        public int ServiceID { get => ID; private set => ID = value; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        private static readonly string tableName = "Service";
        private static readonly string idColumn = "ServiceID";

        public Service() : base(tableName, idColumn)
        { }

        public Service(int serviceID, string serviceName, string serviceDescription) : this()
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
        }

        public Service(string serviceName, string serviceDescription) : this()
        {
            ServiceID = base.GetNextID();
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
        }


        #region DataBase


        public override void FillFromRow(DataRow row)
        {
            this.ServiceID = row.Field<int>(IDColumn);
            this.ServiceName = row.Field<string>("ServiceName");
            this.ServiceDescription = row.Field<string>("ServiceLevel");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("ServiceName = '" + ServiceName + "', ");
            sql.Append("ServiceDescription = '" + ServiceDescription + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + ServiceID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (ServiceID, ServiceName, ServiceDescription)");
            sql.Append("VALUES (");

            sql.Append(ServiceID + ", ");
            sql.Append("'" + ServiceName + "', ");
            sql.Append("'" + ServiceDescription + "' ");

            sql.AppendLine(");");

            return sql.ToString();
        }


        #endregion


        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            DataTable dt = DataHandler.getDataTable("SELECT * FROM Service");
            foreach (DataRow service in dt.Rows)
            {
                services.Add(new Service((int)service[0], (string)service[1], (string)service[2]));
            }

            return services;
        }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   ServiceID == service.ServiceID &&
                   ServiceName == service.ServiceName &&
                   ServiceDescription == service.ServiceDescription;
        }

        public override int GetHashCode()
        {
            int hashCode = 723082494;
            hashCode = hashCode * -1521134295 + ServiceID.GetHashCode();
            hashCode = hashCode * -1521134295 + ServiceName.GetHashCode();
            hashCode = hashCode * -1521134295 + ServiceDescription.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("ServiceID: {0} | ServiceName: {1} | ServiceDescription: {2}", ServiceID, ServiceName, ServiceDescription);
        }
    }
}
