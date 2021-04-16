using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;
using System.Data;

namespace PSS.Business_Logic
{
    static class ClientPhoneSimulationFunctionality
    {
        public static List<Client> GetClientList()
        {
            return DataEngine.GetAllClients();
        }
    }
}
