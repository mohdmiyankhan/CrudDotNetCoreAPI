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
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRepo;

        public ClientController(ClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClient()
        {
            try
            {
                var clientList = await _clientRepo.GetAllClientsAsync();
                if (clientList.Count == 0)
                {
                    // Create the response
                    var response = new ApiResponse<List<Client>>
                    {
                        Message = "Record not found.",
                        Result = false
                    };
                    return Ok(response);
                }
                else
                {
                    // Create the response
                    var response = new ApiResponse<List<Client>>
                    {
                        Message = "Success",
                        Result = true,
                        Data = clientList
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Client>>
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
        public async Task<IActionResult> GetClientById([FromRoute] int id)
        {
            try
            {
                var client = await _clientRepo.GetClientByIdAsync(id);
                // Create the response
                var response = new ApiResponse<Client>
                {
                    Message = "Success",
                    Result = true,
                    Data = client
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Client>>
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
        public async Task<IActionResult> AddUpdateClient([FromBody] Client client)
        {
            try
            {
                if (client.ClientId == 0)
                {
                    await _clientRepo.AddClientAsync(client);
                    // Create the response
                    var response = new ApiResponse<List<Client>>
                    {
                        Message = "Client is created successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
                else
                {
                    await _clientRepo.UpdateClientAsync(client.ClientId, client);
                    // Create the response
                    var response = new ApiResponse<List<Client>>
                    {
                        Message = "Client is updated successfully.",
                        Result = true
                    };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Client>>
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
        public async Task<IActionResult> UpdateClient([FromRoute] int id, [FromBody] Client client)
        {
            try
            {
                await _clientRepo.UpdateClientAsync(id, client);
                // Create the response
                var response = new ApiResponse<List<Client>>
                {
                    Message = "Client is updated successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Client>>
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
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            try
            {
                await _clientRepo.DeleteClientAsync(id);
                // Create the response
                var response = new ApiResponse<List<Client>>
                {
                    Message = "Client is deleted successfully.",
                    Result = true
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Create the response
                var errorResponse = new ApiResponse<List<Client>>
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
