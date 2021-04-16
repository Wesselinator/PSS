using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }

        public Address(int addressID, string street, string city, string postalCode, string province)
        {
            this.AddressID = addressID;
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        public Address(string street, string city, string postalCode, string province)
        {
            new Address(DataEngine.GetNextID("Address", "AddressID"), street, city, postalCode, province);
        }

        public Address()
        {

        }

        public Address(DataRow row)
        {
            this.Street = row.Field<string>("Street");
            this.City = row.Field<string>("City");
            this.PostalCode = row.Field<string>("PostalCode");
            this.Province = row.Field<string>("Province");
        }

        //P3
        public static Address GetID(int ID)
        {
            return new Address(DataEngine.GetByID("Address", "AddressID", ID));
        }

        //P4
        public void Update()
        {
            //test if exist
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE Address");
            sql       += "SET Street = '"+ Street +"'";
            sql += "SET Street = '" + Street + "'";
        }

        public override string ToString()
        {
            //TODO: Create the string!
            return base.ToString();
        }
    }
}
