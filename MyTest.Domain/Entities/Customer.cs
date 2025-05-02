using MyTest.Domain.Common;
using MyTest.Domain.Events;
using MyTest.Domain.ValueObjects;

namespace MyTest.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    private Customer()
    {
    } // for EF Core

    public Customer(Guid id, string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Name is required");

        Id = id;
        Name = name;
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    // public void ChangeAddress(Address newAddress)
    // {
    //     if (newAddress is null)
    //         throw new ArgumentNullException(nameof(newAddress));
    //
    //     Address = newAddress;
    // }
    public void ChangeAddress(Address newAddress)
    {
        if (newAddress is null)
            throw new ArgumentNullException(nameof(newAddress));

        Address = newAddress;
        // اضافه کردن Event به لیست داخلی
        _domainEvents.Add(new CustomerAddressChangedEvent(Id, newAddress));
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentNullException(nameof(newName));

        Name = newName;
    }


    public void ClearEvents() => _domainEvents.Clear();
}