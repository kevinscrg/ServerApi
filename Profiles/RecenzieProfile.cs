using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;

namespace ServerApi.Profiles
{
    public class RecenzieProfile:Profile
    {
        public RecenzieProfile()
        {
            CreateMap<Models.Recenzie, RecenzieDto>().ReverseMap();
            CreateMap<Models.Recenzie, CreateRecenzieDto>().ReverseMap();
        }
    }
}
