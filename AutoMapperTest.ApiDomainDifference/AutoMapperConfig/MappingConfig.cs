using AutoMapper;
using AutoMapperTest.ApiDomainDifference.Dto;
using Room = AutoMapperTest.ApiDomainDifference.Domain.Room;

namespace AutoMapperTest.ApiDomainDifference.AutoMapperConfig
{
    public static class MappingConfig
    {

        public static MapperConfiguration Create()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MapToHospitalDto, HospitalDto>()
                    .ForMember(x => x.Rooms,
                        opt => opt.MapFrom(mapObj => mapObj.CalculateRooms()))
                    .ForMember(x => x.CurrentlyAdmittedPatients,
                        opt => opt.MapFrom(mapObj => mapObj.CalculateAdmittedPatients()));
                
                
                cfg.CreateMap<MapToPatientDto, PatientDto>()
                    .ForMember(x => x.LastHospitalAdmittance,
                        opt => opt.MapFrom(mapObj => mapObj.CalculateLastHospitalAdmittance()))
                    .ForMember(x => x.LastHospitalDischarge,
                        opt => opt.MapFrom(mapObj => mapObj.CalculateLastHospitalDischarge()))
                    .ForMember(x => x.StayingInRoom,
                        opt => opt.MapFrom(mapObj => mapObj.CalculateRoomStay()));
                
                
                cfg.CreateMap<Room, RoomDto>()
                    .ForMember(x => x.Name, 
                        opt => opt.MapFrom(room => $"{room.Floor} - ${room.Name}"));
            });
        }
        
    }
}