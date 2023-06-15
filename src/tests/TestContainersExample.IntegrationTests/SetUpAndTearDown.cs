using System.Threading.Tasks;
using NUnit.Framework;
using Testcontainers.MariaDb;

namespace TestContainersExample.IntegrationTests;

[SetUpFixture]
internal sealed class SetUpAndTearDown
{
    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        await Parallel.ForEachAsync(Dependencies.Instance.Containers,
            async (container, token) => { await container.StartAsync(token); });
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await Parallel.ForEachAsync(Dependencies.Instance.Containers,
            async (container, token) =>
            {
                await container.StopAsync(token);
            });
    }
}