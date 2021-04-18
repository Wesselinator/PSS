using System;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class BusinessClient : Client
    {
        public override int ClientID { get; protected set; } //needed?
        public string BusinessName { get; set; }
        public Person ContactPerson { get => Person; set => Person = value; }

        public static readonly string tableName = "BusinessClient";
        public static readonly string idColumn = "BusinessClientID";
        private static readonly string personColumn = "PrimaryContactPersonID";

        public BusinessClient() : base(tableName, idColumn)
        {  }

        public BusinessClient(int businessID, string businessName, string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            ClientID = businessID;
            BusinessName = businessName;
        }

        public BusinessClient(string businessName, string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            //ClientID = GetClientID
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
    }
}
