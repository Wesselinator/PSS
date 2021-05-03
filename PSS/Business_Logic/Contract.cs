using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

//CHECK
namespace PSS.Business_Logic
{
    public class Contract : SingleIntID
    {
        public int ContractID { get => ID; private set => ID = value; }
        public string ContractName { get; set; }
        public string ServiceLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } //nullable in DataBase (look into [default] for C#)

        public int ContractDurationInMonths { get; set; }
        public decimal MonthlyFee { get; set; }

        public string DisplayMember => ContractName;

        public MultiIDList<ServiceLevelAgreement> ServiceLevelAgreements { get; set; }

        public string BusinessIdentifier { get => StartDate.ToString("yyyy") + "Z" + "D" + "00000"; } //TODO: Finnish Business Identifier


        private static readonly string tableName = "Contract";
        private static readonly string idColumn = "ContractID";

        public Contract() : base(tableName, idColumn)
        {
            ServiceLevelAgreements = new MultiIDList<ServiceLevelAgreement>();
        }

        public Contract(int contractID, string contractName, string serviceLevel, DateTime startDate, DateTime endDate, int contractDurationInMonths, decimal monthlyFee) : this()
        {
            ContractID = contractID;
            ContractName = contractName;
            ServiceLevel = serviceLevel;
            StartDate = startDate;
            EndDate = endDate;
            ContractDurationInMonths = contractDurationInMonths;
            MonthlyFee = monthlyFee;
            FillList(contractID);
        }

        public Contract(string contractName, string serviceLevel, DateTime startDate, DateTime endDate, int contractDurationInMonths, decimal monthlyFee) : this() 
        {
            ContractID = base.GetNextID();
            ContractName = contractName;
            ServiceLevel = serviceLevel;
            StartDate = startDate;
            EndDate = endDate;
            ContractDurationInMonths = contractDurationInMonths;
            MonthlyFee = monthlyFee;
            FillList(ContractID);
        }

        #region DataBase

        private void FillList(int id)
        {
            ServiceLevelAgreements.FillWithPivotColumn(id, idColumn);
        }

        public override void FillFromRow(DataRow row)
        {
            this.ContractID = row.Field<int>(IDColumn);
            this.ContractName = row.Field<string>("ContractName");
            this.ServiceLevel = row.Field<string>("ServiceLevel");
            this.StartDate = row.Field<DateTime>("OfferStartDate");
            this.EndDate = row.Field<DateTime?>("OfferEndDate");
            this.ContractDurationInMonths = row.Field<int>("ContractDurationInMonths");
            this.MonthlyFee = row.Field<decimal>("MonthlyFee");
            FillList(ContractID);
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("ContractName = '" + ContractName + "', ");
            sql.Append("ServiceLevel = '" + ServiceLevel + "', ");
            sql.Append("OfferStartDate = '" + StartDate.ToString("s") + "', ");
            sql.AppendLine("OfferEndDate = '" + EndDate?.ToString("s") + "', ");
            sql.AppendLine("ContractDurationInMonths = " + ContractDurationInMonths + ", ");
            sql.AppendLine("MonthlyFee = " + MonthlyFee.ToString("0.00"));

            sql.AppendLine("WHERE " + IDColumn + " = " + ContractID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(ContractID + ", ");
            sql.Append("'" + ContractName + "', ");
            sql.Append("'" + ServiceLevel + "', ");
            sql.Append("'" + StartDate.ToString("s") + "', ");
            sql.Append("'" + EndDate?.ToString("s") + "', ");
            sql.Append(ContractDurationInMonths + ", ");
            sql.Append(MonthlyFee.ToString("0.00"));

            sql.AppendLine(");");

            return sql.ToString();
        }

        public void AddService(Service service, string agreement, int serviceQuintity)
        {
            ServiceLevelAgreements.Add(new ServiceLevelAgreement(service, ContractID, agreement, serviceQuintity));
        }

        public BaseList<Service> GetServices()
        {
            return ServiceLevelAgreements.GetServices();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is Contract contract &&
                   ContractID == contract.ContractID &&
                   ContractName == contract.ContractName &&
                   ServiceLevel == contract.ServiceLevel &&
                   StartDate == contract.StartDate &&
                   EndDate == contract.EndDate &&
                   ContractDurationInMonths == contract.ContractDurationInMonths &&
                   MonthlyFee == contract.MonthlyFee;
        }

        public override int GetHashCode()
        {
            int hashCode = 1066324823;
            hashCode = hashCode * -1521134295 + ContractID.GetHashCode();
            hashCode = hashCode * -1521134295 + ContractName.GetHashCode();
            hashCode = hashCode * -1521134295 + ServiceLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + StartDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EndDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ContractDurationInMonths.GetHashCode();
            hashCode = hashCode * -1521134295 + MonthlyFee.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("ContractID: {0} | ContractName: {1} | ServiceLevel: {2} | StartDate: [{3}] | EndDate: [{4}] | ContractDurationInMonths: {5} | MonthlyFee: {6}", ContractID, ContractName, ServiceLevel, StartDate, EndDate?.ToString() ?? "Still Active", ContractDurationInMonths, MonthlyFee);
        }
    }
}
