using System;
using System.Text;
using PSS.Data_Access;
using System.Data;
using System.Collections.Generic;

namespace PSS.Business_Logic
{
    public class Task : SingleIntID
    {
        public int TaskID { get => ID; private set => ID = value; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public DateTime DateProcessed { get; set; }
        public bool IsFinished { get; set; }

        private static readonly string tableName = "Task";
        private static readonly string idColumn = "TaskID";

        public Task() : base(tableName, idColumn)
        { }

        public Task(int taskID, string title, string type, string descripion, string notes, ServiceRequest serviceRequest, DateTime dateProcessed, bool isFinished) : this()
        {
            this.TaskID = taskID;
            this.Title = title;
            this.Type = type;
            this.Description = descripion;
            this.Notes = notes;
            this.ServiceRequest = serviceRequest;
            this.DateProcessed = dateProcessed;
            this.IsFinished = isFinished;
        }

        public Task(string title, string type, string descripion, string notes, ServiceRequest serviceRequest, DateTime dateProcessed, bool isFinished) : this()
        {
            this.TaskID = base.GetNextID();
            this.Title = title;
            this.Type = type;
            this.Description = descripion;
            this.Notes = notes;
            this.ServiceRequest = serviceRequest;
            this.DateProcessed = dateProcessed;
            this.IsFinished = isFinished;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TaskID = row.Field<int>(IDColumn);
            this.Title = row.Field<string>("TaskTitle");
            this.Type = row.Field<string>("TaskType");
            this.Description = row.Field<string>("TaskDescription");
            this.Notes = row.Field<string>("TaskNotes");
            this.ServiceRequest = GetDataObject<ServiceRequest>(row.Field<int>("ServiceRequestID"));
            this.DateProcessed = row.Field<DateTime>("DateProcessed");
            this.IsFinished = row.Field<bool>("IsFinished");
        }

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

            sql.Append("TaskTitle = '" + Title + "', ");
            sql.Append("TaskType = '" + Type + "', ");
            sql.Append("TaskDescription = '" + Description + "', ");
            sql.Append("TaskNotes = '" + Notes + "', ");
            sql.Append("ServiceRequestID = " + ServiceRequest.ServiceRequestID + ", ");
            sql.Append("DateProcessed = '" + DateProcessed.ToString("s") + "', ");
            sql.AppendLine("IsFinished = " + (IsFinished ? 1 : 0));

            sql.AppendLine("WHERE " + IDColumn + " = " + TaskID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (TaskID, TaskTitle, TaskType, TaskDescription, TaskNotes, ServiceRequestID, DateProcessed, IsFinished) ");

            sql.Append("VALUES (");
            sql.Append(TaskID + ", ");
            sql.Append("'" + Title + "', ");
            sql.Append("'" + Type + "', ");
            sql.Append("'" + Description + "', ");
            sql.Append("'" + Notes?.ToString() + "', ");
            sql.Append(ServiceRequest.ServiceRequestID + ", ");
            sql.Append("'" + DateProcessed.ToString("s") + "' , ");
            sql.Append( (IsFinished ? 1 : 0) );
            sql.AppendLine(");");

            return sql.ToString();
        }

        public static BaseList<Task> GetAllUnFinishedTasks()
        {
            string sql = "SELECT * FROM " + tableName + " WHERE IsFinished = 0";
            return BaseList<Task>.GrabFill(sql);
        }

        public static BaseList<Task> GetAllDanglingTasks()
        {
            string sql = "SELECT DISTINCT t.* FROM " + tableName + " t " +
                         "LEFT JOIN techniciantask tt ON t.TaskID = tt.TaskID " +
                         "WHERE tt.TaskID IS NULL;";
            return BaseList<Task>.GrabFill(sql);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("TaskID: {0} | Title: {1} | Description: {2} | Notes: {3} |  ServiceRequest: [{4}] | DateProcessed: {5} | IsFinished: {6}", TaskID, Title, Description, Notes, ServiceRequest, DateProcessed, IsFinished);
        }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   TaskID == task.TaskID &&
                   Title == task.Title &&
                   Description == task.Description &&
                   Notes == task.Notes &&
                   ServiceRequest.Equals(task.ServiceRequest) &&
                   DateProcessed == task.DateProcessed &&
                   IsFinished == task.IsFinished;
        }

        public override int GetHashCode()
        {
            int hashCode = -1945863682;
            hashCode = hashCode * -1521134295 + TaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + ServiceRequest.GetHashCode();
            hashCode = hashCode * -1521134295 + DateProcessed.GetHashCode();
            hashCode = hashCode * -1521134295 + IsFinished.GetHashCode();
            return hashCode;
        }
    }
}

