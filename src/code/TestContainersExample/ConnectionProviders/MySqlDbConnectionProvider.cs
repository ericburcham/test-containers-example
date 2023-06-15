using System.Data;
using MySqlConnector;

namespace TestContainersExample;

public sealed class MySqlDbConnectionProvider : IProvideDbConnections
{
    private readonly string _connectionString;

    public MySqlDbConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}