using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Employee
    {
        private int employeeID;

        public int EmployeeID { get => employeeID; set => employeeID = value; }

        public Employee(int employeeID)
        {
            this.employeeID = employeeID;
        }

        public Employee()
        {

        }
    }
}
