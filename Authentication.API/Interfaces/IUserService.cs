using Authentication.API.DTO;

namespace Authentication.API;

public interface IUserService
{
    Task CreateUserAsync(CreateUserRequest model);
    Task Login();
}