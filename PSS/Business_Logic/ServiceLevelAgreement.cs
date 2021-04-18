using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class ServiceLevelAgreement : BaseMultiID
    {
        private Service s;
        public Service Service
        {
            get => s;

            set
            {
                s = value;
                IDs[1] = value.ServiceID;
            }
        }
        public int ContractID { get => IDs[0]; private set => IDs[0] = value; }
        public string PerformanceExpectation { get; set; }

        private static readonly string tableName = "ServiceLevelAgreement";
        public static readonly string idColumn1 = "ServiceID";
        private static readonly string idColumn2 = "ContractID";

        public ServiceLevelAgreement() : base(tableName, idColumn1, idColumn2)
        { }

        public ServiceLevelAgreement(Service service, int contractID, string performanceExpectation) : this()
        {
            this.Service = service;
            this.ContractID = contractID;          
            this.PerformanceExpectation = performanceExpectation;
        }

        #region Database

        public override void FillFromRow(DataRow row)
        {
            this.Service = DataEngine.GetDataObject<Service>(row.Field<int>("ServiceID"));
            this.ContractID = row.Field<int>(idColumn2);           
            this.PerformanceExpectation = row.Field<string>("PerformanceExpectation");
        }

        public override void Save()
        {
            //Service.Save();
            base.Save();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(Service.ServiceID + ", ");
            sql.Append(ContractID + ", ");
            sql.AppendLine("'" + PerformanceExpectation + "'");

            sql.AppendLine(");");

            return sql.ToString();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.AppendLine("PerformanceExpectation = '" + PerformanceExpectation + "'");

            sql.Append("WHERE ");
            sql.Append(idColumn1 + " = " + Service.ServiceID);
            sql.Append(" AND ");
            sql.AppendLine(idColumn2 + " = " + ContractID);

            return sql.ToString();
        }

        #endregion
    }
}
