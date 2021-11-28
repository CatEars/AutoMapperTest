using System;
using Hospital = AutoMapperTest.ApiDomainDifference.Domain.Hospital;
using HospitalEvents = AutoMapperTest.ApiDomainDifference.Domain.HospitalEvents;
using Room = AutoMapperTest.ApiDomainDifference.Domain.Room;

namespace AutoMapperTest.ApiDomainDifference.AutoMapperConfig
{
    public class MapToPatientDto
    {
        public string PatientId { get; set; }
        
        public Hospital Hospital { get; set; }
        
        public HospitalEvents Events { get; set; }

        public DateTime? CalculateLastHospitalAdmittance()
        {
            throw new NotImplementedException();
        }

        public DateTime? CalculateLastHospitalDischarge()
        {
            throw new NotImplementedException();
        }

        public Room? CalculateRoomStay()
        {
            throw new NotImplementedException();
        }
    }
}