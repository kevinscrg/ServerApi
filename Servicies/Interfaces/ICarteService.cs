using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.UpdateDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface ICarteService
    {
        Task<IEnumerable<CarteDto>> GetAllCartiAsync();
        Task<CarteDto> GetCarteByIdAsync(int id);
        Task<CarteDto> AddCarteAsync(CreateCarteDto carte);
        Task UpdateCarteAsync(UpdateCarteDto carte);
        Task DeleteCarteAsync(int id);
    }
}
