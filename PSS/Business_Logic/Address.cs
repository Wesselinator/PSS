using System.Collections.Generic;
using System.Text;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }

        public Address(int addressID, string street, string city, string postalCode, string province)
        {
            this.AddressID = addressID;
            this.Street = street;
            this.City = city;
            this.PostalCode = postalCode;
            this.Province = province;
        }

        public Address(string street, string city, string postalCode, string province)
        {
            new Address(DataEngine.GetNextID("Address", "AddressID"), street, city, postalCode, province);
        }

        public Address()
        {

        }

        public Address(DataRow row)
        {
            this.Street = row.Field<string>("Street");
            this.City = row.Field<string>("City");
            this.PostalCode = row.Field<string>("PostalCode");
            this.Province = row.Field<string>("Province");
        }

        //P3
        public static Address GetID(int ID)
        {
            return new Address(DataEngine.GetByID("Address", "AddressID", ID));
        }

        //P4
        public void Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE Address");

            sql.Append("SET ");
            sql.Append("Street = '"+ Street +"',");
            sql.Append("City = '" + City + "',");
            sql.Append("PostalCode = '" + PostalCode + "',");
            sql.AppendLine("Province = '" + Province + "'");

            sql.AppendLine("WHERE AddressID = " + AddressID);

            DataHandler dh = new DataHandler();
            dh.Update(sql.ToString());
        }

        //order very important
        public void Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO Address");

            sql.Append("VALUES (");
            sql.Append("'" + AddressID + "',");
            sql.Append("'" + Street + "',");
            sql.Append("'" + City + "',");
            sql.Append("'" + PostalCode + "',");
            sql.Append("'" + Province + "'");
            sql.AppendLine(");");

            DataHandler dh = new DataHandler();
            dh.Update(sql.ToString());
        }

        public override string ToString()
        {
            return string.Format("AddressID: {0} | Street: {1} | City: {2} | Postal Code: {3} | Province: {4}", AddressID, Street, City, PostalCode, Province);
        }

        public string ToFormattedString()
        {
            return string.Format("{0}, {1}, {2} | {3}", Street, City, Province, PostalCode);
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
