using System;
using System.Linq;
using System.Text;
using System.Data;

//TODO: If Person gets updated, ID won't. also you shouldn't try and change it.
namespace PSS.Business_Logic
{
    class IndividualClient : Client
    {
        public override int ClientID { get => Person.PersonID; } //needed?

        public MultiIDList<IndividualClientServiceRequest> IndividualClientServiceRequests { get; set; }
        public MultiIDList<IndividualClientContract> IndividualClientContracts { get; set; }
        public MultiIDList<IndividualClientFollowUp> IndividualClientFollowUps { get; set; }

        public override string DisplayMember { get => Person.CellphoneNumber + " | " + Person.FirstName; }

        public static readonly string tableName = "IndividualClient";
        public static readonly string idColumn = "IndividualClientID";
        private static readonly string personColumn = idColumn;

        public IndividualClient() : base(tableName, idColumn)
        {
            IndividualClientServiceRequests = new MultiIDList<IndividualClientServiceRequest>();
            IndividualClientContracts = new MultiIDList<IndividualClientContract>();
            IndividualClientFollowUps = new MultiIDList<IndividualClientFollowUp>();
        }

        public IndividualClient(string type, string status, string notes, Address address, Person person) : base(tableName, idColumn, type, status, notes, address, person)
        {
            ID = Person.PersonID;
            FillLists(person.PersonID);
        }

        public IndividualClient(string type, string status, string notes, Address address) : base(tableName, idColumn, type, status, notes, address)
        {
            ID = Person.PersonID;
            FillLists(ClientID); // this has a value now
        }

        protected override int GetNextID()
        {
            throw new TableIsAComposition(tableName);
        }


        #region DataBase

        protected override void FillLists(int id)
        {
            IndividualClientServiceRequests.FillWithPivotColumn(id, idColumn);
            IndividualClientContracts.FillWithPivotColumn(id, idColumn);
            IndividualClientFollowUps.FillWithPivotColumn(id, idColumn);
        }

        public override void FillFromRow(DataRow row)
        {
            FillPartialRow(row, personColumn);
        }

        public override void Save()
        {
            Address.Save();
            Person.Save(); //what will this do?
            base.Save();
            IndividualClientContracts.SaveAll();
            IndividualClientFollowUps.SaveAll();
            IndividualClientServiceRequests.SaveAll();
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

        #region List Getters/Setters
        //Because of how Lists work and becuase we are in C#7.3 this is sadly the best way to do it     :(

        public override BaseList<ServiceRequest> GetServiceRequests()
        {
            return IndividualClientServiceRequests.GetServiceRequests();
        }
        public override void AddServiceRequest(ServiceRequest serviceRequest)
        {
            IndividualClientServiceRequests.Add(new IndividualClientServiceRequest(ID, serviceRequest));
        }


        public override BaseList<Contract> GetContracts()
        {
            return IndividualClientContracts.GetContracts();
        }

        public override void AddContract(Contract contract, DateTime effectiveDate)
        {
            IndividualClientContracts.Add(new IndividualClientContract(ID, contract, effectiveDate));
        }
        public override Contract GetCurrentContract()
        {
            return IndividualClientContracts.Where(icc => icc.IsCurrent).Select(icc => icc.Contract).FirstOrDefault();
        }

        public override BaseList<FollowUpReport> GetFolowups()
        {
            return IndividualClientFollowUps.GetFollowUps();
        }

        public override void AddFolowup(FollowUpReport followUp)
        {
            IndividualClientFollowUps.Add(new IndividualClientFollowUp(ID, followUp));
        }


        #endregion

        public override bool Equals(object obj)
        {
            return obj is IndividualClient client &&
                   base.Equals(obj); //&&
                   //IndividualClientServiceRequests.Equals(client.IndividualClientServiceRequests) &&
                   //IndividualClientContracts.Equals(client.IndividualClientContracts) &&
                   //IndividualClientFollowUps.Equals(client.IndividualClientFollowUps);
        }

        public override int GetHashCode()
        {
            int hashCode = 335634478;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            //hashCode = hashCode * -1521134295 + IndividualClientServiceRequests.GetHashCode();
            //hashCode = hashCode * -1521134295 + IndividualClientContracts.GetHashCode();
            //hashCode = hashCode * -1521134295 + IndividualClientFollowUps.GetHashCode();
            return hashCode;
        }


    }
}
