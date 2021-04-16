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
        public virtual int ClientID { get; set; }
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

        protected void Update(StringBuilder sql)
        {
            sql.Append("Type = '" + Type + "',");
            sql.Append("Status = '" + Status + "',");
            sql.Append("Notes = '" + Notes + "',");

            Address.Update();
            Person.Update();

            sql.AppendLine("WHERE ClientID = " + ClientID); //Tested: Will access correctly

            DataHandler dh = new DataHandler();
            dh.Update(sql.ToString());
        }
        public void Insert()
        {
            //TODO: this
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   ClientID == client.ClientID &&
                   Type == client.Type &&
                   Status == client.Status &&
                   Notes == client.Notes;
        }

        public override int GetHashCode()
        {
            int hashCode = -33787204;
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
