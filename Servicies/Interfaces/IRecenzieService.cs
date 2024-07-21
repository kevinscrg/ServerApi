using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface IRecenzieService
    {
        Task<IEnumerable<RecenzieDto>> GetAllRecenziiAsync();
        Task<RecenzieDto> GetRecenzieByIdAsync(int id);
        Task<RecenzieDto> AddRecenzieAsync(CreateRecenzieDto recenzie);
        Task UpdateRecenzieAsync(RecenzieDto recenzie);
        Task DeleteRecenzieAsync(int id);
    }
}
