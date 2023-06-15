using System.Data;

namespace TestContainersExample;

public interface IProvideDbConnections
{
    IDbConnection GetConnection();
}