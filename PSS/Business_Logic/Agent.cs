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
        
        public int AgentID { get => IdNumber; set => IdNumber = value; }
        public string Department { get => department; set => department = value; }

        public Agent(int agentID, string department, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(agentID, firstName,lastName,cellphoneNumber,telephoneNumber,email,streetAddress,cityAddress,postalCode,province)
        {
            this.AgentID = agentID;
            this.Department = department;
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
