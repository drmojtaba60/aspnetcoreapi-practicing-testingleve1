namespace MyTest.Domain.Tests.Services
{
    using MyTest.Domain.Services;
    using Xunit;

    public class DiscountServiceTests
    {
        private readonly DiscountService _service = new();

        [Fact]
        public void CalculateDiscount_VipCustomer_ShouldReturn20Percent()
        {
            // Arrange
            decimal amount = 1000;
            bool isVip = true;

            // Act
            var discount = _service.CalculateDiscount(amount, isVip);

            // Assert
            Assert.Equal(200, discount);
        }

        [Fact]
        public void CalculateDiscount_NormalCustomer_ShouldReturn5Percent()
        {
            // Arrange
            decimal amount = 1000;
            bool isVip = false;

            // Act
            var discount = _service.CalculateDiscount(amount, isVip);

            // Assert
            Assert.Equal(50, discount);
        }

        [Fact]
        public void CalculateDiscount_ZeroAmount_ShouldThrow()
        {
            // Arrange
            decimal amount = 0;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateDiscount(amount, true));
        }
    }
}