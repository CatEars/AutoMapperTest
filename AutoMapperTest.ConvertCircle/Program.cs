using System;
using AutoMapper;

namespace AutoMapperTest.ConvertCircle
{

    class CircularDependencyClassInternal
    {
        public CircularDependencyClassInternal? Circle { get; set; }
        public string Name { get; set; }

        public CircularDependencyClassInternal(string name, CircularDependencyClassInternal? circle)
        {
            Name = name;
            Circle = circle;
        }
    }

    class CircularDependencyClassDto
    {
        public CircularDependencyClassDto? Circle { get; set; }
        public string Name { get; set; }
        
        public CircularDependencyClassDto(string name, CircularDependencyClassDto? circle)
        {
            Name = name;
            Circle = circle;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new CircularDependencyClassInternal("A", null);
            var b = new CircularDependencyClassInternal("B", null);
            a.Circle = b;
            b.Circle = a;
            Console.WriteLine("5 times: " + a.Circle!.Circle!.Circle!.Circle!.Circle!.Name);

            var mapperConfig = new MapperConfiguration(opt =>
            {
                opt.CreateMap<CircularDependencyClassInternal, CircularDependencyClassDto>();
            });

            var mapper = mapperConfig.CreateMapper();
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            var x = mapper.Map<CircularDependencyClassDto>(a);
            Console.WriteLine("1=" + x.Name);
            Console.WriteLine("2=" + x.Circle.Name);
            Console.WriteLine("3=" + x.Circle.Circle.Name);
        }
    }
}