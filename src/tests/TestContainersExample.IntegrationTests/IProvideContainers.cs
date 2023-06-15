using System.Collections.Generic;
using DotNet.Testcontainers.Containers;

namespace TestContainersExample.IntegrationTests;

internal interface IProvideContainers
{
    IEnumerable<IContainer> Containers { get; }
}