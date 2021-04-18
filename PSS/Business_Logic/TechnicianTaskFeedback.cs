using System;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;
using System.Collections.Generic;

namespace PSS.Business_Logic
{
    public class TechnicianTaskFeedback : BaseSingleID
    {
        public int TechnicianTaskFeedID { get => ID; private set => ID = value; }
        public DateTime TimeArived { get; set; }
        public DateTime TimeDuration { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public TechnicianTask TechnicianTask { get; set; }

        private static readonly string tableName = "TechnicianTaskFeed";
        private static readonly string idColumn = "TechnicianTaskFeedID";

        public TechnicianTaskFeedback() : base(tableName, idColumn)
        { }

        public TechnicianTaskFeedback(int technicianTaskFeedID, DateTime timeArived, DateTime timeDuration, string notes, string status, string technicianTask) : this()
        {
            TechnicianTaskFeedID = technicianTaskFeedID;
            TimeArived = timeArived;
            TimeDuration = timeDuration;
            Notes = notes;
            Status = status;
            TechnicianTask = technicianTask;
        }

        public TechnicianTaskFeedback(DateTime timeArived, DateTime timeDuration, string notes, string status, string technicianTask) : this()
        {
            TechnicianTaskFeedID = base.GetNextID(); 
            TimeArived = timeArived;
            TimeDuration = timeDuration;
            Notes = notes;
            Status = status;
            TechnicianTask = technicianTask;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianTaskFeedID = row.Field<int>(IDColumn);
            this.TimeArived = row.Field<DateTime>("TimeArived");
            this.TimeDuration = row.Field<DateTime>("TimeDuration");
            this.Notes = row.Field<string>("Notes");
            this.Status = row.Field<string>("Status");
            this.TechnicianTask = DataEngine.GetDataObject<TechnicianTask>(row.Field<int>("TechnicianTaskID"));
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("TechnicianTaskFeedID = " + TechnicianTaskFeedID + ", ");
            sql.Append("TimeArived = '" + TimeArived.ToString("s") + "', ");
            sql.Append("TimeDuration = '" + TimeDuration.ToString("s") + "', ");
            sql.Append("Notes = '" + Notes + "', ");
            sql.Append("Status = '" + Status + "', ");
            sql.AppendLine("TechnicianTaskID = " + TechnicianTask.TechnicianTaskID);

            sql.AppendLine("WHERE " + IDColumn + " = " + TechnicianTaskFeedID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(TechnicianTaskFeedID + ", ");
            sql.Append("'" + TimeArived.ToString("s") + "', ");
            sql.Append("'" + TimeDuration.ToString("s") + "', ");
            sql.Append("'" + Notes + "', ");
            sql.Append("'" + Status + "', ");
            sql.Append(TechnicianTask.TechnicianTaskID);

            sql.AppendLine(");");

            return sql.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is TechnicianTaskFeedback feedback &&
                   TechnicianTaskFeedID == feedback.TechnicianTaskFeedID &&
                   TimeArived == feedback.TimeArived &&
                   TimeDuration == feedback.TimeDuration &&
                   Notes == feedback.Notes &&
                   Status == feedback.Status &&
                   TechnicianTask.Equals(feedback.TechnicianTask);
        }

        public override int GetHashCode()
        {
            int hashCode = -784394317;
            hashCode = hashCode * -1521134295 + TechnicianTaskFeedID.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeArived.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeDuration.GetHashCode();
            hashCode = hashCode * -1521134295 + Notes.GetHashCode();
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            hashCode = hashCode * -1521134295 + TechnicianTask.GetHashCode();
            return hashCode;
        }

        #endregion


    }
}
