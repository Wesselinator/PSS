﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    //not sure how the database distinguses between them so wont try right now
    class Technician : Employee
    {
        private string type;
        private bool isBusy;
        private int technicianID;

        public int TechnicianID { get => technicianID; set => technicianID = value; }
        public string Type { get => type; set => type = value; }
        public bool IsBusy { get => isBusy; set => isBusy = value; }


        public Technician(int technicianID, string type, bool isBusy)
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

        public Technician()
        {

        }


        public bool ServiceClient()
        {
            return true;
        }
    }
}
