using System;
using System.Text;
using System.Data;
using PSS.Data_Access;
using System.Collections.Generic;

//CHECK
namespace PSS.Business_Logic
{
    public class BusinessClient : Client
    {
        public override int ClientID { get; protected set; } //remember this is supposed to be even
        public string BusinessName { get; set; }
        public Person ContactPerson { get => Person; set => Person = value; }
        public MultiIDList<BusinessClientPerson> BusinessClientPeople { get; set; }

        public static readonly string tableName = "BusinessClient";
        public static readonly string idColumn = "BusinessClientID";
        private static readonly string personColumn = "PrimaryContactPersonID";

        public BusinessClient() : base(tableName, idColumn)
        {  }

        public BusinessClient(int businessID, string businessName, string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            ClientID = businessID;
            BusinessName = businessName;
            BusinessClientPeople.FillWithPivotColumn(businessID, BusinessClientPerson.idColumn1);
        }

        public BusinessClient(string businessName, string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            ClientID = GetNextID();
            BusinessName = businessName;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            BusinessName = row.Field<string>("BusinessName");
            FillPartialRow(row, personColumn);
        }

        public override void Save()
        {
            Address.Save();
            Person.Save();
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("BusinessName = '" + BusinessName + "',");

            return base.UpdatePartial(sql);
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(ClientID + ", ");
            sql.Append("'" + BusinessName + "', ");
            sql.Append("'" + Type + "', ");
            sql.Append("'" + Status + "', ");
            sql.Append("'" + Notes + "', ");
            sql.Append(Address.AddressID + ", ");
            sql.Append(ContactPerson.PersonID);

            sql.AppendLine(");");

            return base.InsertPartial(sql);
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is BusinessClient client &&
                   base.Equals(obj) &&
                   ClientID == client.ClientID &&
                   Type == client.Type &&
                   Status == client.Status &&
                   Notes == client.Notes &&
                   CBXString == client.CBXString &&
                   EqualityComparer<Address>.Default.Equals(Address, client.Address) &&
                   EqualityComparer<Person>.Default.Equals(Person, client.Person) &&
                   ClientID == client.ClientID &&
                   BusinessName == client.BusinessName &&
                   EqualityComparer<Person>.Default.Equals(ContactPerson, client.ContactPerson) &&
                   EqualityComparer<MultiIDList<BusinessClientPerson>>.Default.Equals(BusinessClientPeople, client.BusinessClientPeople);
        }

        public override int GetHashCode()
        {
            int hashCode = -929337925;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CBXString);
            hashCode = hashCode * -1521134295 + EqualityComparer<Address>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<Person>.Default.GetHashCode(Person);
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BusinessName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Person>.Default.GetHashCode(ContactPerson);
            hashCode = hashCode * -1521134295 + EqualityComparer<MultiIDList<BusinessClientPerson>>.Default.GetHashCode(BusinessClientPeople);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
