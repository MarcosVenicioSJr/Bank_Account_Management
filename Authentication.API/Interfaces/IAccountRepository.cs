using Authentication.API.DTO;
using Authentication.API.Models;

namespace Authentication.API.Interfaces
{
    public interface IAccountRepository
    {
        Task Insert(AccountDTO model);

        Task Update();

        Task Delete();

        Task<IEnumerable<int>> FindAll();

        Task<User> FindByEmail(string email);
    }
}
