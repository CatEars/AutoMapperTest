using System;
using AutoMapper;

namespace AutoMapperTest.DifferentDomain
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Middle object");
            MiddleObject.Run();
            Console.WriteLine("Double apply");
            DoubleApply.Run();
        }
    }
}