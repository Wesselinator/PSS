using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

//REWORK
namespace PSS.Business_Logic
{
    public class Call : SingleIntID
    {
        private DateTime startTime;
        private DateTime endTime;
        private string descrition;

        public int CallInstanceID { get => ID; private set => ID = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public string Description { get => descrition; set => descrition = value; }

        private static readonly string tableName = "CallInstance";
        private static readonly string idColumn = "CallInstanceID";

        public Call() : base(tableName, idColumn)
        {  }

        public Call(int callInstanceID, DateTime startTime, DateTime endTime, string description) : this()
        {
            this.CallInstanceID = callInstanceID;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Description = description;
        }

        public Call(DateTime startTime, DateTime endTime, string description) : this()
        {
            this.CallInstanceID = base.GetNextID();
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Description = description;
        }

        #region Database

        public override void FillFromRow(DataRow row)
        {
            this.CallInstanceID = row.Field<int>(IDColumn);
            this.startTime = row.Field<DateTime>("StartTime");
            this.endTime = row.Field<DateTime>("EndTime");
            this.descrition = row.Field<string>("Description");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Update " + TableName);

            sql.Append("SET ");
            sql.Append("StartTIme = '" + startTime + "', ");
            sql.Append("EndTime = '" + endTime + "', ");
            sql.Append("Description = '" + descrition + "', ");

            sql.Append("WHERE " + IDColumn + " = " + CallInstanceID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(CallInstanceID + ", ");
            sql.Append("'" + startTime.ToString("s") + "', ");
            sql.Append("'" + endTime.ToString("s") + "', ");
            sql.Append("'" + descrition + "' ");
            sql.Append(");");


            return sql.ToString();
        }

        #endregion 

        public override bool Equals(object obj)
        {
            return obj is Call call &&
                   CallInstanceID == call.CallInstanceID &&
                   StartTime == call.StartTime &&
                   EndTime == call.EndTime &&
                   Description == call.Description;
        }

        public override int GetHashCode()
        {
            int hashCode = 1863301325;
            hashCode = hashCode * -1521134295 + CallInstanceID.GetHashCode();
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + Description.GetHashCode();
            return hashCode;
        }
        
        public override string ToString()
        {
            return string.Format("CallInstanceID: {0} | StartTime: {1} | EndTime: {2} | Description: {3}", CallInstanceID, StartTime, EndTime, Description);

        }
    }
}

