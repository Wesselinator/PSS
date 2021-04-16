using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    public class Client : Person
    {
        private DateTime registrationDate;
        //private List<Contact> contracts;

        public int ClientID { get => IdNumber; set => IdNumber = value; } 
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public string ListString { get => CellphoneNumber + " | " + FirstName; }

        public Client(int clientID, DateTime registrationDate, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(clientID, firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {
            this.ClientID = clientID;
            this.registrationDate = registrationDate;
        }

        public Client(int clientID, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(clientID, firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {
            this.ClientID = clientID;
            this.registrationDate = DateTime.Now;
        }

        public Client() 
        {
            
        }
    }
}
