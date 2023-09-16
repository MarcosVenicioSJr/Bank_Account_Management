using Authentication.API.Models;

namespace Authentication.API;

public interface IRepository
{
    Task Insert();

    Task Update();

    Task Delete();

    Task<IEnumerable<int>> FindAll();

    Task<User> FindByEmail(string email);
}