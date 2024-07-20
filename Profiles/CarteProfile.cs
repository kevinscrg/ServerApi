using AutoMapper;

namespace ServerApi.Profiles
{
    public class CarteProfile : Profile
    {
        public CarteProfile()
        {
            CreateMap<Models.Carte, DTOs.CarteDto>().ReverseMap();
        }
    }
}
