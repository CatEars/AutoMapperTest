using MappingToolTest.ApiModels;
using MappingToolTest.Domain;

namespace MappingToolTest.ApiModels
{
    public static partial class PersonMapper
    {
        public static PersonDto AdaptToDto(this Person p1)
        {
            return p1 == null ? null : new PersonDto()
            {
                Name = p1.Name,
                Age = p1.Age,
                DateOfBirth = p1.DateOfBirth
            };
        }
        public static PersonDto AdaptTo(this Person p2, PersonDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            PersonDto result = p3 ?? new PersonDto();
            
            result.Name = p2.Name;
            result.Age = p2.Age;
            result.DateOfBirth = p2.DateOfBirth;
            return result;
            
        }
    }
}