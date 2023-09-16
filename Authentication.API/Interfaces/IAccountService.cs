namespace Authentication.API.Interfaces
{
    public interface IAccountService
    {
        public Task<string> CreateNewAccount();
    }
}
