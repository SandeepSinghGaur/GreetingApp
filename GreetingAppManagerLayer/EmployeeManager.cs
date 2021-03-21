using GreetingAppModelLayer;
using GreetingAppRepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreetingAppManagerLayer
{
    public class EmployeeManager:IEmployeeManager
    {

        private readonly IEmployeeRepo employeeRepo;
        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public int AddEmployee(Employee emp)
        {
            return this.employeeRepo.AddEmployee(emp);
        }

        public int DeleteEmployee(int id)
        {
            return this.employeeRepo.DeleteEmployee(id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.employeeRepo.GetAllEmployee();
        }

        public Employee GetEmployeeData(int id)
        {
            return this.employeeRepo.GetEmployeeData(id);
        }

        public Employee UpdateEmployee(Employee emp)
        {
            return this.employeeRepo.UpdateEmployee(emp);
        }
        public bool ValidateEmployee(string password, string email)
        {
            return this.employeeRepo.ValidateEmployee(password, email);
        }
    }
}
