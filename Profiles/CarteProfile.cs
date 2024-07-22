using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.UpdateDtos;

namespace ServerApi.Profiles
{
    public class CarteProfile : Profile
    {
        public CarteProfile()
        {
            CreateMap<Models.Carte, CarteDto>()
                .ForMember(dest => dest.Genuri, opt => opt.MapFrom(src => src.Genuri.Select(gen => gen.Nume).ToList()))
                .ForMember(dest => dest.Tropeuri, opt => opt.MapFrom(src => src.Tropeuri.Select(trope => trope.Nume).ToList()))
                .ForMember(dest => dest.RecenziiText, opt => opt.MapFrom(src => src.Recenzii.Select(recenzie => recenzie.Text).ToList()))
                .ForMember(dest => dest.RecenziiRating, opt => opt.MapFrom(src => src.Recenzii.Select(recenzie => recenzie.Rating).ToList()))
                .ReverseMap();

            CreateMap<Models.Carte, CreateCarteDto>().ReverseMap();

            CreateMap<Models.Carte, UpdateCarteDto>().ReverseMap();
        }
    }
}
