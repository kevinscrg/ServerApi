using ServerApi.Dtos.CarteDtos;

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
