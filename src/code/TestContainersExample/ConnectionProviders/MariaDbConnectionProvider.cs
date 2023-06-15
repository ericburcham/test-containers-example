using System.Data;
using MySqlConnector;

namespace TestContainersExample;

public sealed class MariaDbConnectionProvider : IProvideDbConnections
{
    private readonly string _connectionString;

    public MariaDbConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}