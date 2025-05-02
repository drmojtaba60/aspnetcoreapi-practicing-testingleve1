using MyTest.Infrastructure.Persistence;

namespace MyTest.PersistenceTests.Repositories;
using Xunit;
using Microsoft.EntityFrameworkCore;
using MyTest.Domain.Entities;
using MyTest.Infrastructure.Persistence;

public class CustomerRepositoryTests
{
    private AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // isolated test
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public async Task AddAndGetCustomer_WorksCorrectly()
    {
        // Arrange
        var context = CreateContext();
        var repository = new CustomerRepository(context);

        var customer = new Customer(Guid.NewGuid(), "Ali", new("Azadi", "Tehran", "123"));

        // Act
        await repository.AddAsync(customer);
        await context.SaveChangesAsync(); // EF doesn't persist until SaveChangesAsync

        var result = await repository.GetByIdAsync(customer.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Ali", result!.Name);
        Assert.Equal("Tehran", result.Address.City);
    }

    [Fact]
    public async Task DeleteCustomer_RemovesIt()
    {
        // Arrange
        var context = CreateContext();
        var repository = new CustomerRepository(context);
        var customer = new Customer(Guid.NewGuid(), "Sara", new("Elm", "Shiraz", "321"));
        await repository.AddAsync(customer);
        await context.SaveChangesAsync();

        // Act
        await repository.DeleteAsync(customer);
        await context.SaveChangesAsync();

        // Assert
        var result = await repository.GetByIdAsync(customer.Id);
        Assert.Null(result);
    }
}
