using System.Collections.Generic;
using System.Linq;
using DotNet.Testcontainers.Containers;
using FluentAssertions;
using NUnit.Framework;

namespace TestContainersExample.IntegrationTests;

public abstract class Scenario
{
    private static readonly IDictionary<long, string> CUSTOMER_DATA = new Dictionary<long, string>
    {
        {1, "George"},
        {2, "John"}
    };

    private readonly ICollection<Customer> _results = new List<Customer>();

    protected abstract IContainer TestContainer { get; }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var customerService = BuildCustomerService();

        foreach (var customer in CUSTOMER_DATA) customerService.Create(new Customer(customer.Key, customer.Value));
        foreach (var customer in customerService.GetCustomers()) _results.Add(new Customer(customer.Id, customer.Name));
    }

    [Test]
    public void TheCorrectNumberOfCustomersAreReturned()
    {
        _results.Should().HaveCount(CUSTOMER_DATA.Count);
    }

    [Test]
    public void ContainerIsRunningAnd()
    {
        TestContainer.State.Should().Be(TestcontainersStates.Running);
    }

    [Test]
    public void TheCorrectCustomersAreReturned()
    {
        _results
            .Should()
            .AllSatisfy(customer =>
            {
                var cd = CUSTOMER_DATA.Single(cd => cd.Key == customer.Id);
                customer.Name.Should().Be(cd.Value);
            });
    }

    protected abstract ICustomerService BuildCustomerService();
}