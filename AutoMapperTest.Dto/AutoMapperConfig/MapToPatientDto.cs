using AutoMapperTest.Domain;

namespace AutoMapperTest.Dto.AutoMapperConfig
{
    public class MapToPatientDto
    {
        public string PatientId { get; set; }
        
        public Hospital Hospital { get; set; }
        
        public HospitalEvents Events { get; set; }
    }
}