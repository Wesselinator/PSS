using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class BusinessClient : Client
    {
        public string BusinessName { get; set; }
        public Person Contact { get => Person; set => Person = value; }
        
        public BusinessClient(int businessID, string businessName, string contactPersoneName, string contactPersonSurname, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province, Address address) : base(businessID, contactPersoneName, contactPersonSurname, cellphoneNumber, telephoneNumber, email)
        {
            BusinessName = businessName;
            Address = address;
        }
        public BusinessClient()
        {

        }

        public BusinessClient(DataRow row) : base(row, "PrimaryContactPersonID")
        {
            BusinessName = row.Field<string>("BusinessName");            
        }

        public static BusinessClient GetID(int ID)
        {
            return new BusinessClient(DataEngine.GetByID("BusinessClient", "BusinessID", ID));
        }

        public override void Update()
        {
            Address.Update();
            base.Update();
        }
    }
}
