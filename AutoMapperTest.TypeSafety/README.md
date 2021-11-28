# Type Safety

Since AutoMapper relies on reflection and type conversions it should come as no surprise that
it is far from type safe.

There is no way to guard yourself against sending in an object with the wrong type to `mapper.Map()`.

AutoMapper will happily try to convert whatever you throw at it, with no guarantee that it will actually
be able to convert it into something sensible.

The "naive" solution would produce a compilation error in this case, since the compiler cares about types.
AutoMapper always converts to `object`...