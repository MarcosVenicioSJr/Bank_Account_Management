using System.Data;

namespace Authentication.API;

public interface IDbSession : IDisposable
{
    IDbConnection Connection { get; }
    IDbTransaction? Transaction { get; }

}