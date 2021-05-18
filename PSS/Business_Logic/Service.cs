using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PSS.Data_Access;

//CHECK
namespace PSS.Business_Logic
{
    public class Service : SingleIntID
    {
        public int ServiceID { get => ID; private set => ID = value; }
        public string ServiceName { get; set; }

        public string Type { get; set; }
        public string ServiceDescription { get; set; }

        public string DisplayMember => ServiceName;

        private static readonly string tableName = "Service";
        private static readonly string idColumn = "ServiceID";

        public Service() : base(tableName, idColumn)
        { }

        public Service(int serviceID, string serviceName, string type, string serviceDescription) : this()
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            Type = type;
            ServiceDescription = serviceDescription;
        }

        public Service(string serviceName, string type, string serviceDescription) : this()
        {
            ServiceID = base.GetNextID();
            ServiceName = serviceName;
            Type = type;
            ServiceDescription = serviceDescription;
        }


        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.ServiceID = row.Field<int>(IDColumn);
            this.ServiceName = row.Field<string>("ServiceName");
            this.Type = row.Field<string>("Type");
            this.ServiceDescription = row.Field<string>("ServiceDescription");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("ServiceName = '" + ServiceName + "', ");
            sql.Append("ServiceDescription = '" + ServiceDescription + "',");
            sql.Append("[Type] = '" + Type + "'");
            sql.AppendLine("WHERE " + IDColumn + " = " + ServiceID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (ServiceID, ServiceName, [Type], ServiceDescription)");
            sql.Append("VALUES (");

            sql.Append(ServiceID + ", ");
            sql.Append("'" + ServiceName + "', ");
            sql.Append("'" + Type + "', ");
            sql.Append("'" + ServiceDescription + "' ");

            sql.AppendLine(");");

            return sql.ToString();
        }


        #endregion

        [Obsolete("Use BaseList<Service>.GrabAll() instead", false)]
        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            DataTable dt = DataHandler.GetDataTable("SELECT * FROM Service");
            foreach (DataRow service in dt.Rows)
            {
                services.Add(new Service((int)service[0], (string)service[1], "", (string)service[2])); 
            }

            return services;
        }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   ServiceID == service.ServiceID &&
                   ServiceName == service.ServiceName &&
                   Type == service.Type &&
                   ServiceDescription == service.ServiceDescription;
        }

        public override int GetHashCode()
        {
            int hashCode = 723082494;
            hashCode = hashCode * -1521134295 + ServiceID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceDescription);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("ServiceID: {0} | ServiceName: {1}| Type: {2} | ServiceDescription: {3}", ServiceID, ServiceName,Type, ServiceDescription);
        }
    }
}
