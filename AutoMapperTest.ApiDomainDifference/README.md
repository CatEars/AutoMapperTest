# Api Domain Difference

When creating an API for our software, we can choose to represent the DTOs in
our API with a big difference compared to our internal models.

An example of this would be where our internal models is stored in a time series
database, but from the API perspective we are only interested in the current state.

In this project I created such a scenario. The system keeps track of patient
admissions and discharges. The external API only cares about currently admitted patients,
while the internal domain keeps full track of every single event in the chain as individual
events.

# Conclusion

AutoMapper handles this case exceptionally poorly. Creating the "naive" conversion is simple, 
straight-forward, and readable. However AutoMapper becomes a real hassle. It is not possible
to leverage the strengths of AutoMapper in this case.

The main reason being that there is no clear match from one internal object to another 
external object. There is only slight overlap of the data between the internal objects and
the external objects.
