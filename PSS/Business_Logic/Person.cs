using PSS.Business_Logic.DataBaseThings;
using System;
using System.Data;

namespace PSS.Business_Logic
{
    public class Person : IDataInDataBase
    {
        private string firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province;
        private int idNumber;

        public int IDNumber { get => idNumber; set => idNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FullName { get => string.Format("{0} {1}", FirstName, LastName); }
        public string CellphoneNumber { get => cellphoneNumber; set => cellphoneNumber = value; }
        public string TellephoneNumber { get => telephoneNumber; set => telephoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string StreetAddress { get => streetAddress; set => streetAddress = value; }
        public string CityAddress { get => cityAddress; set => cityAddress = value; }
        public string Province { get => province; set => province = value; }
        public string FullAddress { get => string.Format("{0} {1} {2}", StreetAddress, CityAddress, Province); }
        public string PostalCode { get => postalCode; set => postalCode = value; }

        public Person(int idNumber, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province)
        {
            this.IDNumber = idNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CellphoneNumber = cellphoneNumber;
            this.TellephoneNumber = telephoneNumber;
            this.Email = email;
            this.StreetAddress = streetAddress;
            this.CityAddress = cityAddress;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        public Person(string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province)
        {
            // generate random ID Number
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CellphoneNumber = cellphoneNumber;
            this.TellephoneNumber = telephoneNumber;
            this.Email = email;
            this.StreetAddress = streetAddress;
            this.CityAddress = cityAddress;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        public Person()
        {
            
        }

        //Database things

        private static string tableName = "Person"; //double check
        private static string idColumn = "IDNumber"; //double check

        //TODO: Potentially change the way DBTable varible is created
        public static TableInDataBase<Person> DBTable = new TableInDataBase<Person>(tableName, idColumn); //cant make this an Interface Requirement sadly   :(

        //TODO: Definitly create static strings for all these columns\
        //TODO: Double Check these fields
        void IDataInDataBase.FillWith(DataRow DataRow) 
        {   
            idNumber        = DataRow.Field<int>(idColumn);
            firstName       = DataRow.Field<string>("First Name");
            lastName        = DataRow.Field<string>("Last Name");
            cellphoneNumber = DataRow.Field<string>("Cellphone Number");
            telephoneNumber = DataRow.Field<string>("Tellephone Number");
            email           = DataRow.Field<string>("Email");
            streetAddress   = DataRow.Field<string>("Street Address");
            cityAddress     = DataRow.Field<string>("City Address");
            province        = DataRow.Field<string>("Province");
            postalCode      = DataRow.Field<string>("Postal Code");
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, IDNumber);
            ret.Add("First Name", FirstName);
            ret.Add("Last Name", LastName);
            ret.Add("Cellphone Number", CellphoneNumber);
            ret.Add("Tellephone Number", TellephoneNumber);
            ret.Add("Email", Email);
            ret.Add("Street Address", StreetAddress);
            ret.Add("City Address", CityAddress);
            ret.Add("Province", Province);
            ret.Add("Postal Code", PostalCode);

            return ret;
        }


        //P4 Methods

        public void SetUpdate()
        {
            Person.DBTable.Set(this, idNumber);
        }

        public static Person GetSelect(int ID)
        {
            return Person.DBTable.GetByID(ID);
        }
    }
}
