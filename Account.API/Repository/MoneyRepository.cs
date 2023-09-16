using Dapper;
using MoneyMover.API.DTO;
using MoneyMover.API.Interfaces;
using MoneyMover.API.Models;

namespace MoneyMover.API.Repository
{
    public class MoneyRepository : IRepository
    {
        private readonly IDbSession _session;

        public MoneyRepository(IDbSession dbSession)
        {
            _session = dbSession;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetAccountByAccountNumber(string accountNumber)
        {
            using (var coon = _session.Connection)
            {
                Account account = await coon.QueryFirstOrDefaultAsync(MoneyQuerys.MoneyQuerys.GetBalanceByAccountNumberQuery,
                    new { AccountNumber = accountNumber });

                return account;
            }
        }

        public Task Insert(AccountDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Account account)
        {
            using (var coon = _session.Connection)
            {
                await coon.ExecuteAsync(MoneyQuerys.MoneyQuerys.UpdateBalanceQuery,
                    new { Balance = account.Balance, AccountNumber = account.AccountNumber });
            }
        }
    }
}
