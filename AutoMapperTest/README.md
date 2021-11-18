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

