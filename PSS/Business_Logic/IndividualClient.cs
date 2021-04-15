using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Business_Logic.DataBaseThings;
using System.Data;

namespace PSS.Business_Logic
{
    class IndividualClient : Client, IDataInDataBase
    {
        public int IndividualID { get => ClientID; set => ClientID = value; }
        public string ClientName { get => Person.FullName; }

        public IndividualClient() : base()
        {

        }



        //database things

        private static string tableName = "IndividualClient"; //double check
        private static string idColumn = "IClientID"; //double check
        public static TableInDataBase<IndividualClient> DBTable = new TableInDataBase<IndividualClient>(tableName, idColumn);

        void IDataInDataBase.FillWith(DataRow DataRow)
        {
            IndividualID = DataRow.Field<int>(idColumn);
            Person = Person.DBTable.GetByID(DataRow.Field<int>("PersonID"));
            RegistrationDate = DataRow.Field<DateTime>("Registration Date"); //double check
            //contracts
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, IndividualID);
            ret.Add("PersonID", Person.IDNumber);
            ret.Add("Registration Date", RegistrationDate);

            return ret;
        }

        //P4 Methods

        public override void SetUpdate()
        {
            IndividualClient.DBTable.Set(this, ClientID);
        }

        public override Client GetSelect(int ID)
        {
            Client c = IndividualClient.DBTable.GetByID(ID);
            return c;
        }
    }
}
