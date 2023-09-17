using MoneyMover.API.DTO;
using MoneyMover.API.Models;

namespace MoneyMover.API.Interfaces;

public interface IRepository
{
    Task<Account> GetAccountByAccountNumber(string accountNumber);

    Task Update(Account account);

    Task AddTransactioExtract(ExtractDTO model);

    Task<IEnumerable<dynamic>> GetExtractsByAccountNumber(string accountNumber);
}