using System;
using AutoMapper;

namespace AutoMapperTest.HiddenUsage
{
    class Program
    {

        public static void Run()
        {
            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.CreateMap<Person, PersonDto>()
                    .ForMember(x => x.Height,
                        opt => opt.MapFrom(person => person.HeightInCm));
            });

            var mapper = mapperConfig.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            var person = new Person("John Doe", 179);
            var result = mapper.Map<PersonDto>(person);
            Console.WriteLine("Name: " + result.Name);
            Console.WriteLine("Height: " + result.Height);
        }
        
        static void Main(string[] args)
        {
            Run();
        }
    }
}