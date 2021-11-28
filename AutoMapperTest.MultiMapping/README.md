# Multi Mapping

The multi-mapping problem arises because there is no clear way to map from multiple source objects into
a single destination object using AutoMapper.

There are two main solutions, none that great.

The first solution I called "Double Apply". The solution is to map several objects onto one single type
and then apply each mapping several times onto the same destination object.

The second solution I called "Middle Object". The solution is to create an intermediate class that contains
all necessary information to map from one 

# Double Apply

With Double Apply you no longer make it possible to assert that a configuration is valid. This means that
the "safety pin" that checks that AutoMapper does what it "should" do is effectively broken.

This is not an acceptable solution.

# Middle Object

Let's start from the beginning. Why do we choose to use AutoMapper? In order to write less code, so that
we do not have to create any conversion code to begin with. If we have to create an object that encapsulates
all data necessary for AutoMapper to work correctly we will end up in an eerily similar situation
as if we had gone down the route of implementing the "naive solution" without AutoMapper.

In other words, the middle object could just as well be the DTO and we are effectively using AutoMapper
just for the sake of using AutoMapper. This is not an acceptable solution.

# Conclusion

Unless your mappings between your domain and your DTOs perfectly match single object to single external objects,
then AutoMapper is NOT usable.