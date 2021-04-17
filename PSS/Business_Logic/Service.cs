using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }

        private DataHandler dataHandler; 

        public Service(int serviceID, string serviceName, string serviceDescription)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
        }

        public override bool Equals(object obj)
        {
            return obj is Service service &&
                   ServiceID == service.ServiceID &&
                   ServiceName == service.ServiceName &&
                   ServiceDescription == service.ServiceDescription;
        }

        public override int GetHashCode()
        {
            int hashCode = 723082494;
            hashCode = hashCode * -1521134295 + ServiceID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceDescription);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Service()
        {
           
        }

        public List<Service> GetServices()
        {
            dataHandler = new DataHandler();
            List<Service> services = new List<Service>();
            DataTable dt = dataHandler.getDataTable("SELECT * FROM Service");
            foreach (DataRow service in dt.Rows)
            {
                services.Add(new Service((int)service[0],(string)service[1],(string)service[2]));
            }

            return services;
        }

        public override string ToString()
        {
            return ServiceName;
        }
    }
}
