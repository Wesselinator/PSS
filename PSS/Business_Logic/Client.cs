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
        private int clientID;
        //private List<Contact> contracts;

        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public int ClientID { get => clientID; set => clientID = value; }

        public Client(DateTime registrationDate, int clientID)
        {
            this.registrationDate = registrationDate;
            this.clientID = clientID;
        }

        public Client() { 
        
        }
    }
}
