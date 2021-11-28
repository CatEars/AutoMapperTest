When the DTO model is different from the underlying data, then https://stackoverflow.com/questions/19544133/automapper-multi-object-source-and-one-destination 
becomes a difficult problem.

The "most reasonable way" to solve this is to create yet another DTO that includes all data necessary to map from internal structure
to external structure.