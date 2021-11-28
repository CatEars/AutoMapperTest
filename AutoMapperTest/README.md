# AutoMapperTest

A repository where I try to learn a bit about Auto Mapper to see what I like and don't like about it.

## Current Worries

A) How seamless is it using records with automapper?
B)

## Current Happies

You can create automatic tests to verify that all the properties of a DTO will be filled by some source property.
Maybe AutoMapper cannot result in a compile time issue when something is not properly mapped, but if we are diligent
with writing tests for our profiles, then we can catch them in the testing phase, which is the next best thing compared
to compile time errors.

I would argue that this only alleviates the issue. With the "straightforward" solution

## Current Issues

AutoMapper is based on convention. If your DTOs look very similar to your internal data structures (domain objects) 
then it takes **a little** bit less time out of writing conversion code. I don't like that the only selling point 
on their own website (under "Why use AutoMapper?") is that it is boring to write conversions. I think that it 
is boring+annoying to debug AutoMapper converting a guid to a string...

AutoMapper is literally an object to object mapper. If the way you model your DTOs and the way you model your domain do not align,
AutoMapper is not the right tool. AutoMapper is an object to object mapper, not a conversion framework.

AutoMapper does not fit well when your DTOs are very different from your internal structures. For example if the internal structure
is Event Sourced you generally do not expose that through DTOs, but instead only the computed model. For an application
like that most properties of the DTOs will be computed. You gain nothing with AutoMapper. Additionally, I see it as a risk
that using AutoMapper will unconsciously make you tie your domain objects to your DTOs, which should be separated.

It relies heavily on reflection. This tends to be hard to understand. It is hard to say exactly what the output of some conversion
is going to be.


# Comparison

AutoMapper is made to save time, but THE ONLY place that I managed to find that it saves time is when the names of the properties
on your domain objects align with your DTO. In the documentation this is disguised as a good thing by calling it
"Conventions-based", and "by following AutoMappers conventions". In reality tough, the naive solution (creating the function `convertXToY()`) 
has the following advantages over AutoMapper:

1. There is nothing you need to learn except C# to read the code.
   1. Included in this point is that there is very little overhead to understanding the "naive solution". You "just read the code".
2. The compiler will statically check that your conversions are valid, without having to create a specialized test for checking config, like you need to with AutoMapper.
   1. Additionally, you cannot screw this up by forgetting to create the test. Do you know what method to call to check that the config is valid in the back of your head? How do you know each conversion is actually being checked?
3. It is trivial to find where the properties of a domain object/DTO is used, with AutoMapper some usages will be hidden as they are discovered with reflection.
4. Only explicit conversions will be allowed. Issues where guids are turned to strings will never occur.
   1. I could not find an easy way to disable default mappings, so that all mappings need to be explicit.
5. If AutoMapper misbehaves it will take a lot of time to find "why did it misbehave?". It will not take a lot of time with the "naive solution".
6. With the naive solution you rely only on the standard library, and not on a third-party library.
7. If your DTOs are very different from your domain model (e.g. `AutoMapperTest.Dto` vs. `AutoMapperTest.Domain`), then AutoMapper is just "The naive solution, but with more steps".
   1. Related to this is that AutoMapper maps one (1) object to one (1) object. It does not work well with 

These are the pros that AutoMapper has over the naive solution, as I consider it.

1. If you follow AutoMappers conventions, it will save you from writing ~10-20 lines of code per Domain -> DTO conversion
2. AutoMapper will automatically handle nested structures