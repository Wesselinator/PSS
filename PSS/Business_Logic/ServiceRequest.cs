using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PSS.Data_Access;

//CHECK
namespace PSS.Business_Logic
{
    public class ServiceRequest : SingleIntID
    {
        public int ServiceRequestID { get => ID; private set => ID = value; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        private static readonly string tableName = "ServiceRequest";
        private static readonly string idColumn = "ServiceRequestID";

        public ServiceRequest() : base(tableName, idColumn)
        { }

        public ServiceRequest(int serviceRequestID, string title, string type, string description, Client client) : this()
        {
            this.ServiceRequestID = serviceRequestID;
            this.Title = title;
            this.Type = type;
            this.Description = description;
        }

        public ServiceRequest(string title, string type, string description, Client client) : this()
        {
            this.ServiceRequestID = base.GetNextID();
            this.Title = title;
            this.Type = type;
            this.Description = description;
        }

        #region Database

        public override void FillFromRow(DataRow row)
        {
            this.ServiceRequestID = row.Field<int>(IDColumn);
            this.Title = row.Field<string>("ServiceRequestTitle");
            this.Type = row.Field<string>("ServiceRequestType");
            this.Description = row.Field<string>("ServiceRequestDescription");
        }

        public override void Save()
        {
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("ServiceRequestTitle = '" + Title + "',");
            sql.Append("ServiceRequestType = '" + Type + "',");
            sql.AppendLine("ServiceRequestDescription = '" + Description + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + ServiceRequestID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(ServiceRequestID + ", ");
            sql.Append("'" + Title + "', ");
            sql.Append("'" + Type + "', ");
            sql.Append("'" + Description + "', ");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is ServiceRequest request &&
                   ServiceRequestID == request.ServiceRequestID &&
                   Title == request.Title &&
                   Type == request.Type &&
                   Description == request.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = -1848433835;
            hashCode = hashCode * -1521134295 + ServiceRequestID.GetHashCode();
            hashCode = hashCode * -1521134295 + Title.GetHashCode();
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + Description.GetHashCode();
            return hashCode;
        }

    }
}
