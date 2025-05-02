namespace MyTest.Domain.ValueObjects;
public sealed class Address : IEquatable<Address>
{
    public string Street { get; }
    public string City { get; }
    public string ZipCode { get; }
    // سازنده عمومی برای EF Core
    public Address() { }
    public Address(string street, string city, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentNullException(nameof(street), "Street is required");

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentNullException(nameof(city), "City is required");

        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentNullException(nameof(zipCode), "ZipCode is required");

        Street = street.Trim();
        City = city.Trim();
        ZipCode = zipCode.Trim();
    }

    public override string ToString() => $"{Street}, {City}, {ZipCode}";

    public override bool Equals(object? obj) => Equals(obj as Address);

    public bool Equals(Address? other)
    {
        if (other is null) return false;
        return Street == other.Street && City == other.City && ZipCode == other.ZipCode;
    }

    public override int GetHashCode() => HashCode.Combine(Street, City, ZipCode);

    public static bool operator ==(Address? left, Address? right) => Equals(left, right);
    public static bool operator !=(Address? left, Address? right) => !Equals(left, right);
}
