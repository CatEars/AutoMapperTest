using AutoMapperTest.Domain;

namespace AutoMapperTest.Dto.Interfaces
{
    public interface IDtoConvert
    {

        public IDtoConvert WithHospital(Hospital hospital);

        public IDtoConvert WithEvents(HospitalEvents events);

        public HospitalDto GetHospital();

        public PatientDto GetPatient(string patientId);
        
    }
}