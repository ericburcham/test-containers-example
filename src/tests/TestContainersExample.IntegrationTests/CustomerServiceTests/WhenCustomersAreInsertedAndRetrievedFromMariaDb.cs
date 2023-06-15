using DotNet.Testcontainers.Containers;
using NUnit.Framework;

namespace TestContainersExample.IntegrationTests;

[TestFixture]
public class WhenCustomersAreInsertedAndRetrievedFromMariaDb : Scenario
{
    protected override IContainer TestContainer => Dependencies.Instance.MariaDb;

    protected override ICustomerService BuildCustomerService()
    {
        var connectionString = Dependencies.Instance.MariaDb.GetConnectionString();
        return new MariaDbCustomerService(new MariaDbConnectionProvider(connectionString));
    }
}