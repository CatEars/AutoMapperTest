using AutoMapper;
using AutoMapperTest.Domain;

namespace AutoMapperTest.Dto.AutoMapperConfig
{
    public static class MappingConfig
    {

        public static MapperConfiguration Create()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MapToHospitalDto, HospitalDto>();
                cfg.CreateMap<MapToHospitalDto, PatientDto>();
                cfg.CreateMap<Room, RoomDto>()
                    .ForMember(x => x.Name, 
                        opt => opt.MapFrom(room => $"{room.Floor} - ${room.Name}"));
            });
        }
        
    }
}