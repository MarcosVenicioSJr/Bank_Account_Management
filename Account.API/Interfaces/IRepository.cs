using MoneyMover.API.DTO;
using MoneyMover.API.Models;

namespace MoneyMover.API.Interfaces;

public interface IRepository
{
    Task<dynamic> GetAccountByAccountNumber(string accountNumber);

    Task Update(Account account);

    Task AddTransactioExtract(ExtractDTO model);

    Task<IEnumerable<Extract>> GetExtractsByAccountNumber(string accountNumber);
}