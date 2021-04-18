using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Technician : BaseSingleID
    {
        public int TechnicianID { get => ID; private set => ID = value; }
        public string Specialty { get; set; }
        public string PayRate { get; set; }

        private static readonly string tableName = "Technician";
        private static readonly string idColumn = "TechnicianID";

        public Technician() : base(tableName, idColumn) 
        { }

        public Technician(int technicianID, string specialty, string payRate) : this()
        {
            TechnicianID = technicianID;
            Specialty = specialty;
            PayRate = payRate;
        }

        public Technician(string specialty, string payRate) : this()
        {
            TechnicianID = base.GetNextID();
            Specialty = specialty;
            PayRate = payRate;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianID = row.Field<int>(idColumn);
            this.Specialty = row.Field<string>("Speciality");
            this.PayRate = row.Field<string>("PayRate");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + tableName);
            sql.Append("SET ");

            sql.Append("Specialty = '" + Specialty + "', ");
            sql.Append("PayRate = '" + PayRate + "'");

            sql.Append("WHERE " + idColumn + " = " + TechnicianID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO " + tableName);
            sql.Append("VALUES (");

            sql.Append(TechnicianID + ", ");
            sql.Append("'" + Specialty + "', ");
            sql.Append("'" + PayRate + "' ");

            sql.Append(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is Technician technician &&
                   TechnicianID == technician.TechnicianID &&
                   Specialty == technician.Specialty &&
                   PayRate == technician.PayRate;
        }

        public override int GetHashCode()
        {
            int hashCode = 226706189;
            hashCode = hashCode * -1521134295 + TechnicianID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Specialty);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PayRate);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
