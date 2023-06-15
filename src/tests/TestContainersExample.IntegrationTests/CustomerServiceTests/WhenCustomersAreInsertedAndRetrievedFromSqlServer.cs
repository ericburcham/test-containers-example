using DotNet.Testcontainers.Containers;
using NUnit.Framework;

namespace TestContainersExample.IntegrationTests;

[TestFixture]
public class WhenCustomersAreInsertedAndRetrievedFromSqlServer : Scenario
{
    protected override IContainer TestContainer => Dependencies.Instance.SqlServer;

    protected override ICustomerService BuildCustomerService()
    {
        var connectionString = Dependencies.Instance.SqlServer.GetConnectionString();
        return new SqlServerCustomerService(new SqlServerConnectionProvider(connectionString));
    }
}