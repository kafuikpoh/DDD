using DDD.Domain.HostAggregate.ValueObjects;

namespace DDD.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Host
    {
        public static readonly HostId Id = HostId.Create("host id");
    }
}