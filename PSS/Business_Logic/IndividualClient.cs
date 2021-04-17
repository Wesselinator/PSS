using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class IndividualClient : Client, IModifyable
    {
        public override int ClientID { get => Person.PersonID; protected set => Person.PersonID = value; }
        public IndividualClient(string businessName, string type, string status, string notes, Address address, Person person) : base(person.PersonID, type, status, notes, address, person)
        {

        }

        public IndividualClient() : base()
        {

        }

        #region DataBase

        private static readonly string TableName = "IndividualClient";
        private static readonly string IDColumn = "IndividualClientID";

        public IndividualClient(DataRow row) : base(row, IDColumn)
        {  }
        
        //P3
        public IndividualClient(int ID)
        : this(DataEngine.GetByID(TableName, IDColumn, ID))
        {  }

        //P4
        public override void Save()
        {
            Address.Save();
            Person.Save(); //I have no Idea what this will do...
            DataEngine.UpdateORInsert(this, TableName, IDColumn, ClientID);
        }

        string IUpdateable.Update()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE "+ TableName);
            sql.Append("SET ");

            return base.Update(sql);
        }
        string IInsertable.Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(ClientID + ", ");
            

            return base.Insert(sql);
        }

        #endregion
    }
}
