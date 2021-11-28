using System.Collections.Immutable;

namespace AutoMapperTest.ApiDomainDifference.Domain
{
    public record Hospital(string Name, ImmutableList<Room> Rooms);
}