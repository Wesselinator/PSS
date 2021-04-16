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
        public virtual int ClientID { get; protected set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CBXString { get => Person.CellphoneNumber + " | " + Person.FirstName; }
        public Address Address { get; set; }
        public Person Person { get; set; }

        protected Client(int clientID, string type, string status, string notes, Address address, Person person) //should not be able to create half a client
        {
            this.ClientID = clientID;
            this.Type = type;
            this.Status = status;
            this.Notes = notes;
            this.Address = address;
            this.Person = person;
        }

        public Client() //usefull
        {
            
        }

        #region DataBase

        public Client(DataRow row, string ClientID)
        {
            Type = row.Field<string>("Type");
            Status = row.Field<string>("Status");
            Notes = row.Field<string>("Notes");
            Address = new Address(row.Field<int>("AddressID"));
            Person = new Person(row.Field<int>(ClientID));
        }

        //P3
        public static Client GetByClientID(int ID)
        {
            Client ret;
            try
            {
                ret = new BusinessClient(ID);
                return ret; //ID was a Business Client
            }
            catch (Exception)
            {
                try
                {
                    ret = new IndividualClient(ID);
                    return ret; //ID was an Individual Client
                }
                catch (Exception e)
                {
                    throw e; //ID did not exist in client tables
                }
            }
        }
        //P3
        public virtual void Save()
        {
            throw new NotImplementedException(); //This is Correct. It should never hit this.
        }

        protected string Update(StringBuilder sql)
        {
            sql.Append("Type = '" + Type + "', ");
            sql.Append("Status = '" + Status + "', ");
            sql.Append("Notes = '" + Notes + "', ");
            sql.AppendLine("AddressID = " + Address.AddressID);

            sql.AppendLine("WHERE ClientID = " + ClientID); //Tested: Will access correctly.

            return sql.ToString();
        }

        protected string Insert(StringBuilder sql)
        {
            sql.Append("'" + Type + "', ");
            sql.Append("'" + Status + "', ");
            sql.Append("'" + Notes + "', ");
            sql.Append(Address.AddressID);
            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            //add if branch for businsess/individual testing?
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
