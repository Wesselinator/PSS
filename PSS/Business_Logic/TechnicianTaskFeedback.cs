using System;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;
using System.Collections.Generic;

namespace PSS.Business_Logic
{
    public class TechnicianTaskFeedback : SingleIntID
    {
        public int TechnicianTaskFeedID { get => ID; private set => ID = value; }
        public DateTime TimeArived { get; set; }
        public DateTime TimeDeparture { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public TechnicianTask TechnicianTask { get; set; }

        private static readonly string tableName = "TechnicianTaskFeedback";
        private static readonly string idColumn = "TechnicianTaskFeedbackID";

        public TechnicianTaskFeedback() : base(tableName, idColumn)
        { }

        public TechnicianTaskFeedback(int technicianTaskFeedID, DateTime timeArived, DateTime timeDeparture, string notes, string status, TechnicianTask technicianTask) : this()
        {
            TechnicianTaskFeedID = technicianTaskFeedID;
            TimeArived = timeArived;
            TimeDeparture = timeDeparture;
            Notes = notes;
            Status = status;
            TechnicianTask = technicianTask;
        }

        public TechnicianTaskFeedback(DateTime timeArived, DateTime timeDeparture, string notes, string status, TechnicianTask technicianTask) : this()
        {
            TechnicianTaskFeedID = base.GetNextID(); 
            TimeArived = timeArived;
            TimeDeparture = timeDeparture;
            Notes = notes;
            Status = status;
            TechnicianTask = technicianTask;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianTaskFeedID = row.Field<int>(IDColumn);
            this.TimeArived = row.Field<DateTime>("TimeArived");
            this.TimeDeparture = row.Field<DateTime>("TimeDuration");
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
            sql.Append("TimeDeparture = '" + TimeDeparture.ToString("s") + "', ");
            sql.Append("Status = '" + Status + "', ");
            sql.Append("Notes = '" + Notes + "', ");            
            sql.AppendLine("TechnicianTaskID = " + TechnicianTask.TechnicianTaskID);

            sql.AppendLine("WHERE " + IDColumn + " = " + TechnicianTaskFeedID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (TechnicianTaskFeedID, TimeArived, TimeDeparture, Status, Notes) ");
            sql.Append("VALUES (");

            sql.Append(TechnicianTaskFeedID + ", ");
            sql.Append("'" + TimeArived.ToString("s") + "', ");
            sql.Append("'" + TimeDeparture.ToString("s") + "', ");
            sql.Append("'" + Status + "', ");
            sql.Append("'" + Notes + "', ");
            sql.Append(TechnicianTask.TechnicianTaskID);

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is TechnicianTaskFeedback feedback &&
                   TechnicianTaskFeedID == feedback.TechnicianTaskFeedID &&
                   TimeArived == feedback.TimeArived &&
                   TimeDeparture == feedback.TimeDeparture &&
                   Notes == feedback.Notes &&
                   Status == feedback.Status &&
                   TechnicianTask.Equals(feedback.TechnicianTask);
        }

        public override int GetHashCode()
        {
            int hashCode = -784394317;
            hashCode = hashCode * -1521134295 + TechnicianTaskFeedID.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeArived.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeDeparture.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + TechnicianTask.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("TechnicianTaskFeedID: {0} | TimeArived: {1} | TimeDeparture: {2} | Notes: {3} | Status: {4} | TechnicianTask: [{5}]", TechnicianTaskFeedID, TimeArived, TimeDeparture, Notes, Status, TechnicianTask);
        }
    }
}
