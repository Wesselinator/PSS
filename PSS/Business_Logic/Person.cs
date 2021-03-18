using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    public abstract class Person
    {
        private string firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province;
        private int idNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string CellphoneNumber { get => cellphoneNumber; set => cellphoneNumber = value; }
        public string TelephoneNumber { get => telephoneNumber; set => telephoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string CityAddress { get => cityAddress; set => cityAddress = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Province { get => province; set => province = value; }
        public int IdNumber { get => idNumber; set => idNumber = value; }

        protected Person(int idNumber, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CellphoneNumber = cellphoneNumber;
            this.TelephoneNumber = telephoneNumber;
            this.Email = email;
            this.StreetAddress = streetAddress;
            this.CityAddress = cityAddress;
            this.PostalCode = postalCode;
            this.Province = province;
            this.IdNumber = idNumber;
        }

        public Person()
        {

        }
    }
}
