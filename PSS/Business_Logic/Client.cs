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

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   IdNumber == client.IdNumber &&
                   FirstName == client.FirstName &&
                   LastName == client.LastName &&
                   FullName == client.FullName &&
                   CellphoneNumber == client.CellphoneNumber &&
                   TelephoneNumber == client.TelephoneNumber &&
                   Email == client.Email &&
                   ClientID == client.ClientID &&
                   Type == client.Type &&
                   Status == client.Status &&
                   Notes == client.Notes &&
                   ListString == client.ListString;
        }

        public override int GetHashCode()
        {
            int hashCode = -33787204;
            hashCode = hashCode * -1521134295 + IdNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CellphoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TelephoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ListString);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
