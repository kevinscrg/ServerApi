using AutoMapper;

namespace ServerApi.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, DTOs.UserDto>().ReverseMap();
        }
    }
}
