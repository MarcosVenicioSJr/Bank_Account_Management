using MoneyMover.API.DTO;
using MoneyMover.API.DTO.Requests;
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
                var account = await _repository.GetAccountByAccountNumber(model.AccountNumber);

                if (account == null)
                    throw new Exception("Account not found.");

                account.Balance += model.BalanceDeposit;

                await _repository.Update(account);
                await SaveExtract(account.AccountNumber, model.BalanceDeposit);

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
                var account = await _repository.GetAccountByAccountNumber(accountNumber);

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

            if (accountFrom.Balance < model.Value)
                throw new Exception($"Account {accountFrom.AccountNumber} not have balance.");

            accountFrom.Balance -= model.Value;
            accountTo.Balance += model.Value;

            await _repository.Update(accountFrom);
            await _repository.Update(accountTo);
            await SaveExtract(accountFrom.AccountNumber, model.Value, accountTo.AccountNumber);
        }

        public async Task<IEnumerable<dynamic>> GetExtractByAccountNumber(string accountNumber)
        {

            var extracts = await _repository.GetExtractsByAccountNumber(accountNumber);

            if (extracts == null)
                throw new Exception("Account not has transactions.");

            var responses = new List<Extract>();

            foreach (var extract in extracts)
            {
                responses.Add(extract);
            }

            return responses;
        }

        private async Task SaveExtract(string accountFrom, decimal value, string? accountTo = null)
        {
            ExtractDTO extract = new ExtractDTO
            {
                AccountTo = accountTo,
                Value = value,
                AccountFrom = accountFrom,
                TransactionDate = DateTime.UtcNow
            };

            await _repository.AddTransactioExtract(extract);

        }

    }
}
