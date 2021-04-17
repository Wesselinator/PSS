using System.Collections.Generic;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Address : IModifyable
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }

        private static readonly string TableName = "Address";
        private static readonly string IDColumn = "AddressID";

        public Address()// : base(TableName, IDColumn)
        { }
        public Address(int addressID, string street, string city, string postalCode, string province) : this()
        {
            this.AddressID = addressID;
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Province = province;
        }
        public Address(string street, string city, string postalCode, string province)
                : this(DataEngine.GetNextID(TableName, IDColumn), street, city, postalCode, province)
        { }

        #region DataBase

        public Address(DataRow row) : this()
        {
            this.AddressID = row.Field<int>(IDColumn);
            this.Street = row.Field<string>("Street");
            this.City = row.Field<string>("City");
            this.PostalCode = row.Field<string>("PostalCode");
            this.Province = row.Field<string>("Province");
        }

        //P3
        public Address(int ID)
                : this(DataEngine.GetByID(TableName, IDColumn, ID))
        { }

        //P4
        public void Save()
        {
            DataEngine.UpdateORInsert(this, TableName, IDColumn, AddressID);
        }

        string IUpdateable.Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);

            sql.Append("SET ");
            sql.Append("Street = '"+ Street +"', ");
            sql.Append("City = '" + City + "', ");
            sql.Append("PostalCode = '" + PostalCode + "', ");
            sql.AppendLine("Province = '" + Province + "'");

            sql.AppendLine("WHERE " + IDColumn + " = " + AddressID);

            return sql.ToString();
        }

        string IInsertable.Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName);

            sql.Append("VALUES (");
            sql.Append(AddressID +", ");
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Province);
            return hashCode;
        }
    }
}
