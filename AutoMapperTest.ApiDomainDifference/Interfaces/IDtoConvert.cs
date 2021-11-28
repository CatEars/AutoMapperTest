using AutoMapperTest.ApiDomainDifference.Dto;
using Hospital = AutoMapperTest.ApiDomainDifference.Domain.Hospital;
using HospitalEvents = AutoMapperTest.ApiDomainDifference.Domain.HospitalEvents;

namespace AutoMapperTest.ApiDomainDifference.Interfaces
{
    public interface IDtoConvert
    {

        public IDtoConvert WithHospital(Hospital hospital);

        public IDtoConvert WithEvents(HospitalEvents events);

        public HospitalDto GetHospital();

        public PatientDto GetPatient(string patientId);
        
    }
}