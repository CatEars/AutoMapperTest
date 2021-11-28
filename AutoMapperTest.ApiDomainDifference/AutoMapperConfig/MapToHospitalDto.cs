using System.Collections.Generic;
using AutoMapperTest.ApiDomainDifference.Dto;
using Hospital = AutoMapperTest.ApiDomainDifference.Domain.Hospital;
using HospitalEvents = AutoMapperTest.ApiDomainDifference.Domain.HospitalEvents;

namespace AutoMapperTest.ApiDomainDifference.AutoMapperConfig
{
    internal class MapToHospitalDto
    {
        public Hospital Hospital { get; set; }
        
        public HospitalEvents Events { get; set; }

        public List<RoomDto> CalculateRooms()
        {
            throw new System.NotImplementedException();
        }

        public List<PatientDto> CalculateAdmittedPatients()
        {
            throw new System.NotImplementedException();
        }
    }
}