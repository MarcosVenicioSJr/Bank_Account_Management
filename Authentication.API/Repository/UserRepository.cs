using Authentication.API.Models;
using Authentication.API.Querys;
using Dapper;

namespace Authentication.API.Repository;

public class UserRepository : IRepository
{
    private readonly IDbSession _session;

    public UserRepository(IDbSession dbSession)
    {
        _session = dbSession;
    }
    
    public Task Insert()
    {
        throw new NotImplementedException();
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

    public async Task<User> FindByEmail(string email)
    {
        using (var conn = _session.Connection)
        {
            User user = await conn.QueryFirstOrDefaultAsync(UserQuery.FindByEmail,
                new { Email = email });
     
            return user;
        }
    }
}