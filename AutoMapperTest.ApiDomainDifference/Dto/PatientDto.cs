using System;

namespace AutoMapperTest.ApiDomainDifference.Dto
{
    public class PatientDto
    {
        public string PatientId { get; set; }

        public RoomDto? StayingInRoom { get; set; }
        
        public DateTime? LastHospitalAdmittance { get; set; }
        
        public DateTime? LastHospitalDischarge { get; set; }
    }

}