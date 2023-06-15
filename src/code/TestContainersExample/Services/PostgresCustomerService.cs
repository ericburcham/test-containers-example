using System.Collections.Generic;

namespace TestContainersExample;

public sealed class PostgresCustomerService : CustomerService, ICustomerService
{
    private readonly IProvideDbConnections _connectionProvider;

    public PostgresCustomerService(IProvideDbConnections connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Customer> GetCustomers()
    {
        InitializeIfNecessary();

        IList<Customer> customers = new List<Customer>();

        using var connection = _connectionProvider.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name FROM Customers";
        command.Connection!.Open();

        using var dataReader = command.ExecuteReader();
        while (dataReader.Read())
        {
            var id = dataReader.GetInt64(0);
            var name = dataReader.GetString(1);
            customers.Add(new Customer(id, name));
        }

        return customers;
    }


    public void Create(Customer customer)
    {
        InitializeIfNecessary();

        using var connection = _connectionProvider.GetConnection();
        using var command = connection.CreateCommand();

        var id = command.CreateParameter();
        id.ParameterName = "@id";
        id.Value = customer.Id;

        var name = command.CreateParameter();
        name.ParameterName = "@name";
        name.Value = customer.Name;

        command.CommandText = "INSERT INTO Customers (Id, Name) VALUES(@id, @name)";
        command.Parameters.Add(id);
        command.Parameters.Add(name);
        command.Connection!.Open();
        command.ExecuteNonQuery();
    }

    public override void CreateCustomersTable()
    {
        using var connection = _connectionProvider.GetConnection();
        using var command = connection.CreateCommand();
        command.CommandText =
            "CREATE TABLE Customers (Id BIGINT NOT NULL, Name VARCHAR(100) NOT NULL, PRIMARY KEY (Id));";
        command.Connection!.Open();
        command.ExecuteNonQuery();
    }
}