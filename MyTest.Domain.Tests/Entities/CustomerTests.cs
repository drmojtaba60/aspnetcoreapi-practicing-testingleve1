using MyTest.Domain.Entities;
using MyTest.Domain.Events;
using MyTest.Domain.ValueObjects;

namespace MyTest.Domain.Tests.Entities;
using Xunit;

public class CustomerTests
{
    [Fact]
    public void Constructor_ValidValues_ShouldCreateCustomer()
    {
        var id = Guid.NewGuid();
        var address = new Address("Street", "City", "Zip");
        var customer = new Customer(id, "Ali", address);

        Assert.Equal(id, customer.Id);
        Assert.Equal("Ali", customer.Name);
        Assert.Equal(address, customer.Address);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Constructor_InvalidName_ShouldThrow(string name)
    {
        var id = Guid.NewGuid();
        var address = new Address("Street", "City", "Zip");

        Assert.Throws<ArgumentNullException>(() => new Customer(id, name, address));
    }

    [Fact]
    public void Constructor_NullAddress_ShouldThrow()
    {
        var id = Guid.NewGuid();
        Assert.Throws<ArgumentNullException>(() => new Customer(id, "Ali", null));
    }

    [Fact]
    public void ChangeAddress_Valid_ShouldUpdateAddress()
    {
        var customer = new Customer(Guid.NewGuid(), "Ali", new Address("Old St", "Old City", "1111"));
        var newAddress = new Address("New St", "New City", "2222");

        customer.ChangeAddress(newAddress);

        Assert.Equal(newAddress, customer.Address);
    }

    [Fact]
    public void ChangeName_Valid_ShouldUpdateName()
    {
        var customer = new Customer(Guid.NewGuid(), "Ali", new Address("St", "City", "1111"));

        customer.ChangeName("Reza");

        Assert.Equal("Reza", customer.Name);
    }

    [Fact]
    public void ChangeName_Invalid_ShouldThrow()
    {
        var customer = new Customer(Guid.NewGuid(), "Ali", new Address("St", "City", "1111"));

        Assert.Throws<ArgumentNullException>(() => customer.ChangeName(""));
    }
    
    /// <summary>
    /// تست اونت Event Driven
    /// </summary>
    [Fact]
    public void ChangeAddress_ShouldRaise_CustomerAddressChangedEvent()
    {
        // Arrange
        var customer = new Customer(Guid.NewGuid(), "Ali", new Address("Valiasr", "Tehran", "123"));
        var newAddress = new Address("Azadi", "Mashhad", "456");

        // Act
        customer.ChangeAddress(newAddress);

        // Assert
        var domainEvent = customer.DomainEvents.OfType<CustomerAddressChangedEvent>().FirstOrDefault();
        Assert.NotNull(domainEvent);
        Assert.Equal(customer.Id, domainEvent.CustomerId);
        Assert.Equal(newAddress, domainEvent.NewAddress);
    }
}
