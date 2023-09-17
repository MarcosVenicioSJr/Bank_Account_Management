using Gateway.API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Gateway.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MoneyGatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string Uri = "https://localhost:32784/MoneyTransfer/";

        public MoneyGatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetBalance/{accountNumber}")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            try
            {
                var serviceClient = _httpClientFactory.CreateClient();
                var response = await serviceClient.GetAsync($"{Uri}{accountNumber}");
                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { Message = contentResponse });
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Erro ao chamar o serviço.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao chamar o serviço.");
            }
        }

        [HttpPost("DepositMoney")]
        public async Task<IActionResult> DepositMoney([FromBody] DepositRequest model)
        {
            var serviceClient = _httpClientFactory.CreateClient();

            var request = new
            {
                AccountNumber = model.AccountNumber,
                BalanceDeposit = model.BalanceDeposit
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await serviceClient.PostAsync($"{Uri}", jsonContent);
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

        [HttpPost("TransferMoney")]
        public async Task<IActionResult> TransferMoney([FromBody] TransferMoneyRequest model)
        {
            var serviceClient = _httpClientFactory.CreateClient();

            var request = new
            {
                AccountTo = model.AccountTo,
                AccountFrom = model.AccountFrom,
                Value = model.Value,
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await serviceClient.PostAsync($"{Uri}TransferMoney", jsonContent);
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
