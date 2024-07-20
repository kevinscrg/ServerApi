using ServerApi.Dtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface ICarteService
    {
        Task<IEnumerable<CarteDto>> GetAllCartiAsync();
        Task<CarteDto> GetCarteByIdAsync(int id);
        Task<CarteDto> AddCarteAsync(CarteDto carte);
        Task UpdateCarteAsync(CarteDto carte);
        Task DeleteCarteAsync(int id);
    }
}
