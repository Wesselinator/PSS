using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Client : Person
    {
        public int ClientID { get => IdNumber; set => IdNumber = value; }  //this makes sense
        public string Type { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string ListString { get => CellphoneNumber + " | " + FirstName; } //TODO: get a better name
        //Address

        public Client(int clientID, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email) : base(clientID, firstName, lastName, cellphoneNumber, telephoneNumber, email)
        {
            
        }

        public Client() 
        {
            
        }

        public Client(DataRow row) : base(DataEngine.GetByID("Person", "PersonID", row.Field<int>("PersonID")))
        {
            Type = row.Field<string>("Type");
            Status = row.Field<string>("Status");
            Notes = row.Field<string>("Notes");
        }
    }
}
