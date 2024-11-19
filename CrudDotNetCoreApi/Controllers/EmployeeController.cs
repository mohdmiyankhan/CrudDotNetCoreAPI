using CrudDotNetCoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CrudDotNetCoreApi.Models.ApiResponseModel;

namespace CrudDotNetCoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepo;

        public EmployeeController(EmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employeeList = await _employeeRepo.GetAllEmployeesAsync();
                if (employeeList.Count == 0)
                {
                    // Create the response
                    var response = new ApiResponse<List<Employee>>
                    {
                        Message = "Record not found.",
                        Result = false
                    };
                    return Ok(response);
                }
                else
                {
                    // Create the response
                    var response = new ApiResponse<List<Employee>>
                    {
                        Message = "Success",
                        Result = true,
                        Data = employeeList
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Employee>>
                {
                    Message = "An error occurred while processing your request.",
                    Result = false,
                    Error = ex.Message // Optionally, use ex.ToString() for more detailed stack trace
                };
                return Ok(errorResponse);
                //return StatusCode(500, errorResponse); // Return 500 for server error
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            try
            {
                var employee = await _employeeRepo.GetEmployeeByIdAsync(id);
                // Create the response
                var response = new ApiResponse<Employee>
                {
                    Message = "Success",
                    Result = true,
                    Data = employee
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Employee>>
                {
                    Message = "An error occurred while processing your request.",
                    Result = false,
                    Error = ex.Message // Optionally, use ex.ToString() for more detailed stack trace
                };
                return Ok(errorResponse);
                //return StatusCode(500, errorResponse); // Return 500 for server error
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee.EmpId == 0)
                {
                    await _employeeRepo.AddEmployeeAsync(employee);
                    var response = new ApiResponse<List<Employee>>
                    {
                        Message = "Employee is created successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
                else
                {
                    await _employeeRepo.UpdateEmployeeAsync(employee.EmpId, employee);
                    var response = new ApiResponse<List<Employee>>
                    {
                        Message = "Employee is updated successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Employee>>
                {
                    Message = "An error occurred while processing your request.",
                    Result = false,
                    Error = ex.Message // Optionally, use ex.ToString() for more detailed stack trace
                };
                return Ok(errorResponse);
                //return StatusCode(500, errorResponse); // Return 500 for server error
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            try
            {
                await _employeeRepo.UpdateEmployeeAsync(id, employee);
                // Create the response
                var response = new ApiResponse<List<Employee>>
                {
                    Message = "Employee is updated successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Employee>>
                {
                    Message = "An error occurred while processing your request.",
                    Result = false,
                    Error = ex.Message // Optionally, use ex.ToString() for more detailed stack trace
                };
                return Ok(errorResponse);
                //return StatusCode(500, errorResponse); // Return 500 for server error
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {
                await _employeeRepo.DeleteEmployeeAsync(id);
                // Create the response
                var response = new ApiResponse<List<Employee>>
                {
                    Message = "Employee is deleted successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Employee>>
                {
                    Message = "An error occurred while processing your request.",
                    Result = false,
                    Error = ex.Message // Optionally, use ex.ToString() for more detailed stack trace
                };
                return Ok(errorResponse);
                //return StatusCode(500, errorResponse); // Return 500 for server error
            }
        }
    }
}
