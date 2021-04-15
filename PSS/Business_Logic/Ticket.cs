using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Business_Logic.DataBaseThings;
using System.Data;

namespace PSS.Business_Logic
{
    public class Ticket : IDataInDataBase
    {
        private int ticketID;
        private Client client;
        private string department;
        private string status;
        private string problemDescription;

        public int TicketID { get => ticketID; set => ticketID = value; }
        public Client Client { get => client; set => client = value; }
        public string Department { get => department; set => department = value; }
        public string Status { get => status; set => status = value; }
        public string ProblemDescription { get => problemDescription; set => problemDescription = value; }

        public Ticket(int ticketID, Client client, string department, string status, string problemDescription)
        {
            this.ticketID = ticketID;
            this.client = client;
            this.department = department;
            this.status = status;
            this.problemDescription = problemDescription;
        }

        public Ticket(IClient client, string department, string status, string problemDescription)
        {
            new Ticket(Ticket.DBTable.GetNextId(), client, department, status, problemDescription);
        }

        public Ticket(string department, string status, string problemDescription)
        {
            new Ticket(new Client(), department, status, problemDescription);
        }

        public Ticket()
        {
            
        }



        public bool Verify(Client client)
        {
            return client.ClientID == this.Client.ClientID;
        }

        public override string ToString()
        {
            String output = "Ticket ID:" + TicketID;
            return output;
        }

        //Database things

        private static string tableName = "Ticket"; //double check
        private static string idColumn = "TicketID"; //double check
        public static TableInDataBase<Ticket> DBTable = new TableInDataBase<Ticket>(tableName, idColumn);

        void IDataInDataBase.FillWith(DataRow DataRow)
        {
            ticketID = DataRow.Field<int>(idColumn);
            client = Client.GetSelect(Client.ClientID);
            department = DataRow.Field<string>("Department");
            status = DataRow.Field<string>("Status");
            problemDescription = DataRow.Field<string>("Description");
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, ticketID);
            ret.Add("ClientID", client.ClientID);
            ret.Add("Department", department);
            ret.Add("Status", status);
            ret.Add("Description", problemDescription);

            return ret;
        }


        //P4 Methods

        public void SetUpdate()
        {
            Ticket.DBTable.Set(this, TicketID); //figure out order
            //client.SetUpdate();
        }

        public static Ticket GetSelect(int ID)
        {
            return Ticket.DBTable.GetByID(ID);
        }
    }
}

