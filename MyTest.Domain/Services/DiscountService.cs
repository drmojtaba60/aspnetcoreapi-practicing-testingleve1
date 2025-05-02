namespace MyTest.Domain.Services;

public class DiscountService
{
    public decimal CalculateDiscount(decimal totalAmount, bool isVip)
    {
        if (totalAmount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        if (isVip)
            return totalAmount * 0.2m;

        return totalAmount * 0.05m;
    }
}