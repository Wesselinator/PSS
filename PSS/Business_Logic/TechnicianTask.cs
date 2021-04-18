using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class TechnicianTask : BaseSingleID
    {
        public int TechnicianTaskID { get => ID; private set => ID = value; }

        public Task Task { get; set; }

        public Technician Technician { get; set; }

        public DateTime TimeToArrive { get; set; }

        private static readonly string tableName = "TechnicianTask";
        private static readonly string idColumn = "TechnicianTaskID";

        public TechnicianTask() : base(tableName, idColumn)
        {
        }

        public TechnicianTask(int technicianTaskID, Task task, Technician technician, DateTime timeToArrive) : this()
        {
            this.TechnicianTaskID = technicianTaskID;
            this.Task = task;
            this.Technician = technician;
            this.TimeToArrive = timeToArrive;
        }

        public TechnicianTask(Task task, Technician technician, DateTime timeToArrive) : this()
        {
            this.TechnicianTaskID = base.GetNextID();
            this.Task = task;
            this.Technician = technician;
            this.TimeToArrive = timeToArrive;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianTaskID = row.Field<int>(IDColumn);
            this.Task = DataEngine.GetDataObject<Task>(row.Field<int>("TaskID"));
            this.Technician = DataEngine.GetDataObject<Technician>(row.Field<int>("TechnicianID"));
            this.TimeToArrive = row.Field<DateTime>("TimeToArrive");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("TechnicianID = " + TechnicianTaskID + ", ");
            sql.Append("TaskID = " + Task.TaskID + ", ");
            sql.Append("TimeToArrive = '" + TimeToArrive.ToString("s") + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + TechnicianTaskID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(TechnicianTaskID.ToString() + ", ");
            sql.Append(Task.TaskID + ", ");
            sql.Append(Technician.TechnicianID + ", ");
            sql.Append("'" + TimeToArrive.ToString("s") + "'");

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
                   TechnicianTaskID == task.TechnicianTaskID &&
                   EqualityComparer<Task>.Default.Equals(Task, task.Task) &&
                   EqualityComparer<Technician>.Default.Equals(Technician, task.Technician) &&
                   TimeToArrive == task.TimeToArrive;
        }

        public override int GetHashCode()
        {
            int hashCode = 201898852;
            hashCode = hashCode * -1521134295 + TechnicianTaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Task>.Default.GetHashCode(Task);
            hashCode = hashCode * -1521134295 + EqualityComparer<Technician>.Default.GetHashCode(Technician);
            hashCode = hashCode * -1521134295 + TimeToArrive.GetHashCode();
            return hashCode;
        }
    }
}
