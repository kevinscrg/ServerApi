using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;

namespace ServerApi.Profiles
{
    public class CarteProfile : Profile
    {
        public CarteProfile()
        {
            CreateMap<Models.Carte, CarteDto>()
                .ForMember(dest => dest.Genuri, opt => opt.MapFrom(src => src.Genuri.Select(gen => gen.Nume).ToList()))
                .ForMember(dest => dest.Tropeuri, opt => opt.MapFrom(src => src.Tropeuri.Select(trope => trope.Nume).ToList()))
                .ReverseMap();
            CreateMap<Models.Carte, CreateCarteDto>().ReverseMap();
        }
    }
}
