namespace MyTest.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public decimal TotalAmount { get; private set; }

    public Order(string customerName, decimal totalAmount)
    {
        Id = Guid.NewGuid();
        CustomerName = customerName;
        TotalAmount = totalAmount;
    }

    public void ApplyDiscount(decimal percent)
    {
        if (percent < 0 || percent > 100)
            throw new ArgumentOutOfRangeException(nameof(percent), "Discount must be between 0 and 100");

        TotalAmount -= TotalAmount * (percent / 100);
    }
}