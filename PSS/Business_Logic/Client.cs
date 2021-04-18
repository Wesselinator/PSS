using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

//CHECK
namespace PSS.Business_Logic
{
    public abstract class Client : BaseSingleID
    {
        public virtual int ClientID { get => ID; protected set => ID = value; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CBXString { get => Person.CellphoneNumber + " | " + Person.FirstName; }
        public Address Address { get; set; }
        public Person Person { get; set; }

        public Client(string tableName, string idColumn) : base(tableName, idColumn)
        { 
            
        }

        protected Client(string tableName, string idColumn, string type, string status, string notes, Address address, Person person) : this(tableName, idColumn) //Protected Becuase you should not be able to create half a client
        {
            this.Type = type;
            this.Status = status;
            this.Notes = notes;
            this.Address = address;
            this.Person = person;
        }

        #region DataBase

        protected void FillPartialRow(DataRow row, string personColumn)
        {
            Type = row.Field<string>("Type");
            Status = row.Field<string>("Status");
            Notes = row.Field<string>("Notes");
            Address = DataEngine.GetDataObject<Address>(row.Field<int>("AddressID"));
            Person = DataEngine.GetDataObject<Person>(row.Field<int>(personColumn));
        }

        //P3
        //public override void Save()
        //{
        //    throw new NotImplementedException(); //This is Correct. It should never hit this.
        //}

        protected string UpdatePartial(StringBuilder sql)
        {
            sql.Append("Type = '" + Type + "', ");
            sql.Append("Status = '" + Status + "', ");
            sql.Append("Notes = '" + Notes + "', ");
            sql.AppendLine("AddressID = " + Address.AddressID);

            sql.AppendLine("WHERE ClientID = " + ClientID);

            return sql.ToString();
        }

        protected string InsertPartial(StringBuilder sql)
        {
            sql.Append("'" + Type + "', ");
            sql.Append("'" + Status + "', ");
            sql.Append("'" + Notes + "', ");
            sql.Append(Address.AddressID);

            sql.AppendLine(");");

            return sql.ToString();
        }

        protected override int GetNextID()
        {
            int ret = base.GetNextID();

            if (TableName == BusinessClient.tableName)
            {
                if (ret == 0) //Individual Client is empty
                {
                    ret++; // will become 2
                }
            }

            return ret + 1; //always even or odd
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
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            hashCode = hashCode * -1521134295 + Notes.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
