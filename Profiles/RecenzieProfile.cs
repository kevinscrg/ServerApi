using AutoMapper;

namespace ServerApi.Profiles
{
    public class RecenzieProfile:Profile
    {
        public RecenzieProfile()
        {
            CreateMap<Models.Recenzie, DTOs.RecenzieDto>().ReverseMap();
        }
    }
}
