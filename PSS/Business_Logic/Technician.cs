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
        private string type, clientName, clientContactNum, requestDescription, clientStreetAddress, clientCity, notes;
        private bool isBusy;
        private float payRate;

        public int TechnicianID { get => PersonID; set => PersonID = value; }
        public string Type { get => type; set => type = value; }
        public bool IsBusy { get => isBusy; set => isBusy = value; }
        public float PayRate { get => payRate; set => payRate = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string ClientContactNum { get => clientContactNum; set => clientContactNum = value; }
        public string RequestDescription { get => requestDescription; set => requestDescription = value; }
        public string ClientStreetAddress { get => clientStreetAddress; set => clientStreetAddress = value; }
        public string Notes { get => notes; set => notes = value; }
        public string ClientCity { get => clientCity; set => clientCity = value; }

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

        public override bool Equals(object obj)
        {
            return obj is Technician technician &&
                   base.Equals(obj) &&
                   PersonID == technician.PersonID &&
                   FirstName == technician.FirstName &&
                   LastName == technician.LastName &&
                   FullName == technician.FullName &&
                   CellphoneNumber == technician.CellphoneNumber &&
                   TellephoneNumber == technician.TellephoneNumber &&
                   Email == technician.Email &&
                   EmployeeID == technician.EmployeeID &&
                   type == technician.type &&
                   isBusy == technician.isBusy &&
                   TechnicianID == technician.TechnicianID &&
                   Type == technician.Type &&
                   IsBusy == technician.IsBusy;
        }

        public override int GetHashCode()
        {
            int hashCode = 1042436649;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PersonID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CellphoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TellephoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EmployeeID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(type);
            hashCode = hashCode * -1521134295 + isBusy.GetHashCode();
            hashCode = hashCode * -1521134295 + TechnicianID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + IsBusy.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
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

        //Constructor for technician form object
        public Technician(int technicianID, string clientName, string clientContactNum, string requestDescription, string clientStreetAddress, string notes, string clientCity)
        {
            TechnicianID = technicianID;
            ClientName = clientName;
            ClientContactNum = clientContactNum;
            RequestDescription = requestDescription;
            ClientStreetAddress = clientStreetAddress;
            Notes = notes;
            ClientCity = clientCity;
        }

        public Technician getWork(int technicianID)
        {
            return DataEngine.GetWorkRequest(technicianID);
        }
    }
}
