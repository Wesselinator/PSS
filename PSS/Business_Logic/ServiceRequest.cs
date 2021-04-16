using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class ServiceRequest : IModifyable
    {
        public int ServiceRequestID { get; private set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Client Client { get; set; }

        public ServiceRequest(int serviceRequestID, string title, string type, string description, Client client)
        {
            this.ServiceRequestID = serviceRequestID;
            this.Title = title;
            this.Type = type;
            this.Description = description;
            this.Client = client;
        }

        public ServiceRequest(string title, string type, string description, Client client)
        : this(DataEngine.GetNextID(TableName, IDColumn), title, type, description, client)
        {  }

        public ServiceRequest()
        {  }

        #region Database

        private static readonly string TableName = "ServiceRequest";
        private static readonly string IDColumn = "ServiceRequestID";

        public ServiceRequest(DataRow row)
        {
            this.ServiceRequestID = row.Field<int>(IDColumn);
            this.Title = row.Field<string>("ServiceRequestTitle");
            this.Type = row.Field<string>("ServiceRequestType");
            this.Description = row.Field<string>("ServiceRequestDescription");
            this.Client = Client.GetByClientID(row.Field<int>("ClientEntityID"));
        }

        //P3
        public static ServiceRequest GetID(int ID)
        {
            return new ServiceRequest(DataEngine.GetByID(TableName, IDColumn, ID));
        }

        //P4
        public void Save()
        {
            Client.Save(); //Excecute Update/Insert for Client first then do this one
            DataEngine.UpdateORInsert(this, TableName, IDColumn, ServiceRequestID);
        }

        string IUpdateable.Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);

            sql.Append("SET ");
            sql.Append("ServiceRequestTitle = '" + Title + "',");
            sql.Append("ServiceRequestType = '" + Type + "',");
            sql.Append("ServiceRequestDescription = '" + Description + "',");
            sql.AppendLine("ClientEntityID = " + Client.ClientID);

            sql.AppendLine("WHERE " + IDColumn + " = " + ServiceRequestID);

            return sql.ToString();
        }

        string IInsertable.Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(ServiceRequestID + ", ");
            sql.Append("'" + Title + "', ");
            sql.Append("'" + Type + "', ");
            sql.Append("'" + Description + "', ");
            sql.Append(Client.ClientID);
            sql.AppendLine(");");

            return sql.ToString();
        }
        #endregion

        public bool Verify(Client client)
        {
            return client.ClientID == this.Client.ClientID;
        }

        public override bool Equals(object obj)
        {
            return obj is ServiceRequest request &&
                   ServiceRequestID == request.ServiceRequestID &&
                   Title == request.Title &&
                   Type == request.Type &&
                   Description == request.Description &&
                   EqualityComparer<Client>.Default.Equals(Client, request.Client); //TODO: Update this when Equals is in Client
        }

        public override int GetHashCode()
        {
            int hashCode = -1848433835;
            hashCode = hashCode * -1521134295 + ServiceRequestID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
            return hashCode;
        }

    }
}
