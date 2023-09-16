using MoneyMover.API.DTO;

namespace MoneyMover.API.Interfaces;

public interface IMoneyTransferService
{
    Task<decimal> GetBalanceByAccountNumber(string accountNumber);
    Task DepositMoney(DepositRequest model);
    Task TransferMoney(TransferMoneyRequest model);
}