using Account.API.DTO;

namespace Account.API.Interfaces;

public interface IAccountService
{
    Task CreateAccount(CreateAccountRequest model);
}