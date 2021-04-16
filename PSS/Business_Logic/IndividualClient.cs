using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class IndividualClient : Client
    {
        public IndividualClient(int clientID, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email) : base(clientID, firstName, lastName, cellphoneNumber, telephoneNumber, email)
        {

        }

        public IndividualClient() : base()
        {

        }

        public IndividualClient(DataRow row) : base(row)
        {
            Adress = new Address(DataEngine.GetByID("Address", "AddressID", row.Field<int>("AddressID")));
        }
    }
}
