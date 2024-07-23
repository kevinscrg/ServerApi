using AutoMapper;
using ServerApi.Dtos.OtherDtos;

namespace ServerApi.Profiles
{
    public class GenProfile : Profile
    {
        public GenProfile()
        {
            CreateMap<Models.Gen, GenDto>().ReverseMap();
        }
    }
}
