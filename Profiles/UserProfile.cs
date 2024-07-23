using AutoMapper;
using ServerApi.Dtos.UserDtos;

namespace ServerApi.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, UserDto>()
                .ForMember(dest => dest.RecenziiId, opt => opt.MapFrom(src => src.Recenzii.Select(recenzie => recenzie.Id)))
                .ReverseMap();
            CreateMap<Models.User, CreateUserDto>().ReverseMap();
            CreateMap<Models.User, UpdateUserDto>().ReverseMap();
        }
    }
}
