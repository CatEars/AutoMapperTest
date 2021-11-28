# Circular Dependencies

If there is a circular dependency inside of the mapping structure 
(which doesn't have to be class A -> A, but can be class A -> B -> C -> D -> A),
then AutoMapper will NOT understand how to map the objects.

The way to solve this is to no longer use such a constructor to
allow AutoMapper to create the object without needing to first map the dependency.

`mapper.ConfigurationProvider.AssertConfigurationIsValid()` does NOT guard against this.

It is ONLY a runtime error.