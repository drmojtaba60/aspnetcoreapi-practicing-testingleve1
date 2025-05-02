using MyTest.Domain.ValueObjects;

namespace MyTest.Domain.Tests.ValueObjects;

public class AddressTests
{
    [Fact]
    public void Constructor_ValidValues_ShouldSetProperties()
    {
        var address = new Address("123 Main St", "Tehran", "11111");

        Assert.Equal("123 Main St", address.Street);
        Assert.Equal("Tehran", address.City);
        Assert.Equal("11111", address.ZipCode);
    }

    [Theory]
    [InlineData("", "City", "Zip")]
    [InlineData("Street", "", "Zip")]
    [InlineData("Street", "City", "")]
    [InlineData(null, "City", "Zip")]
    [InlineData("Street", null, "Zip")]
    [InlineData("Street", "City", null)]
    public void Constructor_InvalidValues_ShouldThrow(string street, string city, string zip)
    {
        Assert.ThrowsAny<Exception>(() => new Address(street, city, zip));
    }

    [Fact]
    public void Equality_TwoSameAddresses_ShouldBeEqual()
    {
        var a1 = new Address("Street A", "City A", "12345");
        var a2 = new Address("Street A", "City A", "12345");

        Assert.Equal(a1, a2);
        Assert.True(a1 == a2);
        Assert.False(a1 != a2);
    }

    [Fact]
    public void Equality_TwoDifferentAddresses_ShouldNotBeEqual()
    {
        var a1 = new Address("Street A", "City A", "12345");
        var a2 = new Address("Street B", "City A", "12345");

        Assert.NotEqual(a1, a2);
        Assert.True(a1 != a2);
    }
}