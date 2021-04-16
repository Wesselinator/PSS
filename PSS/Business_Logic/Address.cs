using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PSS.Business_Logic
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }

        public Address(string street, string city, string postalCode, string province)
        {
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        public Address(DataRow row)
        {
            this.Street = row.Field<string>("Street");
            this.City = row.Field<string>("City");
            this.PostalCode = row.Field<string>("PostalCode");
            this.Province = row.Field<string>("Province");
        }

        public Address()
        {

        }

        public override string ToString()
        {
            //TODO: Create the string!
            return base.ToString();
        }
    }
}
