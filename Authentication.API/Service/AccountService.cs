using Authentication.API.DTO;
using Authentication.API.Interfaces;

namespace Authentication.API.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CreateNewAccount()
        {
            AccountDTO accountDTO = new AccountDTO()
            {
                AccountNumber = new Random().NextInt64(10000000, 10000000000).ToString(),
                Balance = 0
            };
            try
            {
                await _repository.Insert(accountDTO);

                return accountDTO.AccountNumber;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
