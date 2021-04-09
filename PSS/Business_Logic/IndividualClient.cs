using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class IndividualClient : Client
    {
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public IndividualClient(int clientID, DateTime registrationDate, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(clientID, registrationDate, firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {

        }

        public IndividualClient(int clientID, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(clientID, firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {

        }

        public IndividualClient()
        {

        }
    }
}
