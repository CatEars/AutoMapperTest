using System;
using AutoMapper;

namespace AutoMapperTest.DifferentDomain
{
    public class DoubleApply
    {
        
        class Person
        {
            public string Name { get; set; }
        }

        class Address
        {
            public string Street { get; set; }
        }

        class PersonDto
        {
            public string Name { get; set; }
            public string Street { get; set; }
        }

        public static void Run()
        {
            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.CreateMap<Person, PersonDto>();
                opt.CreateMap<Address, PersonDto>();
            });

            var mapper = mapperConfig.CreateMapper();
            // Try with/without assertion.
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            var person = new Person()
            {
                Name = "John Doe"
            };
            var street = new Address()
            {
                Street = "Upper livington upon stratford-shire"
            };
            var result = mapper.Map<PersonDto>(person);
            result = mapper.Map(street, result);
            Console.WriteLine("Name: " + result.Name);
            Console.WriteLine("Street: " + result.Street);
        }
        
    }
}