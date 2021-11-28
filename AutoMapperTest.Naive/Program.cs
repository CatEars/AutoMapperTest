using System;

namespace AutoMapperTest.Naive
{
    class Person
    {
        public string Name { get; set; }
    }

    class PersonDto
    {
        public string Name { get; set; }
    }
    
    class Program
    {
        static PersonDto ConvertPersonToDto(Person person)
        {
            return new PersonDto()
            {
                Name = person.Name
            };
        }
        
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Name = "John Doe"
            };
            var dto = ConvertPersonToDto(person);
            Console.WriteLine("Name: " + dto.Name);
        }
    }
}