using DDD.Domain.Common.Models;

namespace DDD.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerLocation : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public double Longitude { get; private set; }
    public double Latitude { get; private set; }

    private DinnerLocation(string name, string address, double longitude, double latitude)
    {
        Name = name;
        Address = address;
        Longitude = longitude;
        Latitude = latitude;
    }

    public static DinnerLocation Create(string name, string address, double longitude, double latitude)
    {
        return new DinnerLocation(name, address, longitude, latitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Longitude;
        yield return Latitude;
    }

#pragma warning disable CS8618
    private DinnerLocation()
    {
    }
#pragma warning restore CS8618
}