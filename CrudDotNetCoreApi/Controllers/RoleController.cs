using CrudDotNetCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepo;

        public RoleController(RoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var roleList = await _roleRepo.GetAllRoleAsync();
                if (roleList.Count == 0)
                {
                    // Create the response
                    var response = new ApiResponse<List<Role>>
                    {
                        Message = "Record not found.",
                        Result = false
                    };
                    return Ok(response);
                }
                else
                {
                    // Create the response
                    var response = new ApiResponse<List<Role>>
                    {
                        Message = "Success",
                        Result = true,
                        Data = roleList
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Role>>
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
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            try
            {
                var role = await _roleRepo.GetRoleByIdAsync(id);
                // Create the response
                var response = new ApiResponse<Role>
                {
                    Message = "Success",
                    Result = true,
                    Data = role
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Role>>
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
        public async Task<IActionResult> AddUpdateRole([FromBody] Role role)
        {
            try
            {
                if (role.RoleId == 0)
                {
                    await _roleRepo.AddRoleAsync(role);
                    // Create the response
                    var response = new ApiResponse<List<Role>>
                    {
                        Message = "Role is created successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
                else
                {
                    await _roleRepo.UpdateRoleAsync(role.RoleId, role);
                    // Create the response
                    var response = new ApiResponse<List<Role>>
                    {
                        Message = "Role is updated successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Role>>
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
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] Role role)
        {
            try
            {
                await _roleRepo.UpdateRoleAsync(id, role);
                // Create the response
                var response = new ApiResponse<List<Role>>
                {
                    Message = "Role is updated successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Role>>
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
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            try
            {
                await _roleRepo.DeleteRoleAsync(id);
                // Create the response
                var response = new ApiResponse<List<Role>>
                {
                    Message = "Role is deleted successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Role>>
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
