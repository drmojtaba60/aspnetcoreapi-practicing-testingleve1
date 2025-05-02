namespace MyTest.Domain.Tests.ValueObjects;
using MyTest.Domain.ValueObjects;
using Xunit;

public class EmailTests
{
    [Fact]
    public void Constructor_ValidEmail_ShouldSetValue()
    {
        // Arrange
        var address = "user@example.com";

        // Act
        var email = new Email(address);

        // Assert
        Assert.Equal(address, email.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("invalid-email")]
    [InlineData("user@")]
    [InlineData("@example.com")]
    [InlineData("user@.com")]
    public void Constructor_InvalidEmail_ShouldThrow(string invalidEmail)
    {
        Assert.ThrowsAny<Exception>(() => new Email(invalidEmail));
    }

    [Fact]
    public void Equality_TwoSameEmails_ShouldBeEqual()
    {
        var email1 = new Email("user@example.com");
        var email2 = new Email("user@example.com");

        Assert.Equal(email1, email2);
        Assert.True(email1 == email2);
    }

    [Fact]
    public void Equality_TwoDifferentEmails_ShouldNotBeEqual()
    {
        var email1 = new Email("user1@example.com");
        var email2 = new Email("user2@example.com");

        Assert.NotEqual(email1, email2);
        Assert.True(email1 != email2);
    }
}