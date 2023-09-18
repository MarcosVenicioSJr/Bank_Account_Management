using Authentication.API.DTO;
using Authentication.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    
    public UserController(IUserService service)
    {
        _service = service;
    }
     
    [HttpPost]
    [Route("CreateNewUser")]
    public async Task<OkObjectResult>CreateUser([FromBody] CreateUserRequest model)
    {
        string accountNumber = await _service.CreateUserAsync(model);

        return Ok(new { Message = $"account {accountNumber} and user {model.Name} created successfully" });
    }
}