using MoneyMover.API.DTO;
using MoneyMover.API.Models;

namespace MoneyMover.API.Interfaces;

public interface IRepository
{
    Task<MoneyMover.API.Models.Account> GetAccountByAccountNumber(string accountNumber);
    Task Insert(AccountDTO model);

    Task Update(Account account);

    Task Delete();

    Task<IEnumerable<int>> FindAll();
}