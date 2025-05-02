using MyTest.Domain.Entities;
using MyTest.Domain.ValueObjects;

namespace MyTest.Domain.Services;

public class CustomerMigrationService
{
    private readonly string _oldCity;
    private readonly Address _newAddress;

    public CustomerMigrationService(string oldCity, Address newAddress)
    {
        if (string.IsNullOrWhiteSpace(oldCity))
            throw new ArgumentNullException(nameof(oldCity));
        _oldCity = oldCity.Trim();
        _newAddress = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
    }

    public void MigrateCustomers(IEnumerable<Customer> customers)
    {
        if (customers == null) throw new ArgumentNullException(nameof(customers));

        foreach (var customer in customers)
        {
            if (customer.Address.City.Equals(_oldCity, StringComparison.OrdinalIgnoreCase))
            {
                customer.ChangeAddress(_newAddress);
            }
        }
    }
}