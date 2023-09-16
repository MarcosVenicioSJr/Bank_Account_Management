using Authentication.API.DTO;
using Authentication.API.Interfaces;
using Authentication.API.Models;
using Authentication.API.Repository.Querys;
using Dapper;

namespace Authentication.API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbSession _session;

        public AccountRepository(IDbSession dbSession)
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

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task Insert(AccountDTO model)
        {
            using (var coon = _session.Connection)
            {
                await coon.ExecuteAsync(AccountQuerys.InsertAccount, new { AccountNumber = model.AccountNumber, Balance = model.Balance});
            }
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
