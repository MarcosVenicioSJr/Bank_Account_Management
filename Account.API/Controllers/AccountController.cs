using Account.API.DTO;
using Account.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<OkObjectResult> CreateAccount([FromBody] CreateAccountRequest model)
    {
        await _service.CreateAccount(model);
        return Ok(new {Message = "Conta criada com sucesso!"});
    }
}