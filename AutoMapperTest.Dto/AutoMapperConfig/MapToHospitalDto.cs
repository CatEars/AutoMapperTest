﻿using AutoMapperTest.Domain;

namespace AutoMapperTest.Dto.AutoMapperConfig
{
    internal class MapToHospitalDto
    {
        public Hospital Hospital { get; set; }
        
        public HospitalEvents Events { get; set; }
    }
}