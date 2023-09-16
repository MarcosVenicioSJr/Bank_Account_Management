using Authentication.API.DTO;
using Authentication.API.Models;

namespace Authentication.API;

public interface IUserRepository
{
    Task Insert(UserDTO model);

    Task Update();

    Task Delete();

    Task<IEnumerable<int>> FindAll();

    Task<User> FindByEmail(string email);
}