using EmployeeManagementPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPOC.Repository
{
    public interface IDepartmentRepo
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task AddDepartment(Department department);

    }
}
