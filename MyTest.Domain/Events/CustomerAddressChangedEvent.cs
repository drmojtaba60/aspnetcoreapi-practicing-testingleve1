using MyTest.Domain.Common;
using MyTest.Domain.ValueObjects;

namespace MyTest.Domain.Events;

public class CustomerAddressChangedEvent : IDomainEvent
{
    public Guid CustomerId { get; }
    public Address NewAddress { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public CustomerAddressChangedEvent(Guid customerId, Address newAddress)
    {
        CustomerId = customerId;
        NewAddress = newAddress;
    }
}
