using MyTest.Domain.Entities;
using MyTest.Domain.Services;
using MyTest.Domain.ValueObjects;

public class CustomerMigrationServiceTests
{
    [Fact]
    public void MigrateCustomers_CustomersFromOldCity_ShouldUpdateAddress()
    {
        // Arrange
        var oldAddress = new Address("Valiasr", "Tehran", "123");
        var newAddress = new Address("Azadi", "Mashhad", "456");

        var customer1 = new Customer(Guid.NewGuid(), "Ali", oldAddress);
        var customer2 = new Customer(Guid.NewGuid(), "Reza", new Address("Street", "Shiraz", "789"));

        var service = new CustomerMigrationService("Tehran", newAddress);

        // Act
        service.MigrateCustomers(new[] { customer1, customer2 });

        // Assert
        Assert.Equal(newAddress, customer1.Address);  // باید آدرس عوض شده باشه
        Assert.NotEqual(newAddress, customer2.Address); // نباید عوض شده باشه
    }

    [Fact]
    public void MigrateCustomers_NullInput_ShouldThrow()
    {
        var newAddress = new Address("Azadi", "Mashhad", "456");
        var service = new CustomerMigrationService("Tehran", newAddress);

        Assert.Throws<ArgumentNullException>(() => service.MigrateCustomers(null));
    }

    [Fact]
    public void Constructor_NullAddress_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new CustomerMigrationService("Tehran", null));
    }

    [Fact]
    public void Constructor_InvalidOldCity_ShouldThrow()
    {
        var newAddress = new Address("Azadi", "Mashhad", "456");
        Assert.Throws<ArgumentNullException>(() => new CustomerMigrationService(null, newAddress));
    }
}