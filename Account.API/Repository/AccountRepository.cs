using Account.API.DTO;
using Account.API.Interfaces;
using Account.API.Repository.Querys;
using Dapper;

namespace Account.API.Repository;

public class AccountRepository : IRepository
{
    private readonly IDbSession _session;

    public AccountRepository(IDbSession dbSession)
    {
        _session = dbSession;
    }

    public async Task Insert(AccountDTO model)
    {
        using (var conn = _session.Connection)
        {
            await conn.ExecuteAsync("INSERT INTO Account.AccountClient (Account, Balance) VALUES(@Account, @Balance)", new { Account = model.Account, Balance = model.Balance });
        }
    }

    public Task Update()
    {
        throw new NotImplementedException();
    }

    public Task Delete()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<int>> FindAll()
    {
        throw new NotImplementedException();
    }
}