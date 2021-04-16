using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Contract
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
