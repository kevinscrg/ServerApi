using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface IRecenzieRepository
    {
        Task<IEnumerable<Recenzie>> GetAllRecenziiAsync();
        Task<Recenzie> GetRecenzieByIdAsync(int id);
        Task<Recenzie> AddRecenzieAsync(Recenzie recenzie);
        Task UpdateRecenzieAsync(Recenzie recenzie);
        Task DeleteRecenzieAsync(int id);
    }
}
