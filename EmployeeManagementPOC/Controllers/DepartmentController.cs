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
    [Route("api/[controller]/[action]")]
    
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepo _departmentRepo;

        public DepartmentController(IDepartmentRepo repository) {
            _departmentRepo = repository;
        }
            

        [HttpGet]
        public async Task<IActionResult> GetDepartment() {
            ApiResponseModel<List<Department>> response = new ApiResponseModel<List<Department>>();
            try
            {
                response.Data =await _departmentRepo.GetDepartments();
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
        public async Task<IActionResult> AddDepartment(Department department) 
        {
         ApiResponseModel<List<Department>> response = new ApiResponseModel<List<Department>>();
            try
            {
                await _departmentRepo.AddDepartment(department);
                response.Data = await _departmentRepo.GetDepartments();
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
