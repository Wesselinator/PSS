using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        public Service(int serviceID, string serviceName, string serviceDescription)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
        }
    }
}
