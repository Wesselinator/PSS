using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

//CHECK // equals and hashcode and toStringOverride needed
namespace PSS.Business_Logic
{
    class IndividualClient : Client
    {
        public override int ClientID { get => Person.PersonID; } //needed?

        public MultiIDList<IndividualClientServiceRequest> ServiceRequests { get; set; }
        public MultiIDList<IndividualClientContract> Contracts { get; set; }
        public MultiIDList<IndividualClientFollowUp> FollowUps { get; set; }

        public static readonly string tableName = "IndividualClient";
        public static readonly string idColumn = "IndividualClientID";
        private static readonly string personColumn = idColumn;

        public IndividualClient() : base(tableName, idColumn)
        {
            ServiceRequests = new MultiIDList<IndividualClientServiceRequest>();
            Contracts = new MultiIDList<IndividualClientContract>();
            FollowUps = new MultiIDList<IndividualClientFollowUp>();
        }

        public IndividualClient(string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            FillLists(person.PersonID);
        }

        public IndividualClient(string type, string status, string notes, Address address) : base(tableName, idColumn, type, status, notes, address)
        {
            FillLists(ClientID); // this has a value now
        }


        #region DataBase

        private void FillLists(int id) //TODO: move to virtual above Client.cs
        { 
            ServiceRequests.FillWithPivotColumn(id, idColumn);
            Contracts.FillWithPivotColumn(id, idColumn);
            FollowUps.FillWithPivotColumn(id, idColumn);
        }

        public override void FillFromRow(DataRow row)
        {
            FillPartialRow(row, personColumn);
            FillLists(ClientID); //TODO: call in Client.cs
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
            sql.AppendLine("INSERT INTO " + TableName + " (IndividualClientID, Type, Status, Notes, AddressID)");

            sql.Append("VALUES (");
            sql.Append(ClientID + ", ");
            

            return base.InsertPartial(sql);
        }

        #endregion


    }
}
