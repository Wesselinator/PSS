using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    //TODO: inherit from BusinessClientPerson
    class BusinessClient : Client
    {
        public string BusinessName { get; set; }
        public Address Adress { get; set; }
        
        //TODO: Build Adress
        public BusinessClient(int businessID, string businessName, string contactPersoneName, string contactPersonSurname, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(businessID, contactPersoneName, contactPersonSurname, cellphoneNumber, telephoneNumber, email)
        {
            BusinessName = businessName;
        }
        public BusinessClient()
        {

        }

        public BusinessClient(DataRow row) : base(row)
        {
            BusinessName = row.Field<string>("BusinessName");
            Adress = new Address(DataEngine.GetByID("Address", "AddressID", row.Field<int>("AddressID")));
        }
    }
}
