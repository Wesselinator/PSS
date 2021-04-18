using System;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    //TODO: Add updateability!
    public class BusinessClientPerson : BaseMultiID
    {
        private Person p;
        public int BusinessClientID { get => IDs[0]; private set => IDs[0] = value; }
        public Person Person { 
            get => p;

            set { 
                p = value;
                IDs[1] = value.PersonID;
            }
        }
        public string Role { get; set; }

        private static readonly string tableName = "BusinessClientPerson";
        private static readonly string idColumn1 = "BusinessClientID";
        private static readonly string idColumn2 = "PersonID";

        public BusinessClientPerson() : base(tableName, idColumn1, idColumn2)
        { }

        public BusinessClientPerson(int businessClientID, Person person, string role) : this()
        {
            this.BusinessClientID = businessClientID;
            this.Person = person;
            this.Role = role;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.BusinessClientID = row.Field<int>(idColumn1);

            this.Person = new Person();
            this.Person.FillWithID(row.Field<int>("PersonID"));

            this.Role = row.Field<string>("Role");
        }

        public override void Save()
        {
            Person.Save();
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.AppendLine("Role = '" + Role + "'");

            sql.Append("WHERE ");
            sql.Append(idColumn1 + " = " + BusinessClientID);
            sql.Append(" AND ");
            sql.AppendLine(idColumn2 + " = " + Person.PersonID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);
            sql.Append("VALUES (");

            sql.Append(BusinessClientID + ", ");
            sql.Append(Person.PersonID + ", ");
            sql.AppendLine("'" + Role + "'");

            sql.AppendLine(");");

            return sql.ToString();
        }


        #endregion
    }
}
