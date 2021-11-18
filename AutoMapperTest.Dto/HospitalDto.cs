using System.Collections.Generic;

namespace AutoMapperTest.Dto
{
    public class HospitalDto
    {
        public string Name { get; set; }
        
        public List<RoomDto> Rooms { get; set; }
        
        public List<PatientDto> CurrentlyAdmittedPatients { get; set; }
        
    }
}