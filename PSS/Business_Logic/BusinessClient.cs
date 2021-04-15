using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Business_Logic.DataBaseThings;
using System.Data;

namespace PSS.Business_Logic
{
    class BusinessClient : Client, IDataInDataBase, IClient
    {
        private string businessName;

        public int BusinessID { get => ClientID; set => ClientID = value; }
        public string BusinessName { get => businessName; set => businessName = value; }
        public string ContactPersonName { get => Person.FirstName; set => Person.FirstName = value; }
        public string ContactPersonSurname { get => Person.LastName; set => Person.LastName = value; }
        public string ContactPersonFullName { get => Person.FullName; }
        
        public BusinessClient(int businessID, DateTime registrationDate, string businessName, Person person) : base(businessID, registrationDate, person)
        {
            BusinessName = businessName;
            ContactPersonName = person.FirstName;
            ContactPersonSurname = person.LastName;
        }

        public BusinessClient(DateTime registrationDate, string businessName, Person person)
        {
            new BusinessClient(BusinessClient.DBTable.GetNextId(), registrationDate, businessName, person);
        }

        public BusinessClient(string businessName, Person person)
        {
            new BusinessClient(DateTime.Now, businessName, person);
        }

        //person constructor passthrough
        public BusinessClient(string businessName, string contactPersoneName, string contactPersonSurname, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : 
        {
            Person p = new Person(contactPersoneName, contactPersonSurname, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province);
            new BusinessClient(businessName, p);
        }

        public BusinessClient() : base()
        {
            //completly empty
        }


        //database things

        private static string tableName = "BusinessClient"; //double check
        private static string idColumn = "BClientID"; //double check
        public static TableInDataBase<BusinessClient> DBTable = new TableInDataBase<BusinessClient>(tableName, idColumn);

        void IDataInDataBase.FillWith(DataRow DataRow)
        {
            BusinessID = DataRow.Field<int>(idColumn);
            Person = Person.DBTable.GetByID(DataRow.Field<int>("PersonID"));
            BusinessName = DataRow.Field<string>("Business Name");
            RegistrationDate = DataRow.Field<DateTime>("Registration Date"); //double check
            //contracts
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, BusinessID);
            ret.Add("PersonID", Person.IDNumber);
            ret.Add("Registration Date", RegistrationDate);
            ret.Add("Business Name", BusinessName);

            return ret;
        }


        //P4 Methods

        public void SetUpdate()
        {
            BusinessClient.DBTable.Set(this, ClientID);
        }

        public BusinessClient GetSelect(int ID)
        {
            return BusinessClient.DBTable.GetByID(ID);
        }
    }
}
