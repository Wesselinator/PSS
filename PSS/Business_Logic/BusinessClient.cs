using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class BusinessClient : Client
    {
        private string businessName;
        private string contactPersoneName;
        private string contactPersonSurname;

        public string BusinessName { get => businessName; set => businessName = value; }
        public string ContactPersoneName { get => contactPersoneName; set => contactPersoneName = value; }
        public string ContactPersonSurname { get => contactPersonSurname; set => contactPersonSurname = value; }
        
        public BusinessClient(string businessName, string contactPersoneName, string contactPersonSurname)
        {
            BusinessName = businessName;
            ContactPersoneName = contactPersoneName;
            ContactPersonSurname = contactPersonSurname;
        }

        public BusinessClient()
        {
        }
    }
}
