using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class IndividualClient : Client
    {
        public override int ClientID { get => Person.PersonID; } //remember this is supposed to be odd

        public static readonly string tableName = "IndividualClient";
        public static readonly string idColumn = "IndividualClientID";
        private static readonly string personColumn = idColumn;

        public IndividualClient() : base(tableName, idColumn)
        { }

        public IndividualClient(string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {  }

        //TODO: add a constructor that creates an odd numbered person

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            FillPartialRow(row, personColumn);
        }

        //P4
        public override void Save()
        {
            Address.Save();
            Person.Save(); //what will this do?
            base.Save();
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE "+ TableName);
            sql.Append("SET ");

            return base.UpdatePartial(sql);
        }
        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(ClientID + ", ");
            

            return base.InsertPartial(sql);
        }

        #endregion
    }
}
