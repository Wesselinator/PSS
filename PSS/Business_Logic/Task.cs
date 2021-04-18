using System;
using System.Text;
using PSS.Data_Access;
using System.Data;

//CHECK
namespace PSS.Business_Logic
{
    public class Task : BaseSingleID
    {
        public int TaskID { get => ID; private set => ID = value; }
        public string Title { get; set; }
        public string Descripion { get; set; }
        public string Notes { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public DateTime DateProcessed { get; set; }
        public bool IsFinished { get; set; }

        private static readonly string tableName = "Task";
        private static readonly string idColumn = "TaskID";

        public Task() : base(tableName, idColumn)
        { }

        public Task(int taskID, string title, string descripion, string notes, ServiceRequest serviceRequest, DateTime dateProcessed, bool isFinished) : this()
        {
            this.TaskID = taskID;
            this.Title = title;
            this.Descripion = descripion;
            this.Notes = notes;
            this.ServiceRequest = serviceRequest;
            this.DateProcessed = dateProcessed;
            this.IsFinished = isFinished;
        }

        public Task(string title, string descripion, string notes, ServiceRequest serviceRequest, DateTime dateProcessed, bool isFinished) : this()
        {
            this.TaskID = base.GetNextID();
            this.Title = title;
            this.Descripion = descripion;
            this.Notes = notes;
            this.ServiceRequest = serviceRequest;
            this.DateProcessed = dateProcessed;
            this.IsFinished = isFinished;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TaskID = row.Field<int>(IDColumn);
            this.Title = row.Field<string>("Title");
            this.Descripion = row.Field<string>("Descripion");
            this.Notes = row.Field<string>("Notes");
            this.ServiceRequest = DataEngine.GetDataObject<ServiceRequest>(row.Field<int>("ServiceRequestID"));
            this.DateProcessed = row.Field<DateTime>("DateProcessed");
            this.IsFinished = row.Field<bool>("IsFinished");
        }

        //P4
        public override void Save()
        {
            ServiceRequest.Save();
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("TaskTitle = '" + Title + "',");
            sql.Append("TaskDescripion = '" + Descripion + "',");
            sql.Append("TaskNotes = '" + Notes + "',");
            sql.Append("ServiceRequestID = " + ServiceRequest.ServiceRequestID + ",");
            sql.Append("TaskDateProcessed = '" + DateProcessed.ToString("s") + "'"); //.ToUniversalTime. depending on what exactly SQL Server is smoking
            sql.AppendLine("IsFinished = " + (IsFinished ? 1 : 0));

            sql.AppendLine("WHERE " + IDColumn + " = " + TaskID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(TaskID + ", ");
            sql.Append("'" + Title + "', ");
            sql.Append("'" + Descripion + "', ");
            sql.Append("'" + Notes + "', ");
            sql.Append(ServiceRequest.ServiceRequestID + ", ");
            sql.Append("'" + DateProcessed.ToString("s") + "', ");
            sql.Append( (IsFinished ? 1 : 0) );
            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override string ToString()
        {
            return base.ToString();
            //TODO: update
        }

        //TODO: wtf?
        public static string GetProgressRapport(string ticketNo)
        {
            return DataEngine.GetProgressRapport(ticketNo);
        }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   TaskID == task.TaskID &&
                   Title == task.Title &&
                   Descripion == task.Descripion &&
                   Notes == task.Notes &&
                   ServiceRequest.Equals(task.ServiceRequest) &&
                   DateProcessed == task.DateProcessed &&
                   IsFinished == task.IsFinished;
        }

        public override int GetHashCode()
        {
            int hashCode = -1945863682;
            hashCode = hashCode * -1521134295 + TaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + Title.GetHashCode();
            hashCode = hashCode * -1521134295 + Descripion.GetHashCode();
            hashCode = hashCode * -1521134295 + Notes.GetHashCode();
            hashCode = hashCode * -1521134295 + ServiceRequest.GetHashCode();
            hashCode = hashCode * -1521134295 + DateProcessed.GetHashCode();
            hashCode = hashCode * -1521134295 + IsFinished.GetHashCode();
            return hashCode;
        }
    }
}

