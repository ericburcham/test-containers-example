using System.Data;
using Npgsql;

namespace TestContainersExample;

public sealed class PostgresConnectionProvider : IProvideDbConnections
{
    private readonly string _connectionString;

    public PostgresConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}