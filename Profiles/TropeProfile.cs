using AutoMapper;

namespace ServerApi.Profiles
{
    public class TropeProfile : Profile
    {
        public TropeProfile()
        {
            CreateMap<Models.Trope, Dtos.TropeDto>().ReverseMap();
        }
    }
}
