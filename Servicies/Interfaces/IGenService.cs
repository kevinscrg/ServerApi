using ServerApi.Dtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface IGenService
    {
        Task<IEnumerable<GenDto>> GetAllGenuriAsync();
        Task<GenDto> GetGenByIdAsync(int id);
        Task<GenDto> AddGenAsync(GenDto gen);
        Task UpdateGenAsync(GenDto gen);
        Task DeleteGenAsync(int id);
    }
}
