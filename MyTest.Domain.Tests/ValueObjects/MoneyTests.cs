using MyTest.Domain.ValueObjects;

namespace MyTest.Domain.Tests.ValueObjects;

public class MoneyTests
{
    [Fact]
    public void Constructor_ValidValues_ShouldSetProperties()
    {
        var money = new Money(100, "usd");

        Assert.Equal(100, money.Amount);
        Assert.Equal("USD", money.Currency); // normalized
    }

    [Theory]
    [InlineData(-10, "USD")]
    [InlineData(100, "")]
    [InlineData(100, null)]
    //[InlineData(100, "USD00000")]
    public void Constructor_InvalidValues_ShouldThrow(decimal amount, string currency)
    {
        Assert.ThrowsAny<Exception>(() => new Money(amount, currency));
    }

    [Fact]
    public void Add_SameCurrency_ShouldReturnCorrectSum()
    {
        var m1 = new Money(50, "EUR");
        var m2 = new Money(20, "EUR");

        var result = m1.Add(m2);

        Assert.Equal(new Money(70, "EUR"), result);
    }

    [Fact]
    public void Add_DifferentCurrencies_ShouldThrow()
    {
        var m1 = new Money(50, "USD");
        var m2 = new Money(10, "EUR");

        Assert.Throws<InvalidOperationException>(() => m1.Add(m2));
    }

    [Fact]
    public void Equality_SameAmountAndCurrency_ShouldBeEqual()
    {
        var m1 = new Money(100, "USD");
        var m2 = new Money(100, "USD");

        Assert.Equal(m1, m2);
        Assert.True(m1 == m2);
    }

    [Fact]
    public void Equality_DifferentAmountOrCurrency_ShouldNotBeEqual()
    {
        var m1 = new Money(100, "USD");
        var m2 = new Money(200, "USD");
        var m3 = new Money(100, "EUR");

        Assert.NotEqual(m1, m2);
        Assert.NotEqual(m1, m3);
    }
}