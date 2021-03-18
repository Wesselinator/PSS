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

        public string Type { get => type; set => type = value; }
        public bool IsBusy { get => isBusy; set => isBusy = value; }

        public Technician()
        {
        }

        public Technician(string type, bool isBusy)
        {
            Type = type;
            IsBusy = isBusy;
        }


        public bool ServiceClient()
        {
            return true;
        }
    }
}
