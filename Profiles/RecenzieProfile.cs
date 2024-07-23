using AutoMapper;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.ReceznieDtos;

namespace ServerApi.Profiles
{
    public class RecenzieProfile:Profile
    {
        public RecenzieProfile()
        {
            CreateMap<Models.Recenzie, RecenzieDto>().ReverseMap();
            CreateMap<Models.Recenzie, CreateRecenzieDto>().ReverseMap();
            CreateMap<Models.Recenzie, UpdateRecenzieDto>().ReverseMap();
        }
    }
}
