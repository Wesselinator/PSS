using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    public class Ticket
    {
        private int ticketID;
        private int clientID;
        private string department;
        private string status;
        private string problemDescription;

        public int ClientID { get => clientID; set => clientID = value; }
        public string Department { get => department; set => department = value; }
        public string Status { get => status; set => status = value; }
        public string ProblemDescription { get => problemDescription; set => problemDescription = value; }
        public int TicketID { get => ticketID; set => ticketID = value; }

        public Ticket()
        {

        }

        public Ticket(int ticketID, int clientID, string department, string status, string problemDescription)
        {
            this.ticketID = ticketID;
            this.clientID = clientID;
            this.department = department;
            this.status = status;
            this.problemDescription = problemDescription;
        }

        public override string ToString()
        {
            String output = "Ticket ID:" + TicketID;
            return output;
        }
    }
}

