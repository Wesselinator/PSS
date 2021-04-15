using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Business_Logic.DataBaseThings;
        
namespace PSS.Business_Logic
{
    public class Contract : IDataInDataBase
    {
        public int ContractID { get; set; }
        public string ContractName { get; set; }
        public string ServiceLevel { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyFee { get; set; }

        public Contract(int contractID, string contractName, string serviceLevel, DateTime startDate, DateTime endDate, double monthlyFee)
        {
            ContractID = contractID;
            ContractName = contractName;
            ServiceLevel = serviceLevel;
            StartDate = startDate;
            EndDate = endDate;
            MonthlyFee = monthlyFee;
        }
        public Contract()
        {

        }

        private static string DateFormat = "yyyy MMM-dd";
        public override string ToString()
        {
            return string.Format("ID: {0} | Name: {1} | Level: {2} | From {3} to {4} | R{5:0.00} per Month", ContractID, ContractName, ServiceLevel, StartDate.ToString(DateFormat), EndDate.ToString(DateFormat), MonthlyFee);
        }

        public string ToFormatedString()
        {
            return string.Format("{0} (Level: {1})\n\rAplicable From {2} to {3}\n\rR{5:0.00} per Month", ContractName, ServiceLevel, StartDate.ToString(DateFormat), EndDate.ToString(DateFormat), MonthlyFee);
        }

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

        //Database things

        private static string tableName = "Contract"; //double check
        private static string idColumn = "ContractID"; //double check
        public static TableInDataBase<Contract> DBTable = new TableInDataBase<Contract>(tableName, idColumn);

        void IDataInDataBase.FillWith(DataRow DataRow)
        {
            ContractID = DataRow.Field<int>("ContractID");
            ContractName = DataRow.Field<string>("Contract Name");
            ServiceLevel = DataRow.Field<string>("Service Level");
            StartDate = DataRow.Field<DateTime>("Start Date");
            EndDate = DataRow.Field<DateTime>("End Date");
            MonthlyFee = DataRow.Field<double>("Monthly Fee");
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, ContractID);
            ret.Add("Contract Name", ContractName);
            ret.Add("Service Level", ServiceLevel);
            ret.Add("Start Date", StartDate);
            ret.Add("End Date", EndDate);
            ret.Add("Monthly Fee", MonthlyFee);

            return ret;
        }
    }
}
