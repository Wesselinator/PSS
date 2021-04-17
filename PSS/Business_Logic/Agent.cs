using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class Agent : Employee
    {
        private string department; 
        
        public int AgentID { get => PersonID; set => PersonID = value; }
        public string Department { get => department; set => department = value; }

        public Agent(int agentID, string department, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(agentID, firstName,lastName,cellphoneNumber,telephoneNumber,email,streetAddress,cityAddress,postalCode,province)
        {
            this.AgentID = agentID;
            this.Department = department;
        }

        public Agent(string department)
        {
            Department = department;
        }

        public void AnswerCall()
        {

        }

        public void RegisterIndividualClient(Person person, Address address, Client client)// order matters.
        {
            string PersonQuery = $"INSERT INTO Person VALUES '({person.PersonID})', '({person.FirstName})', '({person.LastName})', '({person.BirthDay})', '({person.CellphoneNumber})', '({person.TellephoneNumber})', '({person.Email})'";
            DataHandler.Insert(PersonQuery);

            string AddressQuery = $"INSERT INTO Address VALUES '({address.AddressID})', '({address.Street})', '({address.City})', '({address.PostalCode})', '({address.Province})'";
            DataHandler.Insert(AddressQuery);

            string ClientQuery = $"INSERT INTO IndividualCLient VALUES '({person.PersonID})', '({client.Type})', '({client.Status})', '({client.Notes})', '({address.AddressID})'";
            DataHandler.Insert(ClientQuery);
        }

        public void UpdateIndividualClient(Person person, Address address, Client client)
        {
            string PersonQuery = $"UPDATE Person SET PersonID = '({person.PersonID})', FirstName = '({person.FirstName})', LastName = '({person.LastName})', BirthDate = '({person.BirthDay})', CellPhoneNumber = '({person.CellphoneNumber})', Telephone = '({person.TellephoneNumber})', Email = '({person.Email})'";
            DataHandler.Update(PersonQuery);

            string AddressQuery = $"UPDATE Address SET AddressID = '({address.AddressID})', Street = '({address.Street})', City = '({address.City})', PostalCode = '({address.PostalCode})', Province = '({address.Province})'";
            DataHandler.Update(AddressQuery);

            string ClientQuery = $"UPDATE IndividualClient SET IndividualClientID = '({person.PersonID})', Type = '({client.Type})', Status = '({client.Status})', Notes = '({client.Notes})', AddressID = '({address.AddressID})'";
            DataHandler.Update(ClientQuery);
        }

        public void RegisterBusinessClient(Person person, Address address, BusinessClient businessclient)
        {            
            string PersonQuery = $"INSERT INTO Person VALUES '({person.PersonID})', '({person.FirstName})', '({person.LastName})', '({person.BirthDay})', '({person.CellphoneNumber})', '({person.TellephoneNumber})', '({person.Email})'";
            DataHandler.Insert(PersonQuery);

            string AddressQuery = $"INSERT INTO Address VALUES '({address.Street})', '({address.City})', '({address.PostalCode})', '({address.Province})'";
            DataHandler.Insert(AddressQuery);

            string ClientQuery = $"INSERT INTO BusinessCLient VALUES '({person.PersonID})', '({businessclient.BusinessName})', '({businessclient.Type})', '({businessclient.Status})', '({businessclient.Notes})', '({address.AddressID})', '({businessclient.ContactPerson})'";
            DataHandler.Insert(ClientQuery);
        }

        public void UpdateBusinessClient(Person person, Address address, BusinessClient businessclient)
        {            
            string PersonQuery = $"UPDATE Person SET PersonID = '({person.PersonID})', FirstName = '({person.FirstName})', LastName = '({person.LastName})', BirthDate = '({person.BirthDay})', CellPhoneNumber = '({person.CellphoneNumber})', Telephone = '({person.TellephoneNumber})', Email = '({person.Email})'";
            DataHandler.Update(PersonQuery);

            string AddressQuery = $"UPDATE Address SET AddressID = '({address.AddressID})', Street = '({address.Street})', City = '({address.City})', PostalCode = '({address.PostalCode})', Province = '({address.Province})'";
            DataHandler.Update(AddressQuery);

            string ClientQuery = $"UPDATE BusinessClient SET BusinessClientID = '({person.PersonID})', CompanyOrEntityName = '({businessclient.BusinessName})', Type = '({businessclient.Type})', Status = '({businessclient.Status})', Notes = '({businessclient.Notes})', AddressID = '({address.AddressID})', PrimaryContactPersonID = '({person.PersonID})'";
            DataHandler.Update(ClientQuery);
        }

        public bool AddClientContract(Client newClient)
        {
            return true;
        }
    }
}
