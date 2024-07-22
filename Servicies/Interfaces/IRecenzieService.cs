using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.UpdateDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface IRecenzieService
    {
        Task<IEnumerable<RecenzieDto>> GetAllRecenziiAsync();
        Task<RecenzieDto> GetRecenzieByIdAsync(int id);
        Task<RecenzieDto> AddRecenzieAsync(CreateRecenzieDto recenzie);
        Task UpdateRecenzieAsync(UpdateRecenzieDto recenzie);
        Task DeleteRecenzieAsync(int id);
    }
}
