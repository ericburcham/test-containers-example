using DotNet.Testcontainers.Containers;
using NUnit.Framework;

namespace TestContainersExample.IntegrationTests;

[TestFixture]
public class WhenCustomersAreInsertedAndRetrievedFromPostgres : Scenario
{
    protected override IContainer TestContainer => Dependencies.Instance.Postgres;

    protected override ICustomerService BuildCustomerService()
    {
        var connectionString = Dependencies.Instance.Postgres.GetConnectionString();
        return new PostgresCustomerService(new PostgresConnectionProvider(connectionString));
    }
}