using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class ServiceLevelAgreement : MultiIntID
    {
        private Service s;
        public Service Service
        {
            get => s;

            set
            {
                s = value;
                IDs[0] = value.ServiceID;
            }
        }
        public int ContractID { get => IDs[1]; private set => IDs[1] = value; }
        public string Agreement { get; set; }
        public int ServiceQuantity { get; set; }

        private static readonly string tableName = "ServiceLevelAgreement";
        public static readonly string idColumn1 = "ServiceID";
        private static readonly string idColumn2 = "ContractID";

        public ServiceLevelAgreement() : base(tableName, idColumn1, idColumn2)
        { }

        public ServiceLevelAgreement(Service service, int contractID, string agreement, int serviceQuantity) : this()
        {
            this.Service = service;
            this.ContractID = contractID;          
            this.Agreement = agreement;
            this.ServiceQuantity = serviceQuantity;
        }

        #region Database

        public override void FillFromRow(DataRow row)
        {
            this.Service = DataEngine.GetDataObject<Service>(row.Field<int>("ServiceID"));
            this.ContractID = row.Field<int>(idColumn2);           
            this.Agreement = row.Field<string>("Agreement");
            this.ServiceQuantity = row.Field<int>("ServiceQuantity");
        }

        public override void Save()
        {
            Service.Save();
            base.Save();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (ServiceID, ContractID, Agreement, ServiceQuantity) ");
            sql.Append("VALUES (");

            sql.Append(Service.ServiceID + ", ");
            sql.Append(ContractID + ", ");
            sql.AppendLine("'" + Agreement + "', ");
            sql.Append(ServiceQuantity + " ");
            sql.AppendLine(");");

            return sql.ToString();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.AppendLine("Agreement = '" + Agreement + "'");
            sql.AppendLine("ServiceQuantity = " + ServiceQuantity + " ");

            sql.Append("WHERE ");
            sql.Append(idColumn1 + " = " + Service.ServiceID);
            sql.Append(" AND ");
            sql.AppendLine(idColumn2 + " = " + ContractID);

            return sql.ToString();
        }
        #endregion

        public override bool Equals(object obj)
        {
            return obj is ServiceLevelAgreement agreement &&
                   Service.Equals(agreement.Service) &&
                   ContractID == agreement.ContractID &&
                   Agreement == agreement.Agreement &&
                   ServiceQuantity == agreement.ServiceQuantity;
        }

        public override int GetHashCode()
        {
            int hashCode = 993702154;
            hashCode = hashCode * -1521134295 + s.GetHashCode();
            hashCode = hashCode * -1521134295 + ContractID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Agreement);
            hashCode = hashCode * -1521134295 + ServiceQuantity.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("ServiceID: {0} | ContractID: {1}| Agreement: {2} | ServiceQuantity: {3}", s.ServiceID, ContractID, Agreement, ServiceQuantity);
        }


    }
}
