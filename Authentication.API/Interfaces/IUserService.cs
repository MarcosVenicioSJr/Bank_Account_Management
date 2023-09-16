using Authentication.API.DTO;

namespace Authentication.API;

public interface IUserService
{
    Task<string> CreateUserAsync(CreateUserRequest model);
    Task Login();
}