using MoneyMover.API.DTO.Requests;

namespace MoneyMover.API.Interfaces;

public interface IMoneyTransferService
{
    Task<decimal> GetBalanceByAccountNumber(string accountNumber);
    Task DepositMoney(DepositRequest model);
    Task TransferMoney(TransferMoneyRequest model);
    Task<IEnumerable<dynamic>> GetExtractByAccountNumber(string accountNumber);
}