using System.Data;

namespace Account.API.Interfaces;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
    IDbTransaction? Transaction { get; }

}