using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class Technician : Employee
    {
        private string type, clientName, clientContactNum, requestDescription, clientAddress, notes;
        private bool isBusy;
        private float payRate;

        public int TechnicianID { get => IdNumber; set => IdNumber = value; }
        public string Type { get => type; set => type = value; }
        public bool IsBusy { get => isBusy; set => isBusy = value; }
        public float PayRate { get => payRate; set => payRate = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string ClientContactNum { get => clientContactNum; set => clientContactNum = value; }
        public string RequestDescription { get => requestDescription; set => requestDescription = value; }
        public string ClientAddress { get => clientAddress; set => clientAddress = value; }
        public string Notes { get => notes; set => notes = value; }

        public Technician() : base()
        {
        }

        public Technician(int technicianID, string type, bool isBusy) : base()
        {
            this.TechnicianID = technicianID;
            this.Type = type;
            this.IsBusy = isBusy;
        }

        public Technician(int technicianID, string type, bool isBusy, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(technicianID, firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {
            this.Type = type;
            this.IsBusy = isBusy;
        }


        public bool ServiceClient()
        {
            return true;
        }

        public static Technician getByID()
        {
            return new Technician();
        }

        public Technician(DataRow row)
        {
            this.TechnicianID = row.Field<int>("TechnicianID");
            this.FirstName = row.Field<string>("FirstName");
            this.LastName = row.Field<string>("LastName");
            this.Type = row.Field<string>("Speciality");
            this.payRate = row.Field<float>("PayRate");
        }

        public Technician getWork(int technicianID)
        {
            return DataEngine.GetWorkRequest(technicianID);
        }
    }
}
