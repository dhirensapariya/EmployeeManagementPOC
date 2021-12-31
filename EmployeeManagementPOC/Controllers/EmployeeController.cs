using EmployeeManagementPOC.Models;
using EmployeeManagementPOC.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementPOC.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private DepartmentRepo _repository;
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo repository)
        {
            _employeeRepo = repository;
        }


        public async Task<IActionResult> GetEmployee() {
            ApiResponseModel<List<Employee>> response = new ApiResponseModel<List<Employee>>();
            try
            {
                response.Data = await _employeeRepo.GetEmployees();
                response.IsValid = true;

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = ex.Message.ToString();

            }
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            ApiResponseModel<List<Employee>> response = new ApiResponseModel<List<Employee>>();
            try
            {
                await _employeeRepo.AddEmployee(employee);
                response.Data = await _employeeRepo.GetEmployees();
                response.IsValid = true;
                response.Message = "Record saved successfully";

            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = ex.Message.ToString();
            }
            return Ok(response);
        }
    }
}
