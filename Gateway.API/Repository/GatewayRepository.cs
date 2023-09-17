using Gateway.API.Interfaces;
using Dapper;
using Gateway.API.Repository.Query;
using Gateway.API.Model;

namespace Gateway.API.Repository
{
    public class GatewayRepository : IRepository
    {
        private readonly IDbSession _session;

        public GatewayRepository(IDbSession dbSession)
        {
            _session = dbSession;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using (var coon = _session.Connection)
            {
                User user = await coon.QueryFirstOrDefaultAsync(GatewayQuery.GetByEmail, new { Email = email });
                return user;
            }
        }
    }
}
