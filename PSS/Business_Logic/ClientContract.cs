using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    //This isn't 100% what hapens in the DB but it simplifies the code a LOT
    public abstract class ClientContract : MultiIntID
    {
        private Contract c;
        public int ClientContractID { get => IDs[0]; private set => IDs[0] = value; }
        public int ClientID { get => IDs[1]; private set => IDs[1] = value; }
        public Contract Contract
        {
            get => c;

            set
            {
                c = value;
                IDs[2] = value.ContractID;
            }
        }
        public DateTime EffectiveDate { get; private set; }

        public bool IsCurrent => DateTime.Now.Between(EffectiveDate, EffectiveDate.AddMonths(Contract.ContractDurationInMonths));

        private readonly string ID1;
        private static readonly string idColumn2 = "ContractID";
        private readonly string ID3;

        public ClientContract(string tableName, string idColumn1, string idColumn3) : base(tableName, idColumn1, idColumn2, idColumn3)
        {
            ID1 = idColumn1;
            ID3 = idColumn3;
        }

        public ClientContract(string tableName, string idColumn1, string idColumn3, int clientContractID, int clientID, Contract contract, DateTime effectiveDate) : this(tableName, idColumn1, idColumn3)
        {
            this.ClientContractID = clientContractID;
            this.ClientID = clientID;
            this.Contract = contract;
            this.EffectiveDate = effectiveDate;
        }

        public ClientContract(string tableName, string idColumn1, string idColumn3, int ClientID, Contract contract, DateTime effectiveDate) : this(tableName, idColumn1, idColumn3)
        {
            this.ClientContractID = GetNextIDOn(1);
            this.ClientID = ClientID;
            this.Contract = contract;
            this.EffectiveDate = effectiveDate;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.ClientContractID = row.Field<int>(ID1);
            this.Contract = DataEngine.GetDataObject<Contract>(row.Field<int>(idColumn2));
            this.ClientID = row.Field<int>(ID3);
            this.EffectiveDate = row.Field<DateTime>("EffectiveDate");
        }

        public override void Save()
        {
            Contract.Save();
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append(idColumn2 + " = " + Contract.ContractID + ", ");
            sql.Append(ID3 + " = " + ClientID + ", ");
            sql.AppendLine("EffectiveDate = '" + EffectiveDate.ToString("s") + "'");


            sql.Append("WHERE ");
            sql.Append(ID1 + " = " + ClientContractID);
            //sql.Append(" AND ");
            //sql.Append(idColumn2 + " = " + BusinessID);
            
            //sql.Append(" AND ");
            //sql.Append(ID3 + " = " + Contract.ContractID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(ClientContractID + ", ");
            sql.Append(ClientID + ", ");
            sql.Append(Contract.ContractID.ToString() + ", ");
            sql.AppendLine("'" + EffectiveDate.ToString("s") + "'");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is ClientContract contract &&
                   ClientContractID == contract.ClientContractID &&
                   ClientID == contract.ClientID &&
                   Contract.Equals(contract.Contract) &&
                   EffectiveDate == contract.EffectiveDate;
        }

        public override int GetHashCode()
        {
            int hashCode = 422978113;
            hashCode = hashCode * -1521134295 + ClientContractID.GetHashCode();
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + Contract.GetHashCode();
            hashCode = hashCode * -1521134295 + EffectiveDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID1);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID3);
            return hashCode;
        }
    }

    public class BusinessClientContract : ClientContract
    {
        private static readonly string tableName = "BusinessClientContract";
        private static readonly string idColumn = "BusinessClientContractID";
        public BusinessClientContract() : base(tableName, idColumn, BusinessClient.idColumn)
        {  }

        public BusinessClientContract(int ID, Contract contract, DateTime effectiveDate) : base(tableName, idColumn, BusinessClient.idColumn, ID, contract, effectiveDate)
        {  }

    }

    public class IndividualClientContract : ClientContract
    {
        private static readonly string tableName = "IndividualClientContract";
        private static readonly string idColumn = "IndividualClientContractID";
        public IndividualClientContract() : base(tableName, idColumn, IndividualClient.idColumn)
        {  }
        public IndividualClientContract(int ID, Contract contract, DateTime effectiveDate) : base(tableName, idColumn, BusinessClient.idColumn, ID, contract, effectiveDate)
        { }
    }


}
