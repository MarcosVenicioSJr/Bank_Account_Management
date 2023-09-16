using Account.API.DTO;
using Account.API.Interfaces;

namespace Account.API.Service;

public class AccountService : IAccountService
{
    private readonly IRepository _repository;

    public AccountService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAccount(CreateAccountRequest model)
    {
        Random random = new Random();
        long numberAccount = random.NextInt64(100000000, 1000000000);
        try
        {
            AccountDTO account = new AccountDTO()
            {
                Balance = model.Balance,
                Account = numberAccount.ToString()
            };

            await _repository.Insert(account);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}