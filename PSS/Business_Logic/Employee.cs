using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.Business_Logic
{
    class Employee : Person
    {
        public int EmployeeID { get => IdNumber; set => IdNumber = value; }

        public Employee(int employeeID, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province) : base(employeeID, firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province)
        {

        }

        public Employee() : base()
        {

        }
    }
}
