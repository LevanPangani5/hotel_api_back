using AutoMapper;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;

namespace WebApplication1
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Lector, LectorAddDto>().ReverseMap();
            CreateMap<User,UserLoginDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<Hotel,HotelAddDto>().ReverseMap();
            CreateMap<Room,RoomAddDto>().ReverseMap();  
            CreateMap<RoomType,RoomTypeGetDto>().ReverseMap();
            CreateMap<Booking,BookingAddDto>().ReverseMap();
            CreateMap<RoomFilter, DateFilter>().ReverseMap();
            CreateMap<DateFilter, BookingAddDto>().ReverseMap();
        }
    }
}
