# Hidden Usage

Since AutoMapper relies on reflection to find properties, it effectively
hides where your internal DTOs are used from the compiler.

In this example it is not possible to see that `Name` is a property that is necessary to exist
on the `Person` object. It is not trivial to find exactly where it is used in a larger code base.

With AutoMapper "you just have to know where it is used" but with the "naive" solution your
IDE could lead you to the right place with no fuzz.

A big minus for AutoMapper is that it makes it unclear if you can refactor a type. How would you
know if AutoMapper required your property to be named in a specific way? You cannot check where
the property is used. You have to manually scan all places where AutoMapper might use it. If
there is a test suite for your conversions with AutoMapper, can you trust that the test suite
is up to date and checks everything?