using Dapper;
using EmployeeManagementPOC.DapperServices;
using EmployeeManagementPOC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPOC.Repository
{
    public class EmployeeRepo :IEmployeeRepo
    {
        private readonly DapperContext _context;
        public EmployeeRepo(DapperContext context)
        {
            _context = context;
        }

        //Get list
        public async Task<List<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }

        //read by Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            var query = "SELECT * FROM Employee where EmployeeId=@Id";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { id });
                return employee;
            }
        }

        //Add new Employee
        public async Task AddEmployee(Employee employee)
        {
            var query = "Insert into Employee(DepartmentId,FirstName,LastName,Email,PhoneNumber,Salary,ProfilePicture) values(@DepartmentId,@FirstName,@LastName,@Email,@PhoneNumber,@Salary,@ProfilePicture)";
            var parameter = new DynamicParameters();
            parameter.Add("DepartmentId", employee.DeparrtmentId, DbType.Int32);
            parameter.Add("FirstName", employee.FirstName, DbType.String);
            parameter.Add("LastName", employee.LastName, DbType.String);
            parameter.Add("Email", employee.Email, DbType.String);
            parameter.Add("PhoneNumber", employee.PhoneNumber, DbType.String);
            parameter.Add("Salary", employee.Salary, DbType.String);
            parameter.Add("ProfilePicture", employee.ProfilePicture, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }
    }
}
