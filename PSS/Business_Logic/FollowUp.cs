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

        private static readonly string tableName = "FollowUp";
        private static readonly string idColumn = "FollowupReportID";

        public FollowUp() : base(tableName, idColumn) 
        { }

        public FollowUp(int followupReportID, string title, string type, string description) : this()
        {
            FollowupReportID = followupReportID;
            Title = title;
            Type = type;
            Description = description;
        }

        public FollowUp(string title, string type, string description) : this()
        {
            FollowupReportID = base.GetNextID();
            Title = title;
            Type = type;
            Description = description;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.FollowupReportID = row.Field<int>(idColumn);
            this.Title = row.Field<string>("Title");
            this.Type = row.Field<string>("Type");
            this.Description = row.Field<string>("Description");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE " + tableName);
            sql.Append("SET ");

            sql.Append("Title = '" + Title + "', ");
            sql.Append("Type = '" + Type + "', ");
            sql.Append("Description = '" + Description + "'");

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

            sql.Append(");");

            return sql.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is FollowUp up &&
                   FollowupReportID == up.FollowupReportID &&
                   Title == up.Title &&
                   Type == up.Type &&
                   Description == up.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = 905264677;
            hashCode = hashCode * -1521134295 + FollowupReportID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }


        #endregion
    }
}
