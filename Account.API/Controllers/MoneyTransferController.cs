using MoneyMover.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MoneyMover.API.DTO;

namespace MoneyMover.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoneyTransferController : ControllerBase
    {
        private readonly IMoneyTransferService _service;

        public MoneyTransferController(IMoneyTransferService service)
        {
            _service = service;
        }

        [HttpGet("{accountNumber}")]
        public async Task<OkObjectResult> GetBalance(string accountNumber)
        {
            try
            {
                decimal balance = await _service.GetBalanceByAccountNumber(accountNumber);

                return Ok(new { Message = $"A conta {accountNumber} possui R${balance} de saldo" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<OkObjectResult> DepositMoney([FromBody] DepositRequest deposit)
        {
            try
            {
                await _service.DepositMoney(deposit);
                return Ok(new { Message = "Deposit made successfully." });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("TransferMoney")]
        public async Task<OkObjectResult> TransferMoney([FromBody] TransferMoneyRequest model)
        {
            await _service.TransferMoney(model);
            return Ok(new { Message = "Transfer Successfully Performed."});
        }
    }
}
