using System;
using System.Linq;
using AutoMapperTest.Domain;
using AutoMapperTest.Dto.Interfaces;

namespace AutoMapperTest.Dto.AutoMapperConfig
{
    public class AutoMapperConvert : IDtoConvert
    {
        private Hospital? _hospital;

        private HospitalEvents _events = HospitalEvents.Empty;
        
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

            throw new System.NotImplementedException();
        }

        public PatientDto GetPatient(string patientId)
        {
            if (_hospital == null)
            {
                throw new Exception("No hospital");
            }
            throw new System.NotImplementedException();
        }
    }
}