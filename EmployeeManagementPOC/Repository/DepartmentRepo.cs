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
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DapperContext _context;
        public DepartmentRepo(DapperContext context)
        {
            _context = context;
        }

        #region Department

        public async Task<List<Department>> GetDepartments()
        {
            var query = "SELECT * FROM Department";
            using (var connection = _context.CreateConnection())
            {
                var departments = await connection.QueryAsync<Department>(query);
                return departments.ToList();
            }
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var query = "SELECT * FROM Department where DepartmentId=@Id";
            using (var connection = _context.CreateConnection())
            {
                var department = await connection.QuerySingleOrDefaultAsync<Department>(query, new { id });
                return department;
            }
        }

        public async Task AddDepartment(Department department)
        {
            var query = "Insert into Department(Name,Description) values (@Name,@Description)";
            var parameter = new DynamicParameters();
            parameter.Add("Name", department.Name, DbType.String);
            parameter.Add("Description", department.Description, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameter);
            }
        }


        #endregion

    }
}
