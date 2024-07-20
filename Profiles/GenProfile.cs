using AutoMapper;

namespace ServerApi.Profiles
{
    public class GenProfile : Profile
    {
        public GenProfile()
        {
            CreateMap<Models.Gen, Dtos.GenDto>().ReverseMap();
        }
    }
}
