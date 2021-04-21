using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

//PERSON
namespace PSS.Business_Logic
{
    public class Person : SingleIntID
    {
        private static readonly string BirthDayFormat = "yyyy-MM-dd";

        public int PersonID { get => ID; private set => ID = value; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public DateTime BirthDay { get; set; }
        public string BirthDayString { get => BirthDay.ToString(BirthDayFormat); }
        public string CellphoneNumber { get; set; }
        public string TellephoneNumber { get; set; }
        public string Email { get; set; }

        private static readonly string tableName = "Person";
        private static readonly string idColumn = "PersonID";

        public Person() : base(tableName, idColumn)
        { }
        public Person(int ID) : this() //This Table is used in compistion
        {
            PersonID = ID;
        }
        public Person(int personID, string firstName, string lastName, DateTime birthDay, string cellphoneNumber, string telephoneNumber, string email) : this()
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.CellphoneNumber = cellphoneNumber;
            this.TellephoneNumber = telephoneNumber;
            this.Email = email;
        }

        public Person(string firstName, string lastName, DateTime birthDay, string cellphoneNumber, string telephoneNumber, string email) : this()
        {
            this.PersonID = base.GetNextID();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.CellphoneNumber = cellphoneNumber;
            this.TellephoneNumber = telephoneNumber;
            this.Email = email;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.PersonID = row.Field<int>(IDColumn);
            this.FirstName = row.Field<string>("FirstName");
            this.LastName = row.Field<string>("LastName");
            this.BirthDay = row.Field<DateTime>("BirthDate");
            this.CellphoneNumber = row.Field<string>("CellphoneNumber");
            this.TellephoneNumber = row.Field<string>("TelephoneNumber");
            this.Email = row.Field<string>("Email");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("FirstName = '" + FirstName + "', ");
            sql.Append("LastName = '" + LastName + "', ");
            sql.Append("BirthDate = '" + BirthDayString + "', ");
            sql.Append("CellPhoneNumber = '" + CellphoneNumber + "', ");
            sql.Append("TelephoneNumber = '" + TellephoneNumber + "', ");
            sql.AppendLine("Email = '" + Email + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + PersonID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (PersonID, FirstName, LastName, BirthDate, CellPhoneNumber, TelephoneNumber, Email)");
            sql.Append("VALUES (");

            sql.Append(PersonID + ", ");
            sql.Append("'" + FirstName + "', ");
            sql.Append("'" + LastName + "', ");
            sql.Append("'" + BirthDayString + "', ");
            sql.Append("'" + CellphoneNumber + "' ");
            sql.Append("'" + TellephoneNumber + "' ");
            sql.Append("'" + Email + "' ");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion        

        public override string ToString()
        {
            return string.Format("PersonID: {0} | FirstName: {1} | LastName: {2} | BirthDay: {3} | CellphoneNumber: {4} | TellePhoneNumber: {5}" +
                " | Email: {6}", PersonID, FirstName, LastName, BirthDay, CellphoneNumber, TellephoneNumber, Email);
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   PersonID == person.PersonID &&
                   FirstName == person.FirstName &&
                   LastName == person.LastName &&
                   FullName == person.FullName &&
                   BirthDay == person.BirthDay &&
                   CellphoneNumber == person.CellphoneNumber &&
                   TellephoneNumber == person.TellephoneNumber &&
                   Email == person.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = -632513257;
            hashCode = hashCode * -1521134295 + PersonID.GetHashCode();
            hashCode = hashCode * -1521134295 + FirstName.GetHashCode();
            hashCode = hashCode * -1521134295 + LastName.GetHashCode();
            hashCode = hashCode * -1521134295 + FullName.GetHashCode();
            hashCode = hashCode * -1521134295 + BirthDay.GetHashCode();
            hashCode = hashCode * -1521134295 + CellphoneNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + TellephoneNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + Email.GetHashCode();
            return hashCode;
        }
    }
}
