using System.Collections.Immutable;

namespace AutoMapperTest.Domain
{
    public record Hospital(string Name, ImmutableList<Room> Rooms);
}