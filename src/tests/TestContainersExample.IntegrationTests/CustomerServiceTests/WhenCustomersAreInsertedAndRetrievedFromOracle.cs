using DotNet.Testcontainers.Containers;
using NUnit.Framework;

namespace TestContainersExample.IntegrationTests;

[TestFixture]
public class WhenCustomersAreInsertedAndRetrievedFromOracle : Scenario
{
    protected override IContainer TestContainer => Dependencies.Instance.Oracle;

    protected override ICustomerService BuildCustomerService()
    {
        var connectionString = Dependencies.Instance.Oracle.GetConnectionString();
        return new OracleCustomerService(new OracleDbConnectionProvider(connectionString));
    }
}