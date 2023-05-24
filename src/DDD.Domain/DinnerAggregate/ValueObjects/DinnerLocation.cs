using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerLocation : ValueObject
{
    public string Name { get; } = null!;
    public string Address { get; } = null!;
    public double Longitude { get; }
    public double Latitude { get; }
    public DinnerLocation(string name, string address, double longitude, double latitude)
    {
        Name = name;
        Address = address;
        Longitude = longitude;
        Latitude = latitude;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Longitude;
        yield return Latitude;
    }
}