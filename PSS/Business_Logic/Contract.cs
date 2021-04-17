using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class Contract : IModifyable
    {
        public int ContractID { get; set; }
        public string ContractName { get; set; }
        public string ServiceLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyFee { get; set; }

        private static readonly string TableName = "Contract";
        private static readonly string IDColumn = "ContractID";

        public Contract()// : base(TableName, IDColumn)
        { }

        public Contract(int contractID, string contractName, string serviceLevel, DateTime startDate, DateTime endDate, double monthlyFee)
        {
            ContractID = contractID;
            ContractName = contractName;
            ServiceLevel = serviceLevel;
            StartDate = startDate;
            EndDate = endDate;
            MonthlyFee = monthlyFee;
        }

        #region DataBase

        public Contract(DataRow row) : this()
        {
            this.ContractID = row.Field<int>(IDColumn);
            this.ContractName = row.Field<string>("ContractName");
            this.ServiceLevel = row.Field<string>("ServiceLevel");
            this.StartDate = row.Field<DateTime>("OfferStartDate");
            this.EndDate = row.Field<DateTime>("OfferEndDate");
            this.MonthlyFee = row.Field<double>("MonthlyFee");
        }

        //P3
        public Contract(int ID)
                : this(DataEngine.GetByID(TableName, IDColumn, ID))
        { }

        //P4
        public void Save()
        {
            DataEngine.UpdateORInsert(this, TableName, IDColumn, ContractID);
        }

        string IUpdateable.Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);

            sql.Append("SET ");
            sql.Append("ContractName = '" + ContractName + "', ");
            sql.Append("ServiceLevel = '" + ServiceLevel + "', ");
            sql.Append("OfferStartDate = '" + StartDate + "', ");
            sql.AppendLine("OfferEndDate = '" + EndDate + "',");
            sql.AppendLine("MonthlyFee = '" + MonthlyFee + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + ContractID);

            return sql.ToString();
        }

        string IInsertable.Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(ContractID + ", ");
            sql.Append("'" + ContractName + "', ");
            sql.Append("'" + ServiceLevel + "', ");
            sql.Append("'" + StartDate + "', ");
            sql.Append("'" + EndDate + "', ");
            sql.Append("'" + MonthlyFee + "' ");
            sql.AppendLine(");");

            return sql.ToString();
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
                   MonthlyFee == contract.MonthlyFee;
        }

        public override int GetHashCode()
        {
            int hashCode = 1066324823;
            hashCode = hashCode * -1521134295 + ContractID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContractName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceLevel);
            hashCode = hashCode * -1521134295 + StartDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EndDate.GetHashCode();
            hashCode = hashCode * -1521134295 + MonthlyFee.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
