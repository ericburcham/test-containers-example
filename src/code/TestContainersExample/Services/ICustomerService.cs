using System.Collections.Generic;

namespace TestContainersExample;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers();
    void Create(Customer customer);
}