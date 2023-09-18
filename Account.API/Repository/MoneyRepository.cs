using Dapper;
using Google.Protobuf.WellKnownTypes;
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

        public async Task AddTransactioExtract(ExtractDTO model)
        {
            using (var coon = _session.Connection)
            {
                await coon.ExecuteAsync(MoneyQuerys.MoneyQuerys.AddTransactioExtract,
                    new { AccountTo = model.AccountTo, AccountFrom = model.AccountFrom, Value = model.Value, TransactionDate = model.TransactionDate });
            }
        }

        public async Task<IEnumerable<Extract>> GetExtractsByAccountNumber(string accountNumber)
        {
            using (var coon = _session.Connection)
            {
                return await coon.QueryAsync<Extract>(MoneyQuerys.MoneyQuerys.GetExtractsByAccountNumber, new { AccountFrom = accountNumber });
            }
        }

        public async Task<dynamic> GetAccountByAccountNumber(string accountNumber)
        {
            using (var coon = _session.Connection)
            {
                var account = await coon.QueryFirstOrDefaultAsync<Account>(MoneyQuerys.MoneyQuerys.GetBalanceByAccountNumberQuery,
                    new { AccountNumber = accountNumber });

                return account;
            }
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
