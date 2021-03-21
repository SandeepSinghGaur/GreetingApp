using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppManagerLayer
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetAllEmployee();
        int AddEmployee(Employee Emp);
        Employee UpdateEmployee(Employee emp);
        Employee GetEmployeeData(int id);
        int DeleteEmployee(int id);
        bool ValidateEmployee(string password, string email);
    }
}
