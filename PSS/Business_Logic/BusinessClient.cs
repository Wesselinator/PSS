using System;
using System.Text;
using System.Data;
using System.Linq;
using PSS.Data_Access;
using System.Collections.Generic;

//CHECK
namespace PSS.Business_Logic
{
    public class BusinessClient : Client
    {
        public override int ClientID { get; protected set; }
        public string BusinessName { get; set; }
        public Person ContactPerson { get => Person; set => Person = value; }
        private MultiIDList<BusinessClientPerson> BusinessClientPeople { get; set; } //TODO: These extentions

        private MultiIDList<BusinessClientServiceRequest> BusinessClientServiceRequests { get; set; }
        private MultiIDList<BusinessClientContract> BusinessClientContracts { get; set; }
        private MultiIDList<BusinessClientFollowUp> BusinessClientFollowUps { get; set; }

        public static readonly string tableName = "BusinessClient";
        public static readonly string idColumn = "BusinessClientID";
        private static readonly string personColumn = "PrimaryContactPersonID";

        public BusinessClient() : base(tableName, idColumn)
        {
            BusinessClientPeople = new MultiIDList<BusinessClientPerson>();
            BusinessClientServiceRequests = new MultiIDList<BusinessClientServiceRequest>();
            BusinessClientContracts = new MultiIDList<BusinessClientContract>();
            BusinessClientFollowUps = new MultiIDList<BusinessClientFollowUp>();
        }

        public BusinessClient(int businessID, string businessName, string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            ClientID = businessID;
            BusinessName = businessName;

            FillLists(businessID);
        }

        public BusinessClient(string businessName, string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            ClientID = GetNextID();
            BusinessName = businessName;
        }

        #region DataBase

        protected override void FillLists(int id)
        {
            BusinessClientPeople.FillWithPivotColumn(id, idColumn);
            BusinessClientServiceRequests.FillWithPivotColumn(id, idColumn);
            BusinessClientContracts.FillWithPivotColumn(id, idColumn);
            BusinessClientFollowUps.FillWithPivotColumn(id, idColumn);
        }

        public override void FillFromRow(DataRow row)
        {
            ClientID = row.Field<int>(idColumn);
            BusinessName = row.Field<string>("BusinessName");
            FillPartialRow(row, personColumn);
            FillLists(ClientID);
        }

        public override void Save()
        {
            Address.Save();
            BusinessClientPeople.SaveAll();
            Person.Save();
            base.Save();
            BusinessClientServiceRequests.SaveAll(); //Create Businsess client first before services
            BusinessClientContracts.SaveAll();
            BusinessClientFollowUps.SaveAll();
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
            sql.AppendLine("INSERT INTO " + TableName + "(BusinessClientID, BusinessName, Type, Status, Notes, PrimaryContactPersonID, AddressID)");
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

        #region List Getters/Setters
        //Because of how Lists work and becuase we are in C#7.3 this is sadly the best way to do it     :(

        public BaseList<ServiceRequest> GetServiceRequests()
        {
            return BusinessClientServiceRequests.GetServiceRequests();
        }

        public void AddServiceRequest(ServiceRequest serviceRequest)
        {
            BusinessClientServiceRequests.Add(new BusinessClientServiceRequest(ID, serviceRequest));
        }

        public BaseList<Contract> GetContracts()
        {
            return BusinessClientContracts.GetContracts();
        }

        public void AddContract(Contract contract, DateTime effectiveDate)
        {
            BusinessClientContracts.Add(new BusinessClientContract(ID, contract, effectiveDate));
        }

        public BaseList<FollowUp> GetFolowups()
        {
            return BusinessClientFollowUps.GetFollowUps();
        }

        public void AddFolowup(FollowUp followUp)
        {
            BusinessClientFollowUps.Add(new BusinessClientFollowUp(ID, followUp));
        }

        #endregion

        public override string ToString()
        {
            return string.Format("ClientID: {0} | BusinessName: {1} | ContactPerson: [{2}] | BusinessClientPeople: [{3}] | " +
                "ServiceRequest: [{4}] | Contracts: [{5}] | FollowUps: [{6}]", 
                ClientID, BusinessName, ContactPerson, BusinessClientPeople, BusinessClientServiceRequests, BusinessClientContracts, BusinessClientFollowUps);
        }
    }
}
