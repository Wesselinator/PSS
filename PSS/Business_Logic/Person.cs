using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PSS.Business_Logic
{
    public abstract class Person
    {
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public string CellphoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public Person(int idNumber, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email)
        {
            this.IdNumber = idNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CellphoneNumber = cellphoneNumber;
            this.TelephoneNumber = telephoneNumber;
            this.Email = email;
        }

        public Person()
        {
            
        }

        public Person(DataRow row) 
        {
            this.IdNumber = row.Field<int>("PersonID");
            this.FirstName = row.Field<string>("FirstName");
            this.LastName = row.Field<string>("LastName");
            this.CellphoneNumber = row.Field<string>("CellphoneNumber");
            this.TelephoneNumber = row.Field<string>("TelephoneNumber");
            this.Email = row.Field<string>("Email");
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   IdNumber == person.IdNumber &&
                   FirstName == person.FirstName &&
                   LastName == person.LastName &&
                   FullName == person.FullName &&
                   CellphoneNumber == person.CellphoneNumber &&
                   TelephoneNumber == person.TelephoneNumber &&
                   Email == person.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = -2023036441;
            hashCode = hashCode * -1521134295 + IdNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CellphoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TelephoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
