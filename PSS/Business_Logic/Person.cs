using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Person : IModifyable
    {
        private static readonly string BirthDayFormat = "yyyy-MM-dd";

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public DateTime BirthDay { get; set; }
        public string BirthDayString { get => BirthDay.ToString(BirthDayFormat); }
        public string CellphoneNumber { get; set; }
        public string TellephoneNumber { get; set; }
        public string Email { get; set; }

        public Person(int personID, string firstName, string lastName, DateTime birthDay, string cellphoneNumber, string telephoneNumber, string email)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.CellphoneNumber = cellphoneNumber;
            this.TellephoneNumber = telephoneNumber;
            this.Email = email;
        }

        public Person()
        {  }

        #region DataBase

        private static readonly string TableName = "Person";
        private static readonly string IDColumn = "PersonID";

        public Person(DataRow row) 
        {
            this.PersonID = row.Field<int>(IDColumn);
            this.FirstName = row.Field<string>("FirstName");
            this.LastName = row.Field<string>("LastName");
            this.BirthDay = row.Field<DateTime>("BirthDay");
            this.CellphoneNumber = row.Field<string>("CellphoneNumber");
            this.TellephoneNumber = row.Field<string>("TelephoneNumber");
            this.Email = row.Field<string>("Email");
        }

        //P3
        public Person(int ID)
        : this(DataEngine.GetByID(TableName, IDColumn, ID))
        { }

        //P4
        public void Save()
        {
            DataEngine.UpdateORInsert(this, TableName, IDColumn, PersonID);
        }

        string IUpdateable.Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("FirstName = '" + FirstName + "', ");
            sql.Append("LastName = '" + LastName + "', ");
            sql.Append("BirthDay = '" + BirthDayString + "', ");
            sql.Append("CellphoneNumber = '" + CellphoneNumber + "', ");
            sql.Append("TellephoneNumber = '" + TellephoneNumber + "', ");
            sql.AppendLine("Email = '" + Email + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + PersonID);

            return sql.ToString();
        }

        string IInsertable.Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

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
            return base.ToString();
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + BirthDay.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CellphoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TellephoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}
