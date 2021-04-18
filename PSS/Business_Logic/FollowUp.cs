using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace PSS.Business_Logic
{
    public class FollowUp : BaseSingleID
    {
        public int FollowupReportID { get => ID; private set => ID = value; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime FollowUpDate { get; set; }
        public bool IsIssueResolved { get; set; }
        public int SatisfactionLevel { get; set; }



        private static readonly string tableName = "FollowUp";
        private static readonly string idColumn = "FollowupReportID";

        public FollowUp() : base(tableName, idColumn) 
        { }

        public FollowUp(int followupReportID, string title, string type, string description, DateTime followUpDate, bool isIssueResolved, int satisfactionLevel) : this()
        {
            this.FollowupReportID = followupReportID;
            this.Title = title;
            this.Type = type;
            this.Description = description;
            this.FollowUpDate = followUpDate;
            this.IsIssueResolved = isIssueResolved;
            this.SatisfactionLevel = satisfactionLevel;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.FollowupReportID = row.Field<int>(idColumn);
            this.Title = row.Field<string>("Title");
            this.Type = row.Field<string>("Type");
            this.Description = row.Field<string>("Description");
            this.FollowUpDate = row.Field<DateTime>("FollowUpCallDate");
            this.IsIssueResolved = row.Field<bool>("IsIssueResolved");
            this.SatisfactionLevel = row.Field<int>("SatisfactionLevel");           
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE " + tableName);
            sql.Append("SET ");

            sql.Append("Title = '" + Title + "', ");
            sql.Append("Type = '" + Type + "', ");
            sql.Append("Description = '" + Description + "', ");
            sql.Append("FollowUpCallDate = '" + FollowUpDate + "', ");
            sql.Append("IsIssueResolved = " + (IsIssueResolved ? 1 : 0) + ", ");
            sql.Append("SatisfactionLevel = " + SatisfactionLevel + " ");


            sql.Append("WHERE " + idColumn + " = " + FollowupReportID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + tableName);
            sql.Append("VALUES (");

            sql.Append(FollowupReportID + ", ");
            sql.Append("'" + Title + "'");
            sql.Append("'" + Type + "'");
            sql.Append("'" + Description + "'");
            sql.Append("'" + FollowUpDate + "', ");
            sql.Append("'" + IsIssueResolved + "', ");
            sql.Append("" + SatisfactionLevel.ToString() + " ");          

            sql.Append(");");

            return sql.ToString();
        }

        #endregion
        

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FollowUp up &&
                   FollowupReportID == up.FollowupReportID &&
                   Title == up.Title &&
                   Type == up.Type &&
                   Description == up.Description &&
                   FollowUpDate == up.FollowUpDate &&
                   IsIssueResolved == up.IsIssueResolved &&
                   SatisfactionLevel == up.SatisfactionLevel;
        }

        public override int GetHashCode()
        {
            int hashCode = 208219931;
            hashCode = hashCode * -1521134295 + FollowupReportID.GetHashCode();
            hashCode = hashCode * -1521134295 + Title.GetHashCode();
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + Description.GetHashCode();
            hashCode = hashCode * -1521134295 + FollowUpDate.GetHashCode();
            hashCode = hashCode * -1521134295 + IsIssueResolved.GetHashCode();
            hashCode = hashCode * -1521134295 + SatisfactionLevel.GetHashCode();
            return hashCode;
        }
    }
}
