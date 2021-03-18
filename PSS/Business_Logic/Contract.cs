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
    }
}
