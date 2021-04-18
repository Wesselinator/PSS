using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PSS.Business_Logic
{
    public class TechnicianTask : BaseSingleID
    {
        public int TechnicianTaskID { get => ID; private set => ID = value; }

        public int TaskID { get; set; }

        public int TechnicianID { get; set; }

        public DateTime TimeToArrive { get; set; }

        private static readonly string tableName = "TechnicianTask";
        private static readonly string idColumn = "TechnicianTaskID";

        public TechnicianTask() : base(tableName, idColumn)
        {
        }

        public TechnicianTask(int technicianTaskID, int taskID, int technicianID, DateTime timeToArrive) : this()
        {
            this.TechnicianTaskID = technicianTaskID;
            this.TaskID = taskID;
            this.TechnicianID = technicianID;
            this.TimeToArrive = timeToArrive;
        }

        public TechnicianTask(int taskID, int technicianID, DateTime timeToArrive)
        {
            this.TechnicianTaskID = base.GetNextID();
            this.TaskID = taskID;
            this.TechnicianID = technicianID;
            this.TimeToArrive = timeToArrive;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianTaskID = row.Field<int>(IDColumn);
            this.TaskID = row.Field<int>("TaskID");
            this.TechnicianID = row.Field<int>("TechnicianID");
            this.TimeToArrive = row.Field<DateTime>("TimeToArrive");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("TaskID = '" + TaskID + "', ");
            sql.Append("TechnicianID = '" + TechnicianID + "', ");
            sql.Append("TimeToArrive = '" + TimeToArrive.ToString("s") + "', ");

            sql.AppendLine("WHERE " + IDColumn + " = " + TechnicianTaskID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(TechnicianTaskID.ToString() + ", ");
            sql.Append("'" + TaskID.ToString() + "', ");
            sql.Append("'" + TechnicianID.ToString() + "', ");
            sql.Append("'" + TimeToArrive.ToString("s") + "', ");

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
            return obj is TechnicianTask task &&
                   TableName == task.TableName &&
                   ID == task.ID &&
                   IDColumn == task.IDColumn &&
                   TechnicianTaskID == task.TechnicianTaskID &&
                   TaskID == task.TaskID &&
                   TechnicianID == task.TechnicianID &&
                   TimeToArrive == task.TimeToArrive;
        }

        public override int GetHashCode()
        {
            int hashCode = 1654516578;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TableName);
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IDColumn);
            hashCode = hashCode * -1521134295 + TechnicianTaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + TaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + TechnicianID.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeToArrive.GetHashCode();
            return hashCode;
        }


    }
}
