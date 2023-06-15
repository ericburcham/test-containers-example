using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace TestContainersExample;

public sealed class OracleDbConnectionProvider : IProvideDbConnections
{
    private readonly string _connectionString;

    public OracleDbConnectionProvider(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        return new OracleConnection(_connectionString);
    }
}