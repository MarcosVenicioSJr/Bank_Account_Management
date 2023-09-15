using System.Data;
using MySql.Data.MySqlClient;

namespace Authentication.API;

public class DbSession : IDbSession
{
    private readonly IConfiguration _configuration;
    private IDbConnection? _connection;
    private IDbTransaction? _transaction;

    public IDbConnection Connection
    {
        get
        {
            if (_connection is not { State: ConnectionState.Open })
            {
                _connection = CreateConnection();
                _connection.Open();
            }

            return _connection;
        }
    }

    public IDbTransaction Transaction
    {
        get
        {
            if (_transaction == null)
            {
                _transaction = Connection.BeginTransaction();
            }

            return _transaction;
        }
    }

    private IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("default");
        var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString!)
        {
            SslMode = MySqlSslMode.VerifyFull
        };
        return new MySqlConnection(connectionStringBuilder.ToString());
    }

    public DbSession(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection?.Dispose();
    }
}
