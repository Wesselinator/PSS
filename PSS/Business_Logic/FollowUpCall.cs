using System;
using System.Text;
using System.Data;

namespace PSS.Business_Logic
{
    [Obsolete("Deprecated", true)]
    class FollowUpCall : SingleIntID
    {
        public int FollowUpCallID { get => ID; private set => ID = value; }

        public bool IsIssueResolved { get; set; }

        public int SatisfactionLevel { get; set; }

        public DateTime FollowUpCallDate { get; set; }

        private static readonly string tableName = "FollowUpCall";
        private static readonly string idColumn = "FollowUpCallID";

        public FollowUpCall() : base(tableName, idColumn)
        {
        }

        public FollowUpCall(int followUpCallID, bool isIssueResolved, int satisfactionLevel, DateTime followUpCallDate) : this()
        {
            this.FollowUpCallID = followUpCallID;
            this.IsIssueResolved = isIssueResolved;
            this.SatisfactionLevel = satisfactionLevel;
            this.FollowUpCallDate = followUpCallDate;
        }

        public FollowUpCall(bool isIssueResolved, int satisfactionLevel, DateTime followUpCallDate) : this()
        {
            this.FollowUpCallID = base.GetNextID();
            this.IsIssueResolved = isIssueResolved;
            this.SatisfactionLevel = satisfactionLevel;
            this.FollowUpCallDate = followUpCallDate;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.FollowUpCallID = row.Field<int>(IDColumn);
            this.IsIssueResolved = row.Field<bool>("IsIssueResolved");
            this.SatisfactionLevel = row.Field<int>("SatisfactionLevel");
            this.FollowUpCallDate = row.Field<DateTime>("FollowUpCallDate");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("IsIssueResolved = " + (IsIssueResolved ? 1 : 0) + ", "); 
            sql.Append("SatisfactionLevel = " + SatisfactionLevel + ", ");
            sql.Append("FollowUpCallDate = '" + FollowUpCallDate + "' ");
            sql.AppendLine("WHERE " + IDColumn + " = " + FollowUpCallID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(FollowUpCallID + ", ");
            sql.Append("'" + IsIssueResolved + "', ");
            sql.Append("'" + SatisfactionLevel + "', ");
            sql.Append("'" + FollowUpCallDate + "' ");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FollowUpCall call &&
                   FollowUpCallID == call.FollowUpCallID &&
                   IsIssueResolved == call.IsIssueResolved &&
                   SatisfactionLevel == call.SatisfactionLevel &&
                   FollowUpCallDate == call.FollowUpCallDate;
        }

        public override int GetHashCode()
        {
            int hashCode = 1058284694;
            hashCode = hashCode * -1521134295 + FollowUpCallID.GetHashCode();
            hashCode = hashCode * -1521134295 + IsIssueResolved.GetHashCode();
            hashCode = hashCode * -1521134295 + SatisfactionLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + FollowUpCallDate.GetHashCode();
            return hashCode;
        }
    }
}
