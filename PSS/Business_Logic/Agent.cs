using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    class Agent : Employee
    {
        private int agentID;
        private string department; 
        
        public int AgentID { get => agentID; set => agentID = value; }
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

        public void RegisterClient(Client client)
        {
            String query = @"INSERT INTO ";
            Data_Access.DataHandler handler = new DataHandler();
            handler.Insert(query);
        }

        public bool AddClientContract(Client newClient)
        {
            return true;
        }
    }
}
