using System;
using System.Collections.Generic;
using System.Text;
using PSS.Data_Access;
using System.Data;

namespace PSS.Business_Logic
{
    public class Task : IModifyable
    {

        public int TaskID { get; private set; }
        public string Title { get; set; }
        public string Descripion { get; set; }
        public string Notes { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public DateTime DateProcessed { get; set; }
        public bool IsFinished { get; set; }

        public Task(int taskID, string title, string descripion, string notes, ServiceRequest serviceRequest, DateTime dateProcessed, bool isFinished)
        {
            this.TaskID = taskID;
            this.Title = title;
            this.Descripion = descripion;
            this.Notes = notes;
            this.ServiceRequest = serviceRequest;
            this.DateProcessed = dateProcessed;
            this.IsFinished = isFinished;
        }

        public Task(string title, string descripion, string notes, ServiceRequest serviceRequest, DateTime dateProcessed, bool isFinished)
             : this(DataEngine.GetNextID(TableName, IDColumn), title, descripion, notes, serviceRequest, dateProcessed, isFinished)
        {  }

        public Task()
        {  }

        #region DataBase

        private static readonly string TableName = "Task";
        private static readonly string IDColumn = "TaskID";

        public Task(DataRow row)
        {
            this.TaskID = row.Field<int>("TicketID");
            this.Title = row.Field<string>("Title");
            this.Descripion = row.Field<string>("Descripion");
            this.Notes = row.Field<string>("Notes");
            this.ServiceRequest = ServiceRequest.GetID(row.Field<int>("ServiceRequestID"));
            this.DateProcessed = row.Field<DateTime>("DateProcessed");
            this.IsFinished = row.Field<bool>("IsFinished");
        }

        //P3
        public static Task GetID(int ID)
        {
            return new Task(DataEngine.GetByID(TableName, IDColumn, ID));
        }

        //P4
        public void Save()
        {
            ServiceRequest.Save();
            DataEngine.UpdateORInsert(this, TableName, IDColumn, TaskID);
        }

        string IUpdateable.Update()
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

        string IInsertable.Insert()
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
                   EqualityComparer<ServiceRequest>.Default.Equals(ServiceRequest, task.ServiceRequest) &&
                   DateProcessed == task.DateProcessed &&
                   IsFinished == task.IsFinished;
        }

        public override int GetHashCode()
        {
            int hashCode = -1945863682;
            hashCode = hashCode * -1521134295 + TaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Descripion);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + EqualityComparer<ServiceRequest>.Default.GetHashCode(ServiceRequest);
            hashCode = hashCode * -1521134295 + DateProcessed.GetHashCode();
            hashCode = hashCode * -1521134295 + IsFinished.GetHashCode();
            return hashCode;
        }
    }
}

