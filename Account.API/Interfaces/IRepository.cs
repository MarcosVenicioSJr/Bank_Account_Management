using Account.API.DTO;

namespace Account.API.Interfaces;

public interface IRepository
{
    Task Insert(AccountDTO model);

    Task Update();

    Task Delete();

    Task<IEnumerable<int>> FindAll();
}