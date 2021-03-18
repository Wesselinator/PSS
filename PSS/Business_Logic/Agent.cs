using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Agent : Employee
    {
        private string department; 
        
        public string Department { get => department; set => department = value; }

        public Agent()
        {
        }

        public Agent(string department)
        {
            Department = department;
        }

        public void AnswerCall()
        {

        }

        public void RegisterClient()
        {

        }

        public bool AddClientContract(Client newClient)
        {
            return true;
        }
    }
}
