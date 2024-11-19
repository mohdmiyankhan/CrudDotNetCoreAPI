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
    public class DesignationController : ControllerBase
    {
        private readonly DesignationRepository _designationRepo;

        public DesignationController(DesignationRepository designationRepo)
        {
            _designationRepo = designationRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDesignation()
        {
            try
            {
                var designationList = await _designationRepo.GetAllDesignationAsync();
                if (designationList.Count == 0)
                {
                    // Create the response
                    var response = new ApiResponse<List<Designation>>
                    {
                        Message = "Record not found.",
                        Result = false
                    };
                    return Ok(response);
                }
                else
                {
                    // Create the response
                    var response = new ApiResponse<List<Designation>>
                    {
                        Message = "Success",
                        Result = true,
                        Data = designationList
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Designation>>
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
        public async Task<IActionResult> GetDesignationById([FromRoute] int id)
        {
            try
            {
                var designation = await _designationRepo.GetDesignationByIdAsync(id);
                // Create the response
                var response = new ApiResponse<Designation>
                {
                    Message = "Success",
                    Result = true,
                    Data = designation
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Designation>>
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
        public async Task<IActionResult> AddUpdateDesignation([FromBody] Designation designation)
        {
            try
            {
                if (designation.DesignationId == 0)
                {
                    await _designationRepo.AddDesignationAsync(designation);
                    // Create the response
                    var response = new ApiResponse<List<Designation>>
                    {
                        Message = "Designation is created successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
                else
                {
                    await _designationRepo.UpdateDesignationAsync(designation.DesignationId, designation);
                    // Create the response
                    var response = new ApiResponse<List<Designation>>
                    {
                        Message = "Designation is updated successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Designation>>
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
        public async Task<IActionResult> UpdateDesignation([FromRoute] int id, [FromBody] Designation designation)
        {
            try
            {
                await _designationRepo.UpdateDesignationAsync(id, designation);
                // Create the response
                var response = new ApiResponse<List<Designation>>
                {
                    Message = "Designation is updated successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Designation>>
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
        public async Task<IActionResult> DeleteDesignation([FromRoute] int id)
        {
            try
            {
                await _designationRepo.DeleteDesignationAsync(id);
                // Create the response
                var response = new ApiResponse<List<Designation>>
                {
                    Message = "Designation is deleted successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Designation>>
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
