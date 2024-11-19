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
    public class ClientProjectController : ControllerBase
    {
        private readonly ClientProjectRepository _clientProjectRepo;

        public ClientProjectController(ClientProjectRepository clientProjectRepo)
        {
            _clientProjectRepo = clientProjectRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientProject()
        {
            try
            {
                var clientProjectList = await _clientProjectRepo.GetAllClientProjectsAsync();
                if (clientProjectList.Count == 0)
                {
                    // Create the response
                    var response = new ApiResponse<List<ClientProject>>
                    {
                        Message = "Record not found.",
                        Result = false
                    };
                    return Ok(response);
                }
                else
                {
                    // Create the response
                    var response = new ApiResponse<List<ClientProject>>
                    {
                        Message = "Record not found.",
                        Result = true,
                        Data = clientProjectList
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<ClientProject>>
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
        public async Task<IActionResult> GetClientProjectById([FromRoute] int id)
        {
            try
            {
                var clientProject = await _clientProjectRepo.GetClientProjectByIdAsync(id);
                // Create the response
                var response = new ApiResponse<ClientProject>
                {
                    Message = "Success",
                    Result = true,
                    Data = clientProject
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<ClientProject>>
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
        public async Task<IActionResult> AddUpdateClientProject([FromBody] ClientProject clientProject)
        {
            try
            {
                if (clientProject.ClientProjectId == 0)
                {
                    await _clientProjectRepo.AddClientProjectAsync(clientProject);
                    // Create the response
                    var response = new ApiResponse<List<ClientProject>>
                    {
                        Message = "Client Project is created successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
                else
                {
                    await _clientProjectRepo.UpdateClientProjectAsync(clientProject.ClientProjectId, clientProject);
                    // Create the response
                    var response = new ApiResponse<List<ClientProject>>
                    {
                        Message = "Client Project is updated successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<ClientProject>>
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
        public async Task<IActionResult> UpdateClientProject([FromRoute] int id, [FromBody] ClientProject clientProject)
        {
            try
            {
                await _clientProjectRepo.UpdateClientProjectAsync(id, clientProject);
                // Create the response
                var response = new ApiResponse<List<ClientProject>>
                {
                    Message = "Client Project is updated successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<ClientProject>>
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
        public async Task<IActionResult> DeleteClientProject([FromRoute] int id)
        {
            try
            {
                await _clientProjectRepo.DeleteClientProjectAsync(id);
                // Create the response
                var response = new ApiResponse<List<ClientProject>>
                {
                    Message = "Client Project is deleted successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<ClientProject>>
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
