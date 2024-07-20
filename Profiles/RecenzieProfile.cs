using AutoMapper;
using ServerApi.Dtos;

namespace ServerApi.Profiles
{
    public class RecenzieProfile:Profile
    {
        public RecenzieProfile()
        {
            CreateMap<Models.Recenzie, RecenzieDto>().ReverseMap();
        }
    }
}
