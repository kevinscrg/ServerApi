using AutoMapper;
using ServerApi.Dtos.OtherDtos;

namespace ServerApi.Profiles
{
    public class TropeProfile : Profile
    {
        public TropeProfile()
        {
            CreateMap<Models.Trope, TropeDto>().ReverseMap();
        }
    }
}
