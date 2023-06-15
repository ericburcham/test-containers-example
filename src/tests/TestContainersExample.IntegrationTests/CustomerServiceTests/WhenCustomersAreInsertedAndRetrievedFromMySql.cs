using DotNet.Testcontainers.Containers;
using NUnit.Framework;

namespace TestContainersExample.IntegrationTests;

[TestFixture]
public class WhenCustomersAreInsertedAndRetrievedFromMySql : Scenario
{
    protected override IContainer TestContainer => Dependencies.Instance.MySql;

    protected override ICustomerService BuildCustomerService()
    {
        var connectionString = Dependencies.Instance.MySql.GetConnectionString();
        return new MySqlCustomerService(new MySqlDbConnectionProvider(connectionString));
    }
}