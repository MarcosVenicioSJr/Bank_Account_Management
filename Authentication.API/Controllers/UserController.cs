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
    public void CreateUser([FromBody] CreateUserRequest model)
    {
        _service.CreateUserAsync(model);
    }
}