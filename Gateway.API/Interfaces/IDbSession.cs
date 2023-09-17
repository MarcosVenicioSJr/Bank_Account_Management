using System.Data;

namespace Gateway.API.Interfaces
{
    public interface IDbSession : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction? Transaction { get; }

    }
}
