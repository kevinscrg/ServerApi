using AutoMapper;
using ServerApi.Dtos;

namespace ServerApi.Profiles
{
    public class CarteProfile : Profile
    {
        public CarteProfile()
        {
            CreateMap<Models.Carte, CarteDto>().ReverseMap();
        }
    }
}
