using Authentication.API.DTO;
using Authentication.API.Models;
using Authentication.API.Validations;

namespace Authentication.API.Service;

public class UserService : IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateUserAsync(CreateUserRequest model)
    {
        var user = await _repository.FindByEmail(model.Email);
        if (!UserValidation.IsNull(user))
            throw new Exception("User already exists");
    }

    public Task Login()
    {
        throw new NotImplementedException();
    }

    public void CreateUser(User model)
    {
        User user = new User()
        {
            Email = model.Email,
            Password = model.Password,
            Account = model.Account
        };
    }
}