using AutoMapper;
using ServerApi.Dtos;

namespace ServerApi.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, UserDto>().ReverseMap();
        }
    }
}
