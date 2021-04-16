using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Client
    {
        public int ClientID { get; set; }  //this makes sense
        public string Type { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CBXString { get => Person.CellphoneNumber + " | " + Person.FirstName; }
        public Address Address { get; set; }
        public Person Person { get; set; }

        public Client(int clientID, string type, string status, string notes, Address address, Person person)
        {
            this.ClientID = clientID;
            this.Type = type;
            this.Status = status;
            this.Notes = notes;
            this.Address = address;
            this.Person = person;
        }

        public Client() 
        {
            
        }

        public Client(DataRow row, string ClientID)
        {
            Type = row.Field<string>("Type");
            Status = row.Field<string>("Status");
            Notes = row.Field<string>("Notes");
            Address = Address.GetID(row.Field<int>("AddressID"));
            Person = Person.GetID(row.Field<int>(ClientID));
        }
    }
}
