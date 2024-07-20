using ServerApi.Dtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface IRecenzieService
    {
        Task<IEnumerable<RecenzieDto>> GetAllRecenziiAsync();
        Task<RecenzieDto> GetRecenzieByIdAsync(int id);
        Task<RecenzieDto> AddRecenzieAsync(RecenzieDto recenzie);
        Task UpdateRecenzieAsync(RecenzieDto recenzie);
        Task DeleteRecenzieAsync(int id);
    }
}
