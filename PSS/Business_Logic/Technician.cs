using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Technician : SingleIntID
    {
        public int TechnicianID { get => Person.PersonID; private set { ID = value; } }
        public string Specialty { get; set; }
        public decimal PayRate { get; set; }
        public Person Person { get; set; }

        public string DisplayMember => Person.FullName;

        private static readonly string tableName = "Technician";
        private static readonly string idColumn = "TechnicianID";

        public Technician() : base(tableName, idColumn) 
        {  }

        public Technician(string specialty, decimal payRate, Person person) : this()
        {
            this.TechnicianID = person.PersonID;
            this.Specialty = specialty;
            this.PayRate = payRate;
            this.Person = person;
        }

        public Technician(string specialty, decimal payRate) : this()
        {
            Person newPerson = new Person();
            newPerson.SetNextID();
            this.TechnicianID = newPerson.PersonID;
            this.Specialty = specialty;
            this.PayRate = payRate;
            this.Person = newPerson;
        }

        protected override int GetNextID()
        {
            throw new TableIsAComposition(tableName);
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.TechnicianID = row.Field<int>(idColumn);
            this.Specialty = row.Field<string>("Speciality");
            this.PayRate = row.Field<decimal>("PayRate");
            this.Person = DataEngine.GetDataObject<Person>(row.Field<int>(idColumn));
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + tableName);
            sql.Append("SET ");

            sql.Append("Speciality = '" + Specialty + "', ");
            sql.Append("PayRate = " + PayRate.ToString("0.00"));

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
            sql.Append(PayRate.ToString("0.00"));

            sql.Append(");");

            return sql.ToString();
        }

        #endregion

        public static BaseList<Technician> GetAllAvailableClients()
        {
            string sql = "SELECT t1.TechnicianID,p.FirstName,p.LastName, p.BirthDate,p.CellPhoneNumber,p.TelephoneNumber,p.Email,t1.Speciality,t1.PayRate " +
            "FROM Person p " +
            "JOIN Technician t1 " +
            "ON p.PersonID = t1.TechnicianID " +
            "WHERE p.PersonID NOT IN( " +
                "SELECT DISTINCT p.PersonID " +
                "FROM Person p " +
                "JOIN Technician t " +
                "ON p.PersonID = t.TechnicianID " +
                "LEFT JOIN TechnicianTask tt " +
                "ON t.TechnicianID = tt.TechnicianID " +
                "LEFT JOIN TechnicianTaskFeedback ttf " +
                "ON tt.TechnicianTaskID = ttf.TechnicianTaskID " +
                "WHERE ('2021/04/18 10:00:00' BETWEEN tt.TimeToArrive AND tt.TimeToDepart)" +
            ")";
            DataTable dataTable = DataHandler.GetDataTable(sql);

            BaseList<Technician> ret = new BaseList<Technician>();
            ret.FillWith(dataTable);
            return ret;
        }

        public override bool Equals(object obj)
        {
            return obj is Technician technician &&
                   TechnicianID == technician.TechnicianID &&
                   Specialty == technician.Specialty &&
                   PayRate == technician.PayRate &&
                   Person.Equals(technician.Person);
        }

        public override int GetHashCode()
        {
            int hashCode = 226706189;
            hashCode = hashCode * -1521134295 + TechnicianID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Specialty);
            hashCode = hashCode * -1521134295 + PayRate.GetHashCode();
            return hashCode;
        }

        public string ToFormattedString()
        {
            return string.Format("{0} specializes in {1} and gets payed R{2:0.00} p/m.{3}", Person.FullName, Specialty, PayRate, ContractString());
        }
        private string ContractString()
        {
            string[] ret = Person.ContactSet();
            string reach = " They can be reached by ";
            switch (ret.Length)
            {
                case 1:
                    return reach + ret[0];

                case 2:
                    return reach + ret[0] + " or by " + ret[1];

                case 3:
                    return reach + ret[0] + " or " + ret[1] + " or by " + ret[2];

                case 0:
                default: 
                    return string.Empty;
            }
        }

        public override string ToString()
        {
            return string.Format("TechnicianID: {0} | Specialty: {1} | PayRate: {2:0.00} | Person: [{3}] ", TechnicianID, Specialty, PayRate, Person);
        }

    }
}
