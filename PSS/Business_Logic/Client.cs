using PSS.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Business_Logic.DataBaseThings;
using System.Data;

namespace PSS.Business_Logic
{
    public class Client
    {
        private int clientID;
        private Person person;
        private List<Contract> contracts;
        private DateTime registrationDate;

        public int ClientID { get => clientID; set => clientID = value; }
        public Person Person { get => person; set => person = value; }
        public List<Contract> Contracts { get => contracts; set => contracts = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }

        ///New spesific client from person with spesific date with inate contracts
        public Client(int clientID, DateTime registrationDate, Person person)
        {
            this.ClientID = clientID;
            this.Person = person;
            //get contracts
            this.registrationDate = registrationDate;
        }

        ///New empty client
        public Client()
        {
            
        }

        public virtual void SetUpdate()
        {
            return;
        }

        public virtual Client GetSelect(int ID)
        {
            return null;
        }
    }
}
