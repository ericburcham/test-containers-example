using System.Data;
using Microsoft.Data.SqlClient;

namespace TestContainersExample;

public sealed class SqlServerConnectionProvider : IProvideDbConnections
{
    private readonly string _connectionString;

    public SqlServerConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}