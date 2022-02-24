using System;

namespace MappingToolTest.ApiModels
{
    public partial record PersonDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}