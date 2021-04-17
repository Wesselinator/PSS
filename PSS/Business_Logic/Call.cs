using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class Call : IModifyable
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

        }

        #region Database

        private static readonly string TableName = "Call";
        private static readonly string IDColumn = "CallInstanceID";

        public Call(DataRow row)
        {
            this.callInstanceID = row.Field<int>(IDColumn);
            this.startTime = row.Field<DateTime>("StartTime");
            this.endTime = row.Field<DateTime>("EndTime");
            this.subject = row.Field<string>("Description");
        }

        //P3
        public Call(int ID)
            : this(DataEngine.GetByID(TableName, IDColumn, ID)) 
        { }

        //P4
        public void Save()
        {
            DataEngine.UpdateORInsert(this, TableName, IDColumn, callInstanceID)
        }

        #endregion 


        public override string ToString()
        {
            return "Call started on " + StartTime ;
        }

        public override bool Equals(object obj)
        {
            return obj is Call call &&
                   startTime == call.startTime &&
                   endTime == call.endTime &&
                   callInstanceID == call.callInstanceID &&
                   clientID == call.clientID &&
                   subject == call.subject &&
                   StartTime == call.StartTime &&
                   EndTime == call.EndTime &&
                   CallInstanceID == call.CallInstanceID &&
                   ClientID == call.ClientID &&
                   Subject == call.Subject;
        }

        public override int GetHashCode()
        {
            int hashCode = -13129892;
            hashCode = hashCode * -1521134295 + startTime.GetHashCode();
            hashCode = hashCode * -1521134295 + endTime.GetHashCode();
            hashCode = hashCode * -1521134295 + callInstanceID.GetHashCode();
            hashCode = hashCode * -1521134295 + clientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(subject);
            hashCode = hashCode * -1521134295 + StartTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + CallInstanceID.GetHashCode();
            hashCode = hashCode * -1521134295 + ClientID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Subject);
            return hashCode;
        }
    }
}

