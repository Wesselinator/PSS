using System;
using System.Text;
using System.Data;
using PSS.Data_Access;
using System.Collections.Generic;

//CHECK
namespace PSS.Business_Logic
{
    public class BusinessClientPerson : MultiIntID
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

        public string DisplayMember => Person.DisplayMember + " [" + Role + "]";

        private static readonly string tableName = "BusinessClientPerson";
        public static readonly string idColumn1 = BusinessClient.idColumn;
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
            this.Person = DataEngine.GetDataObject<Person>(row.Field<int>("PersonID"));
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

            sql.Append("Role = '" + Role + "', ");
            sql.AppendLine(idColumn2 + " = " + Person.PersonID);

            sql.Append("WHERE ");
            sql.Append(idColumn1 + " = " + BusinessClientID);
            sql.Append(" AND ");
            sql.AppendLine(idColumn2 + " = " + Person.PersonID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + "(BusinessClientID, PersonID, Role)");
            sql.Append("VALUES (");

            sql.Append(BusinessClientID + ", ");
            sql.Append(Person.PersonID + ", ");
            sql.AppendLine("'" + Role + "'");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is BusinessClientPerson person &&
                   person.Equals(person.p) &&
                   BusinessClientID == person.BusinessClientID &&
                   Person.Equals(person.Person) &&
                   Role == person.Role;
        }

        public override int GetHashCode()
        {
            int hashCode = 1461023681;
            hashCode = hashCode * -1521134295 + p.GetHashCode();
            hashCode = hashCode * -1521134295 + BusinessClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + Person.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Role);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("Person: [{0}] | BusinessClientID: {1} | Role: {2} ", Person.ToString(), BusinessClientID, Role);
        }
    }
}
