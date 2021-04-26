﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

//CHECK
namespace PSS.Business_Logic
{
    public abstract class Client : SingleIntID
    {
        public virtual int ClientID { get => ID; protected set => ID = value; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string CBXString { get => Person.CellphoneNumber + " | " + Person.FirstName; }
        public Address Address { get; set; }
        public Person Person { get; set; }


        #region Business Identifier
        private static readonly string IdentifierLetter = "ABCDE"; //char[] is a string!
        private int ClientIdentifierLetter { get { 
                int x = (int)ClientID.ToString("D8")[0]; //pad for zeros
                if (x > 4 || x < 0) { throw new BadDataBaseData("ClientIdentifier is Wrong!"); } //bad data is in the database!!!
                return IdentifierLetter[x];
            } }
        private string ClientID7Digits { get { return ClientID.ToString("D8").Remove(0, 1); } } //remove first digit no matter what it is
        #endregion
        public string BusinessIdentifier { get => ClientIdentifierLetter + ClientID7Digits; }

        public Client(string tableName, string idColumn) : base(tableName, idColumn)
        {  }

        protected Client(string tableName, string idColumn, string type, string status, string notes, Address address, Person person) : this(tableName, idColumn) //Protected Becuase you should not be able to create half a client
        {
            this.Type = type;
            this.Status = status;
            this.Notes = notes;
            this.Address = address;
            this.Person = person;
        }

        //Special for Individual Client
        protected Client(string tableName, string idColumn, string type, string status, string notes, Address address) : this(tableName, idColumn) //Protected Becuase you should not be able to create half a client
        {
            int newID = GetNextID(); //TODO: THIS is WRONG grab from Person
            this.Type = type;
            this.Status = status;
            this.Notes = notes;
            this.Address = address;
            this.Person = new Person(newID);
        }

        #region DataBase

        protected void FillPartialRow(DataRow row, string personColumn)
        {
            Type = row.Field<string>("Type");
            Status = row.Field<string>("Status");
            Notes = row.Field<string>("Notes");
            Address = DataEngine.GetDataObject<Address>(row.Field<int>("AddressID"));
            Person = DataEngine.GetDataObject<Person>(row.Field<int>(personColumn));

            FillLists(ClientID);
        }

        protected abstract void FillLists(int id);


        //TODO: test to see if below hits becuase base.
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


        #region List Getters/Setters
        //Because of how Lists work and becuase we are in C#7.3 this is sadly the best way to do it     :(

        public abstract BaseList<ServiceRequest> GetServiceRequests();
        public abstract void AddServiceRequest(ServiceRequest serviceRequest);

        public abstract BaseList<Contract> GetContracts();
        public abstract void AddContract(Contract contract, DateTime effectiveDate);

        public abstract BaseList<FollowUp> GetFolowups();
        public abstract void AddFolowup(FollowUp followUp);

        #endregion


        public static List<Client> GetAllClients()
        {
            return DataEngine.GetAllClients();//move code here
        }

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
            return string.Format("ClientID: {0} | Type: {1} | Status: {2} | Notes: {3} | Address: [{4}] | Person: [{5}]", ClientID, Type, Status, Notes, Address, Person);
        }

    }
}
