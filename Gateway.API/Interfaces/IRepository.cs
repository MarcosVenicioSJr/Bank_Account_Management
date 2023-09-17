using Gateway.API.Model;

namespace Gateway.API.Interfaces
{
    public interface IRepository
    {
        Task<User> GetUserByEmail(string email);
    }
}
