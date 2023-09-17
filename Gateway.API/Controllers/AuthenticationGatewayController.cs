using Gateway.API.DTO;
using Gateway.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Gateway.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationGatewayController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAuthenticationGatewayService _service;
        private readonly string Uri = "https://localhost:7125/User/";

        public AuthenticationGatewayController(IHttpClientFactory httpClientFactory, IAuthenticationGatewayService service)
        {
            _httpClientFactory = httpClientFactory;
            _service = service;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginRequest model)
        {
            var userToken = await _service.Login(model);
            return Ok(userToken);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceClient = _httpClientFactory.CreateClient();

            var request = new
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await serviceClient.PostAsync($"{Uri}CreateNewUser", jsonContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { Message = responseContent });
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Erro ao chamar o serviço.");
            }

        }
    }
}
