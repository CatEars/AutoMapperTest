using System;
using AutoMapper;

namespace AutoMapperTest.TypeSafety
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.CreateMap<Person, PersonDto>();
            });

            var mapper = mapperConfig.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            // Here we "accidentally" use the class `NotAPerson` instead of
            // the correct `Person` class.
            var probablyAPerson = new NotPerson()
            {
                Name = "John Derp?"
            };
            var result = mapper.Map<PersonDto>(probablyAPerson);
            Console.WriteLine("Name: " + result.Name);
        }
    }
}