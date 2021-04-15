using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PSS.Business_Logic.DataBaseThings;

namespace PSS.Business_Logic
{
    class Call
    {
        private DateTime startTime;
        private DateTime endTime;
        private int callInstanceID;
        private int clientID;
        private string subject;

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int CallInstanceID { get => callInstanceID; set => callInstanceID = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        public string Subject { get => subject; set => subject = value; }

        public Call()
        {

        }

        public Call(DateTime startTime, DateTime endTime, int callInstanceID, int clientID, string subject)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.callInstanceID = callInstanceID;
            this.clientID = clientID;
            this.subject = subject;
        }

        public override string ToString()
        {
            return "Call started on " + StartTime ;
        }

        //TODO: upgrade TableDataBase to handle 2 IDs
    }
}

