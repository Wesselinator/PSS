using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Task
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

        public Task()
        {

        }

        public Task(int ticketID, int clientID, string department, string status, string problemDescription)
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

        public override bool Equals(object obj)
        {
            return obj is Task ticket &&
                   ticketID == ticket.ticketID &&
                   clientID == ticket.clientID &&
                   department == ticket.department &&
                   status == ticket.status &&
                   problemDescription == ticket.problemDescription &&
                   ClientID == ticket.ClientID &&
                   Department == ticket.Department &&
                   Status == ticket.Status &&
                   ProblemDescription == ticket.ProblemDescription &&
                   TicketID == ticket.TicketID;
        }

        public override int GetHashCode()
        {
            int hashCode = 1703972206;
            hashCode = hashCode * -1521134295 + ticketID.GetHashCode();
            hashCode = hashCode * -1521134295 + clientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(department);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(status);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(problemDescription);
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Department);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProblemDescription);
            hashCode = hashCode * -1521134295 + TicketID.GetHashCode();
            return hashCode;
        }
    }
}

