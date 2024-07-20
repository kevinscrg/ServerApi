using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface ICarteService
    {
        Task<IEnumerable<CarteDto>> GetAllCartiAsync();
        Task<CarteDto> GetCarteByIdAsync(int id);
        Task<CarteDto> AddCarteAsync(CreateCarteDto carte);
        Task UpdateCarteAsync(CarteDto carte);
        Task DeleteCarteAsync(int id);
    }
}
