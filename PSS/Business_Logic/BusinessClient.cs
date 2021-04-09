using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class BusinessClient : Client
    {
        private string businessName;

        public int BusinessID { get => IdNumber; set => IdNumber = value; }
        public string BusinessName { get => businessName; set => businessName = value; }
        public string ContactPersoneName { get => FirstName; set => FirstName = value; }
        public string ContactPersonSurname { get => LastName; set => LastName = value; }
        
        public BusinessClient(int businessID, string businessName, string contactPersoneName, string contactPersonSurname, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(businessID, contactPersoneName, contactPersonSurname, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {
            BusinessName = businessName;
            ContactPersoneName = contactPersoneName;
            ContactPersonSurname = contactPersonSurname;
        }

        public BusinessClient()
        {
        }
    }
}
