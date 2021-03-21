using GreetingAppModelLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GreetingAppRepositoryLayer
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IConfiguration configuration;
        public string connectionString;
        private object emp;

        public EmployeeRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("DbConnection");
        }


        //To View all Customers details 
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lstCustomer = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Employee Emp = new Employee();

                    Emp.ID = Convert.ToInt32(sdr["CustomerId"]);
                    Emp.FirstName = sdr["FirstName"].ToString();
                    Emp.LastName = sdr["LastName"].ToString();
                    Emp.Mobile = sdr["MobileNo"].ToString();
                    Emp.Password = sdr["Password"].ToString();
                    Emp.Email = sdr["MailId"].ToString();
                    lstCustomer.Add(Emp);
                }

                con.Close();

            }
            return lstCustomer;
            
        }
        //To Add new Customer record      
        public int AddEmployee(Employee Emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", Emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Emp.LastName);
                cmd.Parameters.AddWithValue("@MobileNo", Emp.Mobile);
                cmd.Parameters.AddWithValue("@Password", Emp.Password);
                cmd.Parameters.AddWithValue("@MailId", Emp.Email);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }

        //To Update the records of a particluar Customer    
        public Employee UpdateEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", emp.ID);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@MobileNo", emp.Mobile);
                cmd.Parameters.AddWithValue("@Password", emp.Password);
                cmd.Parameters.AddWithValue("@MailId", emp.Email);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result != 0)
                    return emp;
                return null;
            }
        }

        //Get the details of a particular Customer    
        public Employee GetEmployeeData(int id)
        {
            Employee emp = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("sp_GetEmployeeByID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    emp.ID = Convert.ToInt32(sdr["CustomerId"]);
                    emp.FirstName = sdr["FirstName"].ToString();
                    emp.LastName = sdr["LastName"].ToString();
                    emp.Password = sdr["Password"].ToString();
                    emp.Mobile = sdr["MobileNo"].ToString();
                    emp.Email = sdr["MailId"].ToString();
                }
            }
            return emp;
        }
        //To Delete the record on a particular Customer    
        public int DeleteEmployee(int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
        //Validate the perticular Employee By Using Email and PassWord
        public bool ValidateEmployee(string password,string email)
        {
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("sp_VerifiedEmployeeByEmailAndPassword3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("MailId", email );
                cmd.Parameters.AddWithValue("@Password", password);
                con.Open();
                int codereturn = (int)cmd.ExecuteScalar();
                return codereturn == 1;

            }
        }
    }
}


