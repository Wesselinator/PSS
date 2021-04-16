using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class IndividualClient : Client
    {
        public override int ClientID { get => Person.IdNumber; set => Person.IdNumber = value; }
        public IndividualClient(string businessName, string type, string status, string notes, Address address, Person person) : base(person.IdNumber, type, status, notes, address, person)
        {

        }

        public IndividualClient() : base()
        {

        }

        public IndividualClient(DataRow row) : base(row, "IndividualClient")
        {
            
        }

        //IMPOERTANT: This does not cascade to the People Table!
        public void Update()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE IndividualClient");
            sql.Append("SET ");

            base.Update(sql);
        }
        public void Insert()
        {
            //TODO: this
        }
    }
}
