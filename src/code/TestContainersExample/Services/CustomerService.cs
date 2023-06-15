namespace TestContainersExample;

public abstract class CustomerService
{
    private static readonly object LOCK_OBJECT = new();

    private bool _initialized;

    public abstract void CreateCustomersTable();

    protected void InitializeIfNecessary()
    {
        lock (LOCK_OBJECT)
        {
            if (!_initialized)
            {
                CreateCustomersTable();
                _initialized = true;
            }
        }
    }
}