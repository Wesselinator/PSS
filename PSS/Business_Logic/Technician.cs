using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Technician : Employee
    {
        private string type;
        private bool isBusy;

        public int TechnicianID { get => IdNumber; set => IdNumber = value; }
        public string Type { get => type; set => type = value; }
        public bool IsBusy { get => isBusy; set => isBusy = value; }

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
                   IdNumber == technician.IdNumber &&
                   FirstName == technician.FirstName &&
                   LastName == technician.LastName &&
                   FullName == technician.FullName &&
                   CellphoneNumber == technician.CellphoneNumber &&
                   TelephoneNumber == technician.TelephoneNumber &&
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
            hashCode = hashCode * -1521134295 + IdNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CellphoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TelephoneNumber);
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
    }
}
