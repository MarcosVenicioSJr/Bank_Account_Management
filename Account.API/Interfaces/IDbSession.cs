using System.Data;

namespace MoneyMover.API.Interfaces;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
    IDbTransaction? Transaction { get; }

}