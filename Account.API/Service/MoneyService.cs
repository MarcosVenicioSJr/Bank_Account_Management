using MoneyMover.API.DTO;
using MoneyMover.API.Interfaces;
using MoneyMover.API.Models;

namespace MoneyMover.API.Service
{
    public class MoneyService : IMoneyTransferService
    {
        private readonly IRepository _repository;

        public MoneyService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task DepositMoney(DepositRequest model)
        {
            try
            {
                Account account = await _repository.GetAccountByAccountNumber(model.AccountNumber);

                if (account == null)
                    throw new Exception("Account not found.");

                account.Balance += model.BalanceDeposit;

                await _repository.Update(account);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<decimal> GetBalanceByAccountNumber(string accountNumber)
        {
            try
            {
                Account account = await _repository.GetAccountByAccountNumber(accountNumber);

                if (account == null)
                    throw new Exception("Account not found.");

                return account.Balance;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task TransferMoney(TransferMoneyRequest model)
        {
            Account accountTo = await _repository.GetAccountByAccountNumber(model.AccountTo);
            Account accountFrom = await _repository.GetAccountByAccountNumber(model.AccountFrom);

            if (accountTo == null || accountFrom == null)
                throw new Exception("The transfer could not be performed. Please check the accounts you entered and try again.");

            accountFrom.Balance -= model.Value;
            accountTo.Balance -= model.Value;

            await _repository.Update(accountFrom);
            await _repository.Update(accountTo);
        }
    }
}
