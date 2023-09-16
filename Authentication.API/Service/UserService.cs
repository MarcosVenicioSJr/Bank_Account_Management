using Authentication.API.DTO;
using Authentication.API.Interfaces;
using Authentication.API.Models;
using Authentication.API.Validations;

namespace Authentication.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IAccountService _accountService;

    public UserService(IUserRepository repository, IAccountService accountService)
    {
        _repository = repository;
        _accountService = accountService;
    }

    public async Task<string> CreateUserAsync(CreateUserRequest model)
    {
        var user = await _repository.FindByEmail(model.Email);
        if (!UserValidation.IsNull(user))
            throw new Exception("User already exists");


        try
        {
            await CreateUser(model);
            string accountNumber = await _accountService.CreateNewAccount();
            return accountNumber;
        }catch (Exception ex)
        {
            throw;
        }
        

        
    }

    public Task Login()
    {
        throw new NotImplementedException();
    }

    private async Task CreateUser(CreateUserRequest model)
    {
        UserDTO userDTO = new UserDTO()
        {
            Email = model.Email,
            Name = model.Name,
            Password = model.Password
        };

        await _repository.Insert(userDTO);
    }
}