using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class ClientFollowUp : MultiIntID
    {
        private FollowUp fu;
        public int ClientID { get => IDs[0]; private set => IDs[0] = value; }
        public FollowUp FollowUp
        {
            get => fu;

            set
            {
                fu = value;
                IDs[1] = value.FollowupReportID;
            }
        }

        public static readonly string idColumn2 = "FollowupReportID";
        private readonly string ID1;

        public ClientFollowUp(string tableName, string idColumn1) : base(tableName, idColumn1, idColumn2)
        {
            ID1 = idColumn1;
        }

        public ClientFollowUp(string tableName, string idColumn1, int clientID, FollowUp followUp) : this(tableName, idColumn1)
        {
            this.ClientID = clientID;
            this.FollowUp = followUp;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.ClientID = row.Field<int>(ID1);
            this.FollowUp = DataEngine.GetDataObject<FollowUp>(row.Field<int>(idColumn2));
        }

        public override void Save()
        {
            FollowUp.Save();
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("WHERE ");
            sql.Append(ID1 + " = " + ClientID);
            sql.Append(" AND ");
            sql.AppendLine(idColumn2 + " = " + FollowUp.FollowupReportID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(ClientID + ", ");
            sql.AppendLine(FollowUp.FollowupReportID.ToString());

            sql.AppendLine(");");

            return sql.ToString();
        }


        #endregion

    }

    public class BusinessClientFollowUp : ClientServiceRequest
    {
        public BusinessClientFollowUp() : base("BusinessClientFollowUp", BusinessClient.idColumn)
        { }
    }

    public class IndividualClientFollowUp : ClientServiceRequest
    {
        public IndividualClientFollowUp() : base("IndividualClientFollowUp", IndividualClient.idColumn)
        { }
    }
}
