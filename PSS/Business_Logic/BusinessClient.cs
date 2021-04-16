using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class BusinessClient : Client
    {
        public string BusinessName { get; set; }
        public Person Contact { get => Person; set => Person = value; }
        
        public BusinessClient(int businessID, string businessName, string type, string status, string notes, Address address, Person person) : base(businessID, type, status, notes, address, person)
        {
            BusinessName = businessName;
        }
        public BusinessClient() : base()
        {

        }

        public BusinessClient(DataRow row) : base(row, "PrimaryContactPersonID")
        {
            BusinessName = row.Field<string>("BusinessName");            
        }

        //P3
        public static BusinessClient GetID(int ID)
        {
            return new BusinessClient(DataEngine.GetByID("BusinessClient", "BusinessID", ID));
        }

        //P4
        public void Update()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE BusinessClient");
            sql.Append("SET ");

            sql.Append("BusinessName = '" + BusinessName + "',");

            base.Update(sql);
        }
        public void Insert()
        {
            //TODO: this
        }
    }
}
