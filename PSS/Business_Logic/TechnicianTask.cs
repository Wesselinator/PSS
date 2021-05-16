using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class TechnicianTask : SingleIntID
    {
        public int TechnicianTaskID { get => ID; private set => ID = value; }

        public Technician Technician { get; set; }

        public Task Task { get; set; }

        public DateTime TimeToArrive { get; set; }

        public DateTime TimeToDepart { get; set; }

        public string DisplayMember => Technician.Person.FullName + " ->> " + Task.Title;

        private static readonly string tableName = "TechnicianTask";
        private static readonly string idColumn = "TechnicianTaskID";

        public TechnicianTask() : base(tableName, idColumn)
        {
        }

        public TechnicianTask(int technicianTaskID, Task task, Technician technician, DateTime timeToArrive, DateTime timeToDepart) : this()
        {
            this.TechnicianTaskID = technicianTaskID;
            this.Technician = technician;
            this.Task = task;
            this.TimeToArrive = timeToArrive;
            this.TimeToDepart = timeToDepart;
        }

        public TechnicianTask(Task task, Technician technician, DateTime timeToArrive, DateTime timeToDepart) : this()
        {
            this.TechnicianTaskID = base.GetNextID();
            this.Technician = technician;
            this.Task = task;
            this.TimeToArrive = timeToArrive;
            this.TimeToDepart = timeToDepart;
        }

        #region DataBase

        public override void Save()
        {
            Technician.Save();
            Task.Save();
            base.Save();
        }

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianTaskID = row.Field<int>(IDColumn);
            this.Technician = GetDataObject<Technician>(row.Field<int>("TechnicianID"));
            this.Task = GetDataObject<Task>(row.Field<int>("TaskID"));
            this.TimeToArrive = row.Field<DateTime>("TimeToArrive");
            this.TimeToDepart = row.Field<DateTime>("TimeToDepart");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("TechnicianID = " + Technician.TechnicianID + ", ");
            sql.Append("TaskID = " + Task.TaskID + ", ");
            sql.Append("TimeToArrive = '" + TimeToArrive.ToString("s") + "',");
            sql.Append("TimeToArrive = '" + TimeToDepart.ToString("s") + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + TechnicianTaskID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (TechnicianTaskID, TechnicianID, TaskID, TimeToArrive, TimeToDepart )");
            sql.Append("VALUES (");

            sql.Append(TechnicianTaskID.ToString() + ", ");
            sql.Append(Technician.TechnicianID + ", ");
            sql.Append(Task.TaskID + ", ");
            sql.Append("'" + TimeToArrive.ToString("s") + "',");
            sql.Append("'" + TimeToDepart.ToString("s") + "'");

            sql.AppendLine(");");

            return sql.ToString();
        }

        public static BaseList<TechnicianTask> GetUnfinishedTechTasks()
        {

            string sql = "SELECT tt.* FROM " + tableName + " tt " +
                         "LEFT JOIN Task t ON tt.TaskID = t.TaskID " +
                         "LEFT JOIN Technician tech ON tt.TechnicianID = tech.TechnicianID " +
                         "WHERE t.IsFinished = 0;";
       
            return BaseList<TechnicianTask>.GrabFill(sql);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("TechnicianTaskID: {0} | Task: [{1}] | Technician: [{2}] | TimeToArrive: {3} | TimeToDepart: {4}", TechnicianTaskID, Task, Technician, TimeToArrive, TimeToDepart);
        }

        public override bool Equals(object obj)
        {
            return obj is TechnicianTask task &&
                   TechnicianTaskID == task.TechnicianTaskID &&
                   Task.Equals(task.Task) &&
                   Technician.Equals(task.Technician) &&
                   TimeToArrive == task.TimeToArrive &&
                   TimeToDepart == task.TimeToDepart;
        }

        public override int GetHashCode()
        {
            int hashCode = 201898852;
            hashCode = hashCode * -1521134295 + TechnicianTaskID.GetHashCode();
            hashCode = hashCode * -1521134295 + Task.GetHashCode();
            hashCode = hashCode * -1521134295 + Technician.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeToArrive.GetHashCode();
            hashCode = hashCode * -1521134295 + TimeToDepart.GetHashCode();
            return hashCode;
        }
    }
}
