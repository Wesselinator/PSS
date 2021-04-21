using System.Text;
using System.Data;

//CHECK
namespace PSS.Business_Logic
{
    public class Address : SingleIntID
    {
        public int AddressID { get => ID; private set => ID = value; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }

        private static readonly string tableName = "Address";
        private static readonly string idColumn = "AddressID";

        public Address() : base(tableName, idColumn)
        { }
        public Address(int addressID, string street, string city, string postalCode, string province) : this()
        {
            this.AddressID = addressID;
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        public Address(string street, string city, string postalCode, string province) : this() //no chainning  :(
        {
            this.AddressID = GetNextID();
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.AddressID = row.Field<int>(IDColumn);
            this.Street = row.Field<string>("Street");
            this.City = row.Field<string>("City");
            this.PostalCode = row.Field<string>("PostalCode");
            this.Province = row.Field<string>("Province");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("Street = '" + Street + "', ");
            sql.Append("City = '" + City + "', ");
            sql.Append("PostalCode = '" + PostalCode + "', ");
            sql.AppendLine("Province = '" + Province + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + AddressID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (AddressID, Street, City, PostalCode, Province)");
            sql.Append("VALUES (");

            sql.Append(AddressID + ", ");
            sql.Append("'" + Street + "', ");
            sql.Append("'" + City + "', ");
            sql.Append("'" + PostalCode + "', ");
            sql.Append("'" + Province + "' ");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion


        public string AdressString()
        {
            return string.Format("{0}, {1}, {2}", Street, City, Province);
        }


        public override string ToString()
        {
            return string.Format("AddressID: {0} | Street: {1} | City: {2} | Postal Code: {3} | Province: {4}", AddressID, Street, City, PostalCode, Province);
        }

        public override bool Equals(object obj)
        {
            return obj is Address address &&
                   Street == address.Street &&
                   City == address.City &&
                   PostalCode == address.PostalCode &&
                   Province == address.Province;
        }

        public override int GetHashCode()
        {
            int hashCode = -1008569148;
            hashCode = hashCode * -1521134295 + Street.GetHashCode();
            hashCode = hashCode * -1521134295 + City.GetHashCode();
            hashCode = hashCode * -1521134295 + PostalCode.GetHashCode();
            hashCode = hashCode * -1521134295 + Province.GetHashCode();
            return hashCode;
        }
    }
}
