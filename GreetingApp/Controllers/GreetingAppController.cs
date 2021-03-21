using GreetingAppManagerLayer;
using GreetingAppModelLayer;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GreetingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingAppController : ControllerBase
    {
        private readonly IEmployeeManager employeeManager;
       
        public GreetingAppController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        
        [HttpPost]
        [Route("Register")]
        public ActionResult AddEmployee(Employee employee) 
        {
            try
            {
                var result = this.employeeManager.AddEmployee(employee);
                if (result != 0)
                {
                    return this.Ok(new { Status = true,Message="Employee Added Successfully",Data=result });
                }
                return this.BadRequest(new { Status = false, Message = "Employee Added UnSuccessfully" });

            }
            catch(Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message});

            }
        }
        [HttpDelete]
        [Route("DeleteEmployee/{empID}")]
        public ActionResult DeleteEmployee(int empID)
        {
            try
            {
                var result = this.employeeManager.DeleteEmployee(empID);
                if (result != 0)
                {
                    return this.Ok(new { Status = true, Message = "Employee Deleted Successfully", Data = empID });
                }
                return this.NotFound(new { Status = false, Message = "Employee Delete UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }

        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public ActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var result = this.employeeManager.UpdateEmployee(employee);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Updated Successfully", Data = result });
                }
                return this.NotFound(new { Status = false, Message = "Employee Updated UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public ActionResult GetAllEmployee()
        {
            try
            {
                var result = this.employeeManager.GetAllEmployee();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Get Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Employee Get UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });

            }
        }
        [HttpGet]
        [Route("GetEmployee/{empID}")]
        public ActionResult GetEmployeeByID(int empID)
        {
            try
            {
                var result = this.employeeManager.GetEmployeeData(empID);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Get Successfully", Data = result });
                }
                return this.NotFound(new { Status = false, Message = "Employee Get UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }
        [HttpPost]
        [Route("ValidateEmployee")]
        public ActionResult ValidateEmployee(EmployeeLogin login)
        {
            try
            {
                var result = this.employeeManager.ValidateEmployee(login.Password,  login.Email);
                if (result)
                {
                    return this.Ok(new { Status = true, Message = "Employee Varified Successfully", Data = login });
                }
                return this.BadRequest(new { Status = false, Message = "Employee Verified UnSuccessfully" });

            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });

            }
        }
    }
}
