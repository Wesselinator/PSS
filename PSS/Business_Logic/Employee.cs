using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PSS.Business_Logic.DataBaseThings;

namespace PSS.Business_Logic
{
    class Employee : IDataInDataBase
    {
        private int employeeID;
        private Person person;

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public Person Person { get => person; set => person = value; }

        /// <summary>
        /// Person constructor passthrough
        /// </summary>
        public Employee(int employeeID, string firstName, string lastName, string cellphoneNumber, string telephoneNumber, string email, string streetAddress, string cityAddress, string postalCode, string province)
        {
            Person p = new Person(firstName, lastName, cellphoneNumber, telephoneNumber, email, streetAddress, cityAddress, postalCode, province);
            new Employee(employeeID, p);
        }

        public Employee(int employeeID, Person person)
        {
            new Employee(employeeID, person);
        }

        public Employee(Person person)
        {
            new Employee(Employee.DBTable.GetNextId(), person);
        }

        public Employee()
        {
            
        }

        //Database things

        private static string tableName = "Employee"; //double check
        private static string idColumn = "EmployeeID"; //double check
        public static TableInDataBase<Employee> DBTable = new TableInDataBase<Employee>(tableName, idColumn);

        void IDataInDataBase.FillWith(DataRow DataRow)
        {
            employeeID = DataRow.Field<int>("EmployeeID");
            person = Person.DBTable.GetByID(Person.IDNumber);
        }

        SQLParameterList IDataInDataBase.Extract()
        {
            SQLParameterList ret = new SQLParameterList();

            ret.Add(idColumn, employeeID);
            ret.Add("PersonID", Person.IDNumber);

            return ret;
        }


        //P4 Methods

        public void SetUpdate()
        {
            Employee.DBTable.Set(this, employeeID);
            Person.DBTable.Set(Person, person.IDNumber); //figure out the order of this
        }

        public static Employee GetSelect(int ID)
        {
            return Employee.DBTable.GetByID(ID);
        }
    }
}
