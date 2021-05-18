using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace PSS.Business_Logic
{
    public class BusinessClient : Client
    {
        public string BusinessName { get; set; }
        public Person ContactPerson { get => Person; set => Person = value; }
        private MultiIDList<BusinessClientPerson> BusinessClientPeople { get; set; }

        private MultiIDList<BusinessClientServiceRequest> BusinessClientServiceRequests { get; set; }
        private MultiIDList<BusinessClientContract> BusinessClientContracts { get; set; }
        private MultiIDList<BusinessClientFollowUp> BusinessClientFollowUps { get; set; }

        public override string DisplayMember { get => Person.CellphoneNumber + " | " + BusinessName; }

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
            sql.Append(ContactPerson.PersonID + ", ");
            sql.Append(Address.AddressID);

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        #region List Getters/Setters
        //Because of how Lists work and becuase we are in C#7.3 this is sadly the best way to do it     :(

        public override BaseList<ServiceRequest> GetServiceRequests()
        {
            return BusinessClientServiceRequests.GetServiceRequests();
        }
        public override void AddServiceRequest(ServiceRequest serviceRequest)
        {
            BusinessClientServiceRequests.Add(new BusinessClientServiceRequest(ID, serviceRequest));
        }

        public override BaseList<Contract> GetContracts()
        {
            return BusinessClientContracts.GetContracts();
        }
        public override void AddContract(Contract contract, DateTime effectiveDate)
        {
            BusinessClientContracts.Add(new BusinessClientContract(ID, contract, effectiveDate));
        }
        public override Contract GetCurrentContract()
        {
            return BusinessClientContracts.Where(bcc => bcc.IsCurrent).Select(bcc => bcc.Contract).FirstOrDefault();
        }

        public override BaseList<FollowUpReport> GetFolowups()
        {
            return BusinessClientFollowUps.GetFollowUps();
        }
        public override void AddFolowup(FollowUpReport followUp)
        {
            BusinessClientFollowUps.Add(new BusinessClientFollowUp(ID, followUp));
        }

        public BaseList<Person> GetBusinessPersons()
        {
            return BusinessClientPeople.GetBusinessClientPeople();
        }
        public void AddBusinessPersons(Person person, string role)
        {
            BusinessClientPeople.Add(new BusinessClientPerson(ID, person, role));
        }

        //public void SetBusinessPeople(Bus)

        #endregion

        public override string ToString()
        {
            return string.Format("ClientID: {0} | BusinessName: {1} | ContactPerson: [{2}] | BusinessClientPeople: [{3}] | " +
                "ServiceRequest: [{4}] | Contracts: [{5}] | FollowUps: [{6}]", 
                ClientID, BusinessName, ContactPerson, BusinessClientPeople, BusinessClientServiceRequests, BusinessClientContracts, BusinessClientFollowUps);
        }

        public override bool Equals(object obj)
        {
            return obj is BusinessClient client &&
                   base.Equals(obj) &&
                   BusinessName == client.BusinessName &&
                   ContactPerson.Equals(client.ContactPerson); //&&
                   //BusinessClientPeople.Equals(client.BusinessClientPeople) &&
                   //BusinessClientServiceRequests.Equals(client.BusinessClientServiceRequests) &&
                   //BusinessClientContracts.Equals(client.BusinessClientContracts) &&
                   //BusinessClientFollowUps.Equals(client.BusinessClientFollowUps);
        }

        public override int GetHashCode()
        {
            int hashCode = 55132484;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(BusinessName);
            hashCode = hashCode * -1521134295 + ContactPerson.GetHashCode();
            //hashCode = hashCode * -1521134295 + BusinessClientPeople.GetHashCode();
            //hashCode = hashCode * -1521134295 + BusinessClientServiceRequests.GetHashCode();
            //hashCode = hashCode * -1521134295 + BusinessClientContracts.GetHashCode();
            //hashCode = hashCode * -1521134295 + BusinessClientFollowUps.GetHashCode();
            return hashCode;
        }
    }
}
