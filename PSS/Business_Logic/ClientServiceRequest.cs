using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class ClientServiceRequest : BaseMultiID
    {
        private ServiceRequest sr;
        public int ClientID { get => IDs[0]; private set => IDs[0] = value; }
        public ServiceRequest ServiceRequest
        {
            get => sr;

            set
            {
                sr = value;
                IDs[1] = value.ServiceRequestID;
            }
        }

        public static readonly string idColumn2 = "ServiceRequestID";
        private readonly string ID1;

        public ClientServiceRequest(string tableName, string idColumn1) : base(tableName, idColumn1, idColumn2)
        {
            ID1 = idColumn1;
        }

        public ClientServiceRequest(string tableName, string idColumn1, int clientID, ServiceRequest serviceRequest) : this(tableName, idColumn1)
        {
            this.ClientID = clientID;
            this.ServiceRequest = serviceRequest;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.ClientID = row.Field<int>(ID1);
            this.ServiceRequest = DataEngine.GetDataObject<ServiceRequest>(row.Field<int>(idColumn2));
        }

        public override void Save()
        {
            ServiceRequest.Save();
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.AppendLine(idColumn2 + " = " + ServiceRequest.ServiceRequestID);

            sql.Append("WHERE ");
            sql.Append(ID1 + " = " + ClientID);
            sql.Append(" AND ");
            sql.AppendLine(idColumn2 + " = " + ServiceRequest.ServiceRequestID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(ClientID + ", ");
            sql.AppendLine(ServiceRequest.ServiceRequestID.ToString());

            sql.AppendLine(");");

            return sql.ToString();
        }


        #endregion
    }

    public class BusinessClientServiceRequest : ClientServiceRequest
    {
        public BusinessClientServiceRequest() : base("BusinessClientServiceRequest", BusinessClient.idColumn)
        {  }
    }

    public class IndividualClientServiceRequest : ClientServiceRequest
    {
        public IndividualClientServiceRequest() : base("IndividualClientServiceRequest", IndividualClient.idColumn)
        {  }
    }
}
