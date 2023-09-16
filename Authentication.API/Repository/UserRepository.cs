using Authentication.API.DTO;
using Authentication.API.Models;
using Authentication.API.Querys;
using Dapper;
using System.Xml.Linq;

namespace Authentication.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly IDbSession _session;

    public UserRepository(IDbSession dbSession)
    {
        _session = dbSession;
    }

    public async Task Insert(UserDTO user)
    {
        using (var conn = _session.Connection)
        {
            await conn.ExecuteAsync(UserQuery.InsertUser, new { Name = user.Name, Email = user.Email, Password = user.Password });
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