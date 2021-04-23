using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Technician : SingleIntID
    {
        public int TechnicianID { get => Person.PersonID; private set { ID = value; } }
        public string Specialty { get; set; }
        public string PayRate { get; set; }
        public Person Person { get; set; }

        private static readonly string tableName = "Technician";
        private static readonly string idColumn = "TechnicianID";

        public Technician() : base(tableName, idColumn) 
        { }

        public Technician(string specialty, string payRate, Person person) : this()
        {
            TechnicianID = person.PersonID;
            Specialty = specialty;
            PayRate = payRate;
            Person = person;
        }

        public Technician(string specialty, string payRate) : this()
        {
            int nextID = GetNextID(); //TODO: This is wrong, get from Person
            TechnicianID = nextID;
            Specialty = specialty;
            PayRate = payRate;
            Person = new Person(nextID);
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianID = row.Field<int>(idColumn);
            this.Specialty = row.Field<string>("Speciality");
            this.PayRate = row.Field<string>("PayRate");
            this.Person = DataEngine.GetDataObject<Person>(row.Field<int>(idColumn));
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + tableName);
            sql.Append("SET ");

            sql.Append("Speciality = '" + Specialty + "', ");
            sql.Append("PayRate = '" + PayRate + "'");

            sql.Append("WHERE " + idColumn + " = " + TechnicianID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO " + tableName + " (TechnicianID, Speciality, PayRate)");
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
                   PayRate == technician.PayRate &&
                   Person.Equals(technician);
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
            return string.Format("TechnicianID: {0} | Specialty: {1} | PayRate: {2} | Person: [{3}] ", TechnicianID, Specialty, PayRate, Person);
        }
    }
}
