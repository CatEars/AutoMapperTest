using System;
using AutoMapper;
using AutoMapperTest.ApiDomainDifference.Dto;
using AutoMapperTest.ApiDomainDifference.Interfaces;
using Hospital = AutoMapperTest.ApiDomainDifference.Domain.Hospital;
using HospitalEvents = AutoMapperTest.ApiDomainDifference.Domain.HospitalEvents;

namespace AutoMapperTest.ApiDomainDifference.AutoMapperConfig
{
    public class AutoMapperConvert : IDtoConvert
    {
        private Hospital? _hospital;

        private HospitalEvents _events = HospitalEvents.Empty;

        private readonly IMapper _mapper = MappingConfig.Create().CreateMapper();
        
        public IDtoConvert WithHospital(Hospital hospital)
        {
            _hospital = hospital;
            return this;
        }

        public IDtoConvert WithEvents(HospitalEvents events)
        {
            _events = events;
            return this;
        }

        public HospitalDto GetHospital()
        {
            if (_hospital == null)
            {
                throw new Exception("No hospital");
            }

            return _mapper.Map<HospitalDto>(new MapToHospitalDto()
            {
                Events = _events,
                Hospital = _hospital
            });
        }

        public PatientDto GetPatient(string patientId)
        {
            if (_hospital == null)
            {
                throw new Exception("No hospital");
            }

            return _mapper.Map<PatientDto>(new MapToPatientDto()
            {
                PatientId = patientId,
                Events = _events,
                Hospital = _hospital
            });
        }
    }
}