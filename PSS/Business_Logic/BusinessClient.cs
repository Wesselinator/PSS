using System;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class BusinessClient : Client, IModifyable
    {
        public string BusinessName { get; set; }
        public Person ContactPerson { get => Person; set => Person = value; }
        
        public BusinessClient(int businessID, string businessName, string type, string status, string notes, Address address, Person person) : base(businessID, type, status, notes, address, person)
        {
            BusinessName = businessName;
        }
        public BusinessClient() : base()
        {  }

        #region DataBase

        private static readonly string TableName = "BusinessClient";
        private static readonly string IDColumn = "BusinessClientID";

        public BusinessClient(DataRow row) : base(row, "PrimaryContactPersonID")
        {
            BusinessName = row.Field<string>("BusinessName");
        }

        //P3
        public BusinessClient(int ID)
        : this(DataEngine.GetByID(TableName, IDColumn, ID))
        {  }

        //P4
        public override void Save()
        {
            Address.Save();
            Person.Save();
            DataEngine.UpdateORInsert(this, TableName, IDColumn, ClientID);
        }

        string IUpdateable.Update()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("BusinessName = '" + BusinessName + "',");

            return base.Update(sql);
        }

        string IInsertable.Insert()
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

            return base.Insert(sql);
        }

        #endregion
    }
}
