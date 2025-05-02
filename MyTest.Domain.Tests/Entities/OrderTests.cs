namespace MyTest.Domain.Tests.Entities;
using MyTest.Domain.Entities;
using Xunit;

public class OrderTests
{
    [Fact]
    public void Constructor_ShouldSetProperties()
    {
        // Arrange
        var name = "Ali";
        var total = 500;

        // Act
        var order = new Order(name, total);

        // Assert
        Assert.Equal(name, order.CustomerName);
        Assert.Equal(total, order.TotalAmount);
        Assert.NotEqual(Guid.Empty, order.Id);
    }

    [Fact]
    public void ApplyDiscount_ShouldApplyCorrectly()
    {
        // Arrange
        var order = new Order("Ali", 1000);

        // Act
        order.ApplyDiscount(10);

        // Assert
        Assert.Equal(900, order.TotalAmount);
    }

    [Fact]
    public void ApplyDiscount_InvalidPercent_ShouldThrow()
    {
        // Arrange
        var order = new Order("Ali", 1000);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => order.ApplyDiscount(-5));
        Assert.Throws<ArgumentOutOfRangeException>(() => order.ApplyDiscount(200));
    }
}
