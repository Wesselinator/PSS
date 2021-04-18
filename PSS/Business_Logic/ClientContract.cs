using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    //This isn't 100% what hapens in the DB but it simplifies the code a LOT
    public class ClientContract : BaseMultiID
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

        private readonly string ID1;
        private static readonly string idColumn2 = "ContractID";
        private readonly string ID3;

        public ClientContract(string tableName, string idColumn1, string idColumn3) : base(tableName, idColumn1, idColumn2, idColumn3)
        {
            ID1 = idColumn1;
            ID3 = idColumn3;
        }

        public ClientContract(string tableName, string idColumn1, string idColumn3, int clientContractID, int businessID, Contract contract, DateTime effectiveDate) : this(tableName, idColumn1, idColumn3)
        {
            this.ClientContractID = clientContractID;
            this.ClientID = businessID;
            this.Contract = contract;
            this.EffectiveDate = effectiveDate;
        }

        public ClientContract(string tableName, string idColumn1, string idColumn3, int businessID, Contract contract, DateTime effectiveDate) : this(tableName, idColumn1, idColumn3)
        {
            this.ClientContractID = GetNextIDOn(1);
            this.ClientID = businessID;
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
    }

    public class BusinessClientContract : ClientContract
    {
        public BusinessClientContract() : base("BusinessClientContract", "BusinessClientContractID", BusinessClient.idColumn)
        {  }
    }

    public class IndividualClientContract : ClientContract
    {
        public IndividualClientContract() : base("BusinessClientContract", "BusinessClientContractID", IndividualClient.idColumn)
        {  }
    }
}
