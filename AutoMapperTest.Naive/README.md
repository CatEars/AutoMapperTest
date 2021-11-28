# Naive solution

I reference the "naive" solution a bit of everywhere so I included this example to show
what the "naive" solution to converting from a domain object to an equivalent DTO looks like.

In some cases we just need to create the function `ConvertXToY` but sometimes we need to
create more than one conversion function. For example when we have a domain object composed
of several other domain objects. In such a case we have to create more than one function.